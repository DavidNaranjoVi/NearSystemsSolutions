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
    class Cliente_Iban
    {

        private ArrayList _aId = new ArrayList();
        private int _iId_Cliente;
        private ArrayList _aIban = new ArrayList();

        private static DBSesion db = null;

        public ArrayList AIban { get => _aIban; set => _aIban = value; }

        Cliente_Iban() {}

      public Cliente_Iban(int iId_Cliente)
        {
            _iId_Cliente = iId_Cliente;

            try
            {
                db = new DBSesion();
                db.abrirConexion();
                MySqlDataReader myReader = db.consultar("select * from cliente_iban where id_cliente = " + iId_Cliente);
                while (myReader.Read())
                {
                    _aId.Add(myReader.GetInt32("id"));
                    AIban.Add(myReader.GetString("iban"));
                }

                db.cerrarConexion();

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        static public Cliente_Iban create(int iId_Cliente,ArrayList asIban)
        {

            String sql = "";
            ArrayList aId = new ArrayList();
            ArrayList aIban = new ArrayList();

            try
            {
                db = new DBSesion();

                for (int i = 0; i < asIban.Count; i++)
                {
                    db.abrirConexion();

                    sql = "insert into cliente_iban (id_cliente,iban) Values (" + iId_Cliente + "," + Data.String2Sql(asIban[i].ToString(), true, false) + ");" +
                            "SELECT LAST_INSERT_ID()";

                    aId.Add(db.insertar(sql));
                    aIban.Add(asIban[i].ToString());

                    db.cerrarConexion();

                    

                }

                return new Cliente_Iban(iId_Cliente);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public static Cliente_Iban  consultar(int iId)
        {
            try
            {   
                return new Cliente_Iban(iId);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void actualizar(int iId_cliente,String Iban)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        public static void delete(int iId_cliente)
        {
            try
            {
                String sSql = "DELETE FROM `cliente_iban` WHERE id_cliente = " + iId_cliente;

                db = new DBSesion();
                db.abrirConexion();
                db.eliminar(sSql);
                db.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool check_iban(string sIban)
        {
            if (string.IsNullOrEmpty(sIban))
                return false;

            var asciiShift = 55;
            sIban = sIban.ToUpper();

            if (!System.Text.RegularExpressions.Regex.IsMatch(sIban, "^[A-Z0-9]")) return false;

            //Rearrange sIban
            sIban = sIban.Replace(" ", string.Empty);
            var rearrangedsIban = sIban.Substring(4, sIban.Length - 4) + sIban.Substring(0, 4);

            //Convert to integer checksum
            var stringBuilder = new StringBuilder();
            foreach (var sIbanChar in rearrangedsIban)
            {
                int convertedValue;
                if (char.IsLetter(sIbanChar))
                    convertedValue = sIbanChar - asciiShift;
                else
                    convertedValue = int.Parse(sIbanChar.ToString());
                stringBuilder.Append(convertedValue);
            }

            //Modulo operation on IBAN checksum
            var checkSumString = stringBuilder.ToString();
            var checksum = int.Parse(checkSumString.Substring(0, 1));
            for (var i = 1; i < checkSumString.Length; i++)
            {
                checksum *= 10;
                checksum += int.Parse(checkSumString.Substring(i, 1));
                checksum %= 97;
            }
            return checksum == 1;
        }

        public ArrayList getId() { return _aId; }
        public int getId_Cliente() { return _iId_Cliente; }
        public ArrayList getIban() { return AIban; }

    }
}
