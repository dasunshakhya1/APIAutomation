using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.models
{
    public class Response
    {
        private string content;
        //private HeaderParameter headers;
        private int statusCode;

        public Response(string resContent, int resStatusCode)
        {
            this.content = resContent;

            this.statusCode = resStatusCode;
        }

        public string? Content { get { return content; } }
        //public HeaderParameter Headers { get { return headers; } }
        public int StatusCode { get { return statusCode; } }
    }
}
