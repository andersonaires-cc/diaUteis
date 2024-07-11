using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calendarioAPI.models;
using calendarioAPI.services;
using Microsoft.AspNetCore.Mvc;

namespace calendarioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarioController : ControllerBase
    {
        private readonly CalendarioService _calendarioService;
        public CalendarioController(CalendarioService calendarioService)
        {
            _calendarioService = calendarioService;
        }

        [HttpGet]
        public IActionResult getCalendario()
        {
            var calendarios = _calendarioService.GetCalendarios();

            return Ok(calendarios);
        }

        [HttpPost]
        public async  Task<IActionResult> postCalendario(DateTime dataInicio, DateTime dataFinal,Calendario calendario)
        {
            var result = await  _calendarioService.PostCalendario(dataInicio,dataFinal,calendario);
            return Ok(result);

        }
        

    }
}