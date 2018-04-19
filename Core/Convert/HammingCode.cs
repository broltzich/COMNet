using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Convert
{
    public class HammingCode
    {
        public static BitArray Encode(BitArray inBits)
        {
            int bitLength = inBits.Length;
            int i = 0;
            BitArray outBits = new BitArray(bitLength * 2); // выходной массив (в 2 раза больше входного);
            for (int index = 0; index < bitLength;) // заполнение блоков по 8 бит (8-й - пустой бит)
            {
                for (int k = 1; k < 8; k++)
                {
                    if (Math.Log(k, 2) % 1 == 0) // вставка проверочных бит;
                        outBits[i] = false; 
                    else
                    {
                        outBits[i] = inBits[index];
                        index++;
                    }
                    i++;
                }
                // вычисление проверочных бит
                outBits[i - 7] = outBits[i - 5] ^ outBits[i - 3] ^ outBits[i - 1];
                outBits[i - 6] = outBits[i - 5] ^ outBits[i - 2] ^ outBits[i - 1];
                outBits[i - 4] = outBits[i - 3] ^ outBits[i - 2] ^ outBits[i - 1];
                outBits[i] = false;
                i++;
            }
            return outBits;
        }
        public static BitArray Decode(BitArray inBits)
        {
            int index = 0;
            BitArray outBits = new BitArray(inBits.Length / 2);
            bool error = false;
            for (int i = 0; i < inBits.Length; )
            {
                BitArray checkBits = new BitArray(3)
                {
                    [0] = inBits[i] ^ inBits[i + 2] ^ inBits[i + 4] ^ inBits[i + 6],
                    [1] = inBits[i + 1] ^ inBits[i + 2] ^ inBits[i + 5] ^ inBits[i + 6],
                    [2] = inBits[i + 3] ^ inBits[i + 4] ^ inBits[i + 5] ^ inBits[i + 6]
                };
                if ((checkBits[0] == true | checkBits[1] == true | checkBits[2]) == true)
                {
                    if (error)
                        throw new TooManyErrorsException("Errors");
                    int[] errorIndex = new int[1];
                    checkBits.CopyTo(errorIndex, 0);
                    inBits[i + errorIndex[0]] ^= true;
                    error = true;
                    continue;
                } 
                else
                {
                    outBits[index++] = inBits[i + 2];
                    outBits[index++] = inBits[i + 4];
                    outBits[index++] = inBits[i + 5];
                    outBits[index++] = inBits[i + 6];
                    i += 8;
                }
            }
            return outBits;
        }
    }
}
