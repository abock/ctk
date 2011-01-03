// 
// DemoDriver.cs
//  
// Author:
//   Aaron Bockover <aaron@abock.org>
// 
// Copyright 2011 Aaron Bockover
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

namespace Ctk.Demo
{
    public class DemoDriver : Screen
    {
        public static void Main ()
        {
            // FIXME: this is to work around a bug in Mono. There appears to be
            // a race in the Init() method of TermInfoDriver - the term info
            // driver for System.Console.
            Console.WriteLine (Console.BufferWidth);
            Console.Clear ();

            Application.Init ();

            var demo = new ListDemo ();

            Application.Invoke (() => demo.Render ());

            Application.Run ();
        }
    }
}

