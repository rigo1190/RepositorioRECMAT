﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Ventas:Generica
    {

        public Ventas()
        {
            this.detalleVentas = new HashSet<VentasArticulos>();
        }

        public int Ejercicio { get; set; }

        public int Folio { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Importe { get; set; }

        public int Status { get; set; }

        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }

        public int? FacturaVentaId { get; set; }


        public virtual Clientes Cliente { get; set; }

        public virtual Empleados Empleado { get; set; }
        public virtual FacturasVentas FacturaVenta { get; set; }

        public virtual ICollection<VentasArticulos> detalleVentas { get; set; }


    }
}
