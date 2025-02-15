using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ValidationException : Exception
    {
        public  int Code;
        public ValidationException(int _code, string message) : base(message)
        {
            Code = _code;
        }
    }
}
