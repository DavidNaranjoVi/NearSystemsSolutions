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
   public class ContratoPlantilla
    {
        private int _id;
        private string _sNombrePlantilla;
        private int _id_cliente;
        private int _id_empresa;
        private string _sNumeroAbonado;
        private int _iNumeroContrato;
        private string _sFechaContrato;
        private bool bInstalacion;
        private bool bMantenimiento;
        private string _sFechaVigor;
        private int _iDuracion;
        private double _iPrecioInstalacion;
        private string _sFormaPagoInstalacion;
        private double _iPrecioMantenimiento;
        private string _sFormaPagoMantenimiento;
        private string _sLugar;
        private string _sCalle;
        private string _sCp;
        private string _sPoblacion;
        private string _sProvincia;
        private string _sPersonaContacto;
        private string _sTelefono;
        private bool _bRobo;
        private bool _bCctv;
        private string _sRelacionSistemas;
        private bool _bPeriodicidadAnual;
        private bool _bPrecioVisita;
        private bool _bCustodia;
        private string _sIban;
        private int _id_anexo;
        private string mensualidad;
        private string _sFechaVisado;
        private string _sCC;
        private string _sCS;

        static DBSesion db = null;

        public int Id { get => _id; set => _id = value; }
        public string SNombrePlantilla { get => _sNombrePlantilla; set => _sNombrePlantilla = value; }
        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public string SNumeroAbonado { get => _sNumeroAbonado; set => _sNumeroAbonado = value; }
        public int INumeroContrato { get => _iNumeroContrato; set => _iNumeroContrato = value; }
        public string SFechaContrato { get => _sFechaContrato; set => _sFechaContrato = value; }
        public bool BInstalacion { get => bInstalacion; set => bInstalacion = value; }
        public bool BMantenimiento { get => bMantenimiento; set => bMantenimiento = value; }
        public string SFechaVigor { get => _sFechaVigor; set => _sFechaVigor = value; }
        public int IDuracion { get => _iDuracion; set => _iDuracion = value; }
        public double IPrecioInstalacion { get => _iPrecioInstalacion; set => _iPrecioInstalacion = value; }
        public string SFormaPagoInstalacion { get => _sFormaPagoInstalacion; set => _sFormaPagoInstalacion = value; }
        public double IPrecioMantenimiento { get => _iPrecioMantenimiento; set => _iPrecioMantenimiento = value; }
        public string SFormaPagoMantenimiento { get => _sFormaPagoMantenimiento; set => _sFormaPagoMantenimiento = value; }
        public string SLugar { get => _sLugar; set => _sLugar = value; }
        public string SCalle { get => _sCalle; set => _sCalle = value; }
        public string SCp { get => _sCp; set => _sCp = value; }
        public string SPoblacion { get => _sPoblacion; set => _sPoblacion = value; }
        public string SProvincia { get => _sProvincia; set => _sProvincia = value; }
        public string SPersonaContacto { get => _sPersonaContacto; set => _sPersonaContacto = value; }
        public string STelefono { get => _sTelefono; set => _sTelefono = value; }
        public bool BRobo { get => _bRobo; set => _bRobo = value; }
        public bool BCctv { get => _bCctv; set => _bCctv = value; }
        public string SRelacionSistemas { get => _sRelacionSistemas; set => _sRelacionSistemas = value; }
        public bool BPeriodicidadAnual { get => _bPeriodicidadAnual; set => _bPeriodicidadAnual = value; }
        public bool BPrecioVisita { get => _bPrecioVisita; set => _bPrecioVisita = value; }
        public bool BCustodia { get => _bCustodia; set => _bCustodia = value; }
        public string SIban { get => _sIban; set => _sIban = value; }
        public int Id_empresa { get => _id_empresa; set => _id_empresa = value; }
        public int Id_anexo { get => _id_anexo; set => _id_anexo = value; }
        public string Mensualidad { get => mensualidad; set => mensualidad = value; }
        public string SFechaVisado { get => _sFechaVisado; set => _sFechaVisado = value; }
        public string SCC { get => _sCC; set => _sCC = value; }
        public string SCS { get => _sCS; set => _sCS = value; }

        public ContratoPlantilla(int iId)
        {
            try {

                db = new DBSesion();
                db.abrirConexion();

                MySqlDataReader myReader = db.consultar("select * from plantillaContrato where id = "+iId);

                if (myReader.Read())
                {

                    Id = iId;
                    SNombrePlantilla = myReader.GetString("nombreBorrador");
                    if(!myReader.IsDBNull(3))SNumeroAbonado = myReader.GetString("n_abonado");
                    if (!myReader.IsDBNull(2)) INumeroContrato = myReader.GetInt32("n_contrato");
                    if (!myReader.IsDBNull(4)) Id_cliente = myReader.GetInt32("id_cliente");

                    if (!myReader.IsDBNull(7)) SFechaContrato = myReader.GetString("fechaContrato");
                    else SFechaContrato = "";

                    if (!myReader.IsDBNull(5)) BInstalacion = myReader.GetBoolean("sistemaSeguridad");
                    if (!myReader.IsDBNull(6)) BMantenimiento = myReader.GetBoolean("mantenimiento");

                    if (!myReader.IsDBNull(8)) SFechaVigor = myReader.GetString("fechaVigor");
                    else SFechaVigor = "";

                    if (!myReader.IsDBNull(9)) IDuracion = myReader.GetInt32("duracion");
                    if (!myReader.IsDBNull(10)) IPrecioInstalacion = myReader.GetDouble("precioInstalacion");
                    if (!myReader.IsDBNull(11)) SFormaPagoInstalacion = myReader.GetString("formaPagoInstalacion");
                    if (!myReader.IsDBNull(12)) IPrecioMantenimiento = myReader.GetDouble("precioMantenimiento");
                    if (!myReader.IsDBNull(13)) SFormaPagoMantenimiento = myReader.GetString("formaPagoMantenimiento");
                    if (!myReader.IsDBNull(14)) Mensualidad = myReader.GetString("mensualidad");
                    if (!myReader.IsDBNull(15)) SLugar = myReader.GetString("lugar");
                    if (!myReader.IsDBNull(16)) SCalle = myReader.GetString("calle");
                    if (!myReader.IsDBNull(17)) SCp = myReader.GetString("cp");
                    if (!myReader.IsDBNull(18)) SPoblacion = myReader.GetString("poblacion");
                    if (!myReader.IsDBNull(19)) SProvincia = myReader.GetString("provincia");
                    if (!myReader.IsDBNull(20)) SPersonaContacto = myReader.GetString("personaContacto");
                    if (!myReader.IsDBNull(21)) STelefono = myReader.GetString("telefono");
                    if (!myReader.IsDBNull(22)) BRobo = myReader.GetBoolean("robo");
                    if (!myReader.IsDBNull(23)) BCctv = myReader.GetBoolean("cctv");
                    if (!myReader.IsDBNull(24)) SRelacionSistemas = myReader.GetString("relacionSeguridad");
                    if (!myReader.IsDBNull(25)) BPeriodicidadAnual = myReader.GetBoolean("instalar");
                    if (!myReader.IsDBNull(26)) BPrecioVisita = myReader.GetBoolean("mantener");
                    if (!myReader.IsDBNull(27)) BCustodia = myReader.GetBoolean("llaves");
                    if (!myReader.IsDBNull(28)) SIban = myReader.GetString("iban");
                    if (!myReader.IsDBNull(29)) _id_empresa = myReader.GetInt32("id_empresa");
                    if (!myReader.IsDBNull(30)) _id_anexo = myReader.GetInt32("id_anexo");
                    if (!myReader.IsDBNull(31)) _sFechaVisado = myReader.GetString("fechaVisado");
                    if (!myReader.IsDBNull(32)) _sCC = myReader.GetString("cc");
                    if (!myReader.IsDBNull(33)) _sCS = myReader.GetString("cs");

                }
                else
                {
                    throw new Exception("No existe plantilla del cliente.");
                }

                db.cerrarConexion();

            } catch(Exception ex) { throw ex; }

        }

        public static ContratoPlantilla create(int _idCliente,int _iIdEmpresa,string _sNombrePlantilla, string _sNumeroAbonado,string sNContrato, string _sFechaContrato,
            bool bInstalacion, bool bMantenimiento, string _sFechaVigor,int _iDuracion, double _iPrecioInstalacion, string _sFormaPagoInstalacion,
            double _iPrecioMantenimiento, string _sFormaPagoMantenimiento,string mensualidad, string _sLugar, string _sCalle, string _sCp, string _sPoblacion,
            string _sProvincia, string _sPersonaContacto, string _sTelefono, bool _bRobo, bool _bCctv, string _sRelacionSistemas,
            bool _bPeriodicidadAnual, bool _bPrecioVisita, bool _bCustodia, string _sIban,int _id_anexo,string _sFechaVisado,string _sCC,string _sCS)
        {

            try
            {
                db = new DBSesion();
                db.abrirConexion();

                if (_sFechaVigor.Equals("")) _sFechaVigor = "2000-01-01";
                if (_sFechaContrato.Equals("")) _sFechaContrato = "2000-01-01";

                String sSql_test = "select count(nombreBorrador) from plantillacontrato WHERE nombreBorrador LIKE " + Data.String2Sql(_sNombrePlantilla, true, false);

               MySqlDataReader myReader = db.consultar(sSql_test);

               myReader.Read();
               if (myReader.GetInt32("count(nombreBorrador)") > 0) throw new Exception("El nombre de borrador ya existe");

                myReader.Close();
                db.cerrarConexion();
                db.abrirConexion();
               

                String sSql = "insert into plantillaContrato (nombreBorrador,n_abonado,n_contrato,id_cliente,sistemaSeguridad,mantenimiento,fechaContrato," +
                    "fechaVigor,duracion,precioInstalacion," +
                    "formaPagoInstalacion,precioMantenimiento,formaPagoMantenimiento,mensualidad,lugar,calle,cp,poblacion," +
                    "provincia,personaContacto,telefono," +
                    "robo,cctv,relacionSeguridad,instalar,mantener,llaves,iban,id_empresa,id_anexo,fechaVisado,cc,cs) VALUES ("
                    + Data.String2Sql(_sNombrePlantilla,true,false) + ","
                    + Data.String2Sql(_sNumeroAbonado,true,false) + ","
                    + Convert.ToInt32(sNContrato) + ","
                    + _idCliente + ","
                    + bInstalacion + ","
                    + bMantenimiento + ","
                    + Data.String2Sql(_sFechaContrato, true, false) + ","
                    + Data.String2Sql(_sFechaVigor, true, false) + ","
                    + _iDuracion + ","
                    + _iPrecioInstalacion + ","
                    + Data.String2Sql(_sFormaPagoInstalacion, true, false) + ","
                    + _iPrecioMantenimiento + ","
                    + Data.String2Sql(_sFormaPagoMantenimiento, true, false) + ","
                    + Data.String2Sql(mensualidad, true, false) + ","
                    + Data.String2Sql(_sLugar, true, false) + ","
                    + Data.String2Sql(_sCalle, true, false) + ","
                    + Data.String2Sql(_sCp, true, false) + ","
                    + Data.String2Sql(_sPoblacion, true, false) + ","
                    + Data.String2Sql(_sProvincia, true, false) + ","
                    + Data.String2Sql(_sPersonaContacto, true, false) + ","
                    + Data.String2Sql(_sTelefono, true, false) + ","
                    + _bRobo + ","
                    + _bCctv + ","
                    + Data.String2Sql(_sRelacionSistemas, true, false) + ","
                    + _bPeriodicidadAnual + ","
                    + _bPrecioVisita + ","
                    + _bCustodia + ","
                    + Data.String2Sql(_sIban, true, false) + ","+_iIdEmpresa+","+_id_anexo+","
                    +Data.String2Sql(Data.formatearFecha(_sFechaVisado),true,false)+","
                     + Data.String2Sql(_sCC, true, false) + ","
                      + Data.String2Sql(_sCS, true, false) +");SELECT LAST_INSERT_ID()";

                int id = db.insertar(sSql);

                    db.cerrarConexion();

                return new ContratoPlantilla(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public static ContratoPlantilla actualizar(int _iId,int _iIdEmpresa,int _idCliente, string _sNombrePlantilla, string _sNumeroAbonado,string sNContrato,string _sFechaContrato,bool bInstalacion, 
            bool bMantenimiento,string _sFechaVigor, int _iDuracion, double _iPrecioInstalacion, string _sFormaPagoInstalacion,double _iPrecioMantenimiento, string _sFormaPagoMantenimiento, 
            string _sLugar, string _sCalle,  string _sCp, string _sPoblacion,string _sProvincia,string _sPersonaContacto, string _sTelefono,  bool _bRobo, bool _bCctv, string _sRelacionSistemas,
            bool _bPeriodicidadAnual,  bool _bPrecioVisita,bool _bCustodia, string _sIban,string _sFechaVisado,string _sCC,string _sCS){

            try{
                string fechaContrato = null, 
                    fechaVigor = null;

                if (!_sFechaContrato.Equals("")) 
                    fechaContrato = _sFechaContrato;
                if (!_sFechaVigor.Equals(""))
                    fechaVigor = _sFechaVigor;
                //ERROR TEST

                String sSql = "UPDATE `plantillacontrato` SET " +
                    "`nombreBorrador`="+Data.String2Sql(_sNombrePlantilla,true,false)+"," +
                    "`n_abonado`="+Data.String2Sql(_sNumeroAbonado,true,false)+"," +
                    "`n_contrato`="+Convert.ToInt32(sNContrato) + "," +
                    "`id_cliente`=" +_idCliente+"," +
                    "`id_empresa` = "+_iIdEmpresa +","+
                    "`sistemaSeguridad`="+bInstalacion+"," +
                    "`mantenimiento`="+bMantenimiento+"," +
                    "`fechaContrato`="+Data.String2Sql(fechaContrato,true,false)+"," +
                    "`fechaVigor`="+Data.String2Sql(fechaVigor,true,false)+"," +
                    "`duracion`="+_iDuracion+"," +
                    "`precioInstalacion`="+_iPrecioInstalacion+"," +
                    "`formaPagoInstalacion`="+Data.String2Sql(_sFormaPagoInstalacion,true,false)+"," +
                    "`precioMantenimiento`="+_iPrecioMantenimiento+"," +
                    "`formaPagoMantenimiento`="+Data.String2Sql(_sFormaPagoMantenimiento,true,false)+"," +
                    "`lugar`=" + Data.String2Sql(_sLugar, true, false) + "," +
                    "`calle`="+Data.String2Sql(_sCalle,true,false)+"," +
                    "`cp`="+Data.String2Sql(_sCp, true, false) + "," +
                    "`poblacion`=" + Data.String2Sql(_sPoblacion, true, false) + "," +
                    "`provincia`=" + Data.String2Sql(_sProvincia, true, false) + "," +
                    "`personaContacto`=" + Data.String2Sql(_sPersonaContacto, true, false) + "," +
                    "`telefono`=" + Data.String2Sql(_sTelefono, true, false) + "," +
                    "`robo`=" + _bRobo + "," +
                    "`cctv`=" + _bCctv + "," +
                    "`relacionSeguridad`=" + Data.String2Sql(_sRelacionSistemas, true, false) + "," +
                    "`instalar`=" + _bPeriodicidadAnual + "," +
                    "`mantener`=" + _bPrecioVisita + "," +
                    "`llaves`=" + _bCustodia + "," +
                    "`iban`=" + Data.String2Sql(_sIban, true, false) +","+
                    "`fechaVisado` = "+Data.String2Sql(Data.formatearFecha(_sFechaVisado),true,false)+","+
                    "`cc` = "+Data.String2Sql(_sCC,true,false)+","+
                    "`cs` = "+Data.String2Sql(_sCS,true,false)+" WHERE id = " + _iId;


                Clipboard.SetText(sSql);
                db = new DBSesion();
                db.abrirConexion();
                db.actualizar(sSql);
                db.cerrarConexion();

                return new ContratoPlantilla(_iId);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public static ArrayList consultar()
        {
            ArrayList aContratoBorrador = new ArrayList();
            try
            {
                String sSql = "Select * From plantillacontrato";

                db = new DBSesion();
                db.abrirConexion();

                MySqlDataReader myReader = db.consultar(sSql);


                while (myReader.Read())
                {
                    ContratoPlantilla cContratoBorrador = new ContratoPlantilla(myReader.GetInt32("id"));
                    aContratoBorrador.Add(cContratoBorrador);

                }

                db.cerrarConexion();

                return aContratoBorrador;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ArrayList consultar(string sNombreBorrador)
        {
            ArrayList aContratoBorrador = new ArrayList();
            try
            {
                String sSql = "Select * From plantillacontrato where nombreBorrador like "+Data.String2Sql(sNombreBorrador,true,true);

                db = new DBSesion();
                db.abrirConexion();

                MySqlDataReader myReader = db.consultar(sSql);


                while (myReader.Read())
                {
                    ContratoPlantilla cContratoBorrador = new ContratoPlantilla(myReader.GetInt32("id"));
                    aContratoBorrador.Add(cContratoBorrador);

                }

                db.cerrarConexion();

                return aContratoBorrador;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int iId)
        {
            try
            {
                db = new DBSesion();
                db.abrirConexion();

                string sSql = "DELETE FROM `plantillaelemento` WHERE `id_plantillaContrato` = " + iId;

                db.eliminar(sSql);
                db.cerrarConexion();
                db.abrirConexion();

                sSql = "DELETE FROM `plantillacontrato` WHERE `id` = " + iId;
                db.eliminar(sSql);

                db.cerrarConexion();
                db = null;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string getNombreBorrador() { return SNombrePlantilla; }
        public int getIdCliente() { return Id_cliente; }  

    }
}