using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Versione_in_console
{
    class Program_1
    {
        const int n_reader = 4;
        const int n_writer = 1;
        static SemaphoreSlim wrt = new SemaphoreSlim(1);
        static SemaphoreSlim mutex = new SemaphoreSlim(1);
        static SemaphoreSlim read_counter = new SemaphoreSlim(0, n_reader);
        static string buffer = "basic buffer";
        static string old_buffer=null;

        static void Reader()
        {
            mutex.Wait();
            read_counter.Release();
            if (read_counter.CurrentCount==1)
            {
                Console.WriteLine("WRT WAIT");
                wrt.Wait();
            }
            mutex.Release();
            Console.WriteLine(buffer);
            mutex.Wait();
            read_counter.Wait();
            if (read_counter.CurrentCount==0)
            {
                Console.WriteLine("WRT REALESE");
                wrt.Release();
            }
            mutex.Release();
        }
        static void Writer()
        {
            wrt.Wait();
            if (old_buffer!=buffer)
            {
                old_buffer = buffer;
                int j = 0;
                while (j < 1000)
                {
                    buffer = j.ToString();
                    j++;
                }
                Console.WriteLine(old_buffer);
                Console.WriteLine(buffer);
            }
            wrt.Release();
        }
        static void Mai21n(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            Thread thread = null;
            for (int i = 0; i < n_writer; i++)
            {
                thread = new Thread(Writer);
                thread.Name = "Writer " + i.ToString();
                threads.Add(thread);
            }
            for (int i = 0; i < n_reader; i++)
            {
                thread = new Thread(Reader);
                thread.Name = "Reader " + i.ToString();
                threads.Add(thread);
            }

            threads[0].Start();
            Console.WriteLine(threads[0].Name+"\tSTARTED");
            for (int i = 1; i < threads.Count; i++)
            {
                threads[i].Start();
                Console.WriteLine(threads[i].Name + "\tSTARTED\tSTATE\t" + threads[i].ThreadState);
                Thread.Sleep(50);

            }
            int j = 0;
            while (j<1000)
            {
                buffer = j.ToString();
                j++;
            }
            foreach (Thread item in threads)
            {
                Console.WriteLine(item.Name+"\tJOINED\tSTATE\t"+ item.ThreadState);
                item.Join();
            }
            Console.WriteLine("FINISHED");
            Console.ReadKey();
        }

    }
}
