using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Code = 200,
                Data = data,
                Msg = "Success",
                Total = 0
            };
        }
        public static ApiResult Success(dynamic data, RefAsync<int> total)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Msg = "Success",
                Total = total
            };
        }
        public static ApiResult Error(String msg)
        {
            return new ApiResult
            {
                Code = 200,
                Data = null,
                Msg = msg,
                Total = 0
            };

        }
    }
}
