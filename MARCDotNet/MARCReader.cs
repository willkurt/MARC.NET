using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MARCDotNet
{
    /*This MARCReader is implemented differently then the Pymarc reader is
     * 
     */
    public class MARCReader : IEnumerable
    {
        string recordFileName = "";
        StreamReader marcStream;

        public MARCReader(string fileName)
        {
            this.recordFileName = fileName;
            this.marcStream = new StreamReader(fileName,Encoding.Default);

        }

        public void Close()
        {
            this.marcStream.Close();
        }


        public IEnumerator GetEnumerator()
        {
            return new MARCRecordEnumerator(this);
        }


        public class MARCRecordEnumerator : IEnumerator
        {
            MARCRecord current = null;
            StreamReader file;

            public MARCRecordEnumerator(MARCReader reader)
            {
                this.file = reader.marcStream;
            }

            public bool MoveNext()
            {
                if (this.file.Peek() != -1)
                {
                    this.ReadRecord();
                    return true;
                }
                else
                {
                    return false;
                }

            
            }

            private void ReadRecord()
            {
                char[] headerBuffer = new char[5];
                char[] recordBuffer;
                int recordLength;
                this.file.ReadBlock(headerBuffer, 0, 5);
                recordLength = Int32.Parse(new string(headerBuffer));
                recordBuffer = new char[recordLength - headerBuffer.Length];
                this.file.ReadBlock(recordBuffer,0,recordLength-5);
                this.current=new MARCRecord(new string(headerBuffer)+new string(recordBuffer));
            }

            public void Reset()
            { 
            
            }
            public object Current
            {
                get
                {
                    return this.current;
                }
            }





            public void Dispose()
            {
                this.file.Close();
            }
        }
        
    }
}
