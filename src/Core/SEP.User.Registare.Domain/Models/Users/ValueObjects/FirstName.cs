using SEP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Domain.Models.Users.ValueObjects
{
    public class FirstName : ValueObject<FirstName>, IComparable<FirstName>
    {
        #region prop && constant
        public const short MaxLength = 200;

        public string value { get; }
        #endregion
        #region ctor
        private FirstName()
        {

        }
        public FirstName(string firstName)
        {
            Validate(firstName);
            value = firstName;

        }

        #endregion
        #region method


        #endregion
        #region imp && over
        public int CompareTo(FirstName? other)
        {
            return String.Compare(this.value, other.value, StringComparison.InvariantCultureIgnoreCase);
        }
        public override string ToString()
        {
            return value;
        }

        protected override void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("First Name Is Invalid.");
            if (value.Length > MaxLength)
                throw new ArgumentException("First Name Length is Invalid.");
        }
        protected override bool EqualsCore(FirstName other)
        {
            return value == other.value;
        }
        #endregion
    }
}
