namespace GitHub_BackEnd.Entities
{
    public class GitHubSearchResult : BaseEntity
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<GitHubRepository> items { get; set; }
    }
}
