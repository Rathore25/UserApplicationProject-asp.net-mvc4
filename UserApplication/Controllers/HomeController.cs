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
        [ValidateInput(false)]
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
            ViewBag.ErrorMessage = null;
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
                
                var Data = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest(url+"AccountService.svc/Login", "POST", JsonConvert.SerializeObject(loginData))) as JToken;
                AccountData = JsonConvert.DeserializeObject<RegisterModel>(Data["LoginResult"].ToString());

                if (!string.IsNullOrEmpty(AccountData.UserName))
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
                {
                    
                    ViewBag.ErrorMessage = "Wrong Username or Password";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorPage","Home", new { ex=ex.Message });
            }

        } 
        #endregion


        public ActionResult ForgotPassword()
        {
            ViewBag.Password = string.Empty;
            ViewBag.ErrorMessage = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(RegisterModel model)
        {
            string Password=string.Empty;
            RegisterModel AccountData = null;
            var userData = model;

            var Data = JsonConvert.DeserializeObject(Utilities.HttpRequest.GetHttpRequest(url + "AccountService.svc/Retrieve", "POST", JsonConvert.SerializeObject(userData))) as JToken;
            AccountData = JsonConvert.DeserializeObject<RegisterModel>(Data["RetrievePasswordResult"].ToString());
            if (string.IsNullOrEmpty(AccountData.Password))
            {
                ViewBag.ErrorMessage = "Wrong Username or Email ID";
                ViewBag.Password = string.Empty;
            }
            else
            {
                ViewBag.ErrorMessage = string.Empty;
                ViewBag.Password ="Your password is : "+ AccountData.Password;
            }
            return View();
        }





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
