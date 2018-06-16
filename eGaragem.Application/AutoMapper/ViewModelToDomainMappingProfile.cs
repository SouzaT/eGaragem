using AutoMapper;
using eGaragem.Domain.Entities;
using eGaragem.UI.Mvc.Models;

namespace eGaragem.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
