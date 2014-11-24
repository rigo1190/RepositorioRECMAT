using BusinessLogicLayer;
using DataAccessLayer.Models;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecursosMateriales.Catalogos
{
    public partial class frmUnidadesMedida : Form
    {

        private BusinessLogicLayer.UnitOfWork uow;
        private bool nuevo;
        private bool actualizar;

        public frmUnidadesMedida()
        {
            InitializeComponent();
            uow = new BusinessLogicLayer.UnitOfWork();
            BindGrid();
        }


        private void BindGrid()
        {
            gridControl1.DataSource = Utilerias.GenerarDataTable<UnidadesDeMedida>(uow.UnidadesDeMedidaBL.Get().ToList());
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            MessageBoxIcon icon = MessageBoxIcon.Information;
            UnidadesDeMedida obj;
            string M = "Se ha guardado correctamente";
            
            try
            {

                if (row["Clave"].ToString().Trim().Equals(string.Empty) || row["Nombre"].ToString().Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Los datos que se intentan guardar son vacios. Intente de nuevo", "Guardar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Valid = false;
                    return;
                }

                if (nuevo)
                {

                    if (ValidarClaveUnidadDeMedida(row["Clave"].ToString().Trim()))
                    {
                        obj = new UnidadesDeMedida();
                        obj.Clave = row["Clave"].ToString();
                        obj.Nombre = row["Nombre"].ToString();
                        uow.UnidadesDeMedidaBL.Insert(obj);
                        uow.SaveChanges();
                        nuevo = false;
                        gridControl1.EmbeddedNavigator.Buttons.Append.Enabled = true;
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Id", obj.Id.ToString());

                    }
                    else
                    {
                        M = "La clave se encuentra duplicada, intente con una diferente.";
                        icon = MessageBoxIcon.Error;
                        e.Valid = false;
                    }
                }
                else
                {
                    if (actualizar)
                    {
                        if (ValidarClaveUnidadDeMedida(row["Clave"].ToString().Trim()))
                        {
                            obj = uow.UnidadesDeMedidaBL.GetByID(Utilerias.StrToInt(row["Id"].ToString()));
                            obj.Clave = row["Clave"].ToString();
                            obj.Nombre = row["Nombre"].ToString();

                            uow.UnidadesDeMedidaBL.Update(obj);
                            uow.SaveChanges();
                            actualizar = false;
                        }
                        else
                        {
                            M = "La clave se encuentra duplicada, intente con una diferente.";
                            icon = MessageBoxIcon.Error;
                            e.Valid = false;
                        }
                        
                        
                    }

                }

                //Si hubo errores
                if (uow.Errors.Count > 0)
                {
                    M = string.Empty;

                    foreach (string m in uow.Errors)
                        M += m;

                    icon = MessageBoxIcon.Error;

                }

                MessageBox.Show(M, "Guardar registro", MessageBoxButtons.OK, icon);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "gridView1_ValidateRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private bool ValidarClaveUnidadDeMedida(string clave)
        {
            List<UnidadesDeMedida> list = uow.UnidadesDeMedidaBL.Get(e => e.Clave == clave).ToList();
            return list.Count == 0;

        }


        private bool ValidarEliminacionUnidad(UnidadesDeMedida obj)
        {
            if (obj.UMcompras.Count > 0)
                return false;

            if (obj.UMventas.Count > 0)
                return false;

            return true;
        }


        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            actualizar = true;
        }

        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                nuevo = true;
                gridControl1.EmbeddedNavigator.Buttons.Append.Enabled = false;
                gridView1.GetFocusedRow();
                gridView1.FocusedColumn = gridView1.Columns["Clave"];
            }

            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                UnidadesDeMedida obj;
                DataRow row = gridView1.GetFocusedDataRow();

                obj = uow.UnidadesDeMedidaBL.GetByID(Utilerias.StrToInt(row["Id"].ToString()));

                if (!ValidarEliminacionUnidad(obj))
                {
                    MessageBox.Show("No se puede eliminar el registro, ya que se ha utilizado en otros módulos", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true;
                    return;
                }


                if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Eliminar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    uow.UnidadesDeMedidaBL.Delete(obj);
                    uow.SaveChanges();

                    //Si hubo errores
                    if (uow.Errors.Count > 0)
                    {
                        string M = string.Empty;

                        foreach (string m in uow.Errors)
                            M += m;

                        MessageBox.Show(M, "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                    e.Handled = true;

            }

        }


    }
}
