using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Utilities
{
    public class HttpRequest
    {
        public static string GetHttpRequest(string url, string requestMethod, string requestData)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
                Request.Method = requestMethod;
                Request.ContentType = "application/json";
                if (!string.IsNullOrEmpty(requestData) && !requestData.Equals("{}"))
                {
                    using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                    {
                        Writer.Write(requestData);
                    }
                }
                
                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                {
                    using (Stream ResponseData = Response.GetResponseStream())
                    {
                        using (StreamReader Reader = new StreamReader(ResponseData))
                        {
                            return Reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var protocolException = ex as WebException;
                if (protocolException != null)
                {
                    var responseStream = protocolException.Response.GetResponseStream();
                    var error = new StreamReader(protocolException.Response.GetResponseStream()).ReadToEnd();

                        var ErrorBody = JsonConvert.DeserializeObject<MyCustomErrorDetail>(error);
                        if (ErrorBody != null)
                        {
                            if (!string.IsNullOrEmpty(ErrorBody.ErrorInfo))
                            {
                                throw new Exception(ErrorBody.ErrorDetails);
                            }
                            else
                                throw new Exception(JsonConvert.SerializeObject(ErrorBody));//generic
                        }
                        else
                            throw new Exception(error);
                    
                }
                else
                    throw new Exception("There is an unexpected error with reading the stream.", ex);
            }
        }
    }
}
