namespace NearSystemsSolutions
{
    partial class ConsultarBorrador
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
            this.bConsultar = new System.Windows.Forms.Button();
            this.tNombreBorrador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgBorrador = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgBorrador)).BeginInit();
            this.SuspendLayout();
            // 
            // bConsultar
            // 
            this.bConsultar.Location = new System.Drawing.Point(802, 190);
            this.bConsultar.Name = "bConsultar";
            this.bConsultar.Size = new System.Drawing.Size(118, 42);
            this.bConsultar.TabIndex = 7;
            this.bConsultar.Text = "Consultar";
            this.bConsultar.UseVisualStyleBackColor = true;
            // 
            // tNombreBorrador
            // 
            this.tNombreBorrador.Location = new System.Drawing.Point(272, 89);
            this.tNombreBorrador.Name = "tNombreBorrador";
            this.tNombreBorrador.Size = new System.Drawing.Size(100, 20);
            this.tNombreBorrador.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre del borrador";
            // 
            // dgBorrador
            // 
            this.dgBorrador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBorrador.Location = new System.Drawing.Point(161, 267);
            this.dgBorrador.MultiSelect = false;
            this.dgBorrador.Name = "dgBorrador";
            this.dgBorrador.RowHeadersWidth = 51;
            this.dgBorrador.Size = new System.Drawing.Size(776, 180);
            this.dgBorrador.TabIndex = 4;
            this.dgBorrador.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgBorrador_CellContentClick_1);
            this.dgBorrador.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgBorrador_CellMouseDoubleClick);
            this.dgBorrador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgBorrador_KeyDown);
            // 
            // ConsultarBorrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 608);
            this.Controls.Add(this.bConsultar);
            this.Controls.Add(this.tNombreBorrador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgBorrador);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConsultarBorrador";
            this.Text = "ConsultarBorrador";
            this.Load += new System.EventHandler(this.ConsultarBorrador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBorrador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConsultar;
        private System.Windows.Forms.TextBox tNombreBorrador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgBorrador;
    }
}