using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace NearSystemsSolutions
{
    public partial class consultaContrato : Form
    {
        bool documentacion = true;
        ArrayList contratos = null;
        public consultaContrato(bool d)
        {
            InitializeComponent();

            this.documentacion = d;

            dgContratos.ColumnCount = 8;
            dgContratos.Columns[0].Name = "Nº Contrato";
            dgContratos.Columns[1].Name = "Nº Abonado";
            dgContratos.Columns[2].Name = "Nombre";
            dgContratos.Columns[3].Name = "DNI";
            dgContratos.Columns[4].Name = "CIF";
            dgContratos.Columns[5].Name = "Fecha de entrada en vigor";
            dgContratos.Columns[6].Name = "Fecha de alta";
            dgContratos.Columns[7].Name = "id";
            dgContratos.Columns[7].Visible = false;

            dgContratos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Fill();

        }

        public consultaContrato(string sDocumentacion)
        {
            if (sDocumentacion.Equals("Documentación"))
            {
                documentacion = true;
            }

            InitializeComponent();

            dgContratos.ColumnCount = 8;
            dgContratos.Columns[0].Name = "Nº Contrato";
            dgContratos.Columns[1].Name = "Nº Abonado";
            dgContratos.Columns[2].Name = "Nombre";
            dgContratos.Columns[3].Name = "DNI";
            dgContratos.Columns[4].Name = "CIF";
            dgContratos.Columns[5].Name = "Fecha de entrada en vigor";
            dgContratos.Columns[6].Name = "Fecha de alta";
            dgContratos.Columns[7].Name = "id";
            dgContratos.Columns[7].Visible = false;

            dgContratos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Fill();
        }

        public void Fill(string sNContrato = "", string sNAbonado = "", string sDniCif = "",
           string sCif = "", string sFechaAlta = "")
        {
            //AÑADIR FILTROS
            contratos = Contrato.Consultar();

            Cliente cliente;
            Contrato contrato;
            Empresa empresa;

            for (int i = 0; i < contratos.Count; i++)
            {
                contrato = (Contrato)contratos[i];
                cliente = ((Contrato)contratos[i]).CCLiente;
                empresa = ((Contrato)contratos[i]).EEmpresa;

                string cif = "";

                if (empresa != null) cif = empresa.SCif.ToString();
                else cif = "No consta";

                string[] row =
                {
                    contrato.INumeroContrato.ToString(),
                    contrato.SNumeroAbonado.ToString(),
                    cliente.getNombre(),
                    cliente.getDni(),
                    cif,
                    contrato.SFechaVigor,
                    contrato.SFechaContrato,
                    contrato.Id.ToString()
                };

                dgContratos.Rows.Add(row);
            }

        }

        private void dgContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (documentacion)
            {
                GenerarDocumento form3 = new GenerarDocumento(new Contrato(Convert.ToInt32(dgContratos.Rows[e.RowIndex].Cells["id"].Value)));
                if (form3.IsAccessible)
                {
                    form3.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
                    form3.TopLevel = false;
                    form3.AutoScroll = true;

                    Data.f1.pPanelBig.Controls.Add(form3);
                    form3.Show();
                    this.Close();
                }
            }
            else
            {
                CrearContrato crearContrato = new CrearContrato(new Contrato(Convert.ToInt32(dgContratos.Rows[e.RowIndex].Cells["id"].Value)));
                crearContrato.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
                crearContrato.TopLevel = false;
                crearContrato.AutoScroll = true;

                Data.f1.pPanelBig.Controls.Add(crearContrato);

                crearContrato.Show();
                this.Close();
            }
        }

        private void ConsultaContrato_Load(object sender, EventArgs e)
        {

        }

        private void DgContratos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (documentacion)
            {
                GenerarDocumento form3 = new GenerarDocumento(new Contrato(Convert.ToInt32(dgContratos.Rows[e.RowIndex].Cells["id"].Value)));
                if (form3.IsAccessible)
                {
                    form3.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
                    form3.TopLevel = false;
                    form3.AutoScroll = true;

                    Data.f1.pPanelBig.Controls.Add(form3);
                    form3.Show();
                    this.Close();
                }
            }
            else
            {
                CrearContrato crearContrato = new CrearContrato(new Contrato(Convert.ToInt32(dgContratos.Rows[e.RowIndex].Cells["id"].Value)));
                crearContrato.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
                crearContrato.TopLevel = false;
                crearContrato.AutoScroll = true;

                Data.f1.pPanelBig.Controls.Add(crearContrato);

                crearContrato.Show();
                this.Close();
            }
        }

        private void DgContratos_KeyDown(object sender, KeyEventArgs e)
        {

            if (dgContratos.SelectedRows[0].Index != -1 && e.KeyCode == Keys.Delete)
            {
                Contrato cContrato = (Contrato)contratos[dgContratos.SelectedRows[0].Index];

                if (MessageBox.Show("¿Desea eliminar el contrato seleccionado?", "Confirmación de eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Contrato.delete(cContrato.Id);
                        MessageBox.Show("Contrato eliminado satisfactoriamente.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
