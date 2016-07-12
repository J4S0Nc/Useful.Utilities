using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace XmlMd
{
    /// <summary>
    /// Enhanced version of https://gist.github.com/lontivero/593fc51f1208555112e0
    /// </summary>
    public static class XmlToMarkdown
    {
        /// <summary>
        /// Dictionary of string format templates by node type
        /// </summary>
        private static readonly Dictionary<string, string> templates = new Dictionary<string, string>
        {
            {"doc", "## {0} ##\n\n{1}\n\n"},
            {"type", "\n---\n# {0}\n\n{1}\n"},
            {"field", "|{0,10} |{1,-12} |\n"},
            {"property", "|{0,10} |{1,-12} |\n"},
            {"method", "\n#### {0}\n\n{1}\n\n"},
            {"event", "\n#### {0}\n\n{1}\n\n"},
            {"summary", "{0}\n\n"},
            {"remarks", "\n\n>{0}\n\n"},
            {"example", "_Example_\n\n```\n{0}\n```\n\n"},
            {"code", "_{1} Example_\n\n```{1}\n{0}\n```\n\n"},
            {"seePage", "[{1}|{0}]"},
            {"seeAnchor", "[{1}]({0})"},
            {"param", "|{0,10} |{1,-12} |\n"},
            {"typeparam", "|{0,10} |{1,-12} |\n"},
            {"exception", "\nThrows: [[{0}|{0}]]: {1}\n\n"},
            {"returns", "\nReturns: {0}\n\n"},
            {"paramref", "{0}" },
            {"none", ""}
        };
        /// <summary>
        /// Helper function for documenting a node (and child nodes) into markdown 
        /// </summary>
        private static Func<string, XElement, string[]> d = ((att, node) =>
        {
            var value = node.Attribute(att).Value.TrimStart();
            if (value.Length > 2 && value[1] == ':') value = value.Substring(2);
            return new[]
            {
                value,
                node.Nodes().ToMarkDown().TrimEnd()
            };
        });

        /// <summary>
        /// Dictionary of functions to preform per type
        /// </summary>
        static Dictionary<string, Func<XElement, IEnumerable<string>>> methods = new Dictionary<string, Func<XElement, IEnumerable<string>>>
        {
            {"doc", x=> new[]{
                x.Element("assembly").Element("name").Value,
                x.Element("members").Elements("member").ToMarkDown()
            }},
            {"type", x=>d("name", x)},
            {"field", x=> d("name", x)},
            {"property", x=> d("name", x)},
            {"method",x=>d("name", x)},
            {"event", x=>d("name", x)},
            {"summary", x=> new[]{ x.Nodes().ToMarkDown() }},
            {"remarks", x => new[]{x.Nodes().ToMarkDown()}},
            {"example", x => new[]{x.Value.ToCodeBlock()}},
            {"code", x =>
            {
                var code = d("lang", x)?.FirstOrDefault() ?? "C#";
                return new[] {x.Value.ToCodeBlock(), code};
            }},
            {"seePage", x=> d("cref", x) },
            {"seeAnchor", x=> {
                                  var xx = d("cref", x); xx[0] = xx[0].ToLower();
                                  if (string.IsNullOrWhiteSpace(xx[1])) xx[1] = xx[0];
                                  return xx; }},
            {"param", x => d("name", x) },
            {"paramref", x=> d("name", x) },
            {"typeparam", x=> d("name", x)},
            {"exception", x => d("cref", x) },
            {"returns", x => new[]{x.Nodes().ToMarkDown()}},
            {"none", x => new string[0]}
        };

        /// <summary>
        /// Table of content container 
        /// </summary>
        public static List<string> Toc = new List<string>();
        /// <summary>
        /// Flag to manager adding table headers 
        /// </summary>
        private static bool tableHeader = false;
        /// <summary>
        /// list of things to add table headers to
        /// </summary>
        private static readonly string[] TypesWithHeader = new[] { "param", "typeparam", "field", "property" };

        /// <summary>
        /// Method that transforms a node to a string of markdown 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        internal static string ToMarkDown(this XNode e)
        {

            string name;
            if (e.NodeType == XmlNodeType.Element)
            {
                var el = (XElement)e;
                name = el.Name.LocalName;
                //translate the member to the actual type 
                if (name == "member")
                {
                    switch (el.Attribute("name").Value[0])
                    {
                        case 'F': name = "field"; break;
                        case 'P': name = "property"; break;
                        case 'T': name = "type"; break;
                        case 'E': name = "event"; break;
                        case 'M': name = "method"; break;
                        default: name = "none"; break;
                    }
                }
                //check for reference links 
                if (name == "see")
                {
                    var anchor = el.Attribute("cref").Value.StartsWith("!:#");
                    name = anchor ? "seeAnchor" : "seePage";
                }
                if (!templates.ContainsKey(name))
                {
                    throw new KeyNotFoundException("No template defined for " + name);
                }
                var vals = methods[name](el).ToArray();
                if ("type|event|method".Contains(name)) tableHeader = false;
                if (name == "type")
                {
                    //create item in TOC for every type
                    Toc.Add(string.Format("- [{0}](#{1}) {2}", vals[0], vals[0].Trim().ToLower().Replace(" ", "-").Replace(".", ""), vals[1].Trim().Split('\n')[0]));
                }

                //run template based on type
                string str = "";
                str = string.Format(templates[name], vals);

                if (TypesWithHeader.Contains(name) && !tableHeader && !string.IsNullOrWhiteSpace(str))
                {
                    // create table header
                    tableHeader = true;
                    if (name == "param" || name == "typeparam")
                        str = "\n| Parameter | Description |\n|-----------|-------------|\n" + str;
                    else
                        str = "\n|  Property | Description |\n|-----------|-------------|\n" + str;

                }
                if (name.StartsWith("see")) str = str.Replace("[|", "[");
                if (str.Trim() == "Returns:" || string.IsNullOrWhiteSpace(str)) return string.Empty;
                return str;
            }

            if (e.NodeType == XmlNodeType.Text)
                return Regex.Replace(((XText)e).Value, @"\s+", " ").Trim();
            //              return Regex.Replace(((XText)e).Value, @"(?:(?![\n\r])\s)+", " ").Trim();
            tableHeader = false;
            return "";
        }

        /// <summary>
        /// Aggregate list of nodes and call ToMarkDown on each
        /// </summary>
        /// <param name="es"></param>
        /// <returns></returns>
        internal static string ToMarkDown(this IEnumerable<XNode> es)
        {
            return es.Aggregate("", (current, x) => current + x.ToMarkDown());
        }

        /// <summary>
        /// Helper method to build a code block
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string ToCodeBlock(this string s)
        {
            var lines = s.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var blank = lines[0].TakeWhile(x => x == ' ').Count() - 4;
            return string.Join("\n", lines.Select(x => new string(x.SkipWhile((y, i) => i < blank).ToArray())));
        }
    }
}