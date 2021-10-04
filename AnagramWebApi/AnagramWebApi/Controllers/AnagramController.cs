using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnagramaWebApi.Entities;
using System.Text.Json;
using AnagramWebApi.Entities;

namespace AnagramWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnagramController : ControllerBase
    {
        [HttpPost]
        public string POST(Palabra dto)
        {
            string palabra1 = String.Concat(dto.Palabra1.ToLower().OrderBy(c => c));
            string palabra2 = String.Concat(dto.Palabra2.ToLower().OrderBy(c => c));
            string msg;

            if (palabra1 == palabra2)
            {msg = "Palbras son Anagramas";}
            else
            {msg = "No Son Anagramas, Intenta con estas: ";}

            Anagrama anagrama = new Anagrama()
            {
                Pal1 = dto.Palabra1,
                Pal2 = dto.Palabra2,
                Estatus = msg,
            };

            string json = JsonSerializer.Serialize(anagrama);

            return json;
        }
    }
}