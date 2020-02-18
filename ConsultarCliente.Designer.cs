namespace NearSystemsSolutions
{
    partial class ConsultarCliente
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tApellido = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tDni = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbTipoCliente = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tCif = new System.Windows.Forms.TextBox();
            this.bConsultar = new System.Windows.Forms.Button();
            this.dataCliente = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.11738F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88262F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bConsultar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataCliente, 0, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.52139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.47861F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1327, 631);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.54971F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.45029F));
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tNombre, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tApellido, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tDni, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbTipoCliente, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tCif, 1, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(342, 255);
            this.tableLayoutPanel2.TabIndex = 20;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel2_Paint);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Azure;
            this.label11.Location = new System.Drawing.Point(3, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Cif";
            // 
            // tNombre
            // 
            this.tNombre.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tNombre.Location = new System.Drawing.Point(128, 15);
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(132, 20);
            this.tNombre.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Azure;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nombre";
            // 
            // tApellido
            // 
            this.tApellido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tApellido.Location = new System.Drawing.Point(128, 66);
            this.tApellido.Name = "tApellido";
            this.tApellido.Size = new System.Drawing.Size(132, 20);
            this.tApellido.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Azure;
            this.label17.Location = new System.Drawing.Point(3, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Apellido";
            // 
            // tDni
            // 
            this.tDni.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tDni.Location = new System.Drawing.Point(128, 117);
            this.tDni.Name = "tDni";
            this.tDni.Size = new System.Drawing.Size(132, 20);
            this.tDni.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Azure;
            this.label16.Location = new System.Drawing.Point(3, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Dni";
            // 
            // cbTipoCliente
            // 
            this.cbTipoCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbTipoCliente.FormattingEnabled = true;
            this.cbTipoCliente.Items.AddRange(new object[] {
            "Particular",
            "Empresa"});
            this.cbTipoCliente.Location = new System.Drawing.Point(128, 168);
            this.cbTipoCliente.Name = "cbTipoCliente";
            this.cbTipoCliente.Size = new System.Drawing.Size(132, 21);
            this.cbTipoCliente.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Azure;
            this.label15.Location = new System.Drawing.Point(3, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Tipo cliente";
            // 
            // tCif
            // 
            this.tCif.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tCif.Location = new System.Drawing.Point(128, 219);
            this.tCif.Name = "tCif";
            this.tCif.Size = new System.Drawing.Size(132, 20);
            this.tCif.TabIndex = 31;
            // 
            // bConsultar
            // 
            this.bConsultar.ForeColor = System.Drawing.Color.DarkCyan;
            this.bConsultar.Location = new System.Drawing.Point(1145, 264);
            this.bConsultar.Name = "bConsultar";
            this.bConsultar.Size = new System.Drawing.Size(157, 70);
            this.bConsultar.TabIndex = 21;
            this.bConsultar.Text = "Consultar";
            this.bConsultar.UseVisualStyleBackColor = true;
            this.bConsultar.Click += new System.EventHandler(this.BConsultar_Click);
            // 
            // dataCliente
            // 
            this.dataCliente.AccessibleName = "dg";
            this.dataCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCliente.Location = new System.Drawing.Point(3, 264);
            this.dataCliente.MultiSelect = false;
            this.dataCliente.Name = "dataCliente";
            this.dataCliente.ReadOnly = true;
            this.dataCliente.RowHeadersWidth = 51;
            this.dataCliente.RowTemplate.ReadOnly = true;
            this.dataCliente.Size = new System.Drawing.Size(1065, 364);
            this.dataCliente.TabIndex = 19;
            this.dataCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataCliente_CellContentClick);
            this.dataCliente.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataCliente_CellMouseDoubleClick);
            this.dataCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataCliente_KeyDown);
            // 
            // ConsultarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1347, 666);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ConsultarCliente";
            this.Load += new System.EventHandler(this.ConsultarCliente_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataCliente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tApellido;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tDni;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbTipoCliente;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tCif;
        private System.Windows.Forms.Button bConsultar;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}