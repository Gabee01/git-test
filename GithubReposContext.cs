using Microsoft.EntityFrameworkCore;
using teste.Models;

namespace teste
{
    public class GithubReposContext : DbContext
    {
        public GithubReposContext(DbContextOptions<GithubReposContext> options) : base(options){}
        public DbSet<Repository> Repositories { get; set; }
    }
}