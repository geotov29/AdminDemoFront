using AdminDemoFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace AdminDemoFront.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmpleadoController(IHttpClientFactory httpClientFactory)
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

            var response = await _httpClient.PostAsync("P_AdminListarEmpleados", formContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<EmpleadoResponse>();

                if (result?.ListaEntidadDatos != null)
                {
                    return View(result.ListaEntidadDatos);
                }
            }

            ViewBag.Error = "No se pudieron cargar los datos.";
            return View(new List<Empleado>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Empleado empleado)
        {
            string estadoString = empleado.Estado ? "true" : "false";
            // Crear los datos para enviar como FormUrlEncodedContent
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("IdEmpleado", empleado.IdEmpleado.ToString()),
                new KeyValuePair<string, string>("IdEntidad", empleado.IdEntidad.ToString()),
                new KeyValuePair<string, string>("Nombres", empleado.Nombres),
                new KeyValuePair<string, string>("Apellidos", empleado.Apellidos),
                new KeyValuePair<string, string>("Documento", empleado.Documento),
                new KeyValuePair<string, string>("Email", empleado.Email),
                new KeyValuePair<string, string>("Estado", estadoString),
                new KeyValuePair<string, string>("Token", ""),       // Campo Token vacío
                new KeyValuePair<string, string>("callback", "")     // Campo callback vacío
            });

            // Aquí envías el empleado actualizado a tu API
            var response = await _httpClient.PostAsJsonAsync("P_AdminActualizarEmpleado", formContent);

            if (response.IsSuccessStatusCode)
            {
                return Ok(); // Retornar un estado 200 si la actualización fue exitosa
            }

            return BadRequest("Error al actualizar el empleado.");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Empleado empleado)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Nombres", empleado.Nombres),
                new KeyValuePair<string, string>("Apellidos", empleado.Apellidos),
                new KeyValuePair<string, string>("Documento", empleado.Documento.ToString()),
                new KeyValuePair<string, string>("Email", empleado.Email),
                new KeyValuePair<string, string>("Estado", empleado.Estado.ToString().ToLower()),
                new KeyValuePair<string, string>("IdEntidad", empleado.IdEntidad.ToString()),
                new KeyValuePair<string, string>("Token", ""),
                new KeyValuePair<string, string>("callback", "")
            });

            var response = await _httpClient.PostAsync("P_AdminRegistrarEmpleado", formContent);

            if (response.IsSuccessStatusCode)
            {
                return Ok(); // Retornar un estado 200 si el registro fue exitoso
            }

            return BadRequest("Error al crear el empleado.");
        }
    }
}
