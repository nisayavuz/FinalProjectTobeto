using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
       

        public Result(bool success, string message) : this(success)
        {
            Message = message;
           
        }

        public Result(bool success)  // overloading
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get;  } //readonly => constructorda set edilebilir. Onun dışında set edilemez.
    }
}
