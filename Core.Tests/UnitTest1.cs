using Core.FrameFactory;
using System;
using System.Collections.Generic;
using Xunit;

namespace Core.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var data = 
            var frames = DataFrame.MakeDataFrames();
            var expected = new List<byte[]>
            {

            };
            Assert.True(frames.Count == 23);
            Assert.True(Array.Equals(frames, expected));
        }
    }
}
