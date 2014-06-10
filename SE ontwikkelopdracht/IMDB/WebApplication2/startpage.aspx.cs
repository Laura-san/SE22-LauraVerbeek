﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class startpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account acc = (Account)Session["Employee"];
            if (acc != null)
            {
                if (acc.Soort == "Employee")
                {
                    btn_AddActor.Visible = true;
                    btn_AddMovie.Visible = true;
                    btn_createAccount.Enabled = true;
                }
                else
                {
                    btn_AddActor.Visible = false;
                    btn_AddMovie.Visible = false;
                }
            }
            else
            {
                btn_AddActor.Visible = false;
                btn_AddMovie.Visible = false;
            }
        }

        protected void BtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("startpage.aspx");
        }

        protected void btn_logon_Click1(object sender, EventArgs e)
        {
            Response.Redirect("LogOn.aspx");
        }

        protected void btn_createAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void btn_AddMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMovie.aspx");
        }

        protected void btn_AddActor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddActor.aspx");
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (DDSearch.SelectedIndex == 0)
            {
                Response.Redirect("Movies.aspx");
            }
            else if (DDSearch.SelectedIndex == 1)
            {
                Response.Redirect("Actors.aspx");
            }
            else if (DDSearch.SelectedIndex == 2)
            {
                Response.Redirect("Genre.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a category!');</script>");
            }
        }

        protected void Film1_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void Film2_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void film3_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void Film4_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void Film5_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void Actor1_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void Actor2_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void Actor3_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void Actor4_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }

        protected void Actor5_Click(object sender, ImageClickEventArgs e)
        {
            //todo
        }
    }
}