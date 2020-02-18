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
    public class Anexo
    {
        private int _iId;
        private string _sCif;
        private String _sNumeroAnexo;
        private String _sNombre;
        private String _sFecha;
        private String _sRazonSocial;
        private String _sTipoVia;
        private String _sDireccion;
        private String _sNumero;
        private String _sPiso;
        private String _sCp;
        private String _sMunicipio;
        private String _sProvincia;
        private String _sRepresentanteNombre;
        private String _sRepresentantePuesto;
        private String _sRepresentanteDni;
        private String _sFirma;

        static DBSesion db = null;

        public int IId { get => _iId; set => _iId = value; }
        public string SNumeroAnexo { get => _sNumeroAnexo; set => _sNumeroAnexo = value; }
        public string SNombre { get => _sNombre; set => _sNombre = value; }
        public string SFecha { get => _sFecha; set => _sFecha = value; }
        public string SRazonSocial { get => _sRazonSocial; set => _sRazonSocial = value; }
        public string STipoVia { get => _sTipoVia; set => _sTipoVia = value; }
        public string SDireccion { get => _sDireccion; set => _sDireccion = value; }
        public string SNumero { get => _sNumero; set => _sNumero = value; }
        public string SPiso { get => _sPiso; set => _sPiso = value; }
        public string SCp { get => _sCp; set => _sCp = value; }
        public string SMunicipio { get => _sMunicipio; set => _sMunicipio = value; }
        public string SProvincia { get => _sProvincia; set => _sProvincia = value; }
        public string SRepresentanteNombre { get => _sRepresentanteNombre; set => _sRepresentanteNombre = value; }
        public string SRepresentantePuesto { get => _sRepresentantePuesto; set => _sRepresentantePuesto = value; }
        public string SRepresentanteDni { get => _sRepresentanteDni; set => _sRepresentanteDni = value; }
        public string SFirma { get => _sFirma; set => _sFirma = value; }
        public string SCif { get => _sCif; set => _sCif = value; }

        public Anexo(int iId)
        {
            try
            {

                String sSql = "select * from anexos Where id = " + iId;

                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar(sSql);

                if (myReader.Read())
                {
                    if(!myReader.IsDBNull(1))
                    SNumeroAnexo = myReader.GetString("numeroAnexo");

                    if (!myReader.IsDBNull(2))
                        SCif = myReader.GetString("cif");

                    if (!myReader.IsDBNull(3))
                        SNombre = myReader.GetString("nombre");

                    if (!myReader.IsDBNull(4))
                        SFecha = myReader.GetString("fecha");

                    if (!myReader.IsDBNull(5))
                        SRazonSocial = myReader.GetString("razonSocial");

                    if (!myReader.IsDBNull(6))
                        STipoVia = myReader.GetString("tipoVia");

                    if (!myReader.IsDBNull(7))
                        SDireccion = myReader.GetString("direccion");

                    if (!myReader.IsDBNull(8))
                        SNumero = myReader.GetString("numero");

                    if (!myReader.IsDBNull(9))
                        if (!myReader.IsDBNull(8))SPiso = myReader.GetString("piso");

                    if (!myReader.IsDBNull(10))
                        SCp = myReader.GetString("cp");

                    if (!myReader.IsDBNull(11))
                        SMunicipio = myReader.GetString("municipio");

                    if (!myReader.IsDBNull(12))
                        SProvincia = myReader.GetString("provincia");

                    if (!myReader.IsDBNull(13))
                        SRepresentanteNombre = myReader.GetString("representanteNombre");

                    if (!myReader.IsDBNull(14))
                        SRepresentantePuesto = myReader.GetString("representantePuesto");

                    if (!myReader.IsDBNull(15))
                        SRepresentanteDni = myReader.GetString("representanteDni");

                    if (!myReader.IsDBNull(16))
                        SFirma = myReader.GetString("firma");

                    IId = myReader.GetInt32("id");
                }
                else throw new Exception("Fallo en la consulta del anexo en la base de datos.");

                db.cerrarConexion();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static Anexo create(String sNumeroAnexo,String sCif, String sNombre, String sFecha, String sRazonSocial, String sTipoVia, String sDireccion, String sNumero,
        String sPiso, String sCp, String sMunicipio, String sProvincia, String sRepresentanteNombre, String sRepresentantePuesto, String sRepresentanteDni, String sFirma)
        {

            int iId;

            try                    
            {
                error_test( sNumeroAnexo,sCif,  sNombre,  sFecha,  sRazonSocial, sTipoVia,  sDireccion,  sNumero,
         sPiso,  sCp,  sMunicipio,  sProvincia,  sRepresentanteNombre,  sRepresentantePuesto,  sRepresentanteDni,  sFirma);

                String sSql = "INSERT INTO `anexos`(`numeroAnexo`,`cif`, `nombre`, `fecha`, `razonSocial`, `tipoVia`, " +
                    "`direccion`, `numero`, `piso`, `cp`, `municipio`, `provincia`, `representanteNombre`, " +
                    "`representantePuesto`, `representanteDni`, `firma`) " +
                    "VALUES (" +
                     Data.String2Sql(sNumeroAnexo, true, false) + "," +
                     Data.String2Sql(sCif, true, false) + "," +
                    Data.String2Sql(sNombre, true, false) + "," +
                     Data.String2Sql(sFecha, true, false) + "," +
                     Data.String2Sql(sRazonSocial, true, false) + "," +
                     Data.String2Sql(sTipoVia, true, false) + "," +
                     Data.String2Sql(sDireccion, true, false) + "," +
                    Data.String2Sql(sNumero, true, false) + "," +
                    Data.String2Sql(sPiso, true, false) + "," +
                     Data.String2Sql(sCp, true, false) + "," +
                     Data.String2Sql(sMunicipio, true, false) + "," +
                     Data.String2Sql(sProvincia, true, false) + "," +
                     Data.String2Sql(sRepresentanteNombre, true, false) + "," +
                     Data.String2Sql(sRepresentantePuesto, true, false) + "," +
                     Data.String2Sql(sRepresentanteDni, true, false) + "," +
                    Data.String2Sql(sFirma, true, false) + ");SELECT LAST_INSERT_ID()";

                db = new DBSesion();
                db.abrirConexion();
                iId = db.insertar(sSql);
                db.cerrarConexion();

            }
            catch(Exception ex)   
            {
                throw ex;          
            }

            return new Anexo(iId);
        }
        
        public static ArrayList consultar()
        {
            ArrayList aAnexos = new ArrayList();

            try
            {

                String sSql = "select * from anexos";

                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar(sSql);
               
                while (myReader.Read())
                {
                    aAnexos.Add(new Anexo(myReader.GetInt32("id")));
                }

            }catch(Exception ex)
            {
                throw ex;
            }

            db.cerrarConexion();

            return aAnexos;
        }

        public static void error_test(String sNumeroAnexo, string sCif,String sNombre, String sFecha, String sRazonSocial, String sTipoVia, String sDireccion, String sNumero,
        String sPiso, String sCp, String sMunicipio, String sProvincia, String sRepresentanteNombre, String sRepresentantePuesto, String sRepresentanteDni, String sFirma,bool eEmpresa = false)
        {
            //AÑDIR EXPRESIONES REGULARES
            if (sNumeroAnexo.Equals(""))
                throw new Exception("El número del anexo no puede ser nulo.");

            if (sFecha.Equals(""))
                throw new Exception("La fecha del anexo no puede ser nula.");

            if (sRazonSocial.Equals("") && eEmpresa)
                throw new Exception("La razón social no puede ser nula.");

            if (sTipoVia.Equals(""))
                throw new Exception("El tipo de vía no puede ser nulo.");

            if (sDireccion.Equals(""))
                throw new Exception("La dirección no puede ser nula.");

            if (sNumero.Equals(""))
                throw new Exception("El numero no puede ser nulo.");

            if (sCp.Equals(""))
                throw new Exception("El código postal no puede ser nulo.");

            if (sMunicipio.Equals(""))
                throw new Exception("El municipio no puede ser nulo.");

            if (sProvincia.Equals(""))
                throw new Exception("La provincia no puede ser nula.");

            if (sRepresentanteNombre.Equals(""))
                throw new Exception("El nombre del representante no puede ser nulo.");

            if (sRepresentantePuesto.Equals("") && eEmpresa)
                throw new Exception("El puesto del representante no puede ser nulo.");

            if (sRepresentanteDni.Equals(""))
                throw new Exception("El dni del representante no puede ser nulo.");
        }
         
        public static Anexo actualizar(int iId,String sNumeroAnexo,String sCif, String sNombre, String sFecha, String sRazonSocial, String sTipoVia, String sDireccion, String sNumero,
        String sPiso, String sCp, String sMunicipio, String sProvincia, String sRepresentanteNombre, String sRepresentantePuesto, String sRepresentanteDni, String sFirma,bool eEmpresa = false)
        {
            try
            {
                error_test(sNumeroAnexo,sCif,sNombre,sFecha,sRazonSocial,sTipoVia,sDireccion,sNumero,
                           sPiso,sCp,sMunicipio,sProvincia,sRepresentanteNombre,sRepresentantePuesto,sRepresentanteDni,sFirma,eEmpresa);

                String sSql = "UPDATE `anexos` SET " +
                              "`numeroAnexo`=" + Data.String2Sql(sNumeroAnexo, true, false) + "," +
                              "`cif`=" + Data.String2Sql(sCif, true, false) + "," +
                              "`nombre`=" + Data.String2Sql(sNombre, true, false) + "," +
                              "`fecha`=" + Data.String2Sql(sFecha, true, false) + "," +
                              "`razonSocial`=" + Data.String2Sql(sRazonSocial, true, false) + "," +
                              "`tipoVia`=" + Data.String2Sql(sTipoVia, true, false) + "," +
                              "`direccion`=" + Data.String2Sql(sDireccion, true, false) + "," +
                              "`numero`=" + Data.String2Sql(sNumero, true, false) + "," +
                              "`piso`=" + Data.String2Sql(sPiso, true, false) + "," +
                              "`cp`=" + Data.String2Sql(sCp, true, false) + "," +
                              "`municipio`=" + Data.String2Sql(sMunicipio, true, false) + "," +
                              "`provincia`=" + Data.String2Sql(sProvincia, true, false) + "," +
                              "`representanteNombre`=" + Data.String2Sql(sRepresentanteNombre, true, false) + "," +
                              "`representantePuesto`=" + Data.String2Sql(sRepresentantePuesto, true, false) + "," +
                              "`representanteDni`=" + Data.String2Sql(sRepresentanteDni, true, false) + "," +
                              "`firma`=" + Data.String2Sql(sFirma, true, false) + " WHERE id = " + iId;

                db = new DBSesion();
                db.abrirConexion();
                db.actualizar(sSql);
                db.cerrarConexion();

                return new Anexo(iId);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }                              
}                                  
                                   
                                   
                                   