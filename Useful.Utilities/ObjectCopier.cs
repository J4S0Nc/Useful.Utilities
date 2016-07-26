using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Useful.Utilities
{
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
            if (ReferenceEquals(source, null))
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
                throw new ArgumentException("The type must be serializable.", "obj");
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