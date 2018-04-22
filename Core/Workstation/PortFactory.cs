using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Workstation
{
    class PortFactory
    {
        public static SerialPort CreatePort(string portName)
        {
            var port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One)
            {
                ReadBufferSize = 1024,
                WriteBufferSize = 1024,
                ReadTimeout = 1000,
                WriteTimeout = 1000
            };

            return port;
        }

        
    }
}
