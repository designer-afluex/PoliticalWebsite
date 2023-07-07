﻿using RadhekunkInfra.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RadhekunkInfra
{
    public partial class AdminLevelTree : System.Web.UI.Page
    {
        public DataSet dsResult = new DataSet();
        Tree obj = new Tree();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Pk_AdminId"] == null)
            {
                Response.Redirect("/Home/Login");
            }

        }

        public void GetDirectData()
        {

            try
            {

                obj.RootAgentCode = txtloginid.Text;
                obj.LoginId = txtloginid.Text;

                dsResult = obj.GetLevelTreeData();

                if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {

                    trvBroker.Nodes.Clear();
                    TreeNode ParentNode = new TreeNode();


                    ParentNode.Value = dsResult.Tables[0].Select("LoginId = '" + obj.LoginId + "'").CopyToDataTable().Rows[0]["Pk_UserId"].ToString();

                    ParentNode.Text = dsResult.Tables[0].Select("LoginId = '" + obj.LoginId + "'").CopyToDataTable().Rows[0]["MemberName"].ToString();

                    trvBroker.Nodes.Add(ParentNode);
                    BindTree(ParentNode, dsResult);

                }
            }
            catch (Exception ex)
            {

            }
        }


        public void BindTree(TreeNode ParentNode, DataSet DsData)
        {

            foreach (DataRow d in dsResult.Tables[0].Select("Parentid  = " + ParentNode.Value))
            {
                TreeNode ChildNode = new TreeNode();

                if (ParentNode.Value != obj.LoginId)
                    ParentNode.ImageUrl = ParentNode.ImageUrl;

                ChildNode.Value = d["PK_UserId"].ToString();
                ChildNode.Text = d["MemberName"].ToString();


                // ChildNode.ToolTip = ChildNode.Text;


                ParentNode.ChildNodes.Add(ChildNode);
                BindTree(ChildNode, dsResult);



                trvBroker.DataBind();

            }


        }

        void Data_Bound(Object sender, TreeNodeEventArgs e)
        {

            string Prefix = "<div style='display:none;' class='content'>Some Content</div>";
            e.Node.Text = Prefix + e.Node.Text;

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            GetDirectData();
        }
    }
}