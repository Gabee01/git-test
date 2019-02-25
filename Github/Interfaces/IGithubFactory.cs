using System.Collections.Generic;
using GitRepos.Models;

namespace GitRepos.Github.Interfaces
{
    public interface IGithubFactory
    {
        List<Repository> CreateRepos(List<Octokit.Repository> octoRepos);
//        List<Repository> CreateReposByLanguage(List<string> languages);
//        Task<Repository> GetRepo(int repoId);
    }
}