using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlMd
{
    /// <summary>
    /// Main Program for turning XML docs into MD files
    /// </summary>
    class Program
    {
        /// <summary>
        /// The first parameter should be the path to a single XML file or a directory to search for XML files. You can also pass wild cards like .\docs\MyNamspace.*.xml
        /// The second parameter is optional and will override the output folder if given.
        /// </summary>
        /// <param name="args">Arguments passed in from command line</param>
        /// <example>
        /// Example: XmlMd.exe .\myFile.XML                                    
        /// Process myFile.XML and output myFile.MD to the same folder         
        /// Example: XmlMd.exe .\myFile.XML ..\                                
        /// Process myFile.XML and output myFile.MD to the same folder         
        /// Example: XmlMd.exe .\ ..\                                          
        /// This will process all XML files in the current directory and output MD files to the parent directory
        /// </example>
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                //print usage
                ShowError(@"Missing path to XML files! 

The first parameter should be the path to a single XML file 
or a directory to search for XML files. 

The second parameter is optional and will override the output folder.

Example: " + Assembly.GetExecutingAssembly().ManifestModule + @" .\myFile.XML
Process myFile.XML and output myFile.MD to the same folder

Example: " + Assembly.GetExecutingAssembly().ManifestModule + @" .\myFile.XML ..\
Process myFile.XML and output myFile.MD to the same folder

Example: " + Assembly.GetExecutingAssembly().ManifestModule + @" .\ ..\
This will process all XML files in the current directory
and output MD files to the parent directory", ConsoleColor.Cyan);

                return;
            }
            var outDir = @".\";
            var path = Path.GetDirectoryName(args[0]) ?? Path.GetFullPath(args[0]);
            var filename = Path.GetFileName(args[0]);
            List<string> files = new List<string>();
            if (File.Exists(args[0]))
            {
                files.Add(args[0]);
            }
            else if (string.IsNullOrWhiteSpace(filename) || !filename.Contains(".xml"))
            {
                files = Directory.GetFiles(path, "*.xml").ToList();
            }
            else
            {
                files = Directory.GetFiles(path, filename).ToList();
            }
            if (args.Length > 1)
            {
                outDir = args[1];
                if (!Path.IsPathRooted(outDir))
                    outDir = Path.Combine(path, outDir);

            }
            if (!files.Any())
            {
                ShowError("No XML files found to process", ConsoleColor.DarkYellow);
                return;
            }
            foreach (var file in files)
            {
                XmlToMarkdown.Toc = new List<string>();
                Console.WriteLine("Reading file: " + file);

                var outFile = Path.Combine(outDir, Path.GetFileName(Path.ChangeExtension(file, "md")));
                var xml = File.ReadAllText(file);
                var doc = XDocument.Parse(xml);
                var errors = xml.Split('\n').Where(l => l.Trim().StartsWith("<!-- Badly formed XML comment ignored for member ")).Select(l => l.Trim().Replace("<!--", "# ERROR ").Replace("-->", "\n")).ToArray();
                var md = doc.Root.ToMarkDown();
                md = md.Insert(md.IndexOf('\n') + 1, string.Join("\n", XmlToMarkdown.Toc));
                md = md.Replace("``0", "&lt;T&gt;").Replace("``1", "&lt;T&gt;").Replace("`1", "&lt;T&gt;").Replace("``2", "&lt;T2&gt;");
                md = md.Insert(0, string.Join("", errors));
                File.WriteAllText(outFile, md);
                Console.WriteLine("File saved: " + outFile);
                if (errors.Any())
                {
                    ShowError(string.Join("", errors));
                }
            }

        }

        /// <summary>
        /// Helper method to print errors to console, 
        /// if app is running with input available it can prompt user to press a key
        /// </summary>
        /// <param name="msg">the output message</param>
        /// <param name="color">font color, default is red</param>
        /// <param name="promptForKeyPress">prompt user to press the any key</param>
        private static void ShowError(string msg, ConsoleColor color = ConsoleColor.Red, bool promptForKeyPress = true)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = tempColor;
            if (promptForKeyPress && Console.OpenStandardInput(1) != Stream.Null)
            {
                Console.WriteLine("Press the any key...");
                Console.ReadKey();
            }
        }
    }
}

