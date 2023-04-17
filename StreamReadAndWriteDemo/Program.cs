using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace StreamReadAndWriteDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "";
            string outputFileName = "Duplicate.txt";
            List<string> lines = new List<string>();

            Console.WriteLine("What file do you want me to duplicate?");
            inputFilePath = Console.ReadLine();

            if(File.Exists(inputFilePath))
            {
                Console.WriteLine("File Read beginning");
                // read the file
                string line = "";
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                        Console.WriteLine("Read {0} lines", lines.Count);
                    }
                }
                Console.WriteLine("File Read finish");

                // write the file
                Console.WriteLine("File Write Beginning");

                using (StreamWriter sw = new StreamWriter(outputFileName))
                {
                    sw.WriteLine("Duplicate of : {0}", inputFilePath);
                    sw.WriteLine();
                    for(int x = 0; x < lines.Count; x++)
                    {
                        sw.WriteLine("Line {0}: {1}", x, lines[x]);
                    }
                }

                Console.WriteLine("File Write finish");
            }
            else
            {
                Console.WriteLine("File does not exist!");
            }
            Console.ReadKey();
        }
    }
}
