using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using log4net;
using BusinessLayer;

namespace RESTfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    public class UserService : IUserService
    {

        private static readonly ILog _log = LogManager.GetLogger(typeof(UserService));



        public string AddUser(DataObject.UserDataObject userData)
        {
            try
            {
                BusinessLayer.Users.CreateUser(userData);
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataObject.UserDataObject RetrieveUser(string userId)
        {
            try
            {
                return BusinessLayer.Users.RetrieveUser(userId);
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }

        public List<DataObject.UserDataObject> RetrieveAllUsers()
        {
            try
            {
                return BusinessLayer.Users.RetrieveAllUser();
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }
    }
}
