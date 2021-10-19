using Microsoft.AspNetCore.Mvc;
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

        [BindProperty(SupportsGet = true)]
        [FromQuery(Name = "nombre")]
        public string Nombre { get; set; }

        [BindProperty(SupportsGet = true)]
        [FromQuery(Name = "apellido")]
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }

        [BindProperty(SupportsGet = true)]
        [FromQuery(Name = "posnet")]
        public int Posnet { get; set; }

    }
}
