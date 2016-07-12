## XmlMd ##
- [XmlMd.Program](#xmlmdprogram) Main Program for turning XML docs into MD files
- [XmlMd.DocumentationExample](#xmlmddocumentationexample) This is a dummy class to highlight documentation examples
- [XmlMd.XmlToMarkdown](#xmlmdxmltomarkdown) Enhanced version of https://gist.github.com/lontivero/593fc51f1208555112e0

---
# XmlMd.Program

Main Program for turning XML docs into MD files

#### XmlMd.Program.Main(System.String[])

The first parameter should be the path to a single XML file or a directory to search for XML files. You can also pass wild cards like .\docs\MyNamspace.*.xml The second parameter is optional and will override the output folder if given.


| Parameter | Description |
|-----------|-------------|
|      args |Arguments passed in from command line |

_Example_

```
    Example: XmlMd.exe .\myFile.XML                                    
    Process myFile.XML and output myFile.MD to the same folder         
    Example: XmlMd.exe .\myFile.XML ..\                                
    Process myFile.XML and output myFile.MD to the same folder         
    Example: XmlMd.exe .\ ..\                                          
    This will process all XML files in the current directory and output MD files to the parent directory
    
```


#### XmlMd.Program.ShowError(System.String,System.ConsoleColor,System.Boolean)

Helper method to print errors to console, if app is running with input available it can prompt user to press a key


| Parameter | Description |
|-----------|-------------|
|       msg |the output message |
|     color |font color, default is red |
|promptForKeyPress |prompt user to press the any key |


---
# XmlMd.DocumentationExample

This is a dummy class to highlight documentation examples



>This a remarks block


_Example_

```
This ia an example block
```

_C# Example_

```C#
    //This is a C# code block
    if(example == "code") 
    {
        DoSomething();   
    }
    
```

_VB Example_

```VB
    `This is a VB code block
    If True Then
        DoEvents()
    End If
    
```

_SQL Example_

```SQL
    --This is a SQL code block
    Select * from table 
    where field = 'value'
    
```

|  Property | Description |
|-----------|-------------|
|XmlMd.DocumentationExample.StringProperty |This is a string property |
|XmlMd.DocumentationExample.IntProperty |This is a int property |
|XmlMd.DocumentationExample.BoolProperty |This is a bool property |

#### XmlMd.DocumentationExample.ExampleMethod(System.String,System.Int32,System.Boolean)

This is an example method


| Parameter | Description |
|-----------|-------------|
|  inString |Input string |
|     inInt |Input int    |
|    inBool |Input bool   |

Returns: Returns a string


---
# XmlMd.XmlToMarkdown

Enhanced version of https://gist.github.com/lontivero/593fc51f1208555112e0

|  Property | Description |
|-----------|-------------|
|XmlMd.XmlToMarkdown.templates |Dictionary of string format templates by node type |
|XmlMd.XmlToMarkdown.d |Helper function for documenting a node (and child nodes) into markdown |
|XmlMd.XmlToMarkdown.methods |Dictionary of functions to preform per type |
|XmlMd.XmlToMarkdown.Toc |Table of content container |
|XmlMd.XmlToMarkdown.tableHeader |Flag to manager adding table headers |
|XmlMd.XmlToMarkdown.TypesWithHeader |list of things to add table headers to |
|XmlMd.XmlToMarkdown.LastType |Hold last type to compare with |

#### XmlMd.XmlToMarkdown.ToMarkDown(System.Xml.Linq.XNode)

Method that transforms a node to a string of markdown


| Parameter | Description |
|-----------|-------------|
|         e |             |


#### XmlMd.XmlToMarkdown.ToMarkDown(System.Collections.Generic.IEnumerable{System.Xml.Linq.XNode})

Aggregate list of nodes and call ToMarkDown on each


| Parameter | Description |
|-----------|-------------|
|        es |             |


#### XmlMd.XmlToMarkdown.ToCodeBlock(System.String)

Helper method to build a code block


| Parameter | Description |
|-----------|-------------|
|         s |             |



