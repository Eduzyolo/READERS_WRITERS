using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace READERS_WRITERS.CLASSES
{
    public class READER
    {
        private Thread thread;

        public Thread _thread
        {
            get { return thread; }
            set { thread = value; }
        }
        public READER() { }

        public bool start_thread()
        {
            this.thread.Name = "Reader";
            this.thread.Start();
            Thread.Sleep(500);
            if (this.thread.IsAlive)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
