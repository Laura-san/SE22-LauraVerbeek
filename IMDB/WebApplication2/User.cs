using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class User: Account
    {
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private bool memberLetter;

        public bool MemberLetter
        {
            get { return memberLetter; }
            set { memberLetter = value; }
        }

        public User(int accountID, string username, string password, string firstName, string lastName, DateTime dob, string email, bool letter)
        {
            base.AccountID = accountID;
            base.Username = username;
            base.Password = password;
            base.FirstName = firstName;
            base.LastName = lastName;
            base.DateOfBirth = dob;
            this.email = email;
            this.memberLetter = letter;
        }
    }
}