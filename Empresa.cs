using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace NearSystemsSolutions
{
    class Empresa
    {
        private int _iId;
        private int _iIdCliente;
        private String _sCif;
        private String _sRazonSocial;
        private String _sTipoVia;
        private String _sDireccion;
        private String _sNumero = "";
        private String _sPiso = "";
        private String _sCp;
        private String _sProvincia;
        private String _sMunicipio;
        private String _sNombreNotario;
        private string _sProvinciaNotario;
        private String _sMunicipioNotario;
        private String _sNumeroProtocolo;
        private String _sFechaNotario;

       private static DBSesion db = null;

       public Empresa(int iId) {

            try
            {
                String sSql = "select * from empresas where id = " + iId;

                db = new DBSesion();
                db.abrirConexion();

              MySqlDataReader myReader = db.consultar(sSql);

                if (myReader.Read())
                {
                    if (!myReader.IsDBNull(1)) _iIdCliente = myReader.GetInt32("id_cliente");
                    else throw new Exception("Fallo en la consulta del campo cliente en la empresa.");

                    if (!myReader.IsDBNull(2)) _sCif = myReader.GetString("cif");
                    else throw new Exception("Fallo en la consulta del campo cif.");

                    if (!myReader.IsDBNull(3)) _sRazonSocial = myReader.GetString("razonSocial");
                    else throw new Exception("Fallo en la consulta de razón social.");

                    if (!myReader.IsDBNull(4)) _sTipoVia = myReader.GetString("tipoVia");
                    else throw new Exception("Fallo en la consulta del tipo de vía.");

                    if (!myReader.IsDBNull(5)) _sDireccion = myReader.GetString("direccion");
                    else throw new Exception("Fallo en la consulta de la dirección.");

                    if (!myReader.IsDBNull(6)) _sNumero = myReader.GetString("numero");
                    else throw new Exception("Fallo en la consulta del número");

                    if (!myReader.IsDBNull(7)) _sPiso = myReader.GetString("piso");

                    if (!myReader.IsDBNull(8)) _sCp = myReader.GetString("cp");
                    else throw new Exception("Fallo en la consulta del cp.");

                    if (!myReader.IsDBNull(9)) _sProvincia = myReader.GetString("provincia");
                    else throw new Exception("Fallo en la consulta de la provincia.");

                    if (!myReader.IsDBNull(10)) _sMunicipio = myReader.GetString("municipio");
                    else throw new Exception("Fallo en la consulta del municipio.");

                    if (!myReader.IsDBNull(11)) _sNombreNotario = myReader.GetString("nombreNotario");
                    else throw new Exception("Fallo en la consulta del nombre de notario.");

                    if (!myReader.IsDBNull(12)) _sMunicipioNotario = myReader.GetString("municipioNotario");
                    else throw new Exception("Fallo en la consulta del municipio del notario.");

                    if (!myReader.IsDBNull(13)) _sNumeroProtocolo = myReader.GetString("protocoloNotario");
                    else throw new Exception("Fallo en la consulta del protocolo de notario.");

                    if (!myReader.IsDBNull(14)) _sFechaNotario = myReader.GetString("fechaNotario");
                    else throw new Exception("Fallo en la consulta de la fecha de notario.");

                    if (!myReader.IsDBNull(15)) SProvinciaNotario = myReader.GetString("provinciaNotario");
                    else throw new Exception("Fallo en la carga de la provincia del notario.");

                    _iId = iId;

                    db.cerrarConexion();
                    myReader.Close();

                }
                else
                {
                    db.cerrarConexion();
                    myReader.Close();

                    throw new Exception("La empresa no existe en la base de datos o no se ha insertado correctamente.");
                }

            }catch(Exception ex)
            {
                throw ex;
            }


        }



        public string SCif { get => SCif1; set => SCif1 = value; }
        public int IId { get => _iId; set => _iId = value; }
        public int IIdCliente { get => _iIdCliente; set => _iIdCliente = value; }
        public string SCif1 { get => _sCif; set => _sCif = value; }
        public string SRazonSocial { get => _sRazonSocial; set => _sRazonSocial = value; }
        public string STipoVia { get => _sTipoVia; set => _sTipoVia = value; }
        public string SDireccion { get => _sDireccion; set => _sDireccion = value; }
        public string SNumero { get => _sNumero; set => _sNumero = value; }
        public string SPiso { get => _sPiso; set => _sPiso = value; }
        public string SCp { get => _sCp; set => _sCp = value; }
        public string SProvincia { get => _sProvincia; set => _sProvincia = value; }
        public string SMunicipio { get => _sMunicipio; set => _sMunicipio = value; }
        public string SNombreNotario { get => _sNombreNotario; set => _sNombreNotario = value; }
        public string SMunicipioNotario { get => _sMunicipioNotario; set => _sMunicipioNotario = value; }
        public string SNumeroProtocolo { get => _sNumeroProtocolo; set => _sNumeroProtocolo = value; }
        public string SFechaNotario { get => _sFechaNotario; set => _sFechaNotario = value; }
        public string SProvinciaNotario { get => _sProvinciaNotario; set => _sProvinciaNotario = value; }

        public static Empresa create(int iIdCliente, String sCif, String sRazonSocial, String sTipoVia, String sDireccion, String sNumero, String sPiso, String sCp,
            String sProvincia, String sMunicipio, String sNombreNotario,string sProvinciaNotario, String sMunicipioNotario, String sNumeroProtocolo, String sFechaNotario)
        {
            try
            {
                error_test( sCif, sRazonSocial, sTipoVia, sDireccion, sNumero, sPiso, sCp,
              sProvincia, sMunicipio, sNombreNotario,sProvinciaNotario, sMunicipioNotario, sNumeroProtocolo, sFechaNotario);

                String sSql = "INSERT INTO `empresas`" +
                    "(`id_cliente`, `cif`, `razonSocial`, `tipoVia`, `direccion`, `numero`, `piso`, `cp`, " +
                    "`provincia`, `municipio`, `nombreNotario`,`provinciaNotario`, `municipioNotario`, `protocoloNotario`, `fechaNotario`) " +
                    "VALUES (" 
                    +iIdCliente +","
                   +Data.String2Sql(sCif,true,false) +","
                    + Data.String2Sql(sRazonSocial, true, false) + ","
                   + Data.String2Sql(sTipoVia, true, false) + ","
                    + Data.String2Sql(sDireccion, true, false) + ","
                   + Data.String2Sql(sNumero, true, false) + ","
                   + Data.String2Sql(sPiso, true, false) + ","
                    + Data.String2Sql(sCp, true, false) + ","
                   + Data.String2Sql(sProvincia, true, false) + ","
                   + Data.String2Sql(sMunicipio, true, false) + ","
                   + Data.String2Sql(sNombreNotario, true, false) + ","
                   + Data.String2Sql(sProvinciaNotario, true, false) + ","
                    + Data.String2Sql(sMunicipioNotario, true, false) + ","
                    + Data.String2Sql(sNumeroProtocolo, true, false) + ","
                    + Data.String2Sql(sFechaNotario, true, false)+");SELECT LAST_INSERT_ID()";


                db = new DBSesion();



                db.abrirConexion();

                int iId = db.insertar(sSql);

                db.cerrarConexion();

                return new Empresa(iId);

            }
            catch(Exception ex)
            {
                throw ex;
            }           
        }

        //IMPLEMENTAR ERROR TEST
        static public void error_test( String sCif, String sRazonSocial, String sTipoVia, String sDireccion, String sNumero, String sPiso, String sCp,
            String sProvincia, String sMunicipio, String sNombreNotario,string sProvinciaNotario, String sMunicipioNotario, String sNumeroProtocolo, String sFechaNotario)
        {

            string pCif = "[ABCDEFGHJKLMNPQRSUVW]{1}[0-9A-J]{8}";
            string pNumero = "[0-9SN/]";
            string pPiso = "[0-9a-zA-Z]";
            string pProvincia = "[A-Za-z´]";
            string pFecha = "[0-9]{4}-[0-9]{2}-[0-9]{2}";

            Match mCif = Regex.Match(sCif, pCif,RegexOptions.IgnoreCase);
            Match mNumero = Regex.Match(sNumero, pNumero, RegexOptions.IgnoreCase);
            Match mPiso = Regex.Match(sPiso, pPiso, RegexOptions.IgnoreCase);
            Match mCp = Regex.Match(sCp, pNumero, RegexOptions.IgnoreCase);
            Match mFecha = Regex.Match(sFechaNotario, pFecha, RegexOptions.IgnoreCase);

            if (sCif.Equals(""))
                throw new Exception("El cif no puede ser nulo.");
            else if (!mCif.Success)
                throw new Exception("El cif debe ser un cif válido.");

            if (sRazonSocial.Equals(""))
                throw new Exception("La razon social no puede ser nula.");

            if (sTipoVia.Equals(""))
                throw new Exception("Debe seleccionar un tipo de vía de la empresa");

            if (sDireccion.Equals(""))
                throw new Exception("La dirección de la empresa no puede ser nula.");

            if (sNumero.Equals(""))
                throw new Exception("El número de la dirección de la empresa no puede ser nulo.");
            else if (!mNumero.Success)
                throw new Exception("El número de la dirección de la empresa debe ser válido.");

            if (!sPiso.Equals(""))
                if (!mPiso.Success)
                    throw new Exception("El piso de la dirección de la empresa debe ser un piso válido.");

            if (sCp.Equals(""))
                throw new Exception("El código postal de la empresa no puede ser nulo.");
            else if (!mCp.Success)
                throw new Exception("El código postal de la empresa debe de ser un código postal válido");

            if (sProvincia.Equals(""))
                throw new Exception("La provincia de la empresa no puede ser nulo");

            if (sMunicipio.Equals(""))
                throw new Exception("El municipio de la empresa no puede ser nulo.");

            if (sNombreNotario.Equals(""))
                throw new Exception("El nombre del notario no puede ser nulo.");

            if (sProvinciaNotario.Equals(""))
                throw new Exception("La provincia del notario no puede ser nula.");

            if (sMunicipioNotario.Equals(""))
                throw new Exception("El municipio del notario no puede ser nulo.");

            if (sNumeroProtocolo.Equals(""))
                throw new Exception("El numero de protocolo del notario no puede ser nulo.");

            if (sFechaNotario.Equals(""))
                throw new Exception("La fecha del notario no puede ser nula.");
            else if (!mFecha.Success)
                throw new Exception("La fecha de notario debe ser una fecha válida (AAAA-MM-DD)");
        }

        public static Empresa actualizar(int iId,int iIdCliente, String sCif, String sRazonSocial, String sTipoVia, String sDireccion, String sNumero, String sPiso, String sCp,
            String sProvincia, String sMunicipio, String sNombreNotario,String sProvinciaNotario, String sMunicipioNotario, String sNumeroProtocolo, String sFechaNotario)
        {
            try
            {
                //LLAMAR ERROR TEST

                String sSql = "UPDATE `empresas` SET " +
                    "`cif`="+Data.String2Sql(sCif,true,false)+"," +
                    "`razonSocial`=" + Data.String2Sql(sRazonSocial, true, false) + "," +
                    "`tipoVia`="+Data.String2Sql(sTipoVia,true,false)+"," +
                    "`direccion`="+Data.String2Sql(sDireccion,true,false)+"," +
                    "`numero`="+Data.String2Sql(sNumero,true,false)+"," +
                    "`piso`="+Data.String2Sql(sPiso,true,false)+"," +
                    "`cp`="+Data.String2Sql(sCp,true,false)+"," +
                    "`provincia`="+Data.String2Sql(sProvincia,true,false)+"," +
                    "`municipio`="+Data.String2Sql(sMunicipio,true,false)+"," +
                    "`nombreNotario`="+Data.String2Sql(sNombreNotario,true,false)+"," +
                    "`provinciaNotario`=" + Data.String2Sql(sProvinciaNotario, true, false) + "," +
                    "`municipioNotario`=" +Data.String2Sql(sMunicipioNotario,true,false)+"," +
                    "`protocoloNotario`="+Data.String2Sql(sNumeroProtocolo,true,false)+"," +
                    "`fechaNotario`="+Data.String2Sql(sFechaNotario,true,false)+" WHERE id = " + iId;

                db = new DBSesion();
                db.abrirConexion();
                db.actualizar(sSql);

                db.cerrarConexion();

                return new Empresa(iId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string[] consultar_empresa(String sCif)
        {
            try
            {

                string pNumero = "[0-9]";
                string pCif = "[ABCDEFGHJKLMNPQRSUVW]{1}[0-9A-J]{8}";

                Match mCif = Regex.Match(sCif, pCif, RegexOptions.IgnoreCase);

                if (mCif.Success)
                    sCif = mCif.Groups[0].Value.ToUpper();

                WebClient client = new WebClient();
                String sCode = client.DownloadString("https://www.einforma.com/servlet/app/prod/ETIQUETA_EMPRESA/nif/" + sCif);

                string sRazon = consultar_datos(sCode, "Denominaci&oacute");
                string sDireccion = consultar_datos(sCode, "Domicilio social actual:", true);
                string localidad = consultar_datos(sCode, "Localidad:");
                string sNumero = "";
                string sPiso = "";
                string sProvincia = "";
                int iTipoVia = -1;
                int iIdProvincia = 0;

                string[] sDatosDireccion;

                string[]  localidadAux = localidad.Split(' ');
                string sCp = localidadAux[0];
                localidad = "";

                for (int i = 1; i < localidadAux.Length - 1; i++)
                {

                    if (!localidadAux[i].Equals("("))
                        localidad += localidadAux[i] + " ";
                    else
                        break;
                }

                localidad = localidad.Substring(0, localidad.Length - 1);

                db = new DBSesion();
                db.abrirConexion();

                MySqlDataReader myReader = db.consultar("select provincia,id_provincia from provincias where id_provincia = " + Convert.ToInt32(sCp.Substring(0, 2)));

                if (myReader.Read())
                    if (!myReader.IsDBNull(0))
                    {
                        sProvincia = myReader.GetString("provincia");
                        iIdProvincia = myReader.GetInt32("id_provincia");
                    }
                

                db.cerrarConexion();
                db.abrirConexion();

                myReader = db.consultar("select `municipio` from municipios WHERE provincia = "
                                        +iIdProvincia+" AND  municipio LIKE " + Data.String2Sql(localidad, true, false));
                if (myReader.Read())
                    if (!myReader.IsDBNull(0))
                        localidad = myReader.GetString("municipio");
                //MEJORAR
                if (sDireccion.Contains(','))
                {
                    sDatosDireccion = sDireccion.Split(',');
                    sDireccion = sDatosDireccion[0];

                    if (sDireccion.Contains("CALLE"))
                    {
                        iTipoVia = 0;
                        sDireccion = sDireccion.Replace("CALLE ", "");

                    }else if (sDireccion.Contains("TRAVESÍA"))
                    {
                        iTipoVia = 2;
                        sDireccion = sDireccion.Replace("TRAVESÍA ","");

                    }else if (sDireccion.Contains("AVENIDA"))
                    {
                        iTipoVia = 1;
                        sDireccion = sDireccion.Replace("AVENIDA", "");

                    }else if (sDireccion.Contains("POLÍGONO"))
                    {
                        iTipoVia = 3;
                        sDireccion = sDireccion.Replace("POLÍGONO", "");
                    }
                    else if (sDireccion.Contains("URBANIZACIÓN"))
                    {
                        iTipoVia = 4;
                        sDireccion = sDireccion.Replace("URBANIZACIÓN", "");
                    }
                    else if (sDireccion.Contains("PASEO"))
                    {
                        iTipoVia = 5;
                        sDireccion = sDireccion.Replace("PASEO", "");
                    }
                    else if (sDireccion.Contains("CARRETERA"))
                    {
                        iTipoVia = 6;
                        sDireccion = sDireccion.Replace("CARRETERA", "");

                    }else if (sDireccion.Contains("PLAZA"))
                    {
                        iTipoVia = 7;
                        sDireccion = sDireccion.Replace("PLAZA", "");
                    }

                    if (sDatosDireccion[1].Contains('-'))
                    {
                        if (sDatosDireccion[1].Split('-')[0].Replace(" ", "").Contains("S/N"))
                            sNumero = "S/N";
                        else
                        {
                            sNumero = sDatosDireccion[1].Split('-')[0].Replace(" ", "");

                            Match mPiso = Regex.Match(sDatosDireccion[1].Split('-')[1], pNumero);

                            if (mPiso.Success)
                                sPiso = (mPiso.Groups)[0].Value.Replace(" ", "");
                        }

                    }
                    else
                        sNumero = sDatosDireccion[1].Replace(" ","");
                }

                string [] datos = {sCif, sRazon, sDireccion,sProvincia, localidad,sCp, sNumero, sPiso,iTipoVia.ToString() };

                return datos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static string consultar_datos(string source,string campo,bool direccion = false)
        {
            string sCode = source;
            string sDato;
            sCode = sCode.Substring(sCode.IndexOf(campo));

            if(!direccion)
              sDato = sCode.Substring(sCode.IndexOf("\"70%\">") + 6,sCode.IndexOf("</td></tr><tr>")- (sCode.IndexOf("\"70%\">")+6));
            else
              sDato = sCode.Substring(sCode.IndexOf("\"70%\">") + 6, sCode.IndexOf("<a class") - (sCode.IndexOf("\"70%\">") + 6));

            //string sDato = sCode.Substring(sCode.IndexOf("\"70%\">")+6,sCode.IndexOf(""));

            return sDato;
        }

        public static void delete(int iIdEmpresa)
        {
            try
            {
                ArrayList aId = new ArrayList();

                db = new DBSesion();
                db.abrirConexion();

                string sSql = "SELECT id FROM `contrato` WHERE `id_empresa` = " + iIdEmpresa;
                MySqlDataReader myReader = db.consultar(sSql);

                while (myReader.Read())
                {
                    aId.Add(myReader.GetInt32("id"));
                }

                db.cerrarConexion();

                for(int i = 0; i < aId.Count; i++)
                {
                    db.abrirConexion();
                    db.eliminar("DELETE FROM `contrato_elemento` WHERE `id_contrato` = " + (int)(aId[i]));
                    db.eliminar("DELETE FROM `contrato` WHERE `id` = " + (int)(aId[i]));
                    db.cerrarConexion();
                }

                aId.Clear();

                sSql = "DELETE FROM `plantillacontrato` WHERE `id_empresa` = " + iIdEmpresa;
                myReader = db.consultar(sSql);

                while (myReader.Read())
                {
                    aId.Add(myReader.GetInt32("id"));
                }

                db.cerrarConexion();

                for (int i = 0; i < aId.Count; i++)
                {
                    db.abrirConexion();
                    db.eliminar("DELETE FROM `plantillaelemento` WHERE `id_plantillaContrato` = " + (int)(aId[i]));
                    db.eliminar("DELETE FROM `plantillacontrato` WHERE `id` = " + (int)(aId[i]));
                    db.cerrarConexion();
                }


                db.abrirConexion();
                db.eliminar("DELETE FROM `empresas` WHERE `id` = "+iIdEmpresa);
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
                                     
                                     
                                     
                                     
                                     
                                     
                                     
                                     
                                     