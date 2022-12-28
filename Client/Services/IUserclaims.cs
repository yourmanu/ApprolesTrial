using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ApprolesTrial.Client.Services
{
    public interface IUserclaims
    {
        Task<bool> IsInRole(string roleName);
        Task<List<string>> GetRoles();
        Task<string> GetClaims();
    }

    public class Userclaims : IUserclaims
    {
        private readonly HttpClient _httpClient;

        public Userclaims(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> IsInRole(string roleName)
        {
            var httpResponse = await _httpClient.GetAsync($"Userclaims/isinrole?rolename={roleName}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return result.ToLower().Equals("true");
            }
            return false;
        }

        public async Task<List<string>> GetRoles()
        {
            var httpResponse = await _httpClient.GetAsync($"Userclaims/getroles");
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<string>>(responseString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return result;
            }
            return null;
        }

        public async Task<string> GetClaims()
        {
            var httpResponse = await _httpClient.GetAsync($"Userclaims");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return result;
            }
            return null;
        }
    }

}
