using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace BraintreeHttp
{
    public class FormEncodedSerializer: ISerializer
    {
        public string GetContentTypeRegexPattern()
        {
            return "application/x-www-form-urlencoded";
        }

        public object DeserializeResponse(HttpContent content, Type responseType)
        {
            throw new IOException($"Unable to deserialize Content-Type: {this.GetContentTypeRegexPattern()}.");
        }

        public HttpContent SerializeRequest(HttpRequest request)
        {
            if (!(request.Body is IDictionary))
            {
                throw new IOException("Request requestBody must be Map<string, string> when Content-Type is application/x-www-form-urlencoded");
            }

            return new FormUrlEncodedContent((Dictionary<string, string>)request.Body);
        }
    }
}