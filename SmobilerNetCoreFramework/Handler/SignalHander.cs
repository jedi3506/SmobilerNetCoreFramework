using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmobilerNetCoreFramework.Handler
{
    public class SignalHander
    {
        private static AutoResetEvent resetEvent = new AutoResetEvent(false);
        public static bool Set()
        {
            return resetEvent.Set();
        }

        public static bool Reset()
        {
            return resetEvent.Reset();
        }

        public static bool WaitOne()
        {
            return resetEvent.WaitOne();
        }
    }
}
