using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrameFactory
{
    class ServiceFrame
    {
        public byte[] Connect(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.connection, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] Disconnect(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.disconnection, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] ACK(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.ACK, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] NAK(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.NAK, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] OpenFile(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.file_opening, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
    }
}
