using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Collections;
using System.Net;

namespace NearSystemsSolutions
{
    public partial class CrearCliente : Form
    {
        Cliente cCliente = null;
        Empresa eEmpresa = null;

        public Cliente CCliente { get => cCliente; set => cCliente = value; }

        public CrearCliente()
        {
            InitializeComponent();
            ajustarPantalla();
            cargarDatos();
            cIban.Items.Clear();
            tabControl1.TabPages.Remove(tabPage2);

            

        }

        public void ajustarPantalla()
        {
            tableLayoutPanel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 250, Screen.PrimaryScreen.Bounds.Height - 150);
            tlpFormularioCliente.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 255, Screen.PrimaryScreen.Bounds.Height - 250);
            tableLayoutPanel14.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 255, Screen.PrimaryScreen.Bounds.Height - 260);
            ajustarMenu(tableLayoutPanel14);
            ajustarMenu(tlpFormularioCliente);
        }

        public void cargarDatos()
        {
            Data.ListaProvincias(tProvincias);
            Data.ListaMunicipios(tMunicipios, tProvincias.Text);

            Data.ListaProvincias(cbProvinciasEmpresa);
            Data.ListaProvincias(cbProvinciasNotario);
            tProvincias.SelectedIndex = 12;
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

        public CrearCliente(int iId,int iId_empresa,bool actualizar = false)
        {
            InitializeComponent();
            ajustarPantalla();
            cargarDatos();
            cCliente = new Cliente(iId);

            if(iId_empresa != 0) eEmpresa = new Empresa(iId_empresa);

            tNombre.SelectedText = cCliente.getNombre();
            tApellido.SelectedText = cCliente.getApellido();
            tDni.SelectedText = cCliente.getDni();

            for (int i = 0; i < tTipoCliente.Items.Count; i++) {
                if (tTipoCliente.Items[i].Equals(cCliente.getTipoCliente()))
                {
                    tTipoCliente.SelectedIndex = i;
                    break;
                }
                    }

            tTelefono.SelectedText = cCliente.getTelefono();
            tEmail.SelectedText = cCliente.getEmail();

            Cliente_Iban ciIban = new Cliente_Iban(cCliente.getId());

            ArrayList iban = ciIban.AIban;

            for(int i = 0; i < iban.Count; i++)
            {
                cIban.Items.Add(iban[i].ToString());
            }


            for (int i = 0; i < tTipoVia.Items.Count; i++)
            {
                if (tTipoVia.Items[i].Equals(cCliente.getTipoVia()))
                {
                    tTipoVia.SelectedIndex = i;
                    break;
                }
            }

            tDireccion.SelectedText = cCliente.getDireccion();
            tNumero.SelectedText = cCliente.getNumero();
            tPisoCliente.SelectedText = cCliente.getPiso();

            tProvincias.Items.Clear();
            Data.ListaProvincias(tProvincias);
            tProvincias.SelectedIndex = tProvincias.FindStringExact(cCliente.getProvincia());

            tMunicipios.Items.Clear();
            Data.ListaMunicipios(tMunicipios, tProvincias.Text);
            tMunicipios.SelectedIndex = tMunicipios.FindStringExact(cCliente.getMunicipio());

            tCp.SelectedText = cCliente.getCp();

            if(eEmpresa != null)
            {
                tCif.SelectedText = eEmpresa.SCif;
                tRazonSocial.SelectedText = eEmpresa.SRazonSocial;

                for (int i = 0; i <cbTipoViaEmpresa.Items.Count; i++)
                {
                    if (cbTipoViaEmpresa.Items[i].Equals(eEmpresa.STipoVia))
                    {
                        cbTipoViaEmpresa.SelectedIndex = i;
                        break;
                    }
                }

                tDireccionEmpresa.SelectedText = eEmpresa.SDireccion;
                tNumeroEmpresa.SelectedText = eEmpresa.SNumero;
                tPisoEmpresa.SelectedText = eEmpresa.SPiso;

                cbProvinciasEmpresa.Items.Clear();
                Data.ListaProvincias(cbProvinciasEmpresa);
                cbProvinciasEmpresa.SelectedIndex = cbProvinciasEmpresa.FindStringExact(eEmpresa.SProvincia);

                cbMunicipiosEmpresa.Items.Clear();
                Data.ListaMunicipios(cbMunicipiosEmpresa, cbProvinciasEmpresa.Text);
                cbMunicipiosEmpresa.SelectedIndex = cbMunicipiosEmpresa.FindStringExact(eEmpresa.SMunicipio);

                tCpEmpresa.SelectedText = eEmpresa.SCp;
                tNombreNotario.SelectedText = eEmpresa.SNombreNotario;

                cbProvinciasNotario.Items.Clear();
                Data.ListaProvincias(cbProvinciasNotario);
                cbProvinciasNotario.SelectedIndex = cbProvinciasNotario.FindStringExact(eEmpresa.SProvinciaNotario);
                cbMunicipiosNotario.Items.Clear();
                Data.ListaMunicipios(cbMunicipiosNotario, cbProvinciasNotario.Text);
                cbMunicipiosNotario.SelectedIndex = cbMunicipiosNotario.FindStringExact(eEmpresa.SMunicipioNotario);

                cbMunicipiosNotario.SelectedIndex = cbMunicipiosNotario.FindStringExact(eEmpresa.SMunicipioNotario);
                tNumeroProtocolo.SelectedText = eEmpresa.SNumeroProtocolo;
                tFechaNotario.SelectedText = Data.formatearFecha(eEmpresa.SFechaNotario);

                Data.ListaMunicipios(cbMunicipiosNotario, "");
                cbMunicipiosNotario.SelectedIndex = cbMunicipiosNotario.FindStringExact(eEmpresa.SMunicipioNotario);
            }

            if (actualizar)
            {
                bCrearCliente.Text = "Actualizar cliente";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void tTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void OK_Click(object sender, EventArgs e)
        {

           



        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void bIban_Click(object sender, EventArgs e)
        {

            if (!cIban.Items.Contains(tIban.Text))
            {
                cIban.Items.Insert(0, tIban.Text);
                tIban.Clear();

            }
            else if (!tIban.Text.Equals(""))
            {
                MessageBox.Show("Cuenta Iban ya añadida anteriormente", "Error de cuenta",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bEliminarIban_Click(object sender, EventArgs e)
        {
            if (cIban.Items.Count > cIban.SelectedIndex && cIban.Items.Count > -1 && cIban.SelectedIndex > -1)
            {
                cIban.Items.RemoveAt(cIban.SelectedIndex);
            }
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void tCif_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pEmpresa_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (bCrearCliente.Text.Equals("Añadir Cliente"))
            {
                if (cCliente == null)
                {
                    DateTime fFecha = DateTime.Now;

                    try
                    {
                        test_campos();

                        cCliente = Cliente.Create(tNombre.Text, tApellido.Text, tDni.Text,
                       tTipoCliente.Text, tTipoVia.Text, tDireccion.Text,
                       tNumero.Text, tPisoCliente.Text, tProvincias.Text, tMunicipios.Text, tCp.Text,
                       tTelefono.Text, fFecha.ToString("yyyy-MM-dd"), tEmail.Text);

                        if (tTipoCliente.SelectedItem.Equals("Empresa"))
                            eEmpresa = Empresa.create(cCliente.getId(), tCif.Text, tRazonSocial.Text, cbTipoViaEmpresa.Text, tDireccionEmpresa.Text, tNumeroEmpresa.Text,
                                                      tPisoEmpresa.Text, tCpEmpresa.Text, cbProvinciasEmpresa.Text, cbMunicipiosEmpresa.Text, tNombreNotario.Text,cbProvinciasNotario.Text, cbMunicipiosNotario.Text,
                                                      tNumeroProtocolo.Text, Data.formatearFecha(tFechaNotario.Text));

                        ArrayList lIban = new ArrayList();

                        for (int i = 0; i < cIban.Items.Count; i++)
                        {
                            if (!cIban.Items[i].ToString().Equals(""))
                                lIban.Add(cIban.Items[i].ToString());
                        }

                        Cliente_Iban ciClienteIban = Cliente_Iban.create(cCliente.getId(), lIban);


                        MessageBox.Show("Cliente añadido.", "Operación realizada correctamente");
                        this.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error de formulario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El cliente ya ha sido añadido.");
                }
            }
            else
            {
                try
                {
                    test_campos();

                    Cliente.actualizar(cCliente.getId(), tNombre.Text, tApellido.Text, tDni.Text,
                       tTipoCliente.Text, tTipoVia.Text, tDireccion.Text,
                       tNumero.Text, tPisoCliente.Text, tProvincias.Text, tMunicipios.Text, tCp.Text,
                       tTelefono.Text, tEmail.Text);

                    if (tTipoCliente.Items[tTipoCliente.SelectedIndex].ToString().Equals("Empresa")) {
                        if (eEmpresa != null)
                            Empresa.actualizar(eEmpresa.IId, cCliente.getId(), tCif.Text, tRazonSocial.Text, cbTipoViaEmpresa.Text, tDireccionEmpresa.Text, tNumeroEmpresa.Text,
                                              tPisoEmpresa.Text, tCpEmpresa.Text, cbProvinciasEmpresa.Text, cbMunicipiosEmpresa.Text, tNombreNotario.Text,cbProvinciasNotario.Text, cbMunicipiosNotario.Text,
                                              tNumeroProtocolo.Text, Data.formatearFecha(tFechaNotario.Text));
                        else
                            Empresa.create(cCliente.getId(), tCif.Text, tRazonSocial.Text, cbTipoViaEmpresa.Text, tDireccionEmpresa.Text, tNumeroEmpresa.Text,
                                                      tPisoEmpresa.Text, tCpEmpresa.Text, cbProvinciasEmpresa.Text, cbMunicipiosEmpresa.Text, tNombreNotario.Text,cbProvinciasNotario.Text, cbMunicipiosNotario.Text,
                                                      tNumeroProtocolo.Text, Data.formatearFecha(tFechaNotario.Text));
                }
                    //MEJORAR ACTUALIZACION DE CLIENTE IBAN (NO ELIMINAR Y CREAR)
                    Cliente_Iban.delete(cCliente.getId());

                    ArrayList lIban = new ArrayList();

                    for (int i = 0; i < cIban.Items.Count; i++)
                    {
                        if (!cIban.Items[i].ToString().Equals(""))
                            lIban.Add(cIban.Items[i].ToString());
                    }

                    Cliente_Iban clienteIban = Cliente_Iban.create(cCliente.getId(), lIban);

                    MessageBox.Show("Cliente actualizado.", "Operación realizada correctamente");

                    this.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error de formulario",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        public void test_campos()
        {
            try
            {
                DateTime fFecha = DateTime.Now;

                Cliente.error_test(tNombre.Text, tApellido.Text, tDni.Text,
                       tTipoCliente.Text, tTipoVia.Text, tDireccion.Text,
                       tNumero.Text, tProvincias.Text, tMunicipios.Text, tCp.Text,
                       tTelefono.Text, fFecha.ToString("yyyy-MM-dd"), tEmail.Text);

                Empresa.error_test(tCif.Text, tRazonSocial.Text, cbTipoViaEmpresa.Text, tDireccionEmpresa.Text, tNumeroEmpresa.Text,
                                              tPisoEmpresa.Text, tCpEmpresa.Text, cbProvinciasEmpresa.Text, cbMunicipiosEmpresa.Text, tNombreNotario.Text,
                                              cbProvinciasNotario.Text, cbMunicipiosNotario.Text,
                                              tNumeroProtocolo.Text, Data.formatearFecha(tFechaNotario.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TIban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (Cliente_Iban.check_iban(tIban.Text.ToUpper().Replace(" ", "")))
                    {
                        cIban.Items.Add(tIban.Text.ToUpper().Replace(" ", ""));
                        cIban.SelectedIndex = cIban.Items.Count - 1;
                        tIban.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Iban no válido.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void CIban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (cIban.Items.Count > 0) cIban.Items.RemoveAt(cIban.SelectedIndex);
                    else throw new Exception("No hay ninguna cuenta Iban añadida.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BConsultarCif_Click(object sender, EventArgs e)
        {

            try
            {

                string [] sDatos = Empresa.consultar_empresa(tCif.Text);

                ClearTextBoxes(tabPage2);

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

        private void TTipoCliente_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tTipoCliente.SelectedItem.Equals("Empresa")){

                if (tabControl1.TabPages.Count < 2)
                    tabControl1.TabPages.Add(tabPage2);

            }else if (tTipoCliente.SelectedItem.Equals("Particular"))
                if(tabControl1.TabPages.Count > 1)
                tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
        }

        private void TProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tMunicipios.Items.Clear();
                tMunicipios.Text = "";
                Data.ListaMunicipios(tMunicipios, tProvincias.Text);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearTextBoxes(Control control)

        {

            foreach (Control c in control.Controls)

            {

                if (c is TextBox)

                {

                    ((TextBox)c).Clear();

                }

                if (c.HasChildren)

                {

                    ClearTextBoxes(c);

                }

            }

        }

        private void TableLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TTelefono_Leave(object sender, EventArgs e)
        {
            string sAux = tTelefono.Text;
            tTelefono.Clear();
            tTelefono.SelectedText = sAux.Replace(" ", "").Replace("-","");
        }

        private void TNombre_Leave(object sender, EventArgs e)
        {
            if (!tNombre.Text.Equals(""))
            {
                string sAux = tNombre.Text;
                tNombre.Clear();

                string[] asAux = sAux.Split(' ');

                for (int i = 0; i < asAux.Length; i++)
                {
                    if (asAux[i].Length > 0)
                    {
                        asAux[i] = asAux[i].Substring(0, 1).ToUpper() + asAux[i].Substring(1, asAux[i].Length - 1).ToLower() + " ";
                        tNombre.SelectedText = asAux[i];
                    }
                }

                sAux = tNombre.Text;

                sAux = sAux.Replace(" Del ", " del ");
                sAux = sAux.Replace(" La ", " la ");
                sAux = sAux.Replace(" El ", " el ");
                sAux = sAux.Replace(" De ", " de ");
                sAux = sAux.Replace(" Las ", " las ");
                sAux = sAux.Replace(" Los ", " los ");

                tNombre.Clear();
                tNombre.SelectedText = sAux.Substring(0, sAux.Length - 1);
            }
        }

        private void TApellido_Leave(object sender, EventArgs e)
        {
            if (!tApellido.Text.Equals(""))
            {
                string sAux = tApellido.Text;
                tApellido.Clear();

                string[] asAux = sAux.Split(' ');

                for (int i = 0; i < asAux.Length; i++)
                {
                    if (asAux[i].Length > 0)
                    {
                        asAux[i] = asAux[i].Substring(0, 1).ToUpper() + asAux[i].Substring(1, asAux[i].Length - 1).ToLower() + " ";
                        tApellido.SelectedText = asAux[i];
                    }
                }

                sAux = tApellido.Text;

                sAux = sAux.Replace(" Del ", " del ");
                sAux = sAux.Replace(" La ", " la ");
                sAux = sAux.Replace(" El ", " el ");
                sAux = sAux.Replace(" De ", " de ");
                sAux = sAux.Replace(" Las ", " las ");
                sAux = sAux.Replace(" Los ", " los ");

                tApellido.Clear();
                tApellido.SelectedText = sAux.Substring(0, sAux.Length - 1);
            }
        }

        private void TDni_Leave(object sender, EventArgs e)
        {
            string sAux = tDni.Text;
            sAux = sAux.Replace("-", "");
            sAux = sAux.Replace(" ", "");
            sAux = sAux.ToUpper();

            tDni.Clear();
            tDni.SelectedText = sAux;
        }

        private void TMunicipios_TextChanged(object sender, EventArgs e)
        {

        }

        private void TProvincias_TextChanged(object sender, EventArgs e)
        {


        }

        private void CbProvinciasEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbMunicipiosEmpresa.Items.Clear();
                cbMunicipiosEmpresa.Text = "";
                Data.ListaMunicipios(cbMunicipiosEmpresa, cbProvinciasEmpresa.Text);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CbProvinciasEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void TNombreNotario_Leave(object sender, EventArgs e)
        {
            if (!tNombreNotario.Text.Equals(""))
            {
                string sAux = tNombreNotario.Text;
                tNombreNotario.Clear();

                string[] asAux = sAux.Split(' ');

                for (int i = 0; i < asAux.Length; i++)
                {
                    if (asAux[i].Length > 0)
                    {
                        asAux[i] = asAux[i].Substring(0, 1).ToUpper() + asAux[i].Substring(1, asAux[i].Length - 1).ToLower() + " ";
                        tNombreNotario.SelectedText = asAux[i];
                    }
                }

                sAux = tNombreNotario.Text;

                sAux = sAux.Replace(" Del ", " del ");
                sAux = sAux.Replace(" La ", " la ");
                sAux = sAux.Replace(" El ", " el ");
                sAux = sAux.Replace(" De ", " de ");
                sAux = sAux.Replace(" Las ", " las ");
                sAux = sAux.Replace(" Los ", " los ");

                tNombreNotario.Clear();
                tNombreNotario.SelectedText = sAux.Substring(0, sAux.Length - 1);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMunicipiosNotario.Items.Clear();
            cbMunicipiosNotario.Text = "";
            Data.ListaMunicipios(cbMunicipiosNotario, cbProvinciasNotario.Text);
        }

        private void TFechaNotario_Leave(object sender, EventArgs e)
        {
            string sFecha = Data.formatearFecha(tFechaNotario.Text);

            tFechaNotario.Clear();
            tFechaNotario.SelectedText = sFecha;
        }
    }
}
