using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NearSystemsSolutions
{
    class Zona
    {
        private int _iId;
        private int _iIdAbonado;
        private string zona;
        private string area;
        private string descripcion;

        static private DBSesion db = null;

        public int IId { get => _iId; set => _iId = value; }
        public int IIdAbonado { get => _iIdAbonado; set => _iIdAbonado = value; }
        public string sZona { get => zona; set => zona = value; }
        public string Area { get => area; set => area = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public Zona(int iId)
        {
            try {
                db = new DBSesion();
                db.abrirConexion();

                MySqlDataReader myReader = db.consultar("select * from zona where id = " + iId);

                if (myReader.Read())
                {
                    if (!myReader.IsDBNull(1)) IIdAbonado = myReader.GetInt32("id_fichaAbonado");
                    else new Exception("Fallo en la consulta del id del abonado");

                    if (!myReader.IsDBNull(2)) zona = myReader.GetString("zona");
                    else new Exception("Fallo en la consulta de la zona.");

                    if (!myReader.IsDBNull(3)) Area = myReader.GetString("area");
                    else new Exception("Fallo en la consulta del area.");

                    if (!myReader.IsDBNull(4)) Descripcion = myReader.GetString("descripcion");
                    else new Exception("Fallo en la consulta de la descripcion.");

                    IId = iId;

                    db.cerrarConexion();
                }
                else
                {
                    new Exception("Fallo en la consulta de la zona.");
                }

            } catch(Exception ex) {
                throw ex;
            } 
        }

       static public Zona create(int iIdAbonado,string zona,string area,string descripcion)
        {

            try
            {
                db = new DBSesion();
                db.abrirConexion();

                string sSql = "insert into zona (`id_fichaAbonado`, `zona`, `area`, `descripcion`) values ("
                    + iIdAbonado + ","
                    + Data.String2Sql(zona, true, false) + ","
                    + Data.String2Sql(area, true, false) + ","
                    + Data.String2Sql(descripcion, true, false) + ");SELECT LAST_INSERT_ID()";

               int id =  db.insertar(sSql);

               db.cerrarConexion();

               return new Zona(id);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        
        }

        public static void delete(int iId,int op = 1)
        {
            try
            {
                string sSql="";
                switch (op)
                {
                    case 1:
                 sSql = "DELETE FROM `zona` WHERE id_fichaAbonado = " + iId;
                        break;

                    case 2:
                        sSql = "DELETE FROM `zona` WHERE id = " + iId;
                        break;
                }

                db = new DBSesion();
                db.abrirConexion();
                db.eliminar(sSql);
                db.cerrarConexion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static Zona update(int iId,int iIdFichaAbonado,string zona,string area,string descripcion)
        {
            try
            {

                string sSql = "UPDATE `zona` SET " +
                                "`id_fichaAbonado`=" + iIdFichaAbonado + "," +
                                 "`zona`=" + Data.String2Sql(zona, true, false) + "," +
                                 "`area`=" + Data.String2Sql(area, true, false) + "," +
                                 "`descripcion`=" + Data.String2Sql(descripcion, true, false) +
                                 "WHERE id = " + iId;

                db = new DBSesion();

                db.abrirConexion();
                db.actualizar(sSql);
                db.cerrarConexion();

                return new Zona(iId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
