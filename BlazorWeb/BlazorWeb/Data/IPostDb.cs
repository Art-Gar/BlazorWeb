using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Data
{
    public interface IPostDb
    {
        public Task AddPost(Post post, string userId);
        public Post[] GetPosts();
    }
}
