using AutoMapper;
using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Estagio.Domain.Entities;
using Estagio.Domain.Interfaces;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using System;
using System.Collections.Generic;

namespace Estagio.Application.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository compraRepository;
        private readonly IProdutoRepository produtoRepository;
        private readonly IMapper mapper;

        public CompraService(
            ICompraRepository compraRepository, 
            IProdutoRepository produtoRepository,
            IMapper mapper
            )
        {
            this.compraRepository = compraRepository;
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
        }

        public bool RealizarCompra(List<ProdutoViewModel> produtos)
        {
            var compraProdutos = new List<CompraProdutoViewModel>();
            var compraViewModel = new CompraViewModel();
            decimal total = 0;

            foreach(var produto in produtos)
            {
                var compraProduto = new CompraProdutoViewModel() { Quantidade = produto.QuantidadeAFornecer, Valor = produto.Preco * produto.QuantidadeAFornecer};
                compraProdutos.Add(compraProduto);
                
                produto.CompraProdutos = compraProdutos;
                produto.Quantidade -= compraProduto.Quantidade;

                Produto pr = mapper.Map<Produto>(produto);

                produtoRepository.Update(pr);
                total += compraProduto.Valor;
            }

            compraViewModel.CompraProdutos = compraProdutos;
            compraViewModel.Data = DateTime.Now;

            Compra compra = mapper.Map<Compra>(compraViewModel);

            this.compraRepository.Create(compra);
            var qrCode = GerarQRCodePix(total.ToString());

            return true;
        }

        private string GerarQRCodePix(string valor)
        {
            var cobranca = new Cobranca(_chave: "2d034647-57d1-4cda-a97c-b4a2ddce2e2e")
            {
                SolicitacaoPagador = "Pagamento do pix",
                Valor = new Valor
                {
                    Original = valor
                }
            };

            var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Ágili Software", "Londrina - Paraná"));

            var stringToQrCode = payload.GenerateStringToQrCode();

            return stringToQrCode;
        }
    }
}
