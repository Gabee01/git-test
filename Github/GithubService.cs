using System;
using System.Collections.Generic;
using System.Linq;
using GitRepos.Github.Interfaces;
using Octokit;
using Repository = GitRepos.Models.Repository;

namespace GitRepos.Github
{
    public class GithubService : IGithubService
    {
        private static IGithubRepository _repository;
        private static GitHubClient _github;

        public GithubService(GithubReposContext context)
        {
            _repository = new GithubRepository(context);
            _github = new GitHubClient(new ProductHeaderValue(Environment.GetEnvironmentVariable("API_ID")));
        }

        public List<Repository> FindAndSaveRepos(List<string> languages)
        {
            //Get from api
            var repos = languages.SelectMany(language =>
                    _github.Search.SearchRepo(new SearchRepositoriesRequest
                    {
                        Language = Enum.Parse<Language>(language),
                        SortField = RepoSearchSort.Stars,
                        PerPage = 5
                    }).Result.Items.ToList())
                .ToList();
            
            //Parse to model
            var reposModel = repos.GroupBy(repo => repo.Id).Select(grp => grp.First()).Select(octoRepo => new Repository
            {
                Id = octoRepo.Id,
                Name = octoRepo.Name,
                CreatedAt = octoRepo.CreatedAt.ToUnixTimeSeconds(),
                UpdatedAt = octoRepo.UpdatedAt.ToUnixTimeSeconds(),
                StargazersCount = octoRepo.StargazersCount,
                GitUrl = octoRepo.GitUrl,
                Language = octoRepo.Language,
                FullName = octoRepo.FullName,
                OwnerHtmlUrl = octoRepo.Owner.HtmlUrl,
                HtmlUrl = octoRepo.HtmlUrl,
                Description = octoRepo.Description
            }).ToList();
            
            //Persist on db
            _repository.SaveMany(reposModel);

            return reposModel;
        }

        public Repository GetInfo(int repoId)
        {
            return _repository.FindRepo(repoId);
        }
    }
}