using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Context;

public class NewsletterDb:DbContext
{
    public NewsletterDb(DbContextOptions options):base(options) { }
    public DbSet<User > Users { get; set; }
    public DbSet<Newsletter > Newsletter { get; set; }  

}
