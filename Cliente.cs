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
    public class Cliente
    {
        private int _iId;
        private String _sNombre;
        private String _sApellido;
        private String _sDni;
        private String _sTipoCliente;
        private String _sTipoVia;
        private String _sDireccion;
        private String _sNumero;
        private String _sPiso;
        private String _sProvincia;
        private String _sMunicipio;
        private String _sCp;
        private String _sTelefono;
        private String _sFechaInscripcion;
        private String _sEmail;

        private ArrayList _eEmpresa = new ArrayList();

        private static DBSesion db = null;

        public ArrayList EEmpresa { get => _eEmpresa; set => _eEmpresa = value; }

        public Cliente(int iId)
        {
           
            _iId = iId;

            try
            {
                db = new DBSesion();
                db.abrirConexion();


               MySqlDataReader myReader =  db.consultar("select * from clientes where id = " + iId);

                if (myReader.Read())
                {

                    _sNombre = myReader.GetString("nombre");
                    _sApellido = myReader.GetString("apellido");
                    _sDni = myReader.GetString("dni");
                    _sTipoCliente = myReader.GetString("tipoCliente");
                    _sTipoVia = myReader.GetString("tipoVia");
                    _sDireccion = myReader.GetString("direccion");
                    _sNumero = myReader.GetString("numero");
                    if (!myReader.IsDBNull(14)) _sPiso = myReader.GetString("piso");
                    _sProvincia = myReader.GetString("provincia");
                    _sMunicipio = myReader.GetString("ciudad");
                    _sCp = myReader.GetString("cp");
                    _sTelefono = myReader.GetString("telefono");
                    _sFechaInscripcion = myReader.GetString("fechaInscripcion");
                    if (!myReader.IsDBNull(13)) _sEmail = myReader.GetString("email");
                    if (!myReader.IsDBNull(14)) _sPiso = myReader.GetString("piso");

                    db.cerrarConexion();
                    db.abrirConexion();

                    MySqlDataReader myReaderAux = db.consultar("select id from empresas where id_cliente = "+iId);

                    while (myReaderAux.Read())
                    {
                        _eEmpresa.Add(new Empresa(myReaderAux.GetInt32("id")));
                    }

                    db.cerrarConexion();
                }
                else
                {
                    throw new Exception("No existe el cliente");
                }

                db.cerrarConexion();

            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static Cliente Create(String nombre, String apellido, String dni,String tipoCliente, String tipoVia, String direccion,
            String numero,String piso, String provincia,String municipio,String cp,String telefono, String FechaInscripcion, String email)
        {

            try
            {
                error_test(nombre, apellido, dni, tipoCliente, 
                    tipoVia, direccion, numero, provincia, municipio, cp,
             telefono, FechaInscripcion, email);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                String sSql = "insert into clientes (nombre,apellido,dni,tipoCliente,tipoVia,direccion,numero," +
                          "provincia,ciudad,cp,telefono,fechaInscripcion,email,piso) VALUES ("
                          + Data.String2Sql(nombre, true, false) + ","
                          + Data.String2Sql(apellido, true, false) + ","
                          + Data.String2Sql(dni, true, false) + ","
                          + Data.String2Sql(tipoCliente, true, false) + ","
                          + Data.String2Sql(tipoVia, true, false) + ","
                          + Data.String2Sql(direccion, true, false) + ","
                          + Data.String2Sql(numero, true, false) + ","
                          + Data.String2Sql(provincia, true, false) + ","
                          + Data.String2Sql(municipio, true, false) + ","
                          + Data.String2Sql(cp, true, false) + ","
                          + Data.String2Sql(telefono, true, false) + ","
                          + Data.String2Sql(FechaInscripcion, true, false) + ","
                          + Data.String2Sql(email, true, false) +","
                          +Data.String2Sql(piso,true,false)+");SELECT LAST_INSERT_ID()";



                db = new DBSesion();

                db.abrirConexion();
                int iId = db.insertar(sSql);
                db.cerrarConexion();
                return new Cliente(iId);
            }
            catch (Exception ex) { throw ex; }   

        }

        public static ArrayList consultar() {

            ArrayList aClientes = new ArrayList();

            try
            {
                

                String sSql = "Select * From clientes";

                db = new DBSesion();
                db.abrirConexion();

                MySqlDataReader myReader = db.consultar(sSql);

                Cliente cCliente;

                while (myReader.Read())
                {

                    cCliente  = new Cliente(myReader.GetInt32("id"));
                   aClientes.Add(cCliente);

                }

                db.cerrarConexion();

                

            }catch(Exception ex)
            {
                throw ex;
            }
            return aClientes;

        }


        public static ArrayList consultar(String sNombre, String sApellido, String sDni, String sTipoCliente, String sCif)
        {

            ArrayList aClientes = new ArrayList();
            try
            {
                String sSql = "Select * From clientes";

                sSql += where(sNombre, sApellido, sDni, sTipoCliente);

                db = new DBSesion();
                db.abrirConexion();

                MySqlDataReader myReader = db.consultar(sSql);


                while (myReader.Read())
                {
                    Cliente cCliente = new Cliente(myReader.GetInt32("id"));

                    if (cCliente.getTipoCliente().Equals("Empresa")){
                            for (int i = 0; i < cCliente.EEmpresa.Count; i++)
                            {
                                Empresa e = (Empresa)cCliente.EEmpresa[i];

                                if (e.SCif.Contains(sCif))
                                    aClientes.Add(cCliente);
                            }

                    }else{
                        if(sCif.Equals(""))
                            aClientes.Add(cCliente);
                    }
                    

                }

                db.cerrarConexion();

                return aClientes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Cliente actualizar(int iId,String nombre, String apellido, String dni, String tipoCliente, String tipoVia, String direccion,
            String numero, String piso, String provincia, String municipio, String cp, String telefono, String email)
        {

            try
            {
                error_test(nombre, apellido, dni, tipoCliente,
                    tipoVia, direccion, numero, provincia, municipio, cp,
             telefono, "1999-01-01", email);

                String sSql = "UPDATE `clientes` SET " +
                              "`nombre`="+Data.String2Sql(nombre,true,false)+"," +
                              "`apellido`=" + Data.String2Sql(apellido, true, false) + "," +
                              "`dni`=" + Data.String2Sql(dni, true, false) + "," +
                              "`tipoCliente`=" + Data.String2Sql(tipoCliente, true, false) + "," +
                              "`tipoVia`="+Data.String2Sql(tipoVia,true,false)+"," +
                              "`direccion`="+Data.String2Sql(direccion,true,false)+"," +
                              "`numero`="+Data.String2Sql(numero,true,false)+"," +
                              "`provincia`="+Data.String2Sql(provincia,true,false)+"," +
                              "`ciudad`="+Data.String2Sql(municipio,true,false)+"," +
                              "`cp`="+Data.String2Sql(cp,true,false)+"," +
                              "`telefono`="+Data.String2Sql(telefono,true,false)+"," +
                              "`email`="+Data.String2Sql(email,true,false)+"," +
                              "`piso`="+Data.String2Sql(piso,true,false)+" WHERE id = " + iId;

                db = new DBSesion();
                db.abrirConexion();
                db.actualizar(sSql);

                db.cerrarConexion();

                return new Cliente(iId);

            }
            catch(Exception ex){
                throw ex;
            }

        }
        public static String where(String sNombre, String sApellido, String sDni, String sTipoCliente)
        {

            String sSql = " WHERE ";

            if (!sNombre.Equals("")) sSql += "nombre LIKE " + Data.String2Sql(sNombre, true, true)+" AND ";
            if(!sApellido.Equals("")) sSql += "apellido LIKE " + Data.String2Sql(sApellido, true, true) + " AND ";
            if(!sDni.Equals("")) sSql += "dni LIKE " + Data.String2Sql(sDni, true, true) + " AND ";
            if(!sTipoCliente.Equals("")) sSql += "tipoCliente LIKE " + Data.String2Sql(sTipoCliente, true, true) + " AND ";

            return sSql.Count() == 7 ? "" : sSql.Substring(0, sSql.Count() - 4);
        }

        public static void error_test(String sNombre, String sApellido, String sDni, String sTipoCliente, String sTipoVia,String sDireccion, 
            String sNumero,String sProvincia,String sMunicipio,String sCp,String sTelefono, String sFechaInscripcion, String sEmail)
        {

            string pNumero = "[A-Za-z0-9]";
            string pDni = "[XYZ0-9]{8}[A-Z]{1}";
            string pTelefono = "[0-9]{9}";
            string pFechaInscripcion = "[0-9]{4}-[0-9]{2}-[0-9]{2}";
            string pEmail = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$";
            string pProvincia = "[a-zA-z]";
            string pCp = "[0-9]";

            db = new DBSesion();
            db.abrirConexion();

            if (sCp.Length < 2) throw new Exception("El cp debe ser válido.");

            MySqlDataReader myReader = db.consultar("select provincia from municipios where municipio LIKE "+Data.String2Sql(sProvincia,true,false)
                                                    +"AND provincia = "+Convert.ToInt32(sCp.Substring(0, 2)));


            Match mNumero = Regex.Match(sNumero, pNumero, RegexOptions.IgnoreCase);
            Match mDni = Regex.Match(sDni, pDni, RegexOptions.IgnoreCase);
            Match mTelefono = Regex.Match(sTelefono, pTelefono, RegexOptions.IgnoreCase);
            Match mFechaInscripcion = Regex.Match(sFechaInscripcion, pFechaInscripcion, RegexOptions.IgnoreCase);
            Match mEmail = Regex.Match(sEmail, pEmail, RegexOptions.IgnoreCase);
            Match mProvincia = Regex.Match(sProvincia, pProvincia, RegexOptions.IgnoreCase);
            Match mMunicipio = Regex.Match(sMunicipio, pProvincia, RegexOptions.IgnoreCase);
            Match mCp = Regex.Match(sCp, pCp, RegexOptions.IgnoreCase);

            if (sNombre.Equals("")) throw new Exception("El nombre no puede ser nulo.");

            if (sApellido.Equals("")) throw new Exception("El apellido no puede ser nulo.");

            if (sDni.Equals("")) throw new Exception("El dni no puede ser nulo.");
            else if (!mDni.Success) throw new Exception("El dni debe ser válido (8 caracteres numérico y 1 alfabetico).");

            if (sTipoCliente.Equals("")) throw new Exception("El tipo de cliente no puede ser nulo.");
            else if (!sTipoCliente.Equals("Empresa") && !sTipoCliente.Equals("Particular"))
                throw new Exception("El tipo de cliente debe se un tipo válido");

            if (sTelefono.Equals("")) throw new Exception("EL número de teléfono no puede ser nulo.");
            else if (!mTelefono.Success) throw new Exception("El numero de teléfono debe ser válido.");

            if (!sEmail.Equals("") && !mEmail.Success) throw new Exception("El email debe de ser un email válido.");

            if (sTipoVia.Equals("")) throw new Exception("El tipo de via no puede ser nulo.");

            if (sDireccion.Equals("")) throw new Exception("La dirección no puede ser una dirección nula.");

            if (sNumero.Equals("")) throw new Exception("El numero no puede ser nulo.");
            else if (!mNumero.Success) throw new Exception("EL numero debe de ser un numero válido.");

            if (sProvincia.Equals("")) throw new Exception("La provincia no puede ser nula");
            else if (!mProvincia.Success) throw new Exception("La provincia debe ser una provincia válida");

            if (sMunicipio.Equals("")) throw new Exception("El municipio no puede ser nulo");
            else if (!mMunicipio.Success) throw new Exception("El municipio debe ser un municipio válido");

            if (sCp.Equals("")) throw new Exception("El cp no puede ser nulo");
            else if (!myReader.Read() || !mCp.Success) throw new Exception("El cp debe ser un válido.");

            if (sFechaInscripcion.Equals("")) throw new Exception("La fecha de inscripcion no puede ser nula.");
            else if (!mFechaInscripcion.Success) throw new Exception("La fecha de inscripción debe de ser una fecha válida");

        }

        public int getId() { return _iId; }
        public String getNombre() { return _sNombre; }
        public String getApellido() { return _sApellido; }
        public String getDni() { return _sDni; }
        public String getTipoCliente() { return _sTipoCliente; }
        public String getTipoVia() { return _sTipoVia; }
        public String getDireccion() { return _sDireccion; }
        public String getNumero() { return _sNumero; }
        public String getProvincia() { return _sProvincia; }
        public String getMunicipio() { return _sMunicipio; }
        public String getCp() { return _sCp; }
        public String getTelefono() { return _sTelefono; }
        public String getFechaInscripcion() { return _sFechaInscripcion; }
        public String getEmail() {return _sEmail; }
        public void setEmail(String sEmail) { _sEmail = sEmail; }

        public String getPiso() { return _sPiso; }

    }
}
