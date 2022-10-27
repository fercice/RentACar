using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Application.ViewModels
{
    public class ModeloUpdateViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter no máximo 50 caracteres")]        
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Id da Marca é obrigatório")]
        public Guid MarcaId { get; set; }
    }
}
