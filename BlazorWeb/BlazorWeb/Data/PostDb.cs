using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWeb.Data
{
    public  class PostDb: IPostDb
    {
        private IDbContextFactory<ApplicationDbContext> _dbContext;
        public PostDb(IDbContextFactory<ApplicationDbContext> db) {
            _dbContext = db;
        }
        public  Post[] GetPosts() {
            using (var context = _dbContext.CreateDbContext()) {
                return context.Posts.ToArray();
            }
        }


        public void AddPost( Post post, string userId)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                post.UserId = userId;
                Console.WriteLine(post);
                   context.Posts.Add(new Post { UserId: "3d52c705-9bf7-4c93-bd99-d5501afac6d3", });
                context.SaveChanges();
            }

        }
    }
}
