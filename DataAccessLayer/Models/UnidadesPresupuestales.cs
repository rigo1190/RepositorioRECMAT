using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class UnidadesPresupuestales:Generica
    {

        public UnidadesPresupuestales() {
            this.DetalleSubUPS = new HashSet<UnidadesPresupuestales>();
            this.DetalleEmpleados = new HashSet<Empleados>();
            this.DetalleSolicitudes = new HashSet<Solicitudes>();
            this.DetallePedidos = new HashSet<Pedidos>();
        }


        [Index(IsUnique = true)]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Clave { get; set; }

        public string Nombre { get; set; }

        public int Status { get; set; }

        public int? ParentId { get; set; }

        public virtual UnidadesPresupuestales Parent { get; set; }

        public virtual ICollection<UnidadesPresupuestales> DetalleSubUPS { get; set; }

        public virtual ICollection<Empleados> DetalleEmpleados { get; set; }

        public virtual ICollection<Solicitudes> DetalleSolicitudes { get; set; }

        public virtual ICollection<Pedidos> DetallePedidos { get; set; }

    }
}
