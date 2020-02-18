using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NearSystemsSolutions
{
    class DBSesion
    {   

        private string _sUsuario;
        private string _sContrasena;
        private string _sNombreDB;
        private string _sServidor;
        private string _sPuerto;

        private MySqlCommand cmd = null;
        private MySqlConnection con = null;
        private MySqlDataReader myReader = null;

        public DBSesion(string sUsuario,string sContrasena,string sNombreDB,string sServidor,string sPuerto)
        {
            _sUsuario = sUsuario;
            _sContrasena = sContrasena;
            _sNombreDB = sNombreDB;
            _sServidor = sServidor;
            _sPuerto = sPuerto;
        }

        public DBSesion()
        {
            _sUsuario = "root";
            _sContrasena = "";
            _sNombreDB = "near";
            _sServidor = "localhost";
            _sPuerto = "3306";
        }

        public void abrirConexion()
        {
            try
            {
                String sConfDb = "server=" + SServidor + ";user=" + SUsuario + ";database=" + SNombreDB + ";port=" + SPuerto + ";password=" + SContrasena;
                con = new MySqlConnection(sConfDb);
                con.Open();
               
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            try
            {
               if(myReader != null) myReader.Close();
               if(con != null) con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 insertar(String sSql)
        {
            cmd = new MySqlCommand(sSql, con);
            myReader = cmd.ExecuteReader();
            myReader.Read();
            return Convert.ToInt32(myReader[0].ToString());
        }

        public void eliminar(String sSql)
        {
            cmd = new MySqlCommand(sSql, con);
            cmd.ExecuteNonQuery();
        }

        public void actualizar(String sSql)
        {
            cmd = new MySqlCommand(sSql, con);
            myReader = cmd.ExecuteReader();
        }

        public MySqlDataReader consultar(String sSql)
        {
            cmd = new MySqlCommand(sSql, con);
            return cmd.ExecuteReader();
        }




        public string SUsuario { get => _sUsuario; set => _sUsuario = value; }
        public string SContrasena { get => _sContrasena; set => _sContrasena = value; }
        public string SNombreDB { get => _sNombreDB; set => _sNombreDB = value; }
        public string SServidor { get => _sServidor; set => _sServidor = value; }
        public string SPuerto { get => _sPuerto; set => _sPuerto = value; }

    }
}
