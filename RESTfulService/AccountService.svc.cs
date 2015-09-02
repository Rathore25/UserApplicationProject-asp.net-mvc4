﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLayer;
using DataAccessLayer;
using System.ServiceModel.Web;

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
                throw ex;
            }
        }

        public DataObject.RegisterDataObject Login(DataObject.LoginDataObject loginData)
        {
            try
            {
                DataObject.RegisterDataObject Data= BusinessLayer.Accounts.Validate(loginData);
                if (string.IsNullOrEmpty(Data.UserName))
                    return null;
                else
                    return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
