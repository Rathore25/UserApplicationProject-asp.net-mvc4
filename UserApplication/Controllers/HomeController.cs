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
        private static string url = System.Configuration.ConfigurationManager.AppSettings["LocalHost"];
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
                var Data = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest(url + "AccountService.svc/Register", "POST", JsonConvert.SerializeObject(accountData))) as JToken;
                string ResponseData = Data["RegisterResult"].ToString();
                if (ResponseData.Equals("Success"))
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorPage", "Home", new { ex = ex.Message });
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
                RegisterModel AccountData = null;
                var loginData = model;
                if (!string.IsNullOrEmpty(loginData.UserName) && !string.IsNullOrEmpty(loginData.Password))
                {
                    var Data = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest(url+"AccountService.svc/Login", "POST", JsonConvert.SerializeObject(loginData))) as JToken;
                    AccountData = JsonConvert.DeserializeObject<RegisterModel>(Data["LoginResult"].ToString());
                }
                else
                    throw new Exception("Wrong Username or password");
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
                return RedirectToAction("ErrorPage","Home", new { ex=ex.Message });
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

        [AllowAnonymous]
        public ActionResult ErrorPage(string ex)
        {
            ViewBag.ErrorMessage = ex;
            return View();
        }
    }
}
