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
    public partial class NombreBorrador : Form
    {
        int id;
        int id_empresa;
        string tNAbonado;
        string tNContrato;
        string tFechaContrato;
        bool cbInstalacion;
        bool cbMantenimiento;
        string tFechaVigor;
        int duracion;
        double tInstalacion;
        string tFPInstalacion;
        double tMantenimiento;
        string tFPMantenimiento;
        string tLugar;
        string tCalle;
        string tCp;
        string tPoblacion;
        string tProvincia;
        string tPersonaContacto;
        string tTelefono;
        bool cRobo;
        bool cCctv;
        string tRelacionElementos;
        bool cInstalar;
        bool cMantener;
        bool cbCustodia;
        string cbIban;
        int id_anexo;
        string mensualidad;
        string tFechaVisado;
        string tCC;
        string tCS;

        ContratoPlantilla contratoPlantilla = null;

        public ContratoPlantilla ContratoPlantilla { get => contratoPlantilla; set => contratoPlantilla = value; }
        public string TFechaVisado { get => tFechaVisado; set => tFechaVisado = value; }
        public string TCC { get => tCC; set => tCC = value; }
        public string TCS { get => tCS; set => tCS = value; }

        public NombreBorrador(int id,int id_empresa, string tNAbonado,string tNContrato, string tFechaContrato, bool cbInstalacion,
                    bool cbMantenimiento, string tFechaVigor, int duracion,
                    double tInstalacion, string tFPInstalacion, double tMantenimiento,
                    string tFPMantenimiento,string mensualidad, string tLugar, string tCalle, string tCp, string tPoblacion,
                    string tProvincia, string tPersonaContacto, string tTelefono, bool cRobo, bool cCctv, string tRelacionElementos, bool cInstalar,
                    bool cMantener, bool cbCustodia, string cbIban,int id_anexo, string tFechaVisado,string  tCC, string tCS)
        {
            InitializeComponent();

            this.id = id;
            this.id_empresa = id_empresa;
            this.tNAbonado = tNAbonado;
            this.tNContrato = tNContrato;
            this.tFechaContrato = tFechaContrato;
            this.cbInstalacion = cbInstalacion;
            this.cbMantenimiento = cbMantenimiento;
            this.tFechaVigor = tFechaVigor;
            this.duracion = duracion;
            this.tInstalacion = tInstalacion;
            this.tFPInstalacion = tFPInstalacion;
            this.tMantenimiento = tMantenimiento;
            this.tFPMantenimiento = tFPMantenimiento;
            this.tLugar = tLugar;
            this.tCalle = tCalle;
            this.tCp = tCp;
            this.tPoblacion = tPoblacion;
            this.tProvincia = tProvincia;
            this.tPersonaContacto = tPersonaContacto;
            this.tTelefono = tTelefono;
            this.cRobo = cRobo;
            this.cCctv = cCctv;
            this.tRelacionElementos = tRelacionElementos;
            this.cInstalar = cInstalar;
            this.cMantener = cMantener;
            this.cbCustodia = cbCustodia;
            this.cbIban = cbIban;
            this.id_anexo = id_anexo;
            this.mensualidad = mensualidad;
            this.tFechaVisado = tFechaVisado;
            this.tCC = tCC;
            this.tCS = tCS;

        }

        private void BAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {

                

                ContratoPlantilla = ContratoPlantilla.create(id,id_empresa, tNombrePlantilla.Text, tNAbonado,tNContrato, tFechaContrato, cbInstalacion, cbMantenimiento, tFechaVigor, 12,
                   Convert.ToDouble(tInstalacion), tFPInstalacion, Convert.ToDouble(tMantenimiento), tFPMantenimiento,mensualidad, tLugar, tCalle, tCp, tPoblacion,
                   tProvincia, tPersonaContacto, tTelefono, cRobo, cCctv, tRelacionElementos, cInstalar,
                   cMantener, cbCustodia, cbIban,id_anexo, tFechaVisado, tCC, tCS);

                MessageBox.Show("Plantilla guardada.", "Operación realizada correctamente");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de formulario",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NombreBorrador_Load(object sender, EventArgs e)
        {

        }
    }
}
