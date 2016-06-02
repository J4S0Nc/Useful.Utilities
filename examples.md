# Usage Examples

##ToEnum&lt;T&gt;

```C#
//define some example enums
enum SomeEnum { Yes, No, File_Not_Found }
enum AnotherEnum { No, Maybe, Yes }

//turn a string into an enum
SomeEnum yes = "Yes".ToEnum<SomeEnum>(); 

// replace spaces with _
SomeEnum fileNotFound = "File not found".ToEnum<SomeEnum>("_"); 

//convert one enum to another enum with matching name (not value)
SomeEnum someEnumYes = SomeEnum.Yes; //value of 0
AnotherEnum anotherEnumYes = someEnumYes.ToEnum<AnotherEnum>(); //value of 2

```



