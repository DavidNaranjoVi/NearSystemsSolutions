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
    class ElementoPlantilla
    {
        private ArrayList id = new ArrayList();
        private int id_plantillaContrato;
        private ArrayList id_elemento = new ArrayList();
        private ArrayList cantidad = new ArrayList();

       static DBSesion db = null;

        public ArrayList Id { get => id; set => id = value; }
        public int Id_plantillaContrato { get => id_plantillaContrato; set => id_plantillaContrato = value; }
        public ArrayList Id_elemento { get => id_elemento; set => id_elemento = value; }
        public ArrayList Cantidad { get => cantidad; set => cantidad = value; }

        public ElementoPlantilla(int iIdPlantilla)
        {
            try
            {

                Id_plantillaContrato = iIdPlantilla;

                db = new DBSesion();
                db.abrirConexion();

                String sSql = "select * from plantillaelemento where id_plantillaContrato = " + iIdPlantilla;
                MySqlDataReader myReader = db.consultar(sSql);

                while (myReader.Read())
                {
                    if (!myReader.IsDBNull(0)) Id.Add(myReader.GetInt32("id"));
                    if (!myReader.IsDBNull(2)) Id_elemento.Add(myReader.GetInt32("id_elemento"));
                    if (!myReader.IsDBNull(3)) Cantidad.Add(myReader.GetInt32("cantidad"));
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static ElementoPlantilla create(int idContratoPlantilla,int iIdElemento,int iCantidad) {

            db = new DBSesion();
            
            try
            {
                db.abrirConexion();
                string sSql="";

                
                    int idElemento;
                    sSql = "insert into plantillaelemento (id_plantillaContrato,id_elemento,cantidad) VALUES ("
                            + idContratoPlantilla + ","+iIdElemento+","+
                            iCantidad+ ");SELECT LAST_INSERT_ID()";
                
        

                int iId = db.insertar(sSql);

                db.cerrarConexion();

                return new ElementoPlantilla(idContratoPlantilla);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void delete(int iIdPlantilla)
        {
            try
            {


                db = new DBSesion();
                db.abrirConexion();
                db.consultar("DELETE FROM `plantillaelemento` WHERE `id_plantillaContrato` = " + iIdPlantilla);
                db.cerrarConexion();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
