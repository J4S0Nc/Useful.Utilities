using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

using System.Xml;

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
        /// Returns a value indicating if the substring is found within the string. 
        /// Accepts comparison parameter that can be set to ignore case. 
        /// </summary>
        /// <param name="source">The string</param>
        /// <param name="value">Value to look for in source string</param>
        /// <param name="comparison">comparison type to use (can be set to ignore case)</param>
        /// <returns></returns>
        public static bool Contains(this string source, string value, StringComparison comparison)
        {
            return source.IndexOf(value, comparison) >= 0;
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

        /// <summary>
        /// Recursively iterate child nodes of an XML document. 
        /// Calls elementVisitor action for each node and passes the node and current depth. 
        /// If max depth is greater than 0 an error will be throw when current depth is greater than max. 
        /// </summary>
        /// <code lang="c#"> 
        /// //print a tree of the all the nodes
        /// var xmlDoc = new XmlDocument();
        /// xmlDoc.LoadXml(File.ReadAllText(filename));
        /// xmlDoc.IterateNodes((node, depth) =>
        /// {
        ///     Debug.WriteLine(string.Format("{0}{1} : {2}", string.Empty.PadLeft(depth, ' '), node.Name, (node.ChildNodes.Count == 1 ? node.InnerText : node.Value)));
        /// });
        /// </code>
        /// <param name="doc">The XML document to iterate over</param>
        /// <param name="elementVisitor">The action to call for each node</param>
        /// <param name="maxDepth">Max depth before an error is thrown. 0 = no limit</param>
        /// <exception cref="StackOverflowException"></exception>
        public static void IterateNodes(this XmlDocument doc, Action<XmlNode, int> elementVisitor, int maxDepth = 0)
        {
            if (doc == null || elementVisitor == null) return;
            foreach (XmlNode node in doc.ChildNodes)
            {
                node.IterateNodes(elementVisitor);
            }
        }

        /// <summary>
        /// Recursively iterates over an XML node and all of its child nodes. 
        /// Calls elementVisitor action for each node and passes the node and current depth. 
        /// If max depth is greater than 0 an error will be throw when current depth is greater than max. 
        /// </summary>
        /// <param name="node">XML Node to iterate</param>
        /// <param name="elementVisitor">The action to call for each node</param>
        /// <param name="currentDepth">Zero based counter of current iteration level</param>
        /// <param name="maxDepth">Max depth before an error is thrown. 0 = no limit</param>
        /// <exception cref="StackOverflowException"></exception>
        public static void IterateNodes(this XmlNode node, Action<XmlNode, int> elementVisitor, int currentDepth = 0, int maxDepth = 0)
        {
            //null check
            if (node == null || elementVisitor == null) return;

            //depth check
            if (maxDepth > 0 && currentDepth > maxDepth)
                throw new StackOverflowException("Max iteration depth has been reached");

            //visit current node
            elementVisitor(node, currentDepth);

            //recursively iterate over child nodes
            foreach (XmlNode childNode in node.ChildNodes)
            {
                IterateNodes(childNode, elementVisitor, currentDepth + 1);
            }
        }

        /// <summary>
        /// Extends a name value collection to allow obtaining an item by matching on the calling property or method name. 
        /// </summary>
        /// <param name="items">The collection of items</param>
        /// <param name="defaultValue">default value to return when item is not found or value is empty</param>
        /// <param name="name">Name of key to select. This is optional and obtained through name of the caller method or property (see example code) </param>
        /// <code lang="c#">
        /// //Example using hard coded items
        ///public NameValueCollection Items = new NameValueCollection { { "SomeKey", "Some Value" }, { "AnotherKey", "Another Value" } };
        ///public string SomeKey => Items.Item(); //returns "Some value" from the "SomeKey" item
        ///public string AnotherKey => Items.Item(); //returns "Another value" from the "AnotherKey" item
        ///public string InvalidKey => Items.Item(); //returns null when key is not in items collection
        ///public string DefaultKey => Items.Item("Default value"); //returns "Default value" since key is not in collection
        /// 
        /// //Example using appSettings from a config file
        /// //assume config appSettings has something like: &lt;add key="MyAppSetting" value="some setting value" /&gt;
        /// public string MyAppSetting => System.Configuration.ConfigurationManager.AppSettings.Item(); 
        /// //If setting is not defined or empty string, default value can be returned instead:
        /// public string NotInConfig => System.Configuration.ConfigurationManager.AppSettings.Item("Some default value"); 
        /// </code>
        public static string Item(this NameValueCollection items, string defaultValue = null, [System.Runtime.CompilerServices.CallerMemberName] string name = "")
        {
            return items[name].Default(defaultValue);

        }

        
    }
}
