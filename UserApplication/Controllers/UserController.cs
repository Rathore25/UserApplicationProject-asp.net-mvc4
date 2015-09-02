using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace UserApplication.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                List<UserModel> UserData = new List<UserModel>();
                try
                {
                    HttpWebRequest HttpRequest = (HttpWebRequest)WebRequest.Create("http://localhost:50676/UserTableService.svc/Users");
                    HttpRequest.Method = "GET";
                    string UserDataResponse = string.Empty;
                    using (WebResponse Response = HttpRequest.GetResponse())
                    {
                        using (Stream DataStream = Response.GetResponseStream())
                        {
                            using (StreamReader Reader = new StreamReader(DataStream))
                            {
                                UserDataResponse = Reader.ReadToEnd();
                            }
                        }
                    }
                    UserData = JsonConvert.DeserializeObject<List<UserModel>>(UserDataResponse);
                }
                catch (Exception ex)
                {
                    //_log.Error("Exception in Index :" + ex);
                    throw ex;
                }
                finally
                {
                    //_log.Debug("Index Exited");
                }
                return View(UserData);
            }
            else
                return RedirectToAction("Login","Home");
        }
    }
}
