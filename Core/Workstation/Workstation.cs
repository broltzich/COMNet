using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace Core.Workstation
{
    class PC : IDisposable
    {
        SerialPort COM_in;
        SerialPort COM_out;
        string WorkName;
        
        public PC(string PCName, string inPort, string outPort)
        {
            COM_in = PortFactory.CreatePort(inPort);
            COM_out = PortFactory.CreatePort(outPort);
            WorkName = PCName;
        }
        public void Login()
        {
            try
            {
                COM_in.Open();
                COM_in.DataReceived += COM_in_DataReceived;
                COM_out.Open();
                Console.WriteLine("[{0}] successfully logged in", WorkName);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: cannot open the ports");
                return;
            }

        }

        private void COM_in_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var bytes = ReadBuff();

        }

        public byte[] ReadBuff()
        {
            var result = new List<byte[]>();
            int pos = 0;
            while (COM_in.BytesToRead > 0)
            {
                    int bytesRead = 0;
                    byte[] buff = new byte[1024];
                    bytesRead = COM_in.Read(buff, pos, buff.Length);

                    result.Add(buff.Take(bytesRead).ToArray());
            }

            var byteCount = (result.Count - 1) * 1024 + result.Last().Length;
            var resultBytes = new byte[byteCount];

            var index = 0;
            foreach(var arr in result)
            {
                Array.Copy(arr, 0, resultBytes, index, arr.Length);
                index += 1024;
            }

            return resultBytes;

        }

        public void WriteBuff(byte[] input)
        {
            int pos = 0;
            COM_out.DiscardOutBuffer();
            if (COM_out.BytesToWrite == 0)
            {
                while (pos < input.Length)
                {
                    var dif = input.Length - pos;
                    dif = dif < 1024 ? dif : 1024;
                    COM_out.Write(input, pos, dif);
                    pos += 1024;
                    COM_out.DiscardOutBuffer();
                }
            }
        }

        // Переда
        void PassData()
        {

        }

        public void Dispose()
        {
            if (COM_in.IsOpen)
            {
                COM_in.Close();
                COM_in.Dispose();
            }


        }
        
    }
}
