using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using csUnit;

namespace MARCDotNet
{
    [TestFixture]
    public class MARCRecordTests
    {
        [SetUp]
        public void SetUp()
        { 
        }

        [TearDown]
        public void CleanUp()
        { 
        }

        [Test]
        public void AddField()
        {
            int tag = 245;
            string[] indicators = new string[2]{"1","0"};
            List<string> subfields = new List<string> {"a", "Python", "c", "Guido"};
            MARCField newField = new MARCField(tag, indicators, subfields, "");
            MARCRecord record = new MARCRecord();

            record.AddField(newField);
            Assert.Contains(newField, record.Fields);
        
        }

        [Test]
        public void AddFields()
        {
            int tag1 = 245;
            string[] indicators1 = new string[2] { "1", "0" };
            List<string> subfields1 = new List<string> { "a", "Python", "c", "Guido" };
            MARCField newField1 = new MARCField(tag1, indicators1, subfields1, "");

            int tag2 = 245;
            string[] indicators2 = new string[2] { "1", "0" };
            List<string> subfields2 = new List<string> { "a", "Lisp", "c", "Norvig" };
            MARCField newField2 = new MARCField(tag2, indicators2, subfields2, "");

            MARCRecord record = new MARCRecord();

            record.AddFields(new MARCField[2]{newField1,newField2});
            Assert.Contains(newField1, record.Fields);

            Assert.Contains(newField2, record.Fields);

        }

        [Test]
        public void GetField()
        {
            MARCRecord record = new MARCRecord();
            
            int tag1 = 650;
            string[] indicators1 = new string[2]{"","0"};
            List<string> subfields1 = new List<string>{"a", "Pogramming Language"};
            MARCField subject1 = new MARCField(tag1,indicators1,subfields1,"");

            int tag2 = 650;
            string[] indicators2 = new string[2] { "", "0" };
            List<string> subfields2 = new List<string> { ""};
            MARCField subject2 = new MARCField(tag2, indicators2, subfields2, "");

            record.AddFields(new MARCField[2] {subject1,subject2});
            MARCField[] found = record.GetField(650);
            Assert.Equals(found[0], subject1);
            Assert.Equals(found[1], subject2);
        
        }

        [Test]
        public void GetFields()
        {
            MARCRecord record = new MARCRecord();

            int tag1 = 650;
            string[] indicators1 = new string[2] { "", "0" };
            List<string> subfields1 = new List<string> { "a", "Pogramming Language" };
            MARCField subject1 = new MARCField(tag1, indicators1, subfields1, "");

            int tag2 = 651;
            string[] indicators2 = new string[2] { "", "0" };
            List<string> subfields2 = new List<string> { "a","Object Oriented" };
            MARCField subject2 = new MARCField(tag2, indicators2, subfields2, "");

            record.AddFields(new MARCField[2] { subject1, subject2 });
            Dictionary<int,MARCField[]>  found = record.GetFields(new int[2]{650,651});

            Assert.Equals(found[650][0], subject1);
            Assert.Equals(found[651][0], subject2);
 
        }

        [Test]
        [ExpectedException(typeof(RecordLeaderInvalid))]
        public void TestRecordLeaderInvalid()
        {
            string data = "foo";
            MARCRecord record = new MARCRecord(data);
        }

        [Test]
        [ExpectedException(typeof(BaseAddressInvalid))]
        public void TestBaseAddressInvalid()
        {
            string data = "00695cam  2200241Ia 45x00";
            MARCRecord record = new MARCRecord(data);
        }


        /*DecodeMARC test
         * this is a pretty hefty test to ensure that marc record decoding is performed correctly
         * march data is from: http://marcpm.sourceforge.net/writings/viva.html
         */

