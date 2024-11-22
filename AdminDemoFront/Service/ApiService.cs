namespace AdminDemoFront.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://18.224.112.120:5003/Demo_AdminService.asmx/");
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<T>()
                : default;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data)
        {
            return await _httpClient.PostAsJsonAsync(endpoint, data);
        }
    }
}
