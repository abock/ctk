// 
// MainLoop.cs
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
using System.Threading;
using System.Collections.Generic;

namespace Ctk
{
    public class MainLoop
    {
        private object mutex = new object ();

        private Queue<MainLoopEvent> events = new Queue<MainLoopEvent> ();
        private Queue<MainLoopEvent> events_retain = new Queue<MainLoopEvent> ();

        private AutoResetEvent wait_handle = new AutoResetEvent (false);
        private TimeSpan wait_time = TimeSpan.MaxValue;

        public bool IsRunning { get; private set; }

        public bool EventsPending {
            get { lock (mutex) { return events.Count > 0; } }
        }

        public virtual void Init ()
        {
        }

        public virtual void Quit ()
        {
            lock (mutex) {
                events.Clear ();
                IsRunning = false;
                wait_handle.Set ();
            }
        }

        public virtual void Run ()
        {
            lock (mutex) {
                IsRunning = true;
            }

            while (IsRunning) {
                if (wait_time >= TimeSpan.Zero && wait_time < TimeSpan.MaxValue) {
                    wait_handle.WaitOne (wait_time);
                } else {
                    wait_handle.WaitOne ();
                }

                RunIteration ();
            }
        }

        public virtual void RunIteration ()
        {
            lock (mutex) {
                wait_time = TimeSpan.MaxValue;

                while (events.Count > 0) {
                    var @event = events.Dequeue ();

                    if (!@event.IsReady || @event.Run ()) {
                        events_retain.Enqueue (@event);

                        var iterate_wait_time = @event.Iterate ();
                        if (iterate_wait_time < wait_time) {
                            wait_time = iterate_wait_time;
                        }
                    }
                }

                while (events_retain.Count > 0) {
                    events.Enqueue (events_retain.Dequeue ());
                }
            }
        }

        public void EnqueueEvent (MainLoopEvent @event)
        {
            lock (mutex) {
                @event.Init ();
                events.Enqueue (@event);
                wait_handle.Set ();
            }
        }

        public virtual void Invoke (Action action)
        {
            lock (mutex) {
                EnqueueEvent (new InvokeEvent () { Action = action });
            }
        }

        public virtual void Timeout (TimeSpan duration, Func<bool> action)
        {
            lock (mutex) {
                EnqueueEvent (new TimeoutEvent () { Duration = duration, Action = action });
            }
        }
    }
}