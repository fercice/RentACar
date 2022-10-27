using RentACar.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace RentACar.Domain.Entities
{
    public class Modelo : Entity
    {
        // Empty constructor for EF
        protected Modelo() { }

        public string Nome { get; private set; }

        public Marca Marca { get; set; }

        public Guid MarcaId { get; set; }

        public IList<Veiculo> Veiculos { get; set; }
    }
}