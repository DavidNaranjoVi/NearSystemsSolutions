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
    public partial class AnadirEmpresa : Form
    {
        Cliente cCliente = null;
        Empresa eEmpresa = null;

        public AnadirEmpresa()
        {
            InitializeComponent();
            ajustarPantalla();

            Data.ListaProvincias(cbProvinciasEmpresa);
            Data.ListaProvincias(cbProvinciasNotario);
        }

        public void ajustarPantalla()
        {
            tableLayoutPanel14.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 255, Screen.PrimaryScreen.Bounds.Height - 250);
        }

        private void BSeleccionarCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente consultarCliente = new ConsultarCliente(2);

            consultarCliente.Location = new Point(Data.f1.pPanelBig.Location.X+20,Data.f1.pPanelBig.Location.Y+80);
            consultarCliente.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 200);
            consultarCliente.ShowDialog();

            if (consultarCliente.C != null)
            {
                cCliente = consultarCliente.C;
                tNombreCliente.Clear();
                tNombreCliente.SelectedText = cCliente.getNombre() + " " + cCliente.getApellido();
            }

        }

        private void BAnadirEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                if (cCliente == null) throw new Exception("Seleccione un cliente");

                if (eEmpresa == null)
                    eEmpresa = Empresa.create(cCliente.getId(), tCif.Text, tRazonSocial.Text, cbTipoViaEmpresa.Text, tDireccionEmpresa.Text, tNumeroEmpresa.Text, tPisoEmpresa.Text,
                                              tCpEmpresa.Text, cbProvinciasEmpresa.Text, cbMunicipiosEmpresa.Text, tNombreNotario.Text,cbProvinciasNotario.Text, cbMunicipiosNotario.Text, tNumeroProtocolo.Text,
                                              tFechaNotario.Text);
                else
                    MessageBox.Show("La empresa ya fue añadida anteriormente.");

                MessageBox.Show("La empresa se ha añadido correctamente");

                this.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CbProvinciasEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.ListaMunicipios(cbMunicipiosEmpresa, cbProvinciasEmpresa.Text);
        }

        private void CbProvinciasNotario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.ListaMunicipios(cbMunicipiosNotario, cbProvinciasNotario.Text);
        }

        private void BConsultarCif_Click(object sender, EventArgs e)
        {
            try
            {

                string[] sDatos = Empresa.consultar_empresa(tCif.Text);

                Data.ClearTextBoxes(this.tableLayoutPanel14);

                tCif.SelectedText = sDatos[0];
                tRazonSocial.SelectedText = sDatos[1];
                tDireccionEmpresa.SelectedText = sDatos[2];
                cbProvinciasEmpresa.SelectedIndex = cbProvinciasEmpresa.FindStringExact(sDatos[3]);

                Data.ListaMunicipios(cbMunicipiosEmpresa, cbProvinciasEmpresa.Text);
                MessageBox.Show(sDatos[4]);
                cbMunicipiosEmpresa.SelectedIndex = cbMunicipiosEmpresa.FindStringExact(sDatos[4]);

                tCpEmpresa.SelectedText = sDatos[5];
                tNumeroEmpresa.SelectedText = sDatos[6];
                tPisoEmpresa.SelectedText = sDatos[7];
                if (Convert.ToInt32(sDatos[8]) != -1) cbTipoViaEmpresa.SelectedIndex = Convert.ToInt32(sDatos[8]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El cif de la empresa no consta en la base de datos de la agencia tributaria");
            }
        }
    }
    
}
