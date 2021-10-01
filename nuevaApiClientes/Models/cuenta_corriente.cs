using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nuevaApiClientes.Models
{
    public class cuenta_corriente
    {
        [Key]
        public int id_cuenta_corriente { get; set; }
        public int id_cliente { get; set; }
        public DateTime fecha { get; set; }
        public string movimiento { get; set; }
        public decimal importe { get; set; }

    }
}
