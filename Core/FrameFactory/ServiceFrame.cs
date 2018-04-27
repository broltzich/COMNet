using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrameFactory
{
    public class ServiceFrame
    {
        public byte[] GetLinkFrame(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.link, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] GetUnlinkFrame(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.unlink, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] GetACKFrame(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.ACK, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] GetNAKFrame(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.NAK, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] GetOpenfileFrame(WorkstationType sender, WorkstationType recipient)
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.openfile, (byte)sender, (byte)recipient, (byte)Limiter.stop };
        }
        public byte[] GetTokenFrame()
        {
            return new byte[] { (byte)Limiter.start, (byte)FieldType.token, (byte)Limiter.stop };
        }
    }
}
