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

namespace RecursosMateriales.Almacen
{
    public partial class xfEntradasXcomprasMenores : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork uow;
        public xfEntradasXcomprasMenores()
        {
            InitializeComponent();
            uow = new UnitOfWork();
        }

        private void xfEntradasXcomprasMenores_Load(object sender, EventArgs e)
        {
            cargarComprasMenores();
        }


        #region Metodos
        private void cargarComprasMenores()
        {
            List<ComprasMenores> lista = uow.ComprasMenoresBL.Get(p => p.Ejercicio == fx.xEjercicio && p.Solicitud.Tipo == 1 && p.Status == 1 && p.StatusAlmacen < 2).ToList();
            lstCM.DataSource = lista.OrderBy(p => p.Folio).ToList();
            lstCM.DisplayMember = "Folio";
            lstCM.ValueMember = "Id";
        }

        private void cargarDatosPedidos(int idCM)
        {

            ComprasMenores compraMenor = uow.ComprasMenoresBL.GetByID(idCM);

            txtFolio.Text = compraMenor.Folio.ToString();
            dateTimePicker1.Value = compraMenor.Fecha;
            txtImporte.Text = compraMenor.Importe.ToString("C");
            txtObs.Text = compraMenor.Observaciones.ToString();
            txtUp.Text = compraMenor.UnidadPresupuestal.Nombre;


            List<ComprasMenoresArticulos> lista = uow.ComprasMenoresArticulosBL.Get(p => p.CompraMenorId == compraMenor.Id).OrderBy(q => q.Articulo.Nombre).ToList();


            DataTable table = new DataTable();

            table.Columns.Add("Articulo");
            table.Columns.Add("Cantidad");
            table.Columns.Add("Precio");
            table.Columns.Add("Total");
            table.Columns.Add("Costo Unitario");

            foreach (ComprasMenoresArticulos item in lista)
            {
                DataRow row = table.NewRow();
                row["Articulo"] = item.Articulo.Nombre;
                row["Cantidad"] = item.Cantidad;
                row["Precio"] = item.Precio.ToString("C2");
                row["Total"] = item.ImporteFinal.ToString("C2");
                row["Costo Unitario"] = Math.Round(item.ImporteFinal / item.Cantidad, 2).ToString("C2");

                table.Rows.Add(row);
            }

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Articulo"].Width = 300;


            dataGridView1.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Costo Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


        }
        
        private void cargarFacturas(int idCM)
        {

            DataTable table = new DataTable();

            table.Columns.Add("Articulo");
            table.Columns.Add("Cantidad");
            table.Columns.Add("Precio");
            table.Columns.Add("Total");

            DataRow row1 = table.NewRow();
            row1["Articulo"] = "";
            row1["Cantidad"] = "";
            row1["Precio"] = "";
            row1["Total"] = "";
            table.Rows.Add(row1);

            dataGridView3.DataSource = table;



            List<FacturasAlmacen> listaFacturas = uow.FacturasAlmacenBL.Get(p => p.CompraMenorId == idCM && p.Status < 3).ToList();
            table = new DataTable();

            table.Columns.Add("Id");
            table.Columns.Add("Folio");
            table.Columns.Add("Fecha");
            table.Columns.Add("Importe");
            table.Columns.Add("Observaciones");


            foreach (FacturasAlmacen item in listaFacturas)
            {
                DataRow row = table.NewRow();
                row["Id"] = item.Id;
                row["Folio"] = item.FolioFactura;
                row["Fecha"] = item.FechaFactura;
                row["Importe"] = item.ImporteFactura.ToString("C2");
                row["Observaciones"] = item.Observaciones;
                table.Rows.Add(row);
            }

            dataGridView2.DataSource = table;
            dataGridView2.Columns["Observaciones"].Visible = false;
            dataGridView2.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns["Observaciones"].Width = 300;

        }
        
        private void cargarDetallefacturas()
        {
            int idFactura = 0;
            try
            {
                idFactura = int.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["Id"].Value.ToString());

            }
            catch
            {
                return;
            }


            List<FacturasAlmacenArticulos> lista = uow.FacturasAlmacenArticulosBL.Get(p => p.FacturaAlmacenId == idFactura).ToList();


            DataTable table = new DataTable();


            table.Columns.Add("Articulo");
            table.Columns.Add("Cantidad");
            table.Columns.Add("Precio");
            table.Columns.Add("Total");





            foreach (FacturasAlmacenArticulos item in lista)
            {
                DataRow row = table.NewRow();
                row["Articulo"] = item.Articulo.Nombre;
                row["Cantidad"] = item.Cantidad;
                row["Precio"] = item.Precio.ToString("C2");
                row["Total"] = item.Total.ToString("C2");
                table.Rows.Add(row);
            }

