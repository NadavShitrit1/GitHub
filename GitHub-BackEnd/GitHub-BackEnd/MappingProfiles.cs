using AutoMapper;
using GitHub_BackEnd.Dtos;
using GitHub_BackEnd.Entities;

namespace GitHub_BackEnd
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<LoginDto, AppUser>();


            CreateMap<MyGitHubRepositoryDto, GitHubRepository>();
            
            CreateMap<GitHubRepositoryDto, GitHubRepository>().ForMember(x => x.Id, o => o.Ignore());
            
            CreateMap<GitHubRepository, GitHubRepositoryDto>().ForMember(x => x.id, o => o.MapFrom(s => s.GitHubId));

            CreateMap<RepositoryToReturnDto, GitHubRepository>()
                .ForMember(x => x.name, o => o.MapFrom(s => s.name))
                .ForMember(x => x.description, o => o.MapFrom(s => s.description))
                .ForMember(x => x.AvatarUrl, o => o.MapFrom(s => s.avatar_url))
                .ForMember(x => x.owner, o => o.MapFrom(s => s.owner));
            
            CreateMap<GitHubRepository, RepositoryToReturnDto>().ForMember(x => x.id, o => o.MapFrom(s => s.GitHubId));

        }
    }
}
