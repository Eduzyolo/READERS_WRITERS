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
        #endregion

    }
}
