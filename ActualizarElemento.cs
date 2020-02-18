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
    public partial class ActualizarElemento : Form
    {
        String sCodigo, sNombre, sDescripcion;
        int iId;

        private void bEditar_Click(object sender, EventArgs e)
        {
            bEditar.Visible = false;
            bActualizar.Visible = true;

            tNombre.ReadOnly = false;
            tCodigo.ReadOnly = false;
            tDescripcion.ReadOnly = false;

        }

        private void bActualizar_Click(object sender, EventArgs e)
        {
            try {

                Elemento.actualizar(iId, tCodigo.Text, tNombre.Text, tDescripcion.Text);


            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de formulario",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("El elemento se actualizó correctamente", "Operación realizada con éxito",
               MessageBoxButtons.OK, MessageBoxIcon.Information);

                bActualizar.Visible = false;
                bEditar.Visible = true;

                tNombre.ReadOnly = true;
                tCodigo.ReadOnly = true;
                tDescripcion.ReadOnly = true;
            }
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ActualizarElemento(int iId,String sCodigo, String sNombre, String sDescripcion)
        {
            InitializeComponent();
            bActualizar.Visible = false;
            this.sCodigo = sCodigo;
            this.sNombre = sNombre;
            this.sDescripcion = sDescripcion;
            this.iId = iId;

            tNombre.SelectedText = sNombre;
            tCodigo.SelectedText = sCodigo;
            tDescripcion.SelectedText = sDescripcion;
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
