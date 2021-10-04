using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalidromoWebApi.Entities;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PalindromeApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaliController : ControllerBase
    {
        [HttpPost]
        public string POST(Frase dto)
        {
            string Frase = dto.frase.Replace(" ", String.Empty).ToLower();
            string dato;
            string inverso = "";
            string msg;

            int i = Frase.Length;
            MatchCollection wordColl = Regex.Matches(dto.frase, @"[\W]+");

            for (int x = (i - 1); x >= 0; x--)
            {
                dato = Frase.Substring(x, 1);
                inverso = inverso + dato;
            }

            if (Frase == inverso)
            {msg = "ES PALINDROMO";}
            else
            { msg = "NO ES PALINDROMO";}

            palidromo palindromo = new palidromo()
            {
                palabra = dto.frase,
                status = msg,
                NPalabra = (wordColl.Count + 1)
            };

            string json = JsonSerializer.Serialize(palindromo);

            return json;
        }
    }
}

