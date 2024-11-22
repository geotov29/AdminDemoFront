using System.ComponentModel.DataAnnotations;

namespace AdminDemoFront.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo no válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
