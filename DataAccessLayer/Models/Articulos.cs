using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Articulos:Generica
    {


        [Index(IsUnique = true)]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Clave { get; set; }

        [StringLength(500, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Nombre { get; set; }


        public double PorcentajeImpuesto { get; set; }
        public int UnidadDeMedidaCompraId { get; set; }

        public int UnidadDeMedidaVentaId { get; set; }

        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }


        public int CantidadEnAlmacen { get; set; }
        public int CantidadComprometida { get; set; }
        public int CantidadDisponible { get; set; }

        public int GruposPSId { get; set; }

        public decimal CostoPromedio { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public decimal PrecioDeCompra { get; set; }

        public decimal UltimoPrecioVenta { get; set; }
        public decimal UltimoPrecioCompra { get; set; }


        public virtual UnidadesDeMedida UnidadDeMedidaCompra { get; set; }

        public virtual UnidadesDeMedida UnidadDeMedidaVenta { get; set; }

        public virtual GruposPS GruposPS { get; set; }

    }
}
