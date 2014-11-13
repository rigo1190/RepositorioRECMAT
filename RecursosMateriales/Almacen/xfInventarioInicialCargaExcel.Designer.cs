namespace RecursosMateriales.Almacen
{
    partial class xfInventarioInicialCargaExcel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.PanelImportar = new DevExpress.XtraEditors.GroupControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelImportar)).BeginInit();
            this.PanelImportar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnExportar);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(188, 53);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Exportar Catálogo de Articulos";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(33, 24);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(123, 23);
            this.btnExportar.TabIndex = 0;
            this.btnExportar.Text = "A) Exportar...";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dataGridView1);
            this.groupControl2.Location = new System.Drawing.Point(4, 120);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(575, 227);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Detalle de Artículos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(552, 198);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnImportar);
            this.groupControl3.Location = new System.Drawing.Point(197, 3);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(188, 53);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Importar Existencias";
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(33, 24);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(123, 23);
            this.btnImportar.TabIndex = 0;
            this.btnImportar.Text = "B) Importar...";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Enabled = false;
            this.btnTerminar.Location = new System.Drawing.Point(38, 24);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(123, 23);
            this.btnTerminar.TabIndex = 3;
            this.btnTerminar.Text = "C) Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.btnTerminar);
            this.groupControl4.Location = new System.Drawing.Point(391, 3);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(188, 53);
            this.groupControl4.TabIndex = 4;
            this.groupControl4.Text = "Terminar Proceso";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(15, 24);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 23);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "&Reporte";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(600, 320);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.btnImprimir);
            this.groupControl5.Location = new System.Drawing.Point(585, 3);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(121, 53);
            this.groupControl5.TabIndex = 6;
            this.groupControl5.Text = "Ver";
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.txtStatus);
            this.groupControl6.Location = new System.Drawing.Point(3, 62);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(576, 53);
            this.groupControl6.TabIndex = 7;
            this.groupControl6.Text = "Status ";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(20, 24);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(529, 21);
            this.txtStatus.TabIndex = 0;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PanelImportar
            // 
            this.PanelImportar.Controls.Add(this.progressBar1);
            this.PanelImportar.Controls.Add(this.btnCargarDatos);
            this.PanelImportar.Controls.Add(this.btnBuscarArchivo);
            this.PanelImportar.Controls.Add(this.label2);
            this.PanelImportar.Controls.Add(this.txtHoja);
            this.PanelImportar.Controls.Add(this.label1);
            this.PanelImportar.Controls.Add(this.txtArchivo);
            this.PanelImportar.Location = new System.Drawing.Point(4, 353);
            this.PanelImportar.Name = "PanelImportar";
            this.PanelImportar.Size = new System.Drawing.Size(575, 99);
            this.PanelImportar.TabIndex = 8;
            this.PanelImportar.Text = "Indique la ruta del archivo y el nombre de hoja de los datos a importar.";
            this.PanelImportar.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 70);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(542, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.Location = new System.Drawing.Point(473, 41);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(92, 23);
            this.btnCargarDatos.TabIndex = 6;
            this.btnCargarDatos.Text = "Cargar Datos";
            this.btnCargarDatos.UseVisualStyleBackColor = true;
            this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Location = new System.Drawing.Point(334, 42);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(35, 23);
            this.btnBuscarArchivo.TabIndex = 4;
            this.btnBuscarArchivo.Text = "...";
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre de la Hoja";
            // 
            // txtHoja
            // 
            this.txtHoja.Location = new System.Drawing.Point(375, 43);
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.Size = new System.Drawing.Size(92, 21);
            this.txtHoja.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archivo";
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(23, 42);
            this.txtArchivo.Multiline = true;
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(305, 21);
            this.txtArchivo.TabIndex = 0;
            // 
            // xfInventarioInicialCargaExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 351);
            this.Controls.Add(this.PanelImportar);
            this.Controls.Add(this.groupControl6);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "xfInventarioInicialCargaExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Inventario Inicial (Desde Excel)";
            this.Load += new System.EventHandler(this.xfInventarioInicialCargaExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelImportar)).EndInit();
            this.PanelImportar.ResumeLayout(false);
            this.PanelImportar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button btnExportar;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnTerminar;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.TextBox txtStatus;
        private DevExpress.XtraEditors.GroupControl PanelImportar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCargarDatos;
        private System.Windows.Forms.Button btnBuscarArchivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArchivo;
    }
}