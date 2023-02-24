using PoliticalWebsite.Filter;
using PoliticalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliticalWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            //Session.Abandon();
            return View();
        }

        public ActionResult LoginAction(Home obj)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Home Modal = new Home();
                DataSet ds = obj.Login();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        if (ds.Tables[0].Rows[0]["UserType"].ToString() == "Admin")
                        {
                            Session["Pk_adminId"] = ds.Tables[0].Rows[0]["Pk_adminId"].ToString();
                            Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                            Session["UsertypeName"] = ds.Tables[0].Rows[0]["UsertypeName"].ToString();
                            Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();

                            FormName = "AdminDashboard";
                            Controller = "Admin";
                        }
                        else
                        {
                            TempData["Login"] = "Incorrect LoginId Or Password";
                            FormName = "Login";
                            Controller = "Home";
                        }
                    }
                    else
                    {
                        TempData["Login"] = "Incorrect LoginId Or Password";
                        FormName = "Login";
                        Controller = "Home";

                    }
                }
                else
                {
                    TempData["Login"] = "Incorrect LoginId Or Password";
                    FormName = "Login";
                    Controller = "Home";
                }
            }
            catch (Exception ex)
            {
                TempData["Login"] = ex.Message;
                FormName = "Login";
                Controller = "Home";
            }
            return RedirectToAction(FormName, Controller);
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Contact")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult ContactUs(Home obj)
        {
            try
            {
                obj.AddedBy = "1";
                DataSet ds = obj.SaveContactUs();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Contact"] = "Contact Details Saved Successfully !!";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["Contact"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Contact"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["Contact"] = ex.Message;
            }
            return RedirectToAction("Contact", "Home");
        }

        public ActionResult Events()
        {
            return View(); 
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult NewsPressRelease()
        {
            return View();
        }
    }
}