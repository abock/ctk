// 
// Screen.cs
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
    public class Screen : Container
    {
        protected override void OnChildAdded (Widget child)
        {
            if (ChildCount > 1) {
                Remove (child);
                throw new InvalidOperationException ("Ctk.Screen can have only one child");
            }
        }

        protected override void OnRender ()
        {
            HasFocus = true;

            X = 0;
            Y = 0;
            Width = Console.BufferWidth;
            Height = Console.BufferHeight;

            if (ChildCount > 0) {
                var child = this[0];
                child.X = X;
                child.Y = Y;
                child.Width = Width;
                child.Height = Height;
                child.Render ();
            }
        }
    }
}

