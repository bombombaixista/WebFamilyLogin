using System.ComponentModel.DataAnnotations;

namespace WebFamilyLogin.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string? SenhaHash { get; set; }

        [Required]
        public string Role { get; set; } = "Cliente"; // Admin, Gestor, Cliente

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
