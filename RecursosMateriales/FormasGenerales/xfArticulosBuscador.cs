using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DataAccessLayer;
using BusinessLogicLayer;
using DataAccessLayer.Models;

namespace RecursosMateriales.FormasGenerales
{
    public partial class xfArticulosBuscador : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork uow;
        public Articulos articuloSeleccionado;

        public xfArticulosBuscador()
        {
            InitializeComponent();
            uow = new UnitOfWork();
        }

        private void xfArticulosBuscador_Load(object sender, EventArgs e)
        {
            List<GruposPS> listaA = uow.GruposPSBL.Get(p => p.Nivel == 1).ToList();
            lstNivelA.DataSource = listaA.OrderBy(p=>p.Nombre).ToList();
            lstNivelA.DisplayMember = "Nombre";
            lstNivelA.ValueMember = "Id";

        }


        #region MetodoA
        
        private void lstNivelA_SelectedIndexChanged(object sender, EventArgs e)
        {

            try { 
            
                int padre = int.Parse(lstNivelA.SelectedValue.ToString());

                List<GruposPS> listaB = uow.GruposPSBL.Get(p => p.ParentId == padre).ToList();
                lstNivelB.DataSource = listaB.OrderBy(p => p.Nombre).ToList();
                lstNivelB.DisplayMember = "Nombre";
                lstNivelB.ValueMember = "Id";

            }
            catch { }

        }

        private void lstNivelB_SelectedIndexChanged(object sender, EventArgs e)
        {

            try {


                int padre = int.Parse(lstNivelB.SelectedValue.ToString());


                List<Articulos> lista = uow.ArticulosBL.Get(p => p.GruposPSId == padre).OrderBy(q => q.Nombre).ToList();


                DataTable table = new DataTable();

                table.Columns.Add("Id");
                table.Columns.Add("Clave");
                table.Columns.Add("Nombre");
                table.Columns.Add("UM");

                foreach (Articulos item in lista)
                {
                    DataRow row = table.NewRow();
                    row["Id"] = item.Id;
                    row["Clave"] = item.Clave;
                    row["Nombre"] = item.Nombre;
                    row["UM"] = item.UnidadDeMedidaCompra.Nombre;
                    table.Rows.Add(row);
                }

                dataGridView1.DataSource = table;

                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Nombre"].Width = 500;
            }
            catch { }
            
        }
        
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try {
                this.articuloSeleccionado = uow.ArticulosBL.GetByID(int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value.ToString()));
                this.Close();
            }
            catch { }
            
        }
        #endregion


        #region MetodoB
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
            List<Articulos> lista = uow.ArticulosBL.Get(p => p.Nombre.Contains(txtFiltroA.Text) && p.Nombre.Contains(txtFiltroB.Text) && p.Nombre.Contains(txtFiltroC.Text)).ToList();

            DataTable table = new DataTable();

            table.Columns.Add("Id");
            table.Columns.Add("Clave");
            table.Columns.Add("Nombre");
            table.Columns.Add("UM");

            foreach (Articulos item in lista)
            {
                DataRow row = table.NewRow();
                row["Id"] = item.Id;
                row["Clave"] = item.Clave;
                row["Nombre"] = item.Nombre;
                row["UM"] = item.UnidadDeMedidaCompra.Nombre;
                table.Rows.Add(row);
            }

            dataGridView2.DataSource = table;

            dataGridView2.Columns["Id"].Visible = false;
            dataGridView2.Columns["Nombre"].Width = 500;

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try {
                this.articuloSeleccionado = uow.ArticulosBL.GetByID(int.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["Id"].Value.ToString()));
                this.Close();
            }
            catch { }
            
        }

        #endregion

        


    }
}