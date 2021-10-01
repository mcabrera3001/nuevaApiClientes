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
        private readonly ClientesContext _context;

        private static void CreateCommand(string queryString, string connectionString) //se crea la conexion a la base de datos
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public clientesController(ClientesContext context)  //CONSTRUCTOR PARA EL CONTROLADOR
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(int id)
        {
            var Clientes = await _context.Clientes.FindAsync(id);

            if (Clientes == null)
            {
                return NotFound();
            }

            return Clientes;
        }

        [HttpGet("posnet/{id}")]
        public async Task<ActionResult<Clientes>> GetClientesConPosnet(int id)
        {

            var contextOptions = new DbContextOptionsBuilder<ClientesContext>()
            .UseSqlServer(@"Server = DESKTOP-NA2R6AM\MSQLSERVER; Database = Trocadero; user id = sa; password = mauro3001;
                                MultipleActiveResultSets = true; Trusted_Connection = True")
            .Options;

            using (var db = new ClientesContext(contextOptions))
            {
                var cl = from client in db.Clientes
                         where client.Posnet == id
                         select new { id_cliente = client.Id_Cliente, nombre = client.Nombre, apellido = client.Apellido, 
                             dni = client.Dni, domicilio = client.Domicilio, telefono = client.Telefono, posnet = client.Posnet };

                return Ok(await cl.ToListAsync());

            }
        }

        // PUT: api/clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclientes(int id, Clientes Clientes)
        {
            if (id != Clientes.Id_Cliente)
            {
                return BadRequest();
            }

            _context.Entry(Clientes).State = EntityState.Modified;

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
        public async Task<ActionResult<Clientes>> Postclientes(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientes), new { id = clientes.Id_Cliente }, clientes);

        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclientes(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clientesExists(int id)
        {
            return _context.Clientes.Any(e => e.Id_Cliente == id);
        }
    }
}
