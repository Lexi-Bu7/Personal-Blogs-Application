using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Utility.ApiResult
{
    public static class ApiResultHelper
    {
        // Returning data after Successful running
        public static ApiResult Success(dynamic data)
        {
            return new ApiResult
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Msg = "Success",
                Total = 0
            };
        }
        public static ApiResult Success(dynamic data, RefAsync<int> total)
        {
            return new ApiResult
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Msg = "Success",
                Total = total
            };
        }
        public static ApiResult Error(String msg)
        {
            return new ApiResult
            {
                Code = HttpStatusCode.BadRequest,
                Data = null,
                Msg = msg,
                Total = 0
            };

        }
    }
}
