using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NearSystemsSolutions
{
    public partial class ConfiguracionDoc : Form
    {
        public ConfiguracionDoc()
        {
            InitializeComponent();

            ajustarPantalla();

            tPlantillaContratoNear.SelectedText = AppConfiguration.getConfig("Contrato_Near_Particular");
            tPlantillaContratoNearEmpresa.SelectedText = AppConfiguration.getConfig("Contrato_Near_Empresa");
            tCarpetaNubeContratoNear.SelectedText = AppConfiguration.getConfig("Carpeta_Nube_Contrato_Near");

            tIbercraParticular.SelectedText = AppConfiguration.getConfig("Contrato_Ibercra_Particular");
            tIbercraEmpresa.SelectedText = AppConfiguration.getConfig("Contrato_Ibercra_Empresa");
            tIbercraNube.SelectedText = AppConfiguration.getConfig("Carpeta_Nube_Contrato_Ibercra");

            tAbonado.SelectedText = AppConfiguration.getConfig("Ficha_Abonado");
            tAbonadoNube.SelectedText = AppConfiguration.getConfig("Carpeta_Nube_Ficha_Abonado");

            tMantenimiento.SelectedText = AppConfiguration.getConfig("Ficha_Mantenimiento");
            tMantenimientoNube.SelectedText = AppConfiguration.getConfig("Carpeta_Nube_Ficha_Mantenimiento");
        }

        public void ajustarPantalla()
        {
            tableLayoutPanel1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.7), (int)(Screen.PrimaryScreen.Bounds.Height * 0.8));
            ajustarMenu(tableLayoutPanel1);
        }

        public void ajustarMenu(Control control)
        {
            foreach (Control c in control.Controls)

            {

                if (c is TableLayoutPanel)

                {

                    c.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, (int)(Screen.PrimaryScreen.Bounds.Width * 0.0055), FontStyle.Regular);

                }

                if (c.HasChildren)

                {
                    c.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, (int)(Screen.PrimaryScreen.Bounds.Width * 0.006), FontStyle.Regular);
                    ajustarMenu(c);

                }

            }
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDirectorio = new OpenFileDialog();

            if(ofdDirectorio.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Contrato_Near_Particular", ofdDirectorio.FileName);
                tPlantillaContratoNear.Clear();
                tPlantillaContratoNear.SelectedText = AppConfiguration.getConfig("Contrato_Near_Particular");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDirectorio = new OpenFileDialog();

            if (ofdDirectorio.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Contrato_Near_Empresa", ofdDirectorio.FileName);
                tPlantillaContratoNearEmpresa.Clear();
                tPlantillaContratoNearEmpresa.SelectedText = AppConfiguration.getConfig("Contrato_Near_Empresa");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdNube = new FolderBrowserDialog();

            if(fbdNube.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Carpeta_Nube_Contrato_Near", fbdNube.SelectedPath);
                tCarpetaNubeContratoNear.Clear();
                tCarpetaNubeContratoNear.SelectedText = AppConfiguration.getConfig("Carpeta_Nube_Contrato_Near");
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDirectorio = new OpenFileDialog();

            if (ofdDirectorio.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Contrato_Ibercra_Particular", ofdDirectorio.FileName);
                tIbercraParticular.Clear();
                tIbercraParticular.SelectedText = AppConfiguration.getConfig("Contrato_Ibercra_Particular");
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDirectorio = new OpenFileDialog();

            if (ofdDirectorio.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Contrato_Ibercra_Empresa", ofdDirectorio.FileName);
                tIbercraEmpresa.Clear();
                tIbercraEmpresa.SelectedText = AppConfiguration.getConfig("Contrato_Ibercra_Empresa");
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdNube = new FolderBrowserDialog();

            if (fbdNube.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Carpeta_Nube_Contrato_Ibercra", fbdNube.SelectedPath);
                tIbercraNube.Clear();
                tIbercraNube.SelectedText = AppConfiguration.getConfig("Carpeta_Nube_Contrato_Ibercra");
            }
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDirectorio = new OpenFileDialog();

            if (ofdDirectorio.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Ficha_Abonado", ofdDirectorio.FileName);
                tAbonado.Clear();
                tAbonado.SelectedText = AppConfiguration.getConfig("Ficha_Abonado");
            }
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdNube = new FolderBrowserDialog();

            if (fbdNube.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Carpeta_Nube_Ficha_Abonado", fbdNube.SelectedPath);
                tAbonadoNube.Clear();
                tAbonadoNube.SelectedText = AppConfiguration.getConfig("Carpeta_Nube_Ficha_Abonado");
            }
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDirectorio = new OpenFileDialog();

            if (ofdDirectorio.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Ficha_Mantenimiento", ofdDirectorio.FileName);
                tMantenimiento.Clear();
                tMantenimiento.SelectedText = AppConfiguration.getConfig("Ficha_Mantenimiento");
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdNube = new FolderBrowserDialog();

            if (fbdNube.ShowDialog() == DialogResult.OK)
            {
                AppConfiguration.saveConfig("Carpeta_Nube_Ficha_Mantenimiento", fbdNube.SelectedPath);
                tMantenimientoNube.Clear();
                tMantenimientoNube.SelectedText = AppConfiguration.getConfig("Carpeta_Nube_Ficha_Mantenimiento");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            tPlantillaContratoNear.Clear();
            AppConfiguration.saveConfig("Contrato_Near_Particular","");

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            tPlantillaContratoNearEmpresa.Clear();
            AppConfiguration.saveConfig("Contrato_Near_Empresa","");
            
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            tCarpetaNubeContratoNear.Clear();
            AppConfiguration.saveConfig("Carpeta_Nube_Contrato_Near","");
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            tIbercraParticular.Clear();
            AppConfiguration.saveConfig("Contrato_Ibercra_Particular","");

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            tIbercraEmpresa.Clear();
            AppConfiguration.saveConfig("Contrato_Ibercra_Empresa","");

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            tIbercraNube.Clear();
            AppConfiguration.saveConfig("Carpeta_Nube_Contrato_Ibercra","");

        }

        private void Button17_Click(object sender, EventArgs e)
        {
            tAbonado.Clear();
            AppConfiguration.saveConfig("Ficha_Abonado","");
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            tMantenimiento.Clear();
            AppConfiguration.saveConfig("Ficha_Mantenimiento", "");

        }

        private void Button19_Click(object sender, EventArgs e)
        {
            tMantenimientoNube.Clear();
            AppConfiguration.saveConfig("Carpeta_Nube_Ficha_Mantenimiento", "");
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            tAbonadoNube.Clear();
            AppConfiguration.saveConfig("Carpeta_Nube_Ficha_Abonado", "");
        }
    }
}
