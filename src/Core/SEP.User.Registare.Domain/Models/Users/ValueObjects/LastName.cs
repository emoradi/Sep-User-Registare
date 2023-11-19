using SEP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Domain.Models.Users.ValueObjects
{
    public class LastName : ValueObject<LastName>, IComparable<LastName>
    {
        #region prop && constant
        public const short MaxLength = 400;
        public string value { get; }
        #endregion
        #region ctor
        private LastName()
        {

        }
        public LastName(string lastName)
        {
            Validate(lastName);
            value = lastName;

        }

        #endregion
        #region method



        #endregion
        #region imp && over
        public int CompareTo(LastName? other)
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
                throw new ArgumentException("Last Name Is Invalid.");
            if (value.Length > MaxLength)
                throw new ArgumentException("Last Name Length is Invalid.");
        }
        protected override bool EqualsCore(LastName other)
        {
            return value == other.value;
        }

        #endregion
    }
}
