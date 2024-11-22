namespace AdminDemoFront.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public long Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public bool Estado { get; set; }
        public int IdEmpresa { get; set; }
        public string NombreControl { get; set; }
        public string Empresa { get; set; }
        public int IdEstacionamiento { get; set; }
        public int Perfil { get; set; }
    }
}
