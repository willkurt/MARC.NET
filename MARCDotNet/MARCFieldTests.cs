using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csUnit;

namespace MARCDotNet
{
    [TestFixture]
    public class MARCFieldTests
    {
        MARCField testObject1;
        MARCField testObjectControl;
        MARCField testObjectSubject;
        MARCField testObjectCurly;
        MARCField testObjectNonASCIIChars;
        [SetUp]
        public void SetUp()
        {
            //title field object
            int tag1 = 245;
            string[] indicators1 = new string[2] { "0", "1" };
            List<string> subfields1 = new List<string> { "a", "Huckleberry Finn: ", "b", "An American Odyssey" };
            string data1 = "";
            testObject1 = new MARCField(tag1, indicators1, subfields1, data1);

            //control field object
            int tag2 = 8;
            string[] indicators2 = new string[0];//empty array
            List<string> subfields2 = null; //null?
            string data2 = "831227m19799999nyu           ||| | ger  ";
            testObjectControl = new MARCField(tag2, indicators2, subfields2, data2);

            //subject field test
            int tag3 = 650;
            string[] indicators3 = new string[2] { " ", "0" };
            List<string> subfields3 = new List<string>{
                                "a", "Python (Computer program language)",
                                "v", "Poetry."
                                };
            string data3 = "";
            testObjectSubject = new MARCField(tag3, indicators3, subfields3, data3);
                
            //curly brackets test

            //string answer3 = @"=500  \\$aThis is a test for the conversion of curly braces; the opening curly brace ({lcub}) and the closing curly brace ({rcub}).";
            int tag4 = 500;
            string[] indicators4 = new string[2] {"",""};
            List<string> subfields4 = new List<string> { "a", "This is a test for the conversion of curly braces; the opening curly brace ({) and the closing curly brace (})." };
            testObjectCurly = new MARCField(tag4,indicators4,subfields4);

            int tag5 = 500;
            string[] indicators5 = new string[2] { "", "" };
            List<string> subfields5 = new List<string> { "a", @"This is a test of diacritics like the uppercase Polish L in " + (char)0xa1 + (char)0xe2 + "od" + (char)0xe2 + "z, the uppercase Scandinavia O in " + (char)0xa2 + "st, the uppercase D with crossbar in " + (char)0xa3 + "uro, the uppercase Icelandic thorn in " + (char)0xa4 + "ann, the uppercase digraph AE in " + (char)0xa5 + "gir" };
            testObjectNonASCIIChars = new MARCField(tag5, indicators5, subfields5);
        }

        [TearDown]
        public void CleanUp()
        {
            testObject1 = null;
            testObjectControl = null;
        }

        

        [Test]
        public void Indicator1()
        {
            Assert.Equals("0", testObject1.Indicator1);
            Assert.Equals(" ", testObjectControl.Indicator1);
            Assert.Equals(" ", testObjectSubject.Indicator1);
        }

        [Test]
        public void Indicator2()
        {
            Assert.Equals("1", testObject1.Indicator2);
            Assert.Equals(" ", testObjectControl.Indicator2);
            Assert.Equals("0", testObjectSubject.Indicator2);
        }

        [Test]
        public void IsControlField()
        {
            Assert.False(testObject1.IsControlField());
            Assert.True(testObjectControl.IsControlField());
            Assert.False(testObjectSubject.IsControlField());
        }

        [Test]
        public void IsSubjectField()
        {
            Assert.False(testObject1.IsSubjectField());
            Assert.False(testObjectControl.IsSubjectField());
            Assert.True(testObjectSubject.IsSubjectField());
        }


        [Test]
        public void TestToString()
        {
            Assert.Equals("=245  01$aHuckleberry Finn: $bAn American Odyssey", testObject1.ToString());
            Assert.Equals(@"=008  831227m19799999nyu\\\\\\\\\\\|||\|\ger\\", testObjectControl.ToString());
            // =040  \\$aViArRB$cViArRB
            string answer= @"=040  \\$aViArRB$cViArRB";
            int testTag = 40;
            string[] indicators = new string[2] { "", "" };
            List<string> subfields = new List<string> { "a", "ViArRB", "c", "ViArRB" };
            MARCField testField = new MARCField(testTag, indicators, subfields);
            Assert.Equals(answer,testField.ToString());

            Assert.Equals(@"=500  \\$aThis is a test for the conversion of curly braces; the opening curly brace ({) and the closing curly brace (}).", testObjectCurly.ToString());
        }

