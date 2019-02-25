namespace GitRepos.Models
{
    public class Repository
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public int StargazersCount { get; set; }
        public string GitUrl { get; set; }
        public string FullName { get; set; }
        public string OwnerHtmlUrl { get; set; }
        public string HtmlUrl { get; set; }
        public string Description { get; set; }
    }
}