            dataGridView3.DataSource = table;
            dataGridView3.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns["Articulo"].Width = 300;


        }
        
        #endregion

        #region Eventos
        private void lstCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCM;


            try
            {
                idCM  = int.Parse(lstCM.SelectedValue.ToString());
            }
            catch
            {
                ComprasMenores compraMenor = (ComprasMenores)lstCM.SelectedValue;
                idCM = compraMenor.Id; 
            }

            cargarDatosPedidos(idCM);
            cargarFacturas(idCM);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            cargarDetallefacturas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (lstCM.Items.Count == 0)
                return;

            xfEntradasXcomprasMenoresRegistroFacturas xf = new xfEntradasXcomprasMenoresRegistroFacturas();
            xf.idCM = int.Parse(lstCM.SelectedValue.ToString());
            xf.ShowDialog();

            if (xf.recargarCM)
                cargarComprasMenores();
            else
                cargarFacturas(int.Parse(lstCM.SelectedValue.ToString()));


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            int idFactura = 0;
            int idCM = 0;

            try
            {
                idFactura = int.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["Id"].Value.ToString());
                idCM = int.Parse(lstCM.SelectedValue.ToString());
            }
            catch { return; }


            List<FacturasAlmacen> lista = uow.FacturasAlmacenBL.Get(p => p.CompraMenorId == idCM && p.Id > idFactura).ToList();

            if (lista.Count > 0)
            {
                MessageBox.Show("Esta factura no puede eliminarse porque esta 'Compra Menor' tiene registrado otra factura posterior a esta", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //verificar contra contabilidad, por si ya esta     


            //var listaExistencias = 
            var listaExistencias = from fa in uow.FacturasAlmacenArticulosBL.Get(p => p.Id == idFactura).ToList()
                                   join a in uow.ArticulosBL.Get().ToList()
                                   on fa.ArticuloId equals a.Id
                                   select new { fa.ArticuloId, fa.Cantidad, a.CantidadEnAlmacen };

            //list = list.Where(p => p.Cantidad > p.CantidadEnAlmacen).ToList();
            int i = 0;
            foreach (var item in listaExistencias)
            {
                if (item.Cantidad > item.CantidadEnAlmacen)
                    i++;
            }

            if (i > 0)
            {
                MessageBox.Show("Esta factura no puede eliminarse porque esta 'Compra Menor' tiene registrado otra factura posterior a esta", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (MessageBox.Show("¿Esta seguro de eliminar la factura?", fx.xMSGtitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {




                FacturasAlmacen factura = uow.FacturasAlmacenBL.GetByID(idFactura);

                factura.Status = 3;
                uow.FacturasAlmacenBL.Update(factura);

                ArticulosMovimientos bitacora = uow.ArticulosMovimientosBL.Get(p => p.FacturaAlmacenId == idFactura).First();
                uow.ArticulosMovimientosBL.Update(bitacora);


                foreach (FacturasAlmacenArticulos item in factura.detalleArticulos)
                {
                    Articulos articulo = uow.ArticulosBL.GetByID(item.ArticuloId);

                    articulo.CantidadEnAlmacen = articulo.CantidadEnAlmacen - item.Cantidad;
                    articulo.CantidadDisponible = articulo.CantidadDisponible - item.Cantidad;

                    #region CalculoNuevoCostoPromedio

                    int existencia = articulo.CantidadEnAlmacen;
                    decimal nuevocostopromedio;

                    if (existencia > 0)
                    {
                        List<ArticulosMovimientosEntradas> listaEntradas = uow.ArticulosMovimientosEntradasBL.Get(p => p.ArticuloId == articulo.Id && p.ArticuloMovimiento.Status != 3).ToList();
                        listaEntradas = listaEntradas.OrderByDescending(p => p.ArticuloMovimiento.Movimiento).ToList();

                        decimal sumaImportes = 0;

                        foreach (ArticulosMovimientosEntradas ame in listaEntradas)
                        {
                            if (existencia >= ame.Cantidad)
                            {
                                sumaImportes = sumaImportes + Math.Round(ame.Cantidad * ame.Importe, 2);
                                existencia = existencia - ame.Cantidad;
                            }
                            else
                            {
                                sumaImportes = sumaImportes + Math.Round(existencia * ame.Importe, 2);
                                existencia = 0;
                            }
                        }


                        existencia = articulo.CantidadEnAlmacen;
                        nuevocostopromedio = Math.Round(sumaImportes / existencia, 2);

                    }
                    else
                    {
                        nuevocostopromedio = 0;
                    }
                    #endregion

                    articulo.CostoPromedio = nuevocostopromedio;
                    uow.ArticulosBL.Update(articulo);

                    //desafectamos le pedido
                    ComprasMenoresArticulos compramenorarticulo = uow.ComprasMenoresArticulosBL.Get(p => p.CompraMenorId == idCM && p.ArticuloId == articulo.Id).First();
                    compramenorarticulo.CantidadRecibidaAlmacen = compramenorarticulo.CantidadRecibidaAlmacen - item.Cantidad;
                    uow.ComprasMenoresArticulosBL.Update(compramenorarticulo);

                }

                ComprasMenores compramenor = uow.ComprasMenoresBL.GetByID(idCM);
                compramenor.StatusAlmacen = 1;
                uow.ComprasMenoresBL.Update(compramenor);

                uow.SaveChanges();

                MessageBox.Show("La factura ha sido eliminada correctamente", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarFacturas(idCM);
            }



            uow.SaveChanges();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
               

        #endregion

    }
}