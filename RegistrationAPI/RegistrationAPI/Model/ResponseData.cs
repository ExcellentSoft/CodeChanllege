using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Model
{
    public static class ResponseData
    {
        //for Api response
        public static object Response(string title, object errors = null, object data = null)
        {
            return new { title,  errors, data };
        }
        //bool SuccessStatus,string message, SuccessStatus, message,
    }
}
