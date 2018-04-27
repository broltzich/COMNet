using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrameFactory
{
    public enum FieldType : byte
    {
        link = 1,
        unlink = 2,
        connect = 3,
        disconnect = 4,
        data = 5,
        title = 6,
        openfile = 7,
        ACK = 8,
        NAK = 9,
        token = 128
    }
}
