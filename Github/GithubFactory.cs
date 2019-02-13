using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public Repository GetDescription(int repositoryId)
        {
            throw new System.NotImplementedException();
        }

        public List<Repository> CreateRepoForLanguages(List<Language> languages)
        {
            return languages.SelectMany(language =>
                    _github.Search.SearchRepo(new SearchRepositoriesRequest(language.ToString())).Result.Items.ToList())
                .ToList();
        }
    }
}