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
        DevExpress.Xpo.UnitOfWork xpoUow;
        private int _indexNew;
        public frmUnidadesMedida()
        {
            InitializeComponent();
            uow = new BusinessLogicLayer.UnitOfWork();
            gridControl1.DataSource = uow.UnidadesDeMedidaBL.Get().ToList();
            



        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.AddNewRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnNuevo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            



        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                _indexNew = gridView1.FocusedRowHandle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "gridView1_InitNewRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        


        //public static IDataLayer GetDataLayer()
        //{
        //    try
        //    {

        //        //MessageBox.Show("Entro a getAccess");
        //        var server = @"RIGO-PC\SQLEXPRESS";
        //        var username ="sa";
        //        var password = "081995";
        //        var catalog = "BD3SoftBL";

        //        var Conn = MSSqlConnectionProvider.GetConnectionString
        //            (
        //                server,
        //                username,
        //                password,
        //                catalog
        //             );

        //        return XpoDefault.GetDataLayer(Conn, AutoCreateOption.DatabaseAndSchema);
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        return null;
        //    }



        //}



    }
}
