using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nuevaApiClientes.Models
{
    public class Clientes
    {
        [Key]
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public int Posnet { get; set; }

    }
}
