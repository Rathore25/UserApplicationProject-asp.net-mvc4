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
                    //if (!string.IsNullOrEmpty(error))
                    //{   
                        //error should not be null
                        var ErrorBody = JsonConvert.DeserializeObject(error) as JToken;
                        if (ErrorBody != null)
                        {
                            //it can be both generic or custom
                            if (ErrorBody.Children().Contains("ErrorInfo"))
                            {
                                //it is custom
                                throw new Exception(ErrorBody["ErrorInfo"].ToString());
                            }
                            else
                                throw new Exception(ErrorBody.ToString());//generic
                        }
                        else
                            throw new Exception(error);
                    //}
                }
                else
                    throw new Exception("There is an unexpected error with reading the stream.", ex);
            }
        }
    }
}
