using AutoMapper;
using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Estagio.Domain.Entities;
using Estagio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

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

        public List<ProdutoViewModel> GetAll()
        {
            List<ProdutoViewModel> produtosViewModel = new List<ProdutoViewModel>();

            IEnumerable<Produto> produtos = this.produtoRepository.GetAll();

            produtosViewModel = mapper.Map<List<ProdutoViewModel>>(produtos);

            return produtosViewModel;
        }
        
        public List<ProdutoViewModel> GetProdutosParaCompra()
        {
            IEnumerable<Produto> produtos = this.produtoRepository.GetAll();

            List<ProdutoViewModel>  produtosViewModel = mapper.Map<List<ProdutoViewModel>>(produtos);

            produtosViewModel = produtosViewModel.Where(x => x.Quantidade > 0).ToList();

            return produtosViewModel;
        }

        public List<ProdutoViewModel> GetProdutosEstoque()
        {
            IEnumerable<Produto> produtos = this.produtoRepository.GetAll();

            List<ProdutoViewModel> produtosViewModel = mapper.Map<List<ProdutoViewModel>>(produtos);

            return produtosViewModel;
        }

        public bool Post(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel.Id != 0)
                throw new Exception("ProdutoId precisa estar vazio");

            produtoViewModel.Ativo = true;

            Validator.ValidateObject(produtoViewModel, new ValidationContext(produtoViewModel), true);

            Produto produto = mapper.Map<Produto>(produtoViewModel);

            this.produtoRepository.Create(produto);

            return true;
        }

        public bool Put(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel.Id == 0)
            {
                throw new Exception("ID não é válido");
            }

            Produto produto = this.produtoRepository.Find(x => x.Id == produtoViewModel.Id && x.Ativo);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            produto = mapper.Map<Produto>(produtoViewModel);

            this.produtoRepository.Update(produto);

            return true;
        }

        public bool Delete(long id)
        {
            return this.produtoRepository.Delete(id);
        }

        public bool RealizarCompraEstoque(List<ProdutoViewModel> produtos)
        {
            foreach (var produto in produtos)
            {
                produto.Quantidade += produto.QuantidadeAFornecer;
                Produto pr = mapper.Map<Produto>(produto);
                produtoRepository.Update(pr);
            }

            return true;
        }
    }
}
