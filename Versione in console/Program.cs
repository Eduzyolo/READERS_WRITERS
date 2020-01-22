using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Versione_in_console
{
    class Program
    {
        const int N_lettori = 5; // Metà lettori, metà scrittori
        const int N_Scrittori = 6;
                                        // Regola l'accesso alla variabile NumLettori
        static SemaphoreSlim mutex = new SemaphoreSlim(1);
        // Regola l'accesso al buffer per sacrivere/leggere
        static SemaphoreSlim sincro = new SemaphoreSlim(1);
        static SemaphoreSlim semLinea = new SemaphoreSlim(1);
        static int numLettori = 0;
        static int buffer = 100;
        static void InizioLettura()
        {
            semLinea.Wait();
            mutex.Wait();
            numLettori++;
            if (numLettori == 1)
                sincro.Wait();
            mutex.Release();
            semLinea.Release();
        }
        static void FineLettura()
        {
            mutex.Wait();
            numLettori--;
            if (numLettori == 0)
                sincro.Release();
            mutex.Release();
        }
        static void InizioScrittura()
        {
            semLinea.Wait();
            sincro.Wait();
            semLinea.Release();
        }
        static void FineScrittura()
        {
            sincro.Release();
        }
        static void Leggi(int idLettore)
        {
            int dato;
            InizioLettura();
            Thread.Sleep(1);
            dato = buffer;
            Console.WriteLine("Il lettore n. {0} ha letto il buffer. Valore rilevato: {1}", idLettore, dato);
            FineLettura();
        }
        static void Scrivi(int idScrittore)
        {
            int dato;
            InizioScrittura();
            Thread.Sleep(1); 
            dato = buffer;
            dato++;
            buffer = dato;
            Console.WriteLine("Lo scrittore n. {0} ha modificato il buffer. Nuovo valore: {1}", idScrittore, dato);


            FineScrittura();
        }
        static void Main(string[] args)
        {
            List<Task> lista = new List<Task>();
            for (int i = 0; i < N_Scrittori+N_lettori; i++)
            {
                if (N_Scrittori-i>0)
                {
                    lista.Add(Task.Factory.StartNew(() => Scrivi(i), TaskCreationOptions.LongRunning));
                }
                if (N_lettori-i>0)
                {
                    lista.Add(Task.Factory.StartNew(() => Leggi(i), TaskCreationOptions.LongRunning));
                }
            }
            // Attende la fine di tutti i lettori/scrittori
            Task.WaitAll(lista.ToArray());
            Console.ReadKey(); 
        }


    }

}

