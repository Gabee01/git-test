using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Octokit;

namespace teste
{
    public class GithubFactory : IGithubFactory
    {
        private static GitHubClient _github;

        public GithubFactory()
        {
            _github = new GitHubClient(new ProductHeaderValue("teste-bcredi"));
        }

        public List<Repository> CreateReposForLanguages(List<string> languages)
        {   
            var repos = languages.SelectMany(language =>
                    _github.Search.SearchRepo(new SearchRepositoriesRequest
                    {
                        Language = Enum.Parse<Language>(language),
//                        SortField = 
                    }).Result.Items.ToList())
                .ToList();
            
//            List<teste.Models.Repository> repositories;
//            repos.Select(repo => repositories.Add( new Models.Repository()
//                {
//                    repo.Id,
//                    repo.CreatedAt,
//                    repo.Name,
//                    repo.Url
//                }))
            
            return repos;
        }

        public async Task<Repository> CreateRepoDetails(int repoId)
        {
            return await _github.Repository.Get(repoId);
        }
    }
}