using AutoMapper;
using GitHub_BackEnd.Data;
using GitHub_BackEnd.Dtos;
using GitHub_BackEnd.Entities;
using GitHub_BackEnd.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Linq;

namespace GitHub_BackEnd.Controllers
{
    public class GitHubController : BaseController
    {
        private string baseUrl = "https://api.github.com/search/repositories?q=";
        private readonly HttpClient _httpClient;
        IMapper _mapper;
        DataContext _dataContext;
        IGitHubRepositoryService _gitHubRepositoryService;
        public GitHubController(IGitHubRepositoryService gitHubRepositoryService,IHttpClientFactory httpClientFactory, IMapper mapper, DataContext dataContext)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Token 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");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "NadavShitrit1");
            _mapper = mapper;
            _dataContext = dataContext;
            _gitHubRepositoryService= gitHubRepositoryService;
        }

        [HttpGet("GitHubSearchNoAuth")]
        public async Task<ActionResult<List<GitHubRepository>>> SearchNoAuth([FromQuery]string ?repoName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + repoName);

            if (!response.IsSuccessStatusCode)           
            {
                return BadRequest();
            }

            string result = await response.Content.ReadAsStringAsync();

            List<RepositoryToReturnDto> repos = _gitHubRepositoryService.DeserializeAndMap(result);

            return Ok(repos);
        }

        [HttpGet("GitHubSearch")]
        [Authorize]
        public async Task<ActionResult<List<GitHubRepository>>> Search([FromQuery] string? repoName)
        {
            int? userId = GetIdFromToken();
            if (userId == null)
                return BadRequest();

            AppUser user = await _dataContext.Users.FindAsync(userId.Value);
            if (user == null) return BadRequest();

            HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + repoName);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            string result = await response.Content.ReadAsStringAsync();
            List<RepositoryToReturnDto> repos = _gitHubRepositoryService.DeserializeAndMap(result);

            return Ok(repos);

        }

        [Authorize]
        [HttpPost("BookmarkRepo")]
        public async Task<ActionResult<List<GitHubRepository>>> BookmarkRepo([FromBody] MyGitHubRepositoryDto repoToCreate)
        {
            int? userId = GetIdFromToken();
            if (userId == null)
                return BadRequest();

            AppUser user = await _dataContext.Users.FindAsync(userId.Value);
            if (user == null || user.GitHubRepositories?.FirstOrDefault(x => x.name == repoToCreate.name) != null) return BadRequest();


            GitHubRepository repo = _mapper.Map<MyGitHubRepositoryDto, GitHubRepository>(repoToCreate);
            repo.User = user;
            repo.AvatarUrl = repo.owner.avatar_url;

            Owner owner = await _dataContext.Owners.FirstOrDefaultAsync(x => x.gravatar_id == repo.owner.gravatar_id);
            if (owner != null)
            {
                owner.Repositories.Add(repo);
                _dataContext.Owners.Update(owner);
            }
            else
            {

                repo.owner.Repositories.Add(repo);
                _dataContext.Owners.Add(repo.owner);
            }

            if (user.GitHubRepositories == null)
            {
                user.GitHubRepositories = new List<GitHubRepository>();
            }

            user.GitHubRepositories.Add(repo);
            _dataContext.Users.Update(user);

            await _dataContext.SaveChangesAsync();

            if (user.GitHubRepositories.FirstOrDefault(x => x.name == repoToCreate.name) != null) return Ok();

            return BadRequest();
        }

        [HttpDelete("Unbookmark/{repoToRemove}")]
        [Authorize]
        public async Task<ActionResult> Unbookmark([FromRoute] string repoToRemove)
        {
            int? userId = GetIdFromToken();
            if (userId == null)
                return BadRequest();

            AppUser user = await _dataContext.Users.FindAsync(userId.Value);
            if (user == null || user.GitHubRepositories?.FirstOrDefault(x => x.name == repoToRemove) != null) return BadRequest();


            GitHubRepository repo = await _dataContext.GitHubRepositories.FirstOrDefaultAsync(x => x.name == repoToRemove);
            _dataContext.GitHubRepositories.Remove(repo);
            await _dataContext.SaveChangesAsync();
            return Ok("Remove Complete");
        }


        [Authorize]
        [HttpGet("GetUserRepos")]
        public async Task<ActionResult<List<GitHubRepository>>> GetUserRepos()
        {
            int? userId = GetIdFromToken();
            if (userId == null)
                return BadRequest();

            AppUser user = await _dataContext.Users.FindAsync(userId.Value);

            IReadOnlyList<GitHubRepository> result = _dataContext.GitHubRepositories.Where(x => x.UserId == user.Id).ToList();
            IReadOnlyList<RepositoryToReturnDto> reposes = _mapper.Map<IReadOnlyList<GitHubRepository>, IReadOnlyList<RepositoryToReturnDto>>(result as IReadOnlyList<GitHubRepository>);


            return Ok(reposes);
        }

    }
}
