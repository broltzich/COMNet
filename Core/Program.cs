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

namespace Core
{
    class Program
    {
        static bool _continue;
        static SerialPort _serialPort;

        static void Main(string[] args)
        {
            
            var input = ReadArray();
            /*
            var encoded = HammingCode.Encode(input);
            var decoded = HammingCode.Decode(encoded);
            byte[] bytes = new byte[(decoded.Length - 1) / 8 + 1];
            decoded.CopyTo(bytes, 0);
            File.WriteAllBytes("D:/Projects/COMNet/new_message.txt", bytes);
            Print(decoded);
            */
            PortConnection();
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

        static BitArray ReadArray()
        {
            string file = "D:/Projects/COMNet/message.txt";
            byte[] byte_array = File.ReadAllBytes(file);
            return new BitArray(byte_array);
        }

        static void PortConnection()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string i in ports)
                Console.WriteLine(i);
            Console.Write("PortName: ");
            _serialPort = new SerialPort();
            try
            { 
                _serialPort.PortName = Console.ReadLine();
                _serialPort.BaudRate = 256000;
                _serialPort.Parity = Parity.None;
                _serialPort.DataBits = 7;
                _serialPort.StopBits = StopBits.One;
                _serialPort.ReadTimeout = 1000;
                _serialPort.WriteTimeout = 1000;
                _serialPort.Open();
                
            } 
            catch(Exception e)
            {
                Console.WriteLine("ERROR: cannot open the port");
                return;
            }
            Console.WriteLine("Choose: [send] or [get]");
            string action = Console.ReadLine();
            if (action == "send")
            {
                Console.WriteLine("Type your message:");
                string message = Console.ReadLine();
                _serialPort.WriteLine(message);
                Console.WriteLine("Sended...");
            }
            else if (action == "get")
            {
                Console.WriteLine("Income message: {0}", _serialPort.ReadLine());
            }
            return;
        }

        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
        }

        static void Decode()
        {
            var input = ReadArray();
            BitArray decoded;

            try
            {
                HammingCode.Decode(input);
            }
            catch(TooManyErrorsException e)
            {

            }
            catch(Exception e)
            {

            }
        }
    }
}
