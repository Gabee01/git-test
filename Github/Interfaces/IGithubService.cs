using System.Collections.Generic;
using Octokit;

namespace GitRepos.Github.Interfaces
{
    public interface IGithubService
    {
        List<Repository> GetReposFromGit(List<string> languages);
    }
}