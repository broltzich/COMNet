using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrameFactory
{
    class Frame
    {
        public Frame(FieldType type, WorkstationType sender, WorkstationType recipient, byte size = 0, byte[] data = null)
        {

            int frameLlength = 4 + data.Length;
            byte[] newFrame = new byte[frameLlength];
            //newFrame[0] = Constants.
        }
    }
}
