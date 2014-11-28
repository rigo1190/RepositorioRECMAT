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
using DataAccessLayer.Models;
using BusinessLogicLayer;
    
namespace RecursosMateriales.Almacen
{
    public partial class xfEntradasXcomprasMenoresRegistroFacturas : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork uow;
        public int idCM;
        public bool recargarCM;
        public xfEntradasXcomprasMenoresRegistroFacturas()
        {
            InitializeComponent();
            uow = new UnitOfWork();
        }

        private void xfEntradasXcomprasMenoresRegistroFacturas_Load(object sender, EventArgs e)
        {
            cargarDetalle();
        }



        #region Metodos
        private void cargarDetalle()
        {

            //limpiamos la tabla temporal
            List<FacturasAlmacenTMPdetalle> lista = uow.FacturasAlmacenTMPdetalleBL.Get(p => p.usuario == fx.xUsuario).ToList();

            foreach (FacturasAlmacenTMPdetalle item in lista)
                uow.FacturasAlmacenTMPdetalleBL.Delete(item);

            uow.SaveChanges();



            List<ComprasMenoresArticulos> listaArticulos = uow.ComprasMenoresArticulosBL.Get(p => p.CompraMenorId == idCM && p.Cantidad > p.CantidadRecibidaAlmacen).ToList();

            foreach (ComprasMenoresArticulos item in listaArticulos)
            {
                FacturasAlmacenTMPdetalle obj = new FacturasAlmacenTMPdetalle();

                obj.usuario = fx.xUsuario;
                obj.ArticuloId = item.ArticuloId;
                obj.CantidadPendiente = (item.Cantidad - item.CantidadRecibidaAlmacen);
                obj.Cantidad = (item.Cantidad - item.CantidadRecibidaAlmacen);
                obj.Costo = Math.Round(item.ImporteFinal / item.Cantidad, 2);

                uow.FacturasAlmacenTMPdetalleBL.Insert(obj);
            }

            uow.SaveChanges();
            uow = new UnitOfWork();


            lista = uow.FacturasAlmacenTMPdetalleBL.Get(p => p.usuario == fx.xUsuario).ToList();


            DataTable table = new DataTable();

            table.Columns.Add("id");
            table.Columns.Add("Articulo");
            table.Columns.Add("C.Pendiente");
            table.Columns.Add("Cantidad");
            table.Columns.Add("Costo Unitario");
            table.Columns.Add("Total");



            foreach (FacturasAlmacenTMPdetalle item in lista)
            {
                DataRow row = table.NewRow();

                row["id"] = item.Id;
                row["Articulo"] = item.Articulo.Nombre;
                row["C.Pendiente"] = item.CantidadPendiente;
                row["Cantidad"] = item.Cantidad;
                row["Costo Unitario"] = item.Costo.ToString("C2");
                row["Total"] = Math.Round(item.Cantidad * item.Costo, 2).ToString("C2");

                table.Rows.Add(row);
            }

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Articulo"].ReadOnly = true;
            dataGridView1.Columns["C.Pendiente"].ReadOnly = true;
            dataGridView1.Columns["Costo Unitario"].ReadOnly = true;
            dataGridView1.Columns["Total"].ReadOnly = true;

            dataGridView1.Columns["id"].Visible = false;


            txtImporte.Text = lista.Sum(p => p.Costo * p.Cantidad).ToString("C2");
            txtPedido.Text = idCM.ToString();

        }
        #endregion



