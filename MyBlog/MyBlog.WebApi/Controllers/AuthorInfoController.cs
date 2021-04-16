using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.WebApi.Utility.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorInfoController : ControllerBase
    {
        private readonly IAuthorInfoService _iAuthorInfoService;
        public AuthorInfoController(IAuthorInfoService iAuthorInfoService)
        {
            _iAuthorInfoService = iAuthorInfoService;

        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string name, string username, string userpwd)
        {
            //check if username and password fit the patter
            AuthorInfo author = new AuthorInfo
            {
                Name = name,
                UserName = username,
                UserPwd = userpwd

            };

            // check if there is same account or password exit in the database
            var oldAuthor = await _iAuthorInfoService.FindAsync(c => c.UserName == username);
            if (oldAuthor != null) return ApiResultHelper.Error("Account already exist");
            bool b = await _iAuthorInfoService.CreateAsync(author);
            if (!b) return ApiResultHelper.Error(msg: "Fail to add");
            return ApiResultHelper.Success(author);
        }
        [HttpPut("Edit")]
        public async Task<ApiResult> Edit(string name)
        {
            int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
            return ApiResultHelper.Error(msg: "");

        }
    }

}
