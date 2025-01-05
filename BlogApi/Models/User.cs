using BlogApi.Abstractions;

namespace BlogApi.Models
{
    public class User:BaseEntity
    {
      
        public string NameLastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
