using System;
using System.Collections.Generic;

namespace TestsGenerator.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random random = new();

        public static IList<T> Shuffle<T>(this IList<T> source)
        {
            var elementsCount = source.Count;

            while (elementsCount > 1)
            {
                elementsCount--;

                var randomIndex = random.Next(elementsCount + 1);

                (source[randomIndex], source[elementsCount]) = (source[elementsCount], source[randomIndex]);
            }

            return source;
        }
    }
}