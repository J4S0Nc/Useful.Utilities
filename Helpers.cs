using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

            byte b;

            for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
            {
                b = ((byte)(bytes[bx] >> 4));
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
        /// If the string is null or whitespace the <see cref="value"/> is returned. 
        /// If the string has a value it is returned.
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="value">Default value to return when input is null or whitespace</param>
        /// <returns>input string or default value</returns>
        public static string Default(this string str, string value)
        {
            return string.IsNullOrWhiteSpace(str) ? value : str;
        }

        public static float RoundDown(this float number, int decimalPlaces)
        {
            return (float)(Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces));
        }

        public static float RoundUp(this float number, int decimalPlaces)
        {
            return (float)(Math.Ceiling(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces));
        }
    }


    /// <summary>
    /// Perform a deep copy of an object.
    /// Binary Serialization is used to perform the copy.
    /// </summary>
    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("The type must be serializable.", "source");

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
                return default(T);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Takes a serializable object and returns it as a byte array.
        /// </summary>
        /// <typeparam name="T">The Type of the Object</typeparam>
        /// <param name="source">The source object to serialize.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">The type must be serializable.;source</exception>
        public static byte[] ToBytes<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("The type must be serializable.", "source");
            if (ReferenceEquals(source, null))
                return null;

            IFormatter formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Takes a byte array and desterilizes it to a object. 
        /// </summary>
        /// <typeparam name="T">The Type of the Object</typeparam>
        /// <param name="obj">byte array of the object.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">The type must be serializable.;source</exception>
        public static T FromBytes<T>(byte[] obj)
        {
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("The type must be serializable.", "source");
            if (obj == null || obj.Length == 0)
                return default(T);

            IFormatter formatter = new BinaryFormatter();
            var stream = new MemoryStream(obj);
            using (stream)
            {
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Load an object from XML string.
        /// </summary>
        /// <typeparam name="T">The Type of the Object</typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static T FromXml<T>(string xml)
        {
            using (StringReader stringReader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }

        /// <summary>
        /// Serialize an object to XML string.
        /// </summary>
        /// <typeparam name="T">The Type of Object</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>XML String</returns>
        public static string ToXml<T>(this T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }
    }
}
