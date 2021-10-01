using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nuevaApiClientes.Context;
using nuevaApiClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nuevaApiClientes.Controllers
{
    [Route("api/cuenta_corriente")]
    [ApiController]
    public class cuenta_corrienteController : ControllerBase
    {
        private readonly cuenta_corrienteContext _context;

        public cuenta_corrienteController(cuenta_corrienteContext context)  //CONSTRUCTOR PARA EL CONTROLADOR
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<cuenta_corriente>>> GetClientes()
        {
            return await _context.cuenta_corriente.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<cuenta_corriente>> Getclientes(int id)
        {
            var cuenta_corriente = await _context.cuenta_corriente.FindAsync(id);

            if (cuenta_corriente == null)
            {
                return NotFound();
            }

            return cuenta_corriente;
        }
    }
}
