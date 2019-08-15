using System;

namespace HelloWorld.Core.Console.Helpers
{
    public static class ConsoleWrapper
    {
        static ConsoleWrapper()
        {
            ResetDelegates();
        }

        public static Action<string> WriteLineDelegate { get; set; }

        public static void ResetDelegates()
        {
            ConsoleWrapper.WriteLineDelegate = System.Console.WriteLine;
        }

        public static void WriteLine(string message) => WriteLineDelegate(message);
    }
}
