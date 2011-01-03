// 
// List.cs
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
using System.Collections;

namespace Ctk
{
    public class List : Widget
    {
        private int offset;
        private int focus_offset;

        private IList model;
        public IList Model {
            get { return model; }
            set {
                model = value;
                offset = 0;
                Render ();
            }
        }

        private bool ellipsize = false;
        public bool Ellipsize {
            get { return ellipsize; }
            set {
                ellipsize = value;
                Render ();
            }
        }

        private Selection selection = new Selection ();
        public Selection Selection {
            get { return selection; }
        }

        protected override void OnRender ()
        {
            if (Model == null || Model.Count <= 0 || Width - 2 <= 0) {
                return;
            }

            for (int i = offset, last = Math.Min (offset + Height, Model.Count); i < last; i++) {
                var line = Model[i].ToString ().Trim ();
                int max_width = Width - 2;

                if (line.Length > max_width) {
                    line = line.Substring (0, ellipsize ? max_width - 3 : max_width).Trim ();
                    if (ellipsize) {
                        line += "...";
                    }
                }

                char scroll_bar;
                if (i == offset) {
                    scroll_bar = '\u25b2';
                } else if (i == last - 1) {
                    scroll_bar = '\u25bc';
                } else if (i == (int)Math.Round ((i / (double)Model.Count) * (Height - 3)) + offset + 1) {
                    scroll_bar = '\u2588';
                } else {
                    scroll_bar = '\u2551';
                }

                if (focus_offset == i - offset && HasFocus) {
                     ConsoleCrayon.Style |= ConsoleCrayon.TextStyle.Inverse;
                }

                if (Selection.Contains (i)) {
                    ConsoleCrayon.BackgroundColor = ConsoleColor.DarkGray;
                }

                Console.SetCursorPosition (X, Y + i - offset);
                Console.Write (line.PadRight (Width - 1));

                ConsoleCrayon.Reset ();

                Console.Write (scroll_bar);
            }

            Console.CursorVisible = false;
        }

        protected override void OnKeyPress (ConsoleKeyInfo key)
        {
            if (Model == null) {
                return;
            }

            int delta = 0;

            switch (key.Key) {
                case ConsoleKey.UpArrow:   delta = -1;      break;
                case ConsoleKey.DownArrow: delta = 1;       break;
                case ConsoleKey.PageUp:    delta = -Height; break;
                case ConsoleKey.PageDown:  delta = Height;  break;
                case ConsoleKey.Spacebar:
                    Selection.ToggleSelect (offset + focus_offset);
                    break;
                case ConsoleKey.Enter:
                    OnActivated ();
                    return;
                default:
                    return;
            }

            var max_focus_offset = Math.Min (Height, Model.Count) - 1;
            focus_offset = Math.Max (0, Math.Min (focus_offset + delta, max_focus_offset));
            if (focus_offset == 0 || focus_offset == max_focus_offset) {
                offset = Math.Max (0, Math.Min (offset + delta, Model.Count - Height));
            }

            Render ();
        }
    }
}