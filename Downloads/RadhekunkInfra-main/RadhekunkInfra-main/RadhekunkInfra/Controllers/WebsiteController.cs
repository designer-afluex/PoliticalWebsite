using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RadhekunkInfra.Models;
using RadhekunkInfra.Filter;
using System.Data;

namespace RadhekunkInfra.Controllers
{
    public class WebsiteController : Controller
    {
         //GET: Website
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompanyProfile()
        {
            return View();
        }

        public ActionResult OurMission()
        {
            return View();
        }


        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Residential()
        {
            return View();
        }

        public ActionResult Availibility()
        {
            return View();
        }

        public ActionResult Layout()
        {
            return View();
        }

        public ActionResult Trip()
        {
            return View();
        }

        public ActionResult Winner()
        {
            return View();
        }

        public ActionResult EventGallery()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        [ActionName("ContactUs")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult ContactUs(Website model)
        {
            try
            {
                DataSet ds = model.SaveContact();
                if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    if(ds.Tables[0].Rows[0]["MSG"].ToString()=="1")
                    {
                        TempData["Contactmsg"] = "Details saved successfully !";
                    }
                    else if(ds.Tables[0].Rows[0]["MSG"].ToString() == "0")
                    {
                        TempData["Contactmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                    else
                    {
                        TempData["Contactmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Contactmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch(Exception ex)
            {
                TempData["Contactmsg"] = ex.Message;
            }
            return RedirectToAction("ContactUs", "Website");
        }


        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Signin()
        {
            return View();
        }   
        public ActionResult Plot()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult CancellationPolicy()
        {
            return View();
        }
        public ActionResult RequestForm()
        {
            return View();
        }
    }
}