using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserService
{
    public class UserIngredienteService : IUserIngredienteService
    {
        private readonly HttpClient _httpClient;

        public UserIngredienteService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7192/api/");
        }
        public dynamic GetByID(int Id)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Ingrediente/{Id}").Result;

            if (response.IsSuccessStatusCode)
            {
                dynamic ingrediente = response.Content.ReadAsAsync<dynamic>().Result;
                return ingrediente;
            }
            else
            {
                throw new ArgumentException($"Error al obtener el ingrediente. Código de respuesta: {response.StatusCode}");
            }
        }

        public dynamic GetByName(string Name)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Ingrediente/{Name}").Result;

            if (response.IsSuccessStatusCode)
            {
                dynamic ingrediente = response.Content.ReadAsAsync<dynamic>().Result;
                return ingrediente;
            }
            else
            {
                throw new ArgumentException($"Error al obtener el ingrediente. Código de respuesta: {response.StatusCode}");
            }
        }
    }
}