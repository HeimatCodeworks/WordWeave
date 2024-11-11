using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WordWeave.Services
{
    public class FirestoreService
    {
        private readonly HttpClient _httpClient;
        private readonly string _projectId;

        public FirestoreService()
        {
            _httpClient = new HttpClient();
            _projectId = "wordweave-65ace";
        }

        public async Task<string> GetDocumentAsync(string collection, string documentId)
        {
            var url = $"https://firestore.googleapis.com/v1/projects/{_projectId}/databases/(default)/documents/{collection}/{documentId}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            else
            {
                throw new Exception("Failed to retrieve document from Firestore");
            }
        }

        public async Task<bool> SetDocumentAsync(string collection, string documentId, object data)
        {
            var url = $"https://firestore.googleapis.com/v1/projects/{_projectId}/databases/(default)/documents/{collection}/{documentId}";
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }
}