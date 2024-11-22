namespace AdminDemoFront.Models
{
    public class UsuarioResponse
    {
        public string Mensaje { get; set; }
        public int oEstado { get; set; }
        public List<Usuarios> ListaEntidadDatos { get; set; }
        public object EntidadDatos { get; set; }
        public int IdeEntidad { get; set; }
    }
}
