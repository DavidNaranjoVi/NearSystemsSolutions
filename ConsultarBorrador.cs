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
    public partial class ConsultarBorrador : Form
    {
        ArrayList contratoPlantilla = null;
        ContratoPlantilla cpPlantilla = null;

        public ContratoPlantilla CpPlantilla { get => cpPlantilla; set => cpPlantilla = value; }

        public ConsultarBorrador()
        {
            InitializeComponent();

            dgBorrador.ColumnCount = 5;
            dgBorrador.Columns[0].Name = "Nombre del borrador";
            dgBorrador.Columns[1].Name = "Nombre del cliente";
            dgBorrador.Columns[2].Name = "Apellidos del cliente";
            dgBorrador.Columns[3].Name = "Dni";
            dgBorrador.Columns[4].Name = "id";
            dgBorrador.Columns[4].Visible = false;

            dgBorrador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Fill();

        }

        private void dgBorrador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void Fill()
        {
            dgBorrador.Rows.Clear();
            dgBorrador.Refresh();

            string nombre = "";
            string apellido = "";
            string dni = "";

            contratoPlantilla = ContratoPlantilla.consultar();
            ContratoPlantilla c;
            Cliente cCliente = null;
            for (int i = 0; i < contratoPlantilla.Count; i++)
            {

                c = (ContratoPlantilla)contratoPlantilla[i];
                Nullable<int> id = c.getIdCliente();

                if (id.GetValueOrDefault(0) != 0)
                {
                    cCliente = new Cliente(c.getIdCliente());
                    nombre = cCliente.getNombre();
                    apellido = cCliente.getApellido();
                    dni = cCliente.getDni();
                }
                else
                {
                    nombre = apellido = dni = "";
                }

                String[] row = { c.getNombreBorrador(), nombre, apellido, dni,c.Id.ToString() };
                dgBorrador.Rows.Add(row);
            }
        }

        private void bConsultar_Click(object sender, EventArgs e)
        {
            dgBorrador.Rows.Clear();
            dgBorrador.Refresh();

            string nombre = "";
            string apellido = "";
            string dni = "";

            contratoPlantilla = ContratoPlantilla.consultar(tNombreBorrador.Text);
            ContratoPlantilla c;
            Cliente cCliente = null;
            for (int i = 0; i < contratoPlantilla.Count; i++)
            {

                c = (ContratoPlantilla)contratoPlantilla[i];
                Nullable<int> id = c.getIdCliente();

                if (id.GetValueOrDefault(0) != 0)
                {
                    cCliente = new Cliente(c.getIdCliente());
                    nombre = cCliente.getNombre();
                    apellido = cCliente.getApellido();
                    dni = cCliente.getDni();
                }
                else
                {
                    nombre = apellido = dni = "";
                }

                String[] row = { c.getNombreBorrador(), nombre, apellido, dni };
                dgBorrador.Rows.Add(row);
            }
        }
        private void DgBorrador_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CpPlantilla = new ContratoPlantilla(Convert.ToInt32(dgBorrador[4,e.RowIndex].Value));

            CrearContrato crearContrato = new CrearContrato(CpPlantilla);
            crearContrato.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            crearContrato.TopLevel = false;
            crearContrato.AutoScroll = true;
            Data.f1.pPanelBig.Controls.Add(crearContrato);
            crearContrato.Show();
            this.Close();

        }

        private void ConsultarBorrador_Load(object sender, EventArgs e)
        {

        }

        private void DgBorrador_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CpPlantilla = new ContratoPlantilla(Convert.ToInt32(dgBorrador[4, e.RowIndex].Value));

            CrearContrato crearContrato = new CrearContrato(CpPlantilla);
            crearContrato.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            crearContrato.TopLevel = false;
            crearContrato.AutoScroll = true;
            Data.f1.pPanelBig.Controls.Add(crearContrato);
            crearContrato.Show();
            this.Close();

        }

        private void DgBorrador_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgBorrador.SelectedRows[0].Index != -1 && e.KeyCode == Keys.Delete)
            {
                ContratoPlantilla cpPlantilla = (ContratoPlantilla)contratoPlantilla[dgBorrador.SelectedRows[0].Index];

                if (MessageBox.Show("¿Desea eliminar la plantilla seleccionada?", "Confirmación de eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        ContratoPlantilla.delete(cpPlantilla.Id);
                        MessageBox.Show("Plantilla eliminada satisfactoriamente.");

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
