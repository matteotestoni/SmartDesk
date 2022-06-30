using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtTemp;
    public DataTable dtTempFigli;
    public string strFROMNet = "";
    public string strRisultato = "";
    public string strTemp = "";
    
    public DataTable dtCoreModulesOptionsValue;
    public string strTheme="";
    public string strH1 = "Generazione url";
    public string strTitle = "";
    public string strTitolo = "";
    public string strDescription = "";
    public string strDescrizione = "";
    public string strKeywords = "";
    public DataTable dtCoreUrlRedirect;
    public DataTable dtCoreUrlRewrite;

    public DataTable dtProvince;
    public DataTable dtComuni;
    public DataTable dtAsteCategorie;
    
    
    public DataTable dtAnnunciCategorie;
    public DataTable dtAnnunciCategoriePadri;
    public DataTable dtAnnunciCategorieFigli;
    
    public DataTable dtVeicoliCategoria;
    public DataTable dtVeicoliCarrozzeria;
    public DataTable dtVeicoliMarca;
    public DataTable dtVeicoliTipo;
    public DataTable dtVeicoliModello;
    public DataTable dtVeicoliTestiSEO;  

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strSQL="";
      string strProvincie_UrlKey="";
      string strProvincie_Ky="";
      string strComuni_UrlKey="";
      string strComuni_Ky="";
      string strCoreUrlRedirect_UrlSource="";
      string strCoreUrlRedirect_UrlDestination="";
      string strCoreUrlRewrite_UrlSource="";
      string strCoreUrlRewrite_UrlDestination="";

      

      if (Smartdesk.Login.Verify){
          	dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);

            dtCoreModulesOptionsValue = new DataTable("Options");
            strWHERENet="CoreModulesOptions_Code='design'";
            strORDERNet = "CoreModulesOptionsValue_Ky";
            strFROMNet = "CoreModulesOptionsValue";
            dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtCoreModulesOptionsValue.Rows.Count>0){
              strTheme=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
            }else{
              strTheme="base";
            }                    

            strFROMNet = "Province_Vw";
            strORDERNet = "Province_Provincia";
            strWHERENet="Nazioni_Ky=105";
            dtProvince = new DataTable("Province");
            dtProvince = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 10000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
						strRisultato="<ul>";            
            
            //account
            strRisultato+="<li>Account</li>"; 
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='account';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/login.html','/frontend/" + strTheme + "/account/login.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/registrazione.html','/frontend/" + strTheme + "/account/registrazione.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/registrazione-completata.html','/frontend/" + strTheme + "/account/registrazione-completata.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/modifica-password.html','/frontend/" + strTheme + "/account/modifica-password.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/recupera-password.html','/frontend/" + strTheme + "/account/recupera-password.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/area-personale.html','/frontend/" + strTheme + "/account/area-personale.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/modifica-dati.html','/frontend/" + strTheme + "/account/modifica-dati.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/modifica-privacy.html','/frontend/" + strTheme + "/account/modifica-privacy.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/indirizzi-spedizione.html','/frontend/" + strTheme + "/account/indirizzi-spedizione.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/ordini.html','/frontend/" + strTheme + "/account/ordini.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/annunci.html','/frontend/" + strTheme + "/account/annunci.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/preferiti.html','/frontend/" + strTheme + "/account/preferiti.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/confronto.html','/frontend/" + strTheme + "/account/confronto.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/aste.html','/frontend/" + strTheme + "/account/aste.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/lotti.html','/frontend/" + strTheme + "/account/lotti.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/cauzioni.html','/frontend/" + strTheme + "/account/cauzioni.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/confronto.html','/frontend/" + strTheme + "/account/confronto.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('account', '', '/account/logout.html','/frontend/" + strTheme + "/account/logout.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            //checkout
            strRisultato+="<li>checkout</li>"; 
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='checkout';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('checkout', '', '/checkout/carrello.html','/frontend/" + strTheme + "/checkout/carrello.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('checkout', '', '/checkout/conferma-carrello.html','/frontend/" + strTheme + "/checkout/carrello-conferma.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            /*
            //aste
            strRisultato+="<li>Aste</li>"; 
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='aste';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('aste', '', '/aste/categorie.html','/frontend/" + strTheme + "/aste/elenco-categorie-aste.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('aste', '', '/aste/inserisci.html','/frontend/" + strTheme + "/aste/inserimento-asta.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strFROMNet = "AsteCategorie";
            strORDERNet = "AsteCategorie_Ky";
            strWHERENet="";
            dtAsteCategorie = new DataTable("AsteCategorie");
            dtAsteCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            for (int i = 0; i < dtAsteCategorie.Rows.Count; i++){
              strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('aste', '', '/aste/" + dtAsteCategorie.Rows[i]["AsteCategorie_Url"].ToString() + "/" + dtAsteCategorie.Rows[i]["AsteCategorie_Url"].ToString() + ".html','/frontend/" + strTheme + "/aste/elenco-aste.aspx?AsteCategorie_Ky=" + dtAsteCategorie.Rows[i]["AsteCategorie_Ky"].ToString() + "'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            */
            
            
            //veicoli
            /*
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='VeicoliCarrozzeria';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='VeicoliCategoria';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='VeicoliTipo';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='Veicoli';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strRisultato+="<li>Veicoli</li>"; 
            strCoreUrlRewrite_UrlSource="/veicoli/ricerca-veicoli.html";
            strFROMNet = "CoreUrlRewrite";
            strORDERNet = "CoreUrlRewrite_Ky";
            strWHERENet="CoreUrlRewrite_UrlSource='" + strCoreUrlRewrite_UrlSource + "'";
            dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        	  strCoreUrlRewrite_UrlDestination="/frontend/base/veicoli/elenco-veicoli.aspx?fromrewrite=1";          
            if (dtCoreUrlRewrite!=null && dtCoreUrlRewrite.Rows.Count<1){
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('Veicoli_Ricerca', 'ricerca', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }else{
              strSQL="UPDATE CoreUrlRewrite SET CoreEntities_Code='Veicoli_Ricerca', CoreEntities_KeyValue='ricerca', CoreUrlRewrite_UrlDestination='" + strCoreUrlRewrite_UrlDestination + "', CoreUrlRewrite_UserUpdate=0, CoreUrlRewrite_DateUpdate=GETDATE()";
              strSQL+=" WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            strCoreUrlRewrite_UrlSource="/auto/ricerca-auto.html";
            strFROMNet = "CoreUrlRewrite";
            strORDERNet = "CoreUrlRewrite_Ky";
            strWHERENet="CoreUrlRewrite_UrlSource='" + strCoreUrlRewrite_UrlSource + "'";
            dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        	  strCoreUrlRewrite_UrlDestination="/frontend/base/veicoli/elenco-veicoli.aspx?fromrewrite=1&VeicoliTipo_Ky=1";          
            if (dtCoreUrlRewrite!=null && dtCoreUrlRewrite.Rows.Count<1){
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('Veicoli_Ricerca', 'ricerca', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }else{
              strSQL="UPDATE CoreUrlRewrite SET CoreEntities_Code='Veicoli_Ricerca', CoreEntities_KeyValue='ricerca', CoreUrlRewrite_UrlDestination='" + strCoreUrlRewrite_UrlDestination + "', CoreUrlRewrite_UserUpdate=0, CoreUrlRewrite_DateUpdate=GETDATE()";
              strSQL+=" WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            strCoreUrlRewrite_UrlSource="/auto/ricerca-moto.html";
            strFROMNet = "CoreUrlRewrite";
            strORDERNet = "CoreUrlRewrite_Ky";
            strWHERENet="CoreUrlRewrite_UrlSource='" + strCoreUrlRewrite_UrlSource + "'";
            dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        	  strCoreUrlRewrite_UrlDestination="/frontend/base/veicoli/elenco-veicoli.aspx?fromrewrite=1&VeicoliTipo_Ky=1";          
            if (dtCoreUrlRewrite!=null && dtCoreUrlRewrite.Rows.Count<1){
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('Veicoli_Ricerca', 'ricerca', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }else{
              strSQL="UPDATE CoreUrlRewrite SET CoreEntities_Code='Veicoli_Ricerca', CoreEntities_KeyValue='ricerca', CoreUrlRewrite_UrlDestination='" + strCoreUrlRewrite_UrlDestination + "', CoreUrlRewrite_UserUpdate=0, CoreUrlRewrite_DateUpdate=GETDATE()";
              strSQL+=" WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('VeicoliCategoria', '', '/veicoli/categorie.html','/frontend/" + strTheme + "/veicoli/elenco-categorie-veicoli.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('VeicoliTipo', '', '/veicoli/tipo.html','/frontend/" + strTheme + "/veicoli/elenco-tipo-veicoli.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            
            strFROMNet = "VeicoliTipo";
            strORDERNet = "VeicoliTipo_Titolo";
            strWHERENet="";
            dtVeicoliTipo = new DataTable("VeicoliTipo");
            dtVeicoliTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTipo_Ky", strWHERENet, strORDERNet, 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            for (int iVeicoliTipo = 0; iVeicoliTipo < dtVeicoliTipo.Rows.Count; iVeicoliTipo++){
              //per ogni tipo veicolo genero le carrozzerie

              strFROMNet = "VeicoliMarca";
              strORDERNet = "VeicoliMarca_Importante DESC, VeicoliMarca_Titolo";
              strWHERENet="VeicoliTipo_Ky=" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_Ky"].ToString();
              dtVeicoliMarca = new DataTable("VeicoliMarca");
              dtVeicoliMarca = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliMarca_Ky", strWHERENet, strORDERNet, 1, 10,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

              strFROMNet = "VeicoliCarrozzeria";
              strORDERNet = "VeicoliCarrozzeria_Ordine";
              strWHERENet="VeicoliTipo_Ky=" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_Ky"].ToString();
              dtVeicoliCarrozzeria = new DataTable("VeicoliCarrozzeria");
              dtVeicoliCarrozzeria = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliCarrozzeria_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              for (int i = 0; i < dtVeicoliCarrozzeria.Rows.Count; i++){
                  //testo SEO carrozzeria
                  strTitle=dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Title"].ToString();
                  strDescription=dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Description"].ToString();
                  strKeywords=dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Descrizione"].ToString();
                  strTitolo=dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Title"].ToString();
                  strDescrizione=dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Description"].ToString().Replace("'","''");
                  strFROMNet = "VeicoliTestiSEO";
                  strORDERNet = "VeicoliTestiSEO_Ky";
                  strWHERENet="VeicoliCarrozzeria_Ky Is Null AND VeicoliModello_Ky Is Null AND VeicoliCarburante_Ky Is Null AND VeicoliCategoria_Ky Is Null AND VeicoliCarrozzeria_Ky=" + dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Ky"].ToString() + " AND VeicoliCambio_Ky Is Null";
                  dtVeicoliTestiSEO = new DataTable("VeicoliTestiSEO");
                  dtVeicoliTestiSEO = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTestiSEO_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtVeicoliTestiSEO.Rows.Count<1){
                    strSQL="INSERT INTO VeicoliTestiSEO (VeicoliTipo_Ky, VeicoliMarca_Ky,VeicoliModello_Ky,VeicoliCategoria_Ky,VeicoliCarburante_Ky,VeicoliCarrozzeria_Ky,VeicoliCambio_Ky,VeicoliTestiSEO_Title,VeicoliTestiSEO_Description,VeicoliTestiSEO_Keywords,VeicoliTestiSEO_Titolo,VeicoliTestiSEO_Descrizione, Lingue_Ky) VALUES";
                    strSQL+=" (" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_Ky"].ToString() + ", Null, Null, Null, Null, " + dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Ky"].ToString().ToLower() + ", Null,'" + strTitle + "','" + strDescription + "','" + strKeywords + "','" + strTitolo + "','" + strDescrizione + "', 1)";
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }
                  //rewrite carrozzeria
                  strCoreUrlRewrite_UrlSource="/" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_UrlKey"].ToString() + "/" + dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_UrlKey"].ToString() + ".html";
                  strFROMNet = "CoreUrlRewrite";
                  strORDERNet = "CoreUrlRewrite_Ky";
                  strWHERENet="CoreUrlRewrite_UrlSource='" + strCoreUrlRewrite_UrlSource + "'";
                  dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              	  strCoreUrlRewrite_UrlDestination="/frontend/" + strTheme + "/veicoli/elenco-veicoli.aspx?fromrewrite=1&VeicoliTipo_Ky=" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_Ky"].ToString() + "&VeicoliCarrozzeria_Ky=" + dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Ky"].ToString();          
                  if (dtCoreUrlRewrite!=null && dtCoreUrlRewrite.Rows.Count<1){
                    strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
                    strSQL+="('VeicoliCarrozzeria', '" + dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Ky"].ToString() + "', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', 0, GETDATE())";
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }else{
                    strSQL="UPDATE CoreUrlRewrite SET CoreEntities_Code='VeicoliCarrozzeria', CoreEntities_KeyValue='" + dtVeicoliCarrozzeria.Rows[i]["VeicoliCarrozzeria_Ky"].ToString() + "', CoreUrlRewrite_UrlDestination='" + strCoreUrlRewrite_UrlDestination + "', CoreUrlRewrite_UserUpdate=0, CoreUrlRewrite_DateUpdate=GETDATE()";
                    strSQL+=" WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }
              }     
              
              strFROMNet = "VeicoliCategoria";
              strORDERNet = "VeicoliCategoria_Ordine";
              strWHERENet="VeicoliCategoria_Attiva=1 AND VeicoliTipo_Ky=" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_Ky"].ToString();
              dtVeicoliCategoria = new DataTable("VeicoliCategoria");
              dtVeicoliCategoria = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliCategoria_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              for (int j = 0; j < dtVeicoliCategoria.Rows.Count; j++){
            	  //testo seo categoria
                strFROMNet = "VeicoliTestiSEO";
                strORDERNet = "VeicoliTestiSEO_Ky";
                strWHERENet = "VeicoliMarca_Ky Is Null AND VeicoliModello_Ky Is Null AND VeicoliCarburante_Ky Is Null AND VeicoliCategoria_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + " AND VeicoliCarrozzeria_Ky Is Null AND VeicoliCambio_Ky Is Null";
                dtVeicoliTestiSEO = new DataTable("VeicoliTestiSEO");
                dtVeicoliTestiSEO = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTestiSEO_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtVeicoliTestiSEO.Rows.Count<1){
                  strSQL="INSERT INTO VeicoliTestiSEO (VeicoliTipo_Ky, VeicoliMarca_Ky,VeicoliModello_Ky,VeicoliCategoria_Ky,VeicoliCarburante_Ky,VeicoliCarrozzeria_Ky,VeicoliCambio_Ky,VeicoliTestiSEO_Title,VeicoliTestiSEO_Description,VeicoliTestiSEO_Keywords,VeicoliTestiSEO_Titolo,VeicoliTestiSEO_Descrizione, Lingue_Ky) VALUES";
                  strSQL+=" (" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_Ky"].ToString() + ",Null, Null, " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + ", Null, Null, Null,'" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Descrizione"].ToString().Replace("'","''") + "','" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Descrizione"].ToString().Replace("'","''") + "','" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Descrizione"].ToString().Replace("'","''") + "','" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Descrizione"].ToString().Replace("'","''") + "','" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Descrizione"].ToString().Replace("'","''") + "',1)";
                  new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                }
                  //rewrite categoria
                  strCoreUrlRewrite_UrlSource="/" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_UrlKey"].ToString() + "/" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_UrlKey"].ToString() + ".html";
              	  strCoreUrlRewrite_UrlDestination="/frontend/" + strTheme + "/veicoli/elenco-veicoli.aspx?fromrewrite=1&VeicoliTipo_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliTipo_Ky"].ToString() + "&VeicoliCategoria_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString();          
                  strFROMNet = "CoreUrlRewrite";
                  strORDERNet = "CoreUrlRewrite_Ky";
                  strWHERENet = "CoreUrlRewrite_UrlSource='" + strCoreUrlRewrite_UrlSource + "'";
                  dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtCoreUrlRewrite!=null && dtCoreUrlRewrite.Rows.Count<1){
                    strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
                    strSQL+="('VeicoliCategoria', '" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + "', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', 0, GETDATE())";
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }else{
                    strSQL="UPDATE CoreUrlRewrite SET CoreEntities_Code='VeicoliCategoria', CoreEntities_KeyValue='" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + "', CoreUrlRewrite_UrlDestination='" + strCoreUrlRewrite_UrlDestination + "', CoreUrlRewrite_UserUpdate=0, CoreUrlRewrite_DateUpdate=GETDATE()";
                    strSQL+=" WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }
                    for (int i = 0; i < dtVeicoliMarca.Rows.Count; i++){
                      strTitle=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_DescrizioneWEB"].ToString();
                      strDescription=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_DescrizioneWEB"].ToString();
                      strKeywords=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_DescrizioneWEB"].ToString();
                      strTitolo=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_DescrizioneWEB"].ToString();
                      strDescrizione=dtVeicoliMarca.Rows[i]["VeicoliMarca_Descrizione"].ToString().Replace("'","''");
                      
                      strFROMNet = "VeicoliTestiSEO";
                      strORDERNet = "VeicoliTestiSEO_Ky";
                      strWHERENet="VeicoliMarca_Ky=" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString().ToLower() + " AND VeicoliModello_Ky Is Null AND VeicoliCarburante_Ky Is Null AND VeicoliCategoria_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + " AND VeicoliCarrozzeria_Ky Is Null AND VeicoliCambio_Ky Is Null";
                      dtVeicoliTestiSEO = new DataTable("VeicoliTestiSEO");
                      dtVeicoliTestiSEO = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTestiSEO_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      if (dtVeicoliTestiSEO.Rows.Count<1){
                        strSQL="INSERT INTO VeicoliTestiSEO (VeicoliTipo_Ky, VeicoliMarca_Ky,VeicoliModello_Ky,VeicoliCategoria_Ky,VeicoliCarburante_Ky,VeicoliCarrozzeria_Ky,VeicoliCambio_Ky,VeicoliTestiSEO_Title,VeicoliTestiSEO_Description,VeicoliTestiSEO_Keywords,VeicoliTestiSEO_Titolo,VeicoliTestiSEO_Descrizione, Lingue_Ky) VALUES";
                        strSQL+=" (" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_Ky"].ToString() + "," + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString().ToLower() + ", Null, " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + ", Null, Null, Null,'" + strTitle + "','" + strDescription + "','" + strKeywords + "','" + strTitolo + "','" + strDescrizione + "',1)";
                        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      }
                      
                      //rewrite categoria + marca
                	    strCoreUrlRewrite_UrlSource="/" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_UrlKey"].ToString() + "/" + dtVeicoliMarca.Rows[i]["VeicoliMarca_UrlKey"].ToString().ToLower() + "-" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_UrlKey"].ToString() + ".html";
                	    strCoreUrlRewrite_UrlDestination="/frontend/" + strTheme + "/veicoli/elenco-veicoli.aspx?fromrewrite=1&VeicoliMarca_Ky=" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString().ToLower() + "&VeicoliTipo_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliTipo_Ky"].ToString() + "&VeicoliCategoria_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString();          
                      strFROMNet = "CoreUrlRewrite";
                      strORDERNet = "CoreUrlRewrite_Ky";
                      strWHERENet="CoreUrlRewrite_UrlSource='" + strCoreUrlRewrite_UrlSource + "'";
                      dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      if (dtCoreUrlRewrite!=null && dtCoreUrlRewrite.Rows.Count<1){
                        strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
                        strSQL+="('VeicoliCategoria', '" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + "-" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString() + "', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', 0, GETDATE())";
                        //Response.Write(strSQL + "<hr>");
                        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      }else{
                        strSQL="UPDATE CoreUrlRewrite SET CoreEntities_Code='VeicoliCategoria', CoreEntities_KeyValue='" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + "-" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString() + "', CoreUrlRewrite_UrlDestination='" + strCoreUrlRewrite_UrlDestination + "', CoreUrlRewrite_UserUpdate=0, CoreUrlRewrite_DateUpdate=GETDATE()";
                        strSQL+=" WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
                        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      }
                                      
                      strFROMNet = "VeicoliModello";
                      strORDERNet = "VeicoliModello_Titolo";
                      strWHERENet="VeicoliModello_Dismesso=0 AND VeicoliMarca_Ky=" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString().ToLower();
                      dtVeicoliModello = new DataTable("VeicoliModello");
                      dtVeicoliModello = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliModello_Ky", strWHERENet, strORDERNet, 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      for (int x = 0; x < dtVeicoliModello.Rows.Count; x++){
                    	  //testo seo categoria + marca + modello
                          strTitle=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliModello.Rows[x]["VeicoliModello_Titolo"].ToString().ToLower() + " " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_DescrizioneWEB"].ToString().Replace("'","''");
                          strDescription=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliModello.Rows[x]["VeicoliModello_Titolo"].ToString().ToLower() + " " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_DescrizioneWEB"].ToString().Replace("'","''");
                          strKeywords=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliModello.Rows[x]["VeicoliModello_Titolo"].ToString().ToLower() + " " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_DescrizioneWEB"].ToString().Replace("'","''");
                          strTitolo=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliModello.Rows[x]["VeicoliModello_Titolo"].ToString().ToLower() + " " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_DescrizioneWEB"].ToString().Replace("'","''");
                          strDescrizione=dtVeicoliModello.Rows[x]["VeicoliModello_Descrizione"].ToString().Replace("'","''");
                          
                          strFROMNet = "VeicoliTestiSEO";
                          strORDERNet = "VeicoliTestiSEO_Ky";
                          strWHERENet="VeicoliMarca_Ky=" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString().ToLower() + " AND VeicoliModello_Ky=" + dtVeicoliModello.Rows[x]["VeicoliModello_Ky"].ToString().ToLower() + " AND VeicoliCarburante_Ky Is Null AND VeicoliCategoria_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + " AND VeicoliCarrozzeria_Ky Is Null AND VeicoliCambio_Ky Is Null";
                          dtVeicoliTestiSEO = new DataTable("VeicoliTestiSEO");
                          dtVeicoliTestiSEO = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTestiSEO_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                          if (dtVeicoliTestiSEO.Rows.Count<1){
                              strSQL="INSERT INTO VeicoliTestiSEO (VeicoliTipo_Ky, VeicoliMarca_Ky,VeicoliModello_Ky,VeicoliCategoria_Ky,VeicoliCarburante_Ky,VeicoliCarrozzeria_Ky,VeicoliCambio_Ky,VeicoliTestiSEO_Title,VeicoliTestiSEO_Description,VeicoliTestiSEO_Keywords,VeicoliTestiSEO_Titolo,VeicoliTestiSEO_Descrizione, Lingue_Ky) VALUES";
                              strSQL+=" (" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_Ky"].ToString() + "," + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString().ToLower() + ", " + dtVeicoliModello.Rows[x]["VeicoliModello_Ky"].ToString().ToLower() + ", " + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + ", Null, Null, Null,'" + strTitle + "','" + strDescription + "','" + strKeywords + "','" + strTitolo + "','" + strDescrizione + "',1)";
                              //Response.Write(strSQL + "<hr>");
                              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                          }
                          //rewrite categoria + marca + modello
                    	    strCoreUrlRewrite_UrlSource="/" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_UrlKey"].ToString() + "/" + dtVeicoliMarca.Rows[i]["VeicoliMarca_UrlKey"].ToString().ToLower() + "/" + dtVeicoliMarca.Rows[i]["VeicoliMarca_UrlKey"].ToString().ToLower() + "-" + dtVeicoliModello.Rows[x]["VeicoliModello_UrlKey"].ToString().ToLower() + "-" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_UrlKey"].ToString() + ".html";
                    	    strCoreUrlRewrite_UrlDestination="/frontend/" + strTheme + "/veicoli/elenco-veicoli.aspx?fromrewrite=1&VeicoliModello_Ky=" + dtVeicoliModello.Rows[x]["VeicoliModello_Ky"].ToString().ToLower() + "&VeicoliMarca_Ky=" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString().ToLower() + "&VeicoliTipo_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliTipo_Ky"].ToString() + "&VeicoliCategoria_Ky=" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString();          
                          strFROMNet = "CoreUrlRewrite";
                          strORDERNet = "CoreUrlRewrite_Ky";
                          strWHERENet="CoreUrlRewrite_UrlSource='" + strCoreUrlRewrite_UrlSource + "'";
                          dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                          if (dtCoreUrlRewrite!=null && dtCoreUrlRewrite.Rows.Count<1){
                            strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
                            strSQL+="('VeicoliCategoria', '" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + "-" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString() + "-" + dtVeicoliModello.Rows[x]["VeicoliModello_Ky"].ToString() + "', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', 0, GETDATE())";
                            //Response.Write(strSQL + "<hr>");
                            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                          }else{
                            strSQL="UPDATE CoreUrlRewrite SET CoreEntities_Code='VeicoliCategoria', CoreEntities_KeyValue='" + dtVeicoliCategoria.Rows[j]["VeicoliCategoria_Ky"].ToString() + "-" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString() + "-" + dtVeicoliModello.Rows[x]["VeicoliModello_Ky"].ToString() + "', CoreUrlRewrite_UrlDestination='" + strCoreUrlRewrite_UrlDestination + "', CoreUrlRewrite_UserUpdate=0, CoreUrlRewrite_DateUpdate=GETDATE()";
                            strSQL+=" WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
                            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                          }
                      }
                  } 
              }  

              for (int i = 0; i < dtVeicoliMarca.Rows.Count; i++){
                  //rewrite marca
                  strCoreUrlRewrite_UrlSource="/" + dtVeicoliTipo.Rows[iVeicoliTipo]["VeicoliTipo_UrlKey"].ToString() + "/" + dtVeicoliMarca.Rows[i]["VeicoliMarca_UrlKey"].ToString() + ".html";
            	    strCoreUrlRewrite_UrlDestination="/frontend/" + strTheme + "/veicoli/elenco-veicoli.aspx?fromrewrite=1&VeicoliTipo_Ky=" + dtVeicoliMarca.Rows[i]["VeicoliTipo_Ky"].ToString() + "&VeicoliMarca_Ky=" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString();          
                  strFROMNet = "CoreUrlRewrite";
                  strORDERNet = "CoreUrlRewrite_Ky";
                  strWHERENet="CoreUrlRewrite_UrlSource='" + strCoreUrlRewrite_UrlSource + "'";
                  dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtCoreUrlRewrite!=null && dtCoreUrlRewrite.Rows.Count<1){
                    strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
                    strSQL+="('VeicoliMarca', '" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString() + "', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', 0, GETDATE())";
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }else{
                    strSQL="UPDATE CoreUrlRewrite SET CoreEntities_Code='VeicoliMarca', CoreEntities_KeyValue='" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString() + "', CoreUrlRewrite_UrlDestination='" + strCoreUrlRewrite_UrlDestination + "', CoreUrlRewrite_UserUpdate=0, CoreUrlRewrite_DateUpdate=GETDATE()";
                    strSQL+=" WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }
              }
            
            }

            //contatti
            strRisultato+="<li>Contatti</li>"; 
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='contatti';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('contatti', '', '/contatti/contatti.html','/frontend/" + strTheme + "/contatti/contatti.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            */
            
            //cantieri
            /*
            strRisultato+="<li>Cantieri</li>"; 
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='cantieri';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='cantieri';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('cantieri', '', '/immobili/cantieri-provincia.html','/frontend/" + strTheme + "/immobili/elenco-province-cantieri.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('cantieri', '', '/immobili/inserisci-cantiere.html','/frontend/" + strTheme + "/immobili/inserimento-cantieri.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            for (int i = 0; i < dtProvince.Rows.Count; i++){
              strProvincie_UrlKey=dtProvince.Rows[i]["Province_ProvinciaHTML"].ToString().ToLower();
              strProvincie_Ky=dtProvince.Rows[i]["Province_Ky"].ToString().ToLower();
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('cantieri', '" + strProvincie_Ky + "', '/immobili/" + strProvincie_UrlKey + "/cantieri-nuove-costruzioni-" + strProvincie_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-cantieri.aspx?fromrewrite=1&Province_Ky=" + strProvincie_Ky + "&page=1', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }*/

            //immobili
            /*
            strRisultato+="<li>Immobili</li>"; 
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='immobili';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('immobili', '', '/immobili/provincia.html','/frontend/" + strTheme + "/immobili/elenco-province-immobili.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('immobili', '', '/immobili/inserisci.html','/frontend/" + strTheme + "/immobili/inserimento-immobile.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            for (int i = 0; i < dtProvince.Rows.Count; i++){
              strProvincie_UrlKey=dtProvince.Rows[i]["Province_ProvinciaHTML"].ToString().ToLower();
              strProvincie_Ky=dtProvince.Rows[i]["Province_Ky"].ToString().ToLower();
              //vendita case per provincia
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strProvincie_Ky + "', '/immobili/" + strProvincie_UrlKey + "/vendita-case-provincia-" + strProvincie_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliCategoria_Ky=2&Province_Ky=" + strProvincie_Ky + "&page=1&chiave=0', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //affitto case per provincia
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strProvincie_Ky + "', '/immobili/" + strProvincie_UrlKey + "/affitto-case-provincia-" + strProvincie_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliCategoria_Ky=1&Province_Ky=" + strProvincie_Ky + "&page=1&chiave=0', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //agenzie-immobiliari-provincia
              strSQL = "INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL += "('immobili', '" + strProvincie_Ky + "', '/immobili/" + strProvincie_UrlKey + "/agenzie-immobiliari-provincia-" + strProvincie_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-agenzie.aspx?fromrewrite=1&Province_Ky=" + strProvincie_Ky + "&page=1&chiave=10', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
      
            strFROMNet = "Comuni_Vw";
            strORDERNet = "Comuni_Comune";
            strWHERENet="Nazioni_Ky=105";
            dtComuni = new DataTable("Comuni");
            dtComuni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 20000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            for (int i = 0; i < dtComuni.Rows.Count; i++){
              strProvincie_UrlKey=dtComuni.Rows[i]["Province_ProvinciaHTML"].ToString().ToLower();
              strProvincie_Ky=dtComuni.Rows[i]["Province_Ky"].ToString().ToLower();
              strComuni_UrlKey=dtComuni.Rows[i]["Comuni_ComuneHTML"].ToString().ToLower();
              strComuni_Ky=dtComuni.Rows[i]["Comuni_Ky"].ToString().ToLower();      
              //vendita case per comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/vendita-case-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliCategoria_Ky=2&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=6', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //affitto case per comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/affitto-case-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliCategoria_Ky=1&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=7', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //affitto appartamenti comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/affitto-appartamenti-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=3&ImmobiliCategoria_Ky=1&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=15', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //vendita appartamenti comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/vendita-appartamenti-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=3&ImmobiliCategoria_Ky=2&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=11', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //affitto ville comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/affitto-ville-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=87&ImmobiliCategoria_Ky=1&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=21', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //vendita ville comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/vendita-ville-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=87&ImmobiliCategoria_Ky=2&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=20', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //rustico comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/rustico-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=64&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=16', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //negozi comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/negozi-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=86&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=17', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //terreni comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/terreni-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=63&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=18', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //ufficio comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/ufficio-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=83&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=19', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //nuove costruzioni comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/nuove-costruzioni-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=30&incostruzione=1', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //stanze comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/stanze-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&ImmobiliTipologia_Ky=119&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=31', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //case vacanza comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/case-vacanza-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=29&turistico=1', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //case lusso comuni
              strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL+="('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/case-lusso-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-immobili.aspx?fromrewrite=1&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=32&prestigio=1', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              //agenzie-immobiliari comuni
              strSQL = "INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
              strSQL += "('immobili', '" + strComuni_Ky + "', '/immobili/" + strProvincie_UrlKey + "/agenzie-immobiliari-" + strComuni_UrlKey + ".html', '/frontend/" + strTheme + "/immobili/elenco-agenzie.aspx?fromrewrite=1&Province_Ky=" + strProvincie_Ky + "&Comuni_Ky=" + strComuni_Ky + "&page=1&chiave=9', 0, GETDATE())";
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
              }
            */

            /*
            //annunci
            strRisultato+="<li>Annunci</li>"; 
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='annunci';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('annunci', '', '/annunci/categorie.html','/frontend/" + strTheme + "/annunci/elenco-categorie-annunci.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('annunci', '', '/annunci/tipo.html','/frontend/" + strTheme + "/annunci/elenco-tipo-annunci.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL+="INSERT CoreUrlRewrite (CoreEntities_Code, CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
            strSQL+="('annunci', '', '/annunci/inserisci.html','/frontend/" + strTheme + "/annunci/inserimento-annuncio.aspx'," + Smartdesk.Session.CurrentUser.ToString() + ",GETDATE());";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strFROMNet = "AnnunciCategorie";
            strORDERNet = "AnnunciCategorie_Ky";
            strWHERENet="AnnunciCategorie_Padre=0";
            dtAnnunciCategoriePadri = new DataTable("AnnunciCategoriePadre");
            dtAnnunciCategoriePadri = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strFROMNet = "AnnunciCategorie";
            strORDERNet = "AnnunciCategorie_Ky";
            strWHERENet="AnnunciCategorie_Padre Is Null OR AnnunciCategorie_Padre<>0";
            dtAnnunciCategorie = new DataTable("AnnunciCategorie");
            dtAnnunciCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciCategorie_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='annuncicategorie_comuni';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='annuncicategorie_province';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strSQL="DELETE FROM CoreUrlRewrite WHERE CoreEntities_Code='annuncicategorie';";
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            for (int i = 0; i < dtProvince.Rows.Count; i++){
                strProvincie_UrlKey=dtProvince.Rows[i]["Province_ProvinciaHTML"].ToString().ToLower();
                strProvincie_Ky=dtProvince.Rows[i]["Province_Ky"].ToString().ToLower();                      
                strFROMNet = "Comuni";
                strORDERNet = "Comuni_Comune";
                strWHERENet="Province_Ky=" + strProvincie_Ky;
                dtComuni = new DataTable("Comuni");
                dtComuni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                for (int x = 0; x < dtComuni.Rows.Count; x++){
                    strComuni_Ky=dtComuni.Rows[x]["Comuni_Ky"].ToString().ToLower();
                    strComuni_UrlKey=dtComuni.Rows[x]["Comuni_ComuneHTML"].ToString().ToLower();
                    for (int j = 0; j < dtAnnunciCategorie.Rows.Count; j++){
                      if (j==0 && x==0 && i==0){
                        //categorie
                        strCoreUrlRewrite_UrlSource="/annunci/" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Url"].ToString() + ".html";
                        strCoreUrlRewrite_UrlDestination="/frontend/" + strTheme + "/annunci/visualizza-categoria.aspx?AnnunciCategorie_Ky_Corrente=" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString() + "&AnnunciCategorie_Ky=" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString();          
                        strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
                        strSQL+="('annuncicategorie', '" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString() + "', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', " + Smartdesk.Session.CurrentUser.ToString() + ", GETDATE())";
                        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      }
                      if (x==0){
                        //categorie per provincia
                        strCoreUrlRewrite_UrlSource="/annunci/" + strProvincie_UrlKey + "/" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Url"].ToString() + "-" + strProvincie_UrlKey + ".html";
                        strCoreUrlRewrite_UrlDestination="/frontend/" + strTheme + "/annunci/visualizza-categoria.aspx?AnnunciCategorie_Ky_Corrente=" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString() + "&AnnunciCategorie_Ky=" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString() + "&Province_Ky=" + dtProvince.Rows[i]["Province_Ky"].ToString();          
                        strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
                        strSQL+="('annuncicategorie_province', '" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString() + "-" + strProvincie_Ky + "', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', " + Smartdesk.Session.CurrentUser.ToString() + ", GETDATE())";
                        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                      }
                      //categorie per comune
                      strCoreUrlRewrite_UrlSource="/annunci/" + strProvincie_UrlKey + "/" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Url"].ToString() + "-" + strComuni_UrlKey + "-" + strProvincie_UrlKey + ".html";
                      strCoreUrlRewrite_UrlDestination="/frontend/" + strTheme + "/annunci/visualizza-categoria.aspx?AnnunciCategorie_Ky_Corrente=" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString() + "&AnnunciCategorie_Ky=" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString() + "&Province_Ky=" + dtProvince.Rows[i]["Province_Ky"].ToString() + "&Comuni_Ky=" + dtComuni.Rows[x]["Comuni_Ky"].ToString();          
                      strSQL="INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination,CoreUrlRewrite_UserInsert,CoreUrlRewrite_DateInsert) VALUES ";
                      strSQL+="('annuncicategorie_comuni', '" + dtAnnunciCategorie.Rows[j]["AnnunciCategorie_Ky"].ToString() + "-" + strProvincie_Ky + "-" + strComuni_Ky + "', '" + strCoreUrlRewrite_UrlSource + "', '" + strCoreUrlRewrite_UrlDestination + "', " + Smartdesk.Session.CurrentUser.ToString() + ", GETDATE())";
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                    }
                }
            } */

            
            strRisultato=strRisultato + "</ul>";        
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
