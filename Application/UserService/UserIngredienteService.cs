using Application.Exceptions;
using Application.Interfaces;

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
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync($"Ingrediente/ById/{Id}").Result;

                //if (response.IsSuccessStatusCode)
                //{

                //}
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ExceptionNotFound("No existe el ingrediente con el id: ");
                }
                dynamic ingrediente = response.Content.ReadAsAsync<dynamic>().Result;
                //string content = response.Content.ReadAsStringAsync().Result;
                //string asd = (string)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                return ingrediente;
            }
            catch (ExceptionNotFound e)
            {
                throw new ExceptionNotFound(e.Message);
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