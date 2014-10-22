using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Models;

using RecursosMateriales.Catalogos;
using RecursosMateriales.Adquisiciones;
using RecursosMateriales.Almacen;
using RecursosMateriales.Ventas;


namespace RecursosMateriales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
            


            

        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            frmMenuTMPCatalogos frm = new frmMenuTMPCatalogos();
            frm.ShowDialog();
        }

        private void btnAdquisiciones_Click(object sender, EventArgs e)
        {
            frmMenuTMPadquisiciones frm = new frmMenuTMPadquisiciones();
            frm.ShowDialog();

        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            frmMenuTMPalmacen frm = new frmMenuTMPalmacen();

            frm.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmMenuTMPventas frm = new frmMenuTMPventas();
            frm.ShowDialog();
        }

        private void btnSali_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
