using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using csUnit;

namespace MARCDotNet
{
    [TestFixture]
    public class MARCReaderTests
    {
        MARCReader reader1;
        MARCReader reader2;
        MARCReader mkrtest;
        MARCReader largeMARC;
        StreamWriter writer1;
        StreamWriter writer2;
        StreamWriter writerMnem;
        StreamReader mnemtestFile;




        [SetUp]
        public void SetUp()
        {
            this.reader1 = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\test.dat");
            this.writer1 = new StreamWriter(@"test1.dat");

            this.reader2 = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\part24.dat");
            this.writer2 = new StreamWriter(@"test2.dat");

            this.mkrtest = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc");

            this.mnemtestFile = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\anothertest.mrk",Encoding.Default);
            this.writerMnem = new StreamWriter(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\Mnem.mrk");

            this.largeMARC = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\part24.dat");
        }

        [TearDown]
        public void CleanUp()
        {
            this.writer1.Close();
            this.writer2.Close();
            this.writerMnem.Close();

        }

        [Test]
        public void ReadAndToString()
        {
            TextReader mkrStream = new StreamReader(@"C:\mkranswer.txt",Encoding.Default);
            string testString = "";
            foreach(MARCRecord record in mkrtest)
            {
                testString+=record.ToString();
            }
            StringReader test = new StringReader(testString);
            while (test.Peek() != -1 && mkrStream.Peek() != -1)
            {
                Assert.Equals(mkrStream.ReadLine(), test.ReadLine());
            }
        }

        //make sure that all the files can at least be read in a large file
        //note: uncomment for full tests
        //[Test]
        //public void LargeRecordSanity()
        //{

        //    int i = 0;
        //    foreach (MARCRecord record in largeMARC)
        //    {
        //        i++;
        //    }
        //    Assert.Equals(250000, i);

        
        //}


        








    }
}
