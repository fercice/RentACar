using RentACar.Domain.Core.Entities;
using System.Collections.Generic;

namespace RentACar.Domain.Entities
{
    public class Marca : Entity
    {
        // Empty constructor for EF
        protected Marca() { }

        public string Nome { get; private set; }

        public IList<Modelo> Modelos { get; set; }

        public IList<Veiculo> Veiculos { get; set; }
    }
}