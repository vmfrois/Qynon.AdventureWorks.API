namespace Qynon.AdventureWorks.Models
{
    public class PistaCorrida
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public HistoricoCorrida HistoricoCorrida { get; set; }
    }
}