        [Test]
        public void MARCMakerFormat()
        {
            Assert.Equals(@"=500  \\$aThis is a test for the conversion of curly braces; the opening curly brace ({lcub}) and the closing curly brace ({rcub}).", testObjectCurly.MARCMakerFormat());
            Assert.Equals(@"=500  \\$aThis is a test of diacritics like the uppercase Polish L in {Lstrok}{acute}od{acute}z, the uppercase Scandinavia O in {Ostrok}st, the uppercase D with crossbar in {Dstrok}uro, the uppercase Icelandic thorn in {THORN}ann, the uppercase digraph AE in {AElig}gir", testObjectNonASCIIChars.MARCMakerFormat());
        }

        [Test]
        public void GetSubfield()
        {
            Assert.Equals("Huckleberry Finn: ", testObject1.GetSubfield("a"));
            Assert.Null(testObject1.GetSubfield("q"));
        }

        [Test]
        public void GetSubfields()
        {
            string[] singleValueArray1 =  new string[1]{"a"}; 
            string[] response1 = new string[1]{"Huckleberry Finn: "};
            string[] singleValueArray2 = new string[1]{"a"};
            string[] response2 = new string[1] { "Python (Computer program language)" };
            string[] multipleValueArray1 = new string[2] { "a", "b" };
            string[] response3 = new string[2]{"Huckleberry Finn: ", "An American Odyssey"};
            string[] multipleValueArray2 = new string[2] { "a", "v" };
            string[] response4 = new string[2]{"Python (Computer program language)", "Poetry." };

            Assert.Equals(testObject1.GetSubfields(singleValueArray1)[0], response1[0]);
            Assert.Equals(testObjectSubject.GetSubfields(singleValueArray2)[0],response2[0]);
            Assert.Equals(testObject1.GetSubfields(multipleValueArray1)[0], response3[0]);
            Assert.Equals(testObject1.GetSubfields(multipleValueArray1)[1], response3[1]);
            Assert.Equals(testObjectSubject.GetSubfields(multipleValueArray2)[0], response4[0]);
            Assert.Equals(testObjectSubject.GetSubfields(multipleValueArray2)[1], response4[1]);


        }

        [Test]
        public void SetSubfield()
        {
            testObject1.SetSubfield("a", "Crime and Punishment");
            Assert.Equals("=245  01$aCrime and Punishment$bAn American Odyssey", testObject1.ToString());
            Assert.True(testObject1.SetSubfield("a","cheese"));
            Assert.False(testObject1.SetSubfield("z", "cougar"));
        }

        [Test]
        public void GetValue()
        {
            Assert.Equals(testObject1.Value(), "Huckleberry Finn: An American Odyssey");
            Assert.Equals(testObjectControl.Value(), "831227m19799999nyu           ||| | ger  ");
        }

        [Test]
        public void AddSubfield()
        {
            int tag = 245;
            string[] indicators = new string[2] { "0", "1" };
            List<string> subfields = new List<string> { "a", "foo" };
            MARCField testField = new MARCField(tag,indicators,subfields,"");
            testField.AddSubfield("a", "bar");
            Assert.Equals("=245  01$afoo$abar", testField.ToString());
        }


        [Test]
        public void AsMARC21()
        //need to test this against what pymarc produces.
        {
            string fromPymarc = "01" + MARCConstants.SUBFIELD_INDICATOR + "aHuckleberry Finn: " + MARCConstants.SUBFIELD_INDICATOR + "bAn American Odyssey" + MARCConstants.END_OF_FIELD;
            Assert.Equals(fromPymarc,testObject1.AsMARC21());
        }

        [Test]
        public void FormatField()
        {
            string testString1 = "Python (Computer program language) -- Poetry.";
            string testString2 = "Huckleberry Finn:  An American Odyssey";

            Assert.Equals(testString1, testObjectSubject.FormatField());
            Assert.Equals(testString2, testObject1.FormatField());
        }


    }
}
