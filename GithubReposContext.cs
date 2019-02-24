using GitRepos.Models;
using Microsoft.EntityFrameworkCore;

namespace GitRepos
{
    public class GithubReposContext : DbContext
    {
        public GithubReposContext(DbContextOptions<GithubReposContext> options) : base(options){}
        public DbSet<Repository> Repositories { get; set; }
    }
}