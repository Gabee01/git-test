using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;

namespace GitRepos.Github
{
    public class GithubFactory : IGithubFactory
    {
        private static GitHubClient _github;

        public GithubFactory()
        {
            _github = new GitHubClient(new ProductHeaderValue(Environment.GetEnvironmentVariable("API_ID")));
        }

        public List<Repository> CreateReposForLanguages(List<string> languages)
        {   
            var repos = languages.SelectMany(language =>
                    _github.Search.SearchRepo(new SearchRepositoriesRequest
                    {
                        Language = Enum.Parse<Language>(language),
                        SortField = RepoSearchSort.Forks
//                        SortField = RepoSearchSort.Stars
                    }).Result.Items.ToList())
                .ToList();
            
            return repos;
        }

        public async Task<Repository> CreateRepoDetails(int repoId)
        {
            return await _github.Repository.Get(repoId);
        }
    }
}