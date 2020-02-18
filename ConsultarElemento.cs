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
    public partial class ConsultarElemento : Form
    {
        ArrayList eElemento = new ArrayList();
        public ConsultarElemento()
        {
            InitializeComponent();
            ajustarPantalla();
            dgElementos.ColumnCount = 4;
            dgElementos.Columns[0].Name = "Nombre";
            dgElementos.Columns[1].Name = "Código";
            dgElementos.Columns[2].Name = "Descripcion";
            dgElementos.Columns[3].Name = "id";
            dgElementos.Columns[3].Visible = false;

            dgElementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgElementos.ForeColor = Color.Black;

            Fill();
        }

        public void ajustarPantalla()
        {
            tableLayoutPanel1.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.83), (int)(Screen.PrimaryScreen.Bounds.Height * 0.8));
            ajustarMenu(tableLayoutPanel1);
            dgElementos.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.8), (int)(Screen.PrimaryScreen.Bounds.Height * 0.77));
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
            try
            {
                dgElementos.Rows.Clear();
                dgElementos.Refresh();

                eElemento = Elemento.consultar();
                Elemento e;

                for (int i = 0; i < eElemento.Count; i++)
                {
                    e = (Elemento)eElemento[i];
                    String[] row = { e.SNombre, e.SCodigo, e.SDescripcion,e.IId.ToString()};
                    dgElementos.Rows.Add(row);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de consultas",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Fill(String codigo, String nombre, String descripcion)
        {
            try
            {
                dgElementos.Rows.Clear();
                dgElementos.Refresh();

                eElemento = Elemento.consultar(codigo,nombre,descripcion);
                Elemento e;

                for (int i = 0; i < eElemento.Count; i++)
                {
                    e = (Elemento)eElemento[i];
                    String[] row = { e.SNombre, e.SCodigo, e.SDescripcion,e.IId.ToString() };
                    dgElementos.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de consultas",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bConsultar_Click(object sender, EventArgs e)
        {
            Fill(tCodigo.Text, tNombre.Text, tDescripcion.Text);
        }

        private void dgElementos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Elemento element = (Elemento)eElemento[e.RowIndex];
            ActualizarElemento form11 = new ActualizarElemento(element.IId, element.SCodigo, element.SNombre, element.SDescripcion);
            form11.ShowDialog();

            Fill(tCodigo.Text, tNombre.Text, tDescripcion.Text);*/
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void BActualizar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgElementos.RowCount; i++)
                Elemento.error_test(dgElementos[0, i].Value.ToString(), dgElementos[1, i].Value.ToString(), dgElementos[2, i].Value.ToString());

                for (int i = 0; i < dgElementos.RowCount; i++)
            {
                Elemento.actualizar(
                    Convert.ToInt32(dgElementos[3, i].Value),
                    dgElementos[1, i].Value.ToString(),
                    dgElementos[0, i].Value.ToString(),
                    dgElementos[2, i].Value.ToString()
                    );
            }
            MessageBox.Show("Todos los elementos están actualizados.");
            Fill();
        }

        private void DgElementos_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void DgElementos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Elemento element = (Elemento)eElemento[e.RowIndex];
            ActualizarElemento form11 = new ActualizarElemento(element.IId, element.SCodigo, element.SNombre, element.SDescripcion);
            form11.ShowDialog();

            Fill(tCodigo.Text, tNombre.Text, tDescripcion.Text);
        }

        private void DgElementos_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void DgElementos_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgElementos.SelectedRows[0].Index != -1 && e.KeyCode == Keys.Delete)
            {
                Elemento element = (Elemento)eElemento[dgElementos.SelectedRows[0].Index];

                if (MessageBox.Show("¿Desea eliminar el elemento seleccionado? Se eliminará de los contratos, borradores, etc...", "Confirmación de eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Elemento.delete(element.IId);
                        MessageBox.Show("Elemento eliminado satisfactoriamente.");

                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
    }
}
