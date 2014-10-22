﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Ejercicios 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }

        public int Status { get; set; }

    }
}
