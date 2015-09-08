using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using DataAccessLayer;

namespace RESTfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        [WebInvoke(
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle= WebMessageBodyStyle.WrappedResponse,
                    UriTemplate = "/Register"
                   )]

        string Register(DataObject.RegisterDataObject accountData);

        [OperationContract]
        [WebInvoke(
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle=WebMessageBodyStyle.WrappedResponse,
                    UriTemplate = "/Login"
                   )]

        RegisterDataObject Login(DataObject.LoginDataObject loginData);
    }

    [DataContract]
    public class MyCustomErrorDetail
    {
        public MyCustomErrorDetail(string errorInfo, string errorDetails)
        {
            ErrorInfo = errorInfo;
            ErrorDetails = errorDetails;
        }

        [DataMember]
        public string ErrorInfo { get; private set; }

        [DataMember]
        public string ErrorDetails { get; private set; }
    }

    [DataContract]
    public class LoginDataObject
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    [DataContract]
    public class RegisterDataObject
    {
        [DataMember]
        public string AutoId { get; set; }
        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string EmailId { get; set; }
    }
}
