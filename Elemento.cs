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
    class Elemento
    {

        private int _iId;
        private string _sNombre;
        private string _sCodigo;
        private string _sDescripcion;

        private static DBSesion db = null;

        public int IId { get => _iId; set => _iId = value; }
        public string SNombre { get => _sNombre; set => _sNombre = value; }
        public string SCodigo { get => _sCodigo; set => _sCodigo = value; }
        public string SDescripcion { get => _sDescripcion; set => _sDescripcion = value; }

        public Elemento(int iId)
        {


            try
            {
                db = new DBSesion();
                db.abrirConexion();
                string sSql = "select * from elemento where id = " + iId;

                MySqlDataReader myReader = db.consultar(sSql);
                if (myReader.Read())
                {

                    if(!myReader.IsDBNull(1))SNombre = myReader.GetString("nombre");
                    if (!myReader.IsDBNull(2)) SCodigo = myReader.GetString("codigo");
                    if (!myReader.IsDBNull(3)) SDescripcion = myReader.GetString("descripcion");

                    IId = iId;
                }
                db.cerrarConexion();
                

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public static Elemento create(string sNombre, string sCodigo,string sDescripcion)
        {
            error_test(sNombre, sCodigo, sDescripcion);

            db = new DBSesion();

            string sSql = "insert into elemento (nombre,codigo,descripcion) values ("
                          + Data.String2Sql(sNombre, true, false) + ","
                          + Data.String2Sql(sCodigo, true, false) + ","
                          + Data.String2Sql(sDescripcion, true, false) + ");SELECT LAST_INSERT_ID()";

            try
            {
               db.abrirConexion();

               int iId = db.insertar(sSql);

               db.cerrarConexion();

               return new Elemento(iId);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public static void error_test(string sNombre,string sCodigo,string sDescripcion)
        {
            if (sNombre.Equals("")) throw new Exception("El nombre de unos elementos es nulo. Por favor revise el formulario.");
        }

        public static ArrayList consultar()
        {
            try
            {
                db = new DBSesion();

                db.abrirConexion();
                MySqlDataReader myReader = db.consultar("select * from elemento");

                ArrayList eElemento = new ArrayList();

                while (myReader.Read())
                {
                    eElemento.Add(new Elemento(myReader.GetInt32("id")));
                }

                db.cerrarConexion();

                return eElemento;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static ArrayList consultar(String sCodigo,String sNombre,String sDescripcion)
        {
            try
            {
                db = new DBSesion();

                db.abrirConexion();

                String sSql = "select * from elemento WHERE codigo like "
                               + Data.String2Sql(sCodigo, true, true,true) + " AND nombre like "
                               + Data.String2Sql(sNombre, true, true,true) + " AND descripcion like "
                               + Data.String2Sql(sDescripcion, true, true,true);
                Clipboard.SetText(sSql);
                               
                MySqlDataReader myReader = db.consultar(sSql);

                ArrayList eElemento = new ArrayList();

                while (myReader.Read())
                {
                    eElemento.Add(new Elemento(myReader.GetInt32("id")));
                }

                db.cerrarConexion();

                return eElemento;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void actualizar(int iId,string sCodigo,string sNombre,string sDescripcion)
        {
            try {

                db = new DBSesion();
                db.abrirConexion();

                String sSql = "UPDATE elemento SET nombre = "
                               + Data.String2Sql(sNombre, true, false,true) + ", codigo = "
                               + Data.String2Sql(sCodigo, true, false,true) + ", descripcion = "
                               + Data.String2Sql(sDescripcion, true, false,true)+" WHERE id = "
                               +iId;
                               

                db.actualizar(sSql);
                db.cerrarConexion();

            } catch(Exception ex) { throw ex; }
        }

        public static void delete(int iIdElemento)
        {
            try
            {

                db = new DBSesion();
                db.abrirConexion();

                string sSql = "DELETE FROM `contrato_elemento` WHERE `id_elemento` = " +  iIdElemento;
                db.eliminar(sSql);

                sSql = "DELETE FROM `plantillaelemento` WHERE id_elemento = " + iIdElemento;
                db.eliminar(sSql);

                sSql = "DELETE FROM `elemento` WHERE id = " + iIdElemento;
                db.eliminar(sSql);

                db.cerrarConexion();
                db = null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
