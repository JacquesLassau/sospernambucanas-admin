using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SosWebAdmin.Models
{
    public class Atendente: Usuario
    {
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Código:")]
        [StringLength(5, ErrorMessage = "São permitidos até 5 caracteres.")]
        public int IdAtendente { get; set; }

        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Matricula:")]
        [StringLength(200, ErrorMessage = "São permitidos até 200 caracteres.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Nome:")]
        [StringLength(200, ErrorMessage = "São permitidos até 200 caracteres.")]
        public string Nome { get; set; }
    }
}