using Microsoft.EntityFrameworkCore;

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

        public async Task<Post?> getOnePost(int id)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                Post? post = await context.Posts
                    .Include(p => p.Author)
                    .Include(p => p.Comments.OrderByDescending(c => c.Id)).ThenInclude(c => c.Author)
                    .Include(p => p.Comments.OrderByDescending(c => c.Id)).ThenInclude(c => c.Votes)
                    .Include(c => c.Votes)
                    .FirstOrDefaultAsync(p => p.Id == id);
                return post;
            }
        }
        public async Task AddPost( Post post, string userId)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                post.UserId = userId;
                  context.Posts.Add(post);
                System.Diagnostics.Debug.WriteLine(userId);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdatePost(int id, string userId, string title, string body)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                context.Posts.Where(p => p.UserId == userId && p.Id == id).ExecuteUpdate(setters => setters.SetProperty(p => p.Title, title).SetProperty(p => p.Body, body));
                System.Diagnostics.Debug.WriteLine(userId);
                await context.SaveChangesAsync();
            }
        }
        public async Task DeletePost(int id, string userId)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                context.Posts.Where(p => p.UserId == userId && p.Id == id).ExecuteDelete();
                await context.SaveChangesAsync();
            }
        }
    }
}
