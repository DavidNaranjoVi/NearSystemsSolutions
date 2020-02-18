namespace NearSystemsSolutions
{
    partial class ConsultarFichaMantenimiento
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
            this.dgFichaMantenimiento = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgFichaMantenimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFichaMantenimiento
            // 
            this.dgFichaMantenimiento.AllowUserToAddRows = false;
            this.dgFichaMantenimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFichaMantenimiento.Location = new System.Drawing.Point(12, 52);
            this.dgFichaMantenimiento.MultiSelect = false;
            this.dgFichaMantenimiento.Name = "dgFichaMantenimiento";
            this.dgFichaMantenimiento.ReadOnly = true;
            this.dgFichaMantenimiento.Size = new System.Drawing.Size(1201, 342);
            this.dgFichaMantenimiento.TabIndex = 0;
            this.dgFichaMantenimiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgFichaMantenimiento_CellContentClick);
            this.dgFichaMantenimiento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgFichaMantenimiento_CellDoubleClick);
            this.dgFichaMantenimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgFichaMantenimiento_KeyDown);
            // 
            // ConsultarFichaMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1225, 512);
            this.Controls.Add(this.dgFichaMantenimiento);
            this.Name = "ConsultarFichaMantenimiento";
            this.Text = "ConsultarFichaMantenimiento";
            ((System.ComponentModel.ISupportInitialize)(this.dgFichaMantenimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFichaMantenimiento;
    }
}