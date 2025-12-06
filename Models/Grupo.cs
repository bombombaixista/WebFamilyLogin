namespace WebFamilyLogin.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }

        // Relacionamento: um grupo pode ter vários clientes
        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
