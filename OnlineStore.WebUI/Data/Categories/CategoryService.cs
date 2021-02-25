using AutoMapper;
using OnlineStore.WebAPI.Contracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.WebUI.Data.Categories
{
    public class CategoryService
    {
        private readonly HttpClient httpClient;
        private readonly IMapper mapper;
        
        public CategoryService(HttpClient httpClient, IMapper mapper)
        {
            this.httpClient = httpClient;
            this.mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            var response = await httpClient.GetAsync("/api/categories");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var jsonOption = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var categoryContracts = JsonSerializer.Deserialize<List<CategoryContract>>(json, jsonOption);

            return mapper.Map<List<CategoryViewModel>>(categoryContracts);
        }

        public async Task CreateAsync(CategoryViewModel viewModel)
        {
            var response = await httpClient.PostAsJsonAsync("/api/categories", mapper.Map<CategoryContract>(viewModel));
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"/api/categories/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}