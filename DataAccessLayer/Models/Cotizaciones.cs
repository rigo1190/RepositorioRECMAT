using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Cotizaciones:Generica
    {

        public Cotizaciones()
        {
            this.DetalleArticulos = new HashSet<CotizacionesArticulos>();
            this.DetalleServicios = new HashSet<CotizacionesServicios>();
        }

        public int SolicitudId { get; set; }

        public int ProveedorId { get; set; }

        public int FormaDePagoId { get; set; }
        public int TiempoDeEntregaId { get; set; }
        public string Observaciones { get; set; }
        public string OtrasCondiciones { get; set; }


        public virtual Solicitudes Solicitud { get; set; }
        public virtual Proveedores Proveedor { get; set; }
        public virtual FormaDePago FormaDePago { get; set; }
        public virtual TiempoDeEntrega TiempoDeEntrega { get; set; }

        public virtual ICollection<CotizacionesArticulos> DetalleArticulos { get; set; }
        public virtual ICollection<CotizacionesServicios> DetalleServicios { get; set; }


    }
}
