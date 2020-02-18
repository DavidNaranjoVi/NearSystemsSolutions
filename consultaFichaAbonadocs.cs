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
    public partial class consultaFichaAbonadocs : Form
    {
        private int op;
        FichaAbonado fichaAbonado = null;

        public FichaAbonado FichaAbonado { get => fichaAbonado; set => fichaAbonado = value; }

        public consultaFichaAbonadocs(int op = 1)
        {
            InitializeComponent();

            this.op = op;

            dgFicha.ColumnCount = 6;
            dgFicha.Columns[0].Name = "Número de abonado";
            dgFicha.Columns[1].Name = "Fecha de alta";
            dgFicha.Columns[2].Name = "Nombre";
            dgFicha.Columns[3].Name = "Localidad";
            dgFicha.Columns[4].Name = "Código postal";
            dgFicha.Columns[5].Name = "id";
            dgFicha.Columns[5].Visible = false;

            dgFicha.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Fill();

        }

        private void consultaFichaAbonadocs_Load(object sender, EventArgs e)
        {

        }

        public void Fill(string sNumeroAbonado = "", string sFechaAlta = "", string sNombre = ""
            ,string sLocalidad = "",string sCodigoPostal = "")
        {

            dgFicha.Rows.Clear();

            ArrayList f = new ArrayList(FichaAbonado.consultar(sNumeroAbonado,sFechaAlta,sNombre,sLocalidad,sCodigoPostal));

            for(int i = 0; i < f.Count; i++)
            {

                FichaAbonado aux = (FichaAbonado)f[i];

                string[] row =
                {
                    aux.SNAbonado,
                    aux.SFechaAlta,
                    aux.SNombreRazonSocial,
                    aux.SLocalidad,
                    aux.SCopo,
                    aux.IId.ToString()
                };

                dgFicha.Rows.Add(row);
            }

        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bConsultar_Click(object sender, EventArgs e)
        {
            Fill(tNAbonado.Text,tFechaAlta.Text,tNombre.Text,tLocalidad.Text,tCP.Text);
        }

        private void DgFicha_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (op)
            {
                case 1:

                    CrearFichaAbonado crearFicha = new CrearFichaAbonado(new FichaAbonado(Convert.ToInt32(dgFicha[5, e.RowIndex].Value)),2);
                    crearFicha.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height - 100);
                    crearFicha.TopLevel = false;
                    crearFicha.AutoScroll = true;
                    Data.f1.pPanelBig.Controls.Add(crearFicha);
                    crearFicha.Show();
                    this.Close();
                    break;

                case 2:
                    GenerarDocumento documentoFicha = new GenerarDocumento(new FichaAbonado(Convert.ToInt32(dgFicha[5, e.RowIndex].Value)));
                    break;

                case 3:

                    FichaAbonado = new FichaAbonado(Convert.ToInt32(dgFicha[5, e.RowIndex].Value));
                    this.Close();
                    break;

            }
        }
    }
}
