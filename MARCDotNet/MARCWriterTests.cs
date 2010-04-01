using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using csUnit;

namespace MARCDotNet
{
    [TestFixture]
    public class MARCWriterTests
    {
        MARCReader reader1;
        MARCReader reader2;
        MARCReader mkrtest;
        MARCReader largeMARC;
        MARCReader oneRecord;
        StreamWriter writer1;
        StreamWriter writer2;




        [SetUp]
        public void SetUp()
        {
            this.oneRecord = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\one.dat");
            //this.oneWriter = new StreamWriter(@"singleRecord.mrc");

            this.reader1 = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\test.dat");
            this.writer1 = new StreamWriter(@"test1.dat");

            this.reader2 = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\part24.dat");
            this.writer2 = new StreamWriter(@"test2.dat");

            this.mkrtest = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc");

            this.largeMARC = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\part24.dat");
        }

        [TearDown]
        public void CleanUp()
        {
            this.writer1.Close();
            this.writer2.Close();

        }

        //public static void ObjectToTransmission(MARCRecord record, string output)
        //{
        //}

        [Test]
        public void WriteOneRecord()
        {
            MARCWriter writer = new MARCWriter("onerecord.dat");
            foreach (MARCRecord record in oneRecord)
            {
                writer.Write(record);
            }
            writer.Close();
            StreamReader answer = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\one.dat");
            StreamReader result = new StreamReader("onerecord.dat");
            char[] answerBuffer = new char[1];
            char[] resultBuffer = new char[1];

            while(answer.Peek() != -1 && result.Peek() != -1)
            {
                answer.ReadBlock(answerBuffer,0,1);
                result.ReadBlock(resultBuffer,0,1);
                Assert.Equals(answerBuffer[0],resultBuffer[0]);
            
            }
                
        }

        [Test]
        public void MediumNumberOfRecords()
        {
            string toWriteFile = "mediumrecords.dat";
            string source = @"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc";
            MARCReader ourHumbleReader = new MARCReader(source);
                MARCWriter writer = new MARCWriter(toWriteFile);
                foreach(MARCRecord record in ourHumbleReader)
                {
                    writer.Write(record);
                }
                writer.Close();
                StreamReader answer = new StreamReader(source,Encoding.Default);
                StreamReader result = new StreamReader(toWriteFile);
                char[] answerBuffer = new char[1];
                char[] resultBuffer = new char[1];

                while (answer.Peek() != -1 && result.Peek() != -1)
                {
                    answer.ReadBlock(answerBuffer, 0, 1);
                    result.ReadBlock(resultBuffer, 0, 1);
                    Assert.Equals(answerBuffer[0], resultBuffer[0], ScanMessage((char)answerBuffer[0], (char)resultBuffer[0]));

                }
        
        
        
        }




        //[Test]
        //public void LargeNumberOfRecords()
        //{
        //    MARCWriter writer = new MARCWriter("manyrecords.dat");
        //    foreach (MARCRecord record in largeMARC)
        //    {
        //        writer.Write(record);
        //    }
        //    writer.Close();
        //    StreamReader answer = new StreamReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\part24.dat", Encoding.Default);
        //    StreamReader result = new StreamReader("manyrecords.dat");
        //    char[] answerBuffer = new char[1];
        //    char[] resultBuffer = new char[1];

        //    while (answer.Peek() != -1 && result.Peek() != -1)
        //    {
        //        answer.ReadBlock(answerBuffer, 0, 1);
        //        result.ReadBlock(resultBuffer, 0, 1);
        //        Assert.Equals(answerBuffer[0], resultBuffer[0]);

        //    }

        //}

        [Test]
        public void MediumNumberOfRecordsWithRecordArrays()
        {
            string toWriteFile = "groupsmedium.dat";
            string source = @"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\makrtest.mrc";
            MARCWriter groups = new MARCWriter(toWriteFile);
            MARCReader ourHumbleReader = new MARCReader(source);
            MARCRecord[] recordGroup = new MARCRecord[5];
            int i = 0;
            foreach (MARCRecord record in ourHumbleReader)
            {
                if (i == 5)
                {
                    i = 0;
                    groups.Write(recordGroup);
                }
                recordGroup[i] = record;
                i++;
            }
            for (int j = 0; j < i; j++)
            { 
                groups.Write(recordGroup[j]);
            
            }

            groups.Close();
            StreamReader answer = new StreamReader(source, Encoding.Default);
            StreamReader result = new StreamReader(toWriteFile);
            char[] answerBuffer = new char[1];
            char[] resultBuffer = new char[1];

            while (answer.Peek() != -1 && result.Peek() != -1)
            {
                answer.ReadBlock(answerBuffer, 0, 1);
                result.ReadBlock(resultBuffer, 0, 1);
                Assert.Equals(answerBuffer[0], resultBuffer[0]);

            }
        }


