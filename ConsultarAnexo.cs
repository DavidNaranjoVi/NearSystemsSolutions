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
    public partial class ConsultarAnexo : Form
    {

        Anexo aAnexo = null;

        public ConsultarAnexo()
        {
            InitializeComponent();

            dgAnexos.ColumnCount = 4;
            dgAnexos.Columns[0].Name = "Número anexo";
            dgAnexos.Columns[1].Name = "Nombre de anexo";
            dgAnexos.Columns[2].Name = "Razón social";
            dgAnexos.Columns[3].Name = "id";
            dgAnexos.Columns[3].Visible = false;

           dgAnexos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Fill();
        }

        internal Anexo AAnexo { get => aAnexo; set => aAnexo = value; }

        public void Fill()
        {
            ArrayList aAnexos = Anexo.consultar();

            for(int i = 0; i < aAnexos.Count; i++)
            {
                Anexo a = (Anexo)aAnexos[i];
                String[] row = { "Anexo "+a.SNumeroAnexo, a.SNombre, a.SRazonSocial, a.IId.ToString()};

                dgAnexos.Rows.Add(row);
            }
        }

        private void ConsultarAnexo_Load(object sender, EventArgs e)
        {

        }

        private void DgAnexos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AAnexo = new Anexo(Convert.ToInt32(dgAnexos[3, e.RowIndex].Value));
            CrearAnexo crearAnexo = new CrearAnexo(AAnexo);
            crearAnexo.TopLevel = false;
            crearAnexo.AutoScroll = true;

            Data.f1.pPanelBig.Controls.Add(crearAnexo);

            crearAnexo.Show();
            this.Close();
        }
    }
}
