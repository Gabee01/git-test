using System.Collections.Generic;
using Octokit;

namespace GitRepos.Github.Interfaces
{
    public interface IGithubService
    {
        Models.Repository GetInfo(int repoId);
        List<Models.Repository> FindAndSaveRepos(List<string> languages);
    }
}