using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Addres
    {
        private string street;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        private string number;

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        private string place;

        public string Place
        {
            get { return place; }
            set { place = value; }
        }

        public Addres(string street, string number, string place)
        {
            this.street = street;
            this.place = place;
            this.number = number;
        }
        
    }
}