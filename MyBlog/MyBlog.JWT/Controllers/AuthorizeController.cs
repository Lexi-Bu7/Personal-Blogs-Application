using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IService;
using MyBlog.JWT.Utility._MD5;
using MyBlog.JWT.Utility.ApiResult;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorInfoService _iAuthorInfoService;
        public AuthorizeController(IAuthorInfoService iAuthorInfoService)
        {
            _iAuthorInfoService = iAuthorInfoService;
        }

        [HttpPost("Login")]
        public async Task<ApiResult> Login(string username, string userpwd)
        {   
            //the encryped password
            string pwd = MD5Helper.MD5Encrypt32(userpwd);

            //verify data
            var author = await _iAuthorInfoService.FindAsync(c => c.UserName == username && c.UserPwd == pwd);
            if (author != null)
            {
                //succesfully login
                var claims = new Claim[]
                {
                new Claim(ClaimTypes.Name, author.Name),
                new Claim("Id", author.Id.ToString()),
                new Claim("UserName", author.UserName)
                // Senstive information is not allowed  
                 };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF"));
               
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:6060",
                    audience: "http://localhost:5000",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return ApiResultHelper.Success(jwtToken);
            }
            else
            {
                return ApiResultHelper.Error(msg: "Wrong account number or password");
            }
        }
    }
}
