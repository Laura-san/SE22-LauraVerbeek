using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Movie
    {
        private int movieID;

        public int MovieID
        {
            get { return movieID; }
            set { movieID = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private DateTime releaseDate;

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private EnumGenre genre;

        public EnumGenre Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private Movie nextMovie;

        public Movie NextMovie
        {
            get { return nextMovie; }
            set { nextMovie = value; }
        }

        private Movie prevMovie;

        public Movie PrevMovie
        {
            get { return prevMovie; }
            set { prevMovie = value; }
        }

        private string age;

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        private bool sex;

        public bool Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private bool violence;

        public bool Violence
        {
            get { return violence; }
            set { violence = value; }
        }

        private bool fear;

        public bool Fear
        {
            get { return fear; }
            set { fear = value; }
        }

        private bool discrimination;

        public bool Discrimination
        {
            get { return discrimination; }
            set { discrimination = value; }
        }

        private bool drugsAlcoholAbuse;

        public bool DrugsAlcoholAbuse
        {
            get { return drugsAlcoholAbuse; }
            set { drugsAlcoholAbuse = value; }
        }

        List<Review> Reviews = new List<Review>();
        List<Actor> Cast = new List<Actor>();

        public Movie(int movieID, string title, DateTime releasedate, string description, EnumGenre genre, Movie nextMovie, Movie prevMovie, string age, bool sex, bool violence, bool fear, bool discrimination, bool drugsAlcoholAbuse)
        {
            this.movieID = movieID;
            this.title = title;
            this.releaseDate = releasedate;
            this.description = description;
            this.genre = genre;
            this.nextMovie = nextMovie;
            this.prevMovie = prevMovie;
            this.age = age;
            this.violence = violence;
            this.fear = fear;
            this.discrimination = discrimination;
            this.drugsAlcoholAbuse = drugsAlcoholAbuse;
        }

        public Movie()
        {

        }

        public bool AddReview(Review review)
        {
            Reviews.Add(review);
            return true;
        }

        public bool AddActor(Actor actor)
        {
            Cast.Add(actor);
            return true;
        }

        public void ChangeMovie(Movie movie, string changedValue)
        {

        }

        public List<Actor> ViewCast (Movie movie)
        {
            return movie.Cast;
        }
        
    }
}