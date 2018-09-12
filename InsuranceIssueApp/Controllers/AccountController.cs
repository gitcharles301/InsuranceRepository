using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceIssueApp.Model;
using System.Web.Security;
using System.Security.Principal;
using InsuranceIssueApp.BLL;
using InsuranceIssueApp.Common;

namespace InsuranceIssueApp.Controllers
{
    
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                IUserManager userManager = new UserManager();
                if (userManager.checkLogin(model.LoginID, CryptoEncryption.EncodePassword(model.Password)))
                {
                    User userdetail = userManager.GetUserDetail(model.LoginID);
                    Session["UserName"] = userdetail.FirstName + ' ' + userdetail.LastName;
                    Session["UserId"] = userdetail.UserId;
                    Session["RoleId"] = userdetail.RoleId;
                    FormsAuthentication.SetAuthCookie("Username", false);
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]       
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                return RedirectToAction("Login", "Account");
            }
            catch
            {
                throw;
            }
        }


        //GET: RedirectToLocal
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site
                // so we will redirect to this "action"
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);

                // If we cannot verify if the url is local to our host we redirect to a default location
                return RedirectToAction("Dashboard", "Home");
            }
            catch
            {
                throw;
            }
        }
    }
}