using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    class TodosService
    {
        private HttpClient httpClient;
        private Post post;
        private List<Post> posts;
        private JsonSerializerOptions jsonSerializerOptions;

        public TodosService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Post>> getTodos()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/todos");
            ObservableCollection<Post> items = new ObservableCollection<Post>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, jsonSerializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return items;
        }
    }


}

