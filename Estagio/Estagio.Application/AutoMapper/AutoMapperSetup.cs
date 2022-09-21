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
            CreateMap<CompraViewModel, Compra>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<CompraProdutoViewModel, CompraProduto>();

            #endregion

            #region DomainToViewModel

            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Compra, CompraViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<CompraProduto, CompraProdutoViewModel>();

            #endregion
        }
    }
}
