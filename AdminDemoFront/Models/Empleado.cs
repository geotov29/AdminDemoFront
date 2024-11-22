namespace AdminDemoFront.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public int IdEntidad { get; set; }
        public string NombreEntidad { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
    }
}
