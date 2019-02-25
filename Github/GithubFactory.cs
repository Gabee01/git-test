using System.Collections.Generic;
using System.Linq;
using GitRepos.Github.Interfaces;
using GitRepos.Models;

namespace GitRepos.Github
{
    public class GithubFactory : IGithubFactory
    {
        public List<Repository> CreateRepos(List<Octokit.Repository> octoRepos)
        {
            return octoRepos.GroupBy(repo => repo.Id).Select(grp => grp.First()).Select(octoRepo => new Repository
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
        }
    }
}