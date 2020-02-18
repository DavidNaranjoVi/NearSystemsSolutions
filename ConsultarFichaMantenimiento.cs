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
    public partial class ConsultarFichaMantenimiento : Form
    {
        ArrayList fichaMantenimiento = new ArrayList();
        int op = 1;

        public ConsultarFichaMantenimiento(int op = 1)
        {
            InitializeComponent();
            this.op = op;
            dgFichaMantenimiento.ColumnCount = 5;

            dgFichaMantenimiento.Columns[0].Name = "Parte de trabajo";
            dgFichaMantenimiento.Columns[1].Name = "Nombre o Razón social";
            dgFichaMantenimiento.Columns[2].Name = "Número de abonado";
            dgFichaMantenimiento.Columns[3].Name = "Fecha del parte";
            dgFichaMantenimiento.Columns[4].Name = "id";
            dgFichaMantenimiento.Columns[4].Visible = false;

            dgFichaMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            fichaMantenimiento = FichaMantenimiento.consultar();

            Fill();

        }

        public void Fill()
        {
            try
            {

                for (int i = 0; i < fichaMantenimiento.Count; i++)
                {
                    string[] row =
                    {
                        ((FichaMantenimiento)fichaMantenimiento[i]).SNumero,
                         new FichaAbonado(((FichaMantenimiento)fichaMantenimiento[i]).IIdFichaAbonado).SNombreRazonSocial,
                         new FichaAbonado(((FichaMantenimiento)fichaMantenimiento[i]).IIdFichaAbonado).SNAbonado,
                         ((FichaMantenimiento)fichaMantenimiento[i]).SFecha,
                         ((FichaMantenimiento)fichaMantenimiento[i]).IId.ToString()
                    };

                    dgFichaMantenimiento.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgFichaMantenimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (op)
            {

                case 1:

                    CrearFichaMantenimiento fichaMantenimiento = new CrearFichaMantenimiento(new FichaMantenimiento(Convert.ToInt32(dgFichaMantenimiento[4, e.RowIndex].Value)));

                    fichaMantenimiento.TopLevel = false;
                    fichaMantenimiento.AutoScroll = true;

                    Data.f1.pPanelBig.Controls.Add(fichaMantenimiento);
                    fichaMantenimiento.Show();

                    this.Close();
                    break;

                case 2:

                    GenerarDocumento generarDocumento = new GenerarDocumento(new FichaMantenimiento(Convert.ToInt32(dgFichaMantenimiento[4, e.RowIndex].Value)));
                    generarDocumento.TopLevel = false;
                    generarDocumento.AutoScroll = true;

                    Data.f1.pPanelBig.Controls.Add(generarDocumento);
                    generarDocumento.Show();
                    break;

            }

        }

        private void DgFichaMantenimiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (op)
            {

                case 1:

                    CrearFichaMantenimiento fichaMantenimiento = new CrearFichaMantenimiento(new FichaMantenimiento(Convert.ToInt32(dgFichaMantenimiento[4, e.RowIndex].Value)));

                    fichaMantenimiento.TopLevel = false;
                    fichaMantenimiento.AutoScroll = true;

                    Data.f1.pPanelBig.Controls.Add(fichaMantenimiento);
                    fichaMantenimiento.Show();

                    this.Close();
                    break;

                case 2:

                    GenerarDocumento generarDocumento = new GenerarDocumento(new FichaMantenimiento(Convert.ToInt32(dgFichaMantenimiento[4, e.RowIndex].Value)));
                    generarDocumento.TopLevel = false;
                    generarDocumento.AutoScroll = true;

                    Data.f1.pPanelBig.Controls.Add(generarDocumento);
                    generarDocumento.Show();
                    break;
            }
        }

        private void DgFichaMantenimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgFichaMantenimiento.SelectedRows[0].Index != -1 && e.KeyCode == Keys.Delete)
            {
                FichaMantenimiento fmFicha = (FichaMantenimiento)fichaMantenimiento[dgFichaMantenimiento.SelectedRows[0].Index];

                if (MessageBox.Show("¿Desea eliminar la ficha seleccionada? Se eliminarán todos los test, información, etc...", "Confirmación de eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        FichaMantenimiento.delete(fmFicha.IId);
                        MessageBox.Show("Ficha de mantenimiento eliminada satisfactoriamente.");

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