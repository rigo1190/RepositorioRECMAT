using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class FacturasAlmacenTMPdetalle:Generica
    {
        public int usuario { get; set; }
        public int ArticuloId { get; set; }

        public int CantidadPendiente { get; set; }
        
        public int Cantidad { get; set; }

        public decimal Costo { get; set; }

        public virtual Articulos Articulo { get; set; }

    }
}
