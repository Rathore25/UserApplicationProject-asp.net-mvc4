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
using Newtonsoft.Json.Linq;
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
                var accountData = model ;
                var Data = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest("http://localhost:51091/AccountService.svc/Register", "POST", JsonConvert.SerializeObject(accountData))) as JToken;
                string ResponseData = JsonConvert.DeserializeObject<string>(Data["RegisterResult"].ToString());
                if (ResponseData.Equals("Success"))
                {
                    return RedirectToAction("Login", "Home");
                }
                else
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
                var loginData = model;
                var Data=JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest("http://localhost:51091/AccountService.svc/Login","POST",JsonConvert.SerializeObject(loginData))) as JToken;
                RegisterModel AccountData=JsonConvert.DeserializeObject<RegisterModel>(Data["LoginResult"].ToString());
                
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
