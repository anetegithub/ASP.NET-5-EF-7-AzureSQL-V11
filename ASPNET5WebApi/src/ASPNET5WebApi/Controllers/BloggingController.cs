using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ASPNET5WebApi.Models;

namespace ASPNET5WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BloggingController
    {
        [HttpGet]
        public Object addBlog()
        {
            using (var db = new BloggingContext())
            {
                var MaxBlogId = db.Blogs.Max(x => x.BlogId);

                Blog NewBlog = new Blog();
                NewBlog.Name = "Testblog #" + MaxBlogId.ToString();

                Post FirstPost = new Post() { Comment = "Test" };
                Post SecondPost = new Post() { Comment = "blog" };

                

                NewBlog.Posts = new List<Post>() { FirstPost, SecondPost };

                db.Blogs.Add(NewBlog);
                db.Posts.Add(FirstPost);
                db.Posts.Add(SecondPost);
                
                db.SaveChanges();

                return true;
            }
        }


        [HttpGet]
        public Object getBlogs()
        {
            using (var db = new BloggingContext())
            {
                var AllBlogs = db.Blogs.ToList();
                foreach (var Blog in AllBlogs)
                    Blog.Posts = new List<Post>(from x in db.Posts where x.BlogId == Blog.BlogId select x);
                return AllBlogs;
            }
        }
    }
}