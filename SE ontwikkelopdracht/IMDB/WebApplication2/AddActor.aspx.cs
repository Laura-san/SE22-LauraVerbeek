using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AddActor : System.Web.UI.Page
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

            lbFilmography.Items.Clear();
            List<string> movie = new List<string>();
            movie = (List<string>)Session["movie"];
            if (movie != null)
            {
                foreach (string s in movie)
                {
                    lbFilmography.Items.Add(s);
                }
            }

            if (!IsPostBack)
            {
                if ((string)Session["ActorName"] != null && (string)Session["Biography"] != null)
                {
                    tbName.Text = (string)Session["ActorName"];
                    tbBiography.Text = (string)Session["Biography"];
                    tbDateOfBirthDay.Text = (string)Session["DOBDay"];
                    tbDateOfBirthMonth.Text = (string)Session["DOBMonth"];
                    tbDateOfBirthYear.Text = (string)Session["DOBYear"];
                }
            }
        }

        protected void BtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("startpage.aspx");
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> filmography = new List<string>();
            filmography = (List<string>)Session["movie"];
            int actorID = Convert.ToInt32(DatabaseManager.GiveHighestID("ACTEUR"));
            Actor actor = new Actor(actorID + 1, tbName.Text, tbBiography.Text, DateTime.Now, filmography);
            DatabaseManager.InsertActor(actor);
            Session.Remove("ActorName");
            Session.Remove("Biography");
            Session.Remove("DOBDay");
            Session.Remove("DOBMonth");
            Session.Remove("DOBYear");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Actor added to database.');</script>");
            Response.Redirect("startpage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["ActorName"] = tbName.Text;
            Session["Biography"] = tbBiography.Text;
            Session["DOBDay"] = tbDateOfBirthDay.Text;
            Session["DOBMonth"] = tbDateOfBirthMonth.Text;
            Session["DOBYear"] = tbDateOfBirthYear.Text;
            Response.Redirect("AddToFilmography.aspx");
        }
    }
}