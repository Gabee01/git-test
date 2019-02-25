using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitRepos.Github;
using GitRepos.Github.Interfaces;
using GitRepos.Models;
using Microsoft.AspNetCore.Mvc;
using Activity = System.Diagnostics.Activity;

namespace GitRepos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGithubFactory _factory;
        private readonly IGithubService _service;
        private readonly IGithubRepository _repository;
        public HomeController(GithubReposContext context)
        {
            _factory = new GithubFactory();
            _service = new GithubService();
            _repository = new GithubRepository(context);
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult FindStore(List<string> languages)
        {
            try
            {
                var repos = _service.GetReposFromGit(languages);
                var reposModel = _factory.CreateRepos(repos);
                _repository.CreateMany(reposModel);
                return PartialView("Repos", reposModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpGet]
        public IActionResult GetDetails(int repoId)
        {
            try
            {
                return PartialView("DetailedRepo", _repository.FindRepo(repoId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
