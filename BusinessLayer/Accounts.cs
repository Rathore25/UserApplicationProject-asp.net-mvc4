using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Accounts
    {
        public static void Register(DataObject.RegisterDataObject accountData)
        {
            try 
            {
                DataAccessLayer.Accounts.RegisterData(accountData);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static DataObject.RegisterDataObject Validate(DataObject.LoginDataObject loginData)
        {
            try
            {
                return DataAccessLayer.Accounts.ValidateData(loginData);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
