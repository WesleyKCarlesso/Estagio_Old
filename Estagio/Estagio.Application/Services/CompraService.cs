using AutoMapper;
using Estagio.Application.Interfaces;
using Estagio.Domain.Interfaces;

namespace Estagio.Application.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository compraRepository;
        private readonly IMapper mapper;

        public CompraService(ICompraRepository compraRepository, IMapper mapper)
        {
            this.compraRepository = compraRepository;
            this.mapper = mapper;
        }
    }
}
