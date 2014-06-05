using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Addres
    {
        private string postcode;

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        private string place;

        public string Place
        {
            get { return place; }
            set { place = value; }
        }

        public Addres(string postcode, string place)
        {
            this.postcode = postcode;
            this.place = place;
        }
        
    }
}