using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Data
{
    public class CommentDb : ICommentDb
    {
        private IDbContextFactory<ApplicationDbContext> _dbContext;
        public CommentDb(IDbContextFactory<ApplicationDbContext> db)
        {
            _dbContext = db;
        }
        public async Task AddComment(Comment comment, int postId, string userId)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                comment.PostId = postId;
                context.Comments.Add(comment);
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteComment(int id, string userId)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                context.Comments.Where(c => c.UserId == userId && c.Id == id).ExecuteDelete();
                await context.SaveChangesAsync();
            }
        }
        public async Task HandleCommentVote(int commentId, string userId)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                var commentVote = await context.CommentVotes.FirstOrDefaultAsync(c => c.UserId == userId && c.CommentId == commentId);
                System.Diagnostics.Debug.Print("one vote");
                if(commentVote == null)
                {
                    System.Diagnostics.Debug.Print("two vote");
                    CommentVote newCommentVote = new CommentVote() { CommentId=commentId, UserId=userId  };
                    await context.CommentVotes.AddAsync(newCommentVote);
                } else
                {
                await context.CommentVotes.Where(c => c.UserId == userId && c.CommentId == commentId).ExecuteDeleteAsync();
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
