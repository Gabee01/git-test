using System;
using System.Collections.Generic;
using GitRepos.Github;
using GitRepos.Github.Interfaces;
using GitRepos.Models;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using Activity = System.Diagnostics.Activity;

namespace GitRepos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGithubService _service;
        public HomeController(GithubReposContext context)
        {
            var githubClient = new GitHubClient(new ProductHeaderValue(Environment.GetEnvironmentVariable("API_ID")));
            _service = new GithubService(context, githubClient);
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
                return PartialView("Repos", _service.FindAndSaveRepos(languages));
            }
            catch (Octokit.ApiValidationException)
            {
                return BadRequest("Github API returned an error");
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
                return PartialView("DetailedRepo", _service.GetInfo(repoId));
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
