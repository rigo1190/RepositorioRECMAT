using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ComprasMenores:Generica
    {

        public ComprasMenores()
        {
            this.DetalleCMarticulos = new HashSet<ComprasMenoresArticulos>();
            this.DetalleCMservicios = new HashSet<ComprasMenoresServicios>();
        }

        public int Ejercicio { get; set; }
        public int SolicitudId { get; set; }
        public int UnidadPresupuestalId { get; set; }

        public int ProveedorId { get; set; }
        
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        
        
        public int Status { get; set; }
        public int StatusAlmacen { get; set; }


        

        [StringLength(255, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Observaciones { get; set; }

        public virtual Solicitudes Solicitud { get; set; }
        public virtual UnidadesPresupuestales UnidadPresupuestal { get; set; }

        public virtual Proveedores Proveedor { get; set; }
        public virtual ICollection<ComprasMenoresArticulos> DetalleCMarticulos { get; set; }

        public virtual ICollection<ComprasMenoresServicios> DetalleCMservicios { get; set; }

    }
}
