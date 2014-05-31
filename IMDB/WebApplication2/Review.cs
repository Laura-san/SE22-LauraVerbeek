using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Review
    {
        private int reviewID;

        public int ReviewID
        {
            get { return reviewID; }
            set { reviewID = value; }
        }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; }
        }

        private EnumRating rating;

        public EnumRating Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private string explanation;

        public string Explanation
        {
            get { return explanation; }
            set { explanation = value; }
        }

        private Account account;

        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        public Review(int reviewID, Movie movie, EnumRating rating, string explanation, Account account)
        {
            this.reviewID = reviewID;
            this.movie = movie;
            this.rating = rating;
            this.explanation = explanation;
            this.account = account;
        }
        
    }
}