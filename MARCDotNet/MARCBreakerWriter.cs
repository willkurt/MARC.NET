using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MARCDotNet
{
    /*
     * Write Marctransmission/MARCRecords as human readable, MARCBreaker format.
     */ 
    public class MARCBreakerWriter : MARCWriter
    {
        public MARCBreakerWriter(string filename): base(filename)
        {
           
        }

        public override void Write(MARCRecord record)
        {
            fileStream.Write(record.MARCMakerFormat());
        }

    }
}
