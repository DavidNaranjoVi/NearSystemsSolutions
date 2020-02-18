using System.Windows.Forms;

namespace NearSystemsSolutions
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pPanel = new System.Windows.Forms.Panel();
            this.pPanelBig = new System.Windows.Forms.Panel();
            this.pPanelSide = new System.Windows.Forms.Panel();
            this.pPanelMantenimiento = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pM = new System.Windows.Forms.PictureBox();
            this.pPanelAnexo = new System.Windows.Forms.Panel();
            this.bConsultarAnexo = new System.Windows.Forms.Button();
            this.bAnadirAnexo = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pPanelDoc = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pPanelCliente = new System.Windows.Forms.Panel();
            this.bAnadirEmpresa = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bConsultarCliente = new System.Windows.Forms.Button();
            this.bAnadirCliente = new System.Windows.Forms.Button();
            this.pPanelFichaAbonado = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pPanelElemento = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pPanelContrato = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.nAnadirContrato = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pPanel.SuspendLayout();
            this.pPanelSide.SuspendLayout();
            this.pPanelMantenimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pM)).BeginInit();
            this.pPanelAnexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.pPanelDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pPanelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pPanelFichaAbonado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.pPanelElemento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.pPanelContrato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pPanel
            // 
            this.pPanel.AutoSize = true;
            this.pPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(171)))));
            this.pPanel.Controls.Add(this.pPanelBig);
            this.pPanel.Controls.Add(this.pPanelSide);
            this.pPanel.Location = new System.Drawing.Point(2, 2);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(1000, 899);
            this.pPanel.TabIndex = 1;
            // 
            // pPanelBig
            // 
            this.pPanelBig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPanelBig.AutoSize = true;
            this.pPanelBig.Location = new System.Drawing.Point(163, 10);
            this.pPanelBig.Name = "pPanelBig";
            this.pPanelBig.Size = new System.Drawing.Size(200, 499);
            this.pPanelBig.TabIndex = 0;
            // 
            // pPanelSide
            // 
            this.pPanelSide.AutoScroll = true;
            this.pPanelSide.AutoSize = true;
            this.pPanelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.pPanelSide.Controls.Add(this.pPanelMantenimiento);
            this.pPanelSide.Controls.Add(this.pPanelAnexo);
            this.pPanelSide.Controls.Add(this.pPanelDoc);
            this.pPanelSide.Controls.Add(this.pPanelCliente);
            this.pPanelSide.Controls.Add(this.pPanelFichaAbonado);
            this.pPanelSide.Controls.Add(this.pPanelElemento);
            this.pPanelSide.Controls.Add(this.pPanelContrato);
            this.pPanelSide.Controls.Add(this.pictureBox2);
            this.pPanelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pPanelSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pPanelSide.Location = new System.Drawing.Point(0, 0);
            this.pPanelSide.Margin = new System.Windows.Forms.Padding(2);
            this.pPanelSide.Name = "pPanelSide";
            this.pPanelSide.Size = new System.Drawing.Size(160, 899);
            this.pPanelSide.TabIndex = 0;
            // 
            // pPanelMantenimiento
            // 
            this.pPanelMantenimiento.Controls.Add(this.button1);
            this.pPanelMantenimiento.Controls.Add(this.button2);
            this.pPanelMantenimiento.Controls.Add(this.pM);
            this.pPanelMantenimiento.Location = new System.Drawing.Point(13, 537);
            this.pPanelMantenimiento.Margin = new System.Windows.Forms.Padding(2);
            this.pPanelMantenimiento.Name = "pPanelMantenimiento";
            this.pPanelMantenimiento.Size = new System.Drawing.Size(138, 70);
            this.pPanelMantenimiento.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 115);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Consultar ficha mantenimiento";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 72);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Añadir ficha mantenimiento";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // pM
            // 
            this.pM.Image = ((System.Drawing.Image)(resources.GetObject("pM.Image")));
            this.pM.Location = new System.Drawing.Point(2, 2);
            this.pM.Margin = new System.Windows.Forms.Padding(2);
            this.pM.Name = "pM";
            this.pM.Size = new System.Drawing.Size(136, 66);
            this.pM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pM.TabIndex = 0;
            this.pM.TabStop = false;
            this.pM.Click += new System.EventHandler(this.PM_Click);
            // 
            // pPanelAnexo
            // 
            this.pPanelAnexo.Controls.Add(this.bConsultarAnexo);
            this.pPanelAnexo.Controls.Add(this.bAnadirAnexo);
            this.pPanelAnexo.Controls.Add(this.pictureBox7);
            this.pPanelAnexo.Location = new System.Drawing.Point(11, 444);
            this.pPanelAnexo.Margin = new System.Windows.Forms.Padding(2);
            this.pPanelAnexo.Name = "pPanelAnexo";
            this.pPanelAnexo.Size = new System.Drawing.Size(142, 70);
            this.pPanelAnexo.TabIndex = 7;
            // 
            // bConsultarAnexo
            // 
            this.bConsultarAnexo.Location = new System.Drawing.Point(2, 109);
            this.bConsultarAnexo.Margin = new System.Windows.Forms.Padding(2);
            this.bConsultarAnexo.Name = "bConsultarAnexo";
            this.bConsultarAnexo.Size = new System.Drawing.Size(136, 32);
            this.bConsultarAnexo.TabIndex = 2;
            this.bConsultarAnexo.Text = "Consultar anexo";
            this.bConsultarAnexo.UseVisualStyleBackColor = true;
            this.bConsultarAnexo.Click += new System.EventHandler(this.BConsultarAnexo_Click);
            // 
            // bAnadirAnexo
            // 
            this.bAnadirAnexo.Location = new System.Drawing.Point(2, 72);
            this.bAnadirAnexo.Margin = new System.Windows.Forms.Padding(2);
            this.bAnadirAnexo.Name = "bAnadirAnexo";
            this.bAnadirAnexo.Size = new System.Drawing.Size(136, 35);
            this.bAnadirAnexo.TabIndex = 1;
            this.bAnadirAnexo.Text = "Añadir anexo";
            this.bAnadirAnexo.UseVisualStyleBackColor = true;
            this.bAnadirAnexo.Click += new System.EventHandler(this.BAnadirAnexo_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(2, 2);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(136, 66);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.PictureBox7_Click);
            // 
            // pPanelDoc
            // 
            this.pPanelDoc.Controls.Add(this.button8);
            this.pPanelDoc.Controls.Add(this.button9);
            this.pPanelDoc.Controls.Add(this.pictureBox4);
            this.pPanelDoc.Location = new System.Drawing.Point(9, 730);
            this.pPanelDoc.Margin = new System.Windows.Forms.Padding(2);
            this.pPanelDoc.Name = "pPanelDoc";
            this.pPanelDoc.Size = new System.Drawing.Size(142, 70);
            this.pPanelDoc.TabIndex = 4;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(2, 111);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(136, 32);
            this.button8.TabIndex = 2;
            this.button8.Text = "Configuración";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(2, 72);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(136, 35);
            this.button9.TabIndex = 1;
            this.button9.Text = "Generar documento";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(2, 2);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(138, 66);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // pPanelCliente
            // 
            this.pPanelCliente.Controls.Add(this.bAnadirEmpresa);
            this.pPanelCliente.Controls.Add(this.pictureBox1);
            this.pPanelCliente.Controls.Add(this.bConsultarCliente);
            this.pPanelCliente.Controls.Add(this.bAnadirCliente);
            this.pPanelCliente.Location = new System.Drawing.Point(16, 115);
            this.pPanelCliente.Margin = new System.Windows.Forms.Padding(2);
            this.pPanelCliente.Name = "pPanelCliente";
            this.pPanelCliente.Size = new System.Drawing.Size(138, 67);
            this.pPanelCliente.TabIndex = 0;
            // 
            // bAnadirEmpresa
            // 
            this.bAnadirEmpresa.Location = new System.Drawing.Point(3, 111);
            this.bAnadirEmpresa.Name = "bAnadirEmpresa";
            this.bAnadirEmpresa.Size = new System.Drawing.Size(132, 23);
            this.bAnadirEmpresa.TabIndex = 3;
            this.bAnadirEmpresa.Text = "Añadir empresa";
            this.bAnadirEmpresa.UseVisualStyleBackColor = true;
            this.bAnadirEmpresa.Click += new System.EventHandler(this.BAnadirEmpresa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // bConsultarCliente
            // 
            this.bConsultarCliente.Location = new System.Drawing.Point(2, 136);
            this.bConsultarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.bConsultarCliente.Name = "bConsultarCliente";
            this.bConsultarCliente.Size = new System.Drawing.Size(134, 34);
            this.bConsultarCliente.TabIndex = 2;
            this.bConsultarCliente.Text = "Consultar cliente";
            this.bConsultarCliente.UseVisualStyleBackColor = true;
            this.bConsultarCliente.Click += new System.EventHandler(this.BConsultarCliente_Click);
            // 
            // bAnadirCliente
            // 
            this.bAnadirCliente.Location = new System.Drawing.Point(2, 72);
            this.bAnadirCliente.Margin = new System.Windows.Forms.Padding(2);
            this.bAnadirCliente.Name = "bAnadirCliente";
            this.bAnadirCliente.Size = new System.Drawing.Size(134, 35);
            this.bAnadirCliente.TabIndex = 1;
            this.bAnadirCliente.Text = "Añadir cliente";
            this.bAnadirCliente.UseVisualStyleBackColor = true;
            this.bAnadirCliente.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pPanelFichaAbonado
            // 
            this.pPanelFichaAbonado.Controls.Add(this.button14);
            this.pPanelFichaAbonado.Controls.Add(this.button15);
            this.pPanelFichaAbonado.Controls.Add(this.pictureBox6);
            this.pPanelFichaAbonado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pPanelFichaAbonado.Location = new System.Drawing.Point(11, 332);
            this.pPanelFichaAbonado.Margin = new System.Windows.Forms.Padding(2);
            this.pPanelFichaAbonado.Name = "pPanelFichaAbonado";
            this.pPanelFichaAbonado.Size = new System.Drawing.Size(142, 71);
            this.pPanelFichaAbonado.TabIndex = 6;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(2, 109);
            this.button14.Margin = new System.Windows.Forms.Padding(2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(136, 32);
            this.button14.TabIndex = 2;
            this.button14.Text = "Consultar ficha abonado";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(2, 72);
            this.button15.Margin = new System.Windows.Forms.Padding(2);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(136, 35);
            this.button15.TabIndex = 1;
            this.button15.Text = "Añadir ficha abonado";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button15_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(2, 2);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(136, 66);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.PictureBox6_Click);
            // 
            // pPanelElemento
            // 
            this.pPanelElemento.Controls.Add(this.button11);
            this.pPanelElemento.Controls.Add(this.button12);
            this.pPanelElemento.Controls.Add(this.pictureBox5);
            this.pPanelElemento.Location = new System.Drawing.Point(11, 631);
            this.pPanelElemento.Margin = new System.Windows.Forms.Padding(2);
            this.pPanelElemento.Name = "pPanelElemento";
            this.pPanelElemento.Size = new System.Drawing.Size(138, 70);
            this.pPanelElemento.TabIndex = 5;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(2, 109);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(134, 32);
            this.button11.TabIndex = 2;
            this.button11.Text = "Consultar elemento";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(2, 72);
            this.button12.Margin = new System.Windows.Forms.Padding(2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(134, 33);
            this.button12.TabIndex = 1;
            this.button12.Text = "Añadir elemento";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(2, 2);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(136, 66);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.PictureBox5_Click);
            // 
            // pPanelContrato
            // 
            this.pPanelContrato.Controls.Add(this.button6);
            this.pPanelContrato.Controls.Add(this.button5);
            this.pPanelContrato.Controls.Add(this.nAnadirContrato);
            this.pPanelContrato.Controls.Add(this.pictureBox3);
            this.pPanelContrato.Location = new System.Drawing.Point(13, 223);
            this.pPanelContrato.Margin = new System.Windows.Forms.Padding(2);
            this.pPanelContrato.Name = "pPanelContrato";
            this.pPanelContrato.Size = new System.Drawing.Size(138, 70);
            this.pPanelContrato.TabIndex = 1;
            this.pPanelContrato.Click += new System.EventHandler(this.PPanelContrato_Click);
            this.pPanelContrato.Paint += new System.Windows.Forms.PaintEventHandler(this.PPanelContrato_Paint);
            this.pPanelContrato.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PPanelContrato_MouseClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(2, 145);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(134, 27);
            this.button6.TabIndex = 3;
            this.button6.Text = "Consultar borrador";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(2, 109);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(134, 32);
            this.button5.TabIndex = 2;
            this.button5.Text = "Consultar contrato";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // nAnadirContrato
            // 
            this.nAnadirContrato.Location = new System.Drawing.Point(2, 72);
            this.nAnadirContrato.Margin = new System.Windows.Forms.Padding(2);
            this.nAnadirContrato.Name = "nAnadirContrato";
            this.nAnadirContrato.Size = new System.Drawing.Size(134, 33);
            this.nAnadirContrato.TabIndex = 1;
            this.nAnadirContrato.Text = "Añadir contrato";
            this.nAnadirContrato.UseVisualStyleBackColor = true;
            this.nAnadirContrato.Click += new System.EventHandler(this.Button4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(2, 2);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(134, 63);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            this.pictureBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox3_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(2, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(156, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1744, 992);
            this.Controls.Add(this.pPanel);
            this.Location = new System.Drawing.Point(161, 8);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PPanelBig_Paint);
            this.pPanel.ResumeLayout(false);
            this.pPanel.PerformLayout();
            this.pPanelSide.ResumeLayout(false);
            this.pPanelMantenimiento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pM)).EndInit();
            this.pPanelAnexo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.pPanelDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pPanelCliente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pPanelFichaAbonado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.pPanelElemento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.pPanelContrato.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pPanel;
        private Panel pPanelSide;
        private Panel pPanelDoc;
        private Button button8;
        private Button button9;
        private PictureBox pictureBox4;
        private Panel pPanelFichaAbonado;
        private Button button14;
        private Button button15;
        private PictureBox pictureBox6;
        private Panel pPanelElemento;
        private Button button11;
        private Button button12;
        private PictureBox pictureBox5;
        private Panel pPanelContrato;
        private Button button6;
        private Button button5;
        private Button nAnadirContrato;
        private PictureBox pictureBox3;
        private Panel pPanelCliente;
        private PictureBox pictureBox1;
        private Button bConsultarCliente;
        private Button bAnadirCliente;
        private PictureBox pictureBox2;
        public Panel pPanelBig;
        private Button bAnadirEmpresa;
        private Panel pPanelAnexo;
        private Button bConsultarAnexo;
        private Button bAnadirAnexo;
        private PictureBox pictureBox7;
        private Panel pPanelMantenimiento;
        private Button button1;
        private Button button2;
        private PictureBox pM;
    }

    

}


