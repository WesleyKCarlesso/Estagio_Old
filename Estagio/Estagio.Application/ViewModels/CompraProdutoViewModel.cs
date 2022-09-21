namespace Estagio.Application.ViewModels
{
    public class CompraProdutoViewModel
    {
        public long? IdCompra { get; set; }

        public long? IdProduto { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Valor { get; set; }
    }
}
