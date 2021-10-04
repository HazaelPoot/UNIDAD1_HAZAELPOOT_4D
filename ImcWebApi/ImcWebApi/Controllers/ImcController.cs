using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace ImcApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImcController : ControllerBase
    {
        [HttpGet("{Peso}/{Altura}")]
        public string Get(double peso, double altura)
        {
            Imcs oimc = new Imcs();

            oimc.peso = peso;
            oimc.altura = altura;
            oimc.operacion = (peso / (altura * altura));

            if (oimc.operacion > 25 && oimc.operacion < 29.9)
            { 
                oimc.result = "Indice de masa corporal Alto"; 
            }
            else if (oimc.operacion > 18.5 && oimc.operacion < 24.9)
            {
                oimc.result = "Indice de masa corporal Normal"; 
            }
            else if (oimc.operacion < 18.5)
            {
                oimc.result = "Indice de masa corporal Bajo"; 
            }
            else
            {
                oimc.result = "Indice de masa corporal Fuera del rango"; 
            }

            return $"El Indice de Masa Corporal es de: {Math.Round(oimc.operacion, 2)} : {oimc.result}";
        }
    }
}
