using System.Collections.Generic;

namespace Qynon.AdventureWorks.Models
{
    public class Competidor
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public double TemperaturaMediaCorpo { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public ICollection<HistoricoCorrida> HistoricoCorridas { get; set; }
    }
}
