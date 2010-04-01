using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csUnit;

namespace MARCDotNet
{
    [TestFixture]
    public class MARCMakerMnemonicsTests
    {

        string unprocessed1 = @"This is a test for the conversion of curly braces; the opening curly brace ({) and the closing curly brace (})";
        string processed1 = @"This is a test for the conversion of curly braces; the opening curly brace ({lcub}) and the closing curly brace ({rcub})";

        string unprocessed2 = @"$aThis is a test of diacritics like the uppercase Polish L in "+(char)0xa1+(char)0xe2+"od"+(char)0xe2+"z, the uppercase Scandinavia O in "+(char)0xa2+"st, the uppercase D with crossbar in "+(char)0xa3+"uro, the uppercase Icelandic thorn in "+(char)0xa4+"ann, the uppercase digraph AE in "+(char)0xa5+"gir";
        string processed2 = @"{dollar}aThis is a test of diacritics like the uppercase Polish L in {Lstrok}{acute}od{acute}z, the uppercase Scandinavia O in {Ostrok}st, the uppercase D with crossbar in {Dstrok}uro, the uppercase Icelandic thorn in {THORN}ann, the uppercase digraph AE in {AElig}gir";
        [Test]
        public void ReplaceCharsWithMnemonics()
        { 
            Assert.Equals(processed1,MARCMakerMnemonics.ReplaceCharsWithMnemonics(unprocessed1));
            Assert.Equals(processed2, MARCMakerMnemonics.ReplaceCharsWithMnemonics(unprocessed2));
        
        }

        [Test]
        public void ReplaceMnemsWithChars()
        {
            Assert.Equals(unprocessed2, MARCMakerMnemonics.ReplaceMnemonicsWithChars(processed2));
            Assert.Equals(unprocessed1,MARCMakerMnemonics.ReplaceMnemonicsWithChars(processed1));
        }
       
     
    }
}
