namespace NearSystemsSolutions
{
    partial class ActualizarElemento
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
            this.tNombre = new System.Windows.Forms.TextBox();
            this.tDescripcion = new System.Windows.Forms.TextBox();
            this.tCodigo = new System.Windows.Forms.TextBox();
            this.bSalir = new System.Windows.Forms.Button();
            this.bEditar = new System.Windows.Forms.Button();
            this.bActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 226);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código";
            // 
            // tNombre
            // 
            this.tNombre.Location = new System.Drawing.Point(108, 62);
            this.tNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tNombre.Name = "tNombre";
            this.tNombre.ReadOnly = true;
            this.tNombre.Size = new System.Drawing.Size(132, 22);
            this.tNombre.TabIndex = 3;
            // 
            // tDescripcion
            // 
            this.tDescripcion.Location = new System.Drawing.Point(108, 223);
            this.tDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tDescripcion.Name = "tDescripcion";
            this.tDescripcion.ReadOnly = true;
            this.tDescripcion.Size = new System.Drawing.Size(132, 22);
            this.tDescripcion.TabIndex = 4;
            // 
            // tCodigo
            // 
            this.tCodigo.Location = new System.Drawing.Point(108, 150);
            this.tCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tCodigo.Name = "tCodigo";
            this.tCodigo.ReadOnly = true;
            this.tCodigo.Size = new System.Drawing.Size(132, 22);
            this.tCodigo.TabIndex = 5;
            // 
            // bSalir
            // 
            this.bSalir.Location = new System.Drawing.Point(512, 278);
            this.bSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(168, 62);
            this.bSalir.TabIndex = 6;
            this.bSalir.Text = "Salir";
            this.bSalir.UseVisualStyleBackColor = true;
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // bEditar
            // 
            this.bEditar.Location = new System.Drawing.Point(292, 278);
            this.bEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(188, 62);
            this.bEditar.TabIndex = 7;
            this.bEditar.Text = "Editar";
            this.bEditar.UseVisualStyleBackColor = true;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // bActualizar
            // 
            this.bActualizar.Location = new System.Drawing.Point(292, 279);
            this.bActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bActualizar.Name = "bActualizar";
            this.bActualizar.Size = new System.Drawing.Size(188, 60);
            this.bActualizar.TabIndex = 8;
            this.bActualizar.Text = "Actualizar";
            this.bActualizar.UseVisualStyleBackColor = true;
            this.bActualizar.Click += new System.EventHandler(this.bActualizar_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 363);
            this.Controls.Add(this.bActualizar);
            this.Controls.Add(this.bEditar);
            this.Controls.Add(this.bSalir);
            this.Controls.Add(this.tCodigo);
            this.Controls.Add(this.tDescripcion);
            this.Controls.Add(this.tNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form11";
            this.Text = "Form10";
            this.Load += new System.EventHandler(this.Form11_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.TextBox tDescripcion;
        private System.Windows.Forms.TextBox tCodigo;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Button bEditar;
        private System.Windows.Forms.Button bActualizar;
    }
}