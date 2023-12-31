﻿using SEP.Domain;
using SEP.User.Registare.Domain.Models.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Domain.Models.Users
{
    public class User : AggregateRoot<int>
    {
        #region prop
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public DateTime DateOfBirth { get;  set; }
        public PhoneNumber PhoneNumber { get;  set; }
        public EmailAddress EmailAddress { get;  set; }
        #endregion
        #region ctor
        public User()
        {

        }
        private User(string firstName, string lastName, string email, string phoneNumber, string countryCode, DateTime dateOfBirth)
        {
            this.FirstName = new FirstName(firstName);
            this.LastName = new LastName(lastName);
            this.EmailAddress = new EmailAddress(email);
            this.PhoneNumber = new PhoneNumber(phoneNumber, countryCode);
            this.DateOfBirth = dateOfBirth;
        }
        #endregion
        #region prv method
        private void valudateForCreate(DateTime dateOfBirth)
        {
            if(dateOfBirth==DateTime.MinValue)
                throw new ArgumentException("Date Of Birth Is Invalid.");
        }
        #endregion

        #region pub method
        public User Create(string firstName, string lastName, string email, string phoneNumber, string countryCode, DateTime dateOfBirth)
        {
            valudateForCreate(dateOfBirth);
            var newUser = new User(firstName, lastName, email, phoneNumber, countryCode, dateOfBirth);
            return newUser;
        }
        public void Update( string firstName, string lastName, string phoneNumber, string countryCode, DateTime dateOfBirth)
        {
            valudateForCreate(dateOfBirth);
            this.FirstName = new FirstName(firstName);
            this.LastName = new LastName(lastName);
            this.PhoneNumber = new PhoneNumber(phoneNumber, countryCode);
            this.DateOfBirth = dateOfBirth;
        }


        #endregion

    }
}
