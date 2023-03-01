using PoliticalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliticalWebsite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
         public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminDashboard()
        {
            Admin newdata = new Admin();
            try
            {
                DataSet Ds = newdata.GetDetails();
                ViewBag.GalleryImage = Ds.Tables[0].Rows[0]["GalleryImage"].ToString();
                ViewBag.NewsImage = Ds.Tables[0].Rows[0]["NewsImage"].ToString();
                ViewBag.EventImage = Ds.Tables[0].Rows[0]["EventImage"].ToString();
                ViewBag.Contact = Ds.Tables[0].Rows[0]["Contact"].ToString();
            }
            catch (Exception ex)
            {
                TempData["Dashboard"] = ex.Message;
            }
            return View();
        }

        public ActionResult ContactDetails(Admin model)
        {
            List<Admin> lst = new List<Admin>();
            DataSet ds = model.ContactDetails();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Admin obj = new Admin();
                    obj.Pk_ContactId = r["Pk_ContactId"].ToString();
                    obj.Name = r["Name"].ToString();
                    obj.Email = r["Email"].ToString();
                    obj.Mobile = r["Mobile"].ToString();
                    obj.Subject = r["Subject"].ToString();
                    obj.Message = r["Message"].ToString();
                    obj.Date = r["Date"].ToString();
                    lst.Add(obj);
                }
                model.lstcontact = lst;
            }
            return View(model);
        }
    }
}