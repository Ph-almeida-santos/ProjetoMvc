using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEmMVC.Models
{
    public class FormularioCliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A empresa é obrigatória.")]
        public string Empresa { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(2000, ErrorMessage = "A descrição pode ter no máximo 1000 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; }
    }
}
