using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nuevaApiClientes.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using nuevaApiClientes.Context;
using Dapper;


namespace nuevaApiClientes.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class clientesController : ControllerBase
    {
        private readonly clientesContext _context;

        private static void CreateCommand(string queryString, string connectionString) //se crea la conexion a la base de datos
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public clientesController(clientesContext context)  //CONSTRUCTOR PARA EL CONTROLADOR
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<clientes>>> GetClientes()
        {
            return await _context.clientes.ToListAsync();
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<clientes>> Getclientes(int id)
        {
            var clientes = await _context.clientes.FindAsync(id);

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        [HttpGet("posnet/{id}")]
        public async Task<ActionResult<clientes>> GetclientesConPosnet(int id)
        {

            var contextOptions = new DbContextOptionsBuilder<clientesContext>()
            .UseSqlServer(@"Server = DESKTOP-NA2R6AM\MSQLSERVER; Database = Trocadero; user id = sa; password = mauro3001;
                                MultipleActiveResultSets = true; Trusted_Connection = True")
            .Options;

            using (var db = new clientesContext(contextOptions))
            {
                var cl = from client in db.clientes
                         where client.posnet == id
                         select new { id_cliente = client.id_cliente, nombre = client.nombre, apellido = client.apellido, 
                             dni = client.dni, domicilio = client.domicilio, telefono = client.telefono, posnet = client.posnet };

                return Ok(await cl.ToListAsync());

            }
        }

        // PUT: api/clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclientes(int id, clientes clientes)
        {
            if (id != clientes.id_cliente)
            {
                return BadRequest();
            }

            _context.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<clientes>> Postclientes(clientes clientes)
        {
            _context.clientes.Add(clientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Getclientes), new { id = clientes.id_cliente }, clientes);

        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclientes(int id)
        {
            var clientes = await _context.clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clientesExists(int id)
        {
            return _context.clientes.Any(e => e.id_cliente == id);
        }
    }
}
