using GitHub_BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace GitHub_BackEnd.Dtos
{
    public class RepositoryToReturnDto
    {
        public string id { get; set; }
        public string avatar_url { get; set; } = string.Empty;
        [Required]
        public string name { get; set; } = string.Empty;
        public string? description { get; set; } = string.Empty;
        [Required]
        public Owner owner { get; set;} 
    }
}
