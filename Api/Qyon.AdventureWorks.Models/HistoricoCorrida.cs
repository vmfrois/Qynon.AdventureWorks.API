using System;

namespace Qynon.AdventureWorks.Models
{
    public class HistoricoCorrida
    {
        public int Id { get; set; }
        public int CompetidorId { get; set; }
        public Competidor Competidor { get; set; }
        public int PistaCorridaId { get; set; }
        public PistaCorrida PistaCorrida { get; set; }  
        public DateTime DataCorrida { get; set; }
        public double TempoGasto { get; set; }
    }
}
