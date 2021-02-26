

using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.WebApi.Utility.ApiResult;
using SqlSugar;
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
        //Create a new blog
        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string title, string content, int typeid)
        {
            // verify the data
            #region verify if it's null
            if (String.IsNullOrWhiteSpace(title)) return ApiResultHelper.Error("type can not be empty");
            #endregion
            BlogNews blogNews = new BlogNews
            {
                BrowseCount = 0,
                Content = content,
                LikeCount = 0,
                Time = DateTime.Now,
                Title = title,
                TypeId = typeid,
                AuthorId = 1
            };
            bool b = await _iBlogNewsService.CreateAsync(blogNews);
            if (!b) return ApiResultHelper.Error(msg: "Fail to add new blog, error in server");
            return ApiResultHelper.Success(blogNews);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iBlogNewsService.DelteAsync(id);
            if(!b) return ApiResultHelper.Error(msg: "Fail to delete the blog, error in server");
            return ApiResultHelper.Success(b);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<ApiResult>> Edit(int id, string title, string content, int typeid)
        {
            var blogNews = await _iBlogNewsService.FindAsync(id);
            if (blogNews == null) return ApiResultHelper.Error(msg: "Can't find this Blog you're searching for");
            blogNews.Title = title;
            blogNews.Content = content;
            blogNews.TypeId = typeid;

            bool b = await _iBlogNewsService.EditAsync(blogNews);
            if (!b) return ApiResultHelper.Error(msg: "Fail to edit the blog, error in server");
            return ApiResultHelper.Success(blogNews);
        }

    }
}
