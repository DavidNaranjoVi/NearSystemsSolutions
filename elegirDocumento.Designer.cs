namespace NearSystemsSolutions
{
    partial class elegirDocumento
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bDocumentoContrato = new System.Windows.Forms.Button();
            this.bAbonado = new System.Windows.Forms.Button();
            this.bMantenimiento = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bDocumentoContrato, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bAbonado, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bMantenimiento, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 394);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bDocumentoContrato
            // 
            this.bDocumentoContrato.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bDocumentoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDocumentoContrato.Location = new System.Drawing.Point(42, 41);
            this.bDocumentoContrato.Name = "bDocumentoContrato";
            this.bDocumentoContrato.Size = new System.Drawing.Size(268, 114);
            this.bDocumentoContrato.TabIndex = 0;
            this.bDocumentoContrato.Text = "Generar documento de contrato";
            this.bDocumentoContrato.UseVisualStyleBackColor = true;
            this.bDocumentoContrato.Click += new System.EventHandler(this.BDocumentoContrato_Click);
            // 
            // bAbonado
            // 
            this.bAbonado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bAbonado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAbonado.Location = new System.Drawing.Point(380, 40);
            this.bAbonado.Name = "bAbonado";
            this.bAbonado.Size = new System.Drawing.Size(299, 117);
            this.bAbonado.TabIndex = 1;
            this.bAbonado.Text = "Generar documento de ficha de abonado";
            this.bAbonado.UseVisualStyleBackColor = true;
            this.bAbonado.Click += new System.EventHandler(this.BAbonado_Click);
            // 
            // bMantenimiento
            // 
            this.bMantenimiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMantenimiento.Location = new System.Drawing.Point(41, 240);
            this.bMantenimiento.Name = "bMantenimiento";
            this.bMantenimiento.Size = new System.Drawing.Size(271, 110);
            this.bMantenimiento.TabIndex = 2;
            this.bMantenimiento.Text = "Generar documento de mantenimiento";
            this.bMantenimiento.UseVisualStyleBackColor = true;
            this.bMantenimiento.Click += new System.EventHandler(this.BMantenimiento_Click);
            // 
            // elegirDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(731, 418);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "elegirDocumento";
            this.Text = "elegirDocumento";
            this.Load += new System.EventHandler(this.ElegirDocumento_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bDocumentoContrato;
        private System.Windows.Forms.Button bAbonado;
        private System.Windows.Forms.Button bMantenimiento;
    }
}