        [Test]
        public void DecodeMARC()
        {
            TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc");
            string marcTransmission = marcRecord.ReadToEnd();
                
            MARCRecord testRecord = new MARCRecord(marcTransmission);//decode should happen automatically here
            Assert.Equals("4", testRecord.GetField(50)[0].Indicator2);
            
            Assert.Equals(@"=008  960221s1955\\\\dcuabcdjdbkoqu001\0deng\d", testRecord.GetField(8)[0].ToString());
            //Assert.Equals(@"=050  \4$aPQ1234$b.T39 1955", testRecord.GetField(50)[0].ToString());
            Assert.Equals(@"=260  \\$aWashington, DC :$bLibrary of Congress,$c1955-<1957>", testRecord.GetField(260)[0].ToString());
            Assert.Equals(@"=040  \\$aViArRB$cViArRB", testRecord.GetField(40)[0].ToString());
            Assert.Equals(@"=600  14$aDoe, John,$d1955- $xBiography.", testRecord.GetField(600)[0].ToString());

            marcRecord.Close();
        }

        [Test]
        public void FormatedLeader()
        {
            TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc");
            string marcTransmission = marcRecord.ReadToEnd();

            MARCRecord testRecord = new MARCRecord(marcTransmission);
            Assert.Equals(@"=LDR  01201nam  2200253 a 4500", testRecord.FormatedLeader);

        }

        [Test]
        public void AsMARC21()
        {
            TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc");
            string marcTransmission = marcRecord.ReadToEnd();
            MARCRecord testRecord = new MARCRecord(marcTransmission);//decode should happen automatically here
            //right now I cannot check the header info
            Assert.True(marcTransmission.Contains(testRecord.AsMARC21()));
            marcRecord.Close();

            TextReader singleMarcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\one.dat");
            string singleMarc = singleMarcRecord.ReadToEnd();
            MARCRecord singleTest = new MARCRecord(singleMarc);
            Assert.Equals(singleMarc, singleTest.AsMARC21());
            singleMarcRecord.Close();


        }

        [Test]
        public void Title()
        {
            int tag = 245;
            string[] indicators1 = new string[2] { "0", "1" };
            List<string> subfields1 = new List<string> { "a", "Foo :", "b", "bar" };
            MARCField field1 = new MARCField(tag, indicators1, subfields1);
            MARCRecord record1 = new MARCRecord();
            record1.AddField(field1);

            Assert.Equals("Foo :bar", record1.Title);

            string[] indicators2 = new string[2] { "0", "1" };
            List<string> subfields2 = new List<string> { "a", "Farghin"};
            MARCField field2 = new MARCField(tag, indicators2, subfields2);
            MARCRecord record2 = new MARCRecord();
            record2.AddField(field2);

            Assert.Equals("Farghin", record2.Title);        
        }


        [Test]
        public void ISBN()
        {
            int tag = 20;
            string[] indicators = new string[] { "0", "1" };
            List<string> subfields = new List<string> { "a", "123456789" };
            MARCRecord record = new MARCRecord();
            MARCField field = new MARCField(tag, indicators, subfields);
            record.AddField(field);
            Assert.Equals("123456789", record.ISBN);

            MARCRecord blankRecord = new MARCRecord();
            Assert.Null(blankRecord.ISBN);

        }

        [Test]
        public void Author()
        {
            int tag = 100;
            string[] indicators = new string[] { "1", "0" };
            List<string> subfields = new List<string> { "a", "Bletch, Foobie,", "d", "1979-1981." };
            MARCField field = new MARCField(tag, indicators, subfields);
            MARCRecord record = new MARCRecord();
            record.AddField(field);
            Assert.Equals("Bletch, Foobie, 1979-1981.", record.Author);

            MARCRecord blankRecord = new MARCRecord();
            Assert.Null(blankRecord.Author);
            
        
        }

