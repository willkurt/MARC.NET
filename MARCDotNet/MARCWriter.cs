using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace MARCDotNet
{
    /*
     * Class that writes to MARC transmission format
     */
    public class MARCWriter
    {
        public delegate MARCRecord MARCProcess(MARCRecord record);

        protected StreamWriter fileStream;

        public MARCWriter(string filename)
        {
            this.fileStream = new StreamWriter(filename);
        }

        public virtual void Write(MARCRecord record)
        {
            this.fileStream.Write(record.AsMARC21());
        }
        
        public void Write(MARCRecord[] recordArray)
        {
            foreach (MARCRecord record in recordArray)
            { 
                Write(record);
            }
        }


        /*
         * Applies a process to a record, and then write that record.
         * note: the process must return a MARCrecord
         */ 
        public void ProcessThenWrite(MARCProcess process, MARCRecord record)
        {
            Write(process(record));
        }

        public void ProcessThenWrite(MARCProcess process, MARCRecord[] records)
        {
            foreach(MARCRecord record in records)
            {
                ProcessThenWrite(process, record);
            }

        }

        public void ProcessThenWrite(MARCProcess process, MARCReader records)
        {
            foreach (MARCRecord record in records)
            {
                ProcessThenWrite(process, record);
            }

        }

        

        public void Close()
        {
            this.fileStream.Close();
            this.fileStream.Dispose();
        }

    }
}
