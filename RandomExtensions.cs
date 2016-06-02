using System;
using System.Collections.Generic;
using System.Linq;

namespace Useful.Utilities
{
    /// <summary>
    /// Extension methods for System.Random objects. 
    /// IEnumerable extension to get a random item. 
    /// </summary>
    public static class RandomExtensions
    {
        private static Random _rdn;
        /// <summary>
        /// Static access to random object
        /// </summary>
        public static Random Random => _rdn ?? (_rdn = new Random());

        /// <summary>
        /// Generate a random string. Can take a string of characters to randomly pick from. 
        /// </summary>
        /// <param name="random"></param>
        /// <param name="length">The total length of the new string to return</param>
        /// <param name="chars">string of characters to pick randomly from</para>
        /// <returns></returns>
        public static string String(this Random random, int length, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generate a random string of numbers (may have leading zeros)
        /// </summary>
        /// <param name="random"></param>
        /// <param name="length"></param>
        /// <param name="chars">string of numbers to pick randomly from</para>
        /// <returns></returns>
        public static string Number(this Random random, int length, string chars = "0123456789")
        {
            return String(random,length,chars);
        }

        /// <summary>
        /// Generate a random phone number (10 random digits formatted as ###-###-####)
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static string PhoneNumber(this Random random)
        {
            return string.Format("{0:###-###-####}", random.Number(10));
        }

        /// <summary>
        /// Generate a random Boolean
        /// </summary>
        /// <param name="random"></param>
        /// <param name="weight"> Percent of weight toward true results. 0 = all false, 1 = all true</param>
        /// <returns></returns>
        public static bool Bool(this Random random, double weight = 0.5)
        {
            return random.NextDouble() >= weight;
        }

        /// <summary>
        /// Randomly sort the items and pick one. 
        /// If the collection is null, null is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RandomItem<T>(this IEnumerable<T> list)
        {
            if (list == null || !list.Any()) return default(T);
            return list.OrderBy(i => Guid.NewGuid()).First();
        }
    }
}
