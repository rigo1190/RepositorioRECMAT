using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class FacturasVentas:Generica
    {

        public FacturasVentas()
        {
            this.detalleFacturasArticulos = new HashSet<FacturasVentasArticulos>();
            this.detalleVentas = new HashSet<Ventas>();
        }

        public int Serie{get;set;}
        public int Folio{get;set;}
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }

        public int Status { get; set; }
        public int ClienteId { get; set; }

        public virtual Clientes Cliente { get; set; }

        public virtual ICollection<FacturasVentasArticulos> detalleFacturasArticulos { get; set; }

        public virtual ICollection<Ventas> detalleVentas { get; set; }

    }
}
