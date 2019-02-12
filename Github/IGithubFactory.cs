using System.Collections.Generic;
using Octokit;

namespace teste
{
    public interface IGithubFactory
    {
        IReadOnlyList<Repository> CreateRepositories();
        Repository GetDescription(int repositoryId);
    }
}