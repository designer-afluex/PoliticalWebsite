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
            }
            catch (Exception ex)
            {
                TempData["Dashboard"] = ex.Message;
            }
            return View();
        }

    }
}