using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Useful.Utilities
{

    /// <summary>
    /// Extensions and helper methods
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Convert a string object to an Enum
        /// </summary>
        /// <code lang="c#">
        /// //define some example enums
        /// enum SomeEnum { Yes, No, File_Not_Found }
        /// enum AnotherEnum { No, Maybe, Yes }
        /// 
        /// //turn a string into an enum
        /// SomeEnum yes = "Yes".ToEnum&lt;SomeEnum&gt;();
        /// // replace spaces with _
        /// SomeEnum fileNotFound = "File not found".ToEnum&lt;SomeEnum&gt;("_");
        /// 
        /// //convert one enum to another enum with matching name (not value)
        /// SomeEnum someEnumYes = SomeEnum.Yes; //value of 0
        /// AnotherEnum anotherEnumYes = someEnumYes.ToEnum&lt;AnotherEnum&gt;(); //value of 2
        /// </code>
        /// <typeparam name="T">The type of Enum to convert to</typeparam>
        /// <param name="value">The object to convert</param>
        /// <param name="spaceReplace">If value has spaces, They will be replaced</param>
        /// <returns></returns>
        public static T ToEnum<T>(object value, string spaceReplace = "")
        {
            return ((string)value).ToEnum<T>(spaceReplace);
        }

        /// <summary>
        /// Convert a string to an Enum
        /// </summary>
        /// <typeparam name="T">The type of Enum to convert to</typeparam>
        /// <param name="value">The object to convert</param>
        /// <param name="spaceReplace">If value has spaces, They will be replaced</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value, string spaceReplace = "")
        {
            return (T)Enum.Parse(typeof(T), value.Replace(" ", spaceReplace));
        }


        /// <summary>
        /// Convert a byte array to a hexadecimal string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string ToHex(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            var c = new char[bytes.Length * 2];

            for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
            {
                var b = ((byte)(bytes[bx] >> 4));
                c[cx] = (char)(b > 9 ? b - 10 + 'A' : b + '0');

                b = ((byte)(bytes[bx] & 0x0F));
                c[++cx] = (char)(b > 9 ? b - 10 + 'A' : b + '0');
            }

            return new string(c);
        }

        /// <summary>
        /// Gets attribute from an enumeration object
        /// </summary>
        /// <typeparam name="T">Input type</typeparam>
        /// <typeparam name="TExpected">The return type</typeparam>
        /// <param name="enumeration">The enum value</param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static TExpected GetAttribute<T, TExpected>(this Enum enumeration, Func<T, TExpected> expression) where T : Attribute
        {
            T attribute = enumeration.GetType().GetMember(enumeration.ToString())[0].GetCustomAttributes(typeof(T), false).Cast<T>().SingleOrDefault();

            return attribute == null ? default(TExpected) : expression(attribute);
        }

        /// <summary>
        /// Gets the description value from the <see cref="DescriptionAttribute"/> of the enum. 
        /// If enum doesn't have a description attribute, null is returned
        /// </summary>
        /// <param name="enumeration">The enum value to look at</param>
        /// <returns>description value from the <see cref="DescriptionAttribute"/> or null</returns>
        public static string Description(this Enum enumeration)
        {
            var attribute = enumeration.GetType().GetMember(enumeration.ToString())[0].GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().SingleOrDefault();

            return attribute == null ? default(string) : attribute.Description;
        }

        /// <summary>
        /// If the nullable Boolean value is null or false, false is returned. 
        /// if the nullable Boolean has a value and its true, true is returned. 
        /// </summary>
        /// <param name="value">nullable Boolean</param>
        /// <returns>true or false</returns>
        public static bool IsTrue(this bool? value)
        {
            return value != null && value.Value;
        }

        /// <summary>
        /// If the nullable Boolean value is null or true, true is returned. 
        /// if the nullable Boolean has a value and its false, false is returned. 
        /// </summary>
        /// <param name="value">nullable Boolean</param>
        /// <returns>true or false</returns>
        public static bool IsTrueOrNull(this bool? value)
        {
            return value == null || value.Value;
        }

        /// <summary>
        /// If object is null <see cref="value"/> is returned. 
        /// If object is empty string or min date time, <see cref="value"/> is returned. 
        /// If object is a different type then value it may be casted or may throw an <see cref="InvalidCastException"/>
        /// </summary>
        /// <typeparam name="T">The default value type</typeparam>
        /// <param name="obj">the object</param>
        /// <param name="value">Default value to return when object is null or doesn't match rules</param>
        /// <exception cref="InvalidCastException">When object is different type then default value InvalidCastException might be thrown</exception>
        /// <returns></returns>
        public static T Default<T>(this object obj, T value = default(T))
        {
            if (obj == null || Equals(obj, default(T))) return value;
            if (obj is string && string.IsNullOrWhiteSpace(obj.ToString())) return value;
            if (obj is DateTime && DateTime.MinValue.Equals(obj)) return value;
            if (obj is T) return (T)obj;

            var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            obj = (T)Convert.ChangeType(obj, type);
            if (obj == null || Equals(obj, default(T))) return value;
            return (T)obj;
        }

        /// <summary>
        /// Round a number down. Can set number of decimal places.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static float RoundDown(this float number, int decimalPlaces = 0)
        {
            return (float)(Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces));
        }
        /// <summary>
        /// Round a number up. Can set number of decimal places.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static float RoundUp(this float number, int decimalPlaces = 0)
        {
            return (float)(Math.Ceiling(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces));
        }

        /// <summary>
        /// Convert s string to a long, throws cast exception if it fails
        /// </summary>
        /// <param name="str"></param>
        /// <exception cref="InvalidCastException"></exception>
        /// <returns></returns>
        public static long ToLong(this string str)
        {
            long rtn;
            if (!long.TryParse(str, out rtn))
            {
                throw new InvalidCastException("Unable to parse long from " + str);
            }
            return rtn;
        }

        /// <summary>
        /// Attempt to cast a string to a long, return null if unable to cast
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long? TryToLong(this string str)
        {
            long rtn;
            if (!long.TryParse(str, out rtn))
                return null;
            return rtn;
        }

        /// <summary>
        /// Recursively search a tree collection based on the child selector
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="childSelector"></param>
        /// <returns></returns>
        public static IEnumerable<T> Traverse<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> childSelector)
        {
            if (items == null) yield break;
            var stack = new Stack<T>(items);
            while (stack.Any())
            {
                var next = stack.Pop();
                yield return next;
                var children = childSelector(next);
                if (children == null) continue;
                foreach (var child in children)
                    stack.Push(child);
            }
        }
    }
}
