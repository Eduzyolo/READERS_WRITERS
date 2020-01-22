using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Versione_in_console
{
    class Program_3
    {
        const int MaxProcessi = 1000000; // Metà lettori, metà scrittori
        const int RitardoLettura = 0; // ms
        const int RitardoScrittura = 0; // ms
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
            if (RitardoLettura > 0)
                Thread.Sleep(RitardoLettura);
            dato = buffer;
            Console.WriteLine("Il lettore n. {0} ha letto il buffer. Valore rilevato: {1}", idLettore, dato);
            FineLettura();
        }
        static void Scrivi(int idScrittore)
        {
            int dato;
            InizioScrittura();
            if (RitardoScrittura > 0)
                Thread.Sleep(RitardoScrittura);
            dato = buffer;
            dato++;
            buffer = dato;
            Console.WriteLine("Lo scrittore n. {0} ha modificato il buffer. Nuovo valore: {1}", idScrittore, dato);


            FineScrittura();
        }
        static void iain(string[] args)
        {
            List<Task> lista = new List<Task>();
            for (int i = 1; i <= MaxProcessi / 2; i++)
            {
                int id = i;
                // Avvia un nuovo task lettore
                lista.Add(Task.Factory.StartNew(() => Leggi(id),
               TaskCreationOptions.LongRunning));
                // Avvia un nuovo task scrittore
                lista.Add(Task.Factory.StartNew(() => Scrivi(id),
               TaskCreationOptions.LongRunning));
            }
            // Attende la fine di tutti i lettori/scrittori
            Task.WaitAll(lista.ToArray());
        }

    }
}
