namespace Grafos.Models
{
    public class Carretera
    {

        public int CarreteraId { get; set; }
        public int CiudadOrigenId { get; set; }
        public Ciudad? CiudadOrigen { get; set; }
        public int CiudadDestinoId { get; set; }
        public Ciudad? CiudadDestino { get; set; }
        public double DistanciaKm { get; set; }
        public double TiempoEstimado { get; set; }
        public int TipoCarreteraId { get; set; }
        public TipoCarretera? Tipo { get; set; }
        public bool Estado { get; set; } = true;
    }
}
