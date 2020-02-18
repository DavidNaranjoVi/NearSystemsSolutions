using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NearSystemsSolutions
{
   public class TestZonas
    {
        private int _iId;
        private int _iIdFichaMantenimiento;
        private int _iIdZona;
        private bool _bSabotaje;
        private bool _bCobertura;
        private bool _bBateria;

       static DBSesion db = null;

        public int IId { get => _iId; set => _iId = value; }
        public int IIdZona { get => _iIdZona; set => _iIdZona = value; }
        public bool BSabotaje { get => _bSabotaje; set => _bSabotaje = value; }
        public bool BCobertura { get => _bCobertura; set => _bCobertura = value; }
        public bool BBateria { get => _bBateria; set => _bBateria = value; }

        public TestZonas(int iId)
        {
            try
            {

                db = new DBSesion();
                db.abrirConexion();

                string sSql = "select * from test where id = " + iId;

                MySqlDataReader myReader = db.consultar(sSql);

                if (myReader.Read())
                {
                    if (!myReader.IsDBNull(1)) IIdZona = myReader.GetInt32("id_Zona");
                    else throw new Exception("Fallo en la asignacion de la zona.");

                    if (!myReader.IsDBNull(2)) BSabotaje = myReader.GetBoolean("sabotaje");
                    else throw new Exception("Fallo en la asignación del test de sabotaje.");

                    if (!myReader.IsDBNull(3)) BCobertura = myReader.GetBoolean("cobertura");
                    else throw new Exception("Fallo en la asignación del test de cobertura.");

                    if (!myReader.IsDBNull(4)) BBateria = myReader.GetBoolean("bateria");
                    else throw new Exception("Fallo en la asignación del test de bateria.");

                    IId = iId;
                }
                else
                {
                    throw new Exception("Fallo en la consulta del test de zonas.");
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static TestZonas create(int iIdFichaMantenimiento,int iIdZona,bool bSabotaje,bool bCobertura,bool bBateria)
        {
            try
            {
                //ERROR TEST
                db = new DBSesion();

                string sSql = "INSERT INTO `test`" +
                    "(`id_FichaMantenimiento`,`id_Zona`, `sabotaje`, `cobertura`, `bateria`) " +
                    "VALUES " +
                    "(" +iIdFichaMantenimiento+","
                    + iIdZona + "," +
                    bSabotaje + "," +
                    bCobertura + "," +
                    bBateria + ");SELECT LAST_INSERT_ID()";

                db.abrirConexion();
                int iId = db.insertar(sSql);
                db.cerrarConexion();

                return new TestZonas(iId);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
