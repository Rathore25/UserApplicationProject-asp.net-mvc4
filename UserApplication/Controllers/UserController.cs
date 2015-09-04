using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using log4net;
using Newtonsoft.Json.Linq;

namespace UserApplication.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private static string url = System.Configuration.ConfigurationManager.AppSettings["LocalHost"];
        private static readonly ILog _log = LogManager.GetLogger(typeof(UserController));

        #region Create
        public ActionResult Create()
        {
            _log.Debug("Create Entered");
            _log.Debug("Create Exited");
            return View(new UserModel());
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            _log.Debug("Create Entered");
            _log.Debug("Parameter : Model");

            UserModel UserData = new UserModel();
            if (ModelState.IsValid)
            {
                var DateofBirth = Convert.ToDateTime(model.Dob);
                JsonSerializerSettings DateFormat = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };

                UserData.Name = (model.Name ?? string.Empty);
                UserData.Dob = (DateofBirth);
                UserData.City = (model.City ?? string.Empty);
                UserData.PhoneNumber = (model.PhoneNumber ?? string.Empty);
                UserData.EmailId = (model.EmailId ?? string.Empty);

                try
                {
                    string Result = string.Empty;
                    var Data =JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest(url+"UserService.svc/Add", "POST", JsonConvert.SerializeObject(UserData, DateFormat))) as JToken;
                    if (Data != null)
                    {
                        Result = Data["AddUserResult"].ToString();
                    }
                    _log.Debug("ADD USER RESPONSE" + Result);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View(model);
            }
        }
        #endregion

        #region Retrieve
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                List<UserModel> UserData = null ;
                try
                {
                    var UserDataResponse = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest(url + "UserService.svc/Users", "GET", string.Empty)) as JToken;
                    if (UserDataResponse!=null)
                    {
                        UserData = JsonConvert.DeserializeObject<List<UserModel>>(UserDataResponse["RetrieveAllUsersResult"].ToString()); 
                    }
                }
                catch (Exception ex)
                {
                    _log.Error("Exception in Index :" + ex);
                    return RedirectToAction("ErrorPage", "Home", new { ex = ex.Message });
                }
                finally
                {
                    _log.Debug("Index Exited");
                    
                }
                return View(UserData??new List<UserModel>());
            }
            else
                return RedirectToAction("Login", "Home");
        }
        #endregion

        #region Update
        public ActionResult Edit(string id)
        {
            _log.Debug("Edit Entered");
            _log.Debug("paramater string uid:= " + id);
            UserModel Model = null;
            try
            {
                var userId = id ;
                var UserDataResponse = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest("http://localhost:51091/UserService.svc/User", "POST", JsonConvert.SerializeObject(userId, Formatting.Indented))) as JToken;

                if (UserDataResponse!=null)
                {
                    Model = JsonConvert.DeserializeObject<UserModel>(UserDataResponse["RetrieveUserResult"].ToString()); 
                }
            }
            catch (Exception ex)
            {
                _log.Error("Error in Populating the Edit page with previous data : " + ex);
                return RedirectToAction("ErrorPage", "Home", new { ex = ex.Message });
            }
            finally
            {
                _log.Debug("Edit Exited");
            }
            return View(Model??new UserModel());
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            _log.Debug("Edit Entered : HttpPost");
            _log.Debug("Paramater UserModel model:= " + JsonConvert.SerializeObject(model));
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel UserData = new UserModel();
                    var DateofBirth = Convert.ToDateTime(model.Dob);

                    JsonSerializerSettings DateFormat = new JsonSerializerSettings
                    {
                        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                    };

                    UserData.Uid = model.Uid;
                    UserData.Name = (model.Name ?? string.Empty);
                    UserData.Dob = (DateofBirth);
                    UserData.City = (model.City ?? string.Empty);
                    UserData.PhoneNumber = (model.PhoneNumber ?? string.Empty);
                    UserData.EmailId = (model.EmailId ?? string.Empty);
                    string Result=string.Empty;
                    var Data = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest(url + "UserService.svc/Update", "POST", JsonConvert.SerializeObject(UserData, DateFormat))) as JToken;
                    if (Data != null)
                    {
                         Result = Data["UpdateUserResult"].ToString();
                    }
                    _log.Debug("Edit User result=" + Result);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Error in Updating the table : " + ex);
                return RedirectToAction("ErrorPage", "Home", new { ex = ex.Message });
            }
            finally
            {
                _log.Debug("Edit Exited");
            }
            return RedirectToAction("Index", "User");
        }
        #endregion

        #region Delete
        public ActionResult Delete(string uid)
        {
            _log.Debug("Delete entered");
            _log.Debug("Parameter id :" + uid);
            try
            {
                string Result=string.Empty;
                var Data = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest(url + "UserService.svc/Delete", "POST", JsonConvert.SerializeObject(uid))) as JToken;
                if (Data != null)
                {
                    Result = Data["DeleteUserResult"].ToString();
                }
                _log.Debug("Result :="+Result);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorPage", "Home", new { ex = ex.Message });
            }
            finally
            {
                _log.Debug("Delete exited");
            }
            return RedirectToAction("Index", "User");
        }
        #endregion
    }
}
