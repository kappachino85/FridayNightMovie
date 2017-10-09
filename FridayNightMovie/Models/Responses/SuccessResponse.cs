using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FridayNightMovie.Models.Responses
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {
            this.IsSuccessful = true;
        }
    }
}