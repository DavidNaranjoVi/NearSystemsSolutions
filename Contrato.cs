using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NearSystemsSolutions
{
   public class Contrato
    {
        private int _id;
        private string _sNumeroAbonado;
        private int _iNumeroContrato;
        private int _iIdCliente;
        private int _iIdAnexo;
        private int _iIdEmpresa;

        private Cliente _cCLiente;
        private Empresa _eEmpresa;
        private Anexo _aAnexo;

        private string _sFechaContrato;
        private bool _bInstalacion;
        private bool _bMantenimiento;
        private string _sFechaVigor;
        private int _iDuracion;
        private double _iPrecioInstalacion;
        private string _sFormaPagoInstalacion;
        private double _iPrecioMantenimiento;
        private string _sFormaPagoMantenimiento;
        private string _sMensualidad;
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
        private string _sFechaVisado;
        private string _sCC;
        private string _sCS;

        static DBSesion db = null;

        public int Id { get => _id; set => _id = value; }
        public string SNumeroAbonado { get => SNumeroAbonado1; set => SNumeroAbonado1 = value; }
        public int INumeroContrato { get => _iNumeroContrato; set => _iNumeroContrato = value; }
        public int IIdCliente { get => _iIdCliente; set => _iIdCliente = value; }
        public string SFechaContrato { get => _sFechaContrato; set => _sFechaContrato = value; }
        public bool BInstalacion { get => _bInstalacion; set => _bInstalacion = value; }
        public bool BMantenimiento { get => _bMantenimiento; set => _bMantenimiento = value; }
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
        public Cliente CCLiente { get => CCLiente1; set => CCLiente1 = value; }
        public Cliente CCLiente1 { get => _cCLiente; set => _cCLiente = value; }
        internal Empresa EEmpresa { get => _eEmpresa; set => _eEmpresa = value; }
        internal Anexo AAnexo { get => _aAnexo; set => _aAnexo = value; }
        public string SMensualidad { get => _sMensualidad; set => _sMensualidad = value; }
        public int IIdAnexo { get => _iIdAnexo; set => _iIdAnexo = value; }
        public int IIdEmpresa { get => _iIdEmpresa; set => _iIdEmpresa = value; }
        public string SNumeroAbonado1 { get => _sNumeroAbonado; set => _sNumeroAbonado = value; }
        public string SFechaVisado { get => _sFechaVisado; set => _sFechaVisado = value; }
        public string SCC { get => _sCC; set => _sCC = value; }
        public string SCS { get => _sCS; set => _sCS = value; }

        public Contrato(int _iId)
        {
            try
            {
                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar("select * from contrato WHERE id = " + _iId);

                if (myReader.Read())
                {

                    if (!myReader.IsDBNull(1))
                        INumeroContrato = myReader.GetInt32("n_contrato");
                    else
                        throw new Exception("Fallo en la carga del numero de contrato.");

                    if (!myReader.IsDBNull(2))
                        SNumeroAbonado = myReader.GetString("n_abonado");
                    else
                        throw new Exception("Fallo en la carga del numero de abonado");

                    if (!myReader.IsDBNull(3))
                    {
                        IIdCliente = myReader.GetInt32("id_cliente");
                        CCLiente = new Cliente(IIdCliente);
                    }
                    else
                    {
                        throw new Exception("Fallo en la carga del cliente del contrato");
                    }

                    if (!myReader.IsDBNull(4)) {
                        IIdAnexo = myReader.GetInt32("id_anexo");
                        AAnexo = new Anexo(IIdAnexo);

                    }else throw new Exception("Fallo en la carga del anexo.");

                    if (!myReader.IsDBNull(5) && myReader.GetInt32("id_empresa") != 0) {
                        IIdEmpresa = myReader.GetInt32("id_empresa");
                        EEmpresa = new Empresa(IIdEmpresa);
                    }

                    if (!myReader.IsDBNull(6))
                        BInstalacion = myReader.GetBoolean("sistemaSeguridad");
                    else
                        throw new Exception("Fallo en la carga del campo Instalación Sistema Seguridad del contrato");

                    if (!myReader.IsDBNull(7))
                        BMantenimiento = myReader.GetBoolean("mantenimiento");
                    else
                        throw new Exception("Fallo en la carga del campo Mantenimiento de Seguridad del contrato");

                    if (!myReader.IsDBNull(8))
                        SFechaContrato = myReader.GetString("fechaContrato");
                    else
                        throw new Exception("Fallo en la carga de la fecha del contrato");

                    if (!myReader.IsDBNull(9))
                        SFechaVigor = myReader.GetString("fechaVigor");
                    else
                        throw new Exception("Fallo en la carga de la fecha de entrada de vigor del contrato");

                    if (!myReader.IsDBNull(10))
                        IDuracion = myReader.GetInt32("duracion");
                    else
                        throw new Exception("Fallo en la carga de la duración del contrato");

                    if (!myReader.IsDBNull(11))
                        IPrecioInstalacion = myReader.GetDouble("precioInstalacion");
                    else
                        throw new Exception("Fallo en la carga del precio del contrato");

                    if (!myReader.IsDBNull(12))
                        SFormaPagoInstalacion = myReader.GetString("formaPagoInstalacion");
                    else
                        throw new Exception("Fallo en la carga de la forma de pago del contrato");

                    if (!myReader.IsDBNull(13))
                        IPrecioMantenimiento = myReader.GetDouble("precioMantenimiento");
                    else
                        throw new Exception("Fallo en la carga del precio del mantenimiento del contrato");

                    if (!myReader.IsDBNull(14))
                        SFormaPagoMantenimiento = myReader.GetString("formaPagoMantenimiento");
                    else
                        throw new Exception("Fallo en la carga de la forma de pago del contrato");

                    if (!myReader.IsDBNull(15))
                        SMensualidad = myReader.GetString("mensualidad");
                    else
                        throw new Exception("Fallo en la carga de la mensualidad del contrato");

                    if (!myReader.IsDBNull(16))
                        SLugar = myReader.GetString("lugar");
                    else
                        throw new Exception("Fallo en la carga del lugar del contrato");

                    if (!myReader.IsDBNull(17))
                        SCalle = myReader.GetString("calle");
                    else
                        throw new Exception("Fallo en la carga de la calle del contrato");

                    if (!myReader.IsDBNull(18))
                        SCp = myReader.GetString("cp");
                    else
                        throw new Exception("Fallo en la carga del cp del contrato");

                    if (!myReader.IsDBNull(19))
                        SPoblacion = myReader.GetString("poblacion");
                    else
                        throw new Exception("Fallo en la carga del municipio del contrato");

                    if (!myReader.IsDBNull(20))
                        SProvincia = myReader.GetString("provincia");
                    else
                        throw new Exception("Fallo en la carga de la provincia del contrato");

                    if (!myReader.IsDBNull(21))
                        SPersonaContacto = myReader.GetString("personaContacto");
                    else
                        throw new Exception("Fallo en la carga de la persona de contacto del contrato");

                    if (!myReader.IsDBNull(22))
                        STelefono = myReader.GetString("telefono");
                    else
                        throw new Exception("Fallo en la carga del teléfono del contrato");

                    if (!myReader.IsDBNull(23))
                        BRobo = myReader.GetBoolean("robo");
                    else
                        throw new Exception("Fallo en la carga del campo Robo del contrato");

                    if (!myReader.IsDBNull(24))
                        BCctv = myReader.GetBoolean("cctv");
                    else
                        throw new Exception("Fallo en la carga del Cctv del contrato");

                    if (!myReader.IsDBNull(25))
                        SRelacionSistemas = myReader.GetString("relacionSeguridad");
                    else
                        SRelacionSistemas = "";

                    if (!myReader.IsDBNull(26))
                       BPeriodicidadAnual = myReader.GetBoolean("instalar");
                    else
                        throw new Exception("Fallo en la carga del campo Instalar del contrato");

                    if (!myReader.IsDBNull(27))
                        BPrecioVisita = myReader.GetBoolean("mantener");
                    else
                        throw new Exception("Fallo en la carga del campo Mantener del contrato");

                    if (!myReader.IsDBNull(28))
                        BCustodia = myReader.GetBoolean("llaves");
                    else
                        throw new Exception("Fallo en la carga del campo Custodia de llaves del contrato");

                    if (!myReader.IsDBNull(29))
                        SIban = myReader.GetString("iban");
                    else
                        throw new Exception("Fallo en la carga del Iban del contrato");


                    if (!myReader.IsDBNull(30))
                        SFechaVisado = myReader.GetString("fechaVisado");
                    else
                        throw new Exception("Fallo en la carga de la fecha de visado.");

                    if (!myReader.IsDBNull(31))
                        SCC = myReader.GetString("codigoContrato");
                    else
                        throw new Exception("Fallo en la carga de el CC");

                    if (!myReader.IsDBNull(32))
                        SCS = myReader.GetString("codigoServicio");
                    else
                        throw new Exception("Fallo en la carga de el CS");


                    this.Id = _iId;
                    db.cerrarConexion();
                }
                else
                {
                    throw new Exception("El contrato no se ha guardado correctamente");
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void error_test(string _sNumContrato, string _sNumeroAbonado, int idCliente, int _iIdAnexo, int _iIdEmpresa, string _sFechaContrato,
            bool bInstalacion, bool bMantenimiento, string _sFechaVigor, int _iDuracion, string _iPrecioInstalacion, string _sFormaPagoInstalacion,
            string _iPrecioMantenimiento, string _sFormaPagoMantenimiento, string _sMensualidad, string _sLugar, string _sCalle, string _sCp, string _sPoblacion,
            string _sProvincia, string _sPersonaContacto, string _sTelefono, bool _bRobo, bool _bCctv, string _sRelacionSistemas,
            bool _bPeriodicidadAnual, bool _bPrecioVisita, bool _bCustodia, string _sIban, string _sFechaVisado, string _sCC, string _sCS)
        {
            string sNumeroContrato = "[0-9]";
            string sFecha = "[0-9]{4}-[0-9]{2}-[0-9]{2}";
            string sPrecio = "[0-9](.|,)[0-9]";
            string sTelefono = "[0-9+]{9,12}";

            double n;

            db = new DBSesion();
            db.abrirConexion();

            if (_sCp.Length < 2) throw new Exception("El cp debe ser válido.");

            string sSql = "select provincia from municipios where municipio LIKE " + Data.String2Sql(_sProvincia, true, false)
                                                    + " AND provincia = " + Convert.ToInt32(_sCp.Substring(0, 2));


            MySqlDataReader myReader = db.consultar(sSql);
            
            Match mNumeroContrato = Regex.Match(_sNumContrato, sNumeroContrato);
            Match mFechaContrato = Regex.Match(_sFechaContrato, sFecha);
            Match mFechaVigor = Regex.Match(_sFechaVigor, sFecha);
            Match mPrecioInstalacion = Regex.Match(_iPrecioInstalacion, sPrecio);
            Match mPrecioMantenimiento = Regex.Match(_iPrecioMantenimiento, sPrecio);
            Match mCp = Regex.Match(_sCp, sNumeroContrato);
            Match mTelefono = Regex.Match(_sTelefono,sTelefono);
            Match mFechaVisado = Regex.Match(_sFechaVisado, sFecha);
            Match mCC = Regex.Match( _sCC, sNumeroContrato);
            Match mCS = Regex.Match( _sCS, sNumeroContrato);

            if (_sNumContrato.Equals("")) throw new Exception("El número del contrato  no puede ser nulo");
            else if (!mNumeroContrato.Success) throw new Exception("El número del contrato debe ser válido.");

            if (_sNumeroAbonado.Equals("")) throw new Exception("El numero de abonado no puede ser nulo.");

            if (idCliente == 0) throw new Exception("Debe selecccionar un cliente.");

            //if (_iIdAnexo == 0) throw new Exception("No se ha selecciona o generado correctamente el anexo.");

            if (_iIdEmpresa == 0 && new Cliente(idCliente).getTipoCliente().Equals("Empresa")) throw new Exception("La empresa del cliente no se ha cargado correctamente");

            if (_sFechaContrato.Equals("")) throw new Exception("La fecha del contrato no puede ser nula.");
            else if (!mFechaContrato.Success) throw new Exception("La fecga del contrato debe ser válida.");

            if (_sFechaVigor.Equals("")) throw new Exception("La fecha de entrada de vigor no puede ser nula.");
            else if (!mFechaVigor.Success) throw new Exception("La fecha de entrada de vigor debe ser válida");

            if (_iDuracion == 0) throw new Exception("La duración del contrato no puede ser nula.");

            if (_iPrecioInstalacion.Equals("")) throw new Exception("El precio de instalación no puede ser nulo");
            else if (!Double.TryParse(_iPrecioInstalacion,out n)) throw new Exception("El precio de instalación debe de ser válido.");

            if (_iPrecioMantenimiento.Equals("")) throw new Exception("El precio del mantenimiento no puede ser nulo.");
            else if (!Double.TryParse(_iPrecioMantenimiento, out n)) throw new Exception("El precio del mantenimiento debe de ser válido.");

            if (_sFormaPagoMantenimiento.Equals("")) throw new Exception("La forma de pago del mantenimiento no puede ser nula.");

            if (_sMensualidad.Equals("")) throw new Exception("La mensualidad no puede ser nula.");

            if (_sLugar.Equals("")) throw new Exception("El lugar del contrato no puede ser nulo.");

            if (_sCalle.Equals("")) throw new Exception("La calle del contrato no puede ser nulo.");

            if (_sCp.Equals("")) throw new Exception("El código postal del contrato no puede ser nulo.");
            else if (!myReader.Read()||!mCp.Success) throw new Exception("El código postal del contrato debe de ser válido");

            if (_sPoblacion.Equals("")) throw new Exception("El municipio del contrato no puede ser nulo.");

            if (_sFormaPagoInstalacion.Equals("")) throw new Exception("La forma de pago no puede ser nula.");

            if (_sProvincia.Equals("")) throw new Exception("La provincia del contrato no puede ser nula.");

            if (_sPersonaContacto.Equals("")) throw new Exception("La persona de contacto del contrato no puede ser nula.");

            if (_sTelefono.Equals("")) throw new Exception("El teléfono del contrato no puede ser nulo.");
            else if (!mTelefono.Success) throw new Exception("El télefono debe de ser válido.");

            if (_sIban.Equals("")) throw new Exception("La cuenta iban no puede ser nula.");

            if (_sFechaVisado.Equals("")) throw new Exception("La fecha de visado no puede ser nula.");
            else if (!mFechaVisado.Success) throw new Exception("La fecha de visado debe ser una fecha válida.");

            if (_sCC.Equals("")) throw new Exception("El cc no puede ser nulo.");
            else if (!mCC.Success) throw new Exception("El cc debe ser válido.");

            if (_sCS.Equals("")) throw new Exception("El cs no puede ser nulo.");
            else if (!mCS.Success) throw new Exception("El cs debe de ser válido.");

        }

        public static Contrato create(string _sNumContrato,string _sNumeroAbonado,int idCliente,int _iIdAnexo,int _iIdEmpresa, string _sFechaContrato, 
            bool bInstalacion,bool bMantenimiento,string _sFechaVigor,int _iDuracion, double _iPrecioInstalacion, string _sFormaPagoInstalacion,
            double _iPrecioMantenimiento, string _sFormaPagoMantenimiento,string _sMensualidad,string _sLugar, string _sCalle, string _sCp, string _sPoblacion, 
            string _sProvincia, string _sPersonaContacto, string _sTelefono,bool _bRobo, bool _bCctv, string _sRelacionSistemas, 
            bool _bPeriodicidadAnual, bool _bPrecioVisita, bool _bCustodia, string _sIban,string _sFechaVisado,string _sCC,string _sCS)
        {
          
            try {

                db = new DBSesion();
                db.abrirConexion();

                //ERROR TEST

                String sSql = "insert into contrato (n_contrato,n_abonado,id_cliente,id_anexo,id_empresa,sistemaSeguridad,mantenimiento,fechaContrato," +
                              "fechaVigor,duracion,precioInstalacion,formaPagoInstalacion,precioMantenimiento,formaPagoMantenimiento,mensualidad,lugar," +
                              "calle,cp,poblacion,provincia,personaContacto,telefono,robo,cctv,relacionSeguridad,instalar,mantener,llaves,iban,fechaVisado" +
                              ",codigoContrato,codigoServicio) VALUES ("
                              + _sNumContrato + ","
                               + Data.String2Sql(_sNumeroAbonado,true,false) + ","
                                 + idCliente + ","
                                 + _iIdAnexo + ","
                                 + _iIdEmpresa + ","
                                 + bInstalacion.ToString() + ","
                               + bMantenimiento.ToString() + ","
                                 + Data.String2Sql(_sFechaContrato,true,false) + ","
                                 + Data.String2Sql( _sFechaVigor,true,false) + ","
                               + _iDuracion + ","
                                 + _iPrecioInstalacion + ","
                                 + Data.String2Sql(_sFormaPagoInstalacion,true,false) + ","
                               + _iPrecioMantenimiento + ","
                                 + Data.String2Sql(_sFormaPagoMantenimiento,true,false) + ","
                                 + Data.String2Sql(_sMensualidad, true, false) + ","
                                 + Data.String2Sql(_sLugar,true,false) + ","
                               + Data.String2Sql(_sCalle,true,false) + ","
                               + Data.String2Sql(_sCp,true,false)+","
                                 + Data.String2Sql(_sPoblacion,true,false) + ","
                                 + Data.String2Sql(_sProvincia,true,false) + ","
                               + Data.String2Sql(_sPersonaContacto,true,false) + ","
                                 + Data.String2Sql(_sTelefono,true,false) + ","
                                 + _bRobo.ToString() + ","
                               + _bCctv.ToString() + ","
                                 + Data.String2Sql(_sRelacionSistemas,true,false) + ","
                               + _bPeriodicidadAnual.ToString() + ","
                                + _bPrecioVisita.ToString() + ","
                                  + _bCustodia.ToString() + ","
                                  + Data.String2Sql(_sIban,true,false) +","
                                  +Data.String2Sql(_sFechaVisado,true,false)+","
                                  + Data.String2Sql(_sCC, true, false) + ","
                                  + Data.String2Sql(_sCS, true, false) + "); SELECT LAST_INSERT_ID()";
                Clipboard.SetText(sSql);                int iId = db.insertar(sSql);


                return new Contrato(iId); 

            } catch(Exception ex)
            {
                throw ex;
            }

        }
        
        public static Contrato actualizar(int _iId,string _sNumContrato, string _sNumeroAbonado, int idCliente, int _iIdAnexo, int _iIdEmpresa, string _sFechaContrato,
            bool bInstalacion, bool bMantenimiento, string _sFechaVigor, int _iDuracion, double _iPrecioInstalacion, string _sFormaPagoInstalacion,
            double _iPrecioMantenimiento, string _sFormaPagoMantenimiento, string _sMensualidad, string _sLugar, string _sCalle, string _sCp, string _sPoblacion,
            string _sProvincia, string _sPersonaContacto, string _sTelefono, bool _bRobo, bool _bCctv, string _sRelacionSistemas,
            bool _bPeriodicidadAnual, bool _bPrecioVisita, bool _bCustodia, string _sIban,string _sFechaVisado,string _sCC,string _sCS)
        {
            try
            {
                //COMPROBAR ERRORES

                string idEmpresa = (_iIdEmpresa == 0) ? "null" : _iIdEmpresa.ToString();

                String sSql = "UPDATE `contrato` SET " +
                    "`n_contrato`="+_sNumContrato+"," +
                    "`n_abonado`=" + Data.String2Sql(_sNumeroAbonado,true,false) + "," +
                    "`id_cliente`=" + idCliente + "," +
                    "`id_anexo`=" + _iIdAnexo + "," +
                    "`id_empresa`=" + idEmpresa + "," +
                    "`sistemaSeguridad`=" + bInstalacion.ToString() + "," +
                    "`mantenimiento`=" + bMantenimiento.ToString() + "," +
                    "`fechaContrato`=" + Data.String2Sql(_sFechaContrato, true, false) + "," +
                    "`fechaVigor`=" + Data.String2Sql(_sFechaVigor, true, false) + "," +
                    "`duracion`=" + _iDuracion + "," +
                    "`precioInstalacion`=" + _iPrecioInstalacion + "," +
                    "`formaPagoInstalacion`=" + Data.String2Sql(_sFormaPagoInstalacion, true, false) + "," +
                    "`precioMantenimiento`=" + _iPrecioMantenimiento + "," +
                    "`formaPagoMantenimiento`=" + Data.String2Sql(_sFormaPagoMantenimiento, true, false) + "," +
                    "`mensualidad`=" + Data.String2Sql(_sMensualidad, true, false) + "," +
                    "`lugar`=" + Data.String2Sql(_sLugar, true, false) + "," +
                    "`calle`=" + Data.String2Sql(_sCalle, true, false) + "," +
                    "`cp`=" + Data.String2Sql(_sCp, true, false) + "," +
                    "`poblacion`=" + Data.String2Sql(_sPoblacion, true, false) + "," +
                    "`provincia`=" + Data.String2Sql(_sProvincia, true, false) + "," +
                    "`personaContacto`=" + Data.String2Sql(_sPersonaContacto, true, false) + "," +
                    "`telefono`=" + Data.String2Sql(_sTelefono, true, false) + "," +
                    "`robo`=" + _bRobo.ToString() + "," +
                    "`cctv`=" + _bCctv.ToString() + "," +
                    "`relacionSeguridad`=" + Data.String2Sql(_sRelacionSistemas, true, false) + "," +
                    "`instalar`=" + _bPeriodicidadAnual + "," +
                    "`mantener`=" + _bPrecioVisita + "," +
                    "`llaves`=" + _bCustodia + "," +
                    "`iban`=" + Data.String2Sql(_sIban, true, false) + "," +
                    "`fechaVisado`=" + Data.String2Sql(_sFechaVisado, true, false) + "," +
                    "`codigoContrato`=" + Data.String2Sql(_sCC, true, false) + "," +
                    "`codigoServicio`= " + Data.String2Sql(_sCS, true, false) +
                    " WHERE id = " + _iId;

                db = new DBSesion();
                db.abrirConexion();

                db.actualizar(sSql);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            db.cerrarConexion();
            return new Contrato(_iId);
        }

        public static int Consultar_num()
        {
            int n;
            try
            {
                db = new DBSesion();
                db.abrirConexion();

                String sSql = "select count(id) from contrato";
                MySqlDataReader myReader = db.consultar(sSql);

                if (myReader.Read())
                {
               
                    if (myReader.GetInt32(0) > 0)
                    {
                        db.cerrarConexion();
                        db.abrirConexion();

                        myReader = db.consultar("select max(n_contrato) from contrato");

                        myReader.Read();

                         n = myReader.GetInt32(0);
                        db.cerrarConexion();
                    }
                    else
                    {
                        n = 0;
                        db.cerrarConexion();
                    }

                }
                else
                {
                    throw new Exception("Fallo de lectura numero de contrato");
                }

                return n;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        static public ArrayList Consultar(string sNContrato = "", string sNAbonado = "", string sDniCif = "",string sCif = ""
            , string sFechaAlta = "")
        {
            try {

                db = new DBSesion();
                db.abrirConexion();

                ArrayList aContratos = new ArrayList();

                // CAMBIAR CONSULTA
                string sSql = "select * from contrato";
                
               MySqlDataReader myReader =  db.consultar(sSql);

                while (myReader.Read()) aContratos.Add(new Contrato(myReader.GetInt32("id")));

                db.cerrarConexion();

                return aContratos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int iIdContrato)
        {
            try
            {
                db = new DBSesion();
                db.abrirConexion();

                string sSql = "DELETE FROM `contrato_elemento` WHERE `id_contrato` = " + iIdContrato;
                db.eliminar(sSql);
                db.cerrarConexion();
                db.abrirConexion();
                sSql = "DELETE FROM `contrato` WHERE `id` = " + iIdContrato;
                db.eliminar(sSql);
                db.cerrarConexion();
                db = null;

            }
            catch(Exception ex)
            {

            }
        }
                                      
    }                                 
}                                     
