using AutoMapper;
using eGaragem.Domain.Entities;
using eGaragem.UI.Mvc.Models;

namespace eGaragem.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
