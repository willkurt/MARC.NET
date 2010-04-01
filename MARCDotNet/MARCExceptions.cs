using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MARCDotNet
{
    abstract class MARCSharpException : ApplicationException
    { 
      
    }

    class RecordLengthInvalid : MARCSharpException
    { 
          //return "Invalid record length in first 5 bytes of record";
    }

    class RecordLeaderInvalid : MARCSharpException
    {
        public override string ToString()
        {
            return "Unable to extract record leader";
        }
        
    }

    class RecordDirectoryInvalid : MARCSharpException
    {
        public override string ToString()
        {
            return "Invalid directory";
        }

    }

    class NoFieldsFound : MARCSharpException
    {
        public override string ToString()
        {
            return "Unable to locate fields in record data";
        }
    }

    class BaseAddressInvalid : MARCSharpException
    {
        public override string ToString()
        {
            return "Base address exceeds size of record";
        }
    }


    class BaseAddressNotFound : MARCSharpException
    {
        public override string ToString()
        {
            return "Unable to locate base address of record";
        }
    }

    class WriteNeedsRecord : MARCSharpException
    {
        public override string ToString()
        {
            return "Write requires a pymarc.Record object as an argument";
        }
    }

    class NoActiveFile : MARCSharpException
    {
        public override string ToString()
        {
            return "There is no active file to write to in call to write";
        }
    }
}
