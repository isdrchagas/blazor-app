using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm.Compartilhado.Entidades
{
    public class Carro : IEntity
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string AnoFabricacao { get; set; }
    }
}
