using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebFamilyLogin.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string? SenhaHash { get; set; }

        // GrupoId agora é opcional (nullable)
        public int? GrupoId { get; set; }
        public Grupo? Grupo { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
