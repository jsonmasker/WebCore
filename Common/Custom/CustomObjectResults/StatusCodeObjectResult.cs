using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Custom.CustomObjectResults
{
    public class StatusCodeObjectResult : ObjectResult
    {
        public StatusCodeObjectResult(EStatusCodes statusCodes, object? value) : base(value)
        {
            StatusCode = (int)statusCodes;
        }
    }
}
