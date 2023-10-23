using Api.Models.ModelsForExternalApis;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers.Assets
{
    [Route("api/[controller]")]
    [ApiController]
    public class request_cnpjController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public request_cnpjController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("fetchData/{id}")]
        public async Task<IActionResult> FetchData(string id)
        {
            string cnpj = id;
            string apiUrl = $"https://api.cnpja.com/office/{cnpj}";

            string authToken = _configuration["MY_TOKEN_AUTHORIZATION"];

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", authToken);
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    Company.EmpresaInfo empresaInfo = JsonConvert.DeserializeObject<Company.EmpresaInfo>(responseBody);

                    var resultado = new
                    {
                        nome = empresaInfo.alias,
                        razao = empresaInfo.company.name,
                        ibge = empresaInfo.address.municipality,
                        cep = empresaInfo.address.zip,
                        endereco = empresaInfo.address.details,
                        bairro = empresaInfo.address.district,
                        ddd = empresaInfo.phones[0].area,
                        telcom = empresaInfo.phones[0].number,
                        email = empresaInfo.emails[0].address
                    };

                    return Ok(resultado);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"{e.Message}");
                    return BadRequest($"Erro: {e.Message}");
                }
            }
        }
    }
}
