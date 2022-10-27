using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Domain.Core.Models
{
    public class Model
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
