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
using System.Configuration;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "D:/Projects/COMNet/large_text.txt";
            var input = ReadFile(file);

            var com1 = ConfigurationManager.AppSettings["com1"];
            var com2 = ConfigurationManager.AppSettings["com2"];
            var name = ConfigurationManager.AppSettings["name"];

            int size = 1029;
            Console.WriteLine("AAAA: {0}", (size % 1024).ToString());

            PC WS = new PC(name, com1, com2);
            WS.Login();
            Console.WriteLine("Actions: [send] [wait]");
            string choice = "";
            while (choice != "exit")
            {
                choice = Console.ReadLine();
                if (choice == "send")
                    WS.WriteBuff(input);
                else if (choice == "check")
                {
                    WS.CheckBuffers();
                }
            }
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

        static byte[] ReadFile(string path)
        {
            byte[] byte_array = File.ReadAllBytes(path);
            return byte_array;
        }

        static void SendData(byte[] byteArr)
        {
            
        }
    }
}
