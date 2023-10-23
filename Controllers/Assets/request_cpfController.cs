using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Models.PersonModel;

namespace Api.Controllers.Assets
{
    [ApiController]
    [Route("[controller]")]
    public class RequestCpfController : ControllerBase
    {
        [HttpPost("fetchData")]
        public async Task<IActionResult> FetchData(DataInputModel input)
        {
            string cpf = input.CPF;
            string birthdate = input.BirthDate;

            string apiUrl = $"https://api.infosimples.com/api/v2/consultas/receita-federal/cpf?token=dqsOLrFpqNg_K0qTarE1REaJZWI3Ehgz2aWxD5Fn&timeout=600&cpf={cpf}&birthdate={birthdate}&origem=web";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    return Ok(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"{e.Message}");
                    return BadRequest("erro");
                }
            }
        }
    }

    public class DataInputModel
    {
        public string CPF { get; set; }
        public string BirthDate { get; set; }
    }
}
