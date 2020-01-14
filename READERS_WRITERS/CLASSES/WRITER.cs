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

        public bool start_thread()
        {
            this.thread.Name = "Writer";
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

        public bool write_buffer(string text,string path_write,string path_read)
        {
            try
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
                System.IO.File.WriteAllBytes(path_write,bytes);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
