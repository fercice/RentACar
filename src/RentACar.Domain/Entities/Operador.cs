using RentACar.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Domain.Entities
{
    public class Operador : Entity
    {
        // Empty constructor for EF
        protected Operador() { }

        public string Nome { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Matricula { get; private set; }       
    }
}