using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrameFactory
{
    class Frame
    {
        public static List<byte[]> MakeDataFrames(FieldType type, WorkstationType sender, WorkstationType recipient, byte[] data = null)
        {
            int blockSize = 1024;
            byte[] dataBlockSize = BitConverter.GetBytes(blockSize);
            int pos = 0;
            List<byte[]> frameList = new List<byte[]>();
            while(data.Length > pos)
            {
                int endIndex;
                byte[] newFrame = new byte[1024];
                newFrame[0] = (byte)Limiter.start;
                newFrame[1] = (byte)type;
                newFrame[2] = (byte)sender;
                newFrame[3] = (byte)recipient;
                if (data.Length - pos >= blockSize)
                {
                    Array.Copy(dataBlockSize, 0, newFrame, 4, 4);
                    Array.Copy(data, pos, newFrame, 5, 1024);
                    newFrame[1028] = (byte)Limiter.stop;
                }
                else
                {
                    int lowerBlockSize = data.Length % blockSize;
                    Array.Copy(BitConverter.GetBytes(lowerBlockSize), 0, newFrame, 4, 4);
                    Array.Copy(data, pos, newFrame, 5, lowerBlockSize);
                    newFrame[3+lowerBlockSize] = (byte)Limiter.stop;
                }
                
                frameList.Add(newFrame);
                pos += 1024;
            }



            return null;
        }
    }
}
