using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Data
{
    [Index(nameof(UserId), nameof(CommentId), IsUnique = true)]
    public class CommentVote: IVote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public bool Liked { get; set; }

    }
}
