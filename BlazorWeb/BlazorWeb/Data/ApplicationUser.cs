using Microsoft.AspNetCore.Identity;

namespace BlazorWeb.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<CommentVote> CommentVotes { get; set; }
        public virtual List<PostVote> PostVotes { get; set; }
    }

}
