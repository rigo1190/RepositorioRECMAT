﻿namespace RecursosMateriales.Almacen
{
    partial class frmMenuTMPalmacen
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnCargaAutomatica = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargaArchivo = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargaManual = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnComprasMenores = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(27, 230);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnCargaAutomatica);
            this.groupControl1.Controls.Add(this.btnCargaArchivo);
            this.groupControl1.Controls.Add(this.btnCargaManual);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(174, 128);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Inventario Inicial";
            // 
            // btnCargaAutomatica
            // 
            this.btnCargaAutomatica.Location = new System.Drawing.Point(15, 91);
            this.btnCargaAutomatica.Name = "btnCargaAutomatica";
            this.btnCargaAutomatica.Size = new System.Drawing.Size(146, 23);
            this.btnCargaAutomatica.TabIndex = 2;
            this.btnCargaAutomatica.Text = "Carga Automática ";
            // 
            // btnCargaArchivo
            // 
            this.btnCargaArchivo.Location = new System.Drawing.Point(15, 62);
            this.btnCargaArchivo.Name = "btnCargaArchivo";
            this.btnCargaArchivo.Size = new System.Drawing.Size(146, 23);
            this.btnCargaArchivo.TabIndex = 1;
            this.btnCargaArchivo.Text = "Carga desde Archivo";
            this.btnCargaArchivo.Click += new System.EventHandler(this.btnCargaArchivo_Click);
            // 
            // btnCargaManual
            // 
            this.btnCargaManual.Location = new System.Drawing.Point(15, 33);
            this.btnCargaManual.Name = "btnCargaManual";
            this.btnCargaManual.Size = new System.Drawing.Size(146, 23);
            this.btnCargaManual.TabIndex = 0;
            this.btnCargaManual.Text = "Carga &Manual";
            this.btnCargaManual.Click += new System.EventHandler(this.btnCargaManual_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnComprasMenores);
            this.groupControl2.Controls.Add(this.simpleButton3);
            this.groupControl2.Location = new System.Drawing.Point(192, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(174, 128);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Entradas al almacen";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(15, 33);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(146, 23);
            this.simpleButton3.TabIndex = 0;
            this.simpleButton3.Text = "X Pedidos";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnComprasMenores
            // 
            this.btnComprasMenores.Location = new System.Drawing.Point(15, 62);
            this.btnComprasMenores.Name = "btnComprasMenores";
            this.btnComprasMenores.Size = new System.Drawing.Size(146, 23);
            this.btnComprasMenores.TabIndex = 1;
            this.btnComprasMenores.Text = "X Compras Menores";
            this.btnComprasMenores.Click += new System.EventHandler(this.btnComprasMenores_Click);
            // 
            // frmMenuTMPalmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 262);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmMenuTMPalmacen";
            this.Text = "Menu Temporal de Almacen";
            this.Load += new System.EventHandler(this.frmMenuTMPalmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnCargaAutomatica;
        private DevExpress.XtraEditors.SimpleButton btnCargaArchivo;
        private DevExpress.XtraEditors.SimpleButton btnCargaManual;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnComprasMenores;
    }
}