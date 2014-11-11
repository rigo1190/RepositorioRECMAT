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

using System.Data.SqlClient;



namespace RecursosMateriales.Almacen
{
    public partial class xfInventarioInicialCargaManual : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork uow;
        
        private int IdInventarioInicial;
        private int IdArticulo;

        public xfInventarioInicialCargaManual()
        {
            InitializeComponent();
            uow = new UnitOfWork();
        }

        private void xfInventarioInicialCargaManual_Load(object sender, EventArgs e)
        {
            cargarForma();

        }


        #region Metodos
        private void cargarForma()
        {
            InventarioInicial ii = uow.InventarioInicialBL.Get(p => p.Ejercicio == fx.xEjercicio).FirstOrDefault();

            if (ii == null)
            {
                btnIniciar.Enabled = true;

                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
                btnCerrar.Enabled = false;
            }
            else
            {
                btnIniciar.Enabled = false;

                IdInventarioInicial = ii.Id;
                                
                txtEjercicio.Text = ii.Ejercicio.ToString();
                txtObservaciones.Text = ii.Observaciones.ToString();
                txtStatus.Text = "Abierto";
                dateTimePicker1.Value = ii.Fecha;


                MostrarDetalleArticulos();

                if (ii.Status == 2)
                {
                    txtStatus.Text = "Cerrado";
                    btnIniciar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnCerrar.Enabled = false;
                }
                    


                

                


            }


        }


        private void MostrarDetalleArticulos()  {

            uow = new UnitOfWork();
            List<InventarioInicialArticulos> lista = uow.InventarioInicialArticulosBL.Get(p => p.InventarioInicialId == IdInventarioInicial ).ToList();

            DataTable table = new DataTable();

            table.Columns.Add("Id");
            table.Columns.Add("Clave");
            table.Columns.Add("Nombre");
            table.Columns.Add("UM");
            table.Columns.Add("Cantidad");
            table.Columns.Add("CostoPromedio");

            foreach (InventarioInicialArticulos item in lista)
            {
                DataRow row = table.NewRow();
                row["Id"] = item.Id;
                row["Clave"] = item.Articulo.Clave;
                row["Nombre"] = item.Articulo.Nombre;
                row["UM"] = item.Articulo.UnidadDeMedidaCompra.Nombre;
                row["Cantidad"] = item.Cantidad;
                row["CostoPromedio"] = item.CostoPromedio;
                table.Rows.Add(row);
            }


            dataGridView1.DataSource = table;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Nombre"].Width = 300;

            dataGridView1.Columns["CostoPromedio"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["CostoPromedio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (lista.Count == 0) { 
                btnQuitar.Enabled = false;
                btnCerrar.Enabled = false;
            } 
            else { 
                btnQuitar.Enabled = true;
                btnCerrar.Enabled = true;
            }


        }

        #endregion





        #region Eventos
        
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            InventarioInicial obj = new InventarioInicial();

            obj.Ejercicio = fx.xEjercicio;
            obj.EjercicioCierre = 0;
            obj.Fecha = dateTimePicker1.Value;
            obj.Status = 1;
            obj.Observaciones = txtObservaciones.Text;

            uow.InventarioInicialBL.Insert(obj);
            uow.SaveChanges();

            IdInventarioInicial = obj.Id;

            if (uow.Errors.Count == 0)
            {
                btnIniciar.Enabled = false;
                btnAgregar.Enabled = true;
            }
                


        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {

            try { 
            
                FormasGenerales.xfArticulosBuscador xf = new FormasGenerales.xfArticulosBuscador();

                xf.ShowDialog();

                IdArticulo = xf.articuloSeleccionado.Id;
                txtNombreArticulo.Text = xf.articuloSeleccionado.Nombre;

                txtCantidad.Focus();

            }
            catch { }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!fx.IsNumeric(txtCantidad.Text )) {
                MessageBox.Show("No capturo correctamente la cantidad",fx.xMSGtitulo,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (!fx.IsNumeric(txtCosto.Text))
            {
                MessageBox.Show("No capturo correctamente el costo", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            InventarioInicialArticulos obj = new InventarioInicialArticulos();


            obj.InventarioInicialId = IdInventarioInicial;
            obj.ArticuloId = IdArticulo;
            obj.Cantidad = int.Parse(txtCantidad.Text);
            obj.CostoPromedio = decimal.Parse(txtCosto.Text);

            uow.InventarioInicialArticulosBL.Insert(obj);
            uow.SaveChanges();

            if (uow.Errors.Count == 0)
            {
                MostrarDetalleArticulos();
                txtCantidad.Text = string.Empty;
                txtCosto.Text = string.Empty;
                btnBuscarArticulo.Focus();
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int id;

            id = int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());

            InventarioInicialArticulos obj = uow.InventarioInicialArticulosBL.GetByID(id);

            uow.InventarioInicialArticulosBL.Delete(obj);
            uow.SaveChanges();

            if (uow.Errors.Count == 0)
                MostrarDetalleArticulos();

        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            List<InventarioInicialArticulos> lista = uow.InventarioInicialArticulosBL.Get(p => p.InventarioInicialId == IdInventarioInicial).ToList();

            if (lista.Count == 0) {
                MessageBox.Show("No hay artículos registrados que indiquen el inventario inicial",fx.xMSGtitulo,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }



            if (MessageBox.Show ("¿Esta seguro de dar por terminado el proceso de carga de inventario inicial?",fx.xMSGtitulo,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;




            try { 

                SqlConnection x = new SqlConnection(fx.cnnX);
                SqlCommand cmd = new SqlCommand("SP_articulosInicializarExistenciasyCostoPromedio",x);
                
                 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@iii",IdInventarioInicial);

                x.Open();
                    cmd.ExecuteNonQuery();
                x.Close();


                


                InventarioInicial obj = uow.InventarioInicialBL.GetByID(IdInventarioInicial);
                    obj.Status = 2;
                uow.InventarioInicialBL.Update(obj);
                uow.SaveChanges();

                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
                btnCerrar.Enabled = false;


            }
            catch { }




        }


        private void btnReporte_Click(object sender, EventArgs e)
        {
            XFinformes xf = new XFinformes();
            xf.Reporte = "InventarioInicial";
            xf.Formula = "{InventarioInicialArticulos.InventarioInicialId} = " + IdInventarioInicial;
            xf.ShowDialog();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) | Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) | Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }


            if (e.KeyChar == 46)
            {
                e.Handled = false;
            }


        }

        #endregion

        





    }
}