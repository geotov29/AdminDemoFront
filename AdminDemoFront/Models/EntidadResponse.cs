namespace AdminDemoFront.Models
{
    public class EntidadResponse
    {
        public string Mensaje { get; set; }
        public int oEstado { get; set; }
        public List<Entidad> ListaEntidadDatos { get; set; }
        public object EntidadDatos { get; set; }
        public int IdeEntidad { get; set; }
    }
}
