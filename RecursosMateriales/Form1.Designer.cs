namespace RecursosMateriales
{
    partial class Form1
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
            this.btnCatalogos = new System.Windows.Forms.Button();
            this.btnAdquisiciones = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnInventarios = new System.Windows.Forms.Button();
            this.btnSali = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCatalogos
            // 
            this.btnCatalogos.Location = new System.Drawing.Point(12, 12);
            this.btnCatalogos.Name = "btnCatalogos";
            this.btnCatalogos.Size = new System.Drawing.Size(102, 23);
            this.btnCatalogos.TabIndex = 0;
            this.btnCatalogos.Text = "Catalogos";
            this.btnCatalogos.UseVisualStyleBackColor = true;
            this.btnCatalogos.Click += new System.EventHandler(this.btnCatalogos_Click);
            // 
            // btnAdquisiciones
            // 
            this.btnAdquisiciones.Location = new System.Drawing.Point(12, 37);
            this.btnAdquisiciones.Name = "btnAdquisiciones";
            this.btnAdquisiciones.Size = new System.Drawing.Size(102, 23);
            this.btnAdquisiciones.TabIndex = 1;
            this.btnAdquisiciones.Text = "Adquisiciones";
            this.btnAdquisiciones.UseVisualStyleBackColor = true;
            this.btnAdquisiciones.Click += new System.EventHandler(this.btnAdquisiciones_Click);
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.Location = new System.Drawing.Point(12, 66);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(102, 23);
            this.btnAlmacen.TabIndex = 2;
            this.btnAlmacen.Text = "Almacen";
            this.btnAlmacen.UseVisualStyleBackColor = true;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(12, 95);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(102, 23);
            this.btnVentas.TabIndex = 3;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnInventarios
            // 
            this.btnInventarios.Location = new System.Drawing.Point(12, 124);
            this.btnInventarios.Name = "btnInventarios";
            this.btnInventarios.Size = new System.Drawing.Size(102, 23);
            this.btnInventarios.TabIndex = 4;
            this.btnInventarios.Text = "Inventarios";
            this.btnInventarios.UseVisualStyleBackColor = true;
            // 
            // btnSali
            // 
            this.btnSali.Location = new System.Drawing.Point(14, 172);
            this.btnSali.Name = "btnSali";
            this.btnSali.Size = new System.Drawing.Size(102, 23);
            this.btnSali.TabIndex = 5;
            this.btnSali.Text = "&Salir";
            this.btnSali.UseVisualStyleBackColor = true;
            this.btnSali.Click += new System.EventHandler(this.btnSali_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 225);
            this.Controls.Add(this.btnSali);
            this.Controls.Add(this.btnInventarios);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnAlmacen);
            this.Controls.Add(this.btnAdquisiciones);
            this.Controls.Add(this.btnCatalogos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCatalogos;
        private System.Windows.Forms.Button btnAdquisiciones;
        private System.Windows.Forms.Button btnAlmacen;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnInventarios;
        private System.Windows.Forms.Button btnSali;
    }
}

