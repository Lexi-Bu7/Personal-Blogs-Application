using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace MyBlog.Model
{
    public class BlogNews:BaseId
    {   //nvarchar could use chinese
        [SugarColumn(ColumnDataType ="nvarchar(30)")]
        public string Title { get; set; }

        [SugarColumn(ColumnDataType ="text")]
        public string Content { get; set; }

        public DateTime Time { get; set; }
        

        public int BrowseCount { get; set; }

        public int LikeCount { get; set; }

        //Blog Type
        public int TypeId { get; set; }
        public int AuthorId { get; set; }
        /// <summary>
        /// Classes, not put data into database
        /// </summary>

        [SugarColumn(IsIgnore = true )]
        public TypeInfo TypeInfo { get; set; }

        [SugarColumn(IsIgnore = true)]
        public AuthorInfo AuthorInfo { get; set; }
    }
}
