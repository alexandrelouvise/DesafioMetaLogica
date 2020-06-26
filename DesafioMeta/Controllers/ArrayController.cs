using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioMeta.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayController : ControllerBase
    {
        private readonly IArrayAppService _arrayAppService;

        public ArrayController(IArrayAppService arrayAppService)
        {
            _arrayAppService = arrayAppService;
        }

        [HttpGet]
        [Route("ObterIndiceDoArray")]
        public List<int> ObterIndiceDoArray(int numeroAlvo)
        {
            return _arrayAppService.ObterIndiceDoArray(numeroAlvo);
        }

        [HttpGet]
        [Route("Brackets")]
        public string Brackets(string brackets)
        {
            return _arrayAppService.Brackets(brackets);
        }

        [HttpPost]
        [Route("CompraVendaAcoes")]
        public string CompraVendaAcoes(string codigoUsuario, int dia)
        {
            return _arrayAppService.CompraVendaAcoes(codigoUsuario, dia);
        }

        [HttpPost]
        [Route("CalcularAguaRetida")]
        public int CalcularAguaRetida([FromBody] int?[] numeros)
        {
            return _arrayAppService.CalcularAguaRetida(numeros);
        }


    }
}