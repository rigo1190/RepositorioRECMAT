using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Solicitudes:Generica
    {

        public Solicitudes()
        {
            this.DetalleSolicitudesArticulos = new HashSet<SolicitudesArticulos>();
            this.DetalleSolicitudesServicios = new HashSet<SolicitudesServicios>();
            this.DetalleCotizaciones = new HashSet<Cotizaciones>();
            this.DetalleAsignacionesArticulos = new HashSet<AsignacionesArticulos>();
            this.DetalleAsignacionesServicios = new HashSet<AsignacionesServicios>();

            this.DetallePedidos = new HashSet<Pedidos>();
            this.DetalleComprasMenores = new HashSet<ComprasMenores>();

        }

        public int Ejercicio { get; set; }


        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string FolioA { get; set; }

        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string FolioB { get; set; }
        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string FolioC { get; set; }

        public DateTime Fecha { get; set; }

        public int UnidadPresupuestalId { get; set; }

        [StringLength(255, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Solicitante { get; set; }

        [StringLength(255, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Observaciones { get; set; }

        public int Tipo { get; set; }
        //1.-Materiales 2.-Servicios

        public int Status { get; set; }


        public virtual UnidadesPresupuestales UnidadPresupuestal { get; set;}




        public virtual ICollection<SolicitudesArticulos> DetalleSolicitudesArticulos { get; set; }

        public virtual ICollection<SolicitudesServicios> DetalleSolicitudesServicios { get; set; }

        public virtual ICollection<Cotizaciones> DetalleCotizaciones { get; set; }

        public virtual ICollection<AsignacionesArticulos> DetalleAsignacionesArticulos { get; set; }
        public virtual ICollection<AsignacionesServicios> DetalleAsignacionesServicios { get; set; }

        public virtual ICollection<Pedidos> DetallePedidos { get; set; }

        public virtual ICollection<ComprasMenores> DetalleComprasMenores { get; set; }

    }
}
