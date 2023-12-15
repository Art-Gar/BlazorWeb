namespace BlazorWeb.Data
{
    public interface IWriteable<T> where T : IVote
    {
        string Body { get; set; }
        string UserId { get; set; }
        ApplicationUser Author { get; set; }
        List<T> Votes { get; set; }

    }
}
