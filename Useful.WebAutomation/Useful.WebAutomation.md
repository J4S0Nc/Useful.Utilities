## Useful.WebAutomation ##
- [Useful.WebAutomation.Extensions](#usefulwebautomationextensions) Extension method for web driver and elements
- [Useful.WebAutomation.PageObjects.Controls.BaseElement](#usefulwebautomationpageobjectscontrolsbaseelement) Base Web Element class provides methods for dealing with controls, parent and child elements. Implements OpenQA.Selenium.IWebElement interface
- [Useful.WebAutomation.PageObjects.Controls.WebControl](#usefulwebautomationpageobjectscontrolswebcontrol) Empty implementation of a base element control
- [Useful.WebAutomation.PageObjects.Controls.BasePage](#usefulwebautomationpageobjectscontrolsbasepage) Base page container used by page factory
- [Useful.WebAutomation.PageObjects.Controls.ElementCollection&lt;T&gt;](#usefulwebautomationpageobjectscontrolselementcollection&lt;T&gt;) Collection of elements. The collection it's self can also be an element. 
- [Useful.WebAutomation.PageObjects.Controls.Button](#usefulwebautomationpageobjectscontrolsbutton) Button control
- [Useful.WebAutomation.PageObjects.Controls.FormFields](#usefulwebautomationpageobjectscontrolsformfields) Helper class for linking labels to form fields
- [Useful.WebAutomation.PageObjects.Controls.Label](#usefulwebautomationpageobjectscontrolslabel) Label control, can be null
- [Useful.WebAutomation.PageObjects.Controls.InputField](#usefulwebautomationpageobjectscontrolsinputfield) base input control. If Text attribute is null or empty falls back and checks value attribute
- [Useful.WebAutomation.PageObjects.Controls.TextArea](#usefulwebautomationpageobjectscontrolstextarea) Text area control inherits from [Useful.WebAutomation.PageObjects.Controls.InputField]
- [Useful.WebAutomation.PageObjects.Controls.Checkbox](#usefulwebautomationpageobjectscontrolscheckbox) Check box control inherits from [Useful.WebAutomation.PageObjects.Controls.InputField]
- [Useful.WebAutomation.PageObjects.Controls.RadioButton](#usefulwebautomationpageobjectscontrolsradiobutton) Radio button control inherits from [Useful.WebAutomation.PageObjects.Controls.InputField]
- [Useful.WebAutomation.PageObjects.Controls.SelectField](#usefulwebautomationpageobjectscontrolsselectfield) Select (drop down) control inherits from [Useful.WebAutomation.PageObjects.Controls.InputField]
- [Useful.WebAutomation.PageObjects.ObjectFactory](#usefulwebautomationpageobjectsobjectfactory) Object factory handles the creation of typed elements
- [Useful.WebAutomation.PageObjects.PageFactory](#usefulwebautomationpageobjectspagefactory) Web Driver extensions for navigating and creating page objects
- [Useful.WebAutomation.Selenium.CustomBy](#usefulwebautomationseleniumcustomby) Custom selectors for find elements in a document or context
- [Useful.WebAutomation.Selenium.WebDriver](#usefulwebautomationseleniumwebdriver) Implements Selenium IWebDriver. Handles setting up a new driver and providers methods for dealing with elements and page objects
- [Useful.WebAutomation.Selenium.WebDriver.DriverTypes](#usefulwebautomationseleniumwebdriverdrivertypes) Supported driver types

---
# Useful.WebAutomation.Extensions

 Extension method for web driver and elements

|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.Extensions.WaitTime | default wait time |

#### Useful.WebAutomation.Extensions.Wait(OpenQA.Selenium.IWebDriver,System.Single)

 Wait class wrapper. Takes number of seconds to wait or uses default when not passed in 


| Parameter | Description |
|-----------|-------------|
|    driver |The driver.  |
|   seconds |The seconds. |


#### Useful.WebAutomation.Extensions.Until&lt;T&gt;(OpenQA.Selenium.Support.UI.WebDriverWait,System.Func{OpenQA.Selenium.IWebDriver,System.Boolean},System.Func{&lt;T&gt;})

 Wait Until the given function delegate returns true or a timeout exception is thrown. If the logic function returns true this executes the return logic delegate and sends back the value 


| Parameter | Description |
|-----------|-------------|
|         T |Type to return |

| Parameter | Description |
|-----------|-------------|
|      wait |The wait object |
|untilLogic |Logic to repetitively run until it returns true or times out |
|returnLogic |Logic to execute after untilLogic returns true |

Returns: result of returnLogic delegate


#### Useful.WebAutomation.Extensions.Find(OpenQA.Selenium.Support.UI.WebDriverWait,OpenQA.Selenium.By,OpenQA.Selenium.ISearchContext)

 Wait extension that will try to find a element by selector in the given parent context 


| Parameter | Description |
|-----------|-------------|
|      wait |The wait object |
|  selector |the select to find |
|    parent |The context to search in |


#### Useful.WebAutomation.Extensions.WaitWhileVisible(OpenQA.Selenium.IWebDriver,OpenQA.Selenium.By,OpenQA.Selenium.ISearchContext,OpenQA.Selenium.Support.UI.WebDriverWait)

 Wait for all elements matching selector to not be displayed. throws timeout exception if still visible 


| Parameter | Description |
|-----------|-------------|
|    driver |The driver.  |
|  selector |The selector. |
|    parent |The parent.  |
|      wait |The wait.    |


#### Useful.WebAutomation.Extensions.FindWithWait(OpenQA.Selenium.IWebDriver,OpenQA.Selenium.By,OpenQA.Selenium.ISearchContext,OpenQA.Selenium.Support.UI.WebDriverWait)

 Driver extension that will wait until the selector is found or it times out. 


| Parameter | Description |
|-----------|-------------|
|    driver |The driver.  |
|  selector |The selector. |
|    parent |The parent.  |
|      wait |The wait.    |


#### Useful.WebAutomation.Extensions.ScrollTo(OpenQA.Selenium.IWebDriver,OpenQA.Selenium.IWebElement,System.Int32,System.Int32)

 Scroll to an element using javascript. Can accept positive or negative x and y offsets 


| Parameter | Description |
|-----------|-------------|
|    driver |the driver   |
|         e |The element  |
|   yOffset |Y vertical offset. default it -75 to try to ensure element is viewable |
|   xOffset |X horizontal offset |


#### Useful.WebAutomation.Extensions.IsVisible(OpenQA.Selenium.ISearchContext,System.String,OpenQA.Selenium.By)

 Check if an element is visible by a selector and optionally verify it contains the given text. 


| Parameter | Description |
|-----------|-------------|
|    parent |The parent.  |
|      text |optional text to verify is found on selector. text is case insensitive |
|  selector |Optional selector, defaults to body tag if not given |


#### Useful.WebAutomation.Extensions.IsVisible(OpenQA.Selenium.ISearchContext,OpenQA.Selenium.By)

 Check if an element is visible by a selector. 


| Parameter | Description |
|-----------|-------------|
|    parent |             |
|  selector |             |


#### Useful.WebAutomation.Extensions.Find(OpenQA.Selenium.ISearchContext,OpenQA.Selenium.By,System.Boolean,System.Boolean)

 Find an element using the default timeout 


| Parameter | Description |
|-----------|-------------|
|  selector |             |
|    parent |             |


#### Useful.WebAutomation.Extensions.TryFind(OpenQA.Selenium.ISearchContext,OpenQA.Selenium.By,System.Boolean,System.Boolean)

 Try to find element, returns null if not found 


| Parameter | Description |
|-----------|-------------|
|    parent |The parent.  |
|  selector |The selector. |
|excludeHidden |if set to  true  exclude hidden. |
|excludeDisabled |if set to  true  exclude disabled. |


#### Useful.WebAutomation.Extensions.TryFind(OpenQA.Selenium.ISearchContext,OpenQA.Selenium.By,System.Boolean,System.Boolean,System.Boolean@)

 Try to find element, returns null if not found 


| Parameter | Description |
|-----------|-------------|
|    parent |The parent.  |
|  selector |The selector. |
|excludeHidden |if set to  true  exclude hidden. |
|excludeDisabled |if set to  true  exclude disabled. |
|     found |if set to  true  found. |


#### Useful.WebAutomation.Extensions.FindAll(OpenQA.Selenium.ISearchContext,OpenQA.Selenium.By,System.Boolean,System.Boolean)

 finds all elements match the selector (can include invisible and disabled elements) 


| Parameter | Description |
|-----------|-------------|
|   context |The search context to look under |
|  selector |The selector used to find the elements |
|excludeHidden |if set to  true  exclude hidden. |
|excludeDisabled |if set to  true  exclude disabled. |

Throws: [[OpenQA.Selenium.NoSuchElementException|OpenQA.Selenium.NoSuchElementException]]: Find All Failed: + selector.ToString()


#### Useful.WebAutomation.Extensions.FindAllText(OpenQA.Selenium.ISearchContext,System.String,OpenQA.Selenium.By,OpenQA.Selenium.Support.UI.WebDriverWait)

 Find all the visible elements that contain the given text. 


| Parameter | Description |
|-----------|-------------|
|   context |The search context to look under |
|      text |The text to search for |
|  selector |The selector used to find the elements. if none is given the body tag is used |
|      wait |Optional wait object to hold until any element matching the text is displayed. |


#### Useful.WebAutomation.Extensions.FindText(OpenQA.Selenium.ISearchContext,System.String,OpenQA.Selenium.By,OpenQA.Selenium.Support.UI.WebDriverWait)

 Find the first visible element that contains the given text. 


| Parameter | Description |
|-----------|-------------|
|   context |The search context to look under |
|      text |The text to search for |
|  selector |The selector used to find the elements. if none is given the body tag is used |
|      wait |Optional wait object to hold until any element matching the text is displayed. |


#### Useful.WebAutomation.Extensions.ValidateState(OpenQA.Selenium.IWebElement)

 Throws exceptions if the element is null, disabled or hidden. 


| Parameter | Description |
|-----------|-------------|
|         e |Element to validate |


#### Useful.WebAutomation.Extensions.HasClass(OpenQA.Selenium.IWebElement,System.String)

 Check if an element has the given class name in its class attribute. 


| Parameter | Description |
|-----------|-------------|
|         e |Element to check |
| className |class name to look for |


#### Useful.WebAutomation.Extensions.Parent(OpenQA.Selenium.IWebElement)

 Get parent relative to current element using XPath "./parent::*" 


| Parameter | Description |
|-----------|-------------|
|   element |The current element |


---
# Useful.WebAutomation.PageObjects.Controls.BaseElement

 Base Web Element class provides methods for dealing with controls, parent and child elements. Implements OpenQA.Selenium.IWebElement interface

|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Nullable | Can this element be null? Default is false |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Element | Access base element |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Driver | Access current Web Driver |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Parent | Access parent element as a search context. Driver is returned when ParentElement is null. |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.ParentElemant | Access parent element (up the tree) |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Selector | Selector used to find the current element from it's parent |

#### Useful.WebAutomation.PageObjects.Controls.BaseElement.GetElement

 Get the current element from cache or search parent by selector


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.Control&lt;T&gt;(OpenQA.Selenium.By,Useful.WebAutomation.PageObjects.Controls.BaseElement,System.String)

 Get a typed control based on a selector. 


| Parameter | Description |
|-----------|-------------|
|         T |The type of control to create and return |

| Parameter | Description |
|-----------|-------------|
|        by |The selector used to find the control |
|    parent |The parent control to start the search from. Current element is used when this is null |
|propertyName |Optional name defaulted from the calling member. Used as part of the cache key |


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.Control&lt;T&gt;(OpenQA.Selenium.By,Useful.WebAutomation.Selenium.WebDriver,System.String)

 Get a typed control based on a selector. 


| Parameter | Description |
|-----------|-------------|
|         T |The type of control to create and return |

| Parameter | Description |
|-----------|-------------|
|        by |The selector used to find the control |
|    parent |The web driver that will be searched. |
|propertyName |Optional name defaulted from the calling member. Used as part of the cache key |


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.Controls&lt;T&gt;(OpenQA.Selenium.By,Useful.WebAutomation.PageObjects.Controls.BaseElement,System.String)

 Get a list of typed controls based on a selector. 


| Parameter | Description |
|-----------|-------------|
|         T |The type of control list to create and return |

| Parameter | Description |
|-----------|-------------|
|        by |The selector used to find the controls |
|    parent |The parent control to start the search from. Current element is used when this is null |
|propertyName |Optional name defaulted from the calling member. Used as part of the cache key |


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.Controls&lt;T&gt;(System.Func{Useful.WebAutomation.PageObjects.Controls.ElementCollection{&lt;T&gt;}},System.String)

 Get a list of typed controls based on a function delegate. 


| Parameter | Description |
|-----------|-------------|
|         T |The type of control list to create and return |

| Parameter | Description |
|-----------|-------------|
|       fun |The function used to create and return the controls |
|propertyName |Optional name defaulted from the calling member. Used as part of the cache key |


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.ControlCache&lt;T&gt;(System.Func{&lt;T&gt;},System.String)

 Checks if the current property name has already been created and return it if it has. If not in the cache, create it by calling the function delegate and then cache it for next time. 


| Parameter | Description |
|-----------|-------------|
|         T |The type of control to create and return |

| Parameter | Description |
|-----------|-------------|
|       fun |The function used to create and return the controls |
|propertyName |Name used as part of the cache key |


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.ControlCache&lt;T&gt;(System.String)

 Checks if the current property name has already been created and return it if it has, else returns null 


| Parameter | Description |
|-----------|-------------|
|         T |The type of control to create and return |

| Parameter | Description |
|-----------|-------------|
|propertyName |Name used as part of the cache key |


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.ClearCache

 Clear all items from the control cache


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.RemoveFromCache(System.String)

 remove an item from the cache by the property name 


| Parameter | Description |
|-----------|-------------|
|propertyName |Name used as part of the cache key |


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.FindElement(OpenQA.Selenium.By)

 Finds the first [OpenQA.Selenium.IWebElement] using the given method. 


| Parameter | Description |
|-----------|-------------|
|        by |The locating mechanism to use. |

Returns:  The first matching [OpenQA.Selenium.IWebElement] on the current context. 


Throws: [[OpenQA.Selenium.NoSuchElementException|OpenQA.Selenium.NoSuchElementException]]: If no element matches the criteria.


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.FindElements(OpenQA.Selenium.By)

 Finds all [IWebElements|OpenQA.Selenium.IWebElement] within the current context using the given mechanism. 


| Parameter | Description |
|-----------|-------------|
|        by |The locating mechanism to use. |

Returns:  A [System.Collections.ObjectModel.ReadOnlyCollection&lt;T&gt;] of all [WebElements|OpenQA.Selenium.IWebElement] matching the current criteria, or an empty list if nothing matches.


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.Clear

 Ensures the element is in a valid state then clears the content of this element. 



> If this element is a text entry element, the [OpenQA.Selenium.IWebElement.Clear] method will clear the value. It has no effect on other elements. Text entry elements are defined as elements with INPUT or TEXTAREA tags. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM.


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.SendKeys(System.String)

 Simulates typing text into the element. 


| Parameter | Description |
|-----------|-------------|
|      text |The text to type into the element. |


> The text to be typed may include special characters like arrow keys, backspaces, function keys, and so on. Valid special keys are defined in [OpenQA.Selenium.Keys]. 


Throws: [[OpenQA.Selenium.InvalidElementStateException|OpenQA.Selenium.InvalidElementStateException]]: Thrown when the target element is not enabled.


Throws: [[OpenQA.Selenium.ElementNotVisibleException|OpenQA.Selenium.ElementNotVisibleException]]: Thrown when the target element is not visible.


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM.


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.Submit

 Submits this element to the web server. 



> If this current element is a form, or an element within a form, then this will be submitted to the web server. If this causes the current page to change, then this method will block until the new page is loaded. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM.


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.Click

 Ensures the element is in a valid state then clicks this element. Once clicked the drive will be told to wait for the page to load. 



> 
>            Click this element. If the click causes a new page to load, the 
>                        method will attempt to block until the page has loaded. After calling the
>                         method, you should discard all references to this
>                        element unless you know that the element and the page will still be present.
>                        Otherwise, any further operations performed on this element will have an undefined.
>                        behavior.
>            
>              
>            If this element is not clickable, then this operation is ignored. This allows you to
>                        simulate a users to accidentally missing the target when clicking.
>            
>             


Throws: [[OpenQA.Selenium.ElementNotVisibleException|OpenQA.Selenium.ElementNotVisibleException]]: Thrown when the target element is not visible.


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM.


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.ClickNoWait

 Ensures the element is in a valid state then clicks this element. 



> 
>            Click this element. If the click causes a new page to load, the 
>                        method will attempt to block until the page has loaded. After calling the
>                         method, you should discard all references to this
>                        element unless you know that the element and the page will still be present.
>                        Otherwise, any further operations performed on this element will have an undefined.
>                        behavior.
>            
>              
>            If this element is not clickable, then this operation is ignored. This allows you to
>                        simulate a users to accidentally missing the target when clicking.
>            
>             


Throws: [[OpenQA.Selenium.ElementNotVisibleException|OpenQA.Selenium.ElementNotVisibleException]]: Thrown when the target element is not visible.


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM.


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.ClickAndWait(System.Int32)

 Click the element and wait the given number of seconds. Returns the wait object 


| Parameter | Description |
|-----------|-------------|
|waitSeconds |Number of seconds to wait before timing out |


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.GetAttribute(System.String)

 Gets the value of the specified attribute for this element. 


| Parameter | Description |
|-----------|-------------|
|attributeName |The name of the attribute. |

Returns:  The attribute's current value. Returns a  if the value is not set. 



> The [OpenQA.Selenium.IWebElement.GetAttribute(System.String)] method will return the current value of the attribute, even if the value has been modified after the page has been loaded. Note that the value of the following attributes will be returned even if there is no explicit attribute on the element:  Attribute nameValue returned if not explicitly specifiedValid element typescheckedcheckedCheck BoxselectedselectedOptions in Select elementsdisableddisabledInput and other UI elements 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM.


#### Useful.WebAutomation.PageObjects.Controls.BaseElement.GetCssValue(System.String)

 Gets the value of a CSS property of this element. 


| Parameter | Description |
|-----------|-------------|
|propertyName |The name of the CSS property to get the value of. |

Returns:  The value of the specified CSS property. 



> The value returned by the [OpenQA.Selenium.IWebElement.GetCssValue(System.String)] method is likely to be unpredictable in a cross-browser environment. Color values should be returned as hex strings. For example, a "background-color" property set as "green" in the HTML source, will return "#008000" for its value. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM.


|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.PageObjects.Controls.BaseElement.TagName | Gets the tag name of this element. 



> The [OpenQA.Selenium.IWebElement.TagName] property returns the tag name of the element, not the value of the name attribute. For example, it will return "input" for an element specified by the HTML markup <input name="foo" />. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM. |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Text | Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM. |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Enabled | Gets a value indicating whether or not this element is enabled. 



> The [OpenQA.Selenium.IWebElement.Enabled] property will generally return  for everything except explicitly disabled input elements. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM. |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Selected | Gets a value indicating whether or not this element is selected. 



> This operation only applies to input elements such as check boxes, options in a select element and radio buttons. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM. |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Location | Gets a [System.Drawing.Point] object containing the coordinates of the upper-left corner of this element relative to the upper-left corner of the page. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM. |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Size | Gets a [System.Drawing.Size] object containing the height and width of this element. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM. |
|Useful.WebAutomation.PageObjects.Controls.BaseElement.Displayed | Gets a value indicating whether or not this element is displayed. 



> The [OpenQA.Selenium.IWebElement.Displayed] property avoids the problem of having to parse an element's "style" attribute to determine visibility of an element. 


Throws: [[OpenQA.Selenium.StaleElementReferenceException|OpenQA.Selenium.StaleElementReferenceException]]: Thrown when the target element is no longer valid in the document DOM. |

---
# Useful.WebAutomation.PageObjects.Controls.WebControl

 Empty implementation of a base element control

---
# Useful.WebAutomation.PageObjects.Controls.BasePage

 Base page container used by page factory

|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.PageObjects.Controls.BasePage.Url | The URL of the page |
|Useful.WebAutomation.PageObjects.Controls.BasePage.UseAppRoot | Does this page URL have the same application root URL as other pages? |
|Useful.WebAutomation.PageObjects.Controls.BasePage.PageId | Unique ID string that identifies a page to its type. Typically checked in the validatePage method. |

#### Useful.WebAutomation.PageObjects.Controls.BasePage.ValidatePage

 Called when a page is created by the page factory. Used to validate the DOM matches the type being created.


---
# Useful.WebAutomation.PageObjects.Controls.ElementCollection&lt;T&gt;

 Collection of elements. The collection it's self can also be an element. 


| Parameter | Description |
|-----------|-------------|
|         T |             |

#### Useful.WebAutomation.PageObjects.Controls.ElementCollection&lt;T&gt;.GetElements

 Get all the visible elements by the collections selector. Items are cached internally after first call


|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.PageObjects.Controls.ElementCollection&lt;T&gt;.Nullable | Allow the collection element to be null. |

#### Useful.WebAutomation.PageObjects.Controls.ElementCollection&lt;T&gt;.GetElement

 Gets the root element of the collection (not an item of the collection)


#### Useful.WebAutomation.PageObjects.Controls.ElementCollection&lt;T&gt;.GetEnumerator

 Enumerator of elements in the collection


#### Useful.WebAutomation.PageObjects.Controls.ElementCollection&lt;T&gt;.System#Collections#IEnumerable#GetEnumerator

 Enumerator of elements in the collection


|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.PageObjects.Controls.ElementCollection&lt;T&gt;.Count | Numbers of items in the collection |

---
# Useful.WebAutomation.PageObjects.Controls.Button

 Button control

---
# Useful.WebAutomation.PageObjects.Controls.FormFields

 Helper class for linking labels to form fields

---
# Useful.WebAutomation.PageObjects.Controls.Label

 Label control, can be null

---
# Useful.WebAutomation.PageObjects.Controls.InputField

 base input control. If Text attribute is null or empty falls back and checks value attribute

---
# Useful.WebAutomation.PageObjects.Controls.TextArea

 Text area control inherits from [Useful.WebAutomation.PageObjects.Controls.InputField]

---
# Useful.WebAutomation.PageObjects.Controls.Checkbox

 Check box control inherits from [Useful.WebAutomation.PageObjects.Controls.InputField]

---
# Useful.WebAutomation.PageObjects.Controls.RadioButton

 Radio button control inherits from [Useful.WebAutomation.PageObjects.Controls.InputField]

---
# Useful.WebAutomation.PageObjects.Controls.SelectField

 Select (drop down) control inherits from [Useful.WebAutomation.PageObjects.Controls.InputField]

#### Useful.WebAutomation.PageObjects.Controls.SelectField.AsSelectElement

 Convert Element to [OpenQA.Selenium.Support.UI.SelectElement] SelectElement


---
# Useful.WebAutomation.PageObjects.ObjectFactory

 Object factory handles the creation of typed elements

#### Useful.WebAutomation.PageObjects.ObjectFactory.CreateElement(System.Type,Useful.WebAutomation.Selenium.WebDriver,OpenQA.Selenium.By,Useful.WebAutomation.PageObjects.Controls.BaseElement,OpenQA.Selenium.IWebElement)

 Create a base element and wire its selector, parent, and type 


| Parameter | Description |
|-----------|-------------|
|      type |The type to create |
|    driver |The web driver the element is attached to |
|        by |The selector used to find the element |
|    parent |The parent of the element |
|   element |The element itself if it has already been created |


#### Useful.WebAutomation.PageObjects.ObjectFactory.CreateElement&lt;T&gt;(Useful.WebAutomation.Selenium.WebDriver,OpenQA.Selenium.By,Useful.WebAutomation.PageObjects.Controls.BaseElement,OpenQA.Selenium.IWebElement)

 Create a Typed element and wire its selector and parent. If the type is abstract, attempt to find the type by attribute or tag name 


| Parameter | Description |
|-----------|-------------|
|         T |The Type of element to create |

| Parameter | Description |
|-----------|-------------|
|    driver |The web driver the element is attached to |
|        by |The selector used to find the element |
|    parent |The parent of the element |
|   element |The element itself if is has already been created |


#### Useful.WebAutomation.PageObjects.ObjectFactory.ElementType(OpenQA.Selenium.IWebElement,System.Type)

 Find the type of an element. Checks type attribute and tag name 


| Parameter | Description |
|-----------|-------------|
|   element |The element to check |
|defaultType |The default type to return if type not found |


#### Useful.WebAutomation.PageObjects.ObjectFactory.CheckTagName(OpenQA.Selenium.IWebElement)

 Check the tag name of an element and derive the type 


| Parameter | Description |
|-----------|-------------|
|   element |The element to check |


#### Useful.WebAutomation.PageObjects.ObjectFactory.CheckTypeAttribute(OpenQA.Selenium.IWebElement)

 Check the HTML Type attribute and derive the object type 


| Parameter | Description |
|-----------|-------------|
|   element |The element to check |


#### Useful.WebAutomation.PageObjects.ObjectFactory.TryIt&lt;T&gt;(System.Func{&lt;T&gt;})

 Helper method to wrap exceptions. If/when errors, simply return the default of T 


| Parameter | Description |
|-----------|-------------|
|         T |Type to return |

| Parameter | Description |
|-----------|-------------|
|    action |Action to try |


---
# Useful.WebAutomation.PageObjects.PageFactory

 Web Driver extensions for navigating and creating page objects

#### Useful.WebAutomation.PageObjects.PageFactory.GoTo&lt;T&gt;(Useful.WebAutomation.Selenium.WebDriver,System.String,System.Boolean)

 Creates a page object, ensures the driver has loaded the page then validates the DOM. the page object is returned 


| Parameter | Description |
|-----------|-------------|
|         T |Type of Page object |

| Parameter | Description |
|-----------|-------------|
|    driver |the web driver |
|       url |Optional URL to navigate to. If null, the page object URL property is used. |
|useAppRoot |Optional, Only takes effect if page object UseAppRoot property is null. Used when building URL. |


#### Useful.WebAutomation.PageObjects.PageFactory.CurrentPage&lt;T&gt;(Useful.WebAutomation.Selenium.WebDriver)

 Validates the driver is at the current page and returns a page object of the given type 


| Parameter | Description |
|-----------|-------------|
|         T |Type of Page object |

| Parameter | Description |
|-----------|-------------|
|    driver |the web driver |


#### Useful.WebAutomation.PageObjects.PageFactory.Click&lt;T&gt;(Useful.WebAutomation.Selenium.WebDriver,OpenQA.Selenium.IWebElement)

 Clicks a given element and navigates to the Page object 


| Parameter | Description |
|-----------|-------------|
|         T |Type of Page object |

| Parameter | Description |
|-----------|-------------|
|    driver |the web driver |
|   element |Element to click |


---
# Useful.WebAutomation.Selenium.CustomBy

 Custom selectors for find elements in a document or context

#### Useful.WebAutomation.Selenium.CustomBy.CssAttr(System.String,System.String)

 Find elements by a CSS attribute. 


| Parameter | Description |
|-----------|-------------|
|      attr |Attribute to check |
|     value |value to match |


#### Useful.WebAutomation.Selenium.CustomBy.Text(System.String,OpenQA.Selenium.By)

 Find elements by text. Text is case insensitive 


| Parameter | Description |
|-----------|-------------|
|      text |The text to search for |
|    parent |The element to search under, default is document body |


---
# Useful.WebAutomation.Selenium.WebDriver

 Implements Selenium IWebDriver. Handles setting up a new driver and providers methods for dealing with elements and page objects

|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.Selenium.WebDriver.DriversPath | Path to look for web drivers. Will check for AppSettings name "Drivers". Defaults to ".\Drivers\" |

---
# Useful.WebAutomation.Selenium.WebDriver.DriverTypes

 Supported driver types

|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.Selenium.WebDriver.DriverType | The type of driver |
|Useful.WebAutomation.Selenium.WebDriver.RootUrl | Root URL or server. Example "http://yourDomain.com" |
|Useful.WebAutomation.Selenium.WebDriver.AppPath | Application root folder name. Example "/" or "/MyApp" |

#### Useful.WebAutomation.Selenium.WebDriver.SetupDriver

 Creates a driver if it has not been created yet.


#### Useful.WebAutomation.Selenium.WebDriver.CleanUpDriver

 Close, Quit and dispose of the current driver


#### Useful.WebAutomation.Selenium.WebDriver.Dispose

 Clean up the current driver


#### Useful.WebAutomation.Selenium.WebDriver.GoTo(System.String,System.Boolean)

 Navigates to a page and waits for page to load 


| Parameter | Description |
|-----------|-------------|
|      page |             |
|useAppRoot |             |


#### Useful.WebAutomation.Selenium.WebDriver.EnsureUrl(System.String,System.Boolean)

 Check if the current drivers URL matches the URL passed in. If the URL is different the driver will navigate to the given URL. 


| Parameter | Description |
|-----------|-------------|
|       url |URL to ensure |
|useAppRoot |             |


#### Useful.WebAutomation.Selenium.WebDriver.UrlChanged(System.String,System.Boolean)

 Check if the given URL is different then the drivers current URL 


| Parameter | Description |
|-----------|-------------|
|       url |URL to check |
|useAppRoot |             |


#### Useful.WebAutomation.Selenium.WebDriver.BuildUrl(System.String,System.Boolean)

 Helper method for building URLS. Handles checking for rooted URLs and prepending app root folder when needed 


| Parameter | Description |
|-----------|-------------|
|      page |             |
|useAppRoot |             |


#### Useful.WebAutomation.Selenium.WebDriver.WaitforPage

 Wait until a page is fully loaded and ensures no errors happened. This function makes some assumptions that the site used JQuery. JQuery animations will be turned off, it will attempt to wait for all JQuery AJAX calls to finish and try to add a random element to the DOM and verify it appeared (using JQuery).


#### Useful.WebAutomation.Selenium.WebDriver.TakeScreenShot(System.String,System.String,System.Boolean)

 Take a screen shot and save as a PNG file. 


| Parameter | Description |
|-----------|-------------|
|      name |Name of file to save |
|  rootPath |Folder path to save to. If directory does not exists it will be created. |
|appendTicks |Add DateTime.Now.Ticks to file name |


#### Useful.WebAutomation.Selenium.WebDriver.Execute(System.String)

 Execute a block of java script 


| Parameter | Description |
|-----------|-------------|
|    script |             |


#### Useful.WebAutomation.Selenium.WebDriver.EnsureNoErrors

 Check page for errors or YSOD


#### Useful.WebAutomation.Selenium.WebDriver.ClickButton(System.String)

 finds a button by text and clicks on it 


| Parameter | Description |
|-----------|-------------|
|buttonText |             |


#### Useful.WebAutomation.Selenium.WebDriver.ClickLink(System.String)

 Find a link by its text, scroll to it, then click it. 


| Parameter | Description |
|-----------|-------------|
|  linkText |             |


#### Useful.WebAutomation.Selenium.WebDriver.Click(System.String,OpenQA.Selenium.By)

 Find an element by its text and click it 


| Parameter | Description |
|-----------|-------------|
|      text |The text to find and click |
|        by |The selector used to find the element |


#### Useful.WebAutomation.Selenium.WebDriver.Click(OpenQA.Selenium.IWebElement)

 Click a Web Element. If the element is null, disabled or not visible an exception will be thrown 


| Parameter | Description |
|-----------|-------------|
|         e |The element to click |


#### Useful.WebAutomation.Selenium.WebDriver.FindElement(OpenQA.Selenium.By)

 Finds the first [OpenQA.Selenium.IWebElement] using the given method. 


| Parameter | Description |
|-----------|-------------|
|        by |The locating mechanism to use. |

Returns:  The first matching [OpenQA.Selenium.IWebElement] on the current context. 


Throws: [[OpenQA.Selenium.NoSuchElementException|OpenQA.Selenium.NoSuchElementException]]: If no element matches the criteria.


#### Useful.WebAutomation.Selenium.WebDriver.FindElements(OpenQA.Selenium.By)

 Finds all [IWebElements|OpenQA.Selenium.IWebElement] within the current context using the given mechanism. 


| Parameter | Description |
|-----------|-------------|
|        by |The locating mechanism to use. |

Returns:  A [System.Collections.ObjectModel.ReadOnlyCollection&lt;T&gt;] of all [WebElements|OpenQA.Selenium.IWebElement] matching the current criteria, or an empty list if nothing matches.


#### Useful.WebAutomation.Selenium.WebDriver.Close

 Close the current window, quitting the browser if it is the last window currently open.


#### Useful.WebAutomation.Selenium.WebDriver.Quit

 Quits this driver, closing every associated window.


#### Useful.WebAutomation.Selenium.WebDriver.Manage

 Instructs the driver to change its settings. 


Returns:  An [OpenQA.Selenium.IOptions] object allowing the user to change the settings of the driver.


#### Useful.WebAutomation.Selenium.WebDriver.Navigate

 Instructs the driver to navigate the browser to another location. 


Returns:  An [OpenQA.Selenium.INavigation] object allowing the user to access the browser's history and to navigate to a given URL.


#### Useful.WebAutomation.Selenium.WebDriver.SwitchTo

 Instructs the driver to send future commands to a different frame or window. 


Returns:  An [OpenQA.Selenium.ITargetLocator] object which can be used to select a frame or window.


|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.Selenium.WebDriver.Url | Get or set the current URL of the browser 



> Setting the [OpenQA.Selenium.IWebDriver.Url] property will load a new web page in the current browser window. This is done using an HTTP GET operation, and the method will block until the load is complete. This will follow redirects issued either by the server or as a meta-redirect from within the returned HTML. Should a meta-redirect "rest" for any duration of time, it is best to wait until this timeout is over, since should the underlying page change while your test is executing the results of future calls against this interface will be against the freshly loaded page. |
|Useful.WebAutomation.Selenium.WebDriver.Title | Get the title of the current browser window. |
|Useful.WebAutomation.Selenium.WebDriver.PageSource | Gets the source of the page last loaded by the browser. 



> If the page has been modified after loading (for example, by JavaScript) there is no guarantee that the returned text is that of the modified page. Please consult the documentation of the particular driver being used to determine whether the returned text reflects the current state of the page or the text last sent by the web server. The page source returned is a representation of the underlying DOM: do not expect it to be formatted or escaped in the same way as the response sent from the web server. |
|Useful.WebAutomation.Selenium.WebDriver.CurrentWindowHandle | Gets the current window handle, which is an opaque handle to this window that uniquely identifies it within this driver instance. |
|Useful.WebAutomation.Selenium.WebDriver.WindowHandles | Gets the window handles of open browser windows. |

#### Useful.WebAutomation.Selenium.WebDriver.ExecuteScript(System.String,System.Object[])

 Executes JavaScript in the context of the currently selected frame or window. 


| Parameter | Description |
|-----------|-------------|
|    script |The JavaScript code to execute. |
|      args |The arguments to the script. |

Returns:  The value returned by the script. 



> 
>            The method executes JavaScript in the context of
>                        the currently selected frame or window. This means that "document" will refer
>                        to the current document. If the script has a return value, then the following
>                        steps will be taken: 
>              For an HTML element, this method returns a For a number, a  is returnedFor a boolean, a  is returnedFor all other cases a  is returned.For an array,we check the first element, and attempt to return a              of that type, following the rules above. Nested lists are not             supported.If the value is null or there is no return value,              is returned.  
>            Arguments must be a number (which will be converted to a ),
>                        a , a  or a .
>                        An exception will be thrown if the arguments do not meet these criteria.
>                        The arguments will be made available to the JavaScript via the "arguments" magic///             variable, as if the function were called via "Function.apply" 
>


#### Useful.WebAutomation.Selenium.WebDriver.ExecuteAsyncScript(System.String,System.Object[])

 Executes JavaScript asynchronously in the context of the currently selected frame or window. 


| Parameter | Description |
|-----------|-------------|
|    script |The JavaScript code to execute. |
|      args |The arguments to the script. |

Returns:  The value returned by the script.


|  Property | Description |
|-----------|-------------|
|Useful.WebAutomation.Tests.TestSession.Driver | Static Web driver property to be used in tests. |
|Useful.WebAutomation.Tests.TestSession.RootUrl | Root URL for this site. This is read from the appSettings config section key name is "RootUrl" value should be something like: "http://yourSite.com" |
|Useful.WebAutomation.Tests.TestSession.AppPath | Application folder name/structure to be appended to RootUrl. default is "/". If you are hosting in IIS as a virtual directory place that name in the appSettings config section with a key name of "AppPath" and the value of the directory name like "/MyApp" |
|Useful.WebAutomation.Tests.TestSession.DriverType | The type of driver to load. [Useful.WebAutomation.Selenium.WebDriver.DriverTypes] |

#### Useful.WebAutomation.Tests.TestSession.GetDriver

 Build and return a web driver. If a driver has already been built it is simply returned. This is called from the Driver property.


#### Useful.WebAutomation.Tests.TestSession.TearDownDriver

 Dispose of the current web driver



