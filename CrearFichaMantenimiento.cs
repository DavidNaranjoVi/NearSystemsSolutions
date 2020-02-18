using System;
using System.Collections;
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
    public partial class CrearFichaMantenimiento : Form
    {
        FichaAbonado fichaAbonado = null;
        FichaMantenimiento fichaMantenimiento = null;

        public CrearFichaMantenimiento()
        {
            InitializeComponent();
            ajustarPantalla();

            dgZonas.ColumnCount = 4;
            dgZonas.Columns[0].Name = "Zona";
            dgZonas.Columns[1].Name = "Area";
            dgZonas.Columns[2].Name = "Descripcion de zona";
            dgZonas.Columns[3].Name = "id";
            dgZonas.Columns[3].Visible = false;

            dgZonas.Columns[0].ReadOnly = true;
            dgZonas.Columns[1].ReadOnly = true;
            dgZonas.Columns[2].ReadOnly = true;
            dgZonas.Columns[3].ReadOnly = true;
            dgZonas.Columns[3].ReadOnly = true;

            DataGridViewCheckBoxColumn dgSabotaje = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxColumn dgCobertura = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxColumn dgBateria = new DataGridViewCheckBoxColumn();

            dgZonas.Columns.Add(dgSabotaje);
            dgZonas.Columns[4].Name = "Test de sabotaje";
            dgZonas.Columns.Add(dgCobertura);
            dgZonas.Columns[5].Name = "Test de cobertura";
            dgZonas.Columns.Add(dgBateria);
            dgZonas.Columns[6].Name = "Estado bateria";

            dgZonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgZonas.ForeColor = Color.Black;

            int numeroMantenimiento = FichaMantenimiento.consultar_num();

            if (numeroMantenimiento != -1)
                tNumeroParte.SelectedText = (numeroMantenimiento+1).ToString();

            tFechaParte.SelectedText = Data.formatearFecha(DateTime.Now.ToString());

            Fill();
        }

        public void ajustarPantalla()
        {
            tableLayoutPanel14.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.77),(int)(Screen.PrimaryScreen.Bounds.Height*0.8));
            ajustarMenu(tableLayoutPanel14);
            tabControl1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.75), (int)(Screen.PrimaryScreen.Bounds.Height * 0.7));
            tableLayoutPanel2.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.74), (int)(Screen.PrimaryScreen.Bounds.Height * 0.69));
            ajustarMenu(tableLayoutPanel2);
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

        public CrearFichaMantenimiento(FichaMantenimiento fichaMantenimiento)
        {
            InitializeComponent();

            dgZonas.ColumnCount = 4;
            dgZonas.Columns[0].Name = "Zona";
            dgZonas.Columns[1].Name = "Area";
            dgZonas.Columns[2].Name = "Descripcion de zona";
            dgZonas.Columns[3].Name = "id";
            dgZonas.Columns[3].Visible = false;

            dgZonas.Columns[0].ReadOnly = true;
            dgZonas.Columns[1].ReadOnly = true;
            dgZonas.Columns[2].ReadOnly = true;
            dgZonas.Columns[3].ReadOnly = true;
            dgZonas.Columns[3].ReadOnly = true;

            DataGridViewCheckBoxColumn dgSabotaje = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxColumn dgCobertura = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxColumn dgBateria = new DataGridViewCheckBoxColumn();

            dgZonas.Columns.Add(dgSabotaje);
            dgZonas.Columns[4].Name = "Test de sabotaje";
            dgZonas.Columns.Add(dgCobertura);
            dgZonas.Columns[5].Name = "Test de cobertura";
            dgZonas.Columns.Add(dgBateria);
            dgZonas.Columns[6].Name = "Estado bateria";

            dgZonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgZonas.ForeColor = Color.Black;

            this.fichaMantenimiento = fichaMantenimiento;
            this.fichaAbonado = new FichaAbonado(fichaMantenimiento.IIdFichaAbonado);

            tNumeroParte.ReadOnly = true;
            tFechaParte.ReadOnly = true;

            tNumeroParte.SelectedText = fichaMantenimiento.SNumero;
            tFechaParte.SelectedText = Data.formatearFecha(fichaMantenimiento.SFecha);

            tNAbonado.ReadOnly = true;
            tTipoPanel.ReadOnly = true;
            tEmpresaInstaladora.ReadOnly = true;
            tNombreRazon.ReadOnly = true;
            tDireccion.ReadOnly = true;
            tLocalidad.ReadOnly = true;
            tProvincia.ReadOnly = true;
            tCOPO.ReadOnly = true;
            tFechaAlta.ReadOnly = true;
            tEmail.ReadOnly = true;

            tViaPrincipal.ReadOnly = true;
            tModeloPrincipal.ReadOnly = true;
            tFormatoPrincipal.ReadOnly = true;
            tTestPrincipal.ReadOnly = true;

            tViaSecundaria.ReadOnly = true;
            tModeloSecundaria.ReadOnly = true;
            tFormatoSecundaria.ReadOnly = true;
            tTestSecundaria.ReadOnly = true;

            tCCTVIP.ReadOnly = true;
            tModeloCctvip.ReadOnly = true;
            tIpCliente.ReadOnly = true;
            tPuerto.ReadOnly = true;

            tIMEI.ReadOnly = true;

            ArrayList testZonas = FichaMantenimiento.consultar_zonas(fichaMantenimiento.IId);

            for(int i = 0; i < testZonas.Count; i++)
            {
                TestZonas tzZona = (TestZonas)testZonas[i];
                Zona z = new Zona(tzZona.IIdZona);

                if(tzZona != null)
                {
                    String[] row =
                   {
                        z.sZona,
                        z.Area,
                        z.Descripcion,
                        z.IId.ToString(),
                        tzZona.BSabotaje.ToString(),
                        tzZona.BCobertura.ToString(),
                        tzZona.BBateria.ToString()
                    };

                    dgZonas.Rows.Add(row);
                }
            }

            Fill();

        }
        private void dgZonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgZonas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bEliminarZona_Click(object sender, EventArgs e)
        {

        }

        private void bAnadirZona_Click(object sender, EventArgs e)
        {

        }

        private void DgZonas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Fill()
        {
            if (fichaAbonado != null)
            {
                ArrayList zonas = fichaAbonado.consultar_zona();

                for (int i = 0; i < zonas.Count; i++)
                {
                    Zona z = (Zona)zonas[i];

                    String[] row =
                    {
                        z.sZona,
                        z.Area,
                        z.Descripcion,
                        z.IId.ToString()
                    };

                    dgZonas.Rows.Add(row);
                }

                tNAbonado.Clear();
                tNAbonado.SelectedText = fichaAbonado.SNAbonado;

                tTipoPanel.Clear();
                tTipoPanel.SelectedText = fichaAbonado.STipoPanel;

                tEmpresaInstaladora.Clear();
                tEmpresaInstaladora.SelectedText = fichaAbonado.SEmpresaInstaladora;

                tNombreRazon.Clear();
                tNombreRazon.SelectedText = fichaAbonado.SNombreRazonSocial;

                tDireccion.Clear();
                tDireccion.SelectedText = fichaAbonado.SDireccion;

                tLocalidad.Clear();
                tLocalidad.SelectedText = fichaAbonado.SLocalidad;

                tProvincia.Clear();
                tProvincia.SelectedText = fichaAbonado.SProvincia;

                tCOPO.Clear();
                tCOPO.SelectedText = fichaAbonado.SCopo;

                tFechaAlta.Clear();
                tFechaAlta.SelectedText = Data.formatearFecha(fichaAbonado.SFechaAlta);

                tEmail.Clear();
                tEmail.SelectedText = fichaAbonado.SEmail;

                cbTelefonos.Items.Clear();

                if (!fichaAbonado.STelefono1.Equals(""))
                {
                    cbTelefonos.Items.Add(fichaAbonado.STelefono1);
                    cbTelefonos.SelectedIndex = 0;

                    if (!fichaAbonado.STelefono2.Equals(""))
                    {
                        cbTelefonos.Items.Add(fichaAbonado.STelefono2);

                        if (!fichaAbonado.STelefono3.Equals(""))
                            cbTelefonos.Items.Add(fichaAbonado.STelefono3);
                    }
                }

                tViaPrincipal.Clear();
                tViaPrincipal.SelectedText = fichaAbonado.SViaPrincipal;

                tModeloPrincipal.Clear();
                tModeloPrincipal.SelectedText = fichaAbonado.SModeloPrincipal;

                tFormatoPrincipal.Clear();
                tFormatoPrincipal.SelectedText = fichaAbonado.SFormatoPrincipal;

                tTestPrincipal.Clear();
                tTestPrincipal.SelectedText = fichaAbonado.STestPrincipal;

                tViaSecundaria.Clear();
                tViaSecundaria.SelectedText = fichaAbonado.SViaSecundaria;

                tModeloSecundaria.Clear();
                tModeloSecundaria.SelectedText = fichaAbonado.SModeloSecundaria;

                tFormatoSecundaria.Clear();
                tFormatoSecundaria.SelectedText = fichaAbonado.SFormatoSecundaria;

                tTestSecundaria.Clear();
                tTestSecundaria.SelectedText = fichaAbonado.STestSecundaria;

                tCCTVIP.Clear();
                tCCTVIP.SelectedText = fichaAbonado.SCctvIp;

                tModeloCctvip.Clear();
                tModeloCctvip.SelectedText = fichaAbonado.SCctvIpModelo;

                tIpCliente.Clear();
                tIpCliente.SelectedText = fichaAbonado.SCctvIpCliente;

                tPuerto.Clear();
                tPuerto.SelectedText = fichaAbonado.SCctvIpPuerto;

                tIMEI.Clear();
                tIMEI.SelectedText = fichaAbonado.SIMEI;

            }else if(fichaMantenimiento != null)
            {
                tNumeroParte.Clear();
                tNumeroParte.SelectedText = fichaMantenimiento.SNumero;

                tFechaParte.Clear();
                tFechaParte.SelectedText = Data.formatearFecha(fichaMantenimiento.SFecha);

                rtComentarios.Clear();
                rtComentarios.SelectedText = fichaMantenimiento.SComentarios;
            }
        }

        private void BFichaAbonado_Click(object sender, EventArgs e)
        {
            consultaFichaAbonadocs consultaFichaAbonadocs = new consultaFichaAbonadocs(3);
            consultaFichaAbonadocs.ShowDialog();

            if (consultaFichaAbonadocs.FichaAbonado != null) {
                fichaAbonado = consultaFichaAbonadocs.FichaAbonado;
                Fill();
                    }
        }

        private void BAnadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (fichaAbonado != null)
                {
                    FichaMantenimiento fichaMantenimiento = FichaMantenimiento.create(fichaAbonado.IId, tNumeroParte.Text, tFechaParte.Text, rtComentarios.Text);

                    ArrayList aTestZonas = new ArrayList();

                    for (int i = 0; i < dgZonas.RowCount; i++)
                    {

                        aTestZonas.Add(TestZonas.create(fichaMantenimiento.IId,Convert.ToInt32(dgZonas[3, i].Value), Convert.ToBoolean(dgZonas[4, i].Value),
                            Convert.ToBoolean(dgZonas[5, i].Value), Convert.ToBoolean(dgZonas[6, i].Value)));

                    }

                }
                else
                {
                    throw new Exception("Debe seleccionar una ficha de abonado.");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
