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
    class ListaContactos
    {

        private int _iId;
        private int _iIdAbonado;
        private string _usuario;
        private string _nombre;
        private string _telefono1;
        private string _telefono2;
        private string _consignaIndividual;

        private static DBSesion db = null;

        public ListaContactos(int iId)
        {
            try {

                db = new DBSesion();
                db.abrirConexion();

                string sSql = "select * from listacontactos where id = " + iId;

                MySqlDataReader myReader = db.consultar(sSql);

                if (myReader.Read())
                {
                    if (!myReader.IsDBNull(1)) _iIdAbonado = myReader.GetInt32("id_fichaAbonado");
                    else new Exception("Fallo lectura del id abonado.");

                    if (!myReader.IsDBNull(2)) _usuario = myReader.GetString("usuario");
                    else new Exception("Fallo lectura del usuario.");

                    if (!myReader.IsDBNull(3)) _nombre = myReader.GetString("nombre");
                    else new Exception("Fallo lectura del nombre.");

                    if (!myReader.IsDBNull(4)) _telefono1 = myReader.GetString("telefono1");
                    else new Exception("Fallo lectura del telefono 1.");

                    if (!myReader.IsDBNull(5)) _telefono2 = myReader.GetString("telefono2");

                    if (!myReader.IsDBNull(6)) _consignaIndividual = myReader.GetString("consignaIndividual");

                    _iId = iId;

                    db.cerrarConexion();
                }
                else
                {
                    new Exception("Fallo en la consulta del contacto.");
                }
           
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



        static public ListaContactos create(int iIdAbonado,string usuario,string nombre,string telefono1,string telefono2,
                                    string consignaIndividual)
        {
            try {

                db = new DBSesion();
                db.abrirConexion();

                string sSql = "insert into listacontactos (id_fichaAbonado,usuario,nombre," +
                    "telefono1,telefono2,consignaIndividual) VALUES ("
                    + iIdAbonado + ","
                    + Data.String2Sql(usuario, true, false) + ","
                    + Data.String2Sql(nombre, true, false) + ","
                    + Data.String2Sql(telefono1, true, false) + ","
                    + Data.String2Sql(telefono2, true, false) + ","
                    + Data.String2Sql(consignaIndividual, true, false) + ");SELECT LAST_INSERT_ID()";

                int id = db.insertar(sSql);

                db.cerrarConexion();

                return new ListaContactos(id);

            } catch(Exception ex)
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
                        sSql = "DELETE FROM `listacontactos` WHERE id_fichaAbonado = " + iId;
                        break;

                    case 2:
                        sSql = "DELETE FROM `listacontactos` WHERE id = " + iId;
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

        public static ListaContactos update(int iId,int iIdFichaAbonado,string usuario,string nombre,string telefono1,string telefono2,string consignaIndividual)
        {
            try
            {

                string sSql = "UPDATE `listacontactos` SET " +
                    "`id_fichaAbonado`=" + iIdFichaAbonado + "," +
                    "`usuario`=" + Data.String2Sql(usuario, true, false) + "," +
                    "`nombre`=" + Data.String2Sql(nombre, true, false) + "," +
                    "`telefono1`=" + Data.String2Sql(telefono1, true, false) + "," +
                    "`telefono2`=" + Data.String2Sql(telefono2, true, false) + "," +
                    "`consignaIndividual`=" + Data.String2Sql(consignaIndividual, true, false) +
                    "WHERE id = " + iId;

                db = new DBSesion();

                db.abrirConexion();
                db.actualizar(sSql);
                db.cerrarConexion();

                return new ListaContactos(iId);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int IId { get => _iId; set => _iId = value; }
        public int IIdAbonado { get => _iIdAbonado; set => _iIdAbonado = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Telefono1 { get => _telefono1; set => _telefono1 = value; }
        public string Telefono2 { get => _telefono2; set => _telefono2 = value; }
        public string ConsignaIndividual { get => _consignaIndividual; set => _consignaIndividual = value; }


    }
}
