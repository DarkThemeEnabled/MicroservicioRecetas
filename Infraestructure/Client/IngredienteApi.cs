using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Client
{
    public class IngredienteApi : IIngredienteApi
    {
        private readonly HttpClient _httpClient;

        public IngredienteApi()
        {
            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("https://localhost:7192/api/");
        }

        //Referencia
        //public dynamic GetViajeById(int viajeId)
        //{
        //    HttpResponseMessage response = _httpClient.GetAsync($"Viaje/{viajeId}").Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        dynamic viaje = response.Content.ReadAsAsync<dynamic>().Result;
        //        return viaje;
        //    }
        //    else
        //    {
        //        throw new ExceptionNotFound($"Error al obtener el Viaje. Código de respuesta: {response.StatusCode}");
        //    }
        //}
    }
}
