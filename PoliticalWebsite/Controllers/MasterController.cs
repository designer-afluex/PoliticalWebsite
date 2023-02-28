using PoliticalWebsite.Filter;
using PoliticalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliticalWebsite.Controllers
{
    public class MasterController : AdminBaseController
    {
        // GET: Master

        #region SliderBannerMaster

        public ActionResult AddSliderBanner(string Id)
        {
            if (Id != null)
            {
                Master obj = new Master();
                try
                {
                    obj.SliderBannerID = Id;

                    DataSet ds = obj.SliderBannerList();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_SliderBannerId = ds.Tables[0].Rows[0]["Pk_SliderBannerId"].ToString();
                        obj.SliderBannerImage = ds.Tables[0].Rows[0]["SliderBannerImage"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.Message;
                }
                return View(obj);
            }
            else
            {
                return View();
            }
            return View();
        }


        [HttpPost]
        [ActionName("AddSliderBanner")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveSliderBannerAction(HttpPostedFileBase SliderBanner)
        {
            Master obj = new Master();
            try
            {
                if (SliderBanner != null)
                {
                    obj.SliderBanner = "../BannerImages/" + Guid.NewGuid() + Path.GetExtension(SliderBanner.FileName);
                    SliderBanner.SaveAs(Path.Combine(Server.MapPath(obj.SliderBanner)));
                }
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.SaveSliderBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Slider Banner saved successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddSliderBanner", "Master");
        }

        public ActionResult SliderBannerList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.SliderBannerList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Pk_SliderBannerId = r["Pk_SliderBannerId"].ToString();
                    obj.SliderBannerImage = r["SliderBannerImage"].ToString();
                    lst.Add(obj);
                }
                model.lstSliderBanner = lst;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("AddSliderBanner")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateSliderBannerAction(string Pk_SliderBannerId, HttpPostedFileBase SliderBanner)
        {
            Master obj = new Master();
            try
            {
                obj.SliderBannerID = Pk_SliderBannerId;
                if (SliderBanner != null)
                {
                    obj.SliderBanner = "../BannerImages/" + Guid.NewGuid() + Path.GetExtension(SliderBanner.FileName);
                    SliderBanner.SaveAs(Path.Combine(Server.MapPath(obj.SliderBanner)));
                }
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.UpdateSliderBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Slider Banner updated successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddSliderBanner", "Master");
        }



        public ActionResult DeleteSliderBanner(string Id)
        {
            try
            {
                Master obj = new Master();
                obj.SliderBannerID = Id;
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.DeleteSliderBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Slider Banner deleted successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("SliderBannerList", "Master");
        }
        #endregion


        #region GalleryMaster

        public ActionResult AddGallery(string Id)
        {
            if (Id != null)
            {
                Master obj = new Master();
                try
                {
                    obj.GalleryID = Id;

                    DataSet ds = obj.GalleryimageList();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_GalleryId = ds.Tables[0].Rows[0]["Pk_GalleryId"].ToString();
                        obj.GalleryImage = ds.Tables[0].Rows[0]["GalleryImage"].ToString();
                        obj.Discription = ds.Tables[0].Rows[0]["Discription"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    TempData["Gallery"] = ex.Message;
                }
                return View(obj);
            }
            else
            {
                return View();
            }
            return View();
        }


        [HttpPost]
        [ActionName("AddGallery")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveGalleryAction(HttpPostedFileBase Gallery, string Discription)
        {
            Master obj = new Master();
            try
            {
                if (Gallery != null)
                {
                    obj.Gallery = "../BannerImages/" + Guid.NewGuid() + Path.GetExtension(Gallery.FileName);
                    Gallery.SaveAs(Path.Combine(Server.MapPath(obj.Gallery)));
                }
                obj.Discription = Discription;
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.SaveGalleryBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Gallery Banner saved successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddGallery", "Master");
        }

        public ActionResult GalleryimageList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GalleryimageList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Pk_GalleryId = r["Pk_GalleryId"].ToString();
                    obj.GalleryImage = r["GalleryImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    lst.Add(obj);
                }
                model.lstgallery = lst;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("AddGallery")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateGalleryAction(string Pk_GalleryId, HttpPostedFileBase Gallery, string Discription)
        {
            Master obj = new Master();
            try
            {
                obj.GalleryID = Pk_GalleryId;
                if (Gallery != null)
                {
                    obj.Gallery = "../BannerImages/" + Guid.NewGuid() + Path.GetExtension(Gallery.FileName);
                    Gallery.SaveAs(Path.Combine(Server.MapPath(obj.Gallery)));
                }
                obj.Discription = Discription;
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.UpdateGalleryBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Gallery Banner updated successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddGallery", "Master");
        }



        public ActionResult DeleteGalleryBanner(string Id)
        {
            try
            {
                Master obj = new Master();
                obj.GalleryID = Id;
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.DeleteGalleryBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Gallery Banner deleted successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("GalleryimageList", "Master");
        }
        #endregion

        #region EventMaster

        public ActionResult AddEvent(string Id)
        {
            if (Id != null)
            {
                Master obj = new Master();
                try
                {
                    obj.EventID = Id;

                    DataSet ds = obj.EventimageList();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_EventId = ds.Tables[0].Rows[0]["Pk_EventId"].ToString();
                        obj.EventImage = ds.Tables[0].Rows[0]["EventImage"].ToString();
                        obj.Discription = ds.Tables[0].Rows[0]["Discription"].ToString();
                        obj.Date = ds.Tables[0].Rows[0]["Date"].ToString();
                        obj.Town_Village = ds.Tables[0].Rows[0]["Town_Village"].ToString();
                        obj.City = ds.Tables[0].Rows[0]["City"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    TempData["Event"] = ex.Message;
                }
                return View(obj);
            }
            else
            {
                return View();
            }
            return View();
        }


        [HttpPost]
        [ActionName("AddEvent")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveEventAction(HttpPostedFileBase Event, string Discription,string City,string Town_Village, string Date)
        {
            Master obj = new Master();
            try
            {
                if (Event != null)
                {
                    obj.Event = "../BannerImages/" + Guid.NewGuid() + Path.GetExtension(Event.FileName);
                    Event.SaveAs(Path.Combine(Server.MapPath(obj.Event)));
                }
                obj.Discription = Discription;
                obj.City = City;
                obj.Town_Village = Town_Village;
                obj.Date = Date;
                //obj.Date = string.IsNullOrEmpty(obj.Date) ? null : Common.ConvertToSystemDate(obj.Date, "dd/MM/yyyy");
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.SaveEventBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Event Banner saved successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddEvent", "Master");
        }

        public ActionResult EventimageList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.EventimageList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
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

        [HttpPost]
        [ActionName("AddEvent")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateEventAction(string Pk_EventId, HttpPostedFileBase Event, string Discription, string City, string Town_Village, string Date)
        {
            Master obj = new Master();
            try
            {
                obj.EventID = Pk_EventId;
                if (Event != null)
                {
                    obj.Event = "../BannerImages/" + Guid.NewGuid() + Path.GetExtension(Event.FileName);
                    Event.SaveAs(Path.Combine(Server.MapPath(obj.Event)));
                }
                obj.Discription = Discription;
                obj.City = City;
                obj.Town_Village = Town_Village;
                obj.Date = Date;
                //obj.Date = string.IsNullOrEmpty(obj.Date) ? null : Common.ConvertToSystemDate(obj.Date, "dd/MM/yyyy");
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.UpdateEventBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Event Banner updated successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddEvent", "Master");
        }



        public ActionResult DeleteEventBanner(string Id)
        {
            try
            {
                Master obj = new Master();
                obj.EventID = Id;
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.DeleteEventBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "Event Banner deleted successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("EventimageList", "Master");
        }
        #endregion

        #region NewsMaster

        public ActionResult AddNews(string Id)
        {
            if (Id != null)
            {
                Master obj = new Master();
                try
                {
                    obj.NewsID = Id;

                    DataSet ds = obj.NewsimageList();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_NewsId = ds.Tables[0].Rows[0]["Pk_NewsId"].ToString();
                        obj.NewsImage = ds.Tables[0].Rows[0]["NewsImage"].ToString();
                        obj.Discription = ds.Tables[0].Rows[0]["Discription"].ToString();
                        obj.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                        obj.Date = ds.Tables[0].Rows[0]["Date"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    TempData["News"] = ex.Message;
                }
                return View(obj);
            }
            else
            {
                return View();
            }
            return View();
        }


        [HttpPost]
        [ActionName("AddNews")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveNewsAction(HttpPostedFileBase News, string Discription,string Date,string Message)
        {
            Master obj = new Master();
            try
            {
                if (News != null)
                {
                    obj.News = "../BannerImages/" + Guid.NewGuid() + Path.GetExtension(News.FileName);
                    News.SaveAs(Path.Combine(Server.MapPath(obj.News)));
                }
                obj.Discription = Discription;
                obj.Message = Message;
                obj.Date = Date;
                //obj.Date = string.IsNullOrEmpty(obj.Date) ? null : Common.ConvertToSystemDate(obj.Date, "dd/MM/yyyy");
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.SaveNewsBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "News Banner saved successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddNews", "Master");
        }

        public ActionResult NewsimageList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.NewsimageList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Pk_NewsId = r["Pk_NewsId"].ToString();
                    obj.NewsImage = r["NewsImage"].ToString();
                    obj.Discription = r["Discription"].ToString();
                    obj.Date = r["Date"].ToString();
                    lst.Add(obj);
                }
                model.lstNews = lst;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("AddNews")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateNewsAction(string Pk_NewsId, HttpPostedFileBase News, string Discription, string Date, string Message)
        {
            Master obj = new Master();
            try
            {
                obj.NewsID = Pk_NewsId;
                if (News != null)
                {
                    obj.News = "../BannerImages/" + Guid.NewGuid() + Path.GetExtension(News.FileName);
                    News.SaveAs(Path.Combine(Server.MapPath(obj.News)));
                }
                obj.Discription = Discription;
                obj.Message = Message;
                obj.Date = Date;
                //obj.Date = string.IsNullOrEmpty(obj.Date) ? null : Common.ConvertToSystemDate(obj.Date, "dd/MM/yyyy");
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.UpdateNewsBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "News Banner updated successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("AddNews", "Master");
        }



        public ActionResult DeleteNewsBanner(string Id)
        {
            try
            {
                Master obj = new Master();
                obj.NewsID = Id;
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.DeleteNewsBanner();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["msg"] = "News Banner deleted successfully";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("NewsimageList", "Master");
        }
        #endregion

    }
}