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
    public partial class CrearAnexo : Form
    {
        Anexo aAnexo = null;

        public CrearAnexo()
        {
            InitializeComponent();
            tFechaAnexo.SelectedText = Data.formatearFecha(DateTime.Now.ToString());
        }

        public CrearAnexo(Anexo aAnexo)
        {
            InitializeComponent();

            this.aAnexo = aAnexo;

            bCrearAnexo.Text = "Actualizar anexo";

            tNumeroAnexo.SelectedText = aAnexo.SNumeroAnexo;
            tFechaAnexo.SelectedText = Data.formatearFecha(aAnexo.SFecha);
            tCif.SelectedText = aAnexo.SCif;
            tRazonSocial.SelectedText = aAnexo.SRazonSocial;
            tRepresentante.SelectedText = aAnexo.SRepresentanteNombre;
            tDniRepresentante.SelectedText = aAnexo.SRepresentanteDni;
            tCargo.SelectedText = aAnexo.SRepresentantePuesto;

            for (int i = 0; i < cbTipoVia.Items.Count; i++)
                if (cbTipoVia.Items[i].Equals(aAnexo.STipoVia))
                    cbTipoVia.SelectedIndex= i;

            tDireccionAnexo.SelectedText = aAnexo.SDireccion;
            tNumero.SelectedText = aAnexo.SNumero;
            tPiso.SelectedText = aAnexo.SPiso;
            tProvincia.SelectedText = aAnexo.SProvincia;
            tMunicipio.SelectedText = aAnexo.SMunicipio;
            tCp.SelectedText = aAnexo.SCp;
            tFirma.SelectedText = aAnexo.SFirma;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ConsultarCliente consultarCliente = new ConsultarCliente(2);
            consultarCliente.ShowDialog();

            if (consultarCliente.EEmpresa == null && consultarCliente.C == null)
                MessageBox.Show("No se ha seleccionado ningún cliente.");
            else
            {
                if (consultarCliente.EEmpresa != null)
                {
                    tCif.Clear();
                    tCif.SelectedText = consultarCliente.EEmpresa.SCif;

                    tRazonSocial.Clear();
                    tRazonSocial.SelectedText = consultarCliente.EEmpresa.SRazonSocial;

                    tRepresentante.Clear();
                    tRepresentante.SelectedText = consultarCliente.C.getNombre() + " " + consultarCliente.C.getApellido();

                    tDniRepresentante.Clear();
                    tDniRepresentante.SelectedText = consultarCliente.C.getDni();

                    for (int i = 0; i < cbTipoVia.Items.Count; i++)
                        if (cbTipoVia.Items[i].Equals(consultarCliente.EEmpresa.STipoVia))
                            cbTipoVia.SelectedIndex = i;

                    tDireccionAnexo.Clear();
                    tDireccionAnexo.SelectedText = consultarCliente.EEmpresa.SDireccion;

                    tNumero.Clear();
                    tNumero.SelectedText = consultarCliente.EEmpresa.SNumero;

                    tPiso.Clear();
                    tPiso.SelectedText = consultarCliente.EEmpresa.SPiso;

                    tProvincia.Clear();
                    tProvincia.SelectedText = consultarCliente.EEmpresa.SProvincia;

                    tMunicipio.Clear();
                    tMunicipio.SelectedText = consultarCliente.EEmpresa.SMunicipio;

                    tCp.Clear();
                    tCp.SelectedText = consultarCliente.EEmpresa.SCp;

                    tFirma.Clear();
                    tFirma.SelectedText = tRepresentante.Text;

                }else{

                    tCif.Clear();
                    tCif.ReadOnly = true;

                    tRazonSocial.Clear();
                    tRazonSocial.ReadOnly = true;

                    tRepresentante.Clear();
                    tRepresentante.SelectedText = consultarCliente.C.getNombre() + " " + consultarCliente.C.getApellido();

                    tDniRepresentante.Clear();
                    tDniRepresentante.SelectedText = consultarCliente.C.getDni();

                    for (int i = 0; i < cbTipoVia.Items.Count; i++)
                        if (cbTipoVia.Items[i].Equals(consultarCliente.EEmpresa.STipoVia))
                            cbTipoVia.SelectedIndex = i;

                    tDireccionAnexo.Clear();
                    tDireccionAnexo.SelectedText = consultarCliente.C.getDireccion();

                    tNumero.Clear();
                    tNumero.SelectedText = consultarCliente.C.getNumero();

                    tPiso.Clear();
                    tPiso.SelectedText = consultarCliente.C.getPiso();

                    tProvincia.Clear();
                    tProvincia.SelectedText = consultarCliente.C.getProvincia();

                    tMunicipio.Clear();
                    tMunicipio.SelectedText = consultarCliente.C.getMunicipio();

                    tCp.Clear();
                    tCp.SelectedText = consultarCliente.C.getCp();

                    tFirma.Clear();
                    tFirma.SelectedText = tRepresentante.Text;
                }

            }


        }

        private void BCrearAnexo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bCrearAnexo.Text.Equals("Actualizar anexo"))
                {
                    Anexo anexo = Anexo.create(tNumeroAnexo.Text,tCif.Text, "CONTRATO DE TRATAMIENTO DE DATOS DE CARÁCTER PERSONAL POR CUENTA DE TERCEROS", Data.formatearFecha(tFechaAnexo.Text),
                        tRazonSocial.Text, cbTipoVia.SelectedItem.ToString(), tDireccionAnexo.Text, tNumero.Text, tPiso.Text, tCp.Text, tMunicipio.Text, tProvincia.Text,
                        tRepresentante.Text, tCargo.Text, tDniRepresentante.Text, tFirma.Text);

                    MessageBox.Show("Anexo creado satisfactoriamente");
                    this.Close();
                }else
                {
                    Anexo anexo = Anexo.actualizar(aAnexo.IId,tNumeroAnexo.Text,tCif.Text ,"CONTRATO DE TRATAMIENTO DE DATOS DE CARÁCTER PERSONAL POR CUENTA DE TERCEROS", Data.formatearFecha(tFechaAnexo.Text),
                        tRazonSocial.Text, cbTipoVia.SelectedItem.ToString(), tDireccionAnexo.Text, tNumero.Text, tPiso.Text, tCp.Text, tMunicipio.Text, tProvincia.Text,
                        tRepresentante.Text, tCargo.Text, tDniRepresentante.Text, tFirma.Text);

                    MessageBox.Show("Anexo actualizado satisfactoriamente");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
