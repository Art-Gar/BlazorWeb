using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWeb.Data
{
    public class Comment: IWriteable<CommentVote>
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(max)")]

        public string Body { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public Post Post {  get; set; }
        public ApplicationUser Author { get; set; }
        public List <CommentVote> Votes { get; set; }
        [Timestamp]
        public DateTime? CreatedAt { get; set;}

    }
}
