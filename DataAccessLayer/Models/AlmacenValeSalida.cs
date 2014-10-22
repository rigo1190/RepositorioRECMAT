using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class AlmacenValeSalida:Generica
    {

        public AlmacenValeSalida()
        {
            this.detalleArticulos = new HashSet<AlmacenValeSalidaArticulos>();
        }

        public int Ejercicio { get; set; }
        public int Folio { get; set; }

        public int? SolicitudId { get; set; }

        public int UnidadPresupuestalId { get; set; }

        public DateTime Fecha { get; set; }
        public int Status { get; set; }

        public string Observaciones { get; set; }

        public virtual Solicitudes Solicitud { get; set; }
        public virtual UnidadesPresupuestales UnidadPresupuestal { get; set; }

        public virtual ICollection<AlmacenValeSalidaArticulos> detalleArticulos { get; set; }


    }
}
