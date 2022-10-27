using System.ComponentModel.DataAnnotations;

namespace RentACar.Domain.Enums
{
    public enum EnumCombustivel
    {
        [Display(Name = "Gasolina")]
        Gasolina = 1,
        [Display(Name = "Álcool")]
        Alcool = 2,
        [Display(Name = "Diesel")]
        Diesel = 3
    }
}
