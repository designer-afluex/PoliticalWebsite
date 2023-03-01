using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PoliticalWebsite.Models
{
    public class Home
    {
        public string AddedBy { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }

        #region GalleryMaster
        public List<Home> lstgallery { get; set; }
        public string GalleryImage { get; set; }
        public string Discription { get; set; }
        public string Pk_GalleryId { get; set; }
        public string GalleryID { get; set; }
        #endregion

        #region EventMaster
        public string EventID { get; set; }
        public string Pk_EventId { get; set; }
        public string EventImage { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public string Town_Village { get; set; }
        public List<Home> lstevent { get; set; }
        #endregion
        #region NewsMaster
        public string NewsID { get; set; }
        public string Pk_NewsId { get; set; }
        public string NewsImage { get; set; }
        public string MainNewsImage { get; set; }
        public string MainDiscription { get; set; }
        public List<Home> lstNews { get; set; }
        public string Year { get; set; }
        #endregion


        public DataSet Login()
        {
            SqlParameter[] para ={new SqlParameter ("@LoginId",LoginId),
                                new SqlParameter("@Password",Password)};
            DataSet ds = Connection.ExecuteQuery("Login", para);
            return ds;
        }

        public DataSet SaveContactUs()
        {
            SqlParameter[] para = {
                new SqlParameter("@Name",Name),
                 new SqlParameter("@Email",Email),
                  new SqlParameter("@Mobile",Mobile),
                   new SqlParameter("@Message",Message),
                    new SqlParameter("@Subject",Subject),
                     new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveContactDetails", para);
            return ds;
        }

        public DataSet GalleryimageList()
        {
            SqlParameter[] para = { new SqlParameter("@GalleryID", GalleryID) };
            DataSet ds = Connection.ExecuteQuery("GalleryBannerDetails", para);
            return ds;
        }

        public DataSet EventimageList()
        {
            SqlParameter[] para = { new SqlParameter("@EventID", EventID) };
            DataSet ds = Connection.ExecuteQuery("EventBannerDetails", para);
            return ds;
        }

        public DataSet NewsimageList()
        {
            SqlParameter[] para = { new SqlParameter("@NewsID", NewsID) };
            DataSet ds = Connection.ExecuteQuery("NewsBannerDetails", para);
            return ds;
        }
    }
}