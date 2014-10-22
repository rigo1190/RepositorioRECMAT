using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Models
{
    public class AsignacionesArticulos:Generica
    {

        public int SolicitudId { get; set; }
        public int ProveedorId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public double PorcentajeImpuesto { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public decimal ImporteFinal { get; set; }

        public virtual Solicitudes Solicitud { get; set; }
        public virtual Proveedores Proveedor { get; set; }
        public virtual Articulos Articulo { get; set; }


    }
}
