using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLayer;
using DataAccessLayer;
using System.ServiceModel.Web;
using DataObject;
namespace RESTfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    public class AccountService : IAccountService
    {
        public string Register(DataObject.RegisterDataObject accountData)
        {
            try
            {
                BusinessLayer.Accounts.Register(accountData);
                return "Success";
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Error in Registering",ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public RegisterDataObject Login(DataObject.LoginDataObject loginData)
        {
            try
            {
                DataObject.RegisterDataObject RegisterData= BusinessLayer.Accounts.Validate(loginData);
                if (string.IsNullOrEmpty(RegisterData.Guid) || string.IsNullOrEmpty(RegisterData.UserName))
                {
                    return new RegisterDataObject();
                }
                else
                {
                    RegisterDataObject Data = new RegisterDataObject();
                    Data.AutoId = RegisterData.AutoId;
                    Data.ConfirmPassword = RegisterData.ConfirmPassword;
                    Data.EmailId = RegisterData.EmailId;
                    Data.FullName = RegisterData.FullName;
                    Data.Guid = RegisterData.Guid;
                    Data.Password = RegisterData.Password;
                    Data.UserName = RegisterData.UserName;
                    return Data;
                }
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Unexpected Error caused by "+ex.Source, ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public RegisterDataObject RetrievePassword(DataObject.RegisterDataObject userData)
        {
            try
            {
                DataObject.RegisterDataObject Password = BusinessLayer.Accounts.Retrieve(userData);
                if (string.IsNullOrEmpty(Password.Password))
                {
                    return new RegisterDataObject();
                }
                else
                {
                    RegisterDataObject Data = new RegisterDataObject();
                    Data.AutoId = Password.AutoId;
                    Data.ConfirmPassword = Password.ConfirmPassword;
                    Data.EmailId = Password.EmailId;
                    Data.FullName = Password.FullName;
                    Data.Guid = Password.Guid;
                    Data.Password = Password.Password;
                    Data.UserName = Password.UserName;
                    return Data;
                }
            }
            catch (Exception ex)
            {
                MyCustomErrorDetail Error = new MyCustomErrorDetail("Unexpected Error caused by " + ex.Source, ex.Message);
                throw new WebFaultException<MyCustomErrorDetail>(Error, System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
