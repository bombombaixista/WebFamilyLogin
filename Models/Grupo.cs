using System.ComponentModel.DataAnnotations;

namespace WebFamilyLogin.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // Relacionamento: um grupo pode ter vários clientes
        public ICollection<Cliente>? Clientes { get; set; }
    }
}
