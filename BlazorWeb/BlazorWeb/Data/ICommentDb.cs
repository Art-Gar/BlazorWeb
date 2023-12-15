using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Data
{
    public interface ICommentDb
    {
        public Task AddComment(Comment comment, int postId, string userId);
    }
}
