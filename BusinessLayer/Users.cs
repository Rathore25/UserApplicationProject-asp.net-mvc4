using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data;

namespace BusinessLayer
{
    public class Users
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Users).Name);

        #region AllUser
        public static List<DataObject.UserDataObject> RetrieveAllUser()
        {
            _log.Debug("BusinessLayer.RetrieveAllUser Entered");
            try
            {
                return DataAccessLayer.Users.AllUser();
            }
            catch (Exception exception)
            {
                _log.Error("Error in RetrieveAllUser :" + exception);
                throw exception;
            }
            finally
            {
                _log.Debug("BusinessLayer.RetrieveAllUser Exited");
            }
        } 
        #endregion

        public static void CreateUser(DataObject.UserDataObject UserData)
        {
            _log.Debug("BusinessLayer.CreateUser Entered");
            _log.Debug("Parameter jsonStringUserData :" + UserData);
            try
            {
                DataAccessLayer.Users.EnterRow(UserData);
            }
            catch (Exception exception)
            {
                _log.Error("Error in BusinessLayer.CreateUser :" + exception);
                throw exception;
            }
            finally
            {
                _log.Debug("BusinessLayer.CreateUser Exited");
            }
        }

        public static DataObject.UserDataObject RetrieveUser(string uid)
        {
            _log.Debug("BusinessLayer.RetrieveUser entered");
            try
            {
                return DataAccessLayer.Users.SpecificRowData(uid);
            }
            catch (Exception exception)
            {
                _log.Error("Error in BusinessLayer.RetrieveUser :" + exception);
                throw exception;
            }
            finally
            {
                _log.Debug("BusinessLayer.RetrieveUser exited");
            }
        }

        public static void EditUser(DataObject.UserDataObject RowData)
        {
            _log.Debug("BusinessLayer.EditUser entered");
            try
            {
                DataAccessLayer.Users.EditRow(RowData);
            }
            catch (Exception exception)
            {
                _log.Error("Error in BusinessLayer.EditUser :" + exception);
                throw exception;
            }
            finally
            {
                _log.Debug("BusinessLayer.EditUser Exited");
            }
        }

        public static void DeleteUser(string uid)
        {
            _log.Debug("BusinessLayer.DeleteUser entered");
            _log.Debug("Parameter uid :" + uid);
            try
            {
                DataAccessLayer.Users.DeleteRow(uid);
            }
            catch (Exception exception)
            {
                _log.Error("Error in BusinessLayer.DeleteUser :" + exception);
                throw exception;
            }
            finally
            {
                _log.Debug("BusinessLayer.DeleteUser Exited");
            }
        }
    }
}
