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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {

        #region Create
        [OperationContract]
        [WebInvoke(
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle=WebMessageBodyStyle.WrappedResponse,
                    UriTemplate = "/Add"
                   )]

        string AddUser(DataObject.UserDataObject userData); 
        #endregion

        #region Update
        [OperationContract]
        [WebInvoke(
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle=WebMessageBodyStyle.WrappedResponse,
                    UriTemplate = "/User"
                   )]

        DataObject.UserDataObject RetrieveUser(string userId);

        [OperationContract]
        [WebInvoke(
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle=WebMessageBodyStyle.WrappedResponse,
                    UriTemplate = "/Update"
                   )]

        string UpdateUser(DataObject.UserDataObject userData); 
        #endregion

        #region Retrieve
        [OperationContract]
        [WebInvoke(
                    Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle=WebMessageBodyStyle.WrappedResponse,
                    UriTemplate = "/Users"
                   )]

        List<DataObject.UserDataObject> RetrieveAllUsers(); 
        #endregion

        #region Delete
        [OperationContract]
        [WebInvoke(
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/Delete"
                   )]

        string DeleteUser(string uid); 
        #endregion
    }


    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
