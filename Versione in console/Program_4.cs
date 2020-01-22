using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Versione_in_console
{
    class Program_4
    {
        private static readonly ReaderWriterLockSlim _rwLockSlim = new ReaderWriterLockSlim();
        private static readonly Dictionary<int, string> _map = new Dictionary<int, string>();
        private const int _readersCount = 5;
        private const int _writersCount = 1;
        private const int _readPayload = 100;
        private const int _writePayload = 100;
        private const int _count = 100;
        private static void ReaderProc()
        {
            string val;
            _map.TryGetValue(Environment.TickCount % _count, out val);
            Console.WriteLine("Readinggg");
            Thread.SpinWait(_readPayload);
        }

        private static void WriterProc()
        {
            var n = Environment.TickCount % _count;
            Console.WriteLine("writingg");
            Thread.SpinWait(_writePayload);
            _map[n] = n.ToString();
        }

        private static long Measure(Action reader, Action writer)
        {
            var threads = Enumerable
                .Range(0, _readersCount)
                .Select(n => new Thread(
                  () => {
                      for (int i = 0; i < _count; i++)
                          reader();
                  }))
                .Concat(Enumerable
                  .Range(0, _writersCount)
                  .Select(n => new Thread(
                    () => {
                        for (int i = 0; i < _count; i++)
                            writer();
                    })))
                .ToArray();
            _map.Clear();
            var sw = Stopwatch.StartNew();
            foreach (var thread in threads)
                thread.Start();

            foreach (var thread in threads)
                thread.Join();

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static void RWLockSlimReader()
        {
            _rwLockSlim.EnterReadLock();
            try
            {
                ReaderProc();
            }
            finally
            {
                _rwLockSlim.ExitReadLock();
            }
        }

        private static void RWLockSlimWriter()
        {
            _rwLockSlim.EnterWriteLock();
            try
            {
                WriterProc();
            }
            finally
            {
                _rwLockSlim.ExitWriteLock();
            }
        }
        static void Mai12n()
        {
            // Warm up
            Measure(RWLockSlimReader, RWLockSlimWriter);

            // Measure
            var rwLockSlimTime = Measure(RWLockSlimReader, RWLockSlimWriter);
            Console.WriteLine("ReaderWriterLockSlim: {0}ms", rwLockSlimTime);
            Console.ReadKey();
        }
    }

}

