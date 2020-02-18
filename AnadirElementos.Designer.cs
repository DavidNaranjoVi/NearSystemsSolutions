namespace NearSystemsSolutions
{
    partial class AnadirElementos
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
            this.dgExistentes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgIncluidos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgExistentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgIncluidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgExistentes
            // 
            this.dgExistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExistentes.Location = new System.Drawing.Point(15, 81);
            this.dgExistentes.Name = "dgExistentes";
            this.dgExistentes.RowHeadersWidth = 51;
            this.dgExistentes.Size = new System.Drawing.Size(384, 357);
            this.dgExistentes.TabIndex = 0;
            this.dgExistentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExistentes_CellContentClick);
            this.dgExistentes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgExistentes_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elementos existentes";
            // 
            // dgIncluidos
            // 
            this.dgIncluidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIncluidos.Location = new System.Drawing.Point(454, 81);
            this.dgIncluidos.Name = "dgIncluidos";
            this.dgIncluidos.RowHeadersWidth = 51;
            this.dgIncluidos.Size = new System.Drawing.Size(334, 357);
            this.dgIncluidos.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(567, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elementos incluidos";
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(553, 496);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(112, 42);
            this.bAceptar.TabIndex = 4;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bSalir
            // 
            this.bSalir.Location = new System.Drawing.Point(672, 496);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(116, 42);
            this.bSalir.TabIndex = 5;
            this.bSalir.Text = "Cancelar";
            this.bSalir.UseVisualStyleBackColor = true;
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // AnadirElementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.bSalir);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgIncluidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgExistentes);
            this.Name = "AnadirElementos";
            this.Text = "Form12";
            this.Load += new System.EventHandler(this.Form12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgExistentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgIncluidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgExistentes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgIncluidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bSalir;
    }
}