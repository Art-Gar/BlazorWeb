using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Data
{
    public interface IPostDb
    {
        public void AddPost(Post post, string userId);
        public Post[] GetPosts();
    }
}
