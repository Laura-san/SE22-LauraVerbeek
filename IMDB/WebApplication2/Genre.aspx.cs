using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Genre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_AddActor.Visible = false;
            btn_AddMovie.Visible = false;
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
                //foutmelding
            }
        }

        protected void btn_logon_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOn.aspx");
        }

        protected void btn_createAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void btn_AddMovie_Click(object sender, EventArgs e)
        {
            //todo
        }

        protected void btn_AddActor_Click(object sender, EventArgs e)
        {
            //todo
        }

        protected void BtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("startpage.aspx");
        }
    }
}