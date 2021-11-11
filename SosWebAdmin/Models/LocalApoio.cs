using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SosWebAdmin.Models
{
    public class LocalApoio
    {
        [DisplayName("Código:")]
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        public int IdLocal { get; set; }

        [DisplayName("Latitude:")]
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "São permitidos até 200 caracteres.")]
        public string Latitude { get; set; }

        [DisplayName("Longitude:")]
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "São permitidos até 200 caracteres.")]
        public string Longitude { get; set; }

        [DisplayName("Número:")]
        [StringLength(14, ErrorMessage = "São permitidos até 14 caracteres.")]
        public string NumeroEndereco { get; set; }

        [DisplayName("Endereço:")]
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "São permitidos até 200 caracteres.")]
        public string Endereco { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "São permitidos até 200 caracteres.")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "São permitidos até 200 caracteres.")]
        public string Cidade { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200)]
        public string Estado { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [StringLength(9, ErrorMessage = "São permitidos até 9 caracteres.")]
        [RegularExpression(@"[0-9]{5}\-[0-9]{3}", ErrorMessage = "Digite no formato 00000-000")]
        public string Cep { get; set; }
                
        [DisplayName("Telefone:")]
        [StringLength(14, ErrorMessage = "Devem ser incluídos 14 caracteres.")]
        [MaxLength(14, ErrorMessage = "Preenchimento máximo de 14 caracteres.")]
        [MinLength(14, ErrorMessage = "Preenchimento mínimo de 14 caracteres.")]
        [RegularExpression(@"\(?[0-9]{2}\)?[0-9]{5}\-?[0-9]{4}", ErrorMessage = "Digite no formato (00)00000-0000")]
        public string Telefone { get; set; }
    }
}