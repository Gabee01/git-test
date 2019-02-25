using System;
using System.Collections.Generic;
using System.Linq;
using GitRepos.Github.Interfaces;
using Octokit;

namespace GitRepos.Github
{
    public class GithubService : IGithubService
    {
        private static GitHubClient _github;

        public GithubService()
        {
            _github = new GitHubClient(new ProductHeaderValue(Environment.GetEnvironmentVariable("API_ID")));
        }
        
        public List<Repository> GetReposFromGit(List<string> languages)
        {
            var repos = languages.SelectMany(language =>
                    _github.Search.SearchRepo(new SearchRepositoriesRequest
                    {
                        Language = Enum.Parse<Language>(language),
                        SortField = RepoSearchSort.Stars,
                        PerPage = 5
                    }).Result.Items.ToList())
                .ToList();
            return repos;
        }
    }
}