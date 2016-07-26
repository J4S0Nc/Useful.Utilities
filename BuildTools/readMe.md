# Xml MD
Takes XML documentation files from visual studio and generates markdown file from them. 

## Usage

Example: XmlMd.exe .\myFile.XML
Process myFile.XML and output myFile.MD to the same folder

Example: XmlMd.exe .\myFile.XML ..\
Process myFile.XML and output myFile.MD to the same folder

Example: XmlMd.exe .\ ..\
This will process all XML files in the current directory and output MD files to the parent directory

The first parameter should be the path to a single XML file or a directory to search for XML files. You can also pass wild cards like .\docs\MyNamspace.*.xml

The second parameter is optional and will override the output folder.

## Example Output

[XmlMd.md](./XmlMd.md)

