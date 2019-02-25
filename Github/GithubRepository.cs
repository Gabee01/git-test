using System.Collections.Generic;
using System.Linq;
using GitRepos.Github.Interfaces;
using GitRepos.Models;

namespace GitRepos.Github
{ 
    public class GithubRepository : IGithubRepository
    {
        private GithubReposContext _context;

        public GithubRepository(GithubReposContext context)
        {
            _context = context;
        }

        public void SaveMany(List<Repository> repos)
        {
            foreach (var repo in repos)
            {
                if (!_context.Repositories.Any(dbRepo => dbRepo.Id == repo.Id))
                {
                    _context.Repositories.Add(repo);
                }
            }
            
            _context.SaveChanges();
        }

        public Repository FindRepo(int repoId)
        {
            return _context.Repositories.First(repo => repo.Id == repoId);
        }
    }
}