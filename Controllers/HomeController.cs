using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
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
        
        [HttpPost]
        public IActionResult FindStore(List<string> languages)
        {
//            var repos = _factory.CreateReposForLanguages(languages);
//            return View();
            return PartialView("Repos",_factory.CreateReposForLanguages(languages));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
