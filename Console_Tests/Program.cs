using System;

namespace Console_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            bool testResult = Test.Tests();
            while (testResult)
            {
                testResult = Test.Tests();
            }
        }
    }
}