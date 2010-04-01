using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MARCDotNet
{
    public class MARCConstants
        //Constants used by Pymarc
    {
        public const int LEADER_LEN  = 24;
        public const int DIRECTORY_ENTRY_LEN = 12;
        public const char SUBFIELD_INDICATOR = (char)0x1F;
        public const char END_OF_FIELD = (char)0x1E;
        public const char END_OF_RECORD = (char)0x1D;
    }
}
