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
    public class FichaAbonado
    {
        private int _iId;
        private string _sEmpresaInstaladora = "";
        private string _sNAbonado = "";
        private string _sTipoPanel = "";
        private string _sFechaAlta = "";
        private string _sNombreRazonSocial = "";
        private string _sDireccion = "";
        private string _sLocalidad = "";
        private string _sProvincia = "";
        private string _sCopo = "";
        private string _sTelefono1 = "";
        private string _sTelefono2 = "";
        private string _sTelefono3 = "";
        private string _sEmail = "";
        private string _sViaPrincipal = "";
        private string _sModeloPrincipal = "";
        private string _sFormatoPrincipal = "";
        private string _sTestPrincipal = "";
        private string _sViaSecundaria = "";
        private string _sModeloSecundaria = "";
        private string _sFormatoSecundaria = "";
        private string _sTestSecundaria = "";
        private string _sCctvIp = "";
        private string _sCctvIpModelo = "";
        private string _sCctvIpCliente = "";
        private string _sCctvIpPuerto = "";
        private string _sIMEI = "";
        private string _sConsignaGlobal = "";
        private string _sConsignaCoaccion = "";
        private string _sConsignaCRA = "";
        private string _sComentarios ="";
        private string _sCctv = "";
        private string _sUsuario = "";
        private string _sContrasena = "";
        private string _sLlave = "";

        ArrayList _aZonas = new ArrayList();
        ArrayList _aContactos = new ArrayList();

        static private DBSesion db = null;

        public FichaAbonado(int iId)
        {
            try
            {
                db = new DBSesion();
                db.abrirConexion();

                MySqlDataReader myReader = db.consultar("select * from fichaabonado where id = " + iId);

                if (myReader.Read())
                {
                    if (!myReader.IsDBNull(1)) _sEmpresaInstaladora = myReader.GetString("empresaInstaladora");
                    else new Exception("No se ha podido consultar la empresa instaladora.");

                    if (!myReader.IsDBNull(2)) _sNAbonado = myReader.GetString("n_abonado");
                    else new Exception("No se ha podido consultar el numero de abonado");

                    if (!myReader.IsDBNull(3)) _sTipoPanel = myReader.GetString("tipoPanel");
                    else new Exception("No se ha podido consultar el tipo panel");

                    if (!myReader.IsDBNull(4)) _sFechaAlta = myReader.GetString("fechaAlta");
                    else new Exception("No se ha podido consultar la fecha de alta");

                    if (!myReader.IsDBNull(5)) _sNombreRazonSocial = myReader.GetString("nombreRazon");
                    else new Exception("No se ha podido consultar el nombre o razón social");

                    if (!myReader.IsDBNull(6)) _sDireccion = myReader.GetString("direccion");
                    else new Exception("No se ha podido consultar la dirección.");

                    if (!myReader.IsDBNull(7)) _sLocalidad = myReader.GetString("localidad");
                    else new Exception("No se ha podido consultar la localidad");

                    if (!myReader.IsDBNull(8)) _sProvincia = myReader.GetString("provincia");
                    else new Exception("No se ha podido consultar la provincia");

                    if (!myReader.IsDBNull(9)) _sCopo = myReader.GetString("copo");
                    else new Exception("No se ha podido consultar el CP");

                    if (!myReader.IsDBNull(10)) STelefono1 = myReader.GetString("telefono1");
                    else new Exception("No se ha podido consultar el telefono de contacto.");

                    if (!myReader.IsDBNull(11)) STelefono2 = myReader.GetString("telefono2");
                    else STelefono2 = "";

                    if (!myReader.IsDBNull(12)) STelefono3 = myReader.GetString("telefono3");
                    else STelefono3 = "";

                    if (!myReader.IsDBNull(13)) SEmail = myReader.GetString("email");

                    if (!myReader.IsDBNull(14)) _sViaPrincipal = myReader.GetString("viaPrincipal");
                    else new Exception("No se ha podido consultar la Vía principal.");

                    if (!myReader.IsDBNull(15)) _sModeloPrincipal = myReader.GetString("modeloPrincipal");
                    else new Exception("No se ha podido consultar la Modelo principal.");

                    if (!myReader.IsDBNull(16)) _sFormatoPrincipal = myReader.GetString("formatoPrincipal");
                    else new Exception("No se ha podido consultar la Formato principal.");

                    if (!myReader.IsDBNull(17)) _sTestPrincipal = myReader.GetString("testPrincipal");
                    else new Exception("No se ha podido consultar la test principal.");

                    if (!myReader.IsDBNull(18)) _sViaSecundaria = myReader.GetString("viaSecundaria");
                    else new Exception("No se ha podido consultar la Vía secundaria.");

                    if (!myReader.IsDBNull(19)) _sModeloSecundaria = myReader.GetString("modeloSecundaria");
                    
                    if (!myReader.IsDBNull(20)) _sFormatoSecundaria = myReader.GetString("formatoSecundaria");
                    
                    if (!myReader.IsDBNull(21)) _sTestSecundaria = myReader.GetString("testSecundaria");

                    if (!myReader.IsDBNull(22)) SCctvIp = myReader.GetString("cctvip");

                    if (!myReader.IsDBNull(23)) SCctvIpModelo = myReader.GetString("modeloCctvip");

                    if (!myReader.IsDBNull(24)) SCctvIpCliente = myReader.GetString("ipCliente");

                    if (!myReader.IsDBNull(25)) SCctvIpPuerto = myReader.GetString("puerto");

                    if (!myReader.IsDBNull(26)) _sIMEI = myReader.GetString("imei");

                    if (!myReader.IsDBNull(27)) _sConsignaGlobal = myReader.GetString("consignaGlobal");

                    if (!myReader.IsDBNull(28)) _sConsignaCoaccion = myReader.GetString("consignaCoaccion");

                    if (!myReader.IsDBNull(29)) _sConsignaCRA = myReader.GetString("consignaCRA");

                    if (!myReader.IsDBNull(30)) _sComentarios = myReader.GetString("comentarios");

                    if (!myReader.IsDBNull(31)) _sCctv = myReader.GetString("cctv");


                    if (!myReader.IsDBNull(32)) _sUsuario = myReader.GetString("usuario");
                    else _sUsuario = "";


                    this._iId = iId;

                    db.cerrarConexion();


                }
                else
                {
                    new Exception("No se ha encontrado la ficha de abonado con el id especificado");
                }

                db.abrirConexion();
                if (!_sUsuario.Equals(""))
                {
                    myReader = db.consultar("SELECT AES_DECRYPT(llave, n_abonado) FROM `fichaabonado` WHERE id = " + iId);

                    if (myReader.Read())
                        if (!myReader.IsDBNull(0))
                            _sLlave = myReader.GetString("AES_DECRYPT(llave, n_abonado)");

                }

                db.cerrarConexion();
                db.abrirConexion();
                if (!_sUsuario.Equals(""))
                {
                    myReader = db.consultar("SELECT AES_DECRYPT(password," + Data.String2Sql(_sLlave, true, false) + ") FROM `fichaabonado` WHERE id = " + iId);

                    if (myReader.Read())
                        if (!myReader.IsDBNull(0))
                            _sContrasena = myReader.GetString(0);
                }

                db.cerrarConexion();

            }catch(Exception ex)
            {
                throw ex;
            }

        }

        

        static public FichaAbonado create( string _sEmpresaInstaladora,string _sNAbonado,string _sTipoPanel,string _sFechaAlta,
                                    string _sNombreRazonSocial,string _sDireccion,string _sLocalidad,string _sProvincia,string _sCopo,
                                    string[] _aTelefonos,string _sEmail, string _sViaPrincipal,string _sModeloPrincipal,
                                    string _sFormatoPrincipal,string _sTestPrincipal,string _sViaSecundaria,string _sModeloSecundaria,
                                    string _sFormatoSecundaria,string _sTestSecundaria,string _sCctvIp, 
                                    string _sCctvIpModelo,string _sIPCliente, string _sCctvIpPuerto,string _sIMEI,
                                    string _sConsignaGlobal,string _sConsignaCoaccion,string _sConsignaCRA,string _sComentarios,
                                    string _sCctv,string _sUsuario,string _sContrasena,string _sContrasenaRep,string _sllave,string _sllaveRep)
        {

            try
            {



                error_test( _sEmpresaInstaladora,  _sNAbonado,  _sTipoPanel,  _sFechaAlta,
                                     _sNombreRazonSocial,  _sDireccion,  _sLocalidad,_sProvincia,  _sCopo,
                                     _aTelefonos,_sEmail, _sViaPrincipal,  _sModeloPrincipal,
                                     _sFormatoPrincipal,  _sTestPrincipal,  _sViaSecundaria,  _sModeloSecundaria,
                                     _sFormatoSecundaria,  _sTestSecundaria,  _sCctvIp,
                                     _sCctvIpModelo,  _sIPCliente,  _sCctvIpPuerto,  _sIMEI,
                                     _sConsignaGlobal,  _sConsignaCoaccion,  _sConsignaCRA,  _sComentarios,
                                     _sCctv,  _sUsuario,  _sContrasena,  _sContrasenaRep,  _sllave,  _sllaveRep);

                db = new DBSesion();
                db.abrirConexion();

                string[] tlfn = { "", "", "" };

                for(int i = 0; i < 3; i++)
                {
                    tlfn[i] = _aTelefonos[i].ToString();
                }

                string sSql = "INSERT into fichaabonado (`empresaInstaladora`, `n_abonado`, `tipoPanel`, " +
                    "`fechaAlta`, `nombreRazon`, `direccion`, `localidad`,`provincia`, `copo`, `telefono1`, `telefono2`, " +
                    "`telefono3`, `email`, `viaPrincipal`, `modeloPrincipal`, `formatoPrincipal`, `testPrincipal`, " +
                    "`viaSecundaria`, `modeloSecundaria`, `formatoSecundaria`, `testSecundaria`, `cctvip`, `modeloCctvip`, " +
                    "`ipCliente`, `puerto`, `imei`, `consignaGlobal`, `consignaCoaccion`, `consignaCRA`," +
                    " `comentarios`, `cctv`, `usuario`, `password`, `llave`) VALUES ("
                    + Data.String2Sql(_sEmpresaInstaladora, true, false) + ","
                    + Data.String2Sql(_sNAbonado, true, false) + ","
                    + Data.String2Sql(_sTipoPanel, true, false) + ","
                    + Data.String2Sql(_sFechaAlta, true, false) + ","
                    + Data.String2Sql(_sNombreRazonSocial, true, false) + ","
                    + Data.String2Sql(_sDireccion, true, false) + ","
                    + Data.String2Sql(_sLocalidad, true, false) + ","
                    + Data.String2Sql(_sProvincia, true, false) + ","
                    + Data.String2Sql(_sCopo, true, false) + ","
                    + Data.String2Sql(tlfn[0], true, false) + ","
                    + Data.String2Sql(tlfn[1], true, false) + ","
                    + Data.String2Sql(tlfn[2], true, false) + ","
                    + Data.String2Sql(_sEmail, true, false) + ","
                    + Data.String2Sql(_sViaPrincipal, true, false) + ","
                    + Data.String2Sql(_sModeloPrincipal, true, false) + ","
                    + Data.String2Sql(_sFormatoPrincipal, true, false) + ","
                    + Data.String2Sql(_sTestPrincipal, true, false) + ","
                    + Data.String2Sql(_sViaSecundaria, true, false) + ","
                    + Data.String2Sql(_sModeloSecundaria, true, false) + ","
                    + Data.String2Sql(_sFormatoSecundaria, true, false) + ","
                    + Data.String2Sql(_sTestSecundaria, true, false) + ","
                    + Data.String2Sql(_sCctvIp, true, false) + ","
                    + Data.String2Sql(_sCctvIpModelo, true, false) + ","
                    + Data.String2Sql(_sIPCliente, true, false) + ","
                    + Data.String2Sql(_sCctvIpPuerto, true, false) + ","
                    + Data.String2Sql(_sIMEI, true, false) + ","
                    + Data.String2Sql(_sConsignaGlobal, true, false) + ","
                    + Data.String2Sql(_sConsignaCoaccion, true, false) + ","
                    + Data.String2Sql(_sConsignaCRA, true, false) + ","
                    + Data.String2Sql(_sComentarios, true, false) + ","
                    + Data.String2Sql(_sCctv, true, false) + ","
                    + Data.String2Sql(_sUsuario, true, false) + ","
                    + "AES_ENCRYPT(" + Data.String2Sql(_sContrasena, true, false) + "," + Data.String2Sql(_sllave, true, false) + "),"
                    + "AES_ENCRYPT(" + Data.String2Sql(_sllave, true, false) + "," + Data.String2Sql(_sNAbonado, true, false) + "));" +
                    "SELECT LAST_INSERT_ID()";

                int id = db.insertar(sSql);
                db.cerrarConexion();

                return new FichaAbonado(id);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public static FichaAbonado update(int _iId,string _sEmpresaInstaladora, string _sNAbonado, string _sTipoPanel, string _sFechaAlta,
                                    string _sNombreRazonSocial, string _sDireccion, string _sLocalidad, string _sProvincia, string _sCopo,
                                    string [] _aTelefonos, string _sEmail, string _sViaPrincipal, string _sModeloPrincipal,
                                    string _sFormatoPrincipal, string _sTestPrincipal, string _sViaSecundaria, string _sModeloSecundaria,
                                    string _sFormatoSecundaria, string _sTestSecundaria, string _sCctvIp,
                                    string _sCctvIpModelo, string _sIPCliente, string _sCctvIpPuerto, string _sIMEI,
                                    string _sConsignaGlobal, string _sConsignaCoaccion, string _sConsignaCRA, string _sComentarios,
                                    string _sCctv, string _sUsuario, string _sContrasena, string _sContrasenaRep, string _sllave, string _sllaveRep)
        {

            try
            {

                String sSql = "UPDATE `fichaabonado` SET " +
                    "`empresaInstaladora`="+Data.String2Sql(_sEmpresaInstaladora,true,false)+"," +
                    "`n_abonado`=" + Data.String2Sql(_sNAbonado, true, false) + "," +
                    "`tipoPanel`=" + Data.String2Sql(_sTipoPanel, true, false) + "," +
                    "`fechaAlta`=" + Data.String2Sql(_sFechaAlta, true, false) + "," +
                    "`nombreRazon`=" + Data.String2Sql(_sNombreRazonSocial, true, false) + "," +
                    "`direccion`=" + Data.String2Sql(_sDireccion, true, false) + "," +
                    "`localidad`=" + Data.String2Sql(_sLocalidad, true, false) + "," +
                    "`provincia`=" + Data.String2Sql(_sProvincia, true, false) + "," +
                    "`copo`=" + Data.String2Sql(_sCopo, true, false) + "," +
                    "`telefono1`=" + Data.String2Sql(_aTelefonos[0], true, false) + "," +
                    "`telefono2`=" + Data.String2Sql(_aTelefonos[1], true, false) + "," +
                    "`telefono3`=" + Data.String2Sql(_aTelefonos[2], true, false) + "," +
                    "`email`=" + Data.String2Sql(_sEmail, true, false) + "," +
                    "`viaPrincipal`=" + Data.String2Sql(_sViaPrincipal, true, false) + "," +
                    "`modeloPrincipal`=" + Data.String2Sql(_sModeloPrincipal, true, false) + "," +
                    "`formatoPrincipal`=" + Data.String2Sql(_sFormatoPrincipal, true, false) + "," +
                    "`testPrincipal`=" + Data.String2Sql(_sTestPrincipal, true, false) + "," +
                    "`viaSecundaria`=" + Data.String2Sql(_sViaSecundaria, true, false) + "," +
                    "`modeloSecundaria`=" + Data.String2Sql(_sModeloSecundaria, true, false) + "," +
                    "`formatoSecundaria`=" + Data.String2Sql(_sFormatoSecundaria, true, false) + "," +
                    "`testSecundaria`=" + Data.String2Sql(_sTestSecundaria, true, false) + "," +
                    "`cctvip`=" + Data.String2Sql(_sCctvIp, true, false) + "," +
                    "`modeloCctvip`=" + Data.String2Sql(_sCctvIpModelo, true, false) + "," +
                    "`ipCliente`=" + Data.String2Sql(_sIPCliente, true, false) + "," +
                    "`puerto`=" + Data.String2Sql(_sCctvIpPuerto, true, false) + "," +
                    "`imei`=" + Data.String2Sql(_sIMEI, true, false) + "," +
                    "`consignaGlobal`=" + Data.String2Sql(_sConsignaGlobal, true, false) + "," +
                    "`consignaCoaccion`=" + Data.String2Sql(_sConsignaCoaccion, true, false) + "," +
                    "`consignaCRA`=" + Data.String2Sql(_sConsignaCRA, true, false) + "," +
                    "`comentarios`=" + Data.String2Sql(_sComentarios, true, false) + "," +
                    "`cctv`=" + Data.String2Sql(_sCctv, true, false) + "," +
                    "`usuario`=" + Data.String2Sql(_sUsuario, true, false) + "," +
                    "`password`=" + "AES_ENCRYPT(" + Data.String2Sql(_sContrasena, true, false) + "," + Data.String2Sql(_sllave, true, false) + ")" + "," +
                    "`llave`=" + "AES_ENCRYPT(" + Data.String2Sql(_sllave, true, false) + "," + Data.String2Sql(_sNAbonado, true, false) + ")" + " WHERE id = " + _iId;

                Clipboard.SetText(sSql);

                db = new DBSesion();
                db.abrirConexion();
                db.actualizar(sSql);
                db.cerrarConexion();

                return new FichaAbonado(_iId);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        static public void error_test(string _sEmpresaInstaladora, string _sNAbonado, string _sTipoPanel, string _sFechaAlta,
                                    string _sNombreRazonSocial, string _sDireccion, string _sLocalidad,string _sProvincia, string _sCopo,
                                    string [] _aTelefonos,string _sEmail,  string _sViaPrincipal, string _sModeloPrincipal,
                                    string _sFormatoPrincipal, string _sTestPrincipal, string _sViaSecundaria, string _sModeloSecundaria,
                                    string _sFormatoSecundaria, string _sTestSecundaria, string _sCctvIp,
                                    string _sCctvIpModelo, string _sIPCliente, string _sCctvIpPuerto, string _sIMEI,
                                    string _sConsignaGlobal, string _sConsignaCoaccion, string _sConsignaCRA, string _sComentarios,
                                    string _sCctv, string _sUsuario, string _sContrasena, string _sContrasenaRep, string _sllave, string _sllaveRep)
        {
            string sFecha = "[0-9]{4}-[0-9]{2}-[0-9]{2}";
            string sCp = "[0-9]";
            string sTelefono = "[0-9+]{9,12}";
            string sEmail = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$";

            db = new DBSesion();
            db.abrirConexion();

            if (sCp.Length < 2) throw new Exception("El cp debe ser válido.");

           /* MySqlDataReader myReader = db.consultar("select provincia from municipios where municipio LIKE " + Data.String2Sql(_sProvincia, true, false)
                                                    + "AND provincia = " + Convert.ToInt32(sCp.Substring(0, 2)));*/

            Match mFecha = Regex.Match(_sFechaAlta, sFecha);
            Match mCp = Regex.Match(_sCopo, sCp);
            Match mEmail = Regex.Match(_sEmail, sEmail);
            Match[] mTelefonos =
            {
               (_aTelefonos[0].Equals(""))?Regex.Match("666666666",sTelefono):Regex.Match(_aTelefonos[0],sTelefono),
               (_aTelefonos[1].Equals(""))?Regex.Match("666666666",sTelefono):Regex.Match(_aTelefonos[1],sTelefono),
               (_aTelefonos[2].Equals(""))?Regex.Match("666666666",sTelefono):Regex.Match(_aTelefonos[2],sTelefono),
            };

            if (_sEmpresaInstaladora.Equals("")) throw new Exception("El campo de empresa instaladora no puede ser nulo.");
            if (_sNAbonado.Equals("")) throw new Exception("El campo de número de abonado no puede ser nulo.");
            if (_sTipoPanel.Equals("")) throw new Exception("El campo del tipo panel no puede ser nulo.");

            if (_sFechaAlta.Equals("")) throw new Exception("El campo de fecha de alta no puede ser nulo.");
            else if (!mFecha.Success) throw new Exception("La fecha de alta debe de ser una fecha válida.");

            if (_sNombreRazonSocial.Equals("")) throw new Exception("El nombre o razón social no puede ser nulo.");
            if (_sDireccion.Equals("")) throw new Exception("La dirección no puede ser nula.");
            if (_sLocalidad.Equals("")) throw new Exception("La localidad no puede ser nula.");

            if (_sCopo.Equals("")) throw new Exception("El Cp no puede ser nulo.");
            else if (/*!myReader.Read() ||*/ !mCp.Success) throw new Exception("El cp debe de ser válido.");

            if (_aTelefonos[0].Equals("") && _aTelefonos[1].Equals("") && _aTelefonos[2].Equals("")) throw new Exception("Los teléfonos no pueden ser nulos.");
            else if (!mTelefonos[0].Success && !mTelefonos[1].Success && !mTelefonos[2].Success) throw new Exception("Alguno de los teléfonos es correcto.");

            if (!_sEmail.Equals("") && !mEmail.Success) throw new Exception("El email debe de ser un email válido.");

            if (_sConsignaGlobal.Equals("")) throw new Exception("La consigna global no puede ser nula.");
            if (!_sContrasena.Equals(_sContrasenaRep)) new Exception("Las contraseñas no coinciden");
            if (!_sllave.Equals(_sllaveRep)) new Exception("Las llaves no coinciden");
        }

        public static ArrayList consultar(string sNumeroAbonado = "", string sFechaAlta = "", string sNombre = ""
            , string sLocalidad = "", string sCodigoPostal = "")
        {
            try
            {
                db = new DBSesion();
                db.abrirConexion();

                ArrayList fichaAbonado = new ArrayList();

                string sSql = "select * from fichaabonado WHERE "
                    + "n_abonado LIKE " + Data.String2Sql(sNumeroAbonado, true, true,true) + " AND "
                    + "fechaAlta LIKE " + Data.String2Sql(sFechaAlta, true, true,true) + " AND "
                    + "nombreRazon LIKE " + Data.String2Sql(sNombre, true, true,true) + " AND "
                    + "localidad LIKE" + Data.String2Sql(sLocalidad, true, true,true) + " AND "
                    + "copo LIKE " + Data.String2Sql(sCodigoPostal, true, true,true);
                Clipboard.SetText(sSql);
                MySqlDataReader myReader = db.consultar(sSql);

                while (myReader.Read())
                {
                    fichaAbonado.Add(new FichaAbonado(myReader.GetInt32("id")));
                }
                return fichaAbonado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Contrato consultar_contrato(string sNAbonado)
        {

            try
            {
                string sSql = "select id from contrato where n_abonado like " + Data.String2Sql(sNAbonado, true, false);

                db = new DBSesion();

                db.abrirConexion();

                MySqlDataReader myDataReader = db.consultar(sSql);

                if (myDataReader.Read())
                {
                    return new Contrato(Convert.ToInt32(myDataReader.GetInt32("id")));
                }
                else
                {
                    MessageBox.Show("La ficha de abonado aún no está vinculada a ningún contrato.", "Información sobre vinculación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return null;
                }


            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public ArrayList consultar_zona()
        {
            try
            {

                String sSql = "select id from zona where id_fichaAbonado = " + _iId;

                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar(sSql);

                while (myReader.Read())
                {
                    _aZonas.Add(new Zona(myReader.GetInt32("id")));
                }

                db.cerrarConexion();

            }catch(Exception ex)
            {
                throw ex;
            }

            return _aZonas;
        }

        public ArrayList consultar_contactos()
        {
            try
            {

                String sSql = "select id from listacontactos where id_fichaAbonado = " + _iId;

                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar(sSql);

                while (myReader.Read())
                {
                    _aContactos.Add(new ListaContactos(myReader.GetInt32("id")));
                }

                db.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _aContactos;
        }

        public int IId { get => _iId; set => _iId = value; }
        public string SEmpresaInstaladora { get => _sEmpresaInstaladora; set => _sEmpresaInstaladora = value; }
        public string SNAbonado { get => _sNAbonado; set => _sNAbonado = value; }
        public string STipoPanel { get => _sTipoPanel; set => _sTipoPanel = value; }
        public string SFechaAlta { get => _sFechaAlta; set => _sFechaAlta = value; }
        public string SNombreRazonSocial { get => _sNombreRazonSocial; set => _sNombreRazonSocial = value; }
        public string SDireccion { get => _sDireccion; set => _sDireccion = value; }
        public string SLocalidad { get => _sLocalidad; set => _sLocalidad = value; }
        public string SCopo { get => _sCopo; set => _sCopo = value; }
        public string SViaPrincipal { get => _sViaPrincipal; set => _sViaPrincipal = value; }
        public string SModeloPrincipal { get => _sModeloPrincipal; set => _sModeloPrincipal = value; }
        public string SFormatoPrincipal { get => _sFormatoPrincipal; set => _sFormatoPrincipal = value; }
        public string STestPrincipal { get => _sTestPrincipal; set => _sTestPrincipal = value; }
        public string SViaSecundaria { get => _sViaSecundaria; set => _sViaSecundaria = value; }
        public string SModeloSecundaria { get => _sModeloSecundaria; set => _sModeloSecundaria = value; }
        public string SFormatoSecundaria { get => _sFormatoSecundaria; set => _sFormatoSecundaria = value; }
        public string STestSecundaria { get => _sTestSecundaria; set => _sTestSecundaria = value; }
        public string SIMEI { get => _sIMEI; set => _sIMEI = value; }
        public string SConsignaGlobal { get => _sConsignaGlobal; set => _sConsignaGlobal = value; }
        public string SConsignaCoaccion { get => _sConsignaCoaccion; set => _sConsignaCoaccion = value; }
        public string SConsignaCRA { get => _sConsignaCRA; set => _sConsignaCRA = value; }
        public string SComentarios { get => _sComentarios; set => _sComentarios = value; }
        public string SCctv { get => _sCctv; set => _sCctv = value; }
        public string SUsuario { get => _sUsuario; set => _sUsuario = value; }
        public string SContrasena { get => _sContrasena; set => _sContrasena = value; }
        public string SLlave { get => _sLlave; set => _sLlave = value; }
        public string SCctvIp { get => _sCctvIp; set => _sCctvIp = value; }
        public string SCctvIpModelo { get => _sCctvIpModelo; set => _sCctvIpModelo = value; }
        public string SCctvIpCliente { get => _sCctvIpCliente; set => _sCctvIpCliente = value; }
        public string SCctvIpPuerto { get => _sCctvIpPuerto; set => _sCctvIpPuerto = value; }
        public string STelefono1 { get => _sTelefono1; set => _sTelefono1 = value; }
        public string STelefono2 { get => _sTelefono2; set => _sTelefono2 = value; }
        public string STelefono3 { get => _sTelefono3; set => _sTelefono3 = value; }
        public string SEmail { get => _sEmail; set => _sEmail = value; }
        public string SProvincia { get => _sProvincia; set => _sProvincia = value; }

        public string getTelefonos(int i)
        {
            switch (i)
            {
                case 1: return _sTelefono1;break;
                case 2: return _sTelefono2;break;
                case 3: return _sTelefono3;break;

                default: return "";
            }
        }
    }
}
