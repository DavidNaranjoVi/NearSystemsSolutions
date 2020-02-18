namespace NearSystemsSolutions
{
    partial class consultaContrato
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tNContrato = new System.Windows.Forms.TextBox();
            this.tDniCif = new System.Windows.Forms.TextBox();
            this.tFechaContrato = new System.Windows.Forms.TextBox();
            this.tNAbonado = new System.Windows.Forms.TextBox();
            this.dgContratos = new System.Windows.Forms.DataGridView();
            this.bSalir = new System.Windows.Forms.Button();
            this.bConsultar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tCif = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número Contrato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(505, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha contrato";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nº Abonado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dni Cliente";
            // 
            // tNContrato
            // 
            this.tNContrato.Location = new System.Drawing.Point(107, 13);
            this.tNContrato.Name = "tNContrato";
            this.tNContrato.Size = new System.Drawing.Size(100, 20);
            this.tNContrato.TabIndex = 4;
            // 
            // tDniCif
            // 
            this.tDniCif.Location = new System.Drawing.Point(107, 56);
            this.tDniCif.Name = "tDniCif";
            this.tDniCif.Size = new System.Drawing.Size(100, 20);
            this.tDniCif.TabIndex = 5;
            // 
            // tFechaContrato
            // 
            this.tFechaContrato.Location = new System.Drawing.Point(590, 10);
            this.tFechaContrato.Name = "tFechaContrato";
            this.tFechaContrato.Size = new System.Drawing.Size(100, 20);
            this.tFechaContrato.TabIndex = 6;
            // 
            // tNAbonado
            // 
            this.tNAbonado.Location = new System.Drawing.Point(364, 10);
            this.tNAbonado.Name = "tNAbonado";
            this.tNAbonado.Size = new System.Drawing.Size(100, 20);
            this.tNAbonado.TabIndex = 7;
            // 
            // dgContratos
            // 
            this.dgContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContratos.Location = new System.Drawing.Point(12, 151);
            this.dgContratos.MultiSelect = false;
            this.dgContratos.Name = "dgContratos";
            this.dgContratos.RowHeadersWidth = 51;
            this.dgContratos.Size = new System.Drawing.Size(776, 287);
            this.dgContratos.TabIndex = 8;
            this.dgContratos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgContratos_CellContentClick);
            this.dgContratos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgContratos_CellMouseDoubleClick);
            this.dgContratos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgContratos_KeyDown);
            // 
            // bSalir
            // 
            this.bSalir.Location = new System.Drawing.Point(713, 89);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(75, 38);
            this.bSalir.TabIndex = 9;
            this.bSalir.Text = "Salir";
            this.bSalir.UseVisualStyleBackColor = true;
            // 
            // bConsultar
            // 
            this.bConsultar.Location = new System.Drawing.Point(615, 89);
            this.bConsultar.Name = "bConsultar";
            this.bConsultar.Size = new System.Drawing.Size(75, 38);
            this.bConsultar.TabIndex = 10;
            this.bConsultar.Text = "Consultar";
            this.bConsultar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cif";
            // 
            // tCif
            // 
            this.tCif.Location = new System.Drawing.Point(364, 63);
            this.tCif.Name = "tCif";
            this.tCif.Size = new System.Drawing.Size(100, 20);
            this.tCif.TabIndex = 12;
            // 
            // consultaContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tCif);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bConsultar);
            this.Controls.Add(this.bSalir);
            this.Controls.Add(this.dgContratos);
            this.Controls.Add(this.tNAbonado);
            this.Controls.Add(this.tFechaContrato);
            this.Controls.Add(this.tDniCif);
            this.Controls.Add(this.tNContrato);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "consultaContrato";
            this.Text = "consultaContrato";
            this.Load += new System.EventHandler(this.ConsultaContrato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tNContrato;
        private System.Windows.Forms.TextBox tDniCif;
        private System.Windows.Forms.TextBox tFechaContrato;
        private System.Windows.Forms.TextBox tNAbonado;
        private System.Windows.Forms.DataGridView dgContratos;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Button bConsultar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tCif;
    }
}