namespace GitHub_BackEnd.Entities
{
    public class License : BaseEntity
    {
        public string? key { get; set; }
        public string? name { get; set; }
        public string? spdx_id { get; set; }
        public string? url { get; set; }
        public string? node_id { get; set; }
        public List<GitHubRepository> Repositories { get; set; } = new List<GitHubRepository>();
    }
}
