using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PoliticalWebsite.Models
{
    public class Admin
    {

        public DataSet GetDetails()
        {
            DataSet ds = Connection.ExecuteQuery("BindDataForAdminDashboard");
            return ds;
        }
    }
}