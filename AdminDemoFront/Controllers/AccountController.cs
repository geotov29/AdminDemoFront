using AdminDemoFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AdminDemoFront.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Email", model.Email),
                    new KeyValuePair<string, string>("Clave", model.Password),
                    new KeyValuePair<string, string>("callback", "")

                });

                var response = await _httpClient.PostAsync("P_AdminValidarClave", formContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonDocument = await response.Content.ReadFromJsonAsync<JsonDocument>();
                    var root = jsonDocument.RootElement;

                    if (root.TryGetProperty("EntidadDatos", out JsonElement entidadDatosElement) &&
                        !string.IsNullOrEmpty(entidadDatosElement.GetString()) &&
                        int.TryParse(entidadDatosElement.GetString(), out _))
                    {
                        // Lógica para manejar autenticación exitosa
                        return RedirectToAction("Index", "Empleado");
                    }
                }
            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View(model);
        }

    }
}
