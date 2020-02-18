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
    public partial class elegirDocumento : Form
    {
        public elegirDocumento()
        {
            InitializeComponent();
        }

        private void BDocumentoContrato_Click(object sender, EventArgs e)
        {
            consultaContrato cc = new consultaContrato(true);
            cc.ShowDialog();
        }

        private void ElegirDocumento_Load(object sender, EventArgs e)
        {

        }

        private void BAbonado_Click(object sender, EventArgs e)
        {
            consultaFichaAbonadocs consultaFicha = new consultaFichaAbonadocs(2);
            consultaFicha.ShowDialog();
        }

        private void BMantenimiento_Click(object sender, EventArgs e)
        {
            ConsultarFichaMantenimiento consultarFicha = new ConsultarFichaMantenimiento(2);

            consultarFicha.TopLevel = false;
            consultarFicha.AutoScroll = true;

            Data.f1.pPanelBig.Controls.Add(consultarFicha);

            consultarFicha.Show();
            this.Close();

        }
    }
}
