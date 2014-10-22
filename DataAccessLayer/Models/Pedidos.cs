using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Pedidos:Generica
    {
        public Pedidos()
        {
            this.detallePedidosArticulos = new HashSet<PedidosArticulos>();
            this.detallePedidosServicios = new HashSet<PedidosServicios>();
        }

        public int Ejercicio { get; set; }
        public int SolicitudId { get; set; }
        public int UnidadPresupuestalId { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public int Status { get; set; }

        [StringLength(255, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Observaciones { get; set; }

        public virtual Solicitudes Solicitud { get; set; }
        public virtual UnidadesPresupuestales UnidadPresupuestal { get; set; }

        public virtual ICollection<PedidosArticulos> detallePedidosArticulos { get; set; }
        public virtual ICollection<PedidosServicios> detallePedidosServicios { get; set; }

    }
}
