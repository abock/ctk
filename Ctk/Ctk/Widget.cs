// 
// Widget.cs
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

namespace Ctk
{

    public class Widget
    {
        public event EventHandler Activated;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; internal set; }
        public int Height { get; internal set; }

        public int WidthRequest { get; set; }
        public int HeightRequest { get; set; }

        private bool has_focus;
        public bool HasFocus {
            get { return has_focus; }
            set {
                if (has_focus != value) {
                    has_focus = value;

                    if (has_focus) {
                        OnFocus ();
                    } else {
                        OnUnfocus ();
                    }
                }
            }
        }

        public void Render ()
        {
            OnRender ();
        }

        protected virtual void OnFocus ()
        {
            Globals.KeyPress += OnKeyPress;
            Render ();
        }

        protected virtual void OnUnfocus ()
        {
            Globals.KeyPress -= OnKeyPress;
            Render ();
        }

        protected virtual void OnKeyPress (ConsoleKeyInfo key)
        {
        }

        protected virtual void OnRender ()
        {
        }

        protected virtual void OnActivated ()
        {
            var handler = Activated;
            if (handler != null) {
                handler (this, EventArgs.Empty);
            }
        }
    }
}