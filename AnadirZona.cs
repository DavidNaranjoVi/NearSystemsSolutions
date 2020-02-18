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
    public partial class AnadirZona : Form
    {
        public AnadirZona(int n)
        {
            InitializeComponent();
            tZona.SelectedText = n.ToString().PadLeft(2,'0');

            dgZonasIncluidas.ColumnCount = 3;
            dgZonasIncluidas.Columns[0].Name = "Zona";
            dgZonasIncluidas.Columns[1].Name = "Area";
            dgZonasIncluidas.Columns[2].Name = "Descripcion de la zona";

            dgZonasIncluidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void bAnadir_Click(object sender, EventArgs e)
        {
            string[] row = { tZona.Text.PadLeft(2,'0'), tArea.Text.PadLeft(2,'0'), tDescripcion.Text };

            dgZonasIncluidas.Rows.Add(row);
            dgZonasIncluidas.Rows[dgZonasIncluidas.RowCount-1].ReadOnly = true;

            tZona.Clear();
            tArea.Clear();
            tDescripcion.Clear();

            tZona.SelectedText = (dgZonasIncluidas.Rows.Count).ToString().PadLeft(2,'0');

        }

        private void dgZonasIncluidas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgZonasIncluidas.Rows.RemoveAt(e.RowIndex);
        }

        private void bFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
