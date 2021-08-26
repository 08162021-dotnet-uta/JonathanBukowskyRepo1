
using System;
using System.IO;
using Xunit;

namespace Project0.StoreApplication.Testing
{
    public class OutputTest
    {
        [Fact]
        public void Output_TestOne()
        {
            var _out = Console.Out;
            var stream = new StringWriter();
            Console.SetOut(stream);

            // Run code
            GenerateTestOutput();

            // revert console
            Console.SetOut(_out);
            Assert.Equal("this\nis\ntest\noutput\n", stream.ToString());
        }

        private void GenerateTestOutput()
        {
            Console.WriteLine("this");
            Console.WriteLine("is");
            Console.WriteLine("test");
            Console.WriteLine("output");
        }
    }
}