        [Test]
        //testing to make sure that once a record is created
        //all of the fields are printing right
        public void FieldsTest()
        {
            TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc");
            string marcTransmission = marcRecord.ReadToEnd();

            MARCRecord testRecord = new MARCRecord(marcTransmission);
            Assert.Equals(@"=LDR  01201nam  2200253 a 4500", testRecord.FormatedLeader);
            Assert.Equals(@"=001  tes96000001\", testRecord.GetField(1)[0].ToString());
            Assert.Equals(@"=003  ViArRB", testRecord.GetField(3)[0].ToString());
            Assert.Equals(@"=005  199602210153555.7", testRecord.GetField(5)[0].ToString());
            Assert.Equals(@"=008  960221s1955\\\\dcuabcdjdbkoqu001\0deng\d", testRecord.GetField(8)[0].ToString());
            Assert.Equals(@"=040  \\$aViArRB$cViArRB", testRecord.GetField(40)[0].ToString());
            Assert.Equals(@"=050  \4$aPQ1234$b.T39 1955", testRecord.GetField(50)[0].ToString());
            Assert.Equals(@"=100  2\$aDeer-Doe, J.$q(Jane),$csaint,$d1355-1401,$cspirit.", testRecord.GetField(100)[0].ToString());
            Assert.Equals(@"=245  10$aNew test record number 1 with ordinary data$h[large print] /$cby Jane Deer-Doe ; edited by Patty O'Furniture.", testRecord.GetField(245)[0].ToString());
            Assert.Equals(@"=246  1\$aNew test record number one with ordinary data", testRecord.GetField(246)[0].ToString());
            Assert.Equals(@"=260  \\$aWashington, DC :$bLibrary of Congress,$c1955-<1957>", testRecord.GetField(260)[0].ToString());
            Assert.Equals(@"=300  \\$av. 1-<5> :$bill., maps, ports., charts ;$c cm.", testRecord.GetField(300)[0].ToString());
            Assert.Equals(@"=440  \0$aTest record series ;$vno. 1", testRecord.GetField(440)[0].ToString());
            Assert.Equals(@"=500  \\$aThis is a test of ordinary features like replacement of the mnemonics for currency and dollar signs and backslashes (backsolidus \) used for blanks in certain areas.", testRecord.GetField(500)[0].ToString());
            Assert.Equals(@"=500  \\$aThis is a test for the conversion of curly braces; the opening curly brace ({) and the closing curly brace (}).", testRecord.GetField(500)[1].ToString());
            Assert.Equals(@"=504  \\$aIncludes Bibliographies, discographies, filmographies, and reviews.", testRecord.GetField(504)[0].ToString());
            Assert.Equals(@"=500  \\$aIncludes index.", testRecord.GetField(500)[2].ToString());
            Assert.Equals(@"=650  \4$aTest record$xJuvenile.", testRecord.GetField(650)[0].ToString());
            Assert.Equals(@"=600  14$aDoe, John,$d1955- $xBiography.", testRecord.GetField(600)[0].ToString());
            Assert.Equals(@"=700  1\$aO'Furniture, Patty,$eed.", testRecord.GetField(700)[0].ToString());

        }


        /*Essentially tests that the odd characters that I expect to be in the string actually are.
         * which based on current failings the currenctly aren't
         */ 
        [Test]
        public void SaneRead()
        {
            char polishL = (char)0xa1;
            TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc",Encoding.Default);
            string marcTransmission = marcRecord.ReadToEnd();
            string record2 = marcTransmission.Split(MARCConstants.END_OF_RECORD)[1];
            //basic check that the value is even in the record at all
            Assert.True(record2.Contains(polishL));

            MARCRecord testRecord2 = new MARCRecord(record2);
        
        }


        [Test]
        public void ToStringTest()
        {
            string answer = @"=LDR  01201nam  2200253 a 4500
=001  tes96000001\
=003  ViArRB
=005  199602210153555.7
=008  960221s1955\\\\dcuabcdjdbkoqu001\0deng\d
=040  \\$aViArRB$cViArRB
=050  \4$aPQ1234$b.T39 1955
=100  2\$aDeer-Doe, J.$q(Jane),$csaint,$d1355-1401,$cspirit.
=245  10$aNew test record number 1 with ordinary data$h[large print] /$cby Jane Deer-Doe ; edited by Patty O'Furniture.
=246  1\$aNew test record number one with ordinary data
=260  \\$aWashington, DC :$bLibrary of Congress,$c1955-<1957>
=300  \\$av. 1-<5> :$bill., maps, ports., charts ;$c cm.
=440  \0$aTest record series ;$vno. 1
=500  \\$aThis is a test of ordinary features like replacement of the mnemonics for currency and dollar signs and backslashes (backsolidus \) used for blanks in certain areas.
=500  \\$aThis is a test for the conversion of curly braces; the opening curly brace ({) and the closing curly brace (}).
=504  \\$aIncludes Bibliographies, discographies, filmographies, and reviews.
=500  \\$aIncludes index.
=650  \4$aTest record$xJuvenile.
=600  14$aDoe, John,$d1955- $xBiography.
=700  1\$aO'Furniture, Patty,$eed.
";
            TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc",Encoding.Default);
            string marcTransmission = marcRecord.ReadToEnd();

            MARCRecord testRecord = new MARCRecord(marcTransmission);
            Assert.Equals(answer, testRecord.ToString());
                      
        }

        [Test]
        public void MARCMakerFormat()
        {
            string answer=@"=LDR  01201nam  2200253 a 4500
=001  tes96000001\
=003  ViArRB
=005  199602210153555.7
=008  960221s1955\\\\dcuabcdjdbkoqu001\0deng\d
=040  \\$aViArRB$cViArRB
=050  \4$aPQ1234$b.T39 1955
=100  2\$aDeer-Doe, J.$q(Jane),$csaint,$d1355-1401,$cspirit.
=245  10$aNew test record number 1 with ordinary data$h[large print] /$cby Jane Deer-Doe ; edited by Patty O'Furniture.
=246  1\$aNew test record number one with ordinary data
=260  \\$aWashington, DC :$bLibrary of Congress,$c1955-<1957>
=300  \\$av. 1-<5> :$bill., maps, ports., charts ;$c cm.
=440  \0$aTest record series ;$vno. 1
=500  \\$aThis is a test of ordinary features like replacement of the mnemonics for currency and dollar signs and backslashes (backsolidus \) used for blanks in certain areas.
=500  \\$aThis is a test for the conversion of curly braces; the opening curly brace ({lcub}) and the closing curly brace ({rcub}).
=504  \\$aIncludes Bibliographies, discographies, filmographies, and reviews.
=500  \\$aIncludes index.
=650  \4$aTest record$xJuvenile.
=600  14$aDoe, John,$d1955- $xBiography.
=700  1\$aO'Furniture, Patty,$eed." + "\r\n\r\n";

            string answer2 = @"=LDR  02665nam  2200229 a 4500
=001  tes96000002\
=003  ViArRB
=005  19960221075055.7
=008  960221s1955\\\\dcuabcdjdbkoqu001\0dspa\d
=020  \\$a8472236579
=040  \\$aViArRB$cViArRB
=050  \4$aPQ1234$b.T39 1955
=100  2\$aDeer-Doe, Jane,$d1957-
=245  10$aNew test record number 2 with currently defined ANSEL characters (mostly diacritics) input with their real hexadecimal values$h[large print] /$cby Jane Deer-Doe
=260  \\$aWashington, DC :$bLibrary of Congress,$c1955.
=300  \\$a300 p. :$bill., maps, ports., charts ;$c cm.
=440  \0$aTest record series ;$vno. 2
=500  \\$aThis is a test of diacritics like the uppercase Polish L in {Lstrok}{acute}od{acute}z, the uppercase Scandinavia O in {Ostrok}st, the uppercase D with crossbar in {Dstrok}uro, the uppercase Icelandic thorn in {THORN}ann, the uppercase digraph AE in {AElig}gir, the uppercase digraph OE in {OElig}uvres, the soft sign in rech{softsign}, the middle dot in col{middot}lecci{acute}o, the musical flat in F{flat}, the patent mark in Frizbee{reg}, the plus or minus sign in {plusmn}54%, the uppercase O-hook in B{Ohorn}, the uppercase U-hook in X{Uhorn}A, the alif in mas{mlrhring}alah, the ayn in {mllhring}arab, the lowercase Polish l in W{lstrok}oc{lstrok}aw, the lowercase Scandinavian o in K{ostrok}benhavn, the lowercase d with crossbar in {dstrok}avola, the lowercase Icelandic thorn in {thorn}ann, the lowercase digraph ae in v{aelig}re, the lowercase digraph oe in c{oelig}ur, the lowercase hardsign in s{hardsign}ezd, the Turkish dotless i in masal{inodot}, the British pound sign in {pound}5.95, the lowercase eth in ver{eth}ur, the lowercase o-hook (with pseudo question mark) in S{hooka}{ohorn}, the lowercase u-hook in T{uhorn} D{uhorn}c, the pseudo question mark in c{hooka}ui, the grave accent in tr{grave}es, the acute accent in d{acute}esir{acute}ee, the circumflex in c{circ}ote, the tilde in ma{tilde}nana, the macron in T{macr}okyo, the breve in russki{breve}i, the dot above in {dot}zaba, the dieresis (umlaut) in L{uml}owenbr{uml}au, the caron (hachek) in {caron}crny, the circle above (angstrom) in {ring}arbok, the ligature first and second halves in d{llig}i{rlig}ad{llig}i{rlig}a, the high comma off center in rozdel{rcommaa}ovac, the double acute in id{dblac}oszaki, the candrabindu (breve with dot above) in Ali{candra}iev, the cedilla in {cedil}ca va comme {cedil}ca, the right hook in viet{ogon}a, the dot below in te{dotb}da, the double dot below in {under}k{under}hu{dbldotb}tbah, the circle below in Sa{dotb}msk{ringb}rta, the double underscore in {dblunder}Ghulam, the left hook in Lech Wa{lstrok}{commab}esa, the right cedilla (comma below) in kh{rcedil}ong, the upadhmaniya (half circle below) in {breveb}humantu{caron}s, double tilde, first and second halves in {ldbltil}n{rdbltil}galan, high comma (centered) in g{commaa}eotermika
=504  \\$aIncludes Bibliographies, discographies, filmographies, and reviews.
=500  \\$aIncludes index.
=650  \4$aTest record$xJuvenile.
=600  14$aDoe, John,$d1955- $xBiography."+"\r\n\r\n";
            
            
            TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc",Encoding.Default);
            string marcTransmission = marcRecord.ReadToEnd();
            string record2 = marcTransmission.Split(MARCConstants.END_OF_RECORD)[1];

            MARCRecord testRecord = new MARCRecord(marcTransmission);
            Assert.Equals(answer, testRecord.MARCMakerFormat());

            MARCRecord testRecord2 = new MARCRecord(record2);

            StringReader resultStream = new StringReader(testRecord2.MARCMakerFormat());
            StringReader answerStream = new StringReader(answer2);
            while (resultStream.Peek() != -1 && answerStream.Peek() != -1)
            {   
                string answerLine = answerStream.ReadLine();
                string resultLine = resultStream.ReadLine();
                Assert.Equals(answerLine, resultLine,CharDiff(answerLine,resultLine));
            }

            
            
        }
        
            public string CharDiff(string aString,string bString)
            {
                string message = "the differnce is: ";
                for (int i = 0; i < aString.Length && i < bString.Length; i++)
                {
                    if (aString[i] != bString[i])
                    {
                        return message + aString[i]+" vs " + bString[i] + " at index " + i + "file length is " + bString.Length;
                    }
                }
                return "no difference";
            }

            [Test]
            public void Remove()
            {
            TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc",Encoding.Default);
            string marcTransmission = marcRecord.ReadToEnd();
            MARCRecord testRecord = new MARCRecord(marcTransmission);

//test when only one field is present
            string removed650 = @"=LDR  01201nam  2200253 a 4500
=001  tes96000001\
=003  ViArRB
=005  199602210153555.7
=008  960221s1955\\\\dcuabcdjdbkoqu001\0deng\d
=040  \\$aViArRB$cViArRB
=050  \4$aPQ1234$b.T39 1955
=100  2\$aDeer-Doe, J.$q(Jane),$csaint,$d1355-1401,$cspirit.
=245  10$aNew test record number 1 with ordinary data$h[large print] /$cby Jane Deer-Doe ; edited by Patty O'Furniture.
=246  1\$aNew test record number one with ordinary data
=260  \\$aWashington, DC :$bLibrary of Congress,$c1955-<1957>
=300  \\$av. 1-<5> :$bill., maps, ports., charts ;$c cm.
=440  \0$aTest record series ;$vno. 1
=500  \\$aThis is a test of ordinary features like replacement of the mnemonics for currency and dollar signs and backslashes (backsolidus \) used for blanks in certain areas.
=500  \\$aThis is a test for the conversion of curly braces; the opening curly brace ({) and the closing curly brace (}).
=504  \\$aIncludes Bibliographies, discographies, filmographies, and reviews.
=500  \\$aIncludes index.
=600  14$aDoe, John,$d1955- $xBiography.
=700  1\$aO'Furniture, Patty,$eed.
";
            testRecord.RemoveField(650);
            Assert.Equals(removed650, testRecord.ToString());

//test when there are multiple of the same field
            string remove500 = @"=LDR  01201nam  2200253 a 4500
=001  tes96000001\
=003  ViArRB
=005  199602210153555.7
=008  960221s1955\\\\dcuabcdjdbkoqu001\0deng\d
=040  \\$aViArRB$cViArRB
=050  \4$aPQ1234$b.T39 1955
=100  2\$aDeer-Doe, J.$q(Jane),$csaint,$d1355-1401,$cspirit.
=245  10$aNew test record number 1 with ordinary data$h[large print] /$cby Jane Deer-Doe ; edited by Patty O'Furniture.
=246  1\$aNew test record number one with ordinary data
=260  \\$aWashington, DC :$bLibrary of Congress,$c1955-<1957>
=300  \\$av. 1-<5> :$bill., maps, ports., charts ;$c cm.
=440  \0$aTest record series ;$vno. 1
=504  \\$aIncludes Bibliographies, discographies, filmographies, and reviews.
=600  14$aDoe, John,$d1955- $xBiography.
=700  1\$aO'Furniture, Patty,$eed.
";
            testRecord.RemoveField(500);
            Assert.Equals(remove500, testRecord.ToString());
            }

            [Test]
            public void RemoveFields()
            {
                TextReader marcRecord = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc", Encoding.Default);
                string marcTransmission = marcRecord.ReadToEnd();
                MARCRecord testRecord = new MARCRecord(marcTransmission);

                //test when only one field is present
                string removed650and500 = @"=LDR  01201nam  2200253 a 4500
=001  tes96000001\
=003  ViArRB
=005  199602210153555.7
=008  960221s1955\\\\dcuabcdjdbkoqu001\0deng\d
=040  \\$aViArRB$cViArRB
=050  \4$aPQ1234$b.T39 1955
=100  2\$aDeer-Doe, J.$q(Jane),$csaint,$d1355-1401,$cspirit.
=245  10$aNew test record number 1 with ordinary data$h[large print] /$cby Jane Deer-Doe ; edited by Patty O'Furniture.
=246  1\$aNew test record number one with ordinary data
=260  \\$aWashington, DC :$bLibrary of Congress,$c1955-<1957>
=300  \\$av. 1-<5> :$bill., maps, ports., charts ;$c cm.
=440  \0$aTest record series ;$vno. 1
=504  \\$aIncludes Bibliographies, discographies, filmographies, and reviews.
=600  14$aDoe, John,$d1955- $xBiography.
=700  1\$aO'Furniture, Patty,$eed.
";
                testRecord.RemoveFields(new int[2]{650,500});
                Assert.Equals(removed650and500, testRecord.ToString());
            
            
            }
        
            

            [Test]
            public void MapField()
            { 
                //test the case of 1:1 mapping
                int tag = 245;
                string[] indicators = new string[2] { "1", "0" };
                List<string> subfields = new List<string> { "a", "Python", "c", "Guido" };
                MARCField newField = new MARCField(tag, indicators, subfields, "");
                MARCRecord record = new MARCRecord();

                record.AddField(newField);
                record.MapField(245, 300);
                Assert.Equals(0, record.GetField(245).Length);
                Assert.Equals(1, record.GetField(300).Length);
                
            
            }

            [Test]
            public void HasField()
            { 
     
                int tag = 245;
                string[] indicators = new string[2] { "1", "0" };
                List<string> subfields = new List<string> { "a", "Python", "c", "Guido" };
                MARCField newField = new MARCField(tag, indicators, subfields, "");
                MARCRecord record = new MARCRecord();

                record.AddField(newField);
                Assert.True(record.HasField(245));
                Assert.False(record.HasField(300));

                //test after a map
                record.MapField(245,300);
                Assert.True(record.HasField(300));
                Assert.False(record.HasField(245));
                
            
            }

        [Test]
        public void SortFields()
        {
            MARCRecord messyRecord = new MARCRecord();
            messyRecord.AddField(new MARCField(999
                                                , new string[2] { "1", "0" }
                                                , new List<string> { "a", "stuff" }));
            messyRecord.AddField(new MARCField(645
                                                , new string[2] { "1", "0" }
                                                , new List<string> { "b", "more stuff" }));
            messyRecord.AddField(new MARCField(1
                                                , new string[2] { "1", "0" }
                                                , new List<string> { "c", "zmore stuff" }));
            messyRecord.AddField(new MARCField(997
                                                , new string[2] { "1", "0" }
                                                , new List<string> { "d", "stuffs stuff" }));

            messyRecord.SortFields();
            MARCField[] sortedFields = messyRecord.Fields.ToArray();
            for (int i = 0; i < sortedFields.Length - 1; i++)
            {
                Assert.True(Int32.Parse(sortedFields[i].tag) < Int32.Parse(sortedFields[i + 1].tag));
            }
        }

        //int tag1;
        //string[] indicators1 = new string[]{};
        //List<string> subfields1 = new List<string> { };
        //MARCField field1 = new MARCField(tag1,indicators1, subfields1);
        //MARCRecord record1 = new MARCRecord();
        //record1.AddField(field1);
        //string answer1;
        //Assert.Equals(answer1, record1.UniformTitle);

        //[Test]
        //public void UniformTitle()
        //{
        //    int tag1 = 130;
        //    string[] indicators1 = new string[]{"0",""};
        //    List<string> subfields1 = new List<string> { "a", "Tosefta.", "l", "English.", "f", "1977." };
        //    MARCField field1 = new MARCField(tag1,indicators1,subfields1);
        //    MARCRecord record1 = new MARCRecord();
        //    record1.AddField(field1);
        //    string answer1 = "Tosefta. English. 1977.";
        //    Assert.Equals(answer1, record1.UniformTitle);


        //    int tag2 = 240;
        //    string[] indicators2 = new string[]{"1","4"};
        //    List<string> subfields2 = new List<string>{"a", "The Pickwick papers.", "l", "French."};
        //    MARCField field2 = new MARCField(tag2,indicators2,subfields2);
        //    MARCRecord record2 = new MARCRecord();
        //    record1.AddField(field2);
        //    string answer2 = "The Pickwick papers. French.";
        //    Assert.Equals(answer2, record2.UniformTitle);
        //}


        //[Test]
        //public void Subjects()
        //{
        //    int tag1 = 630;
        //    string[] indicators1 = new string[2]{"0"," "};
        //    List<string> subfields1 = new List<string> { "a", "Tosefta.", "l", "English.", "f", "1977." };
        //    MARCField field1 = new MARCField(tag1, indicators1, subfields1);



        //    int tag2 = 730;
        //    string[] indicators2 = new string[2] { "0", " " };
        //    List<string> subfields2 = new List<string> { "a", "Tosefta.", "l", "English.", "f", "1977." };
        //    MARCField field2 = new MARCField(tag2, indicators2, subfields2);


        //    int tag3 = 600;
        //    string[] indicators3 = new string[2] { "1", "0" };
        //    List<string> subfields3 = new List<string> { "a", "Le Peu, Pepe." };
        //    MARCField field3 = new MARCField(tag3, indicators3, subfields3);



        //}


        //[Test]
        //public void AddedEntries()
        //{

        //}

        //[Test]
        //public void Location()
        //{

        //}

        //[Test]
        //public void Notes()
        //{

        //}

        //[Test]
        //public void Publisher()
        //{

        //}

        //[Test]
        //public void PubYear()
        //{

        //}

    }
}
