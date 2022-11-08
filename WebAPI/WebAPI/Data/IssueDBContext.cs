using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class IssueDBContext : DbContext
    {
        public IssueDBContext(DbContextOptions<IssueDBContext> options)
            : base(options)
        {

        }

        public DbSet<Issue> Issues { get; set; } 
    }
}
