using System.Collections.Generic;
using Octokit;

namespace teste
{
    public class GithubFactory : IGithubFactory
    {
        private static GitHubClient _github;

        public GithubFactory()
        {
            _github = new GitHubClient;
        }
        
        public IReadOnlyList<Repository> CreateRepositories()
        {
            var autoGrow = _github.Repository.GetAllForUser("Gabee01");

            return await autoGrow;
        }

        public Repository GetDescription(int repositoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}