using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AddMovie : System.Web.UI.Page
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
            EnumGenre genre = EnumGenre.Adventure;
            if (DDGenre.SelectedIndex == 0)
            {
                genre = EnumGenre.Adventure;
            }
            else if(DDGenre.SelectedIndex == 1)
            {
                genre = EnumGenre.Comedy;
            }
            else if(DDGenre.SelectedIndex == 2)
            {
                genre = EnumGenre.Drama;
            }
            else if(DDGenre.SelectedIndex == 3)
            {
                genre = EnumGenre.Humor;
            }

            string age = "None";
            if (RBnone.Checked)
            {
                age = "None";
            }
            else if(RBsixteen.Checked)
            {
                age = "16+";
            }
            else if (RBeightteen.Checked)
            {
                age = "18+";
            }

            bool sex = false;
            if (RBYesSex.Checked)
            {
                sex = true;
            }
            else if (RBNoSex.Checked)
            {
                sex = false;
            }

            bool violence = false;
            if (RBYesViolence.Checked)
            {
                violence = true;
            }
            else if (RBNoViolence.Checked)
            {
                violence = false;
            }

            bool fear = false;
            if (RBYesFear.Checked)
            {
                fear = true;
            }
            else if (RBNoFear.Checked)
            {
                fear = false;
            }

            bool discrimination = false;
            if (RBYesDiscrimination.Checked)
            {
                discrimination = true;
            }
            else if (RBNoDiscrimination.Checked)
            {
                discrimination = false;
            }

            bool drugsAlcoholAbuse = false;
            if(RBYesDrugsAlcohol.Checked)
            {
                drugsAlcoholAbuse = true;
            }
            else if (RBNoDrugsAlcohol.Checked)
            {
                drugsAlcoholAbuse = false;
            }
            Movie prev = new Movie(); //GetMovieFromTitle uit de database.
            //Haal release datum op van het form
            int filmID = Convert.ToInt32(DatabaseManager.GiveHighestID("FILM")) + 1;
            Movie movie = new Movie(filmID, tbTitle.Text, DateTime.Now, tbDescription.Text, genre, null, prev, age, sex, violence, fear, discrimination, drugsAlcoholAbuse);
            try
            {
                Response.Redirect("startpage.aspx"); // werkt niet
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Movie added to database!');</script>");
                DatabaseManager.InsertMovie(movie);
            }
            catch
            {
                Response.Redirect("AddMovie.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Added movie failed!');</script>");
            }
        }
        
    }
}