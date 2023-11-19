using SEP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Domain.Models.Users.ValueObjects
{
    public class PhoneNumber : ValueObject<PhoneNumber>, IComparable<PhoneNumber>
    {
        #region prop
        public string value { get; }
        #endregion
        #region constant
        public const int MaxLength = 13;
        #endregion constant
        #region ctor
        private PhoneNumber()
        {
        }

        public PhoneNumber(string phoneNumber, string countryCode)
        {

            Validate(phoneNumber, countryCode);
            value = phoneNumber;
        }
        public PhoneNumber(string orginalPhoneNumber)
        {
            this.value = orginalPhoneNumber;
        }

        #endregion
        #region method

        protected void Validate(string currentPhoneNumber, string countryCode)
        {
            
            if (string.IsNullOrEmpty(currentPhoneNumber) || string.IsNullOrEmpty(countryCode))
                throw new ArgumentException("Phone Number Is Invalid.");
            
        }
        

        #endregion
        #region imp
        public override string ToString()

        {
            return value;
        }
        public int CompareTo(PhoneNumber? other)
        {
            return String.Compare(this.value, other.value, StringComparison.InvariantCultureIgnoreCase);
        }
        protected override bool EqualsCore(PhoneNumber other)
        {
            return value == other.value;
        }
        protected override void Validate(string value)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
