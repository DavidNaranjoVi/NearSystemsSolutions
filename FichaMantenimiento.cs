using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearSystemsSolutions
{
    public class FichaMantenimiento
    {
        private int _iId;
        private int _iIdFichaAbonado;
        private FichaAbonado fichaAbonado = null;
        private string _sNumero;
        private string _sFecha;
        private string _sComentarios;

        static DBSesion db = null;

        public int IId { get => _iId; set => _iId = value; }
        public int IIdFichaAbonado { get => _iIdFichaAbonado; set => _iIdFichaAbonado = value; }
        public string SNumero { get => _sNumero; set => _sNumero = value; }
        public string SFecha { get => _sFecha; set => _sFecha = value; }
        public string SComentarios { get => _sComentarios; set => _sComentarios = value; }
        public FichaAbonado FichaAbonado { get => fichaAbonado; set => fichaAbonado = value; }

        public FichaMantenimiento(int iId)
        {
            try
            {

                db = new DBSesion();
                db.abrirConexion();

                string sSql = "select * from fichaMantenimiento where id = " + iId;

                MySqlDataReader myReader = db.consultar(sSql);

                if (myReader.Read())
                {
                    if (!myReader.IsDBNull(1)) IIdFichaAbonado = myReader.GetInt32("id_fichaAbonado");
                    else throw new Exception("No se ha podido cargar la ficha de abonado relacionada con el mantenimeinto.");

                    if (!myReader.IsDBNull(2)) SNumero = myReader.GetString("numero");
                    else throw new Exception("No se ha podido cargar el numero de la ficha de mantenimiento.");

                    if (!myReader.IsDBNull(3)) SFecha = myReader.GetString("fecha");
                    else throw new Exception("No se ha podido cargar la fecha de la ficha de mantenimiento.");

                    if (!myReader.IsDBNull(4)) SComentarios = myReader.GetString("comentarios");
                    else SComentarios = "";

                    IId = iId;

                    fichaAbonado = new FichaAbonado(IIdFichaAbonado);
                }
                else
                {
                    throw new Exception("Fallo de consulta de la ficha de mantenimiento.");
                }

                db.cerrarConexion();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static FichaMantenimiento create(int iIdAbonado,string sNumeroParte,string sFecha,string sComentarios)
        {
            try
            {
                //ERROR TEST

                db = new DBSesion();
                db.abrirConexion();

                string sSql = "INSERT INTO `fichamantenimiento`" +
                   "(`id_fichaAbonado`, `numero`, `fecha`, `comentarios`) " +
                   "VALUES " +
                   "("+iIdAbonado+"," +
                   Data.String2Sql(sNumeroParte,true,false)+"," +
                   Data.String2Sql(sFecha,true,false)+"," +
                   Data.String2Sql(sComentarios,true,false)+ ");SELECT LAST_INSERT_ID()";

                int iId = db.insertar(sSql);
                db.cerrarConexion();

                return new FichaMantenimiento(iId);


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static ArrayList consultar()
        {
            try
            {
                ArrayList aFichas = new ArrayList();

                string sSql = "select id from fichamantenimiento";

                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar(sSql);

                while (myReader.Read())
                {
                    if (!myReader.IsDBNull(0))
                        aFichas.Add(new FichaMantenimiento(myReader.GetInt32("id")));
                }

                return aFichas;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static int consultar_num()
        {
            try
            {

                string sSql = "select max(numero) from fichamantenimiento";

                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar(sSql);

                if (myReader.Read())
                {
                    if (!myReader.IsDBNull(0))
                        return myReader.GetInt32(0);
                    else
                        return 0;
                }
                else
                {
                    new Exception("Fallo en la consulta del número de parte de trabajo");
                    return -1;
                }


            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static ArrayList consultar_zonas(int idFichaMantenimiento)
        {
            try
            {
                string sSql = "select id from test where id_fichaMantenimiento = "+idFichaMantenimiento;

                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar(sSql);

                ArrayList testZonas = new ArrayList();

                while (myReader.Read())
                {
                    if (!myReader.IsDBNull(0))
                        testZonas.Add(new TestZonas(myReader.GetInt32("id")));
                }

                db.cerrarConexion();

                return testZonas;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int iIdFIcha)
        {
            try
            {
                db = new DBSesion();
                db.abrirConexion();

                string sSql = "DELETE FROM `test` WHERE `id_fichaMantenimiento` = " + iIdFIcha;
                db.eliminar(sSql);

                sSql = "DELETE FROM `fichamantenimiento` WHERE id = " + iIdFIcha;
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
