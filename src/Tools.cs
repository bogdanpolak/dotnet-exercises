using System;
using System.Collections.Generic;

namespace DotNetExercises
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
            // using extention: Console.WriteLine("[" + list.BuildString(", ") + "]");
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }
    }

}