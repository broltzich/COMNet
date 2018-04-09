using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Convert
{
    public class BinStringConverter
    {
        public BitArray StringToBits(string input)
        {
            byte[] input_byteArray = Encoding.Unicode.GetBytes(input);
            return new BitArray(input_byteArray);
        }

        public string BitsToString(BitArray bits)
        {
            byte[] bytes = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(bytes, 0);          
            return Encoding.Unicode.GetString(bytes);
        }
    }
}
