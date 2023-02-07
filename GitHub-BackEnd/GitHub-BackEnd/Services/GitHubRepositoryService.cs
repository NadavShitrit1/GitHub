using AutoMapper;
using GitHub_BackEnd.Dtos;
using GitHub_BackEnd.Entities;
using GitHub_BackEnd.Interfaces;
using Newtonsoft.Json;

namespace GitHub_BackEnd.Services
{
    public class GitHubRepositoryService : IGitHubRepositoryService
    {
        private readonly IMapper _mapper;

        public GitHubRepositoryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<RepositoryToReturnDto> DeserializeAndMap(string result)
        {
            var gitHubSearchResult = JsonConvert.DeserializeObject<GitHubSearchResult>(result);
            var gitHubRepos = gitHubSearchResult.items;
            List<RepositoryToReturnDto> repos = _mapper.Map<List<GitHubRepository>, List<RepositoryToReturnDto>>(gitHubRepos);

            return repos;
        }
    }
}
