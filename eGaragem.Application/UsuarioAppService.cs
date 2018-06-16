using AutoMapper;
using eGaragem.Application.AutoMapper;
using eGaragem.Domain.Entities;
using eGaragem.Infra.Data.Repository;
using eGaragem.Infra.Data.UoW;
using eGaragem.UI.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Application
{
    public class UsuarioAppService
    {
        public UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            if (!usuario.IsValid())
                return usuarioViewModel;

            using (var uow = UnitOfWorkFactory.Create())
            {
                var usuarioRepository = new UsuarioRepository(uow);
                usuarioRepository.Adicionar(usuario);
                usuario.ValidationResult.Message = "Usuário Cadastrado com Sucesso!";
            }
            return new UsuarioViewModel();
        }
    }
}
