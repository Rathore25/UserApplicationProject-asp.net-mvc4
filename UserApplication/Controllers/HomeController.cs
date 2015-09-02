using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Web.Security;
using log4net;

namespace UserApplication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(HomeController).Name);

        #region Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            try
            {
                string URL = "http://localhost:51091/AccountService.svc/Register";
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
                Request.Method = "POST";
                var RequestData = new { accountData = model };
                string ResponseData = string.Empty;
                string x = JsonConvert.SerializeObject(RequestData);
                using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                {
                    Writer.Write(JsonConvert.SerializeObject(RequestData));
                }
                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                {
                    using (Stream DataStream = Response.GetResponseStream())
                    {
                        using (StreamReader Reader = new StreamReader(DataStream))
                        {
                            ResponseData = JsonConvert.DeserializeObject<string>(Reader.ReadToEnd());
                            if (ResponseData.Equals("Success"))
                            {
                                RedirectToAction("Login", "Home");
                            }
                        }
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                string URL = "http://localhost:51091/AccountService.svc/Login";
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
                Request.Method = "POST";
                var RequestData = new { loginData = model };

                
                using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                {
                    Writer.Write(JsonConvert.SerializeObject(RequestData));
                }
                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                {
                    using (Stream DataStream = Response.GetResponseStream())
                    {
                        using (StreamReader Reader = new StreamReader(DataStream))
                        {
                            RegisterModel AccountData = JsonConvert.DeserializeObject<RegisterModel>(Reader.ReadToEnd());

                            if (AccountData != null)
                            {

                                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(
                                        1,
                                        AccountData.UserName,
                                        DateTime.Now,
                                        DateTime.Now.AddMinutes(5),
                                        false,
                                        JsonConvert.SerializeObject(AccountData, Formatting.Indented),
                                        FormsAuthentication.FormsCookiePath);
                                string EncTicket = FormsAuthentication.Encrypt(Ticket);
                                HttpCookie Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncTicket);
                                if (Ticket.IsPersistent)
                                {
                                    Cookie.Expires = Ticket.Expiration;
                                }
                                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);

                                return RedirectToAction("Index", "User");
                            }
                            else
                                return View();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        } 
        #endregion

        #region Logout
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","User");
        } 
        #endregion

    }
}
