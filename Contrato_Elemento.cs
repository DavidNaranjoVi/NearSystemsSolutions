using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearSystemsSolutions
{
    class Contrato_Elemento
    {
        static DBSesion db = new DBSesion();

        private ArrayList _aId = new ArrayList();
        private int _iIdContrato;
        private ArrayList _aIdElementos = new ArrayList();
        private ArrayList _aCantidad = new ArrayList();

        public Contrato_Elemento(int iIdContrato) {

            try
            {

                db = new DBSesion();
                db.abrirConexion();

                String sSql = "select * from contrato_elemento Where id_contrato = " + iIdContrato;

                MySqlDataReader myReader = db.consultar(sSql);

                while (myReader.Read())
                {
                    AId.Add ( myReader.GetInt32("id"));
                    AIdElementos.Add ( myReader.GetInt32("id_elemento"));
                    ACantidad.Add( myReader.GetInt32("cantidad"));
                    IIdContrato = myReader.GetInt32("id_contrato");
                }

                db.cerrarConexion();

            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public ArrayList AId { get => _aId; set => _aId = value; }
        public int IIdContrato { get => _iIdContrato; set => _iIdContrato = value; }
        public ArrayList AIdElementos { get => _aIdElementos; set => _aIdElementos = value; }
        public ArrayList ACantidad { get => _aCantidad; set => _aCantidad = value; }

        public static Contrato_Elemento create(int iIdContrato,ArrayList aIdElementos,ArrayList aCantidad)
        {
            try
            {
                db = new DBSesion();


                for(int i = 0; i < aIdElementos.Count; i++)
                {
                    db.abrirConexion();
                    int iIdElemento = Convert.ToInt32((String)aIdElementos[i]);
                    int iCantidad = Convert.ToInt32((String)aCantidad[i]);

                    String sSql = "INSERT INTO `contrato_elemento`" +
                        "(`id_contrato`, `id_elemento`, `cantidad`) " +
                        "VALUES (" +
                        iIdContrato + "," +
                        iIdElemento + "," +
                        iCantidad + ");SELECT LAST_INSERT_ID()";

                    db.insertar(sSql);
                    db.cerrarConexion();
                }



            }catch(Exception ex)
            {
                throw ex;
            }
            return new Contrato_Elemento(iIdContrato);
        }

        public static bool delete(int iIdContrato)
        {
            try
            {
                String sSql = "DELETE FROM `contrato_elemento` WHERE id_contrato = " + iIdContrato;

                db = new DBSesion();
                db.abrirConexion();

                db.eliminar(sSql);

                db.cerrarConexion();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
