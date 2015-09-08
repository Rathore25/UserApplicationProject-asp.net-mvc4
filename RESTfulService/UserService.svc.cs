using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using log4net;
using BusinessLayer;
using DataObject;

namespace RESTfulService
{
    public class UserService : IUserService
    {

        private static readonly ILog _log = LogManager.GetLogger(typeof(UserService));

        #region Create
        public string AddUser(DataObject.UserDataObject userData)
        {
            try
            {
                BusinessLayer.Users.CreateUser(userData);
                return "Success";
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Error in Adding User", ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        } 
        #endregion

        #region Retrieve
        public List<UserDataObject> RetrieveAllUsers(string Fid)
        {
            try
            {
                List<UserDataObject> listOut = new List<UserDataObject>();

                List<DataObject.UserDataObject> listReceived = BusinessLayer.Users.RetrieveAllUser(Fid);
                foreach (var item in listReceived)
                {
                    UserDataObject Data = new UserDataObject();
                    Data.AutoId = item.AutoId;
                    Data.City = item.City;
                    Data.Dob = item.Dob;
                    Data.EmailId = item.EmailId;
                    Data.Name = item.Name;
                    Data.PhoneNumber = item.PhoneNumber;
                    Data.Uid = item.Uid;
                    listOut.Add(Data);
                }
                return listOut;
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Unexpected Error caused by " + ex.Source, ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        #region Update
        public UserDataObject RetrieveUser(string userId)
        {
            try
            {
                DataObject.UserDataObject UserData = BusinessLayer.Users.RetrieveUser(userId);
                if (string.IsNullOrEmpty(UserData.AutoId))
                {
                    MyCustomErrorDetail Error = new MyCustomErrorDetail("No user found", "No User with such id was in the database");
                    throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.NotFound);
                }
                else
                {
                    UserDataObject Data = new UserDataObject();
                    Data.AutoId = UserData.AutoId;
                    Data.City = UserData.City;
                    Data.Dob = UserData.Dob;
                    Data.EmailId = UserData.EmailId;
                    Data.Name = UserData.Name;
                    Data.PhoneNumber = UserData.PhoneNumber;
                    Data.Uid = UserData.Uid;

                    return Data;
                }
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Unexpected Error caused by " + ex.Source, ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public string UpdateUser(DataObject.UserDataObject userData)
        {
            try
            {
                BusinessLayer.Users.EditUser(userData);
                return "Success";
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Error in Updating User", ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        } 
        #endregion

        #region Delete
        public string DeleteUser(string uid)
        {
            try
            {
                BusinessLayer.Users.DeleteUser(uid);
                return "Success";
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Error in Updating User", ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        } 
        #endregion

    }
}
