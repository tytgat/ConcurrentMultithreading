using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReaderWriter
{
    class Program
    {
        public static Semaphore semReader;
        public static Semaphore semWriter;
        public static int maxData = 10;

        static void Main(string[] args)
        {

            /*
             * Note : 
             *  Due to probably the memory managment of c#, I didn't succeded in reading and writing in the same stream. 
             *  The buffer of the writing stream was never updated so the reader thread couldn't read any data.
             *  To fix that, I have to open and close the file inside each thread instead of opening the writer/reader stream only at the begining of each one.
             */

            semReader = new Semaphore(0, 1);
            semWriter = new Semaphore(1, 1);

            //FileStream file = File.Open("./readerWriterFile.txt", FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            // FileStream file = new FileStream("./readerWriterFile.txt", FileMode.Truncate);
            //file.Close();
            Thread reader = new Thread(Reader);
            Thread writer = new Thread(Writer);
            reader.Start(/*file*/);
            writer.Start(/*file*/);
            writer.Join();
            reader.Join();
            //file.Close();
        }

        public static void Writer(object fileStream)
        {
            //StreamWriter file = new StreamWriter(File.Open("./readerWriterFile.txt", FileMode.OpenOrCreate));

            for (int i = 0; i < maxData; i++)
            {
                semWriter.WaitOne();
                StreamWriter file = new StreamWriter(File.Open("./readerWriterFile.txt", FileMode.OpenOrCreate));
                file.Write((char)(i+65));
                Console.WriteLine("Writing");
                file.Flush();
                Thread.Sleep(1000);
                file.Close();
                semReader.Release();
            }

        }

        public static void Reader(object fileStream)
        {
            //StreamReader file = new StreamReader(File.Open("./readerWriterFile.txt", FileMode.OpenOrCreate));

            char[] buffer = new char[1];
            for (int i = 0; i < maxData; i++)
            {
                semReader.WaitOne();
                StreamReader file = new StreamReader(File.Open("./readerWriterFile.txt", FileMode.OpenOrCreate));
                file.Read(buffer,0,1);
                Console.WriteLine("Reading : " + buffer[0]);
                //Thread.Sleep(1000);
                file.Close();

                semWriter.Release();
            }
            
        }

    }
}
