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
    public partial class CrearFichaAbonado : Form
    {
        Contrato cContrato = null;
        Cliente cCliente = null;
        Empresa eEmpresa = null;
        FichaAbonado fichaAbonado = null;

        ArrayList zonasEliminadas = new ArrayList();
        ArrayList contactosEliminados = new ArrayList();

        int op;
        public CrearFichaAbonado(FichaAbonado ficha = null,int op = 1)
        {
            InitializeComponent();
            ajustarPantalla();

            this.op = op;

            if (ficha != null)
                bAceptar.Text = "Actualizar ficha de abonado";

            fichaAbonado = ficha;

            tEmpresaInstaladora.SelectedText = "Near Systems & Solutions, S.L.";
            tTipoPanel.SelectedText = "Ajax";

            dgZonas.ColumnCount = 4;
            dgZonas.Columns[0].Name = "Zona";
            dgZonas.Columns[1].Name = "Area";
            dgZonas.Columns[2].Name = "Descripcion de zona";
            dgZonas.Columns[3].Name = "id";
            dgZonas.Columns[3].Visible = false;

            dgZonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgZonas.ForeColor = Color.Black;

            dgContactos.ColumnCount = 6;
            dgContactos.Columns[0].Name = "Usuario";
            dgContactos.Columns[1].Name = "Nombre";
            dgContactos.Columns[2].Name = "Teléfono";
            dgContactos.Columns[3].Name = "Teléfono";
            dgContactos.Columns[4].Name = "Consigna Individual";
            dgContactos.Columns[5].Name = "id";
            dgContactos.Columns[5].Visible = false;

            dgContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgContactos.ForeColor = Color.Black;

            tFechaAlta.SelectedText = DateTime.Now.ToString("yyyy-MM-dd");
            tViaPrincipal.SelectedText = "IP";
            tModeloPrincipal.SelectedText = "HUB";
            tFormatoPrincipal.SelectedText = "CONTACT ID";
            tTestPrincipal.SelectedText = "DIARIO";
            tViaSecundaria.SelectedText = "GPRS";

            Data.ListaProvincias(cbProvincias);

            Fill();
        }

        public void ajustarPantalla()
        {
            tableLayoutPanel18.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width*0.75), (int)(Screen.PrimaryScreen.Bounds.Height*0.8));
            tabControl1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.75), (int)(Screen.PrimaryScreen.Bounds.Height * 0.56));
            ajustarMenu(tableLayoutPanel18);
            tableLayoutPanel1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.741), (int)(Screen.PrimaryScreen.Bounds.Height * 0.55));
            ajustarMenu(tableLayoutPanel1);
            tableLayoutPanel16.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width*0.8),(int)( Screen.PrimaryScreen.Bounds.Height*0.2));
            ajustarMenu(tableLayoutPanel16);
            tableLayoutPanel2.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.741), (int)(Screen.PrimaryScreen.Bounds.Height * 0.55));
            dgZonas.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.3), (int)(Screen.PrimaryScreen.Bounds.Height * 0.2));
            ajustarMenu(tableLayoutPanel2);
            tableLayoutPanel3.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.741), (int)(Screen.PrimaryScreen.Bounds.Height * 0.55));
            ajustarMenu(tableLayoutPanel3);

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

        private void tTelefonos_KeyDown(object sender, KeyEventArgs e)
        {
            if(!tTelefonos.Text.Equals("") && e.KeyCode == Keys.Enter)
            {
                if (cbTelefonos.Items.Count < 3)
                {
                    cbTelefonos.Items.Add(tTelefonos.Text);
                    cbTelefonos.SelectedIndex = cbTelefonos.Items.Count - 1;
                    tTelefonos.Clear();
                }
                else
                {
                    MessageBox.Show("Solo se puede un máximo de tres teléfonos", "Error al introducir el teléfono",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbTelefonos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cbTelefonos.Items.RemoveAt(cbTelefonos.SelectedIndex);
            }
        }

        private void bAnadirZona_Click(object sender, EventArgs e)
        {
            AnadirZona form14 = new AnadirZona(dgZonas.Rows.Count);
            form14.ShowDialog();

            for(int i = 0; i < form14.dgZonasIncluidas.RowCount; i++)
            {
                dgZonas.Rows.Add(form14.dgZonasIncluidas.Rows[i].Cells[0].Value,
                    form14.dgZonasIncluidas.Rows[i].Cells[1].Value,
                    form14.dgZonasIncluidas.Rows[i].Cells[2].Value,
                    ""
                    );
            }
        }

        private void dgContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bAnadirContacto_Click(object sender, EventArgs e)
        {
            AnadirPersonaContacto form15 = new AnadirPersonaContacto();
            form15.ShowDialog();

            for(int i = 0; i < form15.dgContactosIncluidos.RowCount; i++)
            {
                dgContactos.Rows.Add(
                    form15.dgContactosIncluidos.Rows[i].Cells[0].Value,
                    form15.dgContactosIncluidos.Rows[i].Cells[1].Value,
                    form15.dgContactosIncluidos.Rows[i].Cells[2].Value,
                    form15.dgContactosIncluidos.Rows[i].Cells[3].Value,
                    form15.dgContactosIncluidos.Rows[i].Cells[4].Value,
                    ""
                );
            }
        }

        private void dgZonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bEliminarContacto_Click(object sender, EventArgs e)
        {
            if (dgContactos.RowCount > 1)
            {
                if (!dgContactos[4, dgContactos.CurrentCell.RowIndex].Value.Equals(""))
                    contactosEliminados.Add(new ListaContactos(Convert.ToInt32(dgContactos[5, dgContactos.CurrentCell.RowIndex].Value)));

                dgContactos.Rows.RemoveAt(dgContactos.CurrentCell.RowIndex);
            }
        }

        private void bEliminarZona_Click(object sender, EventArgs e)
        {
            if (dgZonas.RowCount > 1)
            {
                if (!dgZonas[3, dgZonas.CurrentCell.RowIndex].Value.Equals(""))
                    zonasEliminadas.Add(new Zona(Convert.ToInt32(dgZonas[3, dgZonas.CurrentCell.RowIndex].Value)));
                dgZonas.Rows.RemoveAt(dgZonas.CurrentCell.RowIndex);
            }
            
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList aListaContactos = new ArrayList();
                ArrayList aZonas = new ArrayList();
                string [] tlfn = { "", "", "" };

                //string[,] zonas = new string[dgZonas.RowCount - 1, 4];
                //string[,] contactos = new string[dgContactos.RowCount - 1, 6];

                switch (op)
                {
                    case 1:
                        aListaContactos = new ArrayList();
                        aZonas = new ArrayList();
                        string[,] contactos = new string[dgContactos.RowCount,5];
                        string[,] zonas = new string[dgZonas.RowCount,6];

                        for (int i = 0; i < cbTelefonos.Items.Count; i++)
                        {
                            tlfn[i] = cbTelefonos.Items[i].ToString();
                        }


                            for (int i = 0; i < dgZonas.RowCount; i++)
                            {
                                zonas[i, 0] = dgZonas.Rows[i].Cells[0].Value.ToString();
                                zonas[i, 1] = dgZonas.Rows[i].Cells[1].Value.ToString();
                                zonas[i, 2] = dgZonas.Rows[i].Cells[2].Value.ToString();

                            }

                        MessageBox.Show(dgContactos.RowCount.ToString());
                            for (int i = 0; i < dgContactos.RowCount; i++)
                            {
                                contactos[i, 0] = dgContactos.Rows[i].Cells[0].Value.ToString();
                                contactos[i, 1] = dgContactos.Rows[i].Cells[1].Value.ToString();
                                contactos[i, 2] = dgContactos.Rows[i].Cells[2].Value.ToString();
                                contactos[i, 3] = dgContactos.Rows[i].Cells[3].Value.ToString();
                                contactos[i, 4] = dgContactos.Rows[i].Cells[4].Value.ToString();

                        }
                        
                        FichaAbonado.error_test(tEmpresaInstaladora.Text, tNAbonado.Text, tTipoPanel.Text,
                            Data.formatearFecha(tFechaAlta.Text), tNombreRazon.Text, tDireccion.Text, cbMunicipios.Text, cbProvincias.Text, tCOPO.Text, tlfn, tEmail.Text,
                            tViaPrincipal.Text, tModeloPrincipal.Text, tFormatoPrincipal.Text, tTestPrincipal.Text, tViaSecundaria.Text,
                            tModeloSecundaria.Text, tFormatoSecundaria.Text, tTestSecundaria.Text, tCCTVIP.Text, tModeloCctvip.Text,
                            tIpCliente.Text, tPuerto.Text, tIMEI.Text,
                            tConsignaGlobal.Text, tConsignaCoaccion.Text, tConsignaCra.Text, rtComentarios.Text, tCctv.Text,
                            tUsuario.Text, tContrasena.Text, tContrasenaRep.Text, tLlave.Text,tRepetirLlave.Text);

                        fichaAbonado = FichaAbonado.create(tEmpresaInstaladora.Text, tNAbonado.Text, tTipoPanel.Text,
                            tFechaAlta.Text, tNombreRazon.Text, tDireccion.Text, cbMunicipios.Text, cbProvincias.Text, tCOPO.Text, tlfn, tEmail.Text,
                            tViaPrincipal.Text, tModeloPrincipal.Text, tFormatoPrincipal.Text, tTestPrincipal.Text, tViaSecundaria.Text,
                            tModeloSecundaria.Text, tFormatoSecundaria.Text, tTestSecundaria.Text, tCCTVIP.Text, tModeloCctvip.Text,
                            tIpCliente.Text, tPuerto.Text, tIMEI.Text,
                            tConsignaGlobal.Text, tConsignaCoaccion.Text, tConsignaCra.Text, rtComentarios.Text, tCctv.Text,
                            tUsuario.Text, tContrasena.Text, tContrasenaRep.Text, tLlave.Text, tRepetirLlave.Text);


                            for (int i = 0; i < dgContactos.RowCount; i++)
                        {

                            aListaContactos.Add(ListaContactos.create(fichaAbonado.IId, contactos[i, 0],
                               contactos[i, 1], contactos[i, 2], contactos[i, 3], contactos[i, 4]));

                        }


                            for (int i = 0; i < dgZonas.RowCount; i++)
                        {
                            aZonas.Add(Zona.create(fichaAbonado.IId, zonas[i, 0], zonas[i, 1], zonas[i, 2]));
                        }

                        MessageBox.Show("Ficha de abonado creada correctamente.");
                        this.Close();

                        break;

                    case 2:

                        aListaContactos = new ArrayList();
                        aZonas = new ArrayList();
                        contactos = new string[dgContactos.RowCount, 6];
                        zonas = new string[dgZonas.RowCount, 6];

                        for (int i = 0; i < cbTelefonos.Items.Count; i++)
                        {
                            tlfn[i] = cbTelefonos.Items[i].ToString();
                        }
                      
                        for (int i = 0; i < dgZonas.RowCount; i++)
                        {
                            zonas[i, 0] = dgZonas.Rows[i].Cells[0].Value.ToString();
                            zonas[i, 1] = dgZonas.Rows[i].Cells[1].Value.ToString();
                            zonas[i, 2] = dgZonas.Rows[i].Cells[2].Value.ToString();
                            zonas[i, 3] = dgZonas.Rows[i].Cells[3].Value.ToString();

                        }


                        for (int i = 0; i < dgContactos.RowCount; i++)
                        {

                            contactos[i, 0] = dgContactos.Rows[i].Cells[0].Value.ToString();
                            contactos[i, 1] = dgContactos.Rows[i].Cells[1].Value.ToString();
                            contactos[i, 2] = dgContactos.Rows[i].Cells[2].Value.ToString();
                            contactos[i, 3] = dgContactos.Rows[i].Cells[3].Value.ToString();
                            contactos[i, 4] = dgContactos.Rows[i].Cells[4].Value.ToString();
                            contactos[i, 5] = dgContactos.Rows[i].Cells[5].Value.ToString();
                        }

                        FichaAbonado.error_test(tEmpresaInstaladora.Text, tNAbonado.Text, tTipoPanel.Text,
                            tFechaAlta.Text, tNombreRazon.Text, tDireccion.Text, cbMunicipios.Text, cbProvincias.Text, tCOPO.Text, tlfn, tEmail.Text,
                            tViaPrincipal.Text, tModeloPrincipal.Text, tFormatoPrincipal.Text, tTestPrincipal.Text, tViaSecundaria.Text,
                            tModeloSecundaria.Text, tFormatoSecundaria.Text, tTestSecundaria.Text, tCCTVIP.Text, tModeloCctvip.Text,
                            tIpCliente.Text, tPuerto.Text, tIMEI.Text,
                            tConsignaGlobal.Text, tConsignaCoaccion.Text, tConsignaCra.Text, rtComentarios.Text, tCctv.Text,
                            tUsuario.Text, tContrasena.Text, tContrasenaRep.Text, tLlave.Text, tRepetirLlave.Text);

                        fichaAbonado = FichaAbonado.update(fichaAbonado.IId,tEmpresaInstaladora.Text, tNAbonado.Text, tTipoPanel.Text,
                            Data.formatearFecha(tFechaAlta.Text), tNombreRazon.Text, tDireccion.Text, cbMunicipios.Text, cbProvincias.Text, tCOPO.Text, tlfn, tEmail.Text,
                            tViaPrincipal.Text, tModeloPrincipal.Text, tFormatoPrincipal.Text, tTestPrincipal.Text, tViaSecundaria.Text,
                            tModeloSecundaria.Text, tFormatoSecundaria.Text, tTestSecundaria.Text, tCCTVIP.Text, tModeloCctvip.Text,
                            tIpCliente.Text, tPuerto.Text, tIMEI.Text,
                            tConsignaGlobal.Text, tConsignaCoaccion.Text, tConsignaCra.Text, rtComentarios.Text, tCctv.Text,
                            tUsuario.Text, tContrasena.Text, tContrasenaRep.Text, tLlave.Text, tRepetirLlave.Text);

                        for(int i = 0; i < zonasEliminadas.Count; i++)
                        {
                            Zona.delete(((Zona)zonasEliminadas[i]).IId,2);
                        }

                        for(int i = 0; i < contactosEliminados.Count; i++)
                        {
                            ListaContactos.delete(((ListaContactos)contactosEliminados[i]).IId,2);
                        }

                        zonasEliminadas.Clear();
                        contactosEliminados.Clear();

                        for (int i = 0; i < dgContactos.RowCount; i++)
                        {

                            if (dgContactos[5, i].Value.Equals(""))
                                aListaContactos.Add(ListaContactos.create(fichaAbonado.IId, contactos[i, 0],
                                contactos[i, 1], contactos[i, 2], contactos[i, 3], contactos[i, 4]));
                            else
                                aListaContactos.Add(ListaContactos.update(Convert.ToInt32(contactos[i,5]), fichaAbonado.IId, contactos[i, 0],
                               contactos[i, 1], contactos[i, 2], contactos[i, 3], contactos[i, 4]));

                        }

                        for (int i = 0; i < dgZonas.RowCount; i++)
                        {
                            if (dgZonas[3, i].Value.Equals(""))
                                aZonas.Add(Zona.create(fichaAbonado.IId, zonas[i, 0], zonas[i, 1], zonas[i, 2]));
                            else
                                aZonas.Add(Zona.update(Convert.ToInt32(zonas[i,3]), fichaAbonado.IId, zonas[i, 0], zonas[i, 1], zonas[i, 2]));
                        }

                        MessageBox.Show("Ficha de abonado añadida correctamente.", "Operación realizada correctamente");
                        this.Close();
                        break;
                }
                

            }catch(Exception ex)
            {
             MessageBox.Show(ex.Message, "Error de consultas",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void bCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente form5 = new ConsultarCliente(2);
            form5.ShowDialog();

            if(form5.cliente() != null)
            {
                cCliente  = (Cliente)form5.cliente();
                eEmpresa = (Empresa)form5.EEmpresa;
            }
            Fill();
        }

        public void Fill()
        {
            if(fichaAbonado != null)
            {
                cContrato = FichaAbonado.consultar_contrato(fichaAbonado.SNAbonado);
                if(cContrato != null )cCliente = new Cliente(cContrato.IIdCliente);

                if(cContrato != null)
                    if(cContrato.IIdEmpresa != 0)
                        eEmpresa = new Empresa(cContrato.IIdEmpresa);

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

                cbProvincias.Items.Clear();
                Data.ListaProvincias(cbProvincias);
                cbProvincias.SelectedIndex = cbProvincias.FindStringExact(fichaAbonado.SProvincia);

                cbMunicipios.Items.Clear();
                Data.ListaMunicipios(cbMunicipios, cbProvincias.Text);
                cbMunicipios.SelectedIndex = cbMunicipios.FindStringExact(fichaAbonado.SLocalidad);

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

                    if (!fichaAbonado.STelefono2.Equals(""))
                    {
                        cbTelefonos.Items.Add(fichaAbonado.STelefono2);

                        if (!fichaAbonado.STelefono3.Equals(""))
                            cbTelefonos.Items.Add(fichaAbonado.STelefono3);
                    }
                }

                ArrayList zonas = fichaAbonado.consultar_zona();

                dgZonas.Rows.Clear();

                for(int i = 0; i < zonas.Count; i++)
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

                ArrayList contactos = fichaAbonado.consultar_contactos();

                dgContactos.Rows.Clear();

                for(int i = 0; i < contactos.Count; i++)
                {
                    ListaContactos lc = (ListaContactos)contactos[i];

                    string[] row =
                    {
                        lc.Usuario,
                        lc.Nombre,
                        lc.Telefono1,
                        lc.Telefono2,
                        lc.ConsignaIndividual,
                        lc.IId.ToString()
                    };

                    dgContactos.Rows.Add(row);
                }

                tConsignaGlobal.Clear();
                tConsignaGlobal.SelectedText = fichaAbonado.SConsignaGlobal;

                tConsignaCoaccion.Clear();
                tConsignaCoaccion.SelectedText = fichaAbonado.SConsignaCoaccion;

                tConsignaCra.Clear();
                tConsignaCra.SelectedText = fichaAbonado.SConsignaCRA;

                rtComentarios.Clear();
                rtComentarios.SelectedText = fichaAbonado.SComentarios;

                tUsuario.Clear();
                tUsuario.SelectedText = fichaAbonado.SUsuario;

                tCctv.Clear();
                tCctv.SelectedText = fichaAbonado.SCctv;

                tContrasena.Clear();
                tContrasena.SelectedText = fichaAbonado.SContrasena;

                tContrasenaRep.Clear();
                tContrasenaRep.SelectedText = fichaAbonado.SContrasena;

                tLlave.Clear();
                tLlave.SelectedText = fichaAbonado.SLlave;

                tRepetirLlave.Clear();
                tRepetirLlave.SelectedText = fichaAbonado.SLlave;

            }
            else if (eEmpresa != null)
            {
                string tipoVia = "";
                tNombreRazon.Clear();
                tNombreRazon.SelectedText = eEmpresa.SRazonSocial;

                switch (eEmpresa.STipoVia)
                {
                    case "Calle": tipoVia = "C/"; break;
                    case "Avenida": tipoVia = "Avd.";break;
                    case "Travesía": tipoVia = "Tr.";break;
                    case "Plaza": tipoVia = "Plza.";break;
                    case "Polígono": tipoVia = "Pol.";break;
                    case "Urbanización": tipoVia = "Urb.";break;
                    case "Carretera": tipoVia = "Ctra."; break;
                    case "Paseo": tipoVia = "P.º";break;
                }

                tDireccion.Clear();
                tDireccion.SelectedText = tipoVia + eEmpresa.SDireccion+","+eEmpresa.SNumero;

                tEmail.Clear();
                tEmail.SelectedText = new Cliente(eEmpresa.IIdCliente).getEmail();

                if (!eEmpresa.SPiso.Equals("")) tDireccion.SelectedText = "," + eEmpresa.SPiso;

                cbProvincias.Items.Clear();
                Data.ListaProvincias(cbProvincias);
                cbProvincias.SelectedIndex = cbProvincias.FindStringExact(eEmpresa.SProvincia);

                cbMunicipios.Items.Clear();
                Data.ListaMunicipios(cbMunicipios, cbProvincias.Text);
                cbMunicipios.SelectedIndex = cbMunicipios.FindStringExact(eEmpresa.SMunicipio);

                tCOPO.Clear();
                tCOPO.SelectedText = eEmpresa.SCp;

            }
            else if(cCliente != null)
            {
                string tipoVia = "";

                switch (cCliente.getTipoVia())
                {
                    case "Calle": tipoVia = "C/"; break;
                    case "Avenida": tipoVia = "Avd."; break;
                    case "Travesía": tipoVia = "Tr."; break;
                    case "Plaza": tipoVia = "Plza."; break;
                    case "Polígono": tipoVia = "Pol."; break;
                    case "Urbanización": tipoVia = "Urb."; break;
                    case "Carretera": tipoVia = "Ctra."; break;
                    case "Paseo": tipoVia = "P.º"; break;
                }

                tNombreRazon.Clear();
                tNombreRazon.SelectedText = cCliente.getNombre() + " " + cCliente.getApellido();

                tDireccion.Clear();
                tDireccion.SelectedText = tipoVia + cCliente.getDireccion() + eEmpresa + "," + cCliente.getNumero();

                if (!cCliente.getPiso().Equals("")) tDireccion.SelectedText = "," + cCliente.getPiso();

                tEmail.Clear();
                tEmail.SelectedText = cCliente.getEmail();

                cbProvincias.Items.Clear();
                Data.ListaProvincias(cbProvincias);
                cbProvincias.SelectedIndex = cbProvincias.FindStringExact(cCliente.getProvincia());

                cbMunicipios.Items.Clear();
                Data.ListaMunicipios(cbMunicipios, cbProvincias.Text);
                cbMunicipios.SelectedIndex = cbMunicipios.FindStringExact(cCliente.getMunicipio());

                tCOPO.Clear();
                tCOPO.SelectedText = cCliente.getCp();
            }

            if (fichaAbonado == null && cCliente != null)
            {
                cbTelefonos.Items.Clear();
                cbTelefonos.Items.Add(cCliente.getTelefono());
                cbTelefonos.SelectedIndex = cbTelefonos.Items.Count - 1;
            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TEmpresaInstaladora_TextChanged(object sender, EventArgs e)
        {

        }

        private void TNAbonado_TextChanged(object sender, EventArgs e)
        {

        }

        private void TTipoPanel_TextChanged(object sender, EventArgs e)
        {

        }

        private void TFechaAlta_TextChanged(object sender, EventArgs e)
        {

        }

        private void TCOPO_TextChanged(object sender, EventArgs e)
        {

        }

        private void TProvincia_TextChanged(object sender, EventArgs e)
        {

        }

        private void TEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void TTelefonos_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label35_Click(object sender, EventArgs e)
        {

        }

        private void CbTelefonos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TNombreRazon_TextChanged(object sender, EventArgs e)
        {

        }

        private void TDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void TLocalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void DgZonas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgZonas.RowCount > 1)
            {

                if (!dgZonas[3, e.RowIndex].Value.Equals(""))
                    zonasEliminadas.Add(new Zona(Convert.ToInt32(dgZonas[3, e.RowIndex].Value)));

                dgZonas.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DgContactos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgContactos.RowCount > 1)
            {
                if (!dgContactos[4, e.RowIndex].Value.Equals(""))
                    contactosEliminados.Add(new ListaContactos(Convert.ToInt32(dgContactos[5, e.RowIndex].Value)));

                dgContactos.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMunicipios.Items.Clear();
            Data.ListaMunicipios(cbMunicipios, cbProvincias.Text);
        }

        private void TFechaAlta_Leave(object sender, EventArgs e)
        {
            tFechaAlta.Text = Data.formatearFecha(tFechaAlta.Text);
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            AppConfiguration.saveConfig("EmpresaInstaladora", tEmpresaInstaladora.Text);
            AppConfiguration.saveConfig("NAbonado", tNAbonado.Text);
            AppConfiguration.saveConfig("TipoPanel", tTipoPanel.Text);
            AppConfiguration.saveConfig("FechaAlta", tFechaAlta.Text);
            AppConfiguration.saveConfig("NombreRazonSocial", tNombreRazon.Text);
            AppConfiguration.saveConfig("Direccion", tDireccion.Text);
            AppConfiguration.saveConfig("Provincia", cbProvincias.Text);
            AppConfiguration.saveConfig("Localidad", cbMunicipios.Text);
            AppConfiguration.saveConfig("COPO", tCOPO.Text);
            AppConfiguration.saveConfig("Email", tEmail.Text);

            AppConfiguration.saveConfig("ViaPrincipal", tViaPrincipal.Text);
            AppConfiguration.saveConfig("ModeloPrincipal", tModeloPrincipal.Text);
            AppConfiguration.saveConfig("FormatoPrincipal", tFormatoPrincipal.Text);
            AppConfiguration.saveConfig("TestPrincipal", tTestPrincipal.Text);
            AppConfiguration.saveConfig("ViaSecundaria", tViaSecundaria.Text);
            AppConfiguration.saveConfig("ModeloSecundaria", tModeloSecundaria.Text);
            AppConfiguration.saveConfig("FormatoSecundaria", tFormatoSecundaria.Text);
            AppConfiguration.saveConfig("TestSecundaria", tTestSecundaria.Text);
            AppConfiguration.saveConfig("CCTVIP", tCCTVIP.Text);
            AppConfiguration.saveConfig("ModeloCctv", tModeloCctvip.Text);
            AppConfiguration.saveConfig("IPCliente", tIpCliente.Text);
            AppConfiguration.saveConfig("Puerto", tPuerto.Text);
            AppConfiguration.saveConfig("IMEI", tIMEI.Text);

            AppConfiguration.saveConfig("ConsignaGlobal", tConsignaGlobal.Text);
            AppConfiguration.saveConfig("ConsignaCoaccion", tConsignaCoaccion.Text);
            AppConfiguration.saveConfig("ConsignaCRA", tConsignaCra.Text);

            AppConfiguration.saveConfig("Comentarios", rtComentarios.Text);
            AppConfiguration.saveConfig("Cctv", tCctv.Text);
            AppConfiguration.saveConfig("Usuario", tUsuario.Text);
            AppConfiguration.saveConfig("Contrasena", tContrasena.Text);
            AppConfiguration.saveConfig("ContrasenaRep", tContrasenaRep.Text);
            AppConfiguration.saveConfig("Llave", tLlave.Text);
            AppConfiguration.saveConfig("LlaveRep", tRepetirLlave.Text);
            
            for(int i = 0; i < cbTelefonos.Items.Count; i++)
            {
                AppConfiguration.saveConfig("Telefono" + i.ToString(), cbTelefonos.Items[i].ToString());
            }

            for(int i = 0; i < dgZonas.RowCount; i++)
            {
                AppConfiguration.saveConfig("Zona" + i.ToString(), dgZonas.Rows[i].Cells[0].Value.ToString());
                AppConfiguration.saveConfig("Area" + i.ToString(), dgZonas.Rows[i].Cells[1].Value.ToString());
                AppConfiguration.saveConfig("Descripcion" + i.ToString(), dgZonas.Rows[i].Cells[2].Value.ToString());
            }

            for(int i = 0; i < dgContactos.RowCount; i++)
            {
                AppConfiguration.saveConfig("Usuario" + i.ToString(), dgContactos.Rows[i].Cells[0].Value.ToString());
                AppConfiguration.saveConfig("Nombre" + i.ToString(), dgContactos.Rows[i].Cells[1].Value.ToString());
                AppConfiguration.saveConfig("Telefono1" + i.ToString(), dgContactos.Rows[i].Cells[2].Value.ToString());
                AppConfiguration.saveConfig("Telefono2" + i.ToString(), dgContactos.Rows[i].Cells[3].Value.ToString());
                AppConfiguration.saveConfig("ConsignaIndividual" + i.ToString(), dgContactos.Rows[i].Cells[4].Value.ToString());
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tEmpresaInstaladora.Clear();
            tEmpresaInstaladora.SelectedText = AppConfiguration.getConfig("EmpresaInstaladora");
            tNAbonado.Clear();
            tNAbonado.SelectedText = AppConfiguration.getConfig("NAbonado");
            tTipoPanel.Clear();
            tTipoPanel.SelectedText = AppConfiguration.getConfig("TipoPanel");
            tFechaAlta.Clear();
            tFechaAlta.SelectedText = AppConfiguration.getConfig("FechaAlta");
            tNombreRazon.Clear();
            tNombreRazon.SelectedText = AppConfiguration.getConfig("NombreRazonSocial");
            tDireccion.Clear();
            tDireccion.SelectedText = AppConfiguration.getConfig("Direccion");
            cbProvincias.Items.Clear();
            Data.ListaProvincias(cbProvincias);
            cbProvincias.SelectedIndex = cbProvincias.FindStringExact(AppConfiguration.getConfig("Provincia"));
            cbMunicipios.Items.Clear();
            Data.ListaMunicipios(cbMunicipios, AppConfiguration.getConfig("Provincia"));
            cbMunicipios.SelectedIndex = cbMunicipios.FindStringExact(AppConfiguration.getConfig("Localidad"));
            tCOPO.Clear();
            tCOPO.SelectedText = AppConfiguration.getConfig("COPO");
            tEmail.Clear();
            tEmail.SelectedText = AppConfiguration.getConfig("Email");

            tViaPrincipal.Clear();
            tViaPrincipal.SelectedText = AppConfiguration.getConfig("ViaPrincipal");
            tModeloPrincipal.Clear();
            tModeloPrincipal.SelectedText = AppConfiguration.getConfig("ModeloPrincipal");
            tFormatoPrincipal.Clear();
            tFormatoPrincipal.SelectedText = AppConfiguration.getConfig("FormatoPrincipal");
            tTestPrincipal.Clear();
            tTestPrincipal.SelectedText = AppConfiguration.getConfig("TestPrincipal");
            tViaSecundaria.Clear();
            tViaSecundaria.SelectedText = AppConfiguration.getConfig("ViaSecundaria");
            tModeloSecundaria.Clear();
            tModeloSecundaria.SelectedText = AppConfiguration.getConfig("ModeloSecundaria");
            tFormatoSecundaria.Clear();
            tFormatoSecundaria.SelectedText = AppConfiguration.getConfig("FormatoSecundaria");
            tTestSecundaria.Clear();
            tTestSecundaria.SelectedText = AppConfiguration.getConfig("TestSecundaria");
            tCCTVIP.Clear();
            tCCTVIP.SelectedText = AppConfiguration.getConfig("CCTVIP");
            tModeloCctvip.Clear();
            tModeloCctvip.SelectedText = AppConfiguration.getConfig("ModeloCctv");
            tIpCliente.Clear();
            tIpCliente.SelectedText = AppConfiguration.getConfig("IPCliente");
            tPuerto.Clear();
            tPuerto.SelectedText = AppConfiguration.getConfig("Puerto");
            tIMEI.Clear();
            tIMEI.SelectedText = AppConfiguration.getConfig("IMEI");

            tConsignaGlobal.Clear();
            tConsignaGlobal.SelectedText = AppConfiguration.getConfig("ConsignaGlobal");
            tConsignaCoaccion.Clear();
            tConsignaCoaccion.SelectedText = AppConfiguration.getConfig("ConsignaCoaccion");
            tConsignaCra.Clear();
            tConsignaCra.SelectedText = AppConfiguration.getConfig("ConsignaCRA");

            rtComentarios.Clear();
            rtComentarios.SelectedText = AppConfiguration.getConfig("Comentarios");
            tCctv.Clear();
            tCctv.SelectedText = AppConfiguration.getConfig("Cctv");
            tUsuario.Clear();
            tUsuario.SelectedText = AppConfiguration.getConfig("Usuario");
            tContrasena.Clear();
            tContrasena.SelectedText = AppConfiguration.getConfig("Contrasena");
            tContrasenaRep.Clear();
            tContrasenaRep.SelectedText = AppConfiguration.getConfig("ContrasenaRep");
            tLlave.Clear();
            tLlave.SelectedText = AppConfiguration.getConfig("Llave");
            tRepetirLlave.Clear();
            tRepetirLlave.SelectedText = AppConfiguration.getConfig("LlaveRep");

            dgZonas.Rows.Clear();
            dgContactos.Rows.Clear();
            cbTelefonos.Items.Clear();

            int i = 0;

            while (!AppConfiguration.getConfig("Zona" + i.ToString()).Equals(""))
            {
                dgZonas.Rows.Add(
                    AppConfiguration.getConfig("Zona" + i.ToString()),
                    AppConfiguration.getConfig("Area" + i.ToString()),
                    AppConfiguration.getConfig("Descripcion" + i.ToString())
                    );
                i++;
            }

            i = 0;

            while(!AppConfiguration.getConfig("Telefono" + i.ToString()).Equals(""))
            {
                cbTelefonos.Items.Add(AppConfiguration.getConfig("Telefono" + i.ToString()));
                i++;
            }

            i = 0;

            while(!AppConfiguration.getConfig("Usuario" + i.ToString()).Equals(""))
            {
                dgContactos.Rows.Add(
                    AppConfiguration.getConfig("Usuario" + i.ToString()),
                    AppConfiguration.getConfig("Nombre" + i.ToString()),
                    AppConfiguration.getConfig("Telefono1" + i.ToString()),
                    AppConfiguration.getConfig("Telefono2" + i.ToString()),
                    AppConfiguration.getConfig("ConsignaIndividual" + i.ToString())
                    );
                i++;
            }

        }
    }
}
