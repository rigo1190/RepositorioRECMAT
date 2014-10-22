using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class InventarioInicial: Generica
    {

        public int EjercicioCierre { get; set; }
        public int Ejercicio { get; set; }
        public DateTime Fecha { get; set; }

        public int Status { get; set; }
        public string Observaciones { get; set; }

    }
}
