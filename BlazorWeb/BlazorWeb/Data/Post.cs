using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorWeb.Data
{
    public class Post: IWriteable<PostVote>
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Body { get; set; }
        public string UserId { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual List<PostVote> Votes { get; set; }
        [Timestamp]
        public DateTime? CreatedAt { get; set;}
    }
}
