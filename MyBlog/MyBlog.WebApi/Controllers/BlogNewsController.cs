using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.WebApi.Utility.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;
        public BlogNewsController(IBlogNewsService iBlogNewsService)
        {
            this._iBlogNewsService = iBlogNewsService;
        }
        [HttpGet(template:"BlogNews")]
        public async Task<ActionResult <ApiResult>>GetBlogNews()
        
        {
            var data = await _iBlogNewsService.QueryAsync();
            if (data == null) return ApiResultHelper.Error(msg: "No search blog");
            return ApiResultHelper.Success(data);
        }
       
    }
}
