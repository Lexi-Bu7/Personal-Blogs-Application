using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace MyBlog.JWT.Utility.ApiResult
{
    public class ApiResult
    {
        public System.Net.HttpStatusCode Code { get; set; }
        public int Total { get; set; }
        public String Msg { get; set; }
        public dynamic Data { get; set; }

    }
}
