namespace WebApplication5
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        } 

        public async Task<string> GetMBAOptionsAsync()
        {
            var endpoint = "https://api.opendata.esett.com/EXP04/MBAOptions";
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }

            return null;
        }
    }
}
