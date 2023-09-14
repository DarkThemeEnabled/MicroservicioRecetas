using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Client
{
    public class UsuarioApi : IUsuarioApi
    {
        private readonly HttpClient _httpClient;

        public UsuarioApi()
        {
            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("https://localhost:7192/api/");
        }
    }
}
