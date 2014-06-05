﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Employee: Account
    {
        private DateTime hiredSince;

        public DateTime HiredSinde
        {
            get { return hiredSince; }
            set { hiredSince = value; }
        }

        private double salaris;

        public double Salaris
        {
            get { return salaris; }
            set { salaris = value; }
        }

        private Addres addres;

        public Addres Addres
        {
            get { return addres; }
            set { addres = value; }
        }

        public Employee(int accountid, string username, string password, string firstName, string lastName, DateTime dob, DateTime hiredSince, double salaris, Addres addres)
        {
            base.AccountID = accountid;
            base.Username = username;
            base.Password = password;
            base.FirstName = firstName;
            base.LastName = lastName;
            base.DateOfBirth = dob;
            this.hiredSince = hiredSince;
            this.salaris = salaris;
            this.addres = addres;
        }

        public Employee(DateTime hiredSince, double salaris, Addres addres)
        {
            this.hiredSince = hiredSince;
            this.salaris = salaris;
            this.addres = addres;
        }

        public bool CreateMovie(string title, DateTime releaseDate, string description, EnumGenre genre, Movie movie, string age, bool sex, bool violence, bool fear, bool discrimination, bool drugsAlcoholAbuse)
        {
            return true;
        }

        public bool createActor(string name, string biography, DateTime dob)
        {
            return true;
        }

        public bool AddEmployee(string username, string password, string firstName, string lastName, DateTime dob, DateTime hiredSince, double salaris, Addres addres)
        {
            return true;
        }

        public bool AddUser(string username, string password, string firstName, string lastName, DateTime dob, string email, bool memberLetter)
        {
            return true;
        }
    }
}