using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using csUnit;

namespace MARCDotNet
{
    [TestFixture]
    public class MARCBreakerWriterTests
    {
        [SetUp]
        public void SetUp()
        { }

        [TearDown]
        public void TearDown()
        { }

        [Test]
        public void OneRecordWrite()
        {
            string answer = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\one.mrk").ReadToEnd();
            MARCBreakerWriter file = new MARCBreakerWriter("breakerOneTest.mrk");
            MARCReader reader = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\one.dat");
            MARCRecord theRecord = new MARCRecord();
            foreach (MARCRecord record in reader) { theRecord = record; }
            file.Write(theRecord);
            file.Close();
            string result = new StreamReader("breakerOneTest.mrk").ReadToEnd();

            //only checks that all of the characters so far are the same, not that the strings are identical
            for(int i = 0; i < answer.Length && i < result.Length;i++)
            {
                Assert.Equals(answer[i],result[i],"difference at "+i+" of "+result.Length+"\n "+(char)answer[i]+" v. "+(char)result[i]);
            }
            Assert.Equals(answer.Length, result.Length, "The answer differs by " + (answer.Length - result.Length).ToString());

        }

        [Test]
        public void MultiRecordWrite()
        {
            string answer = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\marc.mrk").ReadToEnd();
            MARCBreakerWriter file = new MARCBreakerWriter("breakerMultiTest.mrk");
            MARCReader reader = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\marc.dat");
            foreach (MARCRecord record in reader) { file.Write(record); }
            file.Close();
            string result = new StreamReader("breakerMultiTest.mrk").ReadToEnd();

            //only checks that all of the characters so far are the same, not that the strings are identical
            for (int i = 0; i < answer.Length && i < result.Length; i++)
            {
                Assert.Equals(answer[i], result[i], "difference at " + i + " of " + result.Length + "\n " + (char)answer[i] + " v. " + (char)result[i]);
            }
            Assert.Equals(answer.Length, result.Length, "The answer differs by " + (answer.Length - result.Length).ToString());

        }

        [Test]
        public void AnotherMultiRecordWrite()
        {
            string answer = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrk").ReadToEnd();
            MARCBreakerWriter file = new MARCBreakerWriter("breakerMultiTest2.mrk");
            MARCReader reader = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc");
            foreach (MARCRecord record in reader) { file.Write(record); }
            file.Close();
            string result = new StreamReader("breakerMultiTest2.mrk").ReadToEnd();

            //only checks that all of the characters so far are the same, not that the strings are identical
            for (int i = 0; i < answer.Length && i < result.Length; i++)
            {
                Assert.Equals(answer[i], result[i], "difference at " + i + " of " + result.Length + "\n " + (char)answer[i] + " v. " + (char)result[i]);
            }
            Assert.Equals(answer.Length, result.Length, "The answer differs by " + (answer.Length - result.Length).ToString());

        }



    }
}
