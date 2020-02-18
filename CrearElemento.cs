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
    public partial class CrearElemento : Form
    {
        ArrayList aElementos = new ArrayList();

        public CrearElemento()
        {
            InitializeComponent();

            ajustarPantalla();

            dgElementos.ColumnCount = 4;
            dgElementos.Columns[0].Name = "Nombre";
            dgElementos.Columns[1].Name = "Código";
            dgElementos.Columns[2].Name = "Descripción";
            dgElementos.Columns[3].Name = "id";

            dgElementos.Columns[3].Visible = false;

            dgElementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

           aElementos = Elemento.consultar();

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
            for(int i = 0; i < aElementos.Count; i++) {

                Elemento e = (Elemento)aElementos[i];

                dgElementos.Rows.Add(

                    e.SNombre,
                    e.SCodigo,
                    e.SDescripcion,
                    e.IId.ToString()

                    );
                dgElementos.Rows[i].ReadOnly = true;

            }
                
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CrearElemento_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            for (int i = aElementos.Count; i < dgElementos.RowCount - 1; i++)
                Elemento.error_test(dgElementos[0, i].Value.ToString().ToUpper(),
                    (dgElementos[1, i].Value != null) ? dgElementos[1, i].Value.ToString().ToUpper() : "",
                    (dgElementos[2, i].Value != null) ? dgElementos[2, i].Value.ToString().ToUpper() : "");

            for (int i = aElementos.Count; i < dgElementos.RowCount - 1; i++)
            {         
               Elemento ele =  Elemento.create(dgElementos[0, i].Value.ToString().ToUpper(), 
                    (dgElementos[1, i].Value != null)?dgElementos[1,i].Value.ToString().ToUpper():"",
                    (dgElementos[2, i].Value != null) ? dgElementos[2, i].Value.ToString().ToUpper() : "");

                aElementos.Add(ele);
            }

            MessageBox.Show("Todos los elementos fueron añadidos correctamente.");

            dgElementos.Rows.Clear();
            Fill();
        }
    }
}
