using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FluentAssertions;
using GitRepos;
using GitRepos.Github;
using GitRepos.Github.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Octokit;
using Xunit;

namespace git_repos_test
{
    public class ServiceTests
    {
        private readonly IGithubService _service;
        private const int ListSize = 10;

        public ServiceTests()
        {
            //Configure db
            var optionsBuilder =
                new DbContextOptionsBuilder<GithubReposContext>()
                    .UseInMemoryDatabase( "githubReposTestDB");
            var _dbContext = new GithubReposContext(optionsBuilder.Options);

            //Mock octokit
            ReadOnlyCollection<Repository> mockedRepos = new ReadOnlyCollection<Repository>(GetRepos());
            var response = new SearchRepositoryResult(ListSize, false, mockedRepos);
            
            var mockedClient = new Mock<IGitHubClient>();
            mockedClient.Setup(githubService => 
                    githubService.Search.SearchRepo(It.IsAny<SearchRepositoriesRequest>()))
                .Returns(Task.Factory.StartNew(() => response));
            
            //Mount service
            _service = new GithubService(_dbContext, mockedClient.Object);
        }

        private IList<Repository> GetRepos()
        {
            var repos = new List<Repository>();
            for (int i = 1; i <= ListSize; i++)
            {
                var repo = new Repository("fake", "fake", "fake", "fake", "fake", "fake", "fake", i, "fake",
                    new User("fake", "fake", "fake", 0, "fake", DateTimeOffset.Now, DateTimeOffset.Now, 0, "fake", 0, 0,
                        null, "fake", 0, i, "fake",
                        "fake", "fake", "fake", 0, null, 0, 0, 0, "fake", null, false, "fake", null),
                    "fake", "fake", "fake", "fake", "fake", false, false, 10,
                    i + 10, "fake", 0, null, DateTimeOffset.Now,
                    DateTimeOffset.Now, null, null, null, null, false, false, false, false, 10, 21, null, null,
                    null, false);
                
                repos.Add(repo);
            }

            return repos;
        }

        [Fact]
        public void ShouldPersistAndReturnRepos()
        {
            var languages = new List<string>
            {
                Language.Python.ToString()
            };
            
            //Test service with memory db and mocked api
            _service.FindAndSaveRepos(languages)
                .Should().NotContainNulls()
                .And.HaveCount(ListSize);

            //Test retrieving saved repo with random Id
            _service.GetInfo(new Random().Next(1, ListSize))
                .Should().NotBeNull().And.BeOfType(typeof(GitRepos.Models.Repository));
        }
    }
}