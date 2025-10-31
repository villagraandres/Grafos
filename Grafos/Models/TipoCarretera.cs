namespace Grafos.Models
{
    public class TipoCarretera
    {

        public int TipoCarreteraId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double VelocidadMaxima { get; set; }
        public double CostoPeajeKm { get; set; }
        public ICollection<Carretera> Carreteras { get; set; } = new List<Carretera>();
    }
}
