using System.ComponentModel.DataAnnotations;

namespace RentACar.Domain.Enums
{
    public enum EnumCategoria
    {
        [Display(Name = "Básico")]
        Basico = 1,
        [Display(Name = "Completo")]
        Completo = 2,
        [Display(Name = "Luxo")]
        Luxo = 3
    }
}
