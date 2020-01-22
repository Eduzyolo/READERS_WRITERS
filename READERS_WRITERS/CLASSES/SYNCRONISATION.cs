using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace READERS_WRITERS.CLASSES
{
    public class SYNCRONISATION
    {
        #region Propertyes
        private Mutex Mutex;
        private Semaphore Db;
        private List<WRITER> Writers;
        private List<READER> Readers;

        public List<READER> _readers
        {
            get { return Readers; }
            set { Readers = value; }
        }

        private CRYPTOGRAFY crypto;

        public CRYPTOGRAFY _crypto
        {
            get { return crypto; }
            set { crypto = value; }
        }

        public List<WRITER> _writers
        {
            get { return Writers; }
            set { Writers = value; }
        }


        public Semaphore _db
        {
            get { return Db; }
            set { Db = value; }
        }


        public Mutex _mutex
        {
            get { return Mutex; }
            set { Mutex = value; }
        }
        #endregion

        #region Methods
        public SYNCRONISATION() { }

        public string read_file(string path)
        {
            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                string text = System.Text.Encoding.UTF8.GetString(bytes);
                return text;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public bool inizialize(int N_readers,int N_writers)
        {
            try
            {
                if (N_readers > 0 && N_writers > 0)
                {
                    this.Readers = new List<READER>(N_readers);
                    this.Writers = new List<WRITER>(N_writers);
                    this.Mutex = new Mutex(true, "Access_to_memory");
                    this.Db = new Semaphore(1, N_readers, "Control access to database");
                    for (int i = 0; i < N_readers; i++)
                    {
                        this.Readers[i] = new READER();
                    }

                    for (int i = 0; i < N_writers; i++)
                    {
                        this.Writers[i] = new WRITER();
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        public void start()
        {
            foreach (var item in this.Readers){ item.start_thread(); }
            foreach (var item in this.Writers) { item.start_thread(); }
        }
        #endregion

    }
}
