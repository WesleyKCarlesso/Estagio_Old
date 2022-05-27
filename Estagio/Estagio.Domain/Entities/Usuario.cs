namespace Estagio.Domain.Entities
{
    public class Usuario
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool Admin { get; set; }
    }
}
