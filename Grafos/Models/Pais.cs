namespace Grafos.Models
{
    public class Pais
    {

        public int PaisId {  get; set; }
        public string Nombre {  get; set; } = string.Empty;
        public ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();
    }
}
