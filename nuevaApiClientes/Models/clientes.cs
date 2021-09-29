using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nuevaApiClientes.Models
{
    public class clientes
    {
        [Key]
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public int posnet { get; set; }

    }
}
