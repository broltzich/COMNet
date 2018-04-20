using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Core
{
    class Workstation
    {
        static SerialPort COM_in;
        static SerialPort COM_out;

        static void Login(string PC_name)
        {
            
        }

        void ConfigurePort(SerialPort PORT)
        {
            PORT.BaudRate = 9600;
            PORT.DataBits = 7;
            PORT.Parity = Parity.None;
            PORT.StopBits = StopBits.One;
            PORT.ReadTimeout = 1000;
            PORT.WriteTimeout = 1000;

        }
    }
}
