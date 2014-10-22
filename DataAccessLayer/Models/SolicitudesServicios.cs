using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SolicitudesServicios:Generica
    {

        public int SolicitudId { get; set; }
        public int ServicioId { get; set; }

        [StringLength(255, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string DescripcionDelServicio { get; set; }
        public int Cantidad { get; set; }

        public string Observaciones { get; set; }


        public virtual Solicitudes Solicitud { get; set; }
        public virtual Servicios Servicio { get; set; }



    }
}
