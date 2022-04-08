using System.Collections.Generic;

namespace TestsGenerator.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static string JoinStrings(this IEnumerable<string> e, string? separator) => string.Join(separator, e);
    }
}