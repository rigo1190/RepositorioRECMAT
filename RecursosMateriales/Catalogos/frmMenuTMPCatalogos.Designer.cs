namespace RecursosMateriales.Catalogos
{
    partial class frmMenuTMPCatalogos
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
            this.btnUnidadesPresupuestales = new System.Windows.Forms.Button();
            this.btnPartidasContables = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUnidadesPresupuestales
            // 
            this.btnUnidadesPresupuestales.Location = new System.Drawing.Point(8, 12);
            this.btnUnidadesPresupuestales.Name = "btnUnidadesPresupuestales";
            this.btnUnidadesPresupuestales.Size = new System.Drawing.Size(138, 23);
            this.btnUnidadesPresupuestales.TabIndex = 0;
            this.btnUnidadesPresupuestales.Text = "Unidades Presupuestales";
            this.btnUnidadesPresupuestales.UseVisualStyleBackColor = true;
            this.btnUnidadesPresupuestales.Click += new System.EventHandler(this.btnUnidadesPresupuestales_Click);
            // 
            // btnPartidasContables
            // 
            this.btnPartidasContables.Location = new System.Drawing.Point(8, 41);
            this.btnPartidasContables.Name = "btnPartidasContables";
            this.btnPartidasContables.Size = new System.Drawing.Size(138, 23);
            this.btnPartidasContables.TabIndex = 1;
            this.btnPartidasContables.Text = "Partidas Contables";
            this.btnPartidasContables.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(8, 236);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmMenuTMPCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPartidasContables);
            this.Controls.Add(this.btnUnidadesPresupuestales);
            this.Name = "frmMenuTMPCatalogos";
            this.Text = "frmMenuTMPCatalogos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnidadesPresupuestales;
        private System.Windows.Forms.Button btnPartidasContables;
        private System.Windows.Forms.Button btnSalir;
    }
}