        #region Eventos
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFolio.Text.Trim() == string.Empty)
            {
                MessageBox.Show("No ha capturado el folio de la factura", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No ha detallado los articulos de la factura que quiere registrar", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (MessageBox.Show("¿Esta seguro de que los datos de la factura son los correctos?", fx.xMSGtitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;




            //registramos la factura
            decimal suma;
            List<FacturasAlmacenTMPdetalle> lista = uow.FacturasAlmacenTMPdetalleBL.Get(p => p.usuario == fx.xUsuario && p.Cantidad > 0 && p.Cantidad <= p.CantidadPendiente).ToList();
            suma = lista.Sum(p => p.Costo * p.Cantidad);

            int consecutivo;
            List<FacturasAlmacen> listaFacturas = uow.FacturasAlmacenBL.Get(p => p.CompraMenorId == this.idCM).ToList();

            consecutivo = listaFacturas.Count;
            consecutivo++;

            FacturasAlmacen factura = new FacturasAlmacen();
            factura.Ejercicio = fx.xEjercicio;
            factura.FolioFactura = txtFolio.Text;
            factura.FechaFactura = dateTimePicker1.Value;
            factura.ImporteFactura = suma;
            factura.Observaciones = txtObservaciones.Text;
            factura.Status = 1;
            factura.Tipo = 2;
            factura.CompraMenorId = this.idCM;
            factura.Consecutivo = consecutivo;
            uow.FacturasAlmacenBL.Insert(factura);


            foreach (FacturasAlmacenTMPdetalle item in lista)
            {
                FacturasAlmacenArticulos facturaArticulo = new FacturasAlmacenArticulos();
                facturaArticulo.ArticuloId = item.ArticuloId;
                facturaArticulo.Cantidad = item.Cantidad;
                facturaArticulo.Precio = item.Costo;
                facturaArticulo.Total = Math.Round(item.Cantidad * item.Costo, 2);
                factura.detalleArticulos.Add(facturaArticulo);
            }



            //registramos la bitacora de movimientos
            ArticulosMovimientos bitacora = new ArticulosMovimientos();

            List<ArticulosMovimientos> listaMovimientos = uow.ArticulosMovimientosBL.Get(p => p.Ejercicio == fx.xEjercicio).ToList();

            int mov = listaMovimientos.Count();
            mov++;

            bitacora.Ejercicio = fx.xEjercicio;
            bitacora.Movimiento = mov;
            bitacora.Tipo = 1;
            bitacora.Fecha = DateTime.Now;
            bitacora.Status = 1;
            bitacora.FacturaAlmacenId = factura.Id;

            uow.ArticulosMovimientosBL.Insert(bitacora);

            foreach (FacturasAlmacenTMPdetalle item in lista)
            {


                Articulos art = uow.ArticulosBL.GetByID(item.ArticuloId);

                #region CalculoNuevoCostoPromedio

                int existencia = art.CantidadEnAlmacen;
                decimal nuevocostopromedio;

                if (existencia > 0)
                {
                    List<ArticulosMovimientosEntradas> listaEntradas = uow.ArticulosMovimientosEntradasBL.Get(p => p.ArticuloId == art.Id && p.ArticuloMovimiento.Status != 3).ToList();
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

                    sumaImportes = sumaImportes + (item.Costo * item.Cantidad);
                    existencia = art.CantidadEnAlmacen + item.Cantidad;
                    nuevocostopromedio = Math.Round(sumaImportes / existencia, 2);

                }
                else
                {
                    nuevocostopromedio = item.Costo;
                }
                #endregion


                ArticulosMovimientosEntradas entrada = new ArticulosMovimientosEntradas();

                entrada.ArticuloId = item.ArticuloId;
                entrada.Cantidad = item.Cantidad;
                entrada.Importe = item.Costo;
                entrada.NuevoCostoPromedio = nuevocostopromedio;

                bitacora.detallaEntradas.Add(entrada);


                art.CantidadEnAlmacen = art.CantidadEnAlmacen + item.Cantidad;
                art.CantidadDisponible = art.CantidadDisponible + item.Cantidad;
                art.CostoPromedio = nuevocostopromedio;
                art.UltimoPrecioCompra = item.Costo;
                uow.ArticulosBL.Update(art);

                //afectamos le pedido

                ComprasMenoresArticulos compramenorarticulo = uow.ComprasMenoresArticulosBL.Get(p=>p.CompraMenorId == idCM && p.ArticuloId == art.Id).First();

                compramenorarticulo.CantidadRecibidaAlmacen = compramenorarticulo.CantidadRecibidaAlmacen + item.Cantidad;
                uow.ComprasMenoresArticulosBL.Update(compramenorarticulo);

            }

            //marcamos el pedido como recibido parcial




            uow.SaveChanges();
            ComprasMenores compramenor = uow.ComprasMenoresBL.GetByID(idCM);

            List<ComprasMenoresArticulos> listaArticulos = uow.ComprasMenoresArticulosBL.Get(p => p.CompraMenorId == idCM && p.CantidadRecibidaAlmacen < p.Cantidad).ToList();

            if (listaArticulos.Count == 0)
            {
                //marcamos el pedido como entregado completo
                compramenor.StatusAlmacen = 2;
                recargarCM = true;
            }
            else
            {
                //marcamos el pedido como entregado parcial
                compramenor.StatusAlmacen = 1;
                recargarCM  = false;
            }
            uow.ComprasMenoresBL.Update(compramenor);
            uow.SaveChanges();



            MessageBox.Show("La factura " + txtFolio.Text + " se ha registrado satisfactoriamente", fx.xMSGtitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int cantidad = 0;
            int id = 0;

            try
            {
                cantidad = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Cantidad"].Value.ToString());
                id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString());
            }
            catch
            {
                return;
            }




            FacturasAlmacenTMPdetalle obj = uow.FacturasAlmacenTMPdetalleBL.GetByID(id);





            if (cantidad == 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Articulo"].Style.BackColor = System.Drawing.Color.White;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["C.Pendiente"].Style.BackColor = System.Drawing.Color.White;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Cantidad"].Style.BackColor = System.Drawing.Color.White;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Costo Unitario"].Style.BackColor = System.Drawing.Color.White;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Total"].Style.BackColor = System.Drawing.Color.White;

                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Cantidad"].Value = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["C.Pendiente"].Value;
                obj.Cantidad = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["C.Pendiente"].Value.ToString());
            }
            else
            {
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Articulo"].Style.BackColor = System.Drawing.Color.Gray;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["C.Pendiente"].Style.BackColor = System.Drawing.Color.Gray;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Cantidad"].Style.BackColor = System.Drawing.Color.Gray;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Costo Unitario"].Style.BackColor = System.Drawing.Color.Gray;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Total"].Style.BackColor = System.Drawing.Color.Gray;

                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Cantidad"].Value = 0;
                obj.Cantidad = 0;
            }

            uow.FacturasAlmacenTMPdetalleBL.Update(obj);
            uow.SaveChanges();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) | Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad, cantidadPendiente;
            int id;

            cantidad = 0;
            try
            {
                cantidad = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString());
            }
            catch
            {
                dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value = dataGridView1.Rows[e.RowIndex].Cells["C.Pendiente"].Value;
                return;
            }




            cantidadPendiente = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["C.Pendiente"].Value.ToString());


            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());

            if (cantidad > cantidadPendiente)
            {
                //dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value = dataGridView1.Rows[e.RowIndex].Cells["Pendiente"].Value;

                dataGridView1.Rows[e.RowIndex].Cells["Articulo"].Style.BackColor = System.Drawing.Color.Maroon;
                dataGridView1.Rows[e.RowIndex].Cells["C.Pendiente"].Style.BackColor = System.Drawing.Color.Maroon;
                dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Style.BackColor = System.Drawing.Color.Maroon;
                dataGridView1.Rows[e.RowIndex].Cells["Costo Unitario"].Style.BackColor = System.Drawing.Color.Maroon;
                dataGridView1.Rows[e.RowIndex].Cells["Total"].Style.BackColor = System.Drawing.Color.Maroon;

            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells["Articulo"].Style.BackColor = System.Drawing.Color.White;
                dataGridView1.Rows[e.RowIndex].Cells["C.Pendiente"].Style.BackColor = System.Drawing.Color.White;
                dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Style.BackColor = System.Drawing.Color.White;
                dataGridView1.Rows[e.RowIndex].Cells["Costo Unitario"].Style.BackColor = System.Drawing.Color.White;
                dataGridView1.Rows[e.RowIndex].Cells["Total"].Style.BackColor = System.Drawing.Color.White;
            }


            if (cantidad == 0)
            {
                dataGridView1.Rows[e.RowIndex].Cells["Articulo"].Style.BackColor = System.Drawing.Color.Gray;
                dataGridView1.Rows[e.RowIndex].Cells["C.Pendiente"].Style.BackColor = System.Drawing.Color.Gray;
                dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Style.BackColor = System.Drawing.Color.Gray;
                dataGridView1.Rows[e.RowIndex].Cells["Costo Unitario"].Style.BackColor = System.Drawing.Color.Gray;
                dataGridView1.Rows[e.RowIndex].Cells["Total"].Style.BackColor = System.Drawing.Color.Gray;
            }


            FacturasAlmacenTMPdetalle obj = uow.FacturasAlmacenTMPdetalleBL.GetByID(id);
            obj.Cantidad = cantidad;
            uow.FacturasAlmacenTMPdetalleBL.Update(obj);
            uow.SaveChanges();

            List<FacturasAlmacenTMPdetalle> lista = uow.FacturasAlmacenTMPdetalleBL.Get(p => p.usuario == fx.xUsuario && p.Cantidad <= p.CantidadPendiente).ToList();

            txtImporte.Text = lista.Sum(p => p.Costo * p.Cantidad).ToString("C2");

        }


        #endregion



    }
}