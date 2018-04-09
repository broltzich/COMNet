using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Convert;
using System.Collections;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "D:/Projects/COMNet/message.txt";
            string input;
            BitArray output;
            var converter = new BinStringConverter();
            using (var sr = new StreamReader(file))
            {
                input = sr.ReadToEnd();
                output = converter.StringToBits(input);
            }
            var sb = new StringBuilder();
            for (var i = 0; i < output.Length; i++)
            {
                if (i % 8 == 0 & i != 0)
                    sb.Append(' ');
                sb.Append(output[i] ? 1 : 0);
            }
            Console.WriteLine(sb);
            var decoded = new BinStringConverter();
            Console.WriteLine(decoded.BitsToString(output));
            Console.WriteLine("End...");
            Console.ReadKey();
        }
    }
}
