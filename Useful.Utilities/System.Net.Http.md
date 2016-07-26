## System.Net.Http ##
- [System.Net.Http.ByteArrayContent](#systemnethttpbytearraycontent) Provides HTTP content based on a byte array.
- [System.Net.Http.ClientCertificateOption](#systemnethttpclientcertificateoption) Specifies how client certificates are provided.
- [System.Net.Http.DelegatingHandler](#systemnethttpdelegatinghandler) A type for HTTP handlers that delegate the processing of HTTP response messages to another handler, called the inner handler.
- [System.Net.Http.FormUrlEncodedContent](#systemnethttpformurlencodedcontent) A container for name/value tuples encoded using application/x-www-form-urlencoded MIME type.
- [System.Net.Http.HttpClient](#systemnethttphttpclient) Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
- [System.Net.Http.HttpClientHandler](#systemnethttphttpclienthandler) The default message handler used by[System.Net.Http.HttpClient].
- [System.Net.Http.HttpCompletionOption](#systemnethttphttpcompletionoption) Indicates if[System.Net.Http.HttpClient]operations should be considered completed either as soon as a response is available, or after reading the entire response message including the content.
- [System.Net.Http.HttpContent](#systemnethttphttpcontent) A base class representing an HTTP entity body and content headers.
- [System.Net.Http.HttpMessageHandler](#systemnethttphttpmessagehandler) A base type for HTTP message handlers.
- [System.Net.Http.HttpMessageInvoker](#systemnethttphttpmessageinvoker) A specialty class that allows applications to call the[System.Net.Http.HttpMessageInvoker.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)]method on an Http handler chain.
- [System.Net.Http.HttpMethod](#systemnethttphttpmethod) A helper class for retrieving and comparing standard HTTP methods and for creating new HTTP methods.
- [System.Net.Http.HttpRequestException](#systemnethttphttprequestexception) A base class for exceptions thrown by the[System.Net.Http.HttpClient]and[System.Net.Http.HttpMessageHandler]classes.
- [System.Net.Http.HttpRequestMessage](#systemnethttphttprequestmessage) Represents a HTTP request message.
- [System.Net.Http.HttpResponseMessage](#systemnethttphttpresponsemessage) Represents a HTTP response message including the status code and data.
- [System.Net.Http.MessageProcessingHandler](#systemnethttpmessageprocessinghandler) A base type for handlers which only do some small processing of request and/or response messages.
- [System.Net.Http.MultipartContent](#systemnethttpmultipartcontent) Provides a collection of[System.Net.Http.HttpContent]objects that get serialized using the multipart/* content type specification.
- [System.Net.Http.MultipartFormDataContent](#systemnethttpmultipartformdatacontent) Provides a container for content encoded using multipart/form-data MIME type.
- [System.Net.Http.StreamContent](#systemnethttpstreamcontent) Provides HTTP content based on a stream.
- [System.Net.Http.StringContent](#systemnethttpstringcontent) Provides HTTP content based on a string.
- [System.Net.Http.Headers.AuthenticationHeaderValue](#systemnethttpheadersauthenticationheadervalue) Represents authentication information in Authorization, ProxyAuthorization, WWW-Authenticate, and Proxy-Authenticate header values.
- [System.Net.Http.Headers.CacheControlHeaderValue](#systemnethttpheaderscachecontrolheadervalue) Represents the value of the Cache-Control header.
- [System.Net.Http.Headers.ContentDispositionHeaderValue](#systemnethttpheaderscontentdispositionheadervalue) Represents the value of the Content-Disposition header.
- [System.Net.Http.Headers.ContentRangeHeaderValue](#systemnethttpheaderscontentrangeheadervalue) Represents the value of the Content-Range header.
- [System.Net.Http.Headers.EntityTagHeaderValue](#systemnethttpheadersentitytagheadervalue) Represents an entity-tag header value.
- [System.Net.Http.Headers.HttpContentHeaders](#systemnethttpheadershttpcontentheaders) Represents the collection of Content Headers as defined in RFC 2616.
- [System.Net.Http.Headers.HttpHeaders](#systemnethttpheadershttpheaders) A collection of headers and their values as defined in RFC 2616.
- [System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;](#systemnethttpheadershttpheadervaluecollection&lt;T&gt;) Represents a collection of header values.
- [System.Net.Http.Headers.HttpRequestHeaders](#systemnethttpheadershttprequestheaders) Represents the collection of Request Headers as defined in RFC 2616.
- [System.Net.Http.Headers.HttpResponseHeaders](#systemnethttpheadershttpresponseheaders) Represents the collection of Response Headers as defined in RFC 2616.
- [System.Net.Http.Headers.MediaTypeHeaderValue](#systemnethttpheadersmediatypeheadervalue) Represents a media type used in a Content-Type header as defined in the RFC 2616.
- [System.Net.Http.Headers.MediaTypeWithQualityHeaderValue](#systemnethttpheadersmediatypewithqualityheadervalue) Represents a media type with an additional quality factor used in a Content-Type header.
- [System.Net.Http.Headers.NameValueHeaderValue](#systemnethttpheadersnamevalueheadervalue) Represents a name/value pair used in various headers as defined in RFC 2616.
- [System.Net.Http.Headers.NameValueWithParametersHeaderValue](#systemnethttpheadersnamevaluewithparametersheadervalue) Represents a name/value pair with parameters used in various headers as defined in RFC 2616.
- [System.Net.Http.Headers.ProductHeaderValue](#systemnethttpheadersproductheadervalue) Represents a product token value in a User-Agent header.
- [System.Net.Http.Headers.ProductInfoHeaderValue](#systemnethttpheadersproductinfoheadervalue) Represents a value which can either be a product or a comment in a User-Agent header.
- [System.Net.Http.Headers.RangeConditionHeaderValue](#systemnethttpheadersrangeconditionheadervalue) Represents an If-Range header value which can either be a date/time or an entity-tag value.
- [System.Net.Http.Headers.RangeHeaderValue](#systemnethttpheadersrangeheadervalue) Represents a Range header value.
- [System.Net.Http.Headers.RangeItemHeaderValue](#systemnethttpheadersrangeitemheadervalue) Represents a byte range in a Range header value.
- [System.Net.Http.Headers.RetryConditionHeaderValue](#systemnethttpheadersretryconditionheadervalue) Represents a Retry-After header value which can either be a date/time or a timespan value.
- [System.Net.Http.Headers.StringWithQualityHeaderValue](#systemnethttpheadersstringwithqualityheadervalue) Represents a string header value with an optional quality.
- [System.Net.Http.Headers.TransferCodingHeaderValue](#systemnethttpheaderstransfercodingheadervalue) Represents an accept-encoding header value.
- [System.Net.Http.Headers.TransferCodingWithQualityHeaderValue](#systemnethttpheaderstransfercodingwithqualityheadervalue) Represents an Accept-Encoding header value.with optional quality factor.
- [System.Net.Http.Headers.ViaHeaderValue](#systemnethttpheadersviaheadervalue) Represents the value of a Via header.
- [System.Net.Http.Headers.WarningHeaderValue](#systemnethttpheaderswarningheadervalue) Represents a warning value used by the Warning header.

---
# System.Net.Http.ByteArrayContent

Provides HTTP content based on a byte array.

#### System.Net.Http.ByteArrayContent.#ctor(System.Byte[])

Initializes a new instance of the[System.Net.Http.ByteArrayContent]class.


| Parameter | Description |
|-----------|-------------|
|   content |The content used to initialize the[System.Net.Http.ByteArrayContent]. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Thecontentparameter is null.


#### System.Net.Http.ByteArrayContent.#ctor(System.Byte[],System.Int32,System.Int32)

Initializes a new instance of the[System.Net.Http.ByteArrayContent]class.


| Parameter | Description |
|-----------|-------------|
|   content |The content used to initialize the[System.Net.Http.ByteArrayContent]. |
|    offset |The offset, in bytes, in thecontentparameter used to initialize the[System.Net.Http.ByteArrayContent]. |
|     count |The number of bytes in thecontentstarting from theoffsetparameter used to initialize the[System.Net.Http.ByteArrayContent]. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Thecontentparameter is null.


Throws: [[System.ArgumentOutOfRangeException|System.ArgumentOutOfRangeException]]: Theoffsetparameter is less than zero.-or-Theoffsetparameter is greater than the length of content specified by thecontentparameter.-or-Thecount parameter is less than zero.-or-Thecountparameter is greater than the length of content specified by thecontentparameter - minus theoffsetparameter.


#### System.Net.Http.ByteArrayContent.CreateContentReadStreamAsync

Creates an HTTP content stream as an asynchronous operation for reading whose backing store is memory from the[System.Net.Http.ByteArrayContent].


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


#### System.Net.Http.ByteArrayContent.SerializeToStreamAsync(System.IO.Stream,System.Net.TransportContext)

Serialize and write the byte array provided in the constructor to an HTTP content stream as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task]. The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|    stream |The target stream. |
|   context |Information about the transport, like channel binding token. This parameter may be null. |


#### System.Net.Http.ByteArrayContent.TryComputeLength(System.Int64@)

Determines whether a byte array has a valid length in bytes.


Returns: Returns[System.Boolean].true iflengthis a valid length; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|    length |The length in bytes of the byte array. |


---
# System.Net.Http.ClientCertificateOption

Specifies how client certificates are provided.

|  Property | Description |
|-----------|-------------|
|System.Net.Http.ClientCertificateOption.Automatic |The[System.Net.Http.HttpClientHandler]will attempt to provide all available client certificates automatically. |
|System.Net.Http.ClientCertificateOption.Manual |The application manually provides the client certificates to the[System.Net.Http.WebRequestHandler]. This value is the default. |

---
# System.Net.Http.DelegatingHandler

A type for HTTP handlers that delegate the processing of HTTP response messages to another handler, called the inner handler.

#### System.Net.Http.DelegatingHandler.#ctor

Creates a new instance of the[System.Net.Http.DelegatingHandler]class.


#### System.Net.Http.DelegatingHandler.#ctor(System.Net.Http.HttpMessageHandler)

Creates a new instance of the[System.Net.Http.DelegatingHandler]class with a specific inner handler.


| Parameter | Description |
|-----------|-------------|
|innerHandler |The inner handler which is responsible for processing the HTTP response messages. |


#### System.Net.Http.DelegatingHandler.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.DelegatingHandler], and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.DelegatingHandler.InnerHandler |Gets or sets the inner handler which processes the HTTP response messages.


Returns: Returns[System.Net.Http.HttpMessageHandler].The inner handler for HTTP response messages. |

#### System.Net.Http.DelegatingHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)

Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;]. The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to send to the server. |
|cancellationToken |A cancellation token to cancel operation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


---
# System.Net.Http.FormUrlEncodedContent

A container for name/value tuples encoded using application/x-www-form-urlencoded MIME type.

#### System.Net.Http.FormUrlEncodedContent.#ctor(System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}})

Initializes a new instance of the[System.Net.Http.FormUrlEncodedContent]class with a specific collection of name/value pairs.


| Parameter | Description |
|-----------|-------------|
|nameValueCollection |A collection of name/value pairs. |


---
# System.Net.Http.HttpClient

Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.

#### System.Net.Http.HttpClient.#ctor

Initializes a new instance of the[System.Net.Http.HttpClient]class.


#### System.Net.Http.HttpClient.#ctor(System.Net.Http.HttpMessageHandler)

Initializes a new instance of the[System.Net.Http.HttpClient]class with a specific handler.


| Parameter | Description |
|-----------|-------------|
|   handler |The HTTP handler stack to use for sending requests. |


#### System.Net.Http.HttpClient.#ctor(System.Net.Http.HttpMessageHandler,System.Boolean)

Initializes a new instance of the[System.Net.Http.HttpClient]class with a specific handler.


| Parameter | Description |
|-----------|-------------|
|   handler |The[System.Net.Http.HttpMessageHandler]responsible for processing the HTTP response messages. |
|disposeHandler |true if the inner handler should be disposed of by Dispose(),false if you intend to reuse the inner handler. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpClient.BaseAddress |Gets or sets the base address of Uniform Resource Identifier (URI) of the Internet resource used when sending requests.


Returns: Returns[System.Uri].The base address of Uniform Resource Identifier (URI) of the Internet resource used when sending requests. |

#### System.Net.Http.HttpClient.CancelPendingRequests

Cancel all pending requests on this instance.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpClient.DefaultRequestHeaders |Gets the headers which should be sent with each request.


Returns: Returns[System.Net.Http.Headers.HttpRequestHeaders].The headers which should be sent with each request. |

#### System.Net.Http.HttpClient.DeleteAsync(System.String)

Send a DELETE request to the specified Uri as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: The request message was already sent by the[System.Net.Http.HttpClient]instance.


#### System.Net.Http.HttpClient.DeleteAsync(System.String,System.Threading.CancellationToken)

Send a DELETE request to the specified Uri with a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: The request message was already sent by the[System.Net.Http.HttpClient]instance.


#### System.Net.Http.HttpClient.DeleteAsync(System.Uri)

Send a DELETE request to the specified Uri as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: The request message was already sent by the[System.Net.Http.HttpClient]instance.


#### System.Net.Http.HttpClient.DeleteAsync(System.Uri,System.Threading.CancellationToken)

Send a DELETE request to the specified Uri with a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: The request message was already sent by the[System.Net.Http.HttpClient]instance.


#### System.Net.Http.HttpClient.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.HttpClient]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


#### System.Net.Http.HttpClient.GetAsync(System.String)

Send a GET request to the specified Uri as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetAsync(System.String,System.Net.Http.HttpCompletionOption)

Send a GET request to the specified Uri with an HTTP completion option as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|completionOption |An HTTP completion option value that indicates when the operation should be considered completed. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetAsync(System.String,System.Net.Http.HttpCompletionOption,System.Threading.CancellationToken)

Send a GET request to the specified Uri with an HTTP completion option and a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|completionOption |An HTTP completion option value that indicates when the operation should be considered completed. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetAsync(System.String,System.Threading.CancellationToken)

Send a GET request to the specified Uri with a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetAsync(System.Uri)

Send a GET request to the specified Uri as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetAsync(System.Uri,System.Net.Http.HttpCompletionOption)

Send a GET request to the specified Uri with an HTTP completion option as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|completionOption |An HTTP completion option value that indicates when the operation should be considered completed. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetAsync(System.Uri,System.Net.Http.HttpCompletionOption,System.Threading.CancellationToken)

Send a GET request to the specified Uri with an HTTP completion option and a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|completionOption |An HTTP completion option value that indicates when the operation should be considered completed. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetAsync(System.Uri,System.Threading.CancellationToken)

Send a GET request to the specified Uri with a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetByteArrayAsync(System.String)

Send a GET request to the specified Uri and return the response body as a byte array in an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetByteArrayAsync(System.Uri)

Send a GET request to the specified Uri and return the response body as a byte array in an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetStreamAsync(System.String)

Send a GET request to the specified Uri and return the response body as a stream in an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetStreamAsync(System.Uri)

Send a GET request to the specified Uri and return the response body as a stream in an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetStringAsync(System.String)

Send a GET request to the specified Uri and return the response body as a string in an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.GetStringAsync(System.Uri)

Send a GET request to the specified Uri and return the response body as a string in an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpClient.MaxResponseContentBufferSize |Gets or sets the maximum number of bytes to buffer when reading the response content.


Returns: Returns[System.Int32].The maximum number of bytes to buffer when reading the response content. The default value for this property is 2 gigabytes.


Throws: [[System.ArgumentOutOfRangeException|System.ArgumentOutOfRangeException]]: The size specified is less than or equal to zero.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: An operation has already been started on the current instance.


Throws: [[System.ObjectDisposedException|System.ObjectDisposedException]]: The current instance has been disposed. |

#### System.Net.Http.HttpClient.PostAsync(System.String,System.Net.Http.HttpContent)

Send a POST request to the specified Uri as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|   content |The HTTP request content sent to the server. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.PostAsync(System.String,System.Net.Http.HttpContent,System.Threading.CancellationToken)

Send a POST request with a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|   content |The HTTP request content sent to the server. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.PostAsync(System.Uri,System.Net.Http.HttpContent)

Send a POST request to the specified Uri as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|   content |The HTTP request content sent to the server. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.PostAsync(System.Uri,System.Net.Http.HttpContent,System.Threading.CancellationToken)

Send a POST request with a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|   content |The HTTP request content sent to the server. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.PutAsync(System.String,System.Net.Http.HttpContent)

Send a PUT request to the specified Uri as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|   content |The HTTP request content sent to the server. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.PutAsync(System.String,System.Net.Http.HttpContent,System.Threading.CancellationToken)

Send a PUT request with a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|   content |The HTTP request content sent to the server. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.PutAsync(System.Uri,System.Net.Http.HttpContent)

Send a PUT request to the specified Uri as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|   content |The HTTP request content sent to the server. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.PutAsync(System.Uri,System.Net.Http.HttpContent,System.Threading.CancellationToken)

Send a PUT request with a cancellation token as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|requestUri |The Uri the request is sent to. |
|   content |The HTTP request content sent to the server. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: TherequestUriwas null.


#### System.Net.Http.HttpClient.SendAsync(System.Net.Http.HttpRequestMessage)

Send an HTTP request as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to send. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: The request message was already sent by the[System.Net.Http.HttpClient]instance.


#### System.Net.Http.HttpClient.SendAsync(System.Net.Http.HttpRequestMessage,System.Net.Http.HttpCompletionOption)

Send an HTTP request as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to send. |
|completionOption |When the operation should complete (as soon as a response is available or after reading the whole response content). |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: The request message was already sent by the[System.Net.Http.HttpClient]instance.


#### System.Net.Http.HttpClient.SendAsync(System.Net.Http.HttpRequestMessage,System.Net.Http.HttpCompletionOption,System.Threading.CancellationToken)

Send an HTTP request as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to send. |
|completionOption |When the operation should complete (as soon as a response is available or after reading the whole response content). |
|cancellationToken |The cancellation token to cancel operation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: The request message was already sent by the[System.Net.Http.HttpClient]instance.


#### System.Net.Http.HttpClient.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)

Send an HTTP request as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to send. |
|cancellationToken |The cancellation token to cancel operation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: The request message was already sent by the[System.Net.Http.HttpClient]instance.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpClient.Timeout |Gets or sets the number of milliseconds to wait before the request times out.


Returns: Returns[System.TimeSpan].The number of milliseconds to wait before the request times out.


Throws: [[System.ArgumentOutOfRangeException|System.ArgumentOutOfRangeException]]: The timeout specified is less than or equal to zero and is not[System.Threading.Timeout.Infinite].


Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: An operation has already been started on the current instance.


Throws: [[System.ObjectDisposedException|System.ObjectDisposedException]]: The current instance has been disposed. |

---
# System.Net.Http.HttpClientHandler

The default message handler used by[System.Net.Http.HttpClient].

#### System.Net.Http.HttpClientHandler.#ctor

Creates an instance of a[System.Net.Http.HttpClientHandler]class.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpClientHandler.AllowAutoRedirect |Gets or sets a value that indicates whether the handler should follow redirection responses.


Returns: Returns[System.Boolean].true if the if the handler should follow redirection responses; otherwise false. The default value is true. |
|System.Net.Http.HttpClientHandler.AutomaticDecompression |Gets or sets the type of decompression method used by the handler for automatic decompression of the HTTP content response.


Returns: Returns[System.Net.DecompressionMethods].The automatic decompression method used by the handler. The default value is[System.Net.DecompressionMethods.None]. |
|System.Net.Http.HttpClientHandler.ClientCertificateOptions |Gets or sets the collection of security certificates that are associated with this handler.


Returns: Returns[System.Net.Http.ClientCertificateOption].The collection of security certificates associated with this handler. |
|System.Net.Http.HttpClientHandler.CookieContainer |Gets or sets the cookie container used to store server cookies by the handler.


Returns: Returns[System.Net.CookieContainer].The cookie container used to store server cookies by the handler. |
|System.Net.Http.HttpClientHandler.Credentials |Gets or sets authentication information used by this handler.


Returns: Returns[System.Net.ICredentials].The authentication credentials associated with the handler. The default is null. |

#### System.Net.Http.HttpClientHandler.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.HttpClientHandler]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpClientHandler.MaxAutomaticRedirections |Gets or sets the maximum number of redirects that the handler follows.


Returns: Returns[System.Int32].The maximum number of redirection responses that the handler follows. The default value is 50. |
|System.Net.Http.HttpClientHandler.MaxRequestContentBufferSize |Gets or sets the maximum request content buffer size used by the handler.


Returns: Returns[System.Int32].The maximum request content buffer size in bytes. The default value is 2 gigabytes. |
|System.Net.Http.HttpClientHandler.PreAuthenticate |Gets or sets a value that indicates whether the handler sends an Authorization header with the request.


Returns: Returns[System.Boolean].true for the handler to send an HTTP Authorization header with requests after authentication has taken place; otherwise, false. The default is false. |
|System.Net.Http.HttpClientHandler.Proxy |Gets or sets proxy information used by the handler.


Returns: Returns[System.Net.IWebProxy].The proxy information used by the handler. The default value is null. |

#### System.Net.Http.HttpClientHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)

Creates an instance of[System.Net.Http.HttpResponseMessage]based on the information provided in the[System.Net.Http.HttpRequestMessage]as an operation that will not block.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message. |
|cancellationToken |A cancellation token to cancel the operation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpClientHandler.SupportsAutomaticDecompression |Gets a value that indicates whether the handler supports automatic response content decompression.


Returns: Returns[System.Boolean].true if the if the handler supports automatic response content decompression; otherwise false. The default value is true. |
|System.Net.Http.HttpClientHandler.SupportsProxy |Gets a value that indicates whether the handler supports proxy settings.


Returns: Returns[System.Boolean].true if the if the handler supports proxy settings; otherwise false. The default value is true. |
|System.Net.Http.HttpClientHandler.SupportsRedirectConfiguration |Gets a value that indicates whether the handler supports configuration settings for the[System.Net.Http.HttpClientHandler.AllowAutoRedirect]and[System.Net.Http.HttpClientHandler.MaxAutomaticRedirections]properties.


Returns: Returns[System.Boolean].true if the if the handler supports configuration settings for the[System.Net.Http.HttpClientHandler.AllowAutoRedirect]and[System.Net.Http.HttpClientHandler.MaxAutomaticRedirections]properties; otherwise false. The default value is true. |
|System.Net.Http.HttpClientHandler.UseCookies |Gets or sets a value that indicates whether the handler uses the[System.Net.Http.HttpClientHandler.CookieContainer]property to store server cookies and uses these cookies when sending requests.


Returns: Returns[System.Boolean].true if the if the handler supports uses the[System.Net.Http.HttpClientHandler.CookieContainer]property to store server cookies and uses these cookies when sending requests; otherwise false. The default value is true. |
|System.Net.Http.HttpClientHandler.UseDefaultCredentials |Gets or sets a value that controls whether default credentials are sent with requests by the handler.


Returns: Returns[System.Boolean].true if the default credentials are used; otherwise false. The default value is false. |
|System.Net.Http.HttpClientHandler.UseProxy |Gets or sets a value that indicates whether the handler uses a proxy for requests.


Returns: Returns[System.Boolean].true if the handler should use a proxy for requests; otherwise false. The default value is true. |

---
# System.Net.Http.HttpCompletionOption

Indicates if[System.Net.Http.HttpClient]operations should be considered completed either as soon as a response is available, or after reading the entire response message including the content.

|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpCompletionOption.ResponseContentRead |The operation should complete after reading the entire response including the content. |
|System.Net.Http.HttpCompletionOption.ResponseHeadersRead |The operation should complete as soon as a response is available and headers are read. The content is not read yet. |

---
# System.Net.Http.HttpContent

A base class representing an HTTP entity body and content headers.

#### System.Net.Http.HttpContent.#ctor

Initializes a new instance of the[System.Net.Http.HttpContent]class.


#### System.Net.Http.HttpContent.CopyToAsync(System.IO.Stream)

Serialize the HTTP content into a stream of bytes and copies it to the stream object provided as thestreamparameter.


Returns: Returns[System.Threading.Tasks.Task].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|    stream |The target stream. |


#### System.Net.Http.HttpContent.CopyToAsync(System.IO.Stream,System.Net.TransportContext)

Serialize the HTTP content into a stream of bytes and copies it to the stream object provided as thestreamparameter.


Returns: Returns[System.Threading.Tasks.Task].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|    stream |The target stream. |
|   context |Information about the transport (channel binding token, for example). This parameter may be null. |


#### System.Net.Http.HttpContent.CreateContentReadStreamAsync

Serialize the HTTP content to a memory stream as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


#### System.Net.Http.HttpContent.Dispose

Releases the unmanaged resources and disposes of the managed resources used by the[System.Net.Http.HttpContent].


#### System.Net.Http.HttpContent.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.HttpContent]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpContent.Headers |Gets the HTTP content headers as defined in RFC 2616.


Returns: Returns[System.Net.Http.Headers.HttpContentHeaders].The content headers as defined in RFC 2616. |

#### System.Net.Http.HttpContent.LoadIntoBufferAsync

Serialize the HTTP content to a memory buffer as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task].The task object representing the asynchronous operation.


#### System.Net.Http.HttpContent.LoadIntoBufferAsync(System.Int64)

Serialize the HTTP content to a memory buffer as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|maxBufferSize |The maximum size, in bytes, of the buffer to use. |


#### System.Net.Http.HttpContent.ReadAsByteArrayAsync

Serialize the HTTP content to a byte array as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


#### System.Net.Http.HttpContent.ReadAsStreamAsync

Serialize the HTTP content and return a stream that represents the content as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


#### System.Net.Http.HttpContent.ReadAsStringAsync

Serialize the HTTP content to a string as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


#### System.Net.Http.HttpContent.SerializeToStreamAsync(System.IO.Stream,System.Net.TransportContext)

Serialize the HTTP content to a stream as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|    stream |The target stream. |
|   context |Information about the transport (channel binding token, for example). This parameter may be null. |


#### System.Net.Http.HttpContent.TryComputeLength(System.Int64@)

Determines whether the HTTP content has a valid length in bytes.


Returns: Returns[System.Boolean].true iflengthis a valid length; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|    length |The length in bytes of the HTTP content. |


---
# System.Net.Http.HttpMessageHandler

A base type for HTTP message handlers.

#### System.Net.Http.HttpMessageHandler.#ctor

Initializes a new instance of the[System.Net.Http.HttpMessageHandler]class.


#### System.Net.Http.HttpMessageHandler.Dispose

Releases the unmanaged resources and disposes of the managed resources used by the[System.Net.Http.HttpMessageHandler].


#### System.Net.Http.HttpMessageHandler.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.HttpMessageHandler]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


#### System.Net.Http.HttpMessageHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)

Send an HTTP request as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to send. |
|cancellationToken |The cancellation token to cancel operation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


---
# System.Net.Http.HttpMessageInvoker

A specialty class that allows applications to call the[System.Net.Http.HttpMessageInvoker.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)]method on an Http handler chain.

#### System.Net.Http.HttpMessageInvoker.#ctor(System.Net.Http.HttpMessageHandler)

Initializes an instance of a[System.Net.Http.HttpMessageInvoker]class with a specific[System.Net.Http.HttpMessageHandler].


| Parameter | Description |
|-----------|-------------|
|   handler |The[System.Net.Http.HttpMessageHandler]responsible for processing the HTTP response messages. |


#### System.Net.Http.HttpMessageInvoker.#ctor(System.Net.Http.HttpMessageHandler,System.Boolean)

Initializes an instance of a[System.Net.Http.HttpMessageInvoker]class with a specific[System.Net.Http.HttpMessageHandler].


| Parameter | Description |
|-----------|-------------|
|   handler |The[System.Net.Http.HttpMessageHandler]responsible for processing the HTTP response messages. |
|disposeHandler |true if the inner handler should be disposed of by Dispose(),false if you intend to reuse the inner handler. |


#### System.Net.Http.HttpMessageInvoker.Dispose

Releases the unmanaged resources and disposes of the managed resources used by the[System.Net.Http.HttpMessageInvoker].


#### System.Net.Http.HttpMessageInvoker.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.HttpMessageInvoker]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


#### System.Net.Http.HttpMessageInvoker.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)

Send an HTTP request as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to send. |
|cancellationToken |The cancellation token to cancel operation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


---
# System.Net.Http.HttpMethod

A helper class for retrieving and comparing standard HTTP methods and for creating new HTTP methods.

#### System.Net.Http.HttpMethod.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.HttpMethod]class with a specific HTTP method.


| Parameter | Description |
|-----------|-------------|
|    method |The HTTP method. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpMethod.Delete |Represents an HTTP DELETE protocol method.


Returns: Returns[System.Net.Http.HttpMethod]. |

#### System.Net.Http.HttpMethod.Equals(System.Net.Http.HttpMethod)

Determines whether the specified[System.Net.Http.HttpMethod]is equal to the current[System.Object].


Returns: Returns[System.Boolean].true if the specified object is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     other |The HTTP method to compare with the current object. |


#### System.Net.Http.HttpMethod.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Object].


Returns: Returns[System.Boolean].true if the specified object is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpMethod.Get |Represents an HTTP GET protocol method.


Returns: Returns[System.Net.Http.HttpMethod]. |

#### System.Net.Http.HttpMethod.GetHashCode

Serves as a hash function for this type.


Returns: Returns[System.Int32].A hash code for the current[System.Object].


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpMethod.Head |Represents an HTTP HEAD protocol method. The HEAD method is identical to GET except that the server only returns message-headers in the response, without a message-body.


Returns: Returns[System.Net.Http.HttpMethod]. |
|System.Net.Http.HttpMethod.Method |An HTTP method.


Returns: Returns[System.String].An HTTP method represented as a[System.String]. |

#### System.Net.Http.HttpMethod.op_Equality(System.Net.Http.HttpMethod,System.Net.Http.HttpMethod)

The equality operator for comparing two[System.Net.Http.HttpMethod]objects.


Returns: Returns[System.Boolean].true if the specifiedleftandrightparameters are equal; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|      left |The left[System.Net.Http.HttpMethod]to an equality operator. |
|     right |The right[System.Net.Http.HttpMethod]to an equality operator. |


#### System.Net.Http.HttpMethod.op_Inequality(System.Net.Http.HttpMethod,System.Net.Http.HttpMethod)

The inequality operator for comparing two[System.Net.Http.HttpMethod]objects.


Returns: Returns[System.Boolean].true if the specifiedleftandrightparameters are inequal; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|      left |The left[System.Net.Http.HttpMethod]to an inequality operator. |
|     right |The right[System.Net.Http.HttpMethod]to an inequality operator. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpMethod.Options |Represents an HTTP OPTIONS protocol method.


Returns: Returns[System.Net.Http.HttpMethod]. |
|System.Net.Http.HttpMethod.Post |Represents an HTTP POST protocol method that is used to post a new entity as an addition to a URI.


Returns: Returns[System.Net.Http.HttpMethod]. |
|System.Net.Http.HttpMethod.Put |Represents an HTTP PUT protocol method that is used to replace an entity identified by a URI.


Returns: Returns[System.Net.Http.HttpMethod]. |

#### System.Net.Http.HttpMethod.ToString

Returns a string that represents the current object.


Returns: Returns[System.String].A string representing the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpMethod.Trace |Represents an HTTP TRACE protocol method.


Returns: Returns[System.Net.Http.HttpMethod]. |

---
# System.Net.Http.HttpRequestException

A base class for exceptions thrown by the[System.Net.Http.HttpClient]and[System.Net.Http.HttpMessageHandler]classes.

#### System.Net.Http.HttpRequestException.#ctor

Initializes a new instance of the[System.Net.Http.HttpRequestException]class.


#### System.Net.Http.HttpRequestException.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.HttpRequestException]class with a specific message that describes the current exception.


| Parameter | Description |
|-----------|-------------|
|   message |A message that describes the current exception. |


#### System.Net.Http.HttpRequestException.#ctor(System.String,System.Exception)

Initializes a new instance of the[System.Net.Http.HttpRequestException]class with a specific message that describes the current exception and an inner exception.


| Parameter | Description |
|-----------|-------------|
|   message |A message that describes the current exception. |
|     inner |The inner exception. |


---
# System.Net.Http.HttpRequestMessage

Represents a HTTP request message.

#### System.Net.Http.HttpRequestMessage.#ctor

Initializes a new instance of the[System.Net.Http.HttpRequestMessage]class.


#### System.Net.Http.HttpRequestMessage.#ctor(System.Net.Http.HttpMethod,System.String)

Initializes a new instance of the[System.Net.Http.HttpRequestMessage]class with an HTTP method and a request[System.Uri].


| Parameter | Description |
|-----------|-------------|
|    method |The HTTP method. |
|requestUri |A string that represents the request[System.Uri]. |


#### System.Net.Http.HttpRequestMessage.#ctor(System.Net.Http.HttpMethod,System.Uri)

Initializes a new instance of the[System.Net.Http.HttpRequestMessage]class with an HTTP method and a request[System.Uri].


| Parameter | Description |
|-----------|-------------|
|    method |The HTTP method. |
|requestUri |The[System.Uri]to request. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpRequestMessage.Content |Gets or sets the contents of the HTTP message.


Returns: Returns[System.Net.Http.HttpContent].The content of a message |

#### System.Net.Http.HttpRequestMessage.Dispose

Releases the unmanaged resources and disposes of the managed resources used by the[System.Net.Http.HttpRequestMessage].


#### System.Net.Http.HttpRequestMessage.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.HttpRequestMessage]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpRequestMessage.Headers |Gets the collection of HTTP request headers.


Returns: Returns[System.Net.Http.Headers.HttpRequestHeaders].The collection of HTTP request headers. |
|System.Net.Http.HttpRequestMessage.Method |Gets or sets the HTTP method used by the HTTP request message.


Returns: Returns[System.Net.Http.HttpMethod].The HTTP method used by the request message. The default is the GET method. |
|System.Net.Http.HttpRequestMessage.Properties |Gets a set of properties for the HTTP request.


Returns: Returns[System.Collections.Generic.IDictionary`2]. |
|System.Net.Http.HttpRequestMessage.RequestUri |Gets or sets the[System.Uri]used for the HTTP request.


Returns: Returns[System.Uri].The[System.Uri]used for the HTTP request. |

#### System.Net.Http.HttpRequestMessage.ToString

Returns a string that represents the current object.


Returns: Returns[System.String].A string representation of the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpRequestMessage.Version |Gets or sets the HTTP message version.


Returns: Returns[System.Version].The HTTP message version. The default is 1.1. |

---
# System.Net.Http.HttpResponseMessage

Represents a HTTP response message including the status code and data.

#### System.Net.Http.HttpResponseMessage.#ctor

Initializes a new instance of the[System.Net.Http.HttpResponseMessage]class.


#### System.Net.Http.HttpResponseMessage.#ctor(System.Net.HttpStatusCode)

Initializes a new instance of the[System.Net.Http.HttpResponseMessage]class with a specific[System.Net.Http.HttpResponseMessage.StatusCode].


| Parameter | Description |
|-----------|-------------|
|statusCode |The status code of the HTTP response. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpResponseMessage.Content |Gets or sets the content of a HTTP response message.


Returns: Returns[System.Net.Http.HttpContent].The content of the HTTP response message. |

#### System.Net.Http.HttpResponseMessage.Dispose

Releases the unmanaged resources and disposes of unmanaged resources used by the[System.Net.Http.HttpResponseMessage].


#### System.Net.Http.HttpResponseMessage.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.HttpResponseMessage]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


#### System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode

Throws an exception if the[System.Net.Http.HttpResponseMessage.IsSuccessStatusCode]property for the HTTP response is false.


Returns: Returns[System.Net.Http.HttpResponseMessage].The HTTP response message if the call is successful.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpResponseMessage.Headers |Gets the collection of HTTP response headers.


Returns: Returns[System.Net.Http.Headers.HttpResponseHeaders].The collection of HTTP response headers. |
|System.Net.Http.HttpResponseMessage.IsSuccessStatusCode |Gets a value that indicates if the HTTP response was successful.


Returns: Returns[System.Boolean].A value that indicates if the HTTP response was successful. true if[System.Net.Http.HttpResponseMessage.StatusCode]was in the range 200-299; otherwise false. |
|System.Net.Http.HttpResponseMessage.ReasonPhrase |Gets or sets the reason phrase which typically is sent by servers together with the status code.


Returns: Returns[System.String].The reason phrase sent by the server. |
|System.Net.Http.HttpResponseMessage.RequestMessage |Gets or sets the request message which led to this response message.


Returns: Returns[System.Net.Http.HttpRequestMessage].The request message which led to this response message. |
|System.Net.Http.HttpResponseMessage.StatusCode |Gets or sets the status code of the HTTP response.


Returns: Returns[System.Net.HttpStatusCode].The status code of the HTTP response. |

#### System.Net.Http.HttpResponseMessage.ToString

Returns a string that represents the current object.


Returns: Returns[System.String].A string representation of the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.HttpResponseMessage.Version |Gets or sets the HTTP message version.


Returns: Returns[System.Version].The HTTP message version. The default is 1.1. |

---
# System.Net.Http.MessageProcessingHandler

A base type for handlers which only do some small processing of request and/or response messages.

#### System.Net.Http.MessageProcessingHandler.#ctor

Creates an instance of a[System.Net.Http.MessageProcessingHandler]class.


#### System.Net.Http.MessageProcessingHandler.#ctor(System.Net.Http.HttpMessageHandler)

Creates an instance of a[System.Net.Http.MessageProcessingHandler]class with a specific inner handler.


| Parameter | Description |
|-----------|-------------|
|innerHandler |The inner handler which is responsible for processing the HTTP response messages. |


#### System.Net.Http.MessageProcessingHandler.ProcessRequest(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)

Performs processing on each request sent to the server.


Returns: Returns[System.Net.Http.HttpRequestMessage].The HTTP request message that was processed.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to process. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |


#### System.Net.Http.MessageProcessingHandler.ProcessResponse(System.Net.Http.HttpResponseMessage,System.Threading.CancellationToken)

Perform processing on each response from the server.


Returns: Returns[System.Net.Http.HttpResponseMessage].The HTTP response message that was processed.


| Parameter | Description |
|-----------|-------------|
|  response |The HTTP response message to process. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |


#### System.Net.Http.MessageProcessingHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)

Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|   request |The HTTP request message to send to the server. |
|cancellationToken |A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Therequestwas null.


---
# System.Net.Http.MultipartContent

Provides a collection of[System.Net.Http.HttpContent]objects that get serialized using the multipart/* content type specification.

#### System.Net.Http.MultipartContent.#ctor

Creates a new instance of the[System.Net.Http.MultipartContent]class.


#### System.Net.Http.MultipartContent.#ctor(System.String)

Creates a new instance of the[System.Net.Http.MultipartContent]class.


| Parameter | Description |
|-----------|-------------|
|   subtype |The subtype of the multipart content. |

Throws: [[System.ArgumentException|System.ArgumentException]]: Thesubtypewas null or contains only white space characters.


#### System.Net.Http.MultipartContent.#ctor(System.String,System.String)

Creates a new instance of the[System.Net.Http.MultipartContent]class.


| Parameter | Description |
|-----------|-------------|
|   subtype |The subtype of the multipart content. |
|  boundary |The boundary string for the multipart content. |

Throws: [[System.ArgumentException|System.ArgumentException]]: Thesubtypewas null or an empty string.Theboundarywas null or contains only white space characters.-or-Theboundaryends with a space character.


Throws: [[System.OutOfRangeException|System.OutOfRangeException]]: The length of theboundarywas greater than 70.


#### System.Net.Http.MultipartContent.Add(System.Net.Http.HttpContent)

Add multipart HTTP content to a collection of[System.Net.Http.HttpContent]objects that get serialized using the multipart/* content type specification.


| Parameter | Description |
|-----------|-------------|
|   content |The HTTP content to add to the collection. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Thecontentwas null.


#### System.Net.Http.MultipartContent.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.MultipartContent]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


#### System.Net.Http.MultipartContent.GetEnumerator

Returns an enumerator that iterates through the collection of[System.Net.Http.HttpContent]objects that get serialized using the multipart/* content type specification..


Returns: Returns[System.Collections.Generic.IEnumerator&lt;T&gt;].An object that can be used to iterate through the collection.


#### System.Net.Http.MultipartContent.SerializeToStreamAsync(System.IO.Stream,System.Net.TransportContext)

Serialize the multipart HTTP content to a stream as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|    stream |The target stream. |
|   context |Information about the transport (channel binding token, for example). This parameter may be null. |


#### System.Net.Http.MultipartContent.System#Collections#IEnumerable#GetEnumerator

The explicit implementation of the[System.Net.Http.MultipartContent.GetEnumerator]method.


Returns: Returns[System.Collections.IEnumerator].An object that can be used to iterate through the collection.


#### System.Net.Http.MultipartContent.TryComputeLength(System.Int64@)

Determines whether the HTTP multipart content has a valid length in bytes.


Returns: Returns[System.Boolean].true iflengthis a valid length; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|    length |The length in bytes of the HHTP content. |


---
# System.Net.Http.MultipartFormDataContent

Provides a container for content encoded using multipart/form-data MIME type.

#### System.Net.Http.MultipartFormDataContent.#ctor

Creates a new instance of the[System.Net.Http.MultipartFormDataContent]class.


#### System.Net.Http.MultipartFormDataContent.#ctor(System.String)

Creates a new instance of the[System.Net.Http.MultipartFormDataContent]class.


| Parameter | Description |
|-----------|-------------|
|  boundary |The boundary string for the multipart form data content. |

Throws: [[System.ArgumentException|System.ArgumentException]]: Theboundarywas null or contains only white space characters.-or-Theboundaryends with a space character.


Throws: [[System.OutOfRangeException|System.OutOfRangeException]]: The length of theboundarywas greater than 70.


#### System.Net.Http.MultipartFormDataContent.Add(System.Net.Http.HttpContent)

Add HTTP content to a collection of[System.Net.Http.HttpContent]objects that get serialized to multipart/form-data MIME type.


| Parameter | Description |
|-----------|-------------|
|   content |The HTTP content to add to the collection. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Thecontentwas null.


#### System.Net.Http.MultipartFormDataContent.Add(System.Net.Http.HttpContent,System.String)

Add HTTP content to a collection of[System.Net.Http.HttpContent]objects that get serialized to multipart/form-data MIME type.


| Parameter | Description |
|-----------|-------------|
|   content |The HTTP content to add to the collection. |
|      name |The name for the HTTP content to add. |

Throws: [[System.ArgumentException|System.ArgumentException]]: Thenamewas null or contains only white space characters.


Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Thecontentwas null.


#### System.Net.Http.MultipartFormDataContent.Add(System.Net.Http.HttpContent,System.String,System.String)

Add HTTP content to a collection of[System.Net.Http.HttpContent]objects that get serialized to multipart/form-data MIME type.


| Parameter | Description |
|-----------|-------------|
|   content |The HTTP content to add to the collection. |
|      name |The name for the HTTP content to add. |
|  fileName |The file name for the HTTP content to add to the collection. |

Throws: [[System.ArgumentException|System.ArgumentException]]: Thenamewas null or contains only white space characters.-or-ThefileNamewas null or contains only white space characters.


Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Thecontentwas null.


---
# System.Net.Http.StreamContent

Provides HTTP content based on a stream.

#### System.Net.Http.StreamContent.#ctor(System.IO.Stream)

Creates a new instance of the[System.Net.Http.StreamContent]class.


| Parameter | Description |
|-----------|-------------|
|   content |The content used to initialize the[System.Net.Http.StreamContent]. |


#### System.Net.Http.StreamContent.#ctor(System.IO.Stream,System.Int32)

Creates a new instance of the[System.Net.Http.StreamContent]class.


| Parameter | Description |
|-----------|-------------|
|   content |The content used to initialize the[System.Net.Http.StreamContent]. |
|bufferSize |The size, in bytes, of the buffer for the[System.Net.Http.StreamContent]. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Thecontentwas null.


Throws: [[System.OutOfRangeException|System.OutOfRangeException]]: ThebufferSizewas less than or equal to zero.


#### System.Net.Http.StreamContent.CreateContentReadStreamAsync

Write the HTTP stream content to a memory stream as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task&lt;T&gt;].The task object representing the asynchronous operation.


#### System.Net.Http.StreamContent.Dispose(System.Boolean)

Releases the unmanaged resources used by the[System.Net.Http.StreamContent]and optionally disposes of the managed resources.


| Parameter | Description |
|-----------|-------------|
| disposing |true to release both managed and unmanaged resources; false to releases only unmanaged resources. |


#### System.Net.Http.StreamContent.SerializeToStreamAsync(System.IO.Stream,System.Net.TransportContext)

Serialize the HTTP content to a stream as an asynchronous operation.


Returns: Returns[System.Threading.Tasks.Task].The task object representing the asynchronous operation.


| Parameter | Description |
|-----------|-------------|
|    stream |The target stream. |
|   context |Information about the transport (channel binding token, for example). This parameter may be null. |


#### System.Net.Http.StreamContent.TryComputeLength(System.Int64@)

Determines whether the stream content has a valid length in bytes.


Returns: Returns[System.Boolean].true iflengthis a valid length; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|    length |The length in bytes of the stream content. |


---
# System.Net.Http.StringContent

Provides HTTP content based on a string.

#### System.Net.Http.StringContent.#ctor(System.String)

Creates a new instance of the[System.Net.Http.StringContent]class.


| Parameter | Description |
|-----------|-------------|
|   content |The content used to initialize the[System.Net.Http.StringContent]. |


#### System.Net.Http.StringContent.#ctor(System.String,System.Text.Encoding)

Creates a new instance of the[System.Net.Http.StringContent]class.


| Parameter | Description |
|-----------|-------------|
|   content |The content used to initialize the[System.Net.Http.StringContent]. |
|  encoding |The encoding to use for the content. |


#### System.Net.Http.StringContent.#ctor(System.String,System.Text.Encoding,System.String)

Creates a new instance of the[System.Net.Http.StringContent]class.


| Parameter | Description |
|-----------|-------------|
|   content |The content used to initialize the[System.Net.Http.StringContent]. |
|  encoding |The encoding to use for the content. |
| mediaType |The media type to use for the content. |


---
# System.Net.Http.Headers.AuthenticationHeaderValue

Represents authentication information in Authorization, ProxyAuthorization, WWW-Authenticate, and Proxy-Authenticate header values.

#### System.Net.Http.Headers.AuthenticationHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.AuthenticationHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|    scheme |The scheme to use for authorization. |


#### System.Net.Http.Headers.AuthenticationHeaderValue.#ctor(System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.AuthenticationHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|    scheme |The scheme to use for authorization. |
| parameter |The credentials containing the authentication information of the user agent for the resource being requested. |


#### System.Net.Http.Headers.AuthenticationHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.AuthenticationHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.AuthenticationHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.AuthenticationHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.AuthenticationHeaderValue.Parameter |Gets the credentials containing the authentication information of the user agent for the resource being requested.


Returns: Returns[System.String].The credentials containing the authentication information. |

#### System.Net.Http.Headers.AuthenticationHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.AuthenticationHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.AuthenticationHeaderValue].An[System.Net.Http.Headers.AuthenticationHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents authentication header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid authentication header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.AuthenticationHeaderValue.Scheme |Gets the scheme to use for authorization.


Returns: Returns[System.String].The scheme to use for authorization. |

#### System.Net.Http.Headers.AuthenticationHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.AuthenticationHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.AuthenticationHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.AuthenticationHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.AuthenticationHeaderValue.TryParse(System.String,System.Net.Http.Headers.AuthenticationHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.AuthenticationHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.AuthenticationHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.AuthenticationHeaderValue]version of the string. |


---
# System.Net.Http.Headers.CacheControlHeaderValue

Represents the value of the Cache-Control header.

#### System.Net.Http.Headers.CacheControlHeaderValue.#ctor

Initializes a new instance of the[System.Net.Http.Headers.CacheControlHeaderValue]class.


#### System.Net.Http.Headers.CacheControlHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.CacheControlHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.CacheControlHeaderValue.Extensions |Cache-extension tokens, each with an optional assigned value.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].A collection of cache-extension tokens each with an optional assigned value. |

#### System.Net.Http.Headers.CacheControlHeaderValue.GetHashCode

Serves as a hash function for a[System.Net.Http.Headers.CacheControlHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.CacheControlHeaderValue.MaxAge |The maximum age, specified in seconds, that the HTTP client is willing to accept a response.


Returns: Returns[System.TimeSpan].The time in seconds. |
|System.Net.Http.Headers.CacheControlHeaderValue.MaxStale |Whether an HTTP client is willing to accept a response that has exceeded its expiration time.


Returns: Returns[System.Boolean].true if the HTTP client is willing to accept a response that has exceed the expiration time; otherwise, false. |
|System.Net.Http.Headers.CacheControlHeaderValue.MaxStaleLimit |The maximum time, in seconds, an HTTP client is willing to accept a response that has exceeded its expiration time.


Returns: Returns[System.TimeSpan].The time in seconds. |
|System.Net.Http.Headers.CacheControlHeaderValue.MinFresh |The freshness lifetime, in seconds, that an HTTP client is willing to accept a response.


Returns: Returns[System.TimeSpan].The time in seconds. |
|System.Net.Http.Headers.CacheControlHeaderValue.MustRevalidate |Whether the origin server require revalidation of a cache entry on any subsequent use when the cache entry becomes stale.


Returns: Returns[System.Boolean].true if the origin server requires revalidation of a cache entry on any subsequent use when the entry becomes stale; otherwise, false. |
|System.Net.Http.Headers.CacheControlHeaderValue.NoCache |Whether an HTTP client is willing to accept a cached response.


Returns: Returns[System.Boolean].true if the HTTP client is willing to accept a cached response; otherwise, false. |
|System.Net.Http.Headers.CacheControlHeaderValue.NoCacheHeaders |A collection of fieldnames in the "no-cache" directive in a cache-control header field on an HTTP response.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].A collection of fieldnames. |
|System.Net.Http.Headers.CacheControlHeaderValue.NoStore |Whether a cache must not store any part of either the HTTP request mressage or any response.


Returns: Returns[System.Boolean].true if a cache must not store any part of either the HTTP request mressage or any response; otherwise, false. |
|System.Net.Http.Headers.CacheControlHeaderValue.NoTransform |Whether a cache or proxy must not change any aspect of the entity-body.


Returns: Returns[System.Boolean].true if a cache or proxy must not change any aspect of the entity-body; otherwise, false. |
|System.Net.Http.Headers.CacheControlHeaderValue.OnlyIfCached |Whether a cache should either respond using a cached entry that is consistent with the other constraints of the HTTP request, or respond with a 504 (Gateway Timeout) status.


Returns: Returns[System.Boolean].true if a cache should either respond using a cached entry that is consistent with the other constraints of the HTTP request, or respond with a 504 (Gateway Timeout) status; otherwise, false. |

#### System.Net.Http.Headers.CacheControlHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.CacheControlHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.CacheControlHeaderValue].A[System.Net.Http.Headers.CacheControlHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents cache-control header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid cache-control header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.CacheControlHeaderValue.Private |Whether all or part of the HTTP response message is intended for a single user and must not be cached by a shared cache.


Returns: Returns[System.Boolean].true if the HTTP response message is intended for a single user and must not be cached by a shared cache; otherwise, false. |
|System.Net.Http.Headers.CacheControlHeaderValue.PrivateHeaders |A collection fieldnames in the "private" directive in a cache-control header field on an HTTP response.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].A collection of fieldnames. |
|System.Net.Http.Headers.CacheControlHeaderValue.ProxyRevalidate |Whether the origin server require revalidation of a cache entry on any subsequent use when the cache entry becomes stale for shared user agent caches.


Returns: Returns[System.Boolean].true if the origin server requires revalidation of a cache entry on any subsequent use when the entry becomes stale for shared user agent caches; otherwise, false. |
|System.Net.Http.Headers.CacheControlHeaderValue.Public |Whether an HTTP response may be cached by any cache, even if it would normally be non-cacheable or cacheable only within a non- shared cache.


Returns: Returns[System.Boolean].true if the HTTP response may be cached by any cache, even if it would normally be non-cacheable or cacheable only within a non- shared cache; otherwise, false. |
|System.Net.Http.Headers.CacheControlHeaderValue.SharedMaxAge |The shared maximum age, specified in seconds, in an HTTP response that overrides the "max-age" directive in a cache-control header or an Expires header for a shared cache.


Returns: Returns[System.TimeSpan].The time in seconds. |

#### System.Net.Http.Headers.CacheControlHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.CacheControlHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.CacheControlHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.CacheControlHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.CacheControlHeaderValue.TryParse(System.String,System.Net.Http.Headers.CacheControlHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.CacheControlHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.CacheControlHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.CacheControlHeaderValue]version of the string. |


---
# System.Net.Http.Headers.ContentDispositionHeaderValue

Represents the value of the Content-Disposition header.

#### System.Net.Http.Headers.ContentDispositionHeaderValue.#ctor(System.Net.Http.Headers.ContentDispositionHeaderValue)

Initializes a new instance of the[System.Net.Http.Headers.ContentDispositionHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|    source |A[System.Net.Http.Headers.ContentDispositionHeaderValue]. |


#### System.Net.Http.Headers.ContentDispositionHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.ContentDispositionHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|dispositionType |A string that contains a[System.Net.Http.Headers.ContentDispositionHeaderValue]. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ContentDispositionHeaderValue.CreationDate |The date at which the file was created.


Returns: Returns[System.DateTimeOffset].The file creation date. |
|System.Net.Http.Headers.ContentDispositionHeaderValue.DispositionType |The disposition type for a content body part.


Returns: Returns[System.String].The disposition type. |

#### System.Net.Http.Headers.ContentDispositionHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.ContentDispositionHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ContentDispositionHeaderValue.FileName |A suggestion for how to construct a filename for storing the message payload to be used if the entity is detached and stored in a separate file.


Returns: Returns[System.String].A suggested filename. |
|System.Net.Http.Headers.ContentDispositionHeaderValue.FileNameStar |A suggestion for how to construct filenames for storing message payloads to be used if the entities are detached and stored in a separate files.


Returns: Returns[System.String].A suggested filename of the form filename*. |

#### System.Net.Http.Headers.ContentDispositionHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.ContentDispositionHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ContentDispositionHeaderValue.ModificationDate |The date at which the file was last modified.


Returns: Returns[System.DateTimeOffset].The file modification date. |
|System.Net.Http.Headers.ContentDispositionHeaderValue.Name |The name for a content body part.


Returns: Returns[System.String].The name for the content body part. |
|System.Net.Http.Headers.ContentDispositionHeaderValue.Parameters |A set of parameters included the Content-Disposition header.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].A collection of parameters. |

#### System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.ContentDispositionHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.ContentDispositionHeaderValue].An[System.Net.Http.Headers.ContentDispositionHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents content disposition header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid content disposition header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ContentDispositionHeaderValue.ReadDate |The date the file was last read.


Returns: Returns[System.DateTimeOffset].The last read date. |
|System.Net.Http.Headers.ContentDispositionHeaderValue.Size |The approximate size, in bytes, of the file.


Returns: Returns[System.Int64].The approximate size, in bytes. |

#### System.Net.Http.Headers.ContentDispositionHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.ContentDispositionHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.ContentDispositionHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.ContentDispositionHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.ContentDispositionHeaderValue.TryParse(System.String,System.Net.Http.Headers.ContentDispositionHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.ContentDispositionHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.ContentDispositionHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.ContentDispositionHeaderValue]version of the string. |


---
# System.Net.Http.Headers.ContentRangeHeaderValue

Represents the value of the Content-Range header.

#### System.Net.Http.Headers.ContentRangeHeaderValue.#ctor(System.Int64)

Initializes a new instance of the[System.Net.Http.Headers.ContentRangeHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|    length |The starting or ending point of the range, in bytes. |


#### System.Net.Http.Headers.ContentRangeHeaderValue.#ctor(System.Int64,System.Int64)

Initializes a new instance of the[System.Net.Http.Headers.ContentRangeHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      from |The position, in bytes, at which to start sending data. |
|        to |The position, in bytes, at which to stop sending data. |


#### System.Net.Http.Headers.ContentRangeHeaderValue.#ctor(System.Int64,System.Int64,System.Int64)

Initializes a new instance of the[System.Net.Http.Headers.ContentRangeHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      from |The position, in bytes, at which to start sending data. |
|        to |The position, in bytes, at which to stop sending data. |
|    length |The starting or ending point of the range, in bytes. |


#### System.Net.Http.Headers.ContentRangeHeaderValue.Equals(System.Object)

Determines whether the specified Object is equal to the current[System.Net.Http.Headers.ContentRangeHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ContentRangeHeaderValue.From |Gets the position at which to start sending data.


Returns: Returns[System.Int64].The position, in bytes, at which to start sending data. |

#### System.Net.Http.Headers.ContentRangeHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.ContentRangeHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ContentRangeHeaderValue.HasLength |Gets whether the Content-Range header has a length specified.


Returns: Returns[System.Boolean].true if the Content-Range has a length specified; otherwise, false. |
|System.Net.Http.Headers.ContentRangeHeaderValue.HasRange |Gets whether the Content-Range has a range specified.


Returns: Returns[System.Boolean].true if the Content-Range has a range specified; otherwise, false. |
|System.Net.Http.Headers.ContentRangeHeaderValue.Length |Gets the length of the full entity-body.


Returns: Returns[System.Int64].The length of the full entity-body. |

#### System.Net.Http.Headers.ContentRangeHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.ContentRangeHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.ContentRangeHeaderValue].An[System.Net.Http.Headers.ContentRangeHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents content range header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid content range header value information.


#### System.Net.Http.Headers.ContentRangeHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.ContentRangeHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ContentRangeHeaderValue.To |Gets the position at which to stop sending data.


Returns: Returns[System.Int64].The position at which to stop sending data. |

#### System.Net.Http.Headers.ContentRangeHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.ContentRangeHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.ContentRangeHeaderValue.TryParse(System.String,System.Net.Http.Headers.ContentRangeHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.ContentRangeHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.ContentRangeHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.ContentRangeHeaderValue]version of the string. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ContentRangeHeaderValue.Unit |The range units used.


Returns: Returns[System.String].A[System.String]that contains range units. |

---
# System.Net.Http.Headers.EntityTagHeaderValue

Represents an entity-tag header value.

#### System.Net.Http.Headers.EntityTagHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.EntityTagHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|       tag |A string that contains an[System.Net.Http.Headers.EntityTagHeaderValue]. |


#### System.Net.Http.Headers.EntityTagHeaderValue.#ctor(System.String,System.Boolean)

Initializes a new instance of the[System.Net.Http.Headers.EntityTagHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|       tag |A string that contains an[System.Net.Http.Headers.EntityTagHeaderValue]. |
|    isWeak |A value that indicates if this entity-tag header is a weak validator. If the entity-tag header is weak validator, thenisWeakshould be set to true. If the entity-tag header is a strong validator, thenisWeakshould be set to false. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.EntityTagHeaderValue.Any |Gets the entity-tag header value.


Returns: Returns[System.Net.Http.Headers.EntityTagHeaderValue]. |

#### System.Net.Http.Headers.EntityTagHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.EntityTagHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.EntityTagHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.EntityTagHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.EntityTagHeaderValue.IsWeak |Gets whether the entity-tag is prefaced by a weakness indicator.


Returns: Returns[System.Boolean].true if the entity-tag is prefaced by a weakness indicator; otherwise, false. |

#### System.Net.Http.Headers.EntityTagHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.EntityTagHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.EntityTagHeaderValue].An[System.Net.Http.Headers.EntityTagHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents entity tag header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid entity tag header value information.


#### System.Net.Http.Headers.EntityTagHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.EntityTagHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.EntityTagHeaderValue.Tag |Gets the opaque quoted string.


Returns: Returns[System.String].An opaque quoted string. |

#### System.Net.Http.Headers.EntityTagHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.EntityTagHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.EntityTagHeaderValue.TryParse(System.String,System.Net.Http.Headers.EntityTagHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.EntityTagHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.EntityTagHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.EntityTagHeaderValue]version of the string. |


---
# System.Net.Http.Headers.HttpContentHeaders

Represents the collection of Content Headers as defined in RFC 2616.

|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.HttpContentHeaders.Allow |Gets the value of the Allow content header on an HTTP response.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].The value of the Allow header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.ContentDisposition |Gets the value of the Content-Disposition content header on an HTTP response.


Returns: Returns[System.Net.Http.Headers.ContentDispositionHeaderValue].The value of the Content-Disposition content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.ContentEncoding |Gets the value of the Content-Encoding content header on an HTTP response.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].The value of the Content-Encoding content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.ContentLanguage |Gets the value of the Content-Language content header on an HTTP response.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].The value of the Content-Language content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.ContentLength |Gets or sets the value of the Content-Length content header on an HTTP response.


Returns: Returns[System.Int64].The value of the Content-Length content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.ContentLocation |Gets or sets the value of the Content-Location content header on an HTTP response.


Returns: Returns[System.Uri].The value of the Content-Location content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.ContentMD5 |Gets or sets the value of the Content-MD5 content header on an HTTP response.


Returns: Returns[System.Byte].The value of the Content-MD5 content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.ContentRange |Gets or sets the value of the Content-Range content header on an HTTP response.


Returns: Returns[System.Net.Http.Headers.ContentRangeHeaderValue].The value of the Content-Range content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.ContentType |Gets or sets the value of the Content-Type content header on an HTTP response.


Returns: Returns[System.Net.Http.Headers.MediaTypeHeaderValue].The value of the Content-Type content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.Expires |Gets or sets the value of the Expires content header on an HTTP response.


Returns: Returns[System.DateTimeOffset].The value of the Expires content header on an HTTP response. |
|System.Net.Http.Headers.HttpContentHeaders.LastModified |Gets or sets the value of the Last-Modified content header on an HTTP response.


Returns: Returns[System.DateTimeOffset].The value of the Last-Modified content header on an HTTP response. |

---
# System.Net.Http.Headers.HttpHeaders

A collection of headers and their values as defined in RFC 2616.

#### System.Net.Http.Headers.HttpHeaders.#ctor

Initializes a new instance of the[System.Net.Http.Headers.HttpHeaders]class.


#### System.Net.Http.Headers.HttpHeaders.Add(System.String,System.Collections.Generic.IEnumerable{System.String})

Adds the specified header and its values into the[System.Net.Http.Headers.HttpHeaders]collection.


| Parameter | Description |
|-----------|-------------|
|      name |The header to add to the collection. |
|    values |A list of header values to add to the collection. |


#### System.Net.Http.Headers.HttpHeaders.Add(System.String,System.String)

Adds the specified header and its value into the[System.Net.Http.Headers.HttpHeaders]collection.


| Parameter | Description |
|-----------|-------------|
|      name |The header to add to the collection. |
|     value |The content of the header. |


#### System.Net.Http.Headers.HttpHeaders.Clear

Removes all headers from the[System.Net.Http.Headers.HttpHeaders]collection.


#### System.Net.Http.Headers.HttpHeaders.Contains(System.String)

Returns if a specific header exists in the[System.Net.Http.Headers.HttpHeaders]collection.


Returns: Returns[System.Boolean].true is the specified header exists in the collection; otherwise false.


| Parameter | Description |
|-----------|-------------|
|      name |The specific header. |


#### System.Net.Http.Headers.HttpHeaders.GetEnumerator

Returns an enumerator that can iterate through the[System.Net.Http.Headers.HttpHeaders]instance.


Returns: Returns[System.Collections.Generic.IEnumerator&lt;T&gt;].An enumerator for the[System.Net.Http.Headers.HttpHeaders].


#### System.Net.Http.Headers.HttpHeaders.GetValues(System.String)

Returns all header values for a specified header stored in the[System.Net.Http.Headers.HttpHeaders]collection.


Returns: Returns[System.Collections.Generic.IEnumerable&lt;T&gt;].An array of header strings.


| Parameter | Description |
|-----------|-------------|
|      name |The specified header to return values for. |


#### System.Net.Http.Headers.HttpHeaders.Remove(System.String)

Removes the specified header from the[System.Net.Http.Headers.HttpHeaders]collection.


Returns: Returns[System.Boolean].


| Parameter | Description |
|-----------|-------------|
|      name |The name of the header to remove from the collection. |


#### System.Net.Http.Headers.HttpHeaders.System#Collections#IEnumerable#GetEnumerator

Gets an enumerator that can iterate through a[System.Net.Http.Headers.HttpHeaders].


Returns: Returns[System.Collections.IEnumerator].An instance of an implementation of an[System.Collections.IEnumerator]that can iterate through a[System.Net.Http.Headers.HttpHeaders].


#### System.Net.Http.Headers.HttpHeaders.ToString

Returns a string that represents the current[System.Net.Http.Headers.HttpHeaders]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.HttpHeaders.TryAddWithoutValidation(System.String,System.Collections.Generic.IEnumerable{System.String})

Returns a value that indicates whether the specified header and its values were added to the[System.Net.Http.Headers.HttpHeaders]collection without validating the provided information.


Returns: Returns[System.Boolean].true if the specified headernameandvaluescould be added to the collection; otherwise false.


| Parameter | Description |
|-----------|-------------|
|      name |The header to add to the collection. |
|    values |The values of the header. |


#### System.Net.Http.Headers.HttpHeaders.TryAddWithoutValidation(System.String,System.String)

Returns a value that indicates whether the specified header and its value were added to the[System.Net.Http.Headers.HttpHeaders]collection without validating the provided information.


Returns: Returns[System.Boolean].true if the specified headernameandvaluecould be added to the collection; otherwise false.


| Parameter | Description |
|-----------|-------------|
|      name |The header to add to the collection. |
|     value |The content of the header. |


#### System.Net.Http.Headers.HttpHeaders.TryGetValues(System.String,System.Collections.Generic.IEnumerable{System.String}@)

Return if a specified header and specified values are stored in the[System.Net.Http.Headers.HttpHeaders]collection.


Returns: Returns[System.Boolean].true is the specified headernameand values are stored in the collection; otherwise false.


| Parameter | Description |
|-----------|-------------|
|      name |The specified header. |
|    values |The specified header values. |


---
# System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;

Represents a collection of header values.


| Parameter | Description |
|-----------|-------------|
|         T |The header collection type. |

#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.Add(`0)

Adds an entry to the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].


| Parameter | Description |
|-----------|-------------|
|      item |The item to add to the header collection. |


#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.Clear

Removes all entries from the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].


#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.Contains(`0)

Determines if the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]contains an item.


Returns: Returns[System.Boolean].true if the entry is contained in the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]instance; otherwise, false


| Parameter | Description |
|-----------|-------------|
|      item |The item to find to the header collection. |


#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.CopyTo(`0[],System.Int32)

Copies the entire[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]to a compatible one-dimensional[System.Array], starting at the specified index of the target array.


| Parameter | Description |
|-----------|-------------|
|     array |The one-dimensional[System.Array]that is the destination of the elements copied from[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]. The[System.Array]must have zero-based indexing. |
|arrayIndex |The zero-based index inarrayat which copying begins. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.Count |Gets the number of headers in the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].


Returns: Returns[System.Int32].The number of headers in a collection |

#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.GetEnumerator

Returns an enumerator that iterates through the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].


Returns: Returns[System.Collections.Generic.IEnumerator&lt;T&gt;].An enumerator for the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]instance.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.IsReadOnly |Gets a value indicating whether the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]instance is read-only.


Returns: Returns[System.Boolean].true if the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]instance is read-only; otherwise, false. |

#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.ParseAdd(System.String)

Parses and adds an entry to the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].


| Parameter | Description |
|-----------|-------------|
|     input |The entry to add. |


#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.Remove(`0)

Removes the specified item from the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].


Returns: Returns[System.Boolean].true if theitemwas removed from the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]instance; otherwise, false


| Parameter | Description |
|-----------|-------------|
|      item |The item to remove. |


#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.System#Collections#IEnumerable#GetEnumerator

Returns an enumerator that iterates through the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].


Returns: Returns[System.Collections.IEnumerator].An enumerator for the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]instance.


#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.ToString

Returns a string that represents the current[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]object. object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;.TryParseAdd(System.String)

Determines whether the input could be parsed and added to the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].


Returns: Returns[System.Boolean].true if theinputcould be parsed and added to the[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;]instance; otherwise, false


| Parameter | Description |
|-----------|-------------|
|     input |The entry to validate. |


---
# System.Net.Http.Headers.HttpRequestHeaders

Represents the collection of Request Headers as defined in RFC 2616.

|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.HttpRequestHeaders.Accept |Gets the value of the Accept header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Accept header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.AcceptCharset |Gets the value of the Accept-Charset header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Accept-Charset header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.AcceptEncoding |Gets the value of the Accept-Encoding header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Accept-Encoding header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.AcceptLanguage |Gets the value of the Accept-Language header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Accept-Language header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Authorization |Gets or sets the value of the Authorization header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.AuthenticationHeaderValue].The value of the Authorization header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.CacheControl |Gets or sets the value of the Cache-Control header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.CacheControlHeaderValue].The value of the Cache-Control header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Connection |Gets the value of the Connection header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Connection header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.ConnectionClose |Gets or sets a value that indicates if the Connection header for an HTTP request contains Close.


Returns: Returns[System.Boolean].true if the Connection header contains Close, otherwise false. |
|System.Net.Http.Headers.HttpRequestHeaders.Date |Gets or sets the value of the Date header for an HTTP request.


Returns: Returns[System.DateTimeOffset].The value of the Date header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Expect |Gets the value of the Expect header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Expect header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.ExpectContinue |Gets or sets a value that indicates if the Expect header for an HTTP request contains Continue.


Returns: Returns[System.Boolean].true if the Expect header contains Continue, otherwise false. |
|System.Net.Http.Headers.HttpRequestHeaders.From |Gets or sets the value of the From header for an HTTP request.


Returns: Returns[System.String].The value of the From header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Host |Gets or sets the value of the Host header for an HTTP request.


Returns: Returns[System.String].The value of the Host header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.IfMatch |Gets the value of the If-Match header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the If-Match header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.IfModifiedSince |Gets or sets the value of the If-Modified-Since header for an HTTP request.


Returns: Returns[System.DateTimeOffset].The value of the If-Modified-Since header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.IfNoneMatch |Gets the value of the If-None-Match header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].Gets the value of the If-None-Match header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.IfRange |Gets or sets the value of the If-Range header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.RangeConditionHeaderValue].The value of the If-Range header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.IfUnmodifiedSince |Gets or sets the value of the If-Unmodified-Since header for an HTTP request.


Returns: Returns[System.DateTimeOffset].The value of the If-Unmodified-Since header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.MaxForwards |Gets or sets the value of the Max-Forwards header for an HTTP request.


Returns: Returns[System.Int32].The value of the Max-Forwards header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Pragma |Gets the value of the Pragma header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Pragma header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.ProxyAuthorization |Gets or sets the value of the Proxy-Authorization header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.AuthenticationHeaderValue].The value of the Proxy-Authorization header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Range |Gets or sets the value of the Range header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.RangeHeaderValue].The value of the Range header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Referrer |Gets or sets the value of the Referer header for an HTTP request.


Returns: Returns[System.Uri].The value of the Referer header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.TE |Gets the value of the TE header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the TE header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Trailer |Gets the value of the Trailer header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Trailer header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.TransferEncoding |Gets the value of the Transfer-Encoding header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Transfer-Encoding header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.TransferEncodingChunked |Gets or sets a value that indicates if the Transfer-Encoding header for an HTTP request contains chunked.


Returns: Returns[System.Boolean].true if the Transfer-Encoding header contains chunked, otherwise false. |
|System.Net.Http.Headers.HttpRequestHeaders.Upgrade |Gets the value of the Upgrade header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Upgrade header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.UserAgent |Gets the value of the User-Agent header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the User-Agent header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Via |Gets the value of the Via header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Via header for an HTTP request. |
|System.Net.Http.Headers.HttpRequestHeaders.Warning |Gets the value of the Warning header for an HTTP request.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Warning header for an HTTP request. |

---
# System.Net.Http.Headers.HttpResponseHeaders

Represents the collection of Response Headers as defined in RFC 2616.

|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.HttpResponseHeaders.AcceptRanges |Gets the value of the Accept-Ranges header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Accept-Ranges header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Age |Gets or sets the value of the Age header for an HTTP response.


Returns: Returns[System.TimeSpan].The value of the Age header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.CacheControl |Gets or sets the value of the Cache-Control header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.CacheControlHeaderValue].The value of the Cache-Control header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Connection |Gets the value of the Connection header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Connection header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.ConnectionClose |Gets or sets a value that indicates if the Connection header for an HTTP response contains Close.


Returns: Returns[System.Boolean].true if the Connection header contains Close, otherwise false. |
|System.Net.Http.Headers.HttpResponseHeaders.Date |Gets or sets the value of the Date header for an HTTP response.


Returns: Returns[System.DateTimeOffset].The value of the Date header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.ETag |Gets or sets the value of the ETag header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.EntityTagHeaderValue].The value of the ETag header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Location |Gets or sets the value of the Location header for an HTTP response.


Returns: Returns[System.Uri].The value of the Location header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Pragma |Gets the value of the Pragma header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Pragma header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.ProxyAuthenticate |Gets the value of the Proxy-Authenticate header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Proxy-Authenticate header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.RetryAfter |Gets or sets the value of the Retry-After header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.RetryConditionHeaderValue].The value of the Retry-After header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Server |Gets the value of the Server header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Server header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Trailer |Gets the value of the Trailer header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Trailer header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.TransferEncoding |Gets the value of the Transfer-Encoding header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Transfer-Encoding header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.TransferEncodingChunked |Gets or sets a value that indicates if the Transfer-Encoding header for an HTTP response contains chunked.


Returns: Returns[System.Boolean].true if the Transfer-Encoding header contains chunked, otherwise false. |
|System.Net.Http.Headers.HttpResponseHeaders.Upgrade |Gets the value of the Upgrade header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Upgrade header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Vary |Gets the value of the Vary header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Vary header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Via |Gets the value of the Via header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Via header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.Warning |Gets the value of the Warning header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the Warning header for an HTTP response. |
|System.Net.Http.Headers.HttpResponseHeaders.WwwAuthenticate |Gets the value of the WWW-Authenticate header for an HTTP response.


Returns: Returns[System.Net.Http.Headers.HttpHeaderValueCollection&lt;T&gt;].The value of the WWW-Authenticate header for an HTTP response. |

---
# System.Net.Http.Headers.MediaTypeHeaderValue

Represents a media type used in a Content-Type header as defined in the RFC 2616.

#### System.Net.Http.Headers.MediaTypeHeaderValue.#ctor(System.Net.Http.Headers.MediaTypeHeaderValue)

Initializes a new instance of the[System.Net.Http.Headers.MediaTypeHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|    source |A[System.Net.Http.Headers.MediaTypeHeaderValue]object used to initialize the new instance. |


#### System.Net.Http.Headers.MediaTypeHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.MediaTypeHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
| mediaType |The source represented as a string to initialize the new instance. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.MediaTypeHeaderValue.CharSet |Gets or sets the character set.


Returns: Returns[System.String].The character set. |

#### System.Net.Http.Headers.MediaTypeHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.MediaTypeHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.MediaTypeHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.MediaTypeHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.MediaTypeHeaderValue.MediaType |Gets or sets the media-type header value.


Returns: Returns[System.String].The media-type header value. |
|System.Net.Http.Headers.MediaTypeHeaderValue.Parameters |Gets or sets the media-type header value parameters.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].The media-type header value parameters. |

#### System.Net.Http.Headers.MediaTypeHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.MediaTypeHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.MediaTypeHeaderValue].An[System.Net.Http.Headers.MediaTypeHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents media type header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid media type header value information.


#### System.Net.Http.Headers.MediaTypeHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.MediaTypeHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.MediaTypeHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.MediaTypeHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.MediaTypeHeaderValue.TryParse(System.String,System.Net.Http.Headers.MediaTypeHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.MediaTypeHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.MediaTypeHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.MediaTypeHeaderValue]version of the string. |


---
# System.Net.Http.Headers.MediaTypeWithQualityHeaderValue

Represents a media type with an additional quality factor used in a Content-Type header.

#### System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
| mediaType |A[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]represented as string to initialize the new instance. |


#### System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.#ctor(System.String,System.Double)

Initializes a new instance of the[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
| mediaType |A[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]represented as string to initialize the new instance. |
|   quality |The quality associated with this header value. |


#### System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue].An[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents media type with quality header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid media type with quality header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Quality |Get or set the quality value for the[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue].


Returns: Returns[System.Double].The quality value for the[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]object. |

#### System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.TryParse(System.String,System.Net.Http.Headers.MediaTypeWithQualityHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.MediaTypeWithQualityHeaderValue]version of the string. |


---
# System.Net.Http.Headers.NameValueHeaderValue

Represents a name/value pair used in various headers as defined in RFC 2616.

#### System.Net.Http.Headers.NameValueHeaderValue.#ctor(System.Net.Http.Headers.NameValueHeaderValue)

Initializes a new instance of the[System.Net.Http.Headers.NameValueHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|    source |A[System.Net.Http.Headers.NameValueHeaderValue]object used to initialize the new instance. |


#### System.Net.Http.Headers.NameValueHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.NameValueHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      name |The header name. |


#### System.Net.Http.Headers.NameValueHeaderValue.#ctor(System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.NameValueHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      name |The header name. |
|     value |The header value. |


#### System.Net.Http.Headers.NameValueHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.NameValueHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.NameValueHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.NameValueHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.NameValueHeaderValue.Name |Gets the header name.


Returns: Returns[System.String].The header name. |

#### System.Net.Http.Headers.NameValueHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.NameValueHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.NameValueHeaderValue].An[System.Net.Http.Headers.NameValueHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents name value header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid name value header value information.


#### System.Net.Http.Headers.NameValueHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.NameValueHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.NameValueHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.NameValueHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.NameValueHeaderValue.TryParse(System.String,System.Net.Http.Headers.NameValueHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.NameValueHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.NameValueHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.NameValueHeaderValue]version of the string. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.NameValueHeaderValue.Value |Gets the header value.


Returns: Returns[System.String].The header value. |

---
# System.Net.Http.Headers.NameValueWithParametersHeaderValue

Represents a name/value pair with parameters used in various headers as defined in RFC 2616.

#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.#ctor(System.Net.Http.Headers.NameValueWithParametersHeaderValue)

Initializes a new instance of the[System.Net.Http.Headers.NameValueWithParametersHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|    source |A[System.Net.Http.Headers.NameValueWithParametersHeaderValue]object used to initialize the new instance. |


#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.NameValueWithParametersHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      name |The header name. |


#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.#ctor(System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.NameValueWithParametersHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      name |The header name. |
|     value |The header value. |


#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.NameValueWithParametersHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.NameValueWithParametersHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.NameValueWithParametersHeaderValue.Parameters |Gets the parameters from the[System.Net.Http.Headers.NameValueWithParametersHeaderValue]object.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].A collection containing the parameters. |

#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.NameValueWithParametersHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.NameValueWithParametersHeaderValue].An[System.Net.Http.Headers.NameValueWithParametersHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents name value with parameter header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid name value with parameter header value information.


#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.NameValueWithParametersHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.NameValueWithParametersHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.NameValueWithParametersHeaderValue.TryParse(System.String,System.Net.Http.Headers.NameValueWithParametersHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.NameValueWithParametersHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.NameValueWithParametersHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.NameValueWithParametersHeaderValue]version of the string. |


---
# System.Net.Http.Headers.ProductHeaderValue

Represents a product token value in a User-Agent header.

#### System.Net.Http.Headers.ProductHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.ProductHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      name |The product name. |


#### System.Net.Http.Headers.ProductHeaderValue.#ctor(System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.ProductHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      name |The product name value. |
|   version |The product version value. |


#### System.Net.Http.Headers.ProductHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.ProductHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.ProductHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.ProductHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ProductHeaderValue.Name |Gets the name of the product token.


Returns: Returns[System.String].The name of the product token. |

#### System.Net.Http.Headers.ProductHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.ProductHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.ProductHeaderValue].An[System.Net.Http.Headers.ProductHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents product header value information. |


#### System.Net.Http.Headers.ProductHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.ProductHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.ProductHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.ProductHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.ProductHeaderValue.TryParse(System.String,System.Net.Http.Headers.ProductHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.ProductHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.ProductHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.ProductHeaderValue]version of the string. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ProductHeaderValue.Version |Gets the version of the product token.


Returns: Returns[System.String].The version of the product token. |

---
# System.Net.Http.Headers.ProductInfoHeaderValue

Represents a value which can either be a product or a comment in a User-Agent header.

#### System.Net.Http.Headers.ProductInfoHeaderValue.#ctor(System.Net.Http.Headers.ProductHeaderValue)

Initializes a new instance of the[System.Net.Http.Headers.ProductInfoHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|   product |A[System.Net.Http.Headers.ProductInfoHeaderValue]object used to initialize the new instance. |


#### System.Net.Http.Headers.ProductInfoHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.ProductInfoHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|   comment |A comment value. |


#### System.Net.Http.Headers.ProductInfoHeaderValue.#ctor(System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.ProductInfoHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|productName |The product name value. |
|productVersion |The product version value. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ProductInfoHeaderValue.Comment |Gets the comment from the[System.Net.Http.Headers.ProductInfoHeaderValue]object.


Returns: Returns[System.String].The comment value this[System.Net.Http.Headers.ProductInfoHeaderValue]. |

#### System.Net.Http.Headers.ProductInfoHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.ProductInfoHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.ProductInfoHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.ProductInfoHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


#### System.Net.Http.Headers.ProductInfoHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.ProductInfoHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.ProductInfoHeaderValue].An[System.Net.Http.Headers.ProductInfoHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents product info header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid product info header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ProductInfoHeaderValue.Product |Gets the product from the[System.Net.Http.Headers.ProductInfoHeaderValue]object.


Returns: Returns[System.Net.Http.Headers.ProductHeaderValue].The product value from this[System.Net.Http.Headers.ProductInfoHeaderValue]. |

#### System.Net.Http.Headers.ProductInfoHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.ProductInfoHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.ProductInfoHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.ProductInfoHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.ProductInfoHeaderValue.TryParse(System.String,System.Net.Http.Headers.ProductInfoHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.ProductInfoHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.ProductInfoHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.ProductInfoHeaderValue]version of the string. |


---
# System.Net.Http.Headers.RangeConditionHeaderValue

Represents an If-Range header value which can either be a date/time or an entity-tag value.

#### System.Net.Http.Headers.RangeConditionHeaderValue.#ctor(System.DateTimeOffset)

Initializes a new instance of the[System.Net.Http.Headers.RangeConditionHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      date |A date value used to initialize the new instance. |


#### System.Net.Http.Headers.RangeConditionHeaderValue.#ctor(System.Net.Http.Headers.EntityTagHeaderValue)

Initializes a new instance of the[System.Net.Http.Headers.RangeConditionHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
| entityTag |An[System.Net.Http.Headers.EntityTagHeaderValue]object used to initialize the new instance. |


#### System.Net.Http.Headers.RangeConditionHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.RangeConditionHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
| entityTag |An entity tag represented as a string used to initialize the new instance. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.RangeConditionHeaderValue.Date |Gets the date from the[System.Net.Http.Headers.RangeConditionHeaderValue]object.


Returns: Returns[System.DateTimeOffset].The date from the[System.Net.Http.Headers.RangeConditionHeaderValue]object. |
|System.Net.Http.Headers.RangeConditionHeaderValue.EntityTag |Gets the entity tag from the[System.Net.Http.Headers.RangeConditionHeaderValue]object.


Returns: Returns[System.Net.Http.Headers.EntityTagHeaderValue].The entity tag from the[System.Net.Http.Headers.RangeConditionHeaderValue]object. |

#### System.Net.Http.Headers.RangeConditionHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.RangeConditionHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.RangeConditionHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.RangeConditionHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


#### System.Net.Http.Headers.RangeConditionHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.RangeConditionHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.RangeConditionHeaderValue].An[System.Net.Http.Headers.RangeConditionHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents range condition header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid range Condition header value information.


#### System.Net.Http.Headers.RangeConditionHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.RangeConditionHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.RangeConditionHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.RangeConditionHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.RangeConditionHeaderValue.TryParse(System.String,System.Net.Http.Headers.RangeConditionHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.RangeConditionHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.RangeConditionHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.RangeConditionHeaderValue]version of the string. |


---
# System.Net.Http.Headers.RangeHeaderValue

Represents a Range header value.

#### System.Net.Http.Headers.RangeHeaderValue.#ctor

Initializes a new instance of the[System.Net.Http.Headers.RangeHeaderValue]class.


#### System.Net.Http.Headers.RangeHeaderValue.#ctor(System.Nullable{System.Int64},System.Nullable{System.Int64})

Initializes a new instance of the[System.Net.Http.Headers.RangeHeaderValue]class with a byte range.


| Parameter | Description |
|-----------|-------------|
|      from |The position at which to start sending data. |
|        to |The position at which to stop sending data. |

Throws: [[System.ArgumentOutOfRangeException|System.ArgumentOutOfRangeException]]: fromis greater thanto-or-fromortois less than 0.


#### System.Net.Http.Headers.RangeHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.RangeHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.RangeHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.RangeHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


#### System.Net.Http.Headers.RangeHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.RangeHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.RangeHeaderValue].An[System.Net.Http.Headers.RangeHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents range header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid range header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.RangeHeaderValue.Ranges |Gets the ranges specified from the[System.Net.Http.Headers.RangeHeaderValue]object.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].The ranges from the[System.Net.Http.Headers.RangeHeaderValue]object. |

#### System.Net.Http.Headers.RangeHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.RangeHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.RangeHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.RangeHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.RangeHeaderValue.TryParse(System.String,System.Net.Http.Headers.RangeHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.RangeHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.AuthenticationHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |he string to validate. |
|parsedValue |The[System.Net.Http.Headers.RangeHeaderValue]version of the string. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.RangeHeaderValue.Unit |Gets the unit from the[System.Net.Http.Headers.RangeHeaderValue]object.


Returns: Returns[System.String].The unit from the[System.Net.Http.Headers.RangeHeaderValue]object. |

---
# System.Net.Http.Headers.RangeItemHeaderValue

Represents a byte range in a Range header value.

#### System.Net.Http.Headers.RangeItemHeaderValue.#ctor(System.Nullable{System.Int64},System.Nullable{System.Int64})

Initializes a new instance of the[System.Net.Http.Headers.RangeItemHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      from |The position at which to start sending data. |
|        to |The position at which to stop sending data. |

Throws: [[System.ArgumentOutOfRangeException|System.ArgumentOutOfRangeException]]: fromis greater thanto-or-fromortois less than 0.


#### System.Net.Http.Headers.RangeItemHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.RangeItemHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.RangeItemHeaderValue.From |Gets the position at which to start sending data.


Returns: Returns[System.Int64].The position at which to start sending data. |

#### System.Net.Http.Headers.RangeItemHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.RangeItemHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


#### System.Net.Http.Headers.RangeItemHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.RangeItemHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.RangeItemHeaderValue.To |Gets the position at which to stop sending data.


Returns: Returns[System.Int64].The position at which to stop sending data. |

#### System.Net.Http.Headers.RangeItemHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.RangeItemHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


---
# System.Net.Http.Headers.RetryConditionHeaderValue

Represents a Retry-After header value which can either be a date/time or a timespan value.

#### System.Net.Http.Headers.RetryConditionHeaderValue.#ctor(System.DateTimeOffset)

Initializes a new instance of the[System.Net.Http.Headers.RetryConditionHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      date |The date and time offset used to initialize the new instance. |


#### System.Net.Http.Headers.RetryConditionHeaderValue.#ctor(System.TimeSpan)

Initializes a new instance of the[System.Net.Http.Headers.RetryConditionHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|     delta |The delta, in seconds, used to initialize the new instance. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.RetryConditionHeaderValue.Date |Gets the date and time offset from the[System.Net.Http.Headers.RetryConditionHeaderValue]object.


Returns: Returns[System.DateTimeOffset].The date and time offset from the[System.Net.Http.Headers.RetryConditionHeaderValue]object. |
|System.Net.Http.Headers.RetryConditionHeaderValue.Delta |Gets the delta in seconds from the[System.Net.Http.Headers.RetryConditionHeaderValue]object.


Returns: Returns[System.TimeSpan].The delta in seconds from the[System.Net.Http.Headers.RetryConditionHeaderValue]object. |

#### System.Net.Http.Headers.RetryConditionHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.RetryConditionHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.RetryConditionHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.RetryConditionHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


#### System.Net.Http.Headers.RetryConditionHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.RetryConditionHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.RetryConditionHeaderValue].An[System.Net.Http.Headers.RetryConditionHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents retry condition header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid retry condition header value information.


#### System.Net.Http.Headers.RetryConditionHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.RetryConditionHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.RetryConditionHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.RetryConditionHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.RetryConditionHeaderValue.TryParse(System.String,System.Net.Http.Headers.RetryConditionHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.RetryConditionHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.RetryConditionHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.RetryConditionHeaderValue]version of the string. |


---
# System.Net.Http.Headers.StringWithQualityHeaderValue

Represents a string header value with an optional quality.

#### System.Net.Http.Headers.StringWithQualityHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.StringWithQualityHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|     value |The string used to initialize the new instance. |


#### System.Net.Http.Headers.StringWithQualityHeaderValue.#ctor(System.String,System.Double)

Initializes a new instance of the[System.Net.Http.Headers.StringWithQualityHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|     value |A string used to initialize the new instance. |
|   quality |A quality factor used to initialize the new instance. |


#### System.Net.Http.Headers.StringWithQualityHeaderValue.Equals(System.Object)

Determines whether the specified Object is equal to the current[System.Net.Http.Headers.StringWithQualityHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.StringWithQualityHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.StringWithQualityHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


#### System.Net.Http.Headers.StringWithQualityHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.StringWithQualityHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.StringWithQualityHeaderValue].An[System.Net.Http.Headers.AuthenticationHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents quality header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid string with quality header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.StringWithQualityHeaderValue.Quality |Gets the quality factor from the[System.Net.Http.Headers.StringWithQualityHeaderValue]object.


Returns: Returns[System.Double].The quality factor from the[System.Net.Http.Headers.StringWithQualityHeaderValue]object. |

#### System.Net.Http.Headers.StringWithQualityHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.StringWithQualityHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.StringWithQualityHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.StringWithQualityHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.StringWithQualityHeaderValue.TryParse(System.String,System.Net.Http.Headers.StringWithQualityHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.StringWithQualityHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.StringWithQualityHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.StringWithQualityHeaderValue]version of the string. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.StringWithQualityHeaderValue.Value |Gets the string value from the[System.Net.Http.Headers.StringWithQualityHeaderValue]object.


Returns: Returns[System.String].The string value from the[System.Net.Http.Headers.StringWithQualityHeaderValue]object. |

---
# System.Net.Http.Headers.TransferCodingHeaderValue

Represents an accept-encoding header value.

#### System.Net.Http.Headers.TransferCodingHeaderValue.#ctor(System.Net.Http.Headers.TransferCodingHeaderValue)

Initializes a new instance of the[System.Net.Http.Headers.TransferCodingHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|    source |A[System.Net.Http.Headers.TransferCodingHeaderValue]object used to initialize the new instance. |


#### System.Net.Http.Headers.TransferCodingHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.TransferCodingHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|     value |A string used to initialize the new instance. |


#### System.Net.Http.Headers.TransferCodingHeaderValue.Equals(System.Object)

Determines whether the specified Object is equal to the current[System.Net.Http.Headers.TransferCodingHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.TransferCodingHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.TransferCodingHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.TransferCodingHeaderValue.Parameters |Gets the transfer-coding parameters.


Returns: Returns[System.Collections.Generic.ICollection&lt;T&gt;].The transfer-coding parameters. |

#### System.Net.Http.Headers.TransferCodingHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.TransferCodingHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.TransferCodingHeaderValue].An[System.Net.Http.Headers.AuthenticationHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents transfer-coding header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid transfer-coding header value information.


#### System.Net.Http.Headers.TransferCodingHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.TransferCodingHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.TransferCodingHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.TransferCodingHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.TransferCodingHeaderValue.TryParse(System.String,System.Net.Http.Headers.TransferCodingHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.TransferCodingHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.TransferCodingHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.TransferCodingHeaderValue]version of the string. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.TransferCodingHeaderValue.Value |Gets the transfer-coding value.


Returns: Returns[System.String].The transfer-coding value. |

---
# System.Net.Http.Headers.TransferCodingWithQualityHeaderValue

Represents an Accept-Encoding header value.with optional quality factor.

#### System.Net.Http.Headers.TransferCodingWithQualityHeaderValue.#ctor(System.String)

Initializes a new instance of the[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|     value |A string used to initialize the new instance. |


#### System.Net.Http.Headers.TransferCodingWithQualityHeaderValue.#ctor(System.String,System.Double)

Initializes a new instance of the[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|     value |A string used to initialize the new instance. |
|   quality |A value for the quality factor. |


#### System.Net.Http.Headers.TransferCodingWithQualityHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue].An[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents transfer-coding value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid transfer-coding with quality header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.TransferCodingWithQualityHeaderValue.Quality |Gets the quality factor from the[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue].


Returns: Returns[System.Double].The quality factor from the[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]. |

#### System.Net.Http.Headers.TransferCodingWithQualityHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.TransferCodingWithQualityHeaderValue.TryParse(System.String,System.Net.Http.Headers.TransferCodingWithQualityHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.TransferCodingWithQualityHeaderValue]version of the string. |


---
# System.Net.Http.Headers.ViaHeaderValue

Represents the value of a Via header.

#### System.Net.Http.Headers.ViaHeaderValue.#ctor(System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.ViaHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|protocolVersion |The protocol version of the received protocol. |
|receivedBy |The host and port that the request or response was received by. |


#### System.Net.Http.Headers.ViaHeaderValue.#ctor(System.String,System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.ViaHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|protocolVersion |The protocol version of the received protocol. |
|receivedBy |The host and port that the request or response was received by. |
|protocolName |The protocol name of the received protocol. |


#### System.Net.Http.Headers.ViaHeaderValue.#ctor(System.String,System.String,System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.ViaHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|protocolVersion |The protocol version of the received protocol. |
|receivedBy |The host and port that the request or response was received by. |
|protocolName |The protocol name of the received protocol. |
|   comment |The comment field used to identify the software of the recipient proxy or gateway. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ViaHeaderValue.Comment |Gets the comment field used to identify the software of the recipient proxy or gateway.


Returns: Returns[System.String].The comment field used to identify the software of the recipient proxy or gateway. |

#### System.Net.Http.Headers.ViaHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.ViaHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.ViaHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.ViaHeaderValue]object.


Returns: Returns[System.Int32].Returns a hash code for the current object.


#### System.Net.Http.Headers.ViaHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.ViaHeaderValue]instance.


Returns: Returns[System.Net.Http.Headers.ViaHeaderValue].An[System.Net.Http.Headers.ViaHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents via header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid via header value information.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.ViaHeaderValue.ProtocolName |Gets the protocol name of the received protocol.


Returns: Returns[System.String].The protocol name. |
|System.Net.Http.Headers.ViaHeaderValue.ProtocolVersion |Gets the protocol version of the received protocol.


Returns: Returns[System.String].The protocol version. |
|System.Net.Http.Headers.ViaHeaderValue.ReceivedBy |Gets the host and port that the request or response was received by.


Returns: Returns[System.String].The host and port that the request or response was received by. |

#### System.Net.Http.Headers.ViaHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.ViaHeaderValue]instance.


Returns: Returns[System.Object].A copy of the current instance.


#### System.Net.Http.Headers.ViaHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.ViaHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.ViaHeaderValue.TryParse(System.String,System.Net.Http.Headers.ViaHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.ViaHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.ViaHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.ViaHeaderValue]version of the string. |


---
# System.Net.Http.Headers.WarningHeaderValue

Represents a warning value used by the Warning header.

#### System.Net.Http.Headers.WarningHeaderValue.#ctor(System.Int32,System.String,System.String)

Initializes a new instance of the[System.Net.Http.Headers.WarningHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      code |The specific warning code. |
|     agent |The host that attached the warning. |
|      text |A quoted-string containing the warning text. |


#### System.Net.Http.Headers.WarningHeaderValue.#ctor(System.Int32,System.String,System.String,System.DateTimeOffset)

Initializes a new instance of the[System.Net.Http.Headers.WarningHeaderValue]class.


| Parameter | Description |
|-----------|-------------|
|      code |The specific warning code. |
|     agent |The host that attached the warning. |
|      text |A quoted-string containing the warning text. |
|      date |The date/time stamp of the warning. |


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.WarningHeaderValue.Agent |Gets the host that attached the warning.


Returns: Returns[System.String].The host that attached the warning. |
|System.Net.Http.Headers.WarningHeaderValue.Code |Gets the specific warning code.


Returns: Returns[System.Int32].The specific warning code. |
|System.Net.Http.Headers.WarningHeaderValue.Date |Gets the date/time stamp of the warning.


Returns: Returns[System.DateTimeOffset].The date/time stamp of the warning. |

#### System.Net.Http.Headers.WarningHeaderValue.Equals(System.Object)

Determines whether the specified[System.Object]is equal to the current[System.Net.Http.Headers.WarningHeaderValue]object.


Returns: Returns[System.Boolean].true if the specified[System.Object]is equal to the current object; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|       obj |The object to compare with the current object. |


#### System.Net.Http.Headers.WarningHeaderValue.GetHashCode

Serves as a hash function for an[System.Net.Http.Headers.WarningHeaderValue]object.


Returns: Returns[System.Int32].A hash code for the current object.


#### System.Net.Http.Headers.WarningHeaderValue.Parse(System.String)

Converts a string to an[System.Net.Http.Headers.WarningHeaderValue]instance.


Returns: Returns an[System.Net.Http.Headers.WarningHeaderValue]instance.


| Parameter | Description |
|-----------|-------------|
|     input |A string that represents authentication header value information. |

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: inputis a null reference.


Throws: [[System.FormatException|System.FormatException]]: inputis not valid authentication header value information.


#### System.Net.Http.Headers.WarningHeaderValue.System#ICloneable#Clone

Creates a new object that is a copy of the current[System.Net.Http.Headers.WarningHeaderValue]instance.


Returns: Returns[System.Object].Returns a copy of the current instance.


|  Property | Description |
|-----------|-------------|
|System.Net.Http.Headers.WarningHeaderValue.Text |Gets a quoted-string containing the warning text.


Returns: Returns[System.String].A quoted-string containing the warning text. |

#### System.Net.Http.Headers.WarningHeaderValue.ToString

Returns a string that represents the current[System.Net.Http.Headers.WarningHeaderValue]object.


Returns: Returns[System.String].A string that represents the current object.


#### System.Net.Http.Headers.WarningHeaderValue.TryParse(System.String,System.Net.Http.Headers.WarningHeaderValue@)

Determines whether a string is valid[System.Net.Http.Headers.WarningHeaderValue]information.


Returns: Returns[System.Boolean].true ifinputis valid[System.Net.Http.Headers.WarningHeaderValue]information; otherwise, false.


| Parameter | Description |
|-----------|-------------|
|     input |The string to validate. |
|parsedValue |The[System.Net.Http.Headers.WarningHeaderValue]version of the string. |



