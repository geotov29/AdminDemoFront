using AdminDemoFront.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminDemoFront.Controllers
{
    public class EntidadController : Controller
    {
        private readonly HttpClient _httpClient;

        public EntidadController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IActionResult> Index()
        {
            // Crear el contenido para el body del POST
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Token", ""),
                new KeyValuePair<string, string>("callback", "")
            });

            // Llamada al API para obtener la lista de entidades
            var response = await _httpClient.PostAsync("P_AdminListarEntidad", formContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<EntidadResponse>();

                if (result?.ListaEntidadDatos != null)
                {
                    return View(result.ListaEntidadDatos);
                }
            }

            ViewBag.Error = "No se pudieron cargar las entidades.";
            return View(new List<Entidad>());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Entidad entidad)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Nombres", entidad.NombreEntidad),
                new KeyValuePair<string, string>("Telefono", entidad.Telefono),
                new KeyValuePair<string, string>("Direccion", entidad.Direccion),
                new KeyValuePair<string, string>("Email", entidad.Email),
                new KeyValuePair<string, string>("Token", ""),
                new KeyValuePair<string, string>("callback", "")
            });

            var response = await _httpClient.PostAsync("P_AdminRegistrarEntidad", formContent);

            if (response.IsSuccessStatusCode)
            {
                return Ok(); // Retornar un estado 200 si el registro fue exitoso
            }

            return BadRequest("Error al crear la entidad.");
        }
    }
}
