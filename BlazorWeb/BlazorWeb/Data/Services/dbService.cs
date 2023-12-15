using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Data.Services
{
    public class dbService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public dbService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public Post[] GetPosts() { using (var context = _dbContextFactory.CreateDbContext()) return context.Posts.ToArray(); }
        public Post[] CreatePost()  { using (var context = _dbContextFactory.CreateDbContext()) return context.Posts.ToArray(); }

        public void AddPost(Post post, string userId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
                post.UserId = userId;
            context.Posts.Add(post);
        }
    }
}
