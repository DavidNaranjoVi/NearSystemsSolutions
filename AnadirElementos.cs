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
    public partial class AnadirElementos : Form
    {
        ArrayList eElemento = Elemento.consultar();
        ArrayList eElementosIncluidos = new ArrayList();
        ArrayList vistaElementos = new ArrayList();

        bool acept = false;

        public bool Acept { get => acept; set => acept = value; }
        public ArrayList VistaElementos { get => vistaElementos; set => vistaElementos = value; }
        public ArrayList EElementosIncluidos { get => eElementosIncluidos; set => eElementosIncluidos = value; }
        public DataGridView ElementosIncluidos { get => dgIncluidos; }

        public AnadirElementos(DataGridView aIncluidos = null)
        {
            InitializeComponent();
            dgExistentes.ColumnCount = 4;
            dgExistentes.Columns[0].Name = "Nombre";
            dgExistentes.Columns[1].Name = "Código";
            dgExistentes.Columns[2].Name = "Descripción";
            dgExistentes.Columns[3].Name = "id";
            dgExistentes.Columns[3].Visible = false;

            dgIncluidos.ColumnCount = 4;
            dgIncluidos.Columns[0].Name = "Nombre";
            dgIncluidos.Columns[1].Name = "Código";
            dgIncluidos.Columns[2].Name = "Cantidad";
            dgIncluidos.Columns[3].Name = "id";
            dgIncluidos.Columns[3].Visible = false;

            dgExistentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgIncluidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (aIncluidos != null)
            {
                Fill_Incluidos(aIncluidos);
            }

            Fill();

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        public void Fill_Incluidos(DataGridView aIncluidos)
        {
            try{

               for(int i = 0; i < aIncluidos.Rows.Count -1; i++)
                {
                    dgIncluidos.Rows.Add(

                        aIncluidos[0, i].Value,
                        aIncluidos[1, i].Value,
                        aIncluidos[2, i].Value,
                        aIncluidos[3, i].Value

                        );
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Fill()
        {
            try { 
            dgExistentes.Rows.Clear();
            dgExistentes.Refresh();

            eElemento = Elemento.consultar();
            Elemento e;

            for (int i = 0; i < eElemento.Count; i++)
            {
                e = (Elemento)eElemento[i];
                String[] row = { e.SNombre, e.SCodigo, e.SDescripcion,e.IId.ToString() };
                dgExistentes.Rows.Add(row);
            }

        }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de consultas",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void dgExistentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Elemento ele = (Elemento)eElemento[e.RowIndex];

            if (!EElementosIncluidos.Contains(ele))
            {
                String[] row = { ele.SNombre, ele.SCodigo, "1" ,ele.IId.ToString()};
                dgIncluidos.Rows.Add(row);
                EElementosIncluidos.Add(ele);
            }
            else
            {

                for(int i = 0;i < dgIncluidos.RowCount -1; i++)
                {

                    if (dgIncluidos.Rows[i].Cells["id"].Value.ToString().Equals(ele.IId.ToString()))
                    {
                        
                        int cant = Convert.ToInt32(dgIncluidos.Rows[i].Cells["Cantidad"].Value.ToString())+1;
                        dgIncluidos.Rows[i].SetValues(ele.SNombre,ele.SCodigo,cant,ele.IId.ToString());
                        break;
                    }
                }
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {

            for(int i = 0;i < dgIncluidos.RowCount-1; i++)
            {
                vistaElementos.Add(
                    dgIncluidos.Rows[i].Cells["Nombre"].Value.ToString()+" - "+
                    dgIncluidos.Rows[i].Cells["Código"].Value.ToString()+" - "+
                    dgIncluidos.Rows[i].Cells["Cantidad"].Value.ToString()+"\n");
            }

            Acept = true;
            this.Close();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgExistentes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Elemento ele = (Elemento)eElemento[e.RowIndex];

            if (!EElementosIncluidos.Contains(ele))
            {
                String[] row = { ele.SNombre, ele.SCodigo, "1", ele.IId.ToString() };
                dgIncluidos.Rows.Add(row);
                EElementosIncluidos.Add(ele);
            }
            else
            {

                for (int i = 0; i < dgIncluidos.RowCount - 1; i++)
                {

                    if (dgIncluidos.Rows[i].Cells["id"].Value.ToString().Equals(ele.IId.ToString()))
                    {

                        int cant = Convert.ToInt32(dgIncluidos.Rows[i].Cells["Cantidad"].Value.ToString()) + 1;
                        dgIncluidos.Rows[i].SetValues(ele.SNombre, ele.SCodigo, cant, ele.IId.ToString());
                        break;
                    }
                }
            }
        }
    }
}
