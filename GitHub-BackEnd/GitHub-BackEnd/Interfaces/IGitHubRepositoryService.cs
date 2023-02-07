using GitHub_BackEnd.Dtos;

namespace GitHub_BackEnd.Interfaces
{
    public interface IGitHubRepositoryService
    {
        public List<RepositoryToReturnDto> DeserializeAndMap(string result);


    }
}
