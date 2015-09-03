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



        public string AddUser(UserDataObject userData)
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

        public UserDataObject RetrieveUser(string userId)
        {
            try
            {
                UserDataObject UserData=BusinessLayer.Users.RetrieveUser(userId);
                if (string.IsNullOrEmpty(UserData.AutoId))
                {
                    MyCustomErrorDetail Error = new MyCustomErrorDetail("No user found", "No User with such id was in the database");
                    throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.NotFound);
                }
                else
                    return UserData;
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Unexpected Error caused by " + ex.Source, ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public string UpdateUser(UserDataObject userData)
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

        public List<UserDataObject> RetrieveAllUsers()
        {
            try
            {
                return BusinessLayer.Users.RetrieveAllUser();
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Unexpected Error caused by " + ex.Source, ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        }

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
    }
}
