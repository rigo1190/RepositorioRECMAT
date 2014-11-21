using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer;

namespace RecursosMateriales.Almacen
{
    public partial class frmMenuTMPalmacen : Form
    {
        public frmMenuTMPalmacen()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMenuTMPalmacen_Load(object sender, EventArgs e)
        {
            

            

            

        }

        private void btnCargaManual_Click(object sender, EventArgs e)
        {
            //xfInventarioInicialCargaManual xf = new xfInventarioInicialCargaManual();
            //xf.ShowDialog();
        }

        private void btnCargaArchivo_Click(object sender, EventArgs e)
        {
            xfInventarioInicialCargaExcel xf = new xfInventarioInicialCargaExcel();
            xf.ShowDialog();
        }
    }
}
