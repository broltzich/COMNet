using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Convert;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using Core.Workstation;

namespace Core
{
    class Program
    {
        static bool _continue;
        static SerialPort _serialPort;

        static void Main(string[] args)
        {
            
            var input = ReadFile();
            /*
            var encoded = HammingCode.Encode(input);
            var decoded = HammingCode.Decode(encoded);
            byte[] bytes = new byte[(decoded.Length - 1) / 8 + 1];
            decoded.CopyTo(bytes, 0);
            File.WriteAllBytes("D:/Projects/COMNet/new_message.txt", bytes);
            Print(decoded);
            */
            PC WS1 = new PC("Workstation1", "COM8", "COM3");
            PC WS2 = new PC("Workstation2", "COM4", "COM5");
            WS1.Login();
            WS2.Login();
            Thread readThread = new Thread();

            Console.WriteLine("End...");
            Console.ReadKey();
        }
        
        static void Print(BitArray input)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < input.Length; i++)
            {
                if (i % 8 == 0 & i != 0)
                    sb.Append("\n");
                else if (i % 4 == 0 && i != 0)
                    sb.Append(' ');
                sb.Append(input[i] ? 1 : 0);
            }
            Console.WriteLine(sb);
        }

        static byte[] ReadFile()
        {
            string file = "D:/Projects/COMNet/large_text.txt";
            byte[] byte_array = File.ReadAllBytes(file);
            return byte_array;
        }
    }
}
