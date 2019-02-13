using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace teste
{
    public interface IGithubFactory
    {
        List<Repository> CreateRepoForLanguages(List<Language> languages);
        Repository GetDescription(int repositoryId);
    }
}