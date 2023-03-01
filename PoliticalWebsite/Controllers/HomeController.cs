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
        public ActionResult Index(Home model)
        {
            List<Home> lst = new List<Home>();
            DataSet ds = model.GalleryimageList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_GalleryId = r["Pk_GalleryId"].ToString();
                    obj.GalleryImage = r["GalleryImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    lst.Add(obj);
                }
                model.lstgallery = lst;
            }

            List<Home> lst1 = new List<Home>();
            DataSet ds1 = model.EventimageList();

            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_EventId = r["Pk_EventId"].ToString();
                    obj.EventImage = r["EventImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    obj.Date = r["Date"].ToString();
                    obj.City = r["City"].ToString();
                    obj.Town_Village = r["Town_Village"].ToString();
                    lst1.Add(obj);
                }
                model.lstevent = lst1;
            }

            List<Home> lst2 = new List<Home>();
            DataSet ds2 = model.NewsimageList();

            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds2.Tables[0].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_NewsId = r["Pk_NewsId"].ToString();
                    obj.NewsImage = r["NewsImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    obj.Message = r["Message"].ToString();
                    obj.Date = r["Date"].ToString();
                    obj.Year = r["Year"].ToString();
                    lst2.Add(obj);
                }
                model.lstNews = lst2;
            }
            return View(model);
        }

        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
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


        public ActionResult About(Home model)
        {
            List<Home> lst = new List<Home>();
            DataSet ds = model.NewsimageList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_NewsId = r["Pk_NewsId"].ToString();
                    obj.NewsImage = r["NewsImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    obj.Message = r["Message"].ToString();
                    obj.Date = r["Date"].ToString();
                    obj.Year = r["Year"].ToString();
                    lst.Add(obj);
                }
                model.lstNews = lst;
            }
            return View(model);
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
                        TempData["Contact"] = "आपका संपर्क विवरण सफलतापूर्वक सहेज लिया गया है !!";
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

        public ActionResult Events(Home model)
        {
            List<Home> lst = new List<Home>();
            DataSet ds = model.EventimageList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_EventId = r["Pk_EventId"].ToString();
                    obj.EventImage = r["EventImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    obj.Date = r["Date"].ToString();
                    obj.City = r["City"].ToString();
                    obj.Town_Village = r["Town_Village"].ToString();
                    lst.Add(obj);
                }
                model.lstevent = lst;
            }
            return View(model);
        }

        public ActionResult Gallery(Home model)
        {
            List<Home> lst = new List<Home>();
            DataSet ds = model.GalleryimageList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_GalleryId = r["Pk_GalleryId"].ToString();
                    obj.GalleryImage = r["GalleryImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    lst.Add(obj);
                }
                model.lstgallery = lst;
            }
            return View(model);
        }

        public ActionResult NewsPressRelease(Home model)
        {
            List<Home> lst = new List<Home>();
            DataSet ds = model.NewsimageList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_NewsId = r["Pk_NewsId"].ToString();
                    obj.NewsImage = r["NewsImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    obj.Message = r["Message"].ToString();
                    obj.Date = r["Date"].ToString();
                    lst.Add(obj);
                }
                model.lstNews = lst;
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[1].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_NewsId = r["Pk_NewsId"].ToString();
                    ViewBag.TopMainNewsImage = r["NewsImage"].ToString();
                    ViewBag.TopMainDiscription = r["Discription"].ToString();
                    ViewBag.TopMessage = r["Message"].ToString();
                    ViewBag.TopDate = r["Date"].ToString();
                    ViewBag.Month = r["Month"].ToString();
                    ViewBag.Day = r["Day"].ToString();
                    lst.Add(obj);
                }
                model.lstNews = lst;
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[2].Rows)
                {
                    Home obj = new Home();
                    obj.Pk_NewsId = r["Pk_NewsId"].ToString();
                    ViewBag.MainNewsImage = r["NewsImage"].ToString();
                    ViewBag.MainDiscription = r["Discription"].ToString();
                    ViewBag.MainMessage = r["Message"].ToString();
                    ViewBag.MainDate = r["Date"].ToString();
                    ViewBag.MainMonth = r["Month"].ToString();
                    ViewBag.MainDay = r["Day"].ToString();
                    lst.Add(obj);
                }
                model.lstNews = lst;
            }
            return View(model);
        }
    }
}