        //[Test]
        //public void LargeNumberOfRecordsWithRecordArrays()
        //{
        //    string toWriteFile = "groupslarge.dat";
        //    string source = @"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\part24.dat";
        //    MARCWriter groups = new MARCWriter(toWriteFile);
        //    MARCReader ourHumbleReader = new MARCReader(source);
        //    MARCRecord[] recordGroup = new MARCRecord[5];
        //    int i = 0;
        //    foreach (MARCRecord record in ourHumbleReader)
        //    {
        //        if (i == 5)
        //        {
        //            i = 0;
        //            groups.Write(recordGroup);
        //        }
        //        recordGroup[i] = record;
        //        i++;
        //    }
        //    for (int j = 0; j < i; j++)
        //    {
        //        groups.Write(recordGroup[j]);

        //    }

        //    groups.Close();
        //    StreamReader answer = new StreamReader(source, Encoding.Default);
        //    StreamReader result = new StreamReader(toWriteFile);
        //    char[] answerBuffer = new char[1];
        //    char[] resultBuffer = new char[1];

        //    while (answer.Peek() != -1 && result.Peek() != -1)
        //    {
        //        answer.ReadBlock(answerBuffer, 0, 1);
        //        result.ReadBlock(resultBuffer, 0, 1);
        //        Assert.Equals(answerBuffer[0], resultBuffer[0]);

        //    }
        //}


        private string ScanMessage(char value1, char value2)
        {
            return "expected " + value1 + " got " + value2;
        
        }

        [Test]
        public void ProcessThenWriteSingeRecord()
        {
            MARCWriter proctest = new MARCWriter(@"proctest.dat");
            MARCRecord procrecord = new MARCRecord();
            proctest.ProcessThenWrite(new MARCWriter.MARCProcess(testProc), procrecord);
            proctest.Close();

            MARCReader test = new MARCReader(@"proctest.dat");
            foreach (MARCRecord record in test)
            {
                string testValue = record.GetField(999)[0].FormatField();
                Assert.Equals("hello there!", testValue);
            }
            test.Close();
        }

        [Test]
        public void ProcessThenWriteMultipeRecords()
        {
            MARCWriter proctests = new MARCWriter(@"proctests.dat");
            MARCRecord[] procrecords = new MARCRecord[4] { new MARCRecord(), new MARCRecord(), new MARCRecord(), new MARCRecord() };
            proctests.ProcessThenWrite(new MARCWriter.MARCProcess(testProc), procrecords);
            proctests.Close();

            MARCReader test = new MARCReader(@"proctests.dat");
            foreach (MARCRecord record in test)
            {
                string testValue = record.GetField(999)[0].FormatField();
                Assert.Equals("hello there!", testValue);
            }
            test.Close();
        }

        [Test]
        public void ProcessThenWriteReader()
        {
            MARCWriter proctests = new MARCWriter(@"proctestforreader.dat");
            MARCReader procrecords = new MARCReader(@"C:\Documents and Settings\wkurt\My Documents\Visual Studio 2008\Projects\TestMARC\TestMARC\marc.dat");
            proctests.ProcessThenWrite(new MARCWriter.MARCProcess(testProc), procrecords);
            proctests.Close();

            MARCReader test = new MARCReader(@"proctestforreader.dat");
            foreach (MARCRecord record in test)
            {
                string testValue = record.GetField(999)[0].FormatField();
                Assert.Equals("hello there!", testValue);
            }
            test.Close();
        }
        
        private MARCRecord testProc(MARCRecord record)
            {
                record.AddField(new MARCField(999,new string[2]{"",""},new List<string>{"a","hello there!"}));
                return record; 
            }


       
    }
}
