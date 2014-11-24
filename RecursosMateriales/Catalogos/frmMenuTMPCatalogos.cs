using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecursosMateriales.Catalogos
{
    public partial class frmMenuTMPCatalogos : Form
    {
        public frmMenuTMPCatalogos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUnidadesPresupuestales_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUnidadesMedida form = new frmUnidadesMedida();
            form.Show();
        }
    }
}
