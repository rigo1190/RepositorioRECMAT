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
using System.Data.OleDb;

using DataAccessLayer;
using BusinessLogicLayer;
using DataAccessLayer.Models;

using System.Data.SqlClient;

namespace RecursosMateriales.Almacen
{
    public partial class xfInventarioInicialCargaExcel : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork uow;

        private int IdInventarioInicial;

        public xfInventarioInicialCargaExcel()
        {
            InitializeComponent();
            uow = new UnitOfWork();
        }

        private void xfInventarioInicialCargaExcel_Load(object sender, EventArgs e)
        {
            cargarForma();
        }


        private void cargarForma()
        {
            InventarioInicial ii = uow.InventarioInicialBL.Get(p => p.Ejercicio == fx.xEjercicio).FirstOrDefault();

            if (ii == null)
            {
                txtStatus.Text = "No se ha cargado el inventario inicial para el ejercicio " + fx.xEjercicio;
                return;
            }
                

            if (ii.Status == 1)
                txtStatus.Text = "La carga inicial del inventario se está realizando de forma manual";

            if (ii.Status == 2)
            {
                txtStatus.Text = "La carga inicial del inventario para el ejercicio " + fx.xEjercicio + " ya sido realizada";


                List<InventarioInicialArticulos> lista = uow.InventarioInicialArticulosBL.Get(p=>p.InventarioInicialId == ii.Id).ToList();

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

            }
                

            btnExportar.Enabled = false;
            btnImportar.Enabled = false;                

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            

            this.Height = 495;
            this.btnSalir.Top = 425;

            this.PanelImportar.Visible = true;
            
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            dialog.Title = "Seleccione el archivo de Excel";
            dialog.FileName = string.Empty;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtArchivo.Text = @dialog.FileName;

            }
            else { txtArchivo.Text = ""; }  
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            if (txtArchivo.Text == "")
            {
                MessageBox.Show("No ha indicado el archivo a importar", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (txtHoja.Text == "")
            {
                MessageBox.Show("No ha indicado el nombre de la hoja que contiene la información", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            LLenarGrid(txtArchivo.Text, txtHoja.Text);
             


             
             
        }



        private void LLenarGrid(string archivo, string hoja)
        {

            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("La hoja seleccionada no tiene contenido", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {

                    //limpiamos la tabla temporal
                    //x.EliminarRegistros();

                    uow.InventarioInicialArticulosMigrateBL.DeleteAll();
                    
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);
                    conexion.Open();
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dataSet.Tables[0].Rows.Count;
                    progressBar1.Value = 0;

                    int cantidad;
                    decimal costo;
                    foreach (DataRow renglon in dataSet.Tables[0].Rows)
                    {

                        try {

                            InventarioInicialArticulosMigrate obj = new InventarioInicialArticulosMigrate();

                            cantidad = int.Parse(renglon[5].ToString());
                            costo = decimal.Parse(renglon[6].ToString());

                            if ((cantidad * costo) > 0)
                            {
                                obj.ArticuloId = int.Parse(renglon[0].ToString());
                                obj.Cantidad = cantidad;
                                obj.CostoPromedio = costo;

                                uow.InventarioInicialArticulosMigrateBL.Insert(obj);
                            }

                            
                        }
                        catch { }

                        

                        progressBar1.Value++;

                    }

                    uow.SaveChanges();



                    uow = new UnitOfWork();

                    #region MostrarDatos
                    List<InventarioInicialArticulosMigrate> lista = uow.InventarioInicialArticulosMigrateBL.Get().ToList();

                    DataTable table = new DataTable();

                    table.Columns.Add("Id");
                    table.Columns.Add("Clave");
                    table.Columns.Add("Nombre");
                    table.Columns.Add("UM");
                    table.Columns.Add("Cantidad");
                    table.Columns.Add("CostoPromedio");

                    foreach (InventarioInicialArticulosMigrate item in lista)
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

                    #endregion

                    conexion.Close();//cerramos la conexion
                    dataGridView1.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                    this.Height = 390;
                    this.btnSalir.Top = 320;
                    this.PanelImportar.Visible = false;

                    if (lista.Count == 0) { 
                        btnTerminar.Enabled = false;
                    }
                    else
                    {
                        btnTerminar.Enabled = true;
                    }


                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            //dialog.Title = "Seleccione el archivo de Excel";
            //dialog.FileName = string.Empty;
            string nombreArchivo = "";

            List<Articulos> lista = uow.ArticulosBL.Get().OrderBy(p => p.GruposPS.Parent.Nombre).OrderBy(q => q.GruposPS.Nombre).OrderBy(r => r.Nombre).ToList();
            

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nombreArchivo = dialog.SelectedPath + @"\CatalogoDeArticulos";
                 
            
                Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = null;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = null;


                workbook = aplicacion.Workbooks.Add(1);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int i = 1;

                worksheet.Cells[i, 1] = "#";
                worksheet.Cells[i, 2] = "Grupo";
                worksheet.Cells[i, 3] = "Producto";
                worksheet.Cells[i, 4] = "Artículo";
                worksheet.Cells[i, 5] = "U.M";
                worksheet.Cells[i, 6] = "Cantidad";
                worksheet.Cells[i, 7] = "Costo Promedio";

                foreach (Articulos item in lista)
                {
                    i++;
                    worksheet.Cells[i, 1] = item.Id;
                    worksheet.Cells[i, 2] = item.GruposPS.Parent.Nombre;
                    worksheet.Cells[i, 3] = item.GruposPS.Nombre;
                    worksheet.Cells[i, 4] = item.Nombre;
                    worksheet.Cells[i, 5] = item.UnidadDeMedidaCompra.Nombre;
                    worksheet.Cells[i, 6] = 0;
                    worksheet.Cells[i, 7] = "$0.00";
                }



                workbook.SaveAs(nombreArchivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                workbook.Close(true);

                aplicacion.Quit();

                MessageBox.Show("El archivo se ha exportado con el nombre de 'Catálogo de Artículos' en la ubicación que usted especifico",fx.xMSGtitulo,MessageBoxButtons.OK,MessageBoxIcon.Information);

            
            }



            


            



        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("¿Esta seguro de dar por terminado el proceso de carga de inventario inicial?", fx.xMSGtitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;



            InventarioInicial obj = new InventarioInicial();
                obj.Ejercicio = fx.xEjercicio;
                obj.EjercicioCierre = 0;
                obj.Fecha = DateTime.Now;
                obj.Status = 1;
                obj.Observaciones = "La carga del inventario inicial se realizo desde un archivo de excel";
            uow.InventarioInicialBL.Insert(obj);
            
             

            List<InventarioInicialArticulosMigrate> lista = uow.InventarioInicialArticulosMigrateBL.Get().ToList();
            foreach (InventarioInicialArticulosMigrate item in lista)
            {
                InventarioInicialArticulos iia = new InventarioInicialArticulos();
                InventarioInicialArticulosCostos iiaCosto = new InventarioInicialArticulosCostos();

                    iia.ArticuloId = item.ArticuloId; 
                    iia.Cantidad = item.Cantidad;
                    iia.CostoPromedio = item.CostoPromedio;

                    iiaCosto.ArticuloId = item.ArticuloId;
                    iiaCosto.Orden = 1;
                    iiaCosto.Cantidad = item.Cantidad;
                    iiaCosto.Costo = item.CostoPromedio;
                
                obj.DetalleArticulos.Add(iia);
                iia.DetalleCostos.Add(iiaCosto);
                
            }

            uow.SaveChanges();


            try
            {
                
                //Actualiza las existencias en el catalogo de articulos
                SqlConnection x = new SqlConnection(fx.cnnX);
                SqlCommand cmd = new SqlCommand("SP_articulosInicializarExistenciasyCostoPromedio", x);                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@iii", int.Parse(obj.Id.ToString()));
                x.Open();
                cmd.ExecuteNonQuery();
                x.Close();
                
                //Genera registros de Movimientos iniciales de los articulos
                ArticulosMovimientos artMov = new ArticulosMovimientos();
                    artMov.Ejercicio = fx.xEjercicio;
                    artMov.Movimiento = 1;
                    artMov.Tipo = 0;
                    artMov.Fecha = DateTime.Now;
                    artMov.Status = 1;
                    artMov.InventarioInicialId = obj.Id;
                uow.ArticulosMovimientosBL.Insert(artMov);


                lista = uow.InventarioInicialArticulosMigrateBL.Get().ToList();
                foreach (InventarioInicialArticulosMigrate item in lista)
                {
                    ArticulosMovimientosEntradas entrada = new ArticulosMovimientosEntradas();                    
                        entrada.ArticuloId = item.ArticuloId;
                        entrada.Cantidad = item.Cantidad;
                        entrada.Importe = item.CostoPromedio;
                        entrada.NuevoCostoPromedio = item.CostoPromedio;
                    artMov.detallaEntradas.Add(entrada);                     
                }

                //Cerramos el inventario inicial
                InventarioInicial ii = uow.InventarioInicialBL.GetByID(obj.Id);
                    obj.Status = 2;
                uow.InventarioInicialBL.Update(obj);


                uow.SaveChanges();


                btnExportar.Enabled = false;
                btnImportar.Enabled = false;
                btnTerminar.Enabled = false;

                MessageBox.Show("El proceso de carga de inventario inicial se ha concluido satisfactoriamente", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);    

            }
            catch { }


        }




    }
}