using RentACar.Domain.Core.Entities;
using RentACar.Domain.Enums;
using System;

namespace RentACar.Domain.Entities
{
    public class Veiculo : Entity
    {
        // Empty constructor for EF
        protected Veiculo() { }

        public string Placa { get; private set; }        

        public Marca Marca { get; set; }

        public Modelo Modelo { get; set; }

        public long Ano { get; set; }        

        public EnumCombustivel Combustivel { get; set; }

        public EnumCategoria Categoria { get; set; }

        public double ValorHora { get; set; }

        public double LimitePortaMalas { get; set; }

        public Guid MarcaId { get; set; }

        public Guid ModeloId { get; set; }
    }
}