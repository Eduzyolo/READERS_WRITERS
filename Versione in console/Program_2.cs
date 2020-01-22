using System;
using System.Threading;

namespace ReaderWriterLockClass
{
    class akshay
    {
        int initial = 0;
        ReaderWriterLock rwl = new ReaderWriterLock();
        public void myRead(object threadName)
        {
            //Accquire Reader Lock.
            rwl.AcquireReaderLock(Timeout.Infinite);
            Console.WriteLine("Read start: Thread: " + threadName + " " + initial);
            if (threadName.ToString() == "Thread 1")
                //Irregular sleeps makes more chances of
                //Multiple threads trying to access it
                //at same time
                Thread.Sleep(10);
            else
                Thread.Sleep(250);
            Console.WriteLine("Read end  : Thread: " + threadName + " " + initial);
            rwl.ReleaseReaderLock();
            //Release Lock
        }
        public void myWrite()
        {
            rwl.AcquireWriterLock(Timeout.Infinite);
            Console.WriteLine("\nWriter start: " + initial);
            initial++; //Writing
            Console.WriteLine("Writer End: " + initial);
            rwl.ReleaseWriterLock();
            Console.WriteLine();
        }
        static void hain(string[] args)
        {
            akshay p = new akshay();
            for (int i = 0; i < 5; i++)
            {
                Thread t1 = new Thread(p.myRead); //Reader Thread
                //Writer Thread
                Thread t2 = new Thread(new ThreadStart(p.myWrite));
                //Reader Again
                Thread t3 = new Thread(p.myRead);
                //Start all threads
                t1.Start("Thread 1");
                t2.Start();
                t3.Start("Thread 3");
                //Wait for them to finish execution
                t1.Join();
                t2.Join();
                t3.Join();
            }
            Console.Read();
        }
    }
}