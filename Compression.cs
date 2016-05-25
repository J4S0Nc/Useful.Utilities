using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Useful.Utilities
{
    /// <summary>
    /// Unbuffered compression/decompression methods using GZip
    /// </summary>
    public class Compression
    {
        /// <summary>
        /// Compresses a string using GZip
        /// </summary>
        /// <param name="text">The text to compress</param>
        /// <returns></returns>
        public static string Compress(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(Compress(buffer));
        }

        /// <summary>
        /// Use GZip Compression
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] data)
        {
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                //todo this should be buffered for large arrays  
                gZipStream.Write(data, 0, data.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(data.Length), 0, gZipBuffer, 0, 4);
            return gZipBuffer;
        }

        /// <summary>
        /// Decompresses a string
        /// </summary>
        /// <param name="compressedText">The compressed text</param>
        /// <returns></returns>
        public static string Decompress(string compressedText)
        {
            byte[] buffer = Convert.FromBase64String(compressedText);
            return Encoding.UTF8.GetString(Decompress(buffer));
        }

        /// <summary>
        /// Use GZip Decompression
        /// </summary>
        /// <param name="compressed"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] compressed)
        {
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(compressed, 0);
                memoryStream.Write(compressed, 4, compressed.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return buffer;
            }
        }

    }
}

