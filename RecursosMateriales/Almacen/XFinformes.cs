using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace RecursosMateriales.Almacen
{
    public partial class XFinformes : DevExpress.XtraEditors.XtraForm
    {

          
        ReportDocument rptDocumentationExpired; 

        public String Reporte;
        public String Formula;
        public String titulo;


        public XFinformes()
        {
            InitializeComponent();
        }

        private void XFinformes_Load(object sender, EventArgs e)
        {
            ConfigureCrystalReports();
        }

        private void ConfigureCrystalReports(){
        
         
    
            ConnectionInfo myConnectionInfo = new ConnectionInfo();
            string reportPath;

            myConnectionInfo.DatabaseName = fx.xbd;
            myConnectionInfo.UserID = "sa";
            myConnectionInfo.Password = fx.xpass;
            myConnectionInfo.ServerName = @fx.xserver;            
            rptDocumentationExpired = new ReportDocument();

             
            reportPath = Application.StartupPath;        
            reportPath = reportPath + @"\Reportes\" + Reporte + ".rpt";

            this.Text = Reporte;

            rptDocumentationExpired.Load(reportPath);
 
            
            ////Solicitudes
            //if (Reporte == "InspeccionTN") { rptDocumentationExpired.RecordSelectionFormula = Formula;}
            //if (Reporte == "presupuesto") { rptDocumentationExpired.RecordSelectionFormula = Formula; }
            //if (Reporte == "TNOrdenDePago") { rptDocumentationExpired.RecordSelectionFormula = Formula; }
            //if (Reporte == "contrato") { rptDocumentationExpired.RecordSelectionFormula = Formula; }
 
            
            //ALMACEN
            if (Reporte == "InventarioInicial") { rptDocumentationExpired.RecordSelectionFormula = Formula; }

            




            this.crystalReportViewer1.ReportSource = rptDocumentationExpired;
            SetDBLogonForReport(myConnectionInfo, rptDocumentationExpired);

            
        }

        private void SetDBLogonForReport(ConnectionInfo myConnectionInfo, ReportDocument myReportDocument){
            Tables myTables = myReportDocument.Database.Tables;  //Dim myTables As Tables = myReportDocument.Database.Tables

            foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in myTables) {
                TableLogOnInfo myTableLogonInfo = myTable.LogOnInfo;
                myTableLogonInfo.ConnectionInfo =myConnectionInfo;
                myTable.ApplyLogOnInfo (myTableLogonInfo);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
             
        



     

    }
}