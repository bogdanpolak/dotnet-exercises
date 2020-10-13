using System;
using System.Collections.Generic;

namespace CodeTest
{
    public static class IEnumerableExtensions
    {
        public static string BuildString<T>(this IEnumerable<T> self, string delim = ",")
        {
            return string.Join(delim, self);
        }
    }

    public class ConsoleTools
    {
        public static void WriteCollection<T>(IEnumerable<T> list)
        {
            Console.WriteLine("[" + list.BuildString(", ") + "]");
        }
    }

}