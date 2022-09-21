using AutoMapper;
using Estagio.Application.Interfaces;
using Estagio.Domain.Interfaces;

namespace Estagio.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IMapper mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
        }
    }
}
