using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWeb.Data
{
    public class Comment: IWriteable<CommentVote>
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(max)")]

        public string Body { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public Post Post {  get; set; }
        public ApplicationUser Author { get; set; }
        public Comment(string body, string UserId, string postId) {
            Body = body;
            this.UserId = UserId;
            this.PostId = postId;
        }
        public List <CommentVote> Votes { get; set; }
    }
}
