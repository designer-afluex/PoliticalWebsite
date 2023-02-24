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
        public string ExampleId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }


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
                    new SqlParameter("@ExampleId",ExampleId),
                     new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveContactDetails", para);
            return ds;
        }
    }
}