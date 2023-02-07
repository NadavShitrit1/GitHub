using GitHub_BackEnd.Entities;

namespace GitHub_BackEnd.Dtos
{
    public class MyGitHubRepositoryDto
    {
        public string? id { get; set; }
        public string name { get; set; }
        public Owner? owner { get; set; }
        public string? description { get; set; }
        public string? avatar_url { get; set; }
    }
}
