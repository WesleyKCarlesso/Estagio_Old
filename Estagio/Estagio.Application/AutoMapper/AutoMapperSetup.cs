using AutoMapper;
using Estagio.Application.ViewModels;
using Estagio.Domain.Entities;

namespace Estagio.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UsuarioViewModel, Usuario>();

            #endregion

            #region DomainToViewModel

            CreateMap<Usuario, UsuarioViewModel>();

            #endregion
        }
    }
}
