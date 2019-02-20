using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace teste
{
    public interface IGithubFactory
    {
        List<Repository> CreateReposForLanguages(List<string> languages);
        Repository GetDescription(int repositoryId);
    }
}