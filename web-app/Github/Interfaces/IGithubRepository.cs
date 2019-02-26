using System.Collections.Generic;
using GitRepos.Models;

namespace GitRepos.Github.Interfaces
{
    public interface IGithubRepository
    {
        void SaveMany(List<Repository> repos);
        Repository FindRepo(int repoId);
    }
}