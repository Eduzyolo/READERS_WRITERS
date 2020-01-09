using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace READERS_WRITERS.CLASSES
{
    public class WRITER
    {
        private Thread thread;

        public Thread _thread
        {
            get { return thread; }
            set { thread = value; }
        }

        public WRITER(){ }
    }
}
