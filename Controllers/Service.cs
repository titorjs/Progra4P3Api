using PruebaP3.Model;

namespace PruebaP3.Controllers
{
    public class Service
    {
        public string _baseUrl = "172.31.52.164:5078/api/";
        public HttpClient _httpClient;

        public Service()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Tarea>> GetAll()
        {
            var respuesta = await _httpClient.GetFromJsonAsync<List<Tarea>>($"Tarea");
            if (respuesta == null)
            {
                return new List<Tarea>();
            }
            return respuesta;
        }

        public async Task<List<Tarea>> Find(string nombre, string estado)
        {
            var respuesta = await _httpClient.GetFromJsonAsync<List<Tarea>>($"Tarea/{nombre}/{estado}");
            if (respuesta == null)
            {
                return new List<Tarea>();
            }
            return respuesta;
        }

        public async Task<bool> Add(Tarea nueva)
        {
            var respueta = _httpClient.PostAsJsonAsync<Tarea>($"Tarea", nueva);
            return respueta != null;
        }
    }
}
