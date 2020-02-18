using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NearSystemsSolutions
{
    public partial class Form1 : Form
    {

        string panel = "";
        static int[] iExpandH = { (int)(Screen.PrimaryScreen.Bounds.Height * 0.167), (int)(Screen.PrimaryScreen.Bounds.Height * 0.167 * 1.15) };
        static int iMinH = (int)(Screen.PrimaryScreen.Bounds.Height * 0.067);

        public Form1()
        {

            InitializeComponent();
            ajustarPantalla();

            Data.f1 = this;
        }


        private void elementoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarElemento form10 = new ConsultarElemento();
            form10.Show();
        }

        private void fichaDeAbonadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearFichaAbonado form13 = new CrearFichaAbonado();

            form13.TopLevel = false;
            form13.AutoScroll = true;

            pPanelBig.Controls.Add(form13);
            form13.Show();
        }

        private void fichaDeAbonadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            consultaFichaAbonadocs consultaAbonado = new consultaFichaAbonadocs();
            
            consultaAbonado.TopLevel = false;
            consultaAbonado.AutoScroll = true;

            pPanelBig.Controls.Add(consultaAbonado);
            consultaAbonado.ShowDialog();
        }

        private void contratoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void generarFichaDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultaContrato ConsultaContrato = new consultaContrato("Documentación");
            ConsultaContrato.TopLevel = false;
            ConsultaContrato.AutoScroll = true;

            pPanelBig.Controls.Add(ConsultaContrato);
            ConsultaContrato.ShowDialog();
        }

        private void PPanelContrato_Click(object sender, EventArgs e)
        {

        }

        private void PPanelContrato_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void PictureBox3_MouseClick(object sender, MouseEventArgs e)
        {


            if (pPanelContrato.Size.Height == 63)
            {
                this.pPanelContrato.Size = new System.Drawing.Size(136, 162);
            }
            else if (pPanelContrato.Size.Height == 162)
            {
                this.pPanelContrato.Size = new System.Drawing.Size(136, 63);
            }
        }

        private void PPanelContrato_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pPanelCliente.Size.Height == 67)
            {
                this.pPanelCliente.Size = new System.Drawing.Size(136, 162);
                this.pPanelContrato.Location = new System.Drawing.Point(3, 234);

            }
            else if (pPanelCliente.Size.Height == 162)
            {
                this.pPanelCliente.Size = new System.Drawing.Size(136, 60);
                this.pPanelContrato.Location = new System.Drawing.Point(3, 154);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CrearCliente f2 = new CrearCliente();
            f2.Size = new Size(Screen.PrimaryScreen.Bounds.Width-201, Screen.PrimaryScreen.Bounds.Height-101);
            f2.TopLevel = false;
            f2.AutoScroll = true;
            pPanelBig.Controls.Add(f2);
            f2.Show();
        }

        private void PPanelBig_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BConsultarCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente form5 = new ConsultarCliente();
            form5.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - (int)(Screen.PrimaryScreen.Bounds.Height*0.11));
            form5.TopLevel = false;
            form5.AutoScroll = true;
            pPanelBig.Controls.Add(form5);
            form5.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void BModificarCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente form5 = new ConsultarCliente();
            form5.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            form5.TopLevel = false;
            form5.AutoScroll = true;
            pPanelBig.Controls.Add(form5);
            form5.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            CrearContrato crearContrato = new CrearContrato();
            crearContrato.Size = new Size(pPanelBig.Size.Width - 1, pPanelBig.Size.Height-1);
            crearContrato.TopLevel = false;
            crearContrato.AutoScroll = true;

            pPanelBig.Controls.Add(crearContrato);
            crearContrato.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            elegirDocumento elegirdocumento = new elegirDocumento();
            elegirdocumento.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            elegirdocumento.TopLevel = false;
            elegirdocumento.AutoScroll = true;

            pPanelBig.Controls.Add(elegirdocumento);
            elegirdocumento.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            consultaContrato consultacontrato = new consultaContrato(false);
            consultacontrato.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            consultacontrato.TopLevel = false;
            consultacontrato.AutoScroll = true;

            pPanelBig.Controls.Add(consultacontrato);
            consultacontrato.Show();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            CrearFichaAbonado fichaAbonado = new CrearFichaAbonado();
            fichaAbonado.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            fichaAbonado.TopLevel = false;
            fichaAbonado.AutoScroll = true;

            pPanelBig.Controls.Add(fichaAbonado);
            fichaAbonado.Show();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            consultaFichaAbonadocs consultaFicha = new consultaFichaAbonadocs();
            consultaFicha.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            consultaFicha.TopLevel = false;
            consultaFicha.AutoScroll = true;
            pPanelBig.Controls.Add(consultaFicha);
            consultaFicha.Show();

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ConsultarBorrador borrador = new ConsultarBorrador();
            borrador.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            borrador.TopLevel = false;
            borrador.AutoScroll = true;
            pPanelBig.Controls.Add(borrador);
            borrador.Show();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            CrearElemento anadirElementos = new CrearElemento();
            anadirElementos.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width*0.85), (int)(Screen.PrimaryScreen.Bounds.Height*0.87));
            anadirElementos.TopLevel = false;
            anadirElementos.AutoScroll = true;
            pPanelBig.Controls.Add(anadirElementos);
            anadirElementos.Show();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            ConsultarElemento consultarElemento = new ConsultarElemento();
            consultarElemento.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.85), (int)(Screen.PrimaryScreen.Bounds.Height * 0.87));
            consultarElemento.TopLevel = false;
            consultarElemento.AutoScroll = true;
            pPanelBig.Controls.Add(consultarElemento);
            consultarElemento.Show();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            panel = "cliente";
            restablecer_panel();

            if(pPanelCliente.Height < iExpandH[0])
            {
                
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelContrato.Location = new Point(pPanelContrato.Location.X, pPanelContrato.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelFichaAbonado.Location = new Point(pPanelFichaAbonado.Location.X, pPanelFichaAbonado.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelCliente.Height = iExpandH[0];

            }
            else
            {
                panel = "";
                pPanelContrato.Location = new Point(pPanelContrato.Location.X, pPanelContrato.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelFichaAbonado.Location = new Point(pPanelFichaAbonado.Location.X, pPanelFichaAbonado.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelCliente.Height = iMinH;
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            panel = "contrato";
            restablecer_panel();

            if (pPanelContrato.Height < iExpandH[0])
            {

               
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelFichaAbonado.Location = new Point(pPanelFichaAbonado.Location.X, pPanelFichaAbonado.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelContrato.Height = iExpandH[0];
            }
            else
            {
                panel = "";
                pPanelFichaAbonado.Location = new Point(pPanelFichaAbonado.Location.X, pPanelFichaAbonado.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelContrato.Height = iMinH;
            }
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            panel = "abonado";
            restablecer_panel();

            if (pPanelFichaAbonado.Height < iExpandH[1])
            {

                
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y + (int)(iExpandH[0]*0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y+ (int)(iExpandH[0] * 0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelFichaAbonado.Height = iExpandH[1];
            }
            else
            {
                panel = "";
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelFichaAbonado.Height = iMinH;
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            panel = "elemento";
            restablecer_panel();

            if (pPanelElemento.Height < iExpandH[0])
            {
                
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y + (int)(iExpandH[0] * 0.7));
                pPanelElemento.Height = iExpandH[0];

            }
            else
            {
                panel = "";
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelElemento.Height = iMinH;

            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            panel = "documento";
            restablecer_panel();
            if (pPanelDoc.Height < iExpandH[0])
            {
                
                pPanelDoc.Height = iExpandH[0];
            }
            else
            {
                panel = "";
                pPanelDoc.Height = iMinH;
            }
        }

        public void restablecer_panel()
        {


            if(pPanelCliente.Height >= iExpandH[0] && !panel.Equals("cliente"))
            {
                pPanelContrato.Location = new Point(pPanelContrato.Location.X, pPanelContrato.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelFichaAbonado.Location = new Point(pPanelFichaAbonado.Location.X, pPanelFichaAbonado.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelCliente.Height = iMinH;

            }else if (pPanelContrato.Height >= iExpandH[0] && !panel.Equals("contrato"))
            {

                pPanelFichaAbonado.Location = new Point(pPanelFichaAbonado.Location.X, pPanelFichaAbonado.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0] * 0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelContrato.Height = iMinH;

            }
            else if(pPanelFichaAbonado.Height >= iExpandH[0] && !panel.Equals("abonado"))
            {
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelAnexo.Location = new Point(pPanelAnexo.Location.X, pPanelAnexo.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelFichaAbonado.Height = iMinH;

            }else if (pPanelAnexo.Height >= iExpandH[0] && !panel.Equals("anexo"))
            {
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y - (int)(iExpandH[0]*0.7));

                pPanelAnexo.Height = iMinH;

            }else if(pPanelMantenimiento.Height >= iExpandH[0] && !panel.Equals("mantenimiento"))
            {
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelMantenimiento.Height = iMinH;
                

            }else if (pPanelElemento.Height >= iExpandH[0] && !panel.Equals("elemento")) {
                pPanelElemento.Height = iMinH;
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0]*0.7));

            }else if(pPanelDoc.Height >= iExpandH[0] && !panel.Equals("documento"))
            {
                pPanelDoc.Height = iMinH;
            }
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            panel = "anexo";
            restablecer_panel();

            if(pPanelAnexo.Height != iExpandH[0])
            {
                
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y + (int)(iExpandH[0]*0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y + (int)(iExpandH[0]*0.7));
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y + (int)(iExpandH[0]*0.7));
                pPanelAnexo.Height = iExpandH[0];;
            }
            else{
                panel = "";
                pPanelMantenimiento.Location = new Point(pPanelMantenimiento.Location.X, pPanelMantenimiento.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelAnexo.Height = iMinH;
            }
        }

        private void BAnadirAnexo_Click(object sender, EventArgs e)
        {
            CrearAnexo crearAnexo = new CrearAnexo();
            crearAnexo.TopLevel = false;
            crearAnexo.AutoScroll = true;

            pPanelBig.Controls.Add(crearAnexo);

            crearAnexo.Show();
        }

        private void BConsultarAnexo_Click(object sender, EventArgs e)
        {
            ConsultarAnexo consultarAnexo = new ConsultarAnexo();
            consultarAnexo.TopLevel = false;
            consultarAnexo.AutoScroll = true;

            pPanelBig.Controls.Add(consultarAnexo);

            consultarAnexo.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CrearFichaMantenimiento crearFichaMantenimiento = new CrearFichaMantenimiento();
            crearFichaMantenimiento.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            crearFichaMantenimiento.TopLevel = false;
            crearFichaMantenimiento.AutoScroll = true;

            pPanelBig.Controls.Add(crearFichaMantenimiento);

            crearFichaMantenimiento.Show();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            ConsultarFichaMantenimiento consultarFichaMantenimiento = new ConsultarFichaMantenimiento();
            consultarFichaMantenimiento.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            consultarFichaMantenimiento.TopLevel = false;
            consultarFichaMantenimiento.AutoScroll = true;

            pPanelBig.Controls.Add(consultarFichaMantenimiento);

            consultarFichaMantenimiento.Show();
        }

        private void PM_Click(object sender, EventArgs e)
        {
            panel = "mantenimiento";
            restablecer_panel();
            if (pPanelMantenimiento.Height < iExpandH[0])
            {
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y + (int)(iExpandH[0]*0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y + (int)(iExpandH[0]*0.7));
                pPanelMantenimiento.Height = iExpandH[1];
            }
            else
            {
                panel = "";
                pPanelElemento.Location = new Point(pPanelElemento.Location.X, pPanelElemento.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelDoc.Location = new Point(pPanelDoc.Location.X, pPanelDoc.Location.Y - (int)(iExpandH[0]*0.7));
                pPanelMantenimiento.Height = iMinH;
            }
        }

        public void ajustarPantalla()
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 10, Screen.PrimaryScreen.Bounds.Height - 35);
            pPanel.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 10, Screen.PrimaryScreen.Bounds.Height - 75);
            pPanelSide.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.08), Screen.PrimaryScreen.Bounds.Height - 75);
            pPanelSide.Font = new Font(FontFamily.GenericSansSerif, (int)(Screen.PrimaryScreen.Bounds.Width * 0.0049), FontStyle.Regular);
            pPanelBig.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 200, Screen.PrimaryScreen.Bounds.Height - 100);


            pPanelCliente.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            pictureBox1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.06), (int)(Screen.PrimaryScreen.Bounds.Height * 0.06));
            pPanelCliente.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.01), (int)(Screen.PrimaryScreen.Bounds.Height * 0.11));
            bAnadirCliente.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            bAnadirCliente.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.07));
            bConsultarCliente.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            bConsultarCliente.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.132));
            bAnadirEmpresa.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            bAnadirEmpresa.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.101));

            pPanelContrato.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            pictureBox3.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.06), (int)(Screen.PrimaryScreen.Bounds.Height * 0.06));
            pPanelContrato.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.01), (int)(Screen.PrimaryScreen.Bounds.Height * 0.2));
            nAnadirContrato.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            button5.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            button6.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            nAnadirContrato.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.07));
            button5.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.101));
            button6.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.132));

            pPanelFichaAbonado.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            pictureBox6.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.06), (int)(Screen.PrimaryScreen.Bounds.Height * 0.06));
            pPanelFichaAbonado.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.01), (int)(Screen.PrimaryScreen.Bounds.Height * 0.29));
            button15.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            button15.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.07));
            button14.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            button14.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.13));


            pPanelAnexo.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            pictureBox7.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.06), (int)(Screen.PrimaryScreen.Bounds.Height * 0.06));
            pPanelAnexo.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.01), (int)(Screen.PrimaryScreen.Bounds.Height * 0.38));
            bAnadirAnexo.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            bAnadirAnexo.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.07));
            bConsultarAnexo.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            bConsultarAnexo.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.101));


            pPanelMantenimiento.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.07));
            pM.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.06), (int)(Screen.PrimaryScreen.Bounds.Height * 0.06));
            pPanelMantenimiento.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.01), (int)(Screen.PrimaryScreen.Bounds.Height * 0.47));
            button2.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            button2.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.07));
            button1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            button1.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.13));


            pPanelElemento.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            pictureBox5.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.06), (int)(Screen.PrimaryScreen.Bounds.Height * 0.06));
            pPanelElemento.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.01), (int)(Screen.PrimaryScreen.Bounds.Height * 0.56));
            button11.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            button12.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            button12.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.07));
            button11.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.101));



            pPanelDoc.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.069), (int)(Screen.PrimaryScreen.Bounds.Height * 0.067));
            pictureBox4.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.06), (int)(Screen.PrimaryScreen.Bounds.Height * 0.06));
            pPanelDoc.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.01), (int)(Screen.PrimaryScreen.Bounds.Height * 0.65));
            button9.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            button9.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.07));
            button8.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.07), (int)(Screen.PrimaryScreen.Bounds.Height * 0.032));
            button8.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.001), (int)(Screen.PrimaryScreen.Bounds.Height * 0.101));
        }

        private void BAnadirEmpresa_Click(object sender, EventArgs e)
        {
            AnadirEmpresa anadirEmpresa = new AnadirEmpresa();

            anadirEmpresa.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 201, Screen.PrimaryScreen.Bounds.Height - 101);

            anadirEmpresa.TopLevel = false;
            anadirEmpresa.AutoScroll = true;

            pPanelBig.Controls.Add(anadirEmpresa);

            anadirEmpresa.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ConfiguracionDoc configuracionDoc = new ConfiguracionDoc();
            configuracionDoc.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.85), (int)(Screen.PrimaryScreen.Bounds.Height * 0.88));
            configuracionDoc.TopLevel = false;
            configuracionDoc.AutoScroll = true;

            pPanelBig.Controls.Add(configuracionDoc);

            configuracionDoc.Show();
        }
    }
}
