using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class LogOn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_logon.Enabled = false;
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

        protected void btnLogON_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            Account account = DatabaseManager.LogIn(username, password);
            if (account.AccountID != -1)
            {
                Session["Employee"] = account;
                Response.Redirect("startpage.aspx");
            }
            else
            {
                Response.Redirect("LogOn.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Invalid Username of Password');</script>");
            }
        }

        protected void btn_AddActor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddActor.aspx");
        }

        protected void btn_AddMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMovie.aspx");
        }

        protected void btn_createAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
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

        protected void BtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("startpage.aspx");
        }
    }
}