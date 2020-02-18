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
    public partial class AnadirPersonaContacto : Form
    {
        public AnadirPersonaContacto()
        {
            InitializeComponent();

            dgContactosIncluidos.ColumnCount = 5;
            dgContactosIncluidos.Columns[0].Name = "Usuario";
            dgContactosIncluidos.Columns[1].Name = "Nombre";
            dgContactosIncluidos.Columns[2].Name = "Teléfono 1";
            dgContactosIncluidos.Columns[3].Name = "Teléfono 2";
            dgContactosIncluidos.Columns[4].Name = "Consigna individual";

            dgContactosIncluidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void bAnadir_Click(object sender, EventArgs e)
        {
            string[] row = { tUsuario.Text, tNombre.Text, tTelefono1.Text, tTelefono2.Text, tConsigna.Text };

            dgContactosIncluidos.Rows.Add(row);

            tUsuario.Clear();
            tNombre.Clear();
            tTelefono1.Clear();
            tTelefono2.Clear();
            tConsigna.Clear();
        }

        private void bFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }
    }
}
