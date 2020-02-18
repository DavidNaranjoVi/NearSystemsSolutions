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
    class Data
    {

        static DBSesion db;
        static public Form1 f1;
        static ArrayList asMunicipios = new ArrayList();

        public static String String2Sql(String s, bool bAddQuotes, bool bAddWildcards,bool bConsulta = false)
        {
            if ((s == null || s == "")&& !bConsulta) return "null";

            s = s.Replace("'", "''");

            if (bAddWildcards)
                s = "%" + s + "%";
            if (bAddQuotes)
                s = "'" + s + "'";

            return s;

        }

        public static void ListaProvincias(ComboBox cbProvincias,string provincia = "")
        {
            db = new DBSesion();
            db.abrirConexion();
            MySqlDataReader myReader = db.consultar("select * from provincias where provincia LIKE "+Data.String2Sql(provincia,true,true,true)+" order by provincia ");

            while (myReader.Read())
            {
                cbProvincias.Items.Add(myReader.GetString("provincia"));
            }
            db.cerrarConexion();
        }

        public static void ListaMunicipios(ComboBox cbMunicipios,string provincia)
        {
            try
            {
                db = new DBSesion();
                db.abrirConexion();
                
                MySqlDataReader myReader = db.consultar("select municipio from municipios, provincias where provincias.provincia LIKE " + String2Sql(provincia, true, true) + " AND " +
                    "provincias.id_provincia = municipios.provincia");


                if (myReader == null)
                {
                    cbMunicipios.Items.Clear();
                    cbMunicipios.Text = "";
                }

                while (myReader.Read())
                    cbMunicipios.Items.Add(myReader.GetString("municipio"));

                db.cerrarConexion();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static ArrayList busquedaMunicipios(string sMunicipio)
        {
            ArrayList asMunicipiosEncontrados = new ArrayList();

            for (int i = 0; i < asMunicipios.Count; i++)
                if ((asMunicipios[i]).ToString().ToLower().Contains(sMunicipio.ToLower()))
                    asMunicipiosEncontrados.Add(asMunicipios[i].ToString());
            return asMunicipiosEncontrados;
        }

        public static int busquedaDireccion(ComboBox cbDireccion,string sDireccion)
        {
            for (int i = 0; i < cbDireccion.Items.Count; i++)
                if (cbDireccion.Items[i].ToString().ToUpper().Equals(sDireccion.ToUpper()))
                    return i;
            return -1;
        }

        public static String formatearFecha(String fecha)
        {

            if (fecha.Length > 10) fecha = fecha.Substring(0, 10);

            if (fecha.Contains("-") && fecha.Length == 10)
            {

                String[] aFecha = new string[3];
                aFecha = fecha.Split('-');

                if (aFecha[0].Length == 4)
                {
                    return fecha;
                }else if(aFecha[2].Length == 4)
                {
                    return aFecha[2] + "-" + aFecha[1] + "-" + aFecha[0];
                }
                else
                {
                    MessageBox.Show("Problemas al detectar la fecha.\nPara evitar errores compruebe su formato (AAAA-mm-dd)");
                    return "";
                }

            }else if (fecha.Contains("/") && fecha.Length == 10)
            {
                String[] aFecha = new string[3];
                aFecha = fecha.Split('/');

                if (aFecha[0].Length == 4)
                {
                    return fecha.Replace("/","-");
                }
                else if (aFecha[2].Length == 4)
                {
                    return aFecha[2] + "-" + aFecha[1] + "-" + aFecha[0];
                }
                else
                {
                    MessageBox.Show("Problemas al detectar la fecha.\nPara evitar errores compruebe su formato (AAAA-mm-dd)");
                    return "";
                }
            }

            return fecha;
        }

        public static void ClearTextBoxes(Control control)

        {

            foreach (Control c in control.Controls)

            {

                if (c is TextBox)

                {

                    ((TextBox)c).Clear();

                }

                if (c.HasChildren)

                {

                    ClearTextBoxes(c);

                }

            }

        }

    }


}
