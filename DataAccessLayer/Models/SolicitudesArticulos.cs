using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Models
{
    public class SolicitudesArticulos:Generica
    {

        public int SolicitudId { get; set; }
        public int ArticuloId { get; set; }

        public int CantidadSolicitada { get; set; }

        public int CantidadAComprar { get; set; }

        public string Observaciones { get; set; }


        public virtual Solicitudes Solicitud { get; set; }
        public virtual Articulos Articulo { get; set; }


    }
}
