using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PoliticalWebsite.Models
{
    public class Master
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }


        #region SliderBannerMaster
        public string SliderBannerID { get; set; }
        public string Pk_SliderBannerId { get; set; }
        public string SliderBanner { get; set; }
        public string SliderBannerImage { get; set; }
        public List<Master> lstSliderBanner { get; set; }
        #endregion

        #region GalleryMaster
        public string GalleryID { get; set; }
        public string Pk_GalleryId { get; set; }
        public string Gallery { get; set; }
        public string GalleryImage { get; set; }
        public List<Master> lstgallery { get; set; }
        #endregion

        #region EventMaster
        public string EventID { get; set; }
        public string Pk_EventId { get; set; }
        public string EventImage { get; set; }
        public string Event { get; set; }
        public string Discription { get; set; }
        public List<Master> lstevent { get; set; }
        public string Date { get; set; }
        public string EventDate { get; set; }
        public string City { get; set; }
        public string Town_Village { get; set; }
        #endregion

        #region NewsMaster
        public string News { get; set; }
        public string NewsID { get; set; }
        public string Pk_NewsId { get; set; }
        public string NewsHeading { get; set; }
        public string NewsImage { get; set; }
        public string file { get; set; }
        public List<Master> lstNews { get; set; }
        public string Result { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Message { get; set; }
        public string NewsDate { get; set; }

        #endregion




        #region SliderBannerMaster

        public DataSet SaveSliderBanner()
        {
            SqlParameter[] para = {
                    new SqlParameter("@SliderBannerImage", SliderBanner),
                    new SqlParameter("@AddedBy", AddedBy)

            };

            DataSet ds = Connection.ExecuteQuery("SaveSliderBanner", para);
            return ds;
        }
        public DataSet SliderBannerList()
        {
            SqlParameter[] para = { new SqlParameter("@Pk_SliderBannerId", SliderBannerID) };
            DataSet ds = Connection.ExecuteQuery("SliderBannerDetails", para);
            return ds;
        }

        public DataSet UpdateSliderBanner()
        {
            SqlParameter[] para = {
                    new SqlParameter("@SliderBannerID", SliderBannerID),
                    new SqlParameter("@SliderBannerImage", SliderBanner),
                    new SqlParameter("@UpdatedBy", AddedBy)

            };

            DataSet ds = Connection.ExecuteQuery("UpdateSliderBanner", para);
            return ds;
        }

        public DataSet DeleteSliderBanner()
        {
            SqlParameter[] para = { new SqlParameter("@SliderBannerID", SliderBannerID),
                                  new SqlParameter("@DeletedBy", AddedBy),};

            DataSet ds = Connection.ExecuteQuery("DeleteSliderBanner", para);
            return ds;
        }

        #endregion



        #region GalleryMaster

        public DataSet SaveGalleryBanner()
        {
            SqlParameter[] para = {
                    new SqlParameter("@GalleryImage", Gallery),
                    new SqlParameter("@Discription", Discription),
                    new SqlParameter("@AddedBy", AddedBy)

            };

            DataSet ds = Connection.ExecuteQuery("SaveGalleryBanner", para);
            return ds;
        }
        public DataSet GalleryimageList()
        {
            SqlParameter[] para = { new SqlParameter("@GalleryID", GalleryID) };
            DataSet ds = Connection.ExecuteQuery("GalleryBannerDetails", para);
            return ds;
        }

        public DataSet UpdateGalleryBanner()
        {
            SqlParameter[] para = {
                    new SqlParameter("@GalleryID", GalleryID),
                    new SqlParameter("@GalleryImage", Gallery),
                    new SqlParameter("@Discription", Discription),
                    new SqlParameter("@UpdatedBy", AddedBy)

            };

            DataSet ds = Connection.ExecuteQuery("UpdateGalleryBanner", para);
            return ds;
        }

        public DataSet DeleteGalleryBanner()
        {
            SqlParameter[] para = { new SqlParameter("@GalleryID", GalleryID),
                                  new SqlParameter("@DeletedBy", AddedBy),};

            DataSet ds = Connection.ExecuteQuery("DeleteGalleryBanner", para);
            return ds;
        }

        #endregion

        #region EventMaster

        public DataSet SaveEventBanner()
        {
            SqlParameter[] para = {
                    new SqlParameter("@EventImage", Event),
                    new SqlParameter("@Discription", Discription),
                    new SqlParameter("@City", City),
                    new SqlParameter("@Town_Village", Town_Village),
                    new SqlParameter("@Date", EventDate),
                    new SqlParameter("@AddedBy", AddedBy)

            };

            DataSet ds = Connection.ExecuteQuery("SaveEventBanner", para);
            return ds;
        }
        public DataSet EventimageList()
        {
            SqlParameter[] para = { new SqlParameter("@EventID", EventID) };
            DataSet ds = Connection.ExecuteQuery("EventBannerDetails", para);
            return ds;
        }

        public DataSet UpdateEventBanner()
        {
            SqlParameter[] para = {
                    new SqlParameter("@EventID", EventID),
                    new SqlParameter("@EventImage", Event),
                    new SqlParameter("@Discription", Discription),
                     new SqlParameter("@City", City),
                    new SqlParameter("@Town_Village", Town_Village),
                    new SqlParameter("@Date", EventDate),
                    new SqlParameter("@UpdatedBy", AddedBy)

            };

            DataSet ds = Connection.ExecuteQuery("UpdateEventBanner", para);
            return ds;
        }

        public DataSet DeleteEventBanner()
        {
            SqlParameter[] para = { new SqlParameter("@EventID", EventID),
                                  new SqlParameter("@DeletedBy", AddedBy),};

            DataSet ds = Connection.ExecuteQuery("DeleteEventBanner", para);
            return ds;
        }

        #endregion

        #region NewsMaster

        public DataSet SaveNewsBanner()
        {
            SqlParameter[] para = {
                    new SqlParameter("@NewsImage", News),
                    new SqlParameter("@Discription", Discription),
                    new SqlParameter("@Message", Message),
                    new SqlParameter("@Date", NewsDate),
                    new SqlParameter("@AddedBy", AddedBy)

            };

            DataSet ds = Connection.ExecuteQuery("SaveNewsBanner", para);
            return ds;
        }
        public DataSet NewsimageList()
        {
            SqlParameter[] para = { new SqlParameter("@NewsID", NewsID) };
            DataSet ds = Connection.ExecuteQuery("NewsBannerDetails", para);
            return ds;
        }

        public DataSet UpdateNewsBanner()
        {
            SqlParameter[] para = {
                    new SqlParameter("@NewsID", NewsID),
                    new SqlParameter("@NewsImage", News),
                    new SqlParameter("@Discription", Discription),
                    new SqlParameter("@Message", Message),
                     new SqlParameter("@Date", NewsDate),
                    new SqlParameter("@UpdatedBy", AddedBy)

            };

            DataSet ds = Connection.ExecuteQuery("UpdateNewsBanner", para);
            return ds;
        }

        public DataSet DeleteNewsBanner()
        {
            SqlParameter[] para = { new SqlParameter("@NewsID", NewsID),
                                  new SqlParameter("@DeletedBy", AddedBy),};

            DataSet ds = Connection.ExecuteQuery("DeleteNewsBanner", para);
            return ds;
        }

        #endregion


        public DataSet ChangePassword()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@OldPassword",OldPassword),
                new SqlParameter("@NewPassword",NewPassword),
                 new SqlParameter("@UpdatedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("AdminChangePassword", para);
            return ds;
        }
    }
}