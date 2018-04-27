using Core.FrameFactory;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Core.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string path = "D:/Projects/COMNet/message.txt";
            byte[] bytes = File.ReadAllBytes(path);
            var frameList = DataFrame.GetFrame(WorkstationType.Workstation1, WorkstationType.Workstation2, bytes);
            Assert.True(frameList.Count == 1 && frameList[0].Length == 19);
        }
    }
}
