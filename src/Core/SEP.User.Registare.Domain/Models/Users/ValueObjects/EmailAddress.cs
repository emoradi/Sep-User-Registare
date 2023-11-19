using SEP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEP.User.Registare.Domain.Models.Users.ValueObjects
{
    public class EmailAddress : ValueObject<EmailAddress>, IComparable<EmailAddress>
    {
        #region prop && constant
        public const short MaxLength = 320;
        private const string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"

           + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"

           + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"

           + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"

           + @"[a-zA-Z]{2,}))$";

        public string value { get; }
        #endregion
        #region ctor
        private EmailAddress()
        {

        }
        public EmailAddress(string emailAddress)
        {
            Validate(emailAddress);
            value = emailAddress;

        }

        #endregion
        #region method


        #endregion
        #region imp && over
        public int CompareTo(EmailAddress? other)
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
                throw new ArgumentException("Email Address Is Invalid.");
            if (value.Length > MaxLength)
                throw new ArgumentException("Email Address  Length is Invalid.");
            Regex regexStrict = new Regex(patternStrict);
            if (!regexStrict.IsMatch(value))
                throw new ArgumentException("Email Address Is Invalid.");
        }

        protected override bool EqualsCore(EmailAddress other)
        {
            return value == other.value;
        }
        #endregion
    }
}