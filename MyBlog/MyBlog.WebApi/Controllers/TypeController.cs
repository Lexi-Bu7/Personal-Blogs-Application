using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class TypeController : ControllerBase
    {
        private readonly ITypeInfoService _iTypeInfoService;
        public TypeController(ITypeInfoService iTypeInfoService)
        {
            this._iTypeInfoService = iTypeInfoService;
        }
        [HttpGet("Types")]
        public async Task<ApiResult> Types()
        {
            var types = await _iTypeInfoService.QueryAsync();
            if (types.Count == 0) return ApiResultHelper.Error("No this blog type");
            return ApiResultHelper.Success(types);
        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string name)
        {
            #region verify if it's null
            if (String.IsNullOrWhiteSpace(name)) return ApiResultHelper.Error("type can not be empty");
            #endregion
            TypeInfo type = new TypeInfo
            {
                Name = name
            };
            bool b = await _iTypeInfoService.CreateAsync(type);
            if (!b) return ApiResultHelper.Error("Fail to add new type, error in server");
            return ApiResultHelper.Success(b);
        }


    }
}