namespace GitRepos.Models
{
    public class Repository
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }        
    }
}