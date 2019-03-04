using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace WebApi.Helpers
{
    public class ListErrors
    {
        public static List<String> toList(IEnumerable<ModelError> err)
        {
            var errors = new List<String>();
            foreach (var e in err)
            {                
                    errors.Add(e.ErrorMessage);
            }
            return errors;
        }
    }
}