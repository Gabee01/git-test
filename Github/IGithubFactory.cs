using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace GitRepos.Github
{
    public interface IGithubFactory
    {
        List<Repository> CreateReposForLanguages(List<string> languages);
        Task<Repository> CreateRepoDetails(int repoId);
    }
}