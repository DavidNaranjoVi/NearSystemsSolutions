namespace NearSystemsSolutions
{
    partial class AnadirPersonaContacto
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
            this.label5 = new System.Windows.Forms.Label();
            this.tUsuario = new System.Windows.Forms.TextBox();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.tTelefono1 = new System.Windows.Forms.TextBox();
            this.tTelefono2 = new System.Windows.Forms.TextBox();
            this.tConsigna = new System.Windows.Forms.TextBox();
            this.dgContactosIncluidos = new System.Windows.Forms.DataGridView();
            this.bAnadir = new System.Windows.Forms.Button();
            this.bFinalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgContactosIncluidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Consigna Individual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Teléfono 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Teléfono 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nombre";
            // 
            // tUsuario
            // 
            this.tUsuario.Location = new System.Drawing.Point(62, 19);
            this.tUsuario.Name = "tUsuario";
            this.tUsuario.Size = new System.Drawing.Size(100, 20);
            this.tUsuario.TabIndex = 5;
            // 
            // tNombre
            // 
            this.tNombre.Location = new System.Drawing.Point(62, 64);
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(189, 20);
            this.tNombre.TabIndex = 6;
            // 
            // tTelefono1
            // 
            this.tTelefono1.Location = new System.Drawing.Point(364, 64);
            this.tTelefono1.Name = "tTelefono1";
            this.tTelefono1.Size = new System.Drawing.Size(128, 20);
            this.tTelefono1.TabIndex = 7;
            // 
            // tTelefono2
            // 
            this.tTelefono2.Location = new System.Drawing.Point(587, 64);
            this.tTelefono2.Name = "tTelefono2";
            this.tTelefono2.Size = new System.Drawing.Size(127, 20);
            this.tTelefono2.TabIndex = 8;
            // 
            // tConsigna
            // 
            this.tConsigna.Location = new System.Drawing.Point(117, 115);
            this.tConsigna.Name = "tConsigna";
            this.tConsigna.Size = new System.Drawing.Size(189, 20);
            this.tConsigna.TabIndex = 9;
            // 
            // dgContactosIncluidos
            // 
            this.dgContactosIncluidos.AllowUserToAddRows = false;
            this.dgContactosIncluidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContactosIncluidos.Location = new System.Drawing.Point(12, 177);
            this.dgContactosIncluidos.MultiSelect = false;
            this.dgContactosIncluidos.Name = "dgContactosIncluidos";
            this.dgContactosIncluidos.ReadOnly = true;
            this.dgContactosIncluidos.RowHeadersWidth = 51;
            this.dgContactosIncluidos.Size = new System.Drawing.Size(776, 261);
            this.dgContactosIncluidos.TabIndex = 10;
            // 
            // bAnadir
            // 
            this.bAnadir.Location = new System.Drawing.Point(492, 108);
            this.bAnadir.Name = "bAnadir";
            this.bAnadir.Size = new System.Drawing.Size(107, 32);
            this.bAnadir.TabIndex = 11;
            this.bAnadir.Text = "Añadir";
            this.bAnadir.UseVisualStyleBackColor = true;
            this.bAnadir.Click += new System.EventHandler(this.bAnadir_Click);
            // 
            // bFinalizar
            // 
            this.bFinalizar.Location = new System.Drawing.Point(665, 108);
            this.bFinalizar.Name = "bFinalizar";
            this.bFinalizar.Size = new System.Drawing.Size(93, 32);
            this.bFinalizar.TabIndex = 12;
            this.bFinalizar.Text = "Finalizar";
            this.bFinalizar.UseVisualStyleBackColor = true;
            this.bFinalizar.Click += new System.EventHandler(this.bFinalizar_Click);
            // 
            // AnadirPersonaContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bFinalizar);
            this.Controls.Add(this.bAnadir);
            this.Controls.Add(this.dgContactosIncluidos);
            this.Controls.Add(this.tConsigna);
            this.Controls.Add(this.tTelefono2);
            this.Controls.Add(this.tTelefono1);
            this.Controls.Add(this.tNombre);
            this.Controls.Add(this.tUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AnadirPersonaContacto";
            this.Text = "Form15";
            this.Load += new System.EventHandler(this.Form15_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgContactosIncluidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tUsuario;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.TextBox tTelefono1;
        private System.Windows.Forms.TextBox tTelefono2;
        private System.Windows.Forms.TextBox tConsigna;
        public System.Windows.Forms.DataGridView dgContactosIncluidos;
        private System.Windows.Forms.Button bAnadir;
        private System.Windows.Forms.Button bFinalizar;
    }
}