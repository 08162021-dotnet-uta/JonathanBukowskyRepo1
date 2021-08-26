
using System;
using System.Collections.Generic;
using System.IO;
using Project0.StoreApplication.Client;
using Project0.StoreApplication.Client.Views.Common;
using Xunit;

namespace Project0.StoreApplication.Testing
{
    public class OutputTest : IDisposable
    {
        public void Dispose()
        {
            RestoreIO();
        }
        private TextWriter _out;
        private TextReader _in;

        public OutputTest()
        {
            _out = Console.Out;
            _in = Console.In;
        }

        private void RestoreIO()
        {
            Console.SetOut(_out);
            Console.SetIn(_in);
        }

        public class FakeView : IView
        {
            public List<string> GetMenuOptions()
            {
                return new()
                {
                    "Test Command 1",
                    "Test Command 2"
                };
            }

            public string GetPrompt()
            {
                return "Test Prompt:";
            }

            public Actions HandleUserInput(string input, out IView nextView)
            {
                Assert.Equal("1", input);
                nextView = null;
                return Actions.CLOSE_MENU;
            }

            public void SetContext(Context context)
            {

            }
        }

        [Fact]
        public void Test_BaseView_RunView()
        {
            var ostream = new StringWriter();
            var istream = new StringReader("1\n");

            Console.SetIn(istream);
            Console.SetOut(ostream);

            IView mock = new FakeView();
            BaseView.RunView(mock, null);
            var actual = ostream.ToString();
            Assert.Contains("Test Command 1", actual);
            Assert.Contains("Test Command 2", actual);
        }


        // ********************** This is just an example below ******************************************** //

        [Fact(Skip = "Skip example test")]
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