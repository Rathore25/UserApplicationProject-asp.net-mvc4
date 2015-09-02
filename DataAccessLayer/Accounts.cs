using MySql.Data.MySqlClient;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System;

namespace DataAccessLayer
{
    public class Accounts
    {
        private static string ConnString = "server=localhost;User Id=root;password=admin;persistsecurityinfo=True;database=userdataschema";

        public static void RegisterData(DataObject.RegisterDataObject accountData)
        {
            try
            {
                using (MySqlConnection Connection = new MySqlConnection(ConnString))
                {
                    Connection.Open();
                    MySqlCommand InsertCommand = new MySqlCommand("udsp_account_register", Connection);
                    InsertCommand.CommandType = CommandType.StoredProcedure;
                    Guid GuidId = Guid.NewGuid();
                    InsertCommand.Parameters.AddWithValue("var_Guid", GuidId.ToString());
                    InsertCommand.Parameters.AddWithValue("var_Username", accountData.UserName);
                    InsertCommand.Parameters.AddWithValue("var_Password", accountData.Password);
                    InsertCommand.Parameters.AddWithValue("var_FullName", accountData.FullName);
                    InsertCommand.Parameters.AddWithValue("var_EmailId", accountData.EmailId);
                    InsertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataObject.RegisterDataObject ValidateData(DataObject.LoginDataObject loginData)
        {
            try
            {
                using (MySqlConnection Connection = new MySqlConnection(ConnString))
                {
                    Connection.Open();
                    DataObject.RegisterDataObject AccountData = new DataObject.RegisterDataObject();
                    MySqlCommand ValidateCommand = new MySqlCommand("udsp_account_validate", Connection);
                    ValidateCommand.CommandType = CommandType.StoredProcedure;
                    Guid GuidId = Guid.NewGuid();
                    ValidateCommand.Parameters.AddWithValue("var_Username", loginData.UserName);
                    ValidateCommand.Parameters.AddWithValue("var_Password", loginData.Password);
                    MySqlDataReader Reader = ValidateCommand.ExecuteReader();

                    while (Reader.Read())
                    {
                        AccountData.AutoId = Reader["AutoId"].ToString();
                        AccountData.Guid = Reader["Guid"].ToString();
                        AccountData.UserName = Reader["Username"].ToString();
                        AccountData.Password = Reader["Password"].ToString();
                        AccountData.FullName = Reader["FullName"].ToString();
                        AccountData.EmailId = Reader["EmailId"].ToString();
                    }
                    return AccountData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            
        }
    }
}
