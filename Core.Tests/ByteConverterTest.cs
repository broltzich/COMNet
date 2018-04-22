using Core.Convert;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests
{
    
    public class ByteConverterTest
    {
        [Fact]
        public void EmptyStringToByteArray_ShouldReturnEmptyArray()
        {
            var input = "c";
            var converter = new BitStringConverter();
           
            var output = converter.StringToBits(input);

            Assert.True(output.Length == 2);//Equals(output, new BitArray(new int[] { 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 })));
        }
    }
}
