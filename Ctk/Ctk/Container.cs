// 
// Container.cs
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
    public abstract class Container : Widget, IEnumerable<Widget>
    {
        private List<Widget> children = new List<Widget> ();
        private Widget focus_child;

        public void Add (Widget child)
        {
            children.Add (child);
            InnerChildAdded (child);
            OnChildAdded (child);
        }

        public void Insert (int position, Widget child)
        {
            children.Insert (position, child);
            InnerChildAdded (child);
            OnChildAdded (child);
        }

        private void InnerChildAdded (Widget child)
        {
            if (HasFocus && ChildCount == 1) {
                FocusChild (child);
            }
        }

        public bool Remove (Widget child)
        {
            var result = children.Remove (child);
            if (result) {
                OnChildRemoved (child);
            }
            return result;
        }

        public int ChildCount {
            get { return children.Count; }
        }

        public Widget this[int index] {
            get { return children[index]; }
        }

        public IEnumerator<Widget> GetEnumerator ()
        {
            return children.GetEnumerator ();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
        {
            return GetEnumerator ();
        }

        protected virtual void OnChildAdded (Widget child)
        {
        }

        protected virtual void OnChildRemoved (Widget child)
        {
        }

        protected override void OnFocus ()
        {
            base.OnFocus ();
            if (ChildCount > 0) {
                FocusChild (this[0]);
            }
        }

        protected override void OnUnfocus ()
        {
            base.OnUnfocus ();
            foreach (var child in this) {
                child.HasFocus = false;
            }
            focus_child = null;
        }

        private void FocusChild (Widget child)
        {
            if (focus_child != null) {
                focus_child.HasFocus = false;
            }

            focus_child = child;

            if (focus_child != null) {
                focus_child.HasFocus = true;
            }
        }

        protected override void OnKeyPress (ConsoleKeyInfo key)
        {
            if (key.Key != ConsoleKey.Tab) {
                return;
            }

            int delta = (key.Modifiers & ConsoleModifiers.Shift) != 0 ? -1 : 1;

            if (focus_child != null) {
                focus_child.HasFocus = false;
            }

            int focus_index = Math.Max (0, Math.Min (children.IndexOf (focus_child) + delta, ChildCount));

            Console.WriteLine ();
            Console.WriteLine ("    {0} ({1})   ", focus_index, ChildCount);
            Console.WriteLine ();

            //FocusChild (this[focus_index]);
        }
    }
}