namespace NearSystemsSolutions
{
    partial class AnadirZona
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tZona = new System.Windows.Forms.TextBox();
            this.tArea = new System.Windows.Forms.TextBox();
            this.tDescripcion = new System.Windows.Forms.TextBox();
            this.dgZonasIncluidas = new System.Windows.Forms.DataGridView();
            this.bAnadir = new System.Windows.Forms.Button();
            this.bFinalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgZonasIncluidas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zona";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Area";
            // 
            // tZona
            // 
            this.tZona.Location = new System.Drawing.Point(51, 25);
            this.tZona.Name = "tZona";
            this.tZona.Size = new System.Drawing.Size(100, 20);
            this.tZona.TabIndex = 4;
            // 
            // tArea
            // 
            this.tArea.Location = new System.Drawing.Point(223, 24);
            this.tArea.Name = "tArea";
            this.tArea.Size = new System.Drawing.Size(100, 20);
            this.tArea.TabIndex = 5;
            // 
            // tDescripcion
            // 
            this.tDescripcion.Location = new System.Drawing.Point(443, 25);
            this.tDescripcion.Name = "tDescripcion";
            this.tDescripcion.Size = new System.Drawing.Size(304, 20);
            this.tDescripcion.TabIndex = 6;
            // 
            // dgZonasIncluidas
            // 
            this.dgZonasIncluidas.AllowUserToAddRows = false;
            this.dgZonasIncluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgZonasIncluidas.Location = new System.Drawing.Point(12, 104);
            this.dgZonasIncluidas.MultiSelect = false;
            this.dgZonasIncluidas.Name = "dgZonasIncluidas";
            this.dgZonasIncluidas.RowHeadersWidth = 51;
            this.dgZonasIncluidas.Size = new System.Drawing.Size(774, 179);
            this.dgZonasIncluidas.TabIndex = 7;
            this.dgZonasIncluidas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgZonasIncluidas_CellMouseDoubleClick);
            // 
            // bAnadir
            // 
            this.bAnadir.Location = new System.Drawing.Point(347, 72);
            this.bAnadir.Name = "bAnadir";
            this.bAnadir.Size = new System.Drawing.Size(100, 26);
            this.bAnadir.TabIndex = 8;
            this.bAnadir.Text = "Añadir";
            this.bAnadir.UseVisualStyleBackColor = true;
            this.bAnadir.Click += new System.EventHandler(this.bAnadir_Click);
            // 
            // bFinalizar
            // 
            this.bFinalizar.Location = new System.Drawing.Point(591, 72);
            this.bFinalizar.Name = "bFinalizar";
            this.bFinalizar.Size = new System.Drawing.Size(110, 23);
            this.bFinalizar.TabIndex = 9;
            this.bFinalizar.Text = "FInalizar";
            this.bFinalizar.UseVisualStyleBackColor = true;
            this.bFinalizar.Click += new System.EventHandler(this.bFinalizar_Click);
            // 
            // AnadirZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 299);
            this.Controls.Add(this.bFinalizar);
            this.Controls.Add(this.bAnadir);
            this.Controls.Add(this.dgZonasIncluidas);
            this.Controls.Add(this.tDescripcion);
            this.Controls.Add(this.tArea);
            this.Controls.Add(this.tZona);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AnadirZona";
            this.Text = "Form14";
            this.Load += new System.EventHandler(this.Form14_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgZonasIncluidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tZona;
        private System.Windows.Forms.TextBox tArea;
        private System.Windows.Forms.TextBox tDescripcion;
        public System.Windows.Forms.DataGridView dgZonasIncluidas;
        private System.Windows.Forms.Button bAnadir;
        private System.Windows.Forms.Button bFinalizar;
    }
}