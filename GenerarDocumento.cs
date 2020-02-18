using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NearSystemsSolutions
{
    public partial class GenerarDocumento : Form
    {

        string[] meses = { "", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        public GenerarDocumento(Contrato contrato)
        {
            InitializeComponent();
            rellenarContrato(contrato);
        }

        public GenerarDocumento(FichaAbonado fichaAbonado)
        {
            InitializeComponent();
            rellenarFicha(fichaAbonado);
        }

        public GenerarDocumento(FichaMantenimiento fichaMantenimiento)
        {
            InitializeComponent();
            rellenarMantenimiento(fichaMantenimiento);
        }

        public void rellenarMantenimiento(FichaMantenimiento fichaMantenimiento)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = null;

            try
            {

                Stream myStream;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                object fileName = @AppConfiguration.getConfig("Ficha_Mantenimiento");
                object fileNameCopy = @AppConfiguration.getConfig("Ficha_Mantenimiento").Substring(0,AppConfiguration.getConfig("Ficha_Mantenimiento").LastIndexOf("\\"))+
                                      "Ficha_Mantenimiento_Copia.dotx";

                object confirmConversions = Type.Missing;

                object readOnly = false;
                object addToRecentFiles = Type.Missing;
                object passwordDoc = Type.Missing;
                object passwordTemplate = Type.Missing;
                object revert = Type.Missing;
                object writepwdoc = Type.Missing;
                object writepwTemplate = Type.Missing;
                object format = Type.Missing;
                object encoding = Type.Missing;
                object visible = false;
                object openRepair = Type.Missing;
                object docDirection = Type.Missing;
                object notEncoding = Type.Missing;
                object xmlTransform = Type.Missing;

                doc = wordApp.Documents.Open(

                ref fileName, ref confirmConversions, ref readOnly, ref addToRecentFiles,
                ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,
                ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,
                ref docDirection, ref notEncoding, ref xmlTransform

                );


                doc.SaveAs2(fileNameCopy);
                doc.Close();

                visible = true;

                doc = wordApp.Documents.Open(

               ref fileNameCopy, ref confirmConversions, ref readOnly, ref addToRecentFiles,
               ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,
               ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,
               ref docDirection, ref notEncoding, ref xmlTransform

               );

                Object empresaInstaladora = "tEmpresaInstaladora";
                Object numeroParte = "tNumeroParte";
                Object fechaParte = "tFechaParte";
                Object numeroAbonado = "tNumeroAbonado";
                Object tipoPanel = "tTipoPanel";
                Object fechaAlta = "tFechaAlta";
                Object nombreRazon = "tNombreRazon";
                Object direccion = "tDireccion";
                Object localidad = "tLocalidad";
                Object provincia = "tProvincia";
                Object comentario = "tComentario";
                Object cp = "tCp";

                Object[] telefonos =
                {
                    "tTelefono",
                    "tTelefono2",
                    "tTelefono3"
                };

                Object email = "tEmail";

                Object[] zonas =
                {
                    "tZona0",
                    "tZona1",
                    "tZona2",
                    "tZona3",
                    "tZona4",
                    "tZona5",
                    "tZona6",
                    "tZona7",
                    "tZona8",
                    "tZona9",
                    "tZona10",
                    "tZona11",
                    "tZona12",
                    "tZona13",
                    "tZona14",
                    "tZona15",
                };

                Object[] areas =
                {
                    "tArea0",
                    "tArea1",
                    "tArea2",
                    "tArea3",
                    "tArea4",
                    "tArea5",
                    "tArea6",
                    "tArea7",
                    "tArea8",
                    "tArea9",
                    "tArea10",
                    "tArea11",
                    "tArea12",
                    "tArea13",
                    "tArea14",
                    "tArea15"
                };

                Object[] descripciones =
                {
                    "tDescripcion0",
                    "tDescripcion1",
                    "tDescripcion2",
                    "tDescripcion3",
                    "tDescripcion4",
                    "tDescripcion5",
                    "tDescripcion6",
                    "tDescripcion7",
                    "tDescripcion8",
                    "tDescripcion9",
                    "tDescripcion10",
                    "tDescripcion11",
                    "tDescripcion12",
                    "tDescripcion13",
                    "tDescripcion14",
                    "tDescripcion15"
                };

                Object[,] test =
                {
                    {"tSabotaje0","tCobertura0","tBateria0"},
                    {"tSabotaje1","tCobertura1","tBateria1"},
                    {"tSabotaje2","tCobertura2","tBateria2"},
                    {"tSabotaje3","tCobertura3","tBateria3"},
                    {"tSabotaje4","tCobertura4","tBateria4" },
                    {"tSabotaje5","tCobertura5","tBateria5"},
                    {"tSabotaje6","tCobertura6","tBateria6"},
                    {"tSabotaje7","tCobertura7","tBateria7"},
                    {"tSabotaje8","tCobertura8","tBateria8" },
                    {"tSabotaje9","tCobertura9","tBateria9"},
                    {"tSabotaje10","tCobertura10","tBateria10"},
                    {"tSabotaje11","tCobertura11","tBateria11"},
                    {"tSabotaje12","tCobertura12","tBateria12"},
                    {"tSabotaje13","tCobertura13","tBateria13"},
                    {"tSabotaje14","tCobertura14","tBateria14"},
                    {"tSabotaje15","tCobertura15","tBateria15"}
                };

                ArrayList aZonas = new FichaAbonado(fichaMantenimiento.IIdFichaAbonado).consultar_zona();
                ArrayList testZonas = FichaMantenimiento.consultar_zonas(fichaMantenimiento.IId);

                for (int i = 0; i < aZonas.Count; i++)
                {

                    Zona zona = (Zona)aZonas[i];

                    
                    TestZonas testZona = (TestZonas)testZonas[i];

                    if (zona.IId == testZona.IIdZona)
                    {

                        Microsoft.Office.Interop.Word.Range rangeZona = doc.Bookmarks.get_Item(ref zonas[i]).Range;
                        rangeZona.Text = zona.sZona;

                        Microsoft.Office.Interop.Word.Range rangeArea = doc.Bookmarks.get_Item(ref areas[i]).Range;
                        rangeArea.Text = zona.Area;

                        Microsoft.Office.Interop.Word.Range rangeDescripcion = doc.Bookmarks.get_Item(ref descripciones[i]).Range;
                        rangeDescripcion.Text = zona.Descripcion;

                        Microsoft.Office.Interop.Word.Range rangeTestSabotaje = doc.Bookmarks.get_Item(ref test[i, 0]).Range;
                        rangeTestSabotaje.Text = testZona.BSabotaje ? "X" : "";

                        Microsoft.Office.Interop.Word.Range rangeTestCobertura = doc.Bookmarks.get_Item(ref test[i, 1]).Range;
                        rangeTestCobertura.Text = testZona.BCobertura ? "X" : "";

                        Microsoft.Office.Interop.Word.Range rangeTestBateria = doc.Bookmarks.get_Item(ref test[i, 2]).Range;
                        rangeTestBateria.Text = testZona.BBateria ? "X" : "";

                    }

                }

                Object viaPrincipal = "tViaPrincipal";
                Object modeloPrincipal = "tModeloPrincipal";
                Object formatoPrincipal = "tFormatoPrincipal";
                Object testPrincipal = "tTestPrincipal";
                Object viaSecundaria = "tViaSecundaria";
                Object modeloSecundaria = "tModeloSecundaria";
                Object formatoSecundaria = "tFormatoSecundaria";
                Object testSecundaria = "tTestSecundaria";
                Object cctvIp = "tCctvIp";
                Object modeloIp = "tModeloIp";
                Object ipCliente = "tIpCliente";
                Object puerto = "tPuerto";
                Object imei = "tIMEI";






                String sFechaAlta = Data.formatearFecha(fichaMantenimiento.FichaAbonado.SFechaAlta);
                String[] aFechaAlta = sFechaAlta.Split('-');
                sFechaAlta = aFechaAlta[2] + "/" + aFechaAlta[1] + "/" + aFechaAlta[0];

                Microsoft.Office.Interop.Word.Range rangeNumeroParte = doc.Bookmarks.get_Item(ref numeroParte).Range;
                rangeNumeroParte.Text = fichaMantenimiento.SNumero;

                Microsoft.Office.Interop.Word.Range rangeEmpresaInstaladora = doc.Bookmarks.get_Item(ref empresaInstaladora).Range;
                rangeEmpresaInstaladora.Text = fichaMantenimiento.FichaAbonado.SEmpresaInstaladora;

                Microsoft.Office.Interop.Word.Range rangeAbonado = doc.Bookmarks.get_Item(ref numeroAbonado).Range;
                rangeAbonado.Text = fichaMantenimiento.FichaAbonado.SNAbonado;

                Microsoft.Office.Interop.Word.Range rangeTipoPanel = doc.Bookmarks.get_Item(ref tipoPanel).Range;
                rangeTipoPanel.Text = fichaMantenimiento.FichaAbonado.STipoPanel;

                Microsoft.Office.Interop.Word.Range rangeFechaAlta = doc.Bookmarks.get_Item(ref fechaAlta).Range;
                rangeFechaAlta.Text = sFechaAlta;

                Microsoft.Office.Interop.Word.Range rangeNombreRazon = doc.Bookmarks.get_Item(ref nombreRazon).Range;
                rangeNombreRazon.Text = fichaMantenimiento.FichaAbonado.SNombreRazonSocial;

                Microsoft.Office.Interop.Word.Range rangeDireccion = doc.Bookmarks.get_Item(ref direccion).Range;
                rangeDireccion.Text = fichaMantenimiento.FichaAbonado.SDireccion;

                Microsoft.Office.Interop.Word.Range rangeLocalidad = doc.Bookmarks.get_Item(ref localidad).Range;
                rangeLocalidad.Text = fichaMantenimiento.FichaAbonado.SLocalidad;

                Microsoft.Office.Interop.Word.Range rangeProvincia = doc.Bookmarks.get_Item(ref provincia).Range;
                rangeProvincia.Text = fichaMantenimiento.FichaAbonado.SProvincia;

                Microsoft.Office.Interop.Word.Range rangeCp = doc.Bookmarks.get_Item(ref cp).Range;
                rangeCp.Text = fichaMantenimiento.FichaAbonado.SCopo;

                for (int i = 0; i < 3; i++)
                {

                    Microsoft.Office.Interop.Word.Range rangeTelefonos = doc.Bookmarks.get_Item(ref telefonos[i]).Range;
                    rangeTelefonos.Text = fichaMantenimiento.FichaAbonado.getTelefonos(i + 1);

                }

                Microsoft.Office.Interop.Word.Range rangeEmail = doc.Bookmarks.get_Item(ref email).Range;
                rangeEmail.Text = fichaMantenimiento.FichaAbonado.SEmail;

                Microsoft.Office.Interop.Word.Range rangeViaPrincipal = doc.Bookmarks.get_Item(ref viaPrincipal).Range;
                rangeViaPrincipal.Text = fichaMantenimiento.FichaAbonado.SViaPrincipal;

                Microsoft.Office.Interop.Word.Range rangeModeloPrincipal = doc.Bookmarks.get_Item(ref modeloPrincipal).Range;
                rangeModeloPrincipal.Text = fichaMantenimiento.FichaAbonado.SModeloPrincipal;

                Microsoft.Office.Interop.Word.Range rangeFormatoPrincipal = doc.Bookmarks.get_Item(ref formatoPrincipal).Range;
                rangeFormatoPrincipal.Text = fichaMantenimiento.FichaAbonado.SFormatoPrincipal;

                Microsoft.Office.Interop.Word.Range rangeTestPrincipal = doc.Bookmarks.get_Item(ref testPrincipal).Range;
                rangeTestPrincipal.Text = fichaMantenimiento.FichaAbonado.STestPrincipal;

                Microsoft.Office.Interop.Word.Range rangeViaSecundaria = doc.Bookmarks.get_Item(ref viaSecundaria).Range;
                rangeViaSecundaria.Text = fichaMantenimiento.FichaAbonado.SViaSecundaria;

                Microsoft.Office.Interop.Word.Range rangeModeloSecundaria = doc.Bookmarks.get_Item(ref modeloSecundaria).Range;
                rangeModeloSecundaria.Text = fichaMantenimiento.FichaAbonado.SModeloSecundaria;

                Microsoft.Office.Interop.Word.Range rangeFormatoSecundaria = doc.Bookmarks.get_Item(ref formatoSecundaria).Range;
                rangeFormatoSecundaria.Text = fichaMantenimiento.FichaAbonado.SFormatoSecundaria;

                Microsoft.Office.Interop.Word.Range rangeTestSecundaria = doc.Bookmarks.get_Item(ref testSecundaria).Range;
                rangeTestSecundaria.Text = fichaMantenimiento.FichaAbonado.STestSecundaria;

                Microsoft.Office.Interop.Word.Range rangeCctvIp = doc.Bookmarks.get_Item(ref cctvIp).Range;
                rangeCctvIp.Text = fichaMantenimiento.FichaAbonado.SCctvIp;

                Microsoft.Office.Interop.Word.Range rangeModeloCctvIp = doc.Bookmarks.get_Item(ref modeloIp).Range;
                rangeModeloCctvIp.Text = fichaMantenimiento.FichaAbonado.SCctvIpModelo;

                Microsoft.Office.Interop.Word.Range rangeIpCliente = doc.Bookmarks.get_Item(ref ipCliente).Range;
                rangeIpCliente.Text = fichaMantenimiento.FichaAbonado.SCctvIpCliente;

                Microsoft.Office.Interop.Word.Range rangePuerto = doc.Bookmarks.get_Item(ref puerto).Range;
                rangePuerto.Text = fichaMantenimiento.FichaAbonado.SCctvIpPuerto;


                saveFileDialog1.AddExtension = true;
                saveFileDialog1.DefaultExt = "doc";
                saveFileDialog1.Filter = "Documento word (.doc)|*.doc|Plantilla word (.dotx)|*.dotx|Documento PDF (.pdf)|*.pdf";
                saveFileDialog1.ShowDialog();

                doc.SaveAs2(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                       , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                doc.Close(false, Type.Missing, Type.Missing);
                wordApp.Quit(false, false, false);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                this.Close();
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        public void rellenarFicha(FichaAbonado fichaAbonado)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = null;

            try
            {

                Stream myStream;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                object fileName = @AppConfiguration.getConfig("Ficha_Abonado");
                object fileNameCopy = @AppConfiguration.getConfig("Ficha_Abonado").Substring(0, AppConfiguration.getConfig("Ficha_Abonado").LastIndexOf("\\")) +
                                      "Ficha_Abonado_Copia.dotx";
                object confirmConversions = Type.Missing;

                object readOnly = false;
                object addToRecentFiles = Type.Missing;
                object passwordDoc = Type.Missing;
                object passwordTemplate = Type.Missing;
                object revert = Type.Missing;
                object writepwdoc = Type.Missing;
                object writepwTemplate = Type.Missing;
                object format = Type.Missing;
                object encoding = Type.Missing;
                object visible = false;
                object openRepair = Type.Missing;
                object docDirection = Type.Missing;
                object notEncoding = Type.Missing;
                object xmlTransform = Type.Missing;

                doc = wordApp.Documents.Open(

                ref fileName, ref confirmConversions, ref readOnly, ref addToRecentFiles,
                ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,
                ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,
                ref docDirection, ref notEncoding, ref xmlTransform
                
                );

                Object empresaInstaladora = "tEmpresaInstaladora";
                Object numeroAbonado = "tAbonado";
                Object tipoPanel = "tTipoPanel";
                Object fechaAlta = "tFechaAlta";
                Object nombreRazon = "tNombreRazonSocial";
                Object direccion = "tDireccion";
                Object localidad = "tLocalidad";
                Object provincia = "tProvincia";
                Object cp = "tCp";


                Object[] telefonos =
                {
                    "tTelefono1",
                    "tTelefono2",
                    "tTelefono3"
                };

                Object email = "tEmail";

                Object [] zonas =
                {
                    "tZona1",
                    "tZona2",
                    "tZona3",
                    "tZona4",
                    "tZona5",
                    "tZona6",
                    "tZona7",
                    "tZona8",
                };

                Object [] areas =
                {
                    "tArea1",
                    "tArea2",
                    "tArea3",
                    "tArea4",
                    "tArea5",
                    "tArea6",
                    "tArea7",
                    "tArea8"
                };

                Object[] descripciones =
                {
                    "tDescripcion1",
                    "tDescripcion2",
                    "tDescripcion3",
                    "tDescripcion4",
                    "tDescripcion5",
                    "tDescripcion6",
                    "tDescripcion7",
                    "tDescripcion8",
                };

                Object viaPrincipal = "tViaPrincipal";
                Object modeloPrincipal = "tModeloPrincipal";
                Object formatoPrincipal = "tFormatoPrincipal";
                Object testPrincipal = "tTestPrincipal";
                Object viaSecundaria = "tViaSecundaria";
                Object modeloSecundaria = "tModeloSecundaria";
                Object formatoSecundaria = "tFormatoSecundaria";
                Object testSecundaria = "tTestSecundaria";
                Object cctvIp = "tCctvIp";
                Object modeloIp = "tModeloIp";
                Object ipCliente = "tIpCliente";
                Object puerto = "tPuerto";
                Object imei = "tImei";

                Object[] usuarios =
                {
                    "tUsuario1",
                    "tUsuario2",
                    "tUsuario3",
                    "tUsuario4",
                    "tUsuario5",
                    "tUsuario6",
                    "tUsuario7",
                    "tUsuario8"
                };

                Object[] nombre =
                {
                    "tNombre1",
                    "tNombre2",
                    "tNombre3",
                    "tNombre4",
                    "tNombre5",
                    "tNombre6",
                    "tNombre7",
                    "tNombre8"
                };

                Object[] telefonoContacto =
                {
                    "tTelefonoContacto1",
                    "tTelefonoContacto2",
                    "tTelefonoContacto3",
                    "tTelefonoContacto4",
                    "tTelefonoContacto5",
                    "tTelefonoContacto6",
                    "tTelefonoContacto7",
                    "tTelefonoContacto8"
                };

                Object[] telefonoContacto1 =
                {
                    "tTelefonoContacto11",
                    "tTelefonoContacto12",
                    "tTelefonoContacto13",
                    "tTelefonoContacto14",
                    "tTelefonoContacto15",
                    "tTelefonoContacto16",
                    "tTelefonoContacto17",
                    "tTelefonoContacto18"
                };

                Object[] consignaIndividual =
                {
                    "tConsignaIndividual1",
                    "tConsignaIndividual2",
                    "tConsignaIndividual3",
                    "tConsignaIndividual4",
                    "tConsignaIndividual5",
                    "tConsignaIndividual6",
                    "tConsignaIndividual7",
                    "tConsignaIndividual8"
                };

                Object consignaGlobal = "tConsignaGlobal";
                Object consignaCoaccion = "tConsignaCoaccion";
                Object consignaCra = "tConsignaCra";
                Object comentario = "tComentario";
                Object cctv = "tCctv";
                Object usuario = "tUsuario";
                Object password = "tPassword";

                doc.SaveAs2(fileNameCopy);
                doc.Close();

                visible = true;

                doc = wordApp.Documents.Open(

               ref fileNameCopy, ref confirmConversions, ref readOnly, ref addToRecentFiles,
               ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,
               ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,
               ref docDirection, ref notEncoding, ref xmlTransform
               
               );

                String sFechaAlta = Data.formatearFecha(fichaAbonado.SFechaAlta);
                String[] aFechaAlta = sFechaAlta.Split('-');
                sFechaAlta = aFechaAlta[2] + "/" + aFechaAlta[1] + "/" + aFechaAlta[0];

                //EMPRESA INSTALADORA POR DEFECTO NEAR, DESCOMENTAR Y AÑADIR MARCADOR PARA EDICIÓN
                /*Microsoft.Office.Interop.Word.Range rangeEmpresaInstaladora = doc.Bookmarks.get_Item(ref empresaInstaladora).Range;
                rangeEmpresaInstaladora.Text = fichaAbonado.SEmpresaInstaladora;*/

                Microsoft.Office.Interop.Word.Range rangeAbonado = doc.Bookmarks.get_Item(ref numeroAbonado).Range;
               rangeAbonado.Text = fichaAbonado.SNAbonado;

                Microsoft.Office.Interop.Word.Range rangeTipoPanel = doc.Bookmarks.get_Item(ref tipoPanel).Range;
                rangeTipoPanel.Text = fichaAbonado.STipoPanel;

                Microsoft.Office.Interop.Word.Range rangeFechaAlta = doc.Bookmarks.get_Item(ref fechaAlta).Range;
                rangeFechaAlta.Text = sFechaAlta;

                Microsoft.Office.Interop.Word.Range rangeNombreRazon = doc.Bookmarks.get_Item(ref nombreRazon).Range;
                rangeNombreRazon.Text = fichaAbonado.SNombreRazonSocial;

                Microsoft.Office.Interop.Word.Range rangeDireccion = doc.Bookmarks.get_Item(ref direccion).Range;
                rangeDireccion.Text = fichaAbonado.SDireccion;

                Microsoft.Office.Interop.Word.Range rangeLocalidad = doc.Bookmarks.get_Item(ref localidad).Range;
                rangeLocalidad.Text = fichaAbonado.SLocalidad;

                Microsoft.Office.Interop.Word.Range rangeProvincia = doc.Bookmarks.get_Item(ref provincia).Range;
                rangeProvincia.Text = fichaAbonado.SProvincia;

                Microsoft.Office.Interop.Word.Range rangeCp = doc.Bookmarks.get_Item(ref cp).Range;
                rangeCp.Text = fichaAbonado.SCopo;

                for (int i = 0; i < 3; i++)
                {

                    Microsoft.Office.Interop.Word.Range rangeTelefonos = doc.Bookmarks.get_Item(ref telefonos[i]).Range;
                    rangeTelefonos.Text = fichaAbonado.getTelefonos(i + 1);

                }


                Microsoft.Office.Interop.Word.Range rangeEmail = doc.Bookmarks.get_Item(ref email).Range;
                rangeEmail.Text = fichaAbonado.SEmail;

                //mejorar condicion for

                ArrayList aZonas = fichaAbonado.consultar_zona();

                for(int i = 0; i < aZonas.Count; i++)
                {
                    Zona zona = (Zona)aZonas[i];

                    Microsoft.Office.Interop.Word.Range rangeZona = doc.Bookmarks.get_Item(ref zonas[i]).Range;
                    rangeZona.Text = zona.sZona;

                    Microsoft.Office.Interop.Word.Range rangeArea = doc.Bookmarks.get_Item(ref areas[i]).Range;
                    rangeArea.Text = zona.Area;

                    Microsoft.Office.Interop.Word.Range rangeDescripcion = doc.Bookmarks.get_Item(ref descripciones[i]).Range;
                    rangeDescripcion.Text = zona.Descripcion;
                }

                Microsoft.Office.Interop.Word.Range rangeViaPrincipal = doc.Bookmarks.get_Item(ref viaPrincipal).Range;
                rangeViaPrincipal.Text = fichaAbonado.SViaPrincipal;

                Microsoft.Office.Interop.Word.Range rangeModeloPrincipal = doc.Bookmarks.get_Item(ref modeloPrincipal).Range;
                rangeModeloPrincipal.Text = fichaAbonado.SModeloPrincipal;

                Microsoft.Office.Interop.Word.Range rangeFormatoPrincipal = doc.Bookmarks.get_Item(ref formatoPrincipal).Range;
                rangeFormatoPrincipal.Text = fichaAbonado.SFormatoPrincipal;

                Microsoft.Office.Interop.Word.Range rangeTestPrincipal = doc.Bookmarks.get_Item(ref testPrincipal).Range;
                rangeTestPrincipal.Text = fichaAbonado.STestPrincipal;

                Microsoft.Office.Interop.Word.Range rangeViaSecundaria = doc.Bookmarks.get_Item(ref viaSecundaria).Range;
                rangeViaSecundaria.Text = fichaAbonado.SViaSecundaria;

                Microsoft.Office.Interop.Word.Range rangeModeloSecundaria = doc.Bookmarks.get_Item(ref modeloSecundaria).Range;
                rangeModeloSecundaria.Text = fichaAbonado.SModeloSecundaria;

                Microsoft.Office.Interop.Word.Range rangeFormatoSecundaria = doc.Bookmarks.get_Item(ref formatoSecundaria).Range;
                rangeFormatoSecundaria.Text = fichaAbonado.SFormatoSecundaria;

                Microsoft.Office.Interop.Word.Range rangeTestSecundaria = doc.Bookmarks.get_Item(ref testSecundaria).Range;
                rangeTestSecundaria.Text = fichaAbonado.STestSecundaria;

                Microsoft.Office.Interop.Word.Range rangeCctvIp = doc.Bookmarks.get_Item(ref cctvIp).Range;
                rangeCctvIp.Text = fichaAbonado.SCctvIp;

                Microsoft.Office.Interop.Word.Range rangeModeloCctvIp = doc.Bookmarks.get_Item(ref modeloIp).Range;
                rangeModeloCctvIp.Text = fichaAbonado.SCctvIpModelo;

                Microsoft.Office.Interop.Word.Range rangeIpCliente = doc.Bookmarks.get_Item(ref ipCliente).Range;
                rangeIpCliente.Text = fichaAbonado.SCctvIpCliente;

                Microsoft.Office.Interop.Word.Range rangePuerto = doc.Bookmarks.get_Item(ref puerto).Range;
                rangePuerto.Text = fichaAbonado.SCctvIpPuerto;

                ArrayList aContactos = fichaAbonado.consultar_contactos();

                for (int i = 0; i < aContactos.Count; i++)
                {
                    ListaContactos c = (ListaContactos)aContactos[i];

                    Microsoft.Office.Interop.Word.Range rangeUsuarios = doc.Bookmarks.get_Item(ref usuarios[i]).Range;
                    rangeUsuarios.Text = c.Usuario;

                    Microsoft.Office.Interop.Word.Range rangeNombre = doc.Bookmarks.get_Item(ref nombre[i]).Range;
                    rangeNombre.Text = c.Nombre;

                    Microsoft.Office.Interop.Word.Range rangeTelefono = doc.Bookmarks.get_Item(ref telefonoContacto[i]).Range;
                    rangeTelefono.Text = c.Telefono1;

                    Microsoft.Office.Interop.Word.Range rangeTelefono1 = doc.Bookmarks.get_Item(ref telefonoContacto1[i]).Range;
                    rangeTelefono1.Text = c.Telefono2;

                    Microsoft.Office.Interop.Word.Range rangeConsignaIndividual = doc.Bookmarks.get_Item(ref consignaIndividual[i]).Range;
                    rangeConsignaIndividual.Text = c.ConsignaIndividual;
                }

                Microsoft.Office.Interop.Word.Range rangeConsignaGlobal = doc.Bookmarks.get_Item(ref consignaGlobal).Range;
                rangeConsignaGlobal.Text = fichaAbonado.SConsignaGlobal;

                Microsoft.Office.Interop.Word.Range rangeConsignaCoaccion = doc.Bookmarks.get_Item(ref consignaCoaccion).Range;
                rangeConsignaCoaccion.Text = fichaAbonado.SConsignaCoaccion;

                Microsoft.Office.Interop.Word.Range rangeConsignaCra = doc.Bookmarks.get_Item(ref consignaCra).Range;
                rangeConsignaCra.Text = fichaAbonado.SConsignaCRA;

                Microsoft.Office.Interop.Word.Range rangeComentario = doc.Bookmarks.get_Item(ref comentario).Range;
                rangeComentario.Text = fichaAbonado.SComentarios;

                Microsoft.Office.Interop.Word.Range rangeCctv = doc.Bookmarks.get_Item(ref cctv).Range;
                rangeCctv.Text = fichaAbonado.SCctv;

                Microsoft.Office.Interop.Word.Range rangeUsuario = doc.Bookmarks.get_Item(ref usuario).Range;
                rangeUsuario.Text = fichaAbonado.SUsuario;

                Microsoft.Office.Interop.Word.Range rangePassword = doc.Bookmarks.get_Item(ref password).Range;
                rangePassword.Text = fichaAbonado.SContrasena;

                saveFileDialog1.AddExtension = true;
                saveFileDialog1.DefaultExt = "doc";
                saveFileDialog1.Filter = "Documento word (.doc)|*.doc|Plantilla word (.dotx)|*.dotx|Documento PDF (.pdf)|*.pdf";
                saveFileDialog1.ShowDialog();

                doc.SaveAs2(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                       , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                doc.Close(false, Type.Missing, Type.Missing);
                wordApp.Quit(false, false, false);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                this.Close();

            }
            catch(Exception ex)
            {
                doc.Close();
                throw ex;
            }
        }

        public void contrato_Near(Contrato contrato)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = null;

            try
            {
                Stream myStream;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                string aux = Data.formatearFecha(contrato.SFechaContrato);
                string[] fecha = aux.Split('-');
                object fileName;
                object fileNameCopy;

                if (contrato.EEmpresa != null)
                {
                    fileName = @AppConfiguration.getConfig("Contrato_Near_Empresa");
                    fileNameCopy = @AppConfiguration.getConfig("Contrato_Near_Empresa").Substring(0, AppConfiguration.getConfig("Contrato_Near_Empresa").LastIndexOf("\\")) +
                                      "Contrato_Copia.dotx";
                }
                else
                {
                    fileName = @AppConfiguration.getConfig("Contrato_Near_Particular");
                    fileNameCopy = @AppConfiguration.getConfig("Contrato_Near_Particular").Substring(0, AppConfiguration.getConfig("Contrato_Near_Particular").LastIndexOf("\\")) +
                                      "Contrato_Copia.dotx";
                }

                object confirmConversions = Type.Missing;

                object readOnly = false;
                object addToRecentFiles = Type.Missing;
                object passwordDoc = Type.Missing;
                object passwordTemplate = Type.Missing;
                object revert = Type.Missing;
                object writepwdoc = Type.Missing;
                object writepwTemplate = Type.Missing;
                object format = Type.Missing;
                object encoding = Type.Missing;
                object visible = false;
                object openRepair = Type.Missing;
                object docDirection = Type.Missing;
                object notEncoding = Type.Missing;
                object xmlTransform = Type.Missing;

                doc = wordApp.Documents.Open(

                ref fileName, ref confirmConversions, ref readOnly, ref addToRecentFiles,
                ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,
                ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,
                ref docDirection, ref notEncoding, ref xmlTransform

                );

                Object name = "tNombre";
                Object dni = "tDni";
                Object fechaAlta = "tFechaAlta";
                Object numeroContrato = "tNumeroContrato";
                Object numeroAbonado = "tNumeroAbonado";
                Object tipoVia = "tTipoVia";
                Object direccion = "tDireccion";
                Object numero = "tNumero";
                Object piso = "tPiso";
                Object cp = "tCp";
                Object municipio = "tMunicipio";
                Object provincia = "tProvincia";
                Object razonSocial = "tRazonSocial";
                Object tipoViaEmpresa = "tTipoViaEmpresa";
                Object direccionEmpresa = "tDireccionEmpresa";
                Object pisoEmpresa = "tPisoEmpresa";
                Object cpEmpresa = "tCpEmpresa";
                Object numeroEmpresa = "tNumeroEmpresa";
                Object municipioEmpresa = "tMunicipioEmpresa";
                Object provinciaEmpresa = "tProvinciaEmpresa";
                Object cif = "tCif";
                Object municipioNotario = "tMunicipioNotario";
                Object nombreNotario = "tNombreNotario";
                Object diaNotario = "tDiaNotario";
                Object mesNotario = "tMesNotatio";
                Object annoNotario = "tAnnoNotatio";
                Object numeroProtocolo = "tNumeroProtocoloNotatio";
                Object instalacionSeguridad = "bInstalacionSistemaSeguridad";
                Object mantenimientoSeguridad = "bMantenimientoSeguridad";
                Object entradaVigor = "tEntradaEnVigor";
                Object precioInstalacion = "tPrecioInstalacion";
                Object precioMantenimiento = "tPrecioMantenimiento";
                Object formaPagoInstalacion = "tFormaPagoInstalacion";
                Object formaPagoMantenimiento = "tFormaPagoMantenimiento";
                Object lugar = "tLugar";
                Object calle = "tCalle";
                Object cp6 = "tCp6";
                Object poblacion = "tPoblacion";
                Object provincia6 = "tProvincia6";
                Object personaContacto = "tPersonaContacto";
                Object telefono = "tTelefono";
                Object robo = "bRobo";
                Object cctv = "bCctv";
                Object relacionSistemas = "tRelacionSistemas";
                Object instalar = "bINSTALAR";
                Object mantener = "bMantener";

                Object[] elementoNombre =
                {
                    "tElementoNombre0","tElementoNombre1","tElementoNombre2","tElementoNombre3","tElementoNombre4","tElementoNombre5","tElementoNombre6",
                    "tElementoNombre7","tElementoNombre8","tElementoNombre9","tElementoNombre10","tElementoNombre11"
                };

                Object[] elementoCodigo = {"tElementoCodigo0","tElementoCodigo1","tElementoCodigo2","tElementoCodigo3","tElementoCodigo4","tElementoCodigo5",
                    "tElementoCodigo6","tElementoCodigo7","tElementoCodigo8","tElementoCodigo9","tElementoCodigo10","tElementoCodigo11" };

                Object[] elementoCantidad =
                {
                    "tElementoCantidad0","tElementoCantidad1","tElementoCantidad2","tElementoCantidad3","tElementoCantidad4","tElementoCantidad5","tElementoCantidad6",
                    "tElementoCantidad7","tElementoCantidad8","tElementoCantidad9","tElementoCantidad10","tElementoCantidad11"
                };

                Object llave = "tLlave";
                Object iban = "tIban";
                Object fechaAnexo = "tFechaAnexo";
                Object nombreEmpresaAnexo = "tNombreEmpresaAnexo";
                Object direccionAnexo = "tDireccionAnexo";
                Object numeroAnexo = "tNumeroAnexo";
                Object municipioAnexo = "tMunicipioAnexo";
                Object cpAnexo = "tCpAnexo";
                Object cifAnexo = "tCifAnexo";
                Object representanteAnexo = "tRepresentanteAnexo";
                Object representanteNumero = "tRepresentanteNumero";
                Object cargoRepresentante = "tCargoRepresentanteAnexo";
                Object dniRepresentante = "tDniRepresentante";
                Object firmaRepresentante = "tFirmaRepresentanteAnexo";
                Object provinciaAnexo = "tProvinciaAnexo";
                Object pisoAnexo = "tPisoAnexo";

                doc.SaveAs2(fileNameCopy);
                doc.Close();

                visible = true;

                doc = wordApp.Documents.Open(

               ref fileNameCopy, ref confirmConversions, ref readOnly, ref addToRecentFiles,
               ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,
               ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,
               ref docDirection, ref notEncoding, ref xmlTransform

               );


                Microsoft.Office.Interop.Word.Range rangeNombre = doc.Bookmarks.get_Item(ref name).Range;

                rangeNombre.Text = contrato.CCLiente.getNombre() + " " + contrato.CCLiente.getApellido();

                Microsoft.Office.Interop.Word.Range rangeDni = doc.Bookmarks.get_Item(ref dni).Range;

                rangeDni.Text = contrato.CCLiente.getDni();

                Microsoft.Office.Interop.Word.Range rangeTipoVia = doc.Bookmarks.get_Item(ref tipoVia).Range;

                rangeTipoVia.Text = contrato.CCLiente.getTipoVia();

                Microsoft.Office.Interop.Word.Range rangeNumeroAbonado = doc.Bookmarks.get_Item(ref numeroAbonado).Range;

                rangeNumeroAbonado.Text = contrato.SNumeroAbonado.ToString();

                Microsoft.Office.Interop.Word.Range rangeNumeroContrato = doc.Bookmarks.get_Item(ref numeroContrato).Range;

                rangeNumeroContrato.Text = contrato.INumeroContrato.ToString();

                Microsoft.Office.Interop.Word.Range rangeFechaAlta = doc.Bookmarks.get_Item(ref fechaAlta).Range;

                rangeFechaAlta.Text = fecha[2] + " de " + meses[Convert.ToUInt32(fecha[1])] + " de " + fecha[0];

                Microsoft.Office.Interop.Word.Range rangeDireccion = doc.Bookmarks.get_Item(ref direccion).Range;

                rangeDireccion.Text = contrato.CCLiente.getDireccion();

                Microsoft.Office.Interop.Word.Range rangeNumero = doc.Bookmarks.get_Item(ref numero).Range;

                rangeNumero.Text = contrato.CCLiente.getNumero();

                Microsoft.Office.Interop.Word.Range rangePiso = doc.Bookmarks.get_Item(ref piso).Range;

                rangePiso.Text = contrato.CCLiente.getPiso();

                Microsoft.Office.Interop.Word.Range rangeCp = doc.Bookmarks.get_Item(ref cp).Range;

                rangeCp.Text = contrato.CCLiente.getCp();

                Microsoft.Office.Interop.Word.Range rangeMunicipio = doc.Bookmarks.get_Item(ref municipio).Range;//

                rangeMunicipio.Text = contrato.CCLiente.getMunicipio();

                Microsoft.Office.Interop.Word.Range rangeProvincia = doc.Bookmarks.get_Item(ref provincia).Range;

                rangeProvincia.Text = contrato.CCLiente.getProvincia();

                if (contrato.EEmpresa != null)
                {

                    Microsoft.Office.Interop.Word.Range rangeRazonSocial = doc.Bookmarks.get_Item(ref razonSocial).Range;//

                    rangeRazonSocial.Text = contrato.EEmpresa.SRazonSocial;

                    Microsoft.Office.Interop.Word.Range rangeDomicilioSocial = doc.Bookmarks.get_Item(ref tipoViaEmpresa).Range;

                    rangeDomicilioSocial.Text = contrato.EEmpresa.STipoVia;

                    Microsoft.Office.Interop.Word.Range rangeDireccionEmpresa = doc.Bookmarks.get_Item(ref direccionEmpresa).Range;
                    rangeDireccionEmpresa.Text = contrato.EEmpresa.SDireccion;

                    Microsoft.Office.Interop.Word.Range rangeNumeroEmpresa = doc.Bookmarks.get_Item(ref numeroEmpresa).Range;//
                    rangeNumeroEmpresa.Text = contrato.EEmpresa.SNumero;

                    if (!contrato.EEmpresa.SPiso.Equals(""))
                    {
                        Microsoft.Office.Interop.Word.Range rangePisoEmpresa = doc.Bookmarks.get_Item(ref pisoEmpresa).Range;//
                        rangePisoEmpresa.Text = contrato.EEmpresa.SPiso+",";
                    }

                    Microsoft.Office.Interop.Word.Range rangeCpEmpresa = doc.Bookmarks.get_Item(ref cpEmpresa).Range;//
                    rangeCpEmpresa.Text = contrato.EEmpresa.SCp;

                    Microsoft.Office.Interop.Word.Range rangeMunicipioEmpresa = doc.Bookmarks.get_Item(ref municipioEmpresa).Range;//
                    rangeMunicipioEmpresa.Text = contrato.EEmpresa.SMunicipio;

                    Microsoft.Office.Interop.Word.Range rangeProvinciaEmpresa = doc.Bookmarks.get_Item(ref provinciaEmpresa).Range;//
                    rangeProvinciaEmpresa.Text = contrato.EEmpresa.SProvincia;

                    Microsoft.Office.Interop.Word.Range rangeCif = doc.Bookmarks.get_Item(ref cif).Range;
                    rangeCif.Text = contrato.EEmpresa.SCif;

                    Microsoft.Office.Interop.Word.Range rangeMunicipioNotario = doc.Bookmarks.get_Item(ref municipioNotario).Range;//
                    rangeMunicipioNotario.Text = contrato.EEmpresa.SMunicipioNotario;

                    Microsoft.Office.Interop.Word.Range rangeNombreNotario = doc.Bookmarks.get_Item(ref nombreNotario).Range;
                    rangeNombreNotario.Text = contrato.EEmpresa.SNombreNotario;

                    String fechaNotario = Data.formatearFecha(contrato.EEmpresa.SFechaNotario);
                    String[] fechaNotarioAux = fechaNotario.Split('-');

                    Microsoft.Office.Interop.Word.Range rangeDiaNotario = doc.Bookmarks.get_Item(ref diaNotario).Range;//
                    rangeDiaNotario.Text = fechaNotarioAux[2];

                    Microsoft.Office.Interop.Word.Range rangeMesNotario = doc.Bookmarks.get_Item(ref mesNotario).Range;//
                    rangeMesNotario.Text = fechaNotarioAux[1];

                    Microsoft.Office.Interop.Word.Range rangeAnnoNotario = doc.Bookmarks.get_Item(ref annoNotario).Range;//
                    rangeAnnoNotario.Text = fechaNotarioAux[0].Substring(2);

                    Microsoft.Office.Interop.Word.Range rangeNumeroProtocolo = doc.Bookmarks.get_Item(ref numeroProtocolo).Range;
                    rangeNumeroProtocolo.Text = contrato.EEmpresa.SNumeroProtocolo;

                }

                Microsoft.Office.Interop.Word.Range rangeInstalacion = doc.Bookmarks.get_Item(ref instalacionSeguridad).Range;

                _ = (contrato.BInstalacion) ? rangeInstalacion.Text = "X" : rangeInstalacion.Text = "";

                Microsoft.Office.Interop.Word.Range rangeMantenimiento = doc.Bookmarks.get_Item(ref mantenimientoSeguridad).Range;

                if (contrato.BMantenimiento) rangeMantenimiento.Text = "X";
                else rangeMantenimiento.Text = "";

                String[] fechaEntradaVigor = Data.formatearFecha(contrato.SFechaVigor).Split('-');

                Microsoft.Office.Interop.Word.Range rangeFechaVigor = doc.Bookmarks.get_Item(ref entradaVigor).Range;

                rangeFechaVigor.Text = fechaEntradaVigor[2] + "/" + fechaEntradaVigor[1] + "/" + fechaEntradaVigor[0];

                Microsoft.Office.Interop.Word.Range rangePrecioInstalacion = doc.Bookmarks.get_Item(ref precioInstalacion).Range;

                rangePrecioInstalacion.Text = contrato.IPrecioInstalacion.ToString();

                Microsoft.Office.Interop.Word.Range rangePrecioMantenimiento = doc.Bookmarks.get_Item(ref precioMantenimiento).Range;

                rangePrecioMantenimiento.Text = contrato.IPrecioMantenimiento.ToString();

                Microsoft.Office.Interop.Word.Range rangeFPInstalacion = doc.Bookmarks.get_Item(ref formaPagoInstalacion).Range;

                rangeFPInstalacion.Text = contrato.SFormaPagoInstalacion;

                Microsoft.Office.Interop.Word.Range rangeFPMantenimiento = doc.Bookmarks.get_Item(ref formaPagoMantenimiento).Range;

                rangeFPMantenimiento.Text = contrato.SFormaPagoMantenimiento;

                Microsoft.Office.Interop.Word.Range rangeLugar = doc.Bookmarks.get_Item(ref lugar).Range;

                rangeLugar.Text = contrato.SLugar;

                Microsoft.Office.Interop.Word.Range rangeCalle = doc.Bookmarks.get_Item(ref calle).Range;

                rangeCalle.Text = contrato.SCalle;

                Microsoft.Office.Interop.Word.Range rangeCp6 = doc.Bookmarks.get_Item(ref cp6).Range;

                rangeCp6.Text = contrato.SCp;

                Microsoft.Office.Interop.Word.Range rangePoblacion6 = doc.Bookmarks.get_Item(ref poblacion).Range;

                rangePoblacion6.Text = contrato.SPoblacion;

                Microsoft.Office.Interop.Word.Range rangeProvincia6 = doc.Bookmarks.get_Item(ref provincia6).Range;

                rangeProvincia6.Text = contrato.SProvincia;

                Microsoft.Office.Interop.Word.Range rangePersonaContacto = doc.Bookmarks.get_Item(ref personaContacto).Range;

                rangePersonaContacto.Text = contrato.SPersonaContacto;

                Microsoft.Office.Interop.Word.Range rangeTelefono = doc.Bookmarks.get_Item(ref telefono).Range;

                rangeTelefono.Text = contrato.STelefono;

                Microsoft.Office.Interop.Word.Range rangeRobo = doc.Bookmarks.get_Item(ref robo).Range;

                if (contrato.BRobo) rangeRobo.Text = "X";
                else rangeRobo.Text = "";

                Microsoft.Office.Interop.Word.Range rangeCctv = doc.Bookmarks.get_Item(ref cctv).Range;

                if (contrato.BCctv) rangeCctv.Text = "X";
                else rangeCctv.Text = "";

                Microsoft.Office.Interop.Word.Range rangeRelacionSistemas = doc.Bookmarks.get_Item(ref relacionSistemas).Range;

                rangeRelacionSistemas.Text = "Anexo " + contrato.AAnexo.SNumeroAnexo;

                Microsoft.Office.Interop.Word.Range rangeInstalar = doc.Bookmarks.get_Item(ref instalar).Range;

                if (contrato.BPeriodicidadAnual) rangeInstalar.Text = "X";
                else rangeInstalar.Text = "";

                Microsoft.Office.Interop.Word.Range rangeMantener = doc.Bookmarks.get_Item(ref mantener).Range;

                if (contrato.BPrecioVisita) rangeMantener.Text = "X";
                else rangeMantener.Text = "";

                Microsoft.Office.Interop.Word.Range rangeElementosNombre;
                Microsoft.Office.Interop.Word.Range rangeElementosCodigo;
                Microsoft.Office.Interop.Word.Range rangeElementosCantidad;

                Contrato_Elemento ce = new Contrato_Elemento(contrato.Id);

                for (int i = 0; i < ce.AIdElementos.Count; i++)
                {
                    rangeElementosNombre = doc.Bookmarks.get_Item(ref elementoNombre[i]).Range;
                    rangeElementosCodigo = doc.Bookmarks.get_Item(ref elementoCodigo[i]).Range;
                    rangeElementosCantidad = doc.Bookmarks.get_Item(ref elementoCantidad[i]).Range;

                    Elemento e = new Elemento((int)ce.AIdElementos[i]);

                    rangeElementosNombre.Text = e.SNombre;
                    rangeElementosCodigo.Text = e.SCodigo;
                    rangeElementosCantidad.Text = ce.ACantidad[i].ToString();
                }

                Microsoft.Office.Interop.Word.Range rangeLlave = doc.Bookmarks.get_Item(ref llave).Range;

                if (contrato.BCustodia) rangeLlave.Text = "SÍ";
                else rangeLlave.Text = "NO";

                Microsoft.Office.Interop.Word.Range rangeIban = doc.Bookmarks.get_Item(ref iban).Range;

                rangeIban.Text = contrato.SIban;

                String[] f = Data.formatearFecha(contrato.AAnexo.SFecha).Split('-');

                Microsoft.Office.Interop.Word.Range rangeFechaAnexo = doc.Bookmarks.get_Item(ref fechaAnexo).Range;

                rangeFechaAnexo.Text = f[2] + " de " + meses[Convert.ToInt32(f[1])] + " de " + f[0];

                if (contrato.EEmpresa != null)
                {

                    Microsoft.Office.Interop.Word.Range rangeNombreEmpresaAnexo = doc.Bookmarks.get_Item(ref nombreEmpresaAnexo).Range;
                    rangeNombreEmpresaAnexo.Text = contrato.AAnexo.SRazonSocial;

                    Microsoft.Office.Interop.Word.Range rangeCargoRepresentanteAnexo = doc.Bookmarks.get_Item(ref cargoRepresentante).Range;//
                    rangeCargoRepresentanteAnexo.Text = contrato.AAnexo.SRepresentantePuesto;


                    Microsoft.Office.Interop.Word.Range rangeCifAnexo = doc.Bookmarks.get_Item(ref cifAnexo).Range;
                    rangeCifAnexo.Text = contrato.AAnexo.SCif;
                }

                Microsoft.Office.Interop.Word.Range rangeDireccionAnexo = doc.Bookmarks.get_Item(ref direccionAnexo).Range;

                rangeDireccionAnexo.Text = contrato.AAnexo.SDireccion;

                Microsoft.Office.Interop.Word.Range rangeNumeroDirAnexo = doc.Bookmarks.get_Item(ref representanteNumero).Range;

                rangeNumeroDirAnexo.Text = contrato.AAnexo.SNumero;

                if (!contrato.AAnexo.SPiso.Equals(""))
                {

                    Microsoft.Office.Interop.Word.Range rangePisoAnexo = doc.Bookmarks.get_Item(ref pisoAnexo).Range;

                    rangePisoAnexo.Text = contrato.AAnexo.SPiso + ", ";
                }

                Microsoft.Office.Interop.Word.Range rangeMunicipioAnexo = doc.Bookmarks.get_Item(ref municipioAnexo).Range;

                rangeMunicipioAnexo.Text = contrato.AAnexo.SMunicipio;

                Microsoft.Office.Interop.Word.Range rangeProvinciaAnexo = doc.Bookmarks.get_Item(ref provinciaAnexo).Range;

                rangeProvinciaAnexo.Text = contrato.AAnexo.SProvincia;

                Microsoft.Office.Interop.Word.Range rangeCpAnexo = doc.Bookmarks.get_Item(ref cpAnexo).Range;

                rangeCpAnexo.Text = contrato.AAnexo.SCp;


                Microsoft.Office.Interop.Word.Range rangeRepresentanteAnexo = doc.Bookmarks.get_Item(ref representanteAnexo).Range;

                rangeRepresentanteAnexo.Text = contrato.AAnexo.SRepresentanteNombre;

                Microsoft.Office.Interop.Word.Range rangeDniRepresentanteAnexo = doc.Bookmarks.get_Item(ref dniRepresentante).Range;//

                rangeDniRepresentanteAnexo.Text = contrato.AAnexo.SRepresentanteDni;

                Microsoft.Office.Interop.Word.Range rangeFirmaRepresentanteAnexo = doc.Bookmarks.get_Item(ref firmaRepresentante).Range;//

                rangeFirmaRepresentanteAnexo.Text = contrato.AAnexo.SFirma;

                saveFileDialog1.AddExtension = true;
                saveFileDialog1.DefaultExt = "doc";
                saveFileDialog1.Filter = "Documento word (.doc)|*.doc|Plantilla word (.dotx)|*.dotx|Documento PDF (.pdf)|*.pdf";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    //GUARDARLO EN PDF ARREGLARR
                    doc.SaveAs2(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                        , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    doc.Close(false, Type.Missing, Type.Missing);
                    wordApp.Quit(false, false, false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    this.Close();


                }
                else
                {

                    doc.Close(false, Type.Missing, Type.Missing);
                    wordApp.Quit(false, false, false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                doc.Close();
                MessageBox.Show(ex.ToString());
            }
        }

//################################################################# CONTRATO IBERCRA ###########################################################################################

        public void contrato_Ibercra(Contrato contrato)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = null;

            try
            {
                Stream myStream;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();


                string aux = Data.formatearFecha(contrato.SFechaVigor);
                string[] fecha = aux.Split('-');
                object fileName;
                object fileNameCopy;

                if (contrato.EEmpresa != null)
                {
                    fileName = @AppConfiguration.getConfig("Contrato_Ibercra_Empresa");
                    fileNameCopy = @AppConfiguration.getConfig("Contrato_Ibercra_Empresa").Substring(0, AppConfiguration.getConfig("Contrato_Ibercra_Empresa").LastIndexOf("\\")) +
                                      "Contrato_Ibercra_Copia.dotx";
                }
                else {
                    fileName = @AppConfiguration.getConfig("Contrato_Ibercra_Particular");
                    fileNameCopy = @AppConfiguration.getConfig("Contrato_Ibercra_Particular").Substring(0, AppConfiguration.getConfig("Contrato_Ibercra_Empresa").LastIndexOf("\\")) +
                                      "Contrato_Ibercra_Copia.dotx";
                }

                
                object confirmConversions = Type.Missing;

                object readOnly = false;
                object addToRecentFiles = Type.Missing;
                object passwordDoc = Type.Missing;
                object passwordTemplate = Type.Missing;
                object revert = Type.Missing;
                object writepwdoc = Type.Missing;
                object writepwTemplate = Type.Missing;
                object format = Type.Missing;
                object encoding = Type.Missing;
                object visible = false;
                object openRepair = Type.Missing;
                object docDirection = Type.Missing;
                object notEncoding = Type.Missing;
                object xmlTransform = Type.Missing;

                doc = wordApp.Documents.Open(

                ref fileName, ref confirmConversions, ref readOnly, ref addToRecentFiles,
                ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,
                ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,
                ref docDirection, ref notEncoding, ref xmlTransform

                );

                Object name = "tNombre";
                Object dni = "tDni";
                Object fechaAlta = "tFechaAlta";
                Object numeroContrato = "tNumeroContrato";
                Object numeroAbonado = "tNumeroAbonado";
                Object tipoVia = "tTipoVia";
                Object direccion = "tDireccion";
                Object numero = "tNumero";
                Object piso = "tPiso";
                Object cp = "tCp";
                Object telefono = "tTelefono";
                Object municipio = "tMunicipio";
                Object provincia = "tProvincia";
                Object razonSocial = "tRazonSocial";
                Object tipoViaEmpresa = "tTipoViaEmpresa";
                Object direccionEmpresa = "tDireccionEmpresa";
                Object cpEmpresa = "tCpEmpresa";
                Object municipioEmpresa = "tMunicipioEmpresa";
                Object provinciaEmpresa = "tProvinciaEmpresa";
                Object numeroEmpresa = "tNumeroEmpresa";
                Object pisoEmpresa = "tPisoEmpresa";
                Object cif = "tCif";
                Object telefonoEmpresa = "tTelefonoEmpresa";
                Object OfechaNotario = "tFechaNotario";
                Object numeroProtocolo = "tNumeroProtocoloNotario";
                Object duracion = "tDuracionContrato";
                Object entradaVigor = "tEntradaVigor";
                Object precioMantenimiento = "tPrecioMantenimiento";
                Object lugar = "tLugar";
                Object calle = "tCalle";
                Object cp6 = "tCp6";
                Object poblacion = "tPoblacion";
                Object provincia6 = "tProvincia6";
                Object duracion2 = "tDuracionContrato2";
                Object nombreFirma = "tNombreFirma";
                Object razonSocialFirma = "tRazonSocialFirma";
                Object llave = "cbAcuda";
                Object fechaAnexo = "tFechaAnexo";
                Object nombreEmpresaAnexo = "tRazonAnexo";
                Object direccionAnexo = "tDireccionAnexo";
                Object numeroAnexo = "tNumeroDireccionAnexo";
                Object provinciaEmpresaAnexo = "tProvinciaEmpresaAnexo";
                Object municipioPrincipioAnexo = "tMunicipioPrincipioAnexo";
                Object municipioAnexo = "tMunicipioAnexo";
                Object cpAnexo = "tCpAnexo";
                Object cifAnexo = "tCifAnexo";
                Object representanteAnexo = "tRepresentanteAnexo";
                Object cargoRepresentante = "tCargoRepresentanteAnexo";
                Object dniRepresentante = "tDniRepresentante";
                Object firmaRepresentante = "tFirmaRepresentanteAnexo";
                Object provinciaAnexo = "tProvinciaAnexo";
                Object representantePiso = "tPisoAnexo";

                doc.SaveAs2(fileNameCopy);
                doc.Close();

                visible = true;

                doc = wordApp.Documents.Open(

               ref fileNameCopy, ref confirmConversions, ref readOnly, ref addToRecentFiles,
               ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,
               ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,
               ref docDirection, ref notEncoding, ref xmlTransform

               );


                Microsoft.Office.Interop.Word.Range rangeNombre = doc.Bookmarks.get_Item(ref name).Range;

                rangeNombre.Text = contrato.CCLiente.getNombre() + " " + contrato.CCLiente.getApellido();

                Microsoft.Office.Interop.Word.Range rangeDni = doc.Bookmarks.get_Item(ref dni).Range;

                rangeDni.Text = contrato.CCLiente.getDni();

                string tipoViaCliente = "";

                switch (contrato.CCLiente.getTipoVia())
                {
                    case "Calle": tipoViaCliente = "C/";break;
                    case "Avenida": tipoViaCliente = "Av.";break;
                    case "Travesía": tipoViaCliente = "Tr.";break;
                }

                Microsoft.Office.Interop.Word.Range rangeNumeroAbonado = doc.Bookmarks.get_Item(ref numeroAbonado).Range;

                rangeNumeroAbonado.Text = contrato.SNumeroAbonado.ToString();

                Microsoft.Office.Interop.Word.Range rangeNumeroContrato = doc.Bookmarks.get_Item(ref numeroContrato).Range;

                rangeNumeroContrato.Text = contrato.INumeroContrato.ToString();

                Microsoft.Office.Interop.Word.Range rangeFechaAlta = doc.Bookmarks.get_Item(ref fechaAlta).Range;

                rangeFechaAlta.Text = fecha[2] + " de " + meses[Convert.ToUInt32(fecha[1])] + " de " + fecha[0];

                Microsoft.Office.Interop.Word.Range rangeDireccion = doc.Bookmarks.get_Item(ref direccion).Range;

                rangeDireccion.Text = tipoViaCliente+" "+contrato.CCLiente.getDireccion();

                Microsoft.Office.Interop.Word.Range rangeNumero = doc.Bookmarks.get_Item(ref numero).Range;

                rangeNumero.Text = contrato.CCLiente.getNumero();

                Microsoft.Office.Interop.Word.Range rangePiso = doc.Bookmarks.get_Item(ref piso).Range;

                if(!contrato.CCLiente.getPiso().Equals(""))
                    rangePiso.Text =contrato.CCLiente.getPiso() + ",";

                Microsoft.Office.Interop.Word.Range rangeCp = doc.Bookmarks.get_Item(ref cp).Range;

                rangeCp.Text = contrato.CCLiente.getCp();

                Microsoft.Office.Interop.Word.Range rangeMunicipio = doc.Bookmarks.get_Item(ref municipio).Range;//

                rangeMunicipio.Text = contrato.CCLiente.getMunicipio();

                Microsoft.Office.Interop.Word.Range rangeProvincia = doc.Bookmarks.get_Item(ref provincia).Range;

                rangeProvincia.Text = contrato.CCLiente.getProvincia();

                Microsoft.Office.Interop.Word.Range rangeTelefono = doc.Bookmarks.get_Item(ref telefono).Range;

                rangeTelefono.Text = contrato.CCLiente.getTelefono();

                if (contrato.EEmpresa != null)
                {

                    Microsoft.Office.Interop.Word.Range rangeRazonSocial = doc.Bookmarks.get_Item(ref razonSocial).Range;//

                    rangeRazonSocial.Text = contrato.EEmpresa.SRazonSocial;

                    string via = "";

                    switch (contrato.EEmpresa.STipoVia)
                    {
                        case "Calle": via = "C/";break;
                        case "Avenida": via = "Av.";break;
                        case "Travesía": via = "Tr.";break;

                    }

                    Microsoft.Office.Interop.Word.Range rangeDireccionEmpresa = doc.Bookmarks.get_Item(ref direccionEmpresa).Range;
                    rangeDireccionEmpresa.Text = via + contrato.EEmpresa.SDireccion;

                    Microsoft.Office.Interop.Word.Range rangeNumeroEmpresa = doc.Bookmarks.get_Item(ref numeroEmpresa).Range;
                    rangeNumeroEmpresa.Text = contrato.EEmpresa.SNumero;

                    Microsoft.Office.Interop.Word.Range rangePisoEmpresa = doc.Bookmarks.get_Item(ref pisoEmpresa).Range;

                    if(!contrato.EEmpresa.SPiso.Equals(""))
                        rangePisoEmpresa.Text = contrato.EEmpresa.SPiso;

                    Microsoft.Office.Interop.Word.Range rangeCpEmpresa = doc.Bookmarks.get_Item(ref cpEmpresa).Range;//
                    rangeCpEmpresa.Text = contrato.EEmpresa.SCp;

                    Microsoft.Office.Interop.Word.Range rangeMunicipioEmpresa = doc.Bookmarks.get_Item(ref municipioEmpresa).Range;//
                    rangeMunicipioEmpresa.Text = contrato.EEmpresa.SMunicipio;

                    Microsoft.Office.Interop.Word.Range rangeProvinciaEmpresa = doc.Bookmarks.get_Item(ref provinciaEmpresa).Range;//
                    rangeProvinciaEmpresa.Text = contrato.EEmpresa.SProvincia;

                    Microsoft.Office.Interop.Word.Range rangeCif = doc.Bookmarks.get_Item(ref cif).Range;
                    rangeCif.Text = contrato.EEmpresa.SCif;

                    String fechaNotario = Data.formatearFecha(contrato.EEmpresa.SFechaNotario);
                    String[] fechaNotarioAux = fechaNotario.Split('-');

                    Microsoft.Office.Interop.Word.Range rangeFechaNotario = doc.Bookmarks.get_Item(ref OfechaNotario).Range;//
                    rangeFechaNotario.Text = fechaNotarioAux[2] + " de " + meses[Convert.ToInt32(fechaNotarioAux[1])] + " de " + fechaNotarioAux[0];

                    Microsoft.Office.Interop.Word.Range rangeNumeroProtocolo = doc.Bookmarks.get_Item(ref numeroProtocolo).Range;
                    rangeNumeroProtocolo.Text = contrato.EEmpresa.SNumeroProtocolo;

                }

                String[] fechaEntradaVigor = Data.formatearFecha(contrato.SFechaVigor).Split('-');

                Microsoft.Office.Interop.Word.Range rangeFechaVigor = doc.Bookmarks.get_Item(ref entradaVigor).Range;

                rangeFechaVigor.Text = fechaEntradaVigor[2] + "/" + fechaEntradaVigor[1] + "/" + fechaEntradaVigor[0];

                Microsoft.Office.Interop.Word.Range rangeDuracionContrato = doc.Bookmarks.get_Item(ref duracion).Range;
                rangeDuracionContrato.Text = contrato.IDuracion.ToString();

                Microsoft.Office.Interop.Word.Range rangeDuracionContrato2 = doc.Bookmarks.get_Item(ref duracion2).Range;
                rangeDuracionContrato2.Text = contrato.IDuracion.ToString();

                Microsoft.Office.Interop.Word.Range rangePrecioMantenimiento = doc.Bookmarks.get_Item(ref precioMantenimiento).Range;

                rangePrecioMantenimiento.Text = contrato.IPrecioMantenimiento.ToString();


                Microsoft.Office.Interop.Word.Range rangeLugar = doc.Bookmarks.get_Item(ref lugar).Range;

                rangeLugar.Text = contrato.SLugar;

                Microsoft.Office.Interop.Word.Range rangeCalle = doc.Bookmarks.get_Item(ref calle).Range;

                rangeCalle.Text = contrato.SCalle;

                Microsoft.Office.Interop.Word.Range rangeCp6 = doc.Bookmarks.get_Item(ref cp6).Range;

                rangeCp6.Text = contrato.SCp;

                Microsoft.Office.Interop.Word.Range rangePoblacion6 = doc.Bookmarks.get_Item(ref poblacion).Range;

                rangePoblacion6.Text = contrato.SPoblacion;

                Microsoft.Office.Interop.Word.Range rangeProvincia6 = doc.Bookmarks.get_Item(ref provincia6).Range;

                rangeProvincia6.Text = contrato.SProvincia;

                Microsoft.Office.Interop.Word.Range rangeNombreFirma = doc.Bookmarks.get_Item(ref nombreFirma).Range;
                rangeNombreFirma.Text = contrato.CCLiente.getNombre() + " " + contrato.CCLiente.getApellido();

                if (contrato.EEmpresa != null)
                {
                    Microsoft.Office.Interop.Word.Range rangeRazonSocialFirma = doc.Bookmarks.get_Item(ref razonSocialFirma).Range;
                    rangeRazonSocialFirma.Text = contrato.AAnexo.SRazonSocial;
                }


                Microsoft.Office.Interop.Word.ContentControls cc = doc.SelectContentControlsByTitle("cbAcuda");

                if (cc != null) { }
                    

                Microsoft.Office.Interop.Word.Range rangeMunicipioPrincipioAnexo = doc.Bookmarks.get_Item(ref municipioPrincipioAnexo).Range;
                rangeMunicipioPrincipioAnexo.Text = contrato.AAnexo.SMunicipio;

                String[] f = Data.formatearFecha(contrato.SFechaVigor).Split('-');

                Microsoft.Office.Interop.Word.Range rangeFechaAnexo = doc.Bookmarks.get_Item(ref fechaAnexo).Range;

                rangeFechaAnexo.Text = f[2] + " de " + meses[Convert.ToInt32(f[1])] + " de " + f[0];

                if (contrato.EEmpresa != null)
                {

                    Microsoft.Office.Interop.Word.Range rangeNombreEmpresaAnexo = doc.Bookmarks.get_Item(ref nombreEmpresaAnexo).Range;
                    rangeNombreEmpresaAnexo.Text = contrato.AAnexo.SRazonSocial;

                    Microsoft.Office.Interop.Word.Range rangeCargoRepresentanteAnexo = doc.Bookmarks.get_Item(ref cargoRepresentante).Range;//
                    rangeCargoRepresentanteAnexo.Text = contrato.AAnexo.SRepresentantePuesto;


                    Microsoft.Office.Interop.Word.Range rangeCifAnexo = doc.Bookmarks.get_Item(ref cifAnexo).Range;
                    rangeCifAnexo.Text = contrato.AAnexo.SCif;
                }

                Microsoft.Office.Interop.Word.Range rangeDireccionAnexo = doc.Bookmarks.get_Item(ref direccionAnexo).Range;

                rangeDireccionAnexo.Text = contrato.AAnexo.SDireccion;

                Microsoft.Office.Interop.Word.Range rangeNumeroDirAnexo = doc.Bookmarks.get_Item(ref numeroAnexo).Range;

                rangeNumeroDirAnexo.Text = contrato.AAnexo.SNumero;

                Microsoft.Office.Interop.Word.Range rangePisoAnexo = doc.Bookmarks.get_Item(ref representantePiso).Range;

                rangePisoAnexo.Text =  contrato.AAnexo.SPiso+ ",";

                Microsoft.Office.Interop.Word.Range rangeMunicipioAnexo = doc.Bookmarks.get_Item(ref municipioAnexo).Range;

                rangeMunicipioAnexo.Text = contrato.AAnexo.SMunicipio;

                Microsoft.Office.Interop.Word.Range rangeProvinciaAnexo = doc.Bookmarks.get_Item(ref provinciaAnexo).Range;

                rangeProvinciaAnexo.Text = contrato.AAnexo.SProvincia;

                Microsoft.Office.Interop.Word.Range rangeCpAnexo = doc.Bookmarks.get_Item(ref cpAnexo).Range;

                rangeCpAnexo.Text = contrato.AAnexo.SCp;


                Microsoft.Office.Interop.Word.Range rangeRepresentanteAnexo = doc.Bookmarks.get_Item(ref representanteAnexo).Range;

                rangeRepresentanteAnexo.Text = contrato.AAnexo.SRepresentanteNombre;

                Microsoft.Office.Interop.Word.Range rangeDniRepresentanteAnexo = doc.Bookmarks.get_Item(ref dniRepresentante).Range;//

                rangeDniRepresentanteAnexo.Text = contrato.AAnexo.SRepresentanteDni;

                Microsoft.Office.Interop.Word.Range rangeFirmaRepresentanteAnexo = doc.Bookmarks.get_Item(ref firmaRepresentante).Range;//

                rangeFirmaRepresentanteAnexo.Text = contrato.AAnexo.SFirma;

                saveFileDialog1.AddExtension = true;
                saveFileDialog1.DefaultExt = "doc";
                saveFileDialog1.Filter = "Documento word (.doc)|*.doc|Plantilla word (.dotx)|*.dotx|Documento PDF (.pdf)|*.pdf";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    //GUARDARLO EN PDF ARREGLARR
                    doc.SaveAs2(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                        , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    doc.Close(false, Type.Missing, Type.Missing);
                    wordApp.Quit(false, false, false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    this.Close();


                }
                else
                {

                    doc.Close(false, Type.Missing, Type.Missing);
                    wordApp.Quit(false, false, false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                doc.Close();
                MessageBox.Show(ex.ToString());
            }
        }

        public void rellenarContrato(Contrato contrato)
        {
            contrato_Near(contrato);
            contrato_Ibercra(contrato);
           
        }


        private void GenerarDocumento_Load(object sender, EventArgs e)
        {

        }
    }
}
