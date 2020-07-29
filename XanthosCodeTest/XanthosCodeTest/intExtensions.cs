using System.Diagnostics;

namespace XanthosCodeTest
{
    public static class intExtensions
    {
        [DebuggerStepThrough]
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        [DebuggerStepThrough]
        public static bool IsOdd(this int i)
        {
            return !IsEven(i);
        }

    }
}