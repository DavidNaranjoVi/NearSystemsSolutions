using System;
using System.Collections;
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
    public partial class CrearContrato : Form
    {

        static Cliente c = null;
        static Empresa eEmpresa = null;
        ArrayList aElementoIncluido = new ArrayList();
        DBSesion db = null;
        ContratoPlantilla contratoPlantilla = null;
        Contrato contrato = null;
        Anexo aAnexo = null;

        public CrearContrato()
        {

            InitializeComponent();
            ajustarPantalla();
            tabControl1.TabPages.Remove(tabPage2);

            DateTime fFecha = DateTime.Now;
            cMensualidad.SelectedIndex = 0;
            dtpFechaVigor.SelectedText = tFechaContrato.SelectedText = (fFecha.ToString("yyyy-MM-dd"));

            cbInstalacion.Checked = true;
            cbMantenimiento.Checked = true;

            tFPInstalacion.SelectedText = "Domiciliación";
            tFPMantenimiento.SelectedText = "Domiciliación mensual";

            tMantenimiento.SelectedText = "24";

            dgElementos.ColumnCount = 4;
            dgElementos.Columns[0].Name = "Nombre";
            dgElementos.Columns[1].Name = "Código";
            dgElementos.Columns[2].Name = "Cantidad";
            dgElementos.Columns[3].Name = "id";
            dgElementos.Columns[3].Visible = false;

            dgElementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            tNContrato.SelectedText = (Contrato.Consultar_num() + 1).ToString();


            cbInstalacion.Checked = true;
            cbMantenimiento.Checked = true;
            cRobo.Checked = true;
            cCctv.Checked = true;
            cInstalar.Checked = true;
            cMantener.Checked = true;


            nudDuracion.Value = 12;
        }

        public void ajustarPantalla()
        {
            tableLayoutPanel42.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width*0.738),(int)( Screen.PrimaryScreen.Bounds.Height*0.797));
            tlpFormularioCliente.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width*0.718), (int)(Screen.PrimaryScreen.Bounds.Height*0.644));
            tableLayoutPanel14.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.718), (int)(Screen.PrimaryScreen.Bounds.Height * 0.644));
            tableLayoutPanel1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.718), (int)(Screen.PrimaryScreen.Bounds.Height * 0.61));
            tableLayoutPanel31.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.718), (int)(Screen.PrimaryScreen.Bounds.Height * 0.61));
            ajustarMenu(tableLayoutPanel42);
            ajustarMenu(tableLayoutPanel1);
            ajustarMenu(tableLayoutPanel31);
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
                    c.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, (int)(Screen.PrimaryScreen.Bounds.Width * 0.0055), FontStyle.Regular);
                    ajustarMenu(c);

                }

            }
        }


        public CrearContrato(Contrato cContrato)
        {
            try
            {
                InitializeComponent();
                ajustarPantalla();


                dgElementos.ColumnCount = 4;
                dgElementos.Columns[0].Name = "Nombre";
                dgElementos.Columns[1].Name = "Código";
                dgElementos.Columns[2].Name = "Cantidad";
                dgElementos.Columns[3].Name = "id";
                dgElementos.Columns[3].Visible = false;

                dgElementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                contrato = cContrato;

                tNContrato.SelectedText = contrato.INumeroContrato.ToString();
                tNAbonado.SelectedText = contrato.SNumeroAbonado.ToString();
                tFechaContrato.SelectedText = Data.formatearFecha(contrato.SFechaContrato);

                bCerrarContrato.Text = "Actualizar contrato";

                if (contrato.EEmpresa == null)
                    tabControl1.TabPages.Remove(tabPage2);

                c = new Cliente(contrato.IIdCliente);

                Fill_Cliente();

                if (c.getTipoCliente().Equals("Empresa"))
                {

                    eEmpresa = new Empresa(contrato.IIdEmpresa);
                    Fill_Empresa();
                }

                aAnexo = new Anexo(contrato.IIdAnexo);

                Fill_Condiciones(contrato);

                Fill_Anexo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        public CrearContrato(ContratoPlantilla contratoPlantilla)
        {
            try
            {
                InitializeComponent();
                ajustarPantalla();
                dgElementos.ColumnCount = 4;
                dgElementos.Columns[0].Name = "Nombre";
                dgElementos.Columns[1].Name = "Código";
                dgElementos.Columns[2].Name = "Cantidad";
                dgElementos.Columns[3].Name = "id";
                dgElementos.Columns[3].Visible = false;

                dgElementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bPlantilla.Text = "Actualizar borrador";

                this.contratoPlantilla = contratoPlantilla;

                tFechaContrato.SelectedText = Data.formatearFecha(contratoPlantilla.SFechaContrato);
                tNContrato.SelectedText = contratoPlantilla.INumeroContrato.ToString(); ;
                tNAbonado.SelectedText = contratoPlantilla.SNumeroAbonado;

                if(contratoPlantilla.Id_cliente != 0)
                {
                    c = new Cliente(contratoPlantilla.Id_cliente);
                    Fill_Cliente();
                }


                if (contratoPlantilla.Id_empresa != 0)
                {
                    eEmpresa = new Empresa(contratoPlantilla.Id_empresa);
                    Fill_Empresa();
                }

                Fill_Condiciones(contratoPlantilla);

                if (contratoPlantilla.Id_anexo != 0)
                    aAnexo = new Anexo(contratoPlantilla.Id_anexo);

                Fill_Anexo();


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Fill_Cliente()
        {
            tNombre.Clear();
            tNombre.SelectedText = c.getNombre();

            tApellido.Clear();
            tApellido.SelectedText = c.getApellido();

            tDni.Clear();
            tDni.SelectedText = c.getDni();

            tTipoCliente.SelectedIndex = tTipoCliente.FindStringExact(c.getTipoCliente());

            tTelefono.Clear();
            tTelefono.SelectedText = c.getTelefono();

            tEmail.Clear();
            tEmail.SelectedText = c.getEmail();

            cbIban.Items.Clear();

            tTipoVia.SelectedIndex = tTipoVia.FindStringExact(c.getTipoVia());

            tDireccion.Clear();
            tDireccion.SelectedText = c.getDireccion();

            tProvincia.Clear();
            tProvincia.SelectedText = c.getDireccion();

            tMunicipio.Clear();
            tMunicipio.SelectedText = c.getMunicipio();

            tNumero.Clear();
            tNumero.SelectedText = c.getNumero();

            tPisoCliente.Clear();
            tPisoCliente.SelectedText = c.getPiso();

            tCp.Clear();
            tCp.SelectedText = c.getCp();

            Cliente_Iban cliente_iban = new Cliente_Iban(c.getId());

            ArrayList aIbans = cliente_iban.AIban;

            for (int i = 0; i < aIbans.Count; i++)
            {
                cbIban.Items.Add(aIbans[i]);
                cIban.Items.Add(aIbans[i]);
            }

            if (cIban.Items.Count > 0)
            {
                cIban.SelectedIndex = 0;
               
            }

            if(contrato == null && contratoPlantilla == null)
            {
                tLugar.Clear();
                tLugar.SelectedText = c.getDireccion();

                tCalle.Clear();
                tCalle.SelectedText = c.getDireccion();

                tCpCondiciones.Clear();
                tCpCondiciones.SelectedText = c.getCp();

                cbProvinciasCondiciones.Items.Clear();
                Data.ListaProvincias(cbProvinciasCondiciones);
                cbProvinciasCondiciones.SelectedIndex = cbProvinciasCondiciones.FindStringExact(c.getProvincia());

                cbMunicipiosCondiciones.Items.Clear();
                Data.ListaMunicipios(cbMunicipiosCondiciones, c.getProvincia());
                cbMunicipiosCondiciones.SelectedIndex = cbMunicipiosCondiciones.FindStringExact(c.getMunicipio());

                tPersonaContacto.Clear();
                tPersonaContacto.SelectedText = c.getNombre() + " " + c.getApellido();

                tTelefonoCondiciones.Clear();
                tTelefonoCondiciones.SelectedText = c.getTelefono();

            }

        }

        public void Fill_Empresa()
        {
            tCif.Clear();
            tCif.SelectedText = eEmpresa.SCif;

            tRazonSocial.Clear();
            tRazonSocial.SelectedText = eEmpresa.SRazonSocial;

            for (int i = 0; i < cbTipoViaEmpresa.Items.Count; i++)
                if (cbTipoViaEmpresa.Items[i].Equals(eEmpresa.STipoVia))
                    cbTipoViaEmpresa.SelectedIndex = i;

            tDireccionEmpresa.Clear();
            tDireccionEmpresa.SelectedText = eEmpresa.SDireccion;

            tNumeroEmpresa.Clear();
            tNumeroEmpresa.SelectedText = eEmpresa.SNumero;

            tPisoEmpresa.Clear();
            tPisoEmpresa.SelectedText = eEmpresa.SPiso;

            tProvinciaEmpresa.Clear();
            tProvinciaEmpresa.SelectedText = eEmpresa.SProvincia;

            tMunicipioEmpresa.Clear();
            tMunicipioEmpresa.SelectedText = eEmpresa.SMunicipio;

            tCpEmpresa.Clear();
            tCpEmpresa.SelectedText = eEmpresa.SCp;

            tNombreNotario.Clear();
            tNombreNotario.SelectedText = eEmpresa.SNombreNotario;

            tMunicipioNotario.Clear();
            tMunicipioNotario.SelectedText = eEmpresa.SNombreNotario;

            tNumeroProtocolo.Clear();
            tNumeroProtocolo.SelectedText = eEmpresa.SNumeroProtocolo;

            tFechaNotario.Clear();
            tFechaNotario.SelectedText = Data.formatearFecha(eEmpresa.SFechaNotario);

            if (contrato == null && contratoPlantilla == null)
            {

                tLugar.Clear();
                tLugar.SelectedText = eEmpresa.SDireccion;

                tCalle.Clear();
                tCalle.SelectedText = eEmpresa.SDireccion;

                tCpCondiciones.Clear();
                tCpCondiciones.SelectedText = eEmpresa.SCp;

                cbProvinciasCondiciones.Items.Clear();
                Data.ListaProvincias(cbProvinciasCondiciones);
                cbProvinciasCondiciones.SelectedIndex = cbProvinciasCondiciones.FindStringExact(eEmpresa.SProvincia);

                cbMunicipiosCondiciones.Items.Clear();
                Data.ListaMunicipios(cbMunicipiosCondiciones, eEmpresa.SProvincia);
                cbMunicipiosCondiciones.SelectedIndex = cbMunicipiosCondiciones.FindStringExact(eEmpresa.SMunicipio);
            }

        }

        public void Fill_Anexo()
        {
            if(aAnexo != null)
            {
                onlyRead_Anexo(true);
                tNumeroAnexo.Clear();
                tNumeroAnexo.SelectedText = aAnexo.SNumeroAnexo;

                tFechaAnexo.Clear();
                tFechaAnexo.SelectedText = Data.formatearFecha(aAnexo.SFecha);


                if (tTipoCliente.SelectedText.Equals("Empresa"))
                {
                    tCifAnexo.Clear();
                    tCifAnexo.SelectedText = aAnexo.SCif;

                    lRazonSocialAnexo.Text = "Razón social";

                    tRazonSocialAnexo.Clear();
                    tRazonSocialAnexo.SelectedText = aAnexo.SRazonSocial;

                    tRepresentante.Clear();
                    tRepresentante.SelectedText = aAnexo.SRepresentanteNombre;

                    tDniRepresentante.Clear();
                    tDniRepresentante.SelectedText = aAnexo.SRepresentanteDni;

                    tCargo.Clear();
                    tCargo.SelectedText = aAnexo.SRepresentantePuesto;


                }
                else
                {
                    tCifAnexo.Clear();
                    tCifAnexo.ReadOnly = true;

                    tRazonSocialAnexo.Clear();
                    tRazonSocialAnexo.ReadOnly = true;

                    tRepresentante.Clear();
                    tRepresentante.SelectedText = aAnexo.SRepresentanteNombre;

                    lDniRepresentante.Text = "Dni cliente";
                    tDniRepresentante.Clear();
                    tDniRepresentante.SelectedText = aAnexo.SRepresentanteDni;

                    tCargo.Clear();
                    tCargo.ReadOnly = true;
                }

                for (int i = 0; i < cbTipoViaAnexo.Items.Count; i++)
                    if (cbTipoViaAnexo.Items[i].Equals(aAnexo.STipoVia))
                        cbTipoViaAnexo.SelectedIndex = i;

                tDireccionAnexo.Clear();
                tDireccionAnexo.SelectedText = aAnexo.SDireccion;

                tNumeroDireccionAnexo.Clear();
                tNumeroDireccionAnexo.SelectedText = aAnexo.SNumero;

                tPisoAnexo.Clear();
                tPisoAnexo.SelectedText = aAnexo.SPiso;

                tProvinciaAnexo.Clear();
                tProvinciaAnexo.SelectedText = aAnexo.SProvincia;

                tMunicipioAnexo.Clear();
                tMunicipioAnexo.SelectedText = aAnexo.SMunicipio;

                tCpAnexo.Clear();
                tCpAnexo.SelectedText = aAnexo.SCp;


                tFirma.Clear();
                tFirma.SelectedText = aAnexo.SFirma;

                
            }else if(eEmpresa != null)
            {
                onlyRead_Anexo(false);
                tNumeroAnexo.Clear();
                tNumeroAnexo.SelectedText = "II";

                tFechaAnexo.Clear();
                tFechaAnexo.SelectedText = Data.formatearFecha(DateTime.Now.ToString());

                tCifAnexo.Clear();
                tCifAnexo.SelectedText = eEmpresa.SCif;

                lRazonSocialAnexo.Text = "Razón social";

                tRazonSocialAnexo.Clear();
                tRazonSocialAnexo.SelectedText = eEmpresa.SRazonSocial;

                tRepresentante.Clear();
                tRepresentante.SelectedText = c.getNombre()+" "+c.getApellido();

                tDniRepresentante.Clear();
                tDniRepresentante.SelectedText = c.getDni();

                tCargo.Clear();
                tCargo.SelectedText = "Gerente";

                for (int i = 0; i < cbTipoViaAnexo.Items.Count; i++)
                    if (cbTipoViaAnexo.Items[i].Equals(eEmpresa.STipoVia))
                        cbTipoViaAnexo.SelectedIndex = i;

                tDireccionAnexo.Clear();
                tDireccionAnexo.SelectedText = eEmpresa.SDireccion;

                tNumeroDireccionAnexo.Clear();
                tNumeroDireccionAnexo.SelectedText = eEmpresa.SNumero;

                tPisoAnexo.Clear();
                tPisoAnexo.SelectedText = eEmpresa.SPiso;

                tProvinciaAnexo.Clear();
                tProvinciaAnexo.SelectedText = eEmpresa.SProvincia;

                tMunicipioAnexo.Clear();
                tMunicipioAnexo.SelectedText = eEmpresa.SMunicipio;

                tCpAnexo.Clear();
                tCpAnexo.SelectedText = eEmpresa.SCp;

                tFirma.Clear();
                tFirma.SelectedText = c.getNombre() + " " + c.getApellido();

            }else if(c != null)
            {
                onlyRead_Anexo(false);
                tNumeroAnexo.Clear();
                tNumeroAnexo.SelectedText = "II";

                tFechaAnexo.Clear();
                tFechaAnexo.SelectedText = Data.formatearFecha(DateTime.Now.ToString());

                tCifAnexo.Clear();
                tCifAnexo.ReadOnly = true;

                tRazonSocialAnexo.Clear();
                tRazonSocialAnexo.ReadOnly = true;

                tRepresentante.Clear();
                tRepresentante.SelectedText = c.getNombre() + " " + c.getApellido();

                lDniRepresentante.Text = "Dni cliente";
                tDniRepresentante.Clear();
                tDniRepresentante.SelectedText = c.getDni();

                tCargo.Clear();

                for (int i = 0; i < cbTipoViaAnexo.Items.Count; i++)
                    if (cbTipoViaAnexo.Items[i].Equals(c.getTipoVia()))
                        cbTipoViaAnexo.SelectedIndex = i;

                tDireccionAnexo.Clear();
                tDireccionAnexo.SelectedText = c.getDireccion();

                tNumeroDireccionAnexo.Clear();
                tNumeroDireccionAnexo.SelectedText = c.getNumero();

                tPisoAnexo.Clear();
                tPisoAnexo.SelectedText = c.getPiso();

                tProvinciaAnexo.Clear();
                tProvinciaAnexo.SelectedText = c.getProvincia();

                tMunicipioAnexo.Clear();
                tMunicipioAnexo.SelectedText = c.getMunicipio();

                tCpAnexo.Clear();
                tCpAnexo.SelectedText = c.getCp();

                tFirma.Clear();
                tFirma.SelectedText = c.getNombre() + " " + c.getApellido();
            }
        }

        public void onlyRead_Anexo(bool bOnlyRead)
        {
            tNumeroAnexo.ReadOnly = bOnlyRead;         
            tFechaAnexo.ReadOnly = bOnlyRead;
            tCifAnexo.ReadOnly = bOnlyRead;
            tRazonSocialAnexo.ReadOnly = bOnlyRead;
            tRepresentante.ReadOnly = bOnlyRead;
            tDniRepresentante.ReadOnly = bOnlyRead;
            tCargo.ReadOnly = bOnlyRead;
            tDireccionAnexo.ReadOnly = bOnlyRead;
            tNumeroDireccionAnexo.ReadOnly = bOnlyRead;
            tPisoAnexo.ReadOnly = bOnlyRead;
            tProvinciaAnexo.ReadOnly = bOnlyRead;
            tMunicipioAnexo.ReadOnly = bOnlyRead;
            tCpAnexo.ReadOnly = bOnlyRead;
            tFirma.ReadOnly = bOnlyRead;
        }

        public void Fill_Condiciones(Object o)
        {
            if (o.GetType() == typeof(Contrato))
            {
                cbInstalacion.Checked = contrato.BInstalacion;
                cbMantenimiento.Checked = contrato.BMantenimiento;

                dtpFechaVigor.Clear();
                dtpFechaVigor.SelectedText = Data.formatearFecha(contrato.SFechaVigor);
                nudDuracion.Value = contrato.IDuracion;

                tInstalacion.Clear();
                tInstalacion.SelectedText = contrato.IPrecioInstalacion.ToString();

                tMantenimiento.Clear();
                tMantenimiento.SelectedText = contrato.IPrecioMantenimiento.ToString();

                tFPInstalacion.Clear();
                tFPInstalacion.SelectedText = contrato.SFormaPagoInstalacion;

                tFPMantenimiento.Clear();
                tFPMantenimiento.SelectedText = contrato.SFormaPagoMantenimiento;

                for (int i = 0; i < cMensualidad.Items.Count; i++)
                    if (cMensualidad.Items[i].Equals(contrato.SMensualidad))
                        cMensualidad.SelectedIndex = i;


                tLugar.Clear();
                tLugar.SelectedText = contrato.SLugar;

                tCalle.Clear();
                tCalle.SelectedText = contrato.SCalle;

                tCpCondiciones.Clear();
                tCpCondiciones.SelectedText = contrato.SCp;

                cbProvinciasCondiciones.Items.Clear();
                Data.ListaProvincias(cbProvinciasCondiciones);
                cbProvinciasCondiciones.SelectedIndex = cbProvinciasCondiciones.FindStringExact(contrato.SProvincia);

                cbMunicipiosCondiciones.Items.Clear();
                Data.ListaMunicipios(cbMunicipiosCondiciones, contrato.SProvincia);
                cbMunicipiosCondiciones.SelectedIndex = cbMunicipiosCondiciones.FindStringExact(contrato.SPoblacion);

                tPersonaContacto.Clear();
                tPersonaContacto.SelectedText = contrato.SPersonaContacto;

                tTelefonoCondiciones.Clear();
                tTelefonoCondiciones.SelectedText = contrato.STelefono;

                cRobo.Checked = contrato.BRobo;
                cCctv.Checked = contrato.BCctv;
                cMantener.Checked = contrato.BPrecioVisita;
                cInstalar.Checked = contrato.BPeriodicidadAnual;

                tFechaVisado.Clear();
                tFechaVisado.SelectedText = Data.formatearFecha(contrato.SFechaVisado);

                tCC.Clear();
                tCC.SelectedText = contrato.SCC;

                tCS.Clear();
                tCS.SelectedText = contrato.SCS;

                if(cbIban.FindStringExact(contrato.SIban) != -1)
                cbIban.SelectedIndex = cbIban.FindStringExact(contrato.SIban);

                Contrato_Elemento contrato_Elemento = new Contrato_Elemento(contrato.Id);

                ArrayList aElementosId = contrato_Elemento.AIdElementos;
                ArrayList aElementosCant = contrato_Elemento.ACantidad;

                for (int i = 0; i < aElementosId.Count; i++)
                {
                    Elemento e = new Elemento((int)aElementosId[i]);

                    String[] row =
                    {
                        e.SNombre,
                    e.SCodigo,
                    aElementosCant[i].ToString(),
                    e.IId.ToString()
                    };

                    dgElementos.Rows.Add(row);
                }
            }else
            {


                cbInstalacion.Checked = contratoPlantilla.BInstalacion;
                cbMantenimiento.Checked = contratoPlantilla.BMantenimiento;


                dtpFechaVigor.Clear();
                if (!contratoPlantilla.SFechaVigor.Equals(""))
                dtpFechaVigor.SelectedText = Data.formatearFecha(contratoPlantilla.SFechaVigor);

                nudDuracion.Value = contratoPlantilla.IDuracion;

                tInstalacion.Clear();
                tInstalacion.SelectedText = contratoPlantilla.IPrecioInstalacion.ToString();

                tMantenimiento.Clear();
                tMantenimiento.SelectedText = contratoPlantilla.IPrecioMantenimiento.ToString();

                tFPInstalacion.Clear();
                tFPInstalacion.SelectedText = contratoPlantilla.SFormaPagoInstalacion;

                tFPMantenimiento.Clear();
                tFPMantenimiento.SelectedText = contratoPlantilla.SFormaPagoMantenimiento;

                for (int i = 0; i < cMensualidad.Items.Count; i++)
                    if (cMensualidad.Items[i].Equals(contratoPlantilla.Mensualidad))
                        cMensualidad.SelectedIndex = i;


                tLugar.Clear();
                tLugar.SelectedText = contratoPlantilla.SLugar;

                tCalle.Clear();
                tCalle.SelectedText = contratoPlantilla.SCalle;

                tCpCondiciones.Clear();
                tCpCondiciones.SelectedText = contratoPlantilla.SCp;

                cbProvinciasCondiciones.Items.Clear();
                Data.ListaProvincias(cbProvinciasCondiciones);
                cbProvinciasCondiciones.SelectedIndex = cbProvinciasCondiciones.FindStringExact(contratoPlantilla.SProvincia);

                cbMunicipiosCondiciones.Items.Clear();
                Data.ListaMunicipios(cbMunicipiosCondiciones, contratoPlantilla.SProvincia);
                cbMunicipiosCondiciones.SelectedIndex = cbMunicipiosCondiciones.FindStringExact(contratoPlantilla.SPoblacion);

                tPersonaContacto.Clear();
                tPersonaContacto.SelectedText = contratoPlantilla.SPersonaContacto;

                tTelefonoCondiciones.Clear();
                tTelefonoCondiciones.SelectedText = contratoPlantilla.STelefono;

                cRobo.Checked = contratoPlantilla.BRobo;
                cCctv.Checked = contratoPlantilla.BCctv;
                cMantener.Checked = contratoPlantilla.BPrecioVisita;
                cInstalar.Checked = contratoPlantilla.BPeriodicidadAnual;

                tFechaVisado.Clear();
                tFechaVisado.SelectedText = Data.formatearFecha(contratoPlantilla.SFechaVisado);

                tCC.Clear();
                tCC.SelectedText = contratoPlantilla.SCC;

                tCS.Clear();
                tCS.SelectedText = contratoPlantilla.SCS;

                if(cbIban.FindStringExact(contratoPlantilla.SIban) != -1)
                cbIban.SelectedIndex = cbIban.FindStringExact(contratoPlantilla.SIban);

                ElementoPlantilla contrato_Elemento = new ElementoPlantilla(contratoPlantilla.Id);

                if (contrato_Elemento != null)
                {

                    ArrayList aElementosId = contrato_Elemento.Id_elemento;
                    ArrayList aElementosCant = contrato_Elemento.Cantidad;

                    for (int i = 0; i < aElementosId.Count; i++)
                    {
                        Elemento e = new Elemento((int)aElementosId[i]);

                        String[] row =
                        {
                        e.SNombre,
                         e.SCodigo,
                           aElementosCant[i].ToString(),
                            e.IId.ToString()
                    };

                        dgElementos.Rows.Add(row);
                    }

                }

                if(contratoPlantilla.Id_anexo != 0)
                {
                    aAnexo = new Anexo(contratoPlantilla.Id_anexo);
                    tAnexo.Clear();
                    tAnexo.SelectedText = (aAnexo.SRazonSocial.Equals("")) ? aAnexo.SRepresentanteNombre : aAnexo.SRazonSocial;

                }

                cbCustodia.Checked = contratoPlantilla.BCustodia;

                for (int i = 0; i < cIban.Items.Count; i++)
                {
                    if (cIban.Items[i].Equals(contratoPlantilla.SIban))
                        cIban.SelectedIndex = i;
                }

            }

            
        }

        private void bPlantilla_Click(object sender, EventArgs e)
        {

        }


        private void bElemento_Click(object sender, EventArgs e)
        {


        }

        private void bCerrarContrato_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CrearContrato_Load(object sender, EventArgs e)
        {

        }

        private void TlpFormularioCliente_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BSeleccionarCliente_Click(object sender, EventArgs e)
        {

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

        private void BPlantilla_Click_1(object sender, EventArgs e)
        {

        }

        private void BSeleccionarPlantilla_Click(object sender, EventArgs e)
        {


        }

       /* private void BSeleccionarPlantilla_Click_1(object sender, EventArgs e)
        {
            ConsultarBorrador consultarBorrador = new ConsultarBorrador();
            consultarBorrador.ShowDialog();

            ClearTextBoxes(this);

            Fill(consultarBorrador.CpPlantilla);
        }*/

        private void BPlantilla_Click_2(object sender, EventArgs e)
        {
            int id = 0;
            int id_empresa = 0;
            int id_anexo = 0;
            double precioInstalacion = 0;
            double precioMantenimiento = 0;

            if (c != null) id = c.getId();
            if (eEmpresa != null) id_empresa = eEmpresa.IId;

            if (!tInstalacion.Text.Equals(""))
                precioInstalacion = Convert.ToDouble(tInstalacion.Text);

            if(!tMantenimiento.Text.Equals(""))
                precioMantenimiento = Convert.ToDouble(tMantenimiento.Text);

            if (aAnexo != null)
                id_anexo = aAnexo.IId;


            try
            {
                if (contratoPlantilla == null)
                {

                    NombreBorrador form9 = new NombreBorrador(id, id_empresa, tNAbonado.Text,tNContrato.Text, Data.formatearFecha(tFechaContrato.Text), cbInstalacion.Checked, cbMantenimiento.Checked, Data.formatearFecha(dtpFechaVigor.Text), 12,
                        precioInstalacion, tFPInstalacion.Text, precioMantenimiento, tFPMantenimiento.Text,cMensualidad.SelectedItem.ToString(), tLugar.Text, tCalle.Text, tCpCondiciones.Text, cbMunicipiosCondiciones.Text,
                        cbProvinciasCondiciones.Text, tPersonaContacto.Text, tTelefonoCondiciones.Text, cRobo.Checked, cCctv.Checked, tAnexo.Text, cInstalar.Checked,
                        cMantener.Checked, cbCustodia.Checked, cbIban.Text,id_anexo,tFechaVisado.Text,tCC.Text,tCS.Text);
                    form9.ShowDialog();

                    for (int i = 0; i < dgElementos.RowCount - 1; i++)
                        ElementoPlantilla.create(form9.ContratoPlantilla.Id, Convert.ToInt32(dgElementos.Rows[i].Cells["id"].Value),
                            Convert.ToInt32(dgElementos.Rows[i].Cells["Cantidad"].Value));
                    this.Close();
                }
                else
                {
                    
                    ContratoPlantilla.actualizar(contratoPlantilla.Id, id_empresa, id, contratoPlantilla.SNombrePlantilla, tNAbonado.Text,
                        tNContrato.Text,Data.formatearFecha(tFechaContrato.Text), cbInstalacion.Checked, cbMantenimiento.Checked, Data.formatearFecha(dtpFechaVigor.Text),
                        Convert.ToInt32(nudDuracion.Value), precioInstalacion,
                        tFPInstalacion.Text,
                        precioMantenimiento,
                        tFPMantenimiento.Text,
                        tLugar.Text,
                        tCalle.Text,
                        tCpCondiciones.Text,
                        cbMunicipiosCondiciones.Text,
                        cbProvinciasCondiciones.Text,
                        tPersonaContacto.Text,
                        tTelefonoCondiciones.Text,
                        cRobo.Checked,
                        cCctv.Checked,
                        tAnexo.Text,
                        cInstalar.Checked,
                        cMantener.Checked,
                        cbCustodia.Checked,
                        cbIban.Items[cIban.SelectedIndex].ToString()
                        , tFechaVisado.Text, tCC.Text, tCS.Text);

                    ElementoPlantilla.delete(contratoPlantilla.Id);

                    for (int i = 0; i < dgElementos.RowCount - 1; i++)
                        ElementoPlantilla.create(contratoPlantilla.Id, Convert.ToInt32(dgElementos.Rows[i].Cells["id"].Value),
                            Convert.ToInt32(dgElementos.Rows[i].Cells["Cantidad"].Value));


                    MessageBox.Show("Plantilla actualizada.", "Operación realizada correctamente");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de formulario",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BSeleccionarCliente_Click_1(object sender, EventArgs e)
        {
            ConsultarCliente form5 = new ConsultarCliente(2);
            form5.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - (int)(Screen.PrimaryScreen.Bounds.Height * 0.11));
            form5.Location = Data.f1.pPanelBig.Location;
            form5.ShowDialog();


            c = (Cliente)form5.cliente();
            eEmpresa = (Empresa)form5.EEmpresa;

            if (c != null)
            {
                Fill_Cliente();
            }

            if (eEmpresa != null)
            {
                Fill_Empresa();
            }

            Fill_Anexo();
        }

        private void BCerrarContrato_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!bCerrarContrato.Text.Equals("Actualizar contrato"))
                {
                    int id = 0;

                    if (c != null) id = c.getId();

                    int iIdEmpresa = 0;

                    if (eEmpresa != null) iIdEmpresa = eEmpresa.IId;

                    if(aAnexo == null)
                     Anexo.error_test(tNumeroAnexo.Text, tCif.Text, "CONTRATO DE TRATAMIENTO DE DATOS DE CARÁCTER PERSONAL POR CUENTA DE TERCEROS", tFechaAnexo.Text, tRazonSocialAnexo.Text,
                                 cbTipoViaAnexo.Text, tDireccionAnexo.Text, tNumeroDireccionAnexo.Text, tPisoAnexo.Text, tCpAnexo.Text, tMunicipioAnexo.Text,
                                 tProvinciaAnexo.Text, tRepresentante.Text, tCargo.Text, tDniRepresentante.Text, tFirma.Text,eEmpresa != null);

                    Contrato.error_test(tNContrato.Text, tNAbonado.Text, id, (aAnexo==null)?0:aAnexo.IId, iIdEmpresa, tFechaContrato.Text, cbInstalacion.Checked,
                        cbMantenimiento.Checked, Data.formatearFecha(dtpFechaVigor.Text), Convert.ToInt32(nudDuracion.Value), tInstalacion.Text, tFPInstalacion.Text,
                        tMantenimiento.Text, tFPMantenimiento.Text, cMensualidad.Text, tLugar.Text, tCalle.Text, tCpCondiciones.Text, cbProvinciasCondiciones.Text,
                        cbProvinciasCondiciones.Text, tPersonaContacto.Text, tTelefonoCondiciones.Text, cRobo.Checked, cCctv.Checked, tRepresentante.Text,
                        cInstalar.Checked, cMantener.Checked, cbCustodia.Checked, cbIban.Text, Data.formatearFecha(tFechaVisado.Text), tCC.Text, tCS.Text);

                    if(aAnexo == null)
                        aAnexo = Anexo.create(tNumeroAnexo.Text,tCif.Text, "CONTRATO DE TRATAMIENTO DE DATOS DE CARÁCTER PERSONAL POR CUENTA DE TERCEROS", tFechaAnexo.Text, tRazonSocialAnexo.Text,
                                 cbTipoViaAnexo.Text, tDireccionAnexo.Text, tNumeroDireccionAnexo.Text, tPisoAnexo.Text, tCpAnexo.Text, tMunicipioAnexo.Text,
                                 tProvinciaAnexo.Text, tRepresentante.Text, tCargo.Text, tDniRepresentante.Text, tFirma.Text);

                    Contrato cContrato = Contrato.create(tNContrato.Text, tNAbonado.Text, id, aAnexo.IId, iIdEmpresa, tFechaContrato.Text, cbInstalacion.Checked,
                        cbMantenimiento.Checked, Data.formatearFecha(dtpFechaVigor.Text), Convert.ToInt32(nudDuracion.Value), Convert.ToDouble(tInstalacion.Text), tFPInstalacion.Text,
                        Convert.ToDouble(tMantenimiento.Text), tFPMantenimiento.Text, cMensualidad.Text, tLugar.Text, tCalle.Text, tCpCondiciones.Text, cbProvinciasCondiciones.Text,
                        cbProvinciasCondiciones.Text, tPersonaContacto.Text, tTelefonoCondiciones.Text, cRobo.Checked, cCctv.Checked, aAnexo.SRepresentanteNombre,
                        cInstalar.Checked, cMantener.Checked, cbCustodia.Checked, cbIban.SelectedItem.ToString(),Data.formatearFecha(tFechaVisado.Text),tCC.Text,tCS.Text);


                    ArrayList aIdElementos = new ArrayList();
                    ArrayList aCantidad = new ArrayList();

                    for (int i = 0; i < dgElementos.RowCount - 1; i++)
                    {
                        aIdElementos.Add(dgElementos[3, i].Value);
                        aCantidad.Add(dgElementos[2, i].Value);
                    }


                    Contrato_Elemento.create(cContrato.Id, aIdElementos, aCantidad);



                    MessageBox.Show("Contrato cerrado.", "Operación realizada correctamente");
                    this.Close();

                }
                else
                {
                    int idEmpresa = 0;

                    if (eEmpresa != null)
                        idEmpresa = eEmpresa.IId;

                    Contrato.error_test(tNContrato.Text, tNAbonado.Text, (c != null)?c.getId():0, aAnexo.IId, idEmpresa, Data.formatearFecha(tFechaContrato.Text), cbInstalacion.Checked,
                        cbMantenimiento.Checked, Data.formatearFecha(dtpFechaVigor.Text), Convert.ToInt32(nudDuracion.Value), tInstalacion.Text, tFPInstalacion.Text,
                       tMantenimiento.Text, tFPMantenimiento.Text, cMensualidad.Text, tLugar.Text, tCalle.Text, tCpCondiciones.Text, cbMunicipiosCondiciones.Text,
                        cbProvinciasCondiciones.Text, tPersonaContacto.Text, tTelefonoCondiciones.Text, cRobo.Checked, cCctv.Checked, tAnexo.Text,
                        cInstalar.Checked, cMantener.Checked, cbCustodia.Checked, cbIban.Text, Data.formatearFecha(tFechaVisado.Text), tCC.Text, tCS.Text);

                    Contrato cContrato = Contrato.actualizar(contrato.Id,tNContrato.Text, tNAbonado.Text, c.getId(), aAnexo.IId, idEmpresa, Data.formatearFecha(tFechaContrato.Text), cbInstalacion.Checked,
                        cbMantenimiento.Checked, Data.formatearFecha(dtpFechaVigor.Text), Convert.ToInt32(nudDuracion.Value), Convert.ToDouble(tInstalacion.Text), tFPInstalacion.Text,
                        Convert.ToDouble(tMantenimiento.Text), tFPMantenimiento.Text, cMensualidad.SelectedItem.ToString(), tLugar.Text, tCalle.Text, tCpCondiciones.Text, cbMunicipiosCondiciones.Text,
                        cbProvinciasCondiciones.Text, tPersonaContacto.Text, tTelefonoCondiciones.Text, cRobo.Checked, cCctv.Checked, tAnexo.Text,
                        cInstalar.Checked, cMantener.Checked, cbCustodia.Checked, cbIban.SelectedItem.ToString(),Data.formatearFecha(tFechaVisado.Text),tCC.Text,tCS.Text);

                    Contrato_Elemento.delete(cContrato.Id);

                    ArrayList aIdElementos = new ArrayList();
                    ArrayList aCantidad = new ArrayList();

                    for (int i = 0; i < dgElementos.RowCount - 1; i++)
                    {
                        aIdElementos.Add(dgElementos[3, i].Value);
                        aCantidad.Add(dgElementos[2, i].Value);
                    }

                    Contrato_Elemento.create(cContrato.Id, aIdElementos, aCantidad);

                    MessageBox.Show("Contrato actualizado.", "Operación realizada correctamente");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de formulario",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
         
        }

        private void BElemento_Click_1(object sender, EventArgs e)
        {
            AnadirElementos form12 = new AnadirElementos(dgElementos);
            form12.ShowDialog();
            aElementoIncluido = form12.EElementosIncluidos;
            dgElementos.Rows.Clear();
            for (int i = 0; i < form12.ElementosIncluidos.RowCount - 1; i++)
            {
                string[] row = { form12.ElementosIncluidos.Rows[i].Cells["Nombre"].Value.ToString(),
                    form12.ElementosIncluidos.Rows[i].Cells["Código"].Value.ToString(),
                    form12.ElementosIncluidos.Rows[i].Cells["Cantidad"].Value.ToString(),
                    form12.ElementosIncluidos.Rows[i].Cells["id"].Value.ToString()
                };
                dgElementos.Rows.Add(row);
            }
        }

        private void DgElementos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgElementos[2, e.RowIndex].Value) > 1)
                dgElementos[2, e.RowIndex].Value = (Convert.ToInt32(dgElementos[2, e.RowIndex].Value) - 1).ToString();

            else
                dgElementos.Rows.RemoveAt(e.RowIndex);

        }

        private void CrearContrato_Load_1(object sender, EventArgs e)
        {

        }

        private void TTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tTipoCliente.SelectedItem.Equals("Particular") && contrato == null && contratoPlantilla == null)
                tabControl1.TabPages.Remove(tabPage2);
            else if (contrato == null && contratoPlantilla == null && tabControl1.TabPages.Count < 4)
                tabControl1.TabPages.Insert(1, tabPage2);
        }

        private void BAnexo_Click(object sender, EventArgs e)
        {
            ConsultarAnexo consultarAnexo = new ConsultarAnexo();
            consultarAnexo.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - (int)(Screen.PrimaryScreen.Bounds.Height * 0.11));
            consultarAnexo.ShowDialog();

            if (consultarAnexo.AAnexo != null)
            {
                tAnexo.Clear();
                aAnexo = consultarAnexo.AAnexo;
                tAnexo.SelectedText = (aAnexo.SRazonSocial == null) ? aAnexo.SRepresentanteNombre : aAnexo.SRazonSocial;
                Fill_Anexo();
            }
        }

        private void BQuitarAnexo_Click(object sender, EventArgs e)
        {
            aAnexo = null;
            ClearTextBoxes(tabPage4);
            Fill_Anexo();
        }

        private void TCif_TextChanged(object sender, EventArgs e)
        {

        }

        private void TCif_Leave(object sender, EventArgs e)
        {
            tCif.SelectedText = tCif.Text.Replace(" ", "");
        }

        private void TlpFormularioCliente_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void TFechaContrato_Leave(object sender, EventArgs e)
        {
            string sFecha = tFechaContrato.Text;
            tFechaContrato.Clear();
            tFechaContrato.SelectedText= Data.formatearFecha(sFecha);
        }

        private void DtpFechaVigor_Leave(object sender, EventArgs e)
        {
            string sFecha = dtpFechaVigor.Text;
            dtpFechaVigor.Clear();
            dtpFechaVigor.SelectedText = Data.formatearFecha(sFecha);
        }

        private void TFechaVisado_Leave(object sender, EventArgs e)
        {
            string sFecha = tFechaVisado.Text;
            tFechaVisado.Clear();
            tFechaVisado.SelectedText = Data.formatearFecha(sFecha);
        }

        private void TInstalacion_Leave(object sender, EventArgs e)
        {
            string sPrecio = tInstalacion.Text;

            tInstalacion.Clear();
            tInstalacion.SelectedText = sPrecio.Replace(',', '.');
        }

        private void TMantenimiento_Leave(object sender, EventArgs e)
        {
            string sPrecio = tMantenimiento.Text;

            tMantenimiento.Clear();
            tMantenimiento.SelectedText = sPrecio.Replace(',', '.');
        }
    }
}
