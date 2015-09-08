using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using log4net;
using MySql.Data.MySqlClient;
using System.Data;
using DataObject;
using System.Configuration;
namespace DataAccessLayer
{

    public class Users
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Users));

        private static string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString;

        #region CreateRow
        public static void EnterRow(DataObject.UserDataObject UserData)
        {
            _log.Debug("DatabaseConnectionProvider.EnterRow entered");
            _log.Debug("Parameter jsonStringUserData: " + UserData);
            MySqlConnection Connection = new MySqlConnection(ConnString);

            try
            {
                Connection.Open();
                MySqlCommand InsertCommand = new MySqlCommand("udsp_userdataschema_create", Connection);
                InsertCommand.CommandType = CommandType.StoredProcedure;
                //InsertCommand.CommandText = "INSERT INTO usertable(uid,name,dob,city,phone,emailid) VALUES(@uid,@list0,@list1,@list2,@list3,@list4)";
                Guid GuidId = Guid.NewGuid();
                InsertCommand.Parameters.AddWithValue("var_uid", GuidId.ToString());
                InsertCommand.Parameters.AddWithValue("var_name", UserData.Name);
                InsertCommand.Parameters.AddWithValue("var_dob", UserData.Dob);
                InsertCommand.Parameters.AddWithValue("var_city", UserData.City);
                InsertCommand.Parameters.AddWithValue("var_phone", UserData.PhoneNumber);
                InsertCommand.Parameters.AddWithValue("var_emailid", UserData.EmailId);
                if (InsertCommand.ExecuteNonQuery() == 0)
                    throw new Exception("No row was Inserted");
            }
            catch (Exception exception)
            {
                _log.Error("Error in EnterRow " + exception.Message);
                throw exception;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
                _log.Debug("DatabaseConnectionProvider.EnterRow exited");
            }

        }
        #endregion

        #region RetrieveAllRows
        public static List<UserDataObject> AllUser()
        {
            _log.Debug("DatabaseConnectionProvider.AllUser entered");
            MySqlConnection Connection = new MySqlConnection(ConnString);
            try
            {
                Connection.Open();
                MySqlCommand SelectCommand = new MySqlCommand("udsp_userdataschema_retrieve", Connection);
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.AddWithValue("var_uid", string.Empty);
                List<UserDataObject> UserData = new List<UserDataObject>();
                using (MySqlDataReader Reader = SelectCommand.ExecuteReader())
                {

                    while (Reader.Read())
                    {
                        UserDataObject RowData = new UserDataObject();
                        RowData.AutoId = Reader["autoid"].ToString();
                        RowData.Uid = Reader["uid"].ToString();
                        RowData.Name = Reader["name"].ToString();
                        RowData.Dob = Convert.ToDateTime(Reader["dob"]);
                        RowData.City = Reader["city"].ToString();
                        RowData.PhoneNumber = Reader["phone"].ToString();
                        RowData.EmailId = Reader["emailid"].ToString();
                        UserData.Add(RowData);
                    }
                }
                _log.Debug("Result:= " + JsonConvert.SerializeObject(UserData, Formatting.Indented));
                return UserData;

            }
            catch (MySqlException exception)
            {
                _log.Error("MySqlException in AllUser :" + exception);
                throw exception;
            }
            catch (Exception exception)
            {
                _log.Error("Error in AllUser :" + exception);
                throw exception;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
                _log.Debug("DatabaseConnectionProvider.AllUser exited");
            }
        }
        #endregion

        #region UpdateRow
        #region SpecificRowData
        public static DataObject.UserDataObject SpecificRowData(string uid)
        {
            _log.Debug("DatabaseConnectionProvider.SpecificRowData entered");
            _log.Debug("Parameter autoId : " + uid);
            MySqlConnection Connection = new MySqlConnection(ConnString);

            try
            {
                Connection.Open();

                MySqlCommand SpecificUserCommand = new MySqlCommand("udsp_userdataschema_retrieve", Connection);
                SpecificUserCommand.CommandType = CommandType.StoredProcedure;
                SpecificUserCommand.Parameters.AddWithValue("var_uid", uid);
                MySqlDataReader Reader = SpecificUserCommand.ExecuteReader();

                DataObject.UserDataObject UserRow = new DataObject.UserDataObject();
                while (Reader.Read())
                {
                    UserRow.AutoId = (Reader["autoid"].ToString());
                    UserRow.Uid = (Reader["uid"].ToString());
                    UserRow.Name = (Reader["name"].ToString());
                    UserRow.Dob = (Convert.ToDateTime(Reader["dob"]));
                    UserRow.City = (Reader["city"].ToString());
                    UserRow.PhoneNumber = (Reader["phone"].ToString());
                    UserRow.EmailId = (Reader["emailid"].ToString());
                }
                _log.Debug("Result :=" + JsonConvert.SerializeObject(UserRow, Formatting.Indented));
                return UserRow;
            }
            catch (Exception exception)
            {
                _log.Error("Error in SpecificRowData :" + exception.Message);
                throw exception;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
                _log.Debug("DatabaseConnectionProvider.SpecificRowData exited");
            }

        }
        #endregion

        #region EditRow
        public static void EditRow(DataObject.UserDataObject RowData)
        {
            _log.Debug("DatabaseConnectionProvider.EditRow entered");
            _log.Debug("parameter 1 =" + RowData);
            MySqlConnection Connection = new MySqlConnection(ConnString);

            try
            {
                Connection.Open();
                MySqlCommand UpdateCommand = new MySqlCommand("udsp_userdataschema_update", Connection);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                UpdateCommand.Parameters.AddWithValue("var_uid", RowData.Uid);
                UpdateCommand.Parameters.AddWithValue("var_name", RowData.Name);
                UpdateCommand.Parameters.AddWithValue("var_dob", RowData.Dob);
                UpdateCommand.Parameters.AddWithValue("var_city", RowData.City);
                UpdateCommand.Parameters.AddWithValue("var_phone", RowData.PhoneNumber);
                UpdateCommand.Parameters.AddWithValue("var_emailid", RowData.EmailId);
                if (UpdateCommand.ExecuteNonQuery() == 0)
                    throw new Exception("No row was updated");
            }
            catch (Exception exception)
            {
                _log.Error("Error in EditRow :" + exception.Message);
                throw exception;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
                _log.Debug("DatabaseConnectionProvider.EditRow exited");
            }

        }
        #endregion
        #endregion

        #region DeleteRow
        public static void DeleteRow(string uid)
        {
            _log.Debug("DatabaseConnectionProvider.DeleteRow entered");
            _log.Debug("parameter uid =" + uid);
            MySqlConnection Connection = new MySqlConnection(ConnString);
            try
            {
                Connection.Open();
                MySqlCommand DeleteCommand = new MySqlCommand("udsp_userdataschema_delete", Connection);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                DeleteCommand.Parameters.AddWithValue("var_uid", uid);

                if (DeleteCommand.ExecuteNonQuery() == 0)
                    throw new Exception("No user with such id in database");

            }
            catch (Exception exception)
            {
                _log.Error("Error in DeleteRow :" + exception.Message);
                throw exception;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
                _log.Debug("DatabaseConnectionProvider.DeleteRow exited");
            }

        }
        #endregion
    }
}
