using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Domain.AutoMapper
{
    class GitHubProfile : Profile
    {
        public GitHubProfile()
        {
            //Model to ViewModel 
            CreateMap<GitHub, GitHubViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.IdGitHub, opt => opt.MapFrom(src => src.IdGitHub))
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.URL, opt => opt.MapFrom(src => src.URL))
                    .ForMember(dest => dest.Linguagem, opt => opt.MapFrom(src => src.Language))
                    .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.DonoRepositorio, opt => opt.MapFrom(src => src.DonoRepositorio))
                    .ForMember(dest => dest.DtAtualizacao, opt => opt.MapFrom(src => src.DtAtualizacao))
                    .ForMember(dest => dest.Favorito, opt => opt.MapFrom(src => src.Favorite));
        }
    }
}
