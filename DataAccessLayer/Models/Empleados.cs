using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Empleados:Generica
    {

        [Index(IsUnique = true)]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Clave { get; set; }

        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Nombre { get; set; }


        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string ApellidoPaterno { get; set; }

        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string ApellidoMaterno { get; set; }

        [StringLength(100, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Calle { get; set; }

        [StringLength(20, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string NumeroInterior { get; set; }

        [StringLength(20, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string NumeroExterior { get; set; }


     
        public int UnidadPresupuestalId { get; set; }


        public int Status { get; set; }



        public virtual UnidadesPresupuestales UnidadPresupuestal { get; set; }
    
    }

}
