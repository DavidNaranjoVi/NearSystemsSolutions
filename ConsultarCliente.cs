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
    public partial class ConsultarCliente : Form
    {
        ArrayList aClientes = new ArrayList();
        DataGridView dataCLiente = null;
        Cliente c = null;
        Empresa eEmpresa = null;
        int op;

        internal Empresa EEmpresa { get => eEmpresa; set => eEmpresa = value; }
        public Cliente C { get => c; set => c = value; }

        public Cliente cliente() { return C; }

        public ConsultarCliente(int op = 1)
        {
            InitializeComponent();

            this.op = op;

            dataCliente.ColumnCount = 7;
            dataCliente.Columns[0].Name = "Nombre";
            dataCliente.Columns[1].Name = "Apellido";
            dataCliente.Columns[2].Name = "Dni";
            dataCliente.Columns[3].Name = "Tipo de cliente";
            dataCliente.Columns[4].Name = "Cif";
            dataCliente.Columns[5].Name = "id";
            dataCliente.Columns[5].Visible = false;
            dataCliente.Columns[6].Name = "id_empresa";
            dataCliente.Columns[6].Visible = false;

            dataCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ajustarPantalla();
            Fill();
        }

        public void ajustarPantalla()
        {
            tableLayoutPanel1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width- Screen.PrimaryScreen.Bounds.Width*0.30), Screen.PrimaryScreen.Bounds.Height - (int)(Screen.PrimaryScreen.Bounds.Height * 0.21));
            dataCliente.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width*0.50), (int)(Screen.PrimaryScreen.Bounds.Height*0.6));
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

        public void Fill()
        {

            dataCliente.Rows.Clear();
            dataCliente.Refresh();

            aClientes = NearSystemsSolutions.Cliente.consultar();
            Cliente c;

            for (int i = 0; i < aClientes.Count; i++)
            {
                string s = "";
                c = (Cliente)aClientes[i];

                if (c.getTipoCliente().Equals("Empresa"))
                {
                    for (int j = 0; j < c.EEmpresa.Count; j++)
                    {
                        Empresa e = (Empresa)c.EEmpresa[j];
                        String[] row = { c.getNombre(), c.getApellido(), c.getDni(), c.getTipoCliente(), e.SCif,c.getId().ToString(),e.IId.ToString() };
                        dataCliente.Rows.Add(row);
                    }
                }
                else
                {
                    String[] row = { c.getNombre(), c.getApellido(), c.getDni(), c.getTipoCliente(), "No consta" ,c.getId().ToString(),"No consta"};
                    dataCliente.Rows.Add(row);
                }
            }
        }

        public void Fill(String sNombre, String sApellido, String sDni, String sTipoCliente, String sCif)
        {
            try
            {
                dataCliente.Rows.Clear();
                dataCliente.Refresh();

                aClientes = NearSystemsSolutions.Cliente.consultar(sNombre, sApellido, sDni, sTipoCliente, sCif);
                Cliente c;

                for (int i = 0; i < aClientes.Count; i++)
                {
                    string s = "";

                    c = (Cliente)aClientes[i];

                    if (c.getTipoCliente().Equals("Empresa"))
                    {
                        for (int j = 0; j < c.EEmpresa.Count; j++)
                        {
                            Empresa e = (Empresa)c.EEmpresa[j];

                            String[] row = { c.getNombre(), c.getApellido(), c.getDni(), c.getTipoCliente(), e.SCif, c.getId().ToString(), e.IId.ToString() };
                            dataCliente.Rows.Add(row);
                        }
                    }
                    else
                    {
                        String[] row = { c.getNombre(), c.getApellido(), c.getDni(), c.getTipoCliente(), "No consta", c.getId().ToString(), "No consta" };
                        dataCliente.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ConsultarCliente_Load(object sender, EventArgs e)
        {

        }

        private void BConsultar_Click(object sender, EventArgs e)
        {
            Fill(tNombre.Text, tApellido.Text, tDni.Text, cbTipoCliente.Text, tCif.Text);
        }

        private void DataCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row;

            switch (op) {
                case 1:
                 row = e.RowIndex;
            CrearCliente crearCliente;

            if (!dataCliente[6, row].Value.Equals("No consta"))
            {
                crearCliente = new CrearCliente(Convert.ToInt32(dataCliente[5, row].Value), Convert.ToInt32(dataCliente[6, row].Value), true);

            }
            else
            {
                crearCliente = new CrearCliente(Convert.ToInt32(dataCliente[5, row].Value), 0, true);

            }


            mostrar(crearCliente);
                    this.Close();
            break;
                case 2:
                    row = e.RowIndex;
                    C = new Cliente(Convert.ToInt32(dataCliente[5, row].Value));
                    if(C.getTipoCliente().Equals("Empresa") )EEmpresa = new Empresa(Convert.ToInt32(dataCliente[6, row].Value));
                    this.Close();
                    break;

            }
        }

        public static void mostrar(CrearCliente c)
        {
            c.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
            c.TopLevel = false;
            c.AutoScroll = true;
            Data.f1.pPanelBig.Controls.Add(c);
            c.Show();

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataCliente_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row;

            switch (op)
            {
                case 1:
                    row = e.RowIndex;
                    CrearCliente crearCliente;

                    if (!dataCliente[6, row].Value.Equals("No consta"))
                    {
                        crearCliente = new CrearCliente(Convert.ToInt32(dataCliente[5, row].Value), Convert.ToInt32(dataCliente[6, row].Value), true);

                    }
                    else
                    {
                        crearCliente = new CrearCliente(Convert.ToInt32(dataCliente[5, row].Value), 0, true);

                    }


                    mostrar(crearCliente);
                    this.Close();
                    break;
                case 2:
                    row = e.RowIndex;
                    C = new Cliente(Convert.ToInt32(dataCliente[5, row].Value));
                    if (C.getTipoCliente().Equals("Empresa")) EEmpresa = new Empresa(Convert.ToInt32(dataCliente[6, row].Value));
                    this.Close();
                    break;

            }
        }

        private void DataCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataCliente.SelectedRows[0].Index != -1 && e.KeyCode == Keys.Delete)
            {
                Cliente fmFicha = (Cliente)aClientes[dataCliente.SelectedRows[0].Index];

                if (MessageBox.Show("¿Desea eliminar el cliente seleccionado? Se eliminará la empresa, contratos, etc...", "Confirmación de eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (!dataCliente[4, dataCliente.SelectedRows[0].Index].Equals("No consta"))
                        {
                            Empresa.delete(Convert.ToInt32(dataCliente[6, dataCliente.SelectedRows[0].Index]));
                            MessageBox.Show("Empresa del cliente eliminada satisfactoriamente.");
                        }
                        else
                        {
                            //Cliente.delete(Convert.ToInt32(dataCliente[5, dataCliente.SelectedRows[0].Index]));
                            MessageBox.Show("Cliente eliminado satisfactoriamente.");
                            //AQUI seguir
                        }

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
