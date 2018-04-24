using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrameFactory
{
    public enum FieldType : byte
    {
        connection = 1,
        disconnection = 2,
        ACK = 65,
        NAK = 66,
        message_read = 112,

        file_title = 17,
        info = 18,
    }
}
