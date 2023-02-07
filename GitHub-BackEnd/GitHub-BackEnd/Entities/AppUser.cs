using System.ComponentModel.DataAnnotations;

namespace GitHub_BackEnd.Entities
{
    public class AppUser : BaseEntity
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public byte[] PasswordHash { get; set; } 
        [Required]
        public byte[] PasswordSalt { get; set; }
        public List<GitHubRepository> GitHubRepositories { get; set; }     


    }
}
