using Application.Exceptions;
using Application.Interfaces;
using Azure;
using Newtonsoft.Json.Linq;

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
                //string jsonContent = response.Content.ReadAsStringAsync().Result;
                //dynamic dynamicData = JObject.Parse(jsonContent);
                //string pruba = ($"name: {dynamicData.name}");

                return ingrediente;
            }
            catch (ExceptionNotFound e)
            {
                throw new ExceptionNotFound(e.Message);
            }
            //Al parecer esto devuelve la excepcion que da el error :O
            //catch (HttpRequestException e)
            //{
            //    Console.WriteLine("\nException Caught!");
            //    Console.WriteLine("Message :{0} ", e.Message);
            //}
        }

        public string GetIngredienteName(int Id)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Ingrediente/ById/{Id}").Result;
            string jsonContent = response.Content.ReadAsStringAsync().Result;
            dynamic dynamicData = JObject.Parse(jsonContent);
            return ($"{dynamicData.name}");
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