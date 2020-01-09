using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace READERS_WRITERS.CLASSES
{
    public class SYNCRONISATION
    {
        private Mutex Mutex;

        public Mutex _mutex
        {
            get { return Mutex; }
            set { Mutex = value; }
        }

        public SYNCRONISATION() { }


    }
}
