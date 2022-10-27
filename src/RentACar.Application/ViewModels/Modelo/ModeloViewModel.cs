using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Application.ViewModels
{
    public class ModeloViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter no máximo 50 caracteres")]        
        [DisplayName("Nome")]
        public string Nome { get; set; }

        public MarcaViewModel Marca { get; set; }
    }
}
