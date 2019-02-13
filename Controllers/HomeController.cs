using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using teste.Models;
using Activity = System.Diagnostics.Activity;

namespace teste.Controllers
{
    public class HomeController : Controller
    {
        private GithubFactory _factory;
        public HomeController()
        {
            _factory = new GithubFactory();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult FindStore(List<Language> languages)
        {
            return View("Repos",_factory.CreateRepoForLanguages(languages));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
