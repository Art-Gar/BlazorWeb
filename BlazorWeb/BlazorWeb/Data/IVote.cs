namespace BlazorWeb.Data
{
    public interface IVote
    {
        bool Liked {  get; set; }
        string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
