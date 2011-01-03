// 
// Box.cs
//  
// Author:
//   Aaron Bockover <aaron@abock.org>
// 
// Copyright 2010 Aaron Bockover
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace Ctk
{
    public class Box : Container
    {
        private class Packing
        {
            public bool Fill = true;
            public bool Expand = true;
            public int Spacing = -1;
            public double SizeRatio;

            public Packing ()
            {
            }

            public Packing (bool fill, bool expand, int spacing)
            {
                Fill = fill;
                Expand = expand;
                Spacing = spacing;
            }
        }

        private Dictionary<Widget, Packing> packing_map = new Dictionary<Widget, Packing> ();

        public void PackStart (Widget child)
        {
            Pack (child, new Packing (), false);
        }

        public void PackStart (Widget child, bool fill, bool expand, int spacing)
        {
            Pack (child, new Packing (fill, expand, spacing), false);
        }

        public void PackEnd (Widget child)
        {
            Pack (child, new Packing (), true);
        }

        public void PackEnd (Widget child, bool fill, bool expand, int spacing)
        {
            Pack (child, new Packing (fill, expand, spacing), true);
        }

        private void Pack (Widget child, Packing packing, bool end)
        {
            MapPacking (child, packing);
            Add (child);
        }

        private void MapPacking (Widget child, Packing packing)
        {
            if (packing_map.ContainsKey (child)) {
                packing_map[child] = packing;
            } else {
                packing_map.Add (child, packing);
            }
        }

        protected override void OnChildAdded (Widget child)
        {
            if (!packing_map.ContainsKey (child)) {
                packing_map.Add (child, new Packing ());
            }
        }

        protected override void OnChildRemoved (Widget child)
        {
            packing_map.Remove (child);
        }

        protected override void OnRender ()
        {
            if ((Horizontal && Width <= 0) || (!Horizontal && Height <= 0)) {
                return;
            }

            int static_alloc = 0;
            int variable_alloc = 0;
            int expand_count = 0;

            foreach (var child in this) {
                var packing = packing_map[child];
                if (packing.Expand) {
                    expand_count++;
                } else {
                    static_alloc += Horizontal ? child.WidthRequest : child.HeightRequest;
                }
            }

            static_alloc = Math.Max (0, Math.Min (Width, static_alloc));
            variable_alloc = Math.Max (0, (Horizontal ? Width : Height) - static_alloc) / expand_count;

            int child_x = X;
            int child_y = Y;

            foreach (var child in this) {
                var packing = packing_map[child];

                child.X = child_x;
                child.Y = child_y;

                if (Horizontal) {
                    child.Width = Math.Max (0, packing.Expand ? variable_alloc : child.WidthRequest);
                    child.Height = Math.Max (0, Height);
                    child_x += child.Width;
                } else {
                    child.Width = Math.Max (0, Width);
                    child.Height = Math.Max (0, packing.Expand ? variable_alloc : child.HeightRequest);
                    child_y += child.Height;
                }

                if (child.Width >= 0 && child.Height >= 0) {
                    child.Render ();
                }
            }
        }

        private bool horizontal;
        public bool Horizontal {
            get { return horizontal; }
            set {
                horizontal = value;
                Render ();
            }
        }
    }
}