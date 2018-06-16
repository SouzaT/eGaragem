using eGaragem.Domain.Interfaces.Service;
using eGaragem.Domain.Services;
using eGaragem.Infra.Data.Interfaces;
using eGaragem.Infra.Data.UoW;
using SimpleInjector;

namespace eGaragem.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //App
            //Domain
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            //infra dados
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}
