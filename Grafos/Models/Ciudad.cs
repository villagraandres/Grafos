namespace Grafos.Models
{
    public class Ciudad
    {

        public int CiudadId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Poblacion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int PaisId { get; set; }
        public Pais? Pais { get; set; }
        public ICollection<Carretera> CarreterasOrigen { get; set; } = new List<Carretera>();
        public ICollection<Carretera> CarreterasDestino { get; set; } = new List<Carretera>();
    }
}
