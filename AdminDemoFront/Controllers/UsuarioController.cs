using AdminDemoFront.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminDemoFront.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsuarioController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Token", ""),
                new KeyValuePair<string, string>("callback", "")
            });

            var response = await _httpClient.PostAsync("P_AdminListarUsuarios", formContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<UsuarioResponse>();

                if (result?.ListaEntidadDatos != null)
                {
                    return View(result.ListaEntidadDatos);
                }
            }

            ViewBag.Error = "No se pudieron cargar los usuarios.";
            return View(new List<Usuarios>());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuarios usuario)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Documento", usuario.Documento.ToString()),
                new KeyValuePair<string, string>("Nombres", usuario.Nombres),
                new KeyValuePair<string, string>("Apellidos", usuario.Apellidos),
                new KeyValuePair<string, string>("Direccion", usuario.Direccion ?? ""),
                new KeyValuePair<string, string>("Telefono", usuario.Telefono ?? ""),
                new KeyValuePair<string, string>("Celular", usuario.Celular ?? ""),
                new KeyValuePair<string, string>("Usuario", usuario.Usuario),
                new KeyValuePair<string, string>("Password", usuario.Password),
                new KeyValuePair<string, string>("Email", usuario.Email),
                new KeyValuePair<string, string>("Cargo", usuario.Cargo ?? ""),
                new KeyValuePair<string, string>("Estado", usuario.Estado.ToString().ToLower()),
                new KeyValuePair<string, string>("IdEmpresa", usuario.IdEmpresa.ToString()),
                new KeyValuePair<string, string>("Perfil", usuario.Perfil.ToString()),
                new KeyValuePair<string, string>("Token", ""),
                new KeyValuePair<string, string>("callback", "")
            });

            var response = await _httpClient.PostAsync("P_AdminRegistrarUsuario", formContent);

            if (response.IsSuccessStatusCode)
            {
                return Ok(); // Retornar un estado 200 si el registro fue exitoso
            }

            return BadRequest("Error al crear el usuario.");
        }
    }
}
