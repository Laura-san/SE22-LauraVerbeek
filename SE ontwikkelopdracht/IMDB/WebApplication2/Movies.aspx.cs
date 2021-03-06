﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Movies : System.Web.UI.Page
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

            lbMovies.Items.Clear();
            List<Movie> movies = DatabaseManager.GiveMovies();
            if (movies != null)
            {
                foreach (Movie movie in movies)
                {
                    lbMovies.Items.Add(movie.Title);
                }
                Session["Movies"] = movies;
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
            Response.Redirect("AddMovie.aspx");
        }

        protected void btn_AddActor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddActor.aspx");
        }

        protected void BtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("startpage.aspx");
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (DDSearch.SelectedIndex == 0)
            {
                Response.Redirect("Movies.aspx");
            }
            else if(DDSearch.SelectedIndex == 1)
            {
                Response.Redirect("Actors.aspx");
            }
            else if(DDSearch.SelectedIndex == 2)
            {
                Response.Redirect("Genre.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a category!');</script>");
            }
        }

        protected void btn_viewMovie_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Movie> movies = (List<Movie>)Session["Movies"];
                int selectedMovie = (lbMovies.SelectedIndex) - 1;
                if (selectedMovie >= 0)
                {
                    Movie m = movies[selectedMovie];
                    Session["ViewMovie"] = m;
                    Response.Redirect("ViewMovi.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a movie!');</script>");
                }
            }
        }
    }
}