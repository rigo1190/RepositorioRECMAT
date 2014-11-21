using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class InventarioInicialArticulosMigrate:Generica
    {

        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }

        public decimal CostoPromedio { get; set; }

        public virtual Articulos Articulo { get; set; }
    }
}
