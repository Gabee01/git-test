using System.Collections.Generic;
using System.Threading.Tasks;
using GitRepos.Github;
using GitRepos.Models;
using Microsoft.AspNetCore.Mvc;
using Activity = System.Diagnostics.Activity;

namespace GitRepos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGithubFactory _factory;
        public HomeController()
        {
            _factory = new GithubFactory();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult FindStore(List<string> languages)
        {
            return PartialView("Repos",_factory.CreateReposForLanguages(languages));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetDetails(int repoId)
        {
            return PartialView("DetailedRepo",await _factory.CreateRepoDetails(repoId));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
