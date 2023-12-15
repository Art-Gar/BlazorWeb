using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWeb.Data
{
    public  class PostDb
    {
        private ApplicationDbContext _dbContext;
        PostDb()
        {
            _dbContext = new ApplicationDbContext("");
        }
        public  Post[] GetPosts() { return _dbContext.Posts.ToArray(); }
        public  Post[] CreatePost() { return _dbContext.Posts.ToArray(); }

        public void AddPost( Post post, string userId)
        { 
            post.UserId = userId;
           _dbContext.Posts.Add(post);
        }
    }
}
