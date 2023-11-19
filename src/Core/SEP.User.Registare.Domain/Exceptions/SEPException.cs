using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Domain.Exceptions
{
    public class SEPException: Exception
    {
        public SEPException(string? message) : base(message)
        {
        }
    }
}
