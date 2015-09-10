using MySql.Data.MySqlClient;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System;
using System.Web;

namespace DataAccessLayer
{
    public class Accounts
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString;

        public static void RegisterData(DataObject.RegisterDataObject accountData)
        {
            MySqlConnection Connection = new MySqlConnection(ConnString);
            try
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
                if (InsertCommand.ExecuteNonQuery() == 0)
                    throw new Exception("No person was registered");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(Connection.State== ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
        }

        public static DataObject.RegisterDataObject ValidateData(DataObject.LoginDataObject loginData)
        {
            MySqlConnection Connection = new MySqlConnection(ConnString);
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
        }

        public static DataObject.RegisterDataObject RetrievePassword(DataObject.RegisterDataObject userData)
        {
            MySqlConnection Connection = new MySqlConnection(ConnString);
            try
            {
                Connection.Open();
                DataObject.RegisterDataObject Password = new DataObject.RegisterDataObject();
                MySqlCommand RetrieveCommand = new MySqlCommand("udsp_account_retrieve", Connection);
                RetrieveCommand.CommandType = CommandType.StoredProcedure;
                Guid GuidId = Guid.NewGuid();
                RetrieveCommand.Parameters.AddWithValue("var_Username", userData.UserName);
                RetrieveCommand.Parameters.AddWithValue("var_EmailId", userData.EmailId);
                MySqlDataReader Reader = RetrieveCommand.ExecuteReader();

                while (Reader.Read())
                {
                    Password.AutoId = string.Empty;
                    Password.Guid = string.Empty;
                    Password.UserName = string.Empty;
                    Password.Password = Reader["Password"].ToString();
                    Password.FullName = string.Empty;
                    Password.EmailId = string.Empty;
                }
                return Password;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
        }
    }
}
