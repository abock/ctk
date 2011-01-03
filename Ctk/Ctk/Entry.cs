// 
// Entry.cs
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
using System.Text;

namespace Ctk
{
    public class Entry : Widget
    {
        private StringBuilder value = new StringBuilder ();
        private int cursor_position;
        private int scroll_offset;

        public string Value {
            get { return value.ToString (); }
            set {
                this.value = new StringBuilder (value);
                SetCursor (0);
            }
        }

        protected override void OnRender ()
        {
            Console.SetCursorPosition (X, Y);
            Console.Write (String.Empty.PadRight (Width));
            Console.SetCursorPosition (X, Y);

            for (int i = Math.Max (0, scroll_offset - cursor_position),
                end = i + Math.Min (value.Length - i, Width); i < end; i++) {
                Console.Write (value[i]);
            }

            Console.SetCursorPosition (X + cursor_position, Y);
        }

        protected override void OnKeyPress (ConsoleKeyInfo key)
        {
            switch (key.Key) {
                case ConsoleKey.Backspace:
                    if (value.Length > 0 && scroll_offset > 0) {
                        MoveCursor (-1);
                        value.Remove (scroll_offset, 1);
                    }
                    break;
                case ConsoleKey.Delete:
                    if (value.Length > 0 && scroll_offset < value.Length) {
                         value.Remove (scroll_offset, 1);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    MoveCursor (-1);
                    break;
                case ConsoleKey.RightArrow:
                    MoveCursor (1);
                    break;
                case ConsoleKey.End:
                    SetCursor (value.Length);
                    break;
                case ConsoleKey.Home:
                    SetCursor (0);
                    break;
                case ConsoleKey.Enter:
                    OnActivated ();
                    break;
                default:
                    if (!Char.IsControl (key.KeyChar)) {
                        value.Insert (scroll_offset, key.KeyChar.ToString ());
                        MoveCursor (1);
                    }
                    break;
            }

            Render ();
        }

        private void SetCursor (int position)
        {
            cursor_position = Math.Max (0, Math.Min (position, Math.Min (Width, value.Length)));
            scroll_offset = Math.Max (0, Math.Min (position, value.Length));
        }

        private void MoveCursor (int delta)
        {
            cursor_position = Math.Max (0, Math.Min (cursor_position + delta, Math.Min (Width, value.Length)));
            scroll_offset = Math.Max (0, Math.Min (scroll_offset + delta, value.Length));
        }
    }
}