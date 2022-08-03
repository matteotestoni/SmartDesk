using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtLogin;
    public string strErrore="";
    public DataTable dtCoreModulesOptionsValue;
    public DataTable dtCMSSlide;
    public DataTable dtHome;
    public DataTable dtAsteEsperimenti;
    public DataTable dtLottiAsta;
    public DataTable dtAnnunci;
    public DataTable dtAnnunciCategorie;
    public DataTable dtAttributi;
    public DataTable dtProdotti;
    public string strTheme="base";
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
  	  
      strErrore=Smartdesk.Current.Request("errore");

      strWHERENet = "CMSContenutiTipo_Ky=8 AND CMSContenuti_PubblicaWeb=1 AND Lingue_Ky=1";
      dtHome = new DataTable("Home");
      dtHome = Smartdesk.Sql.getTablePage("CMSContenuti_Vw", null, "CMSContenuti_Ky", strWHERENet, "CMSContenuti_Ky DESC", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

  	  strWHERENet = "AnnunciCategorie_Padre=0";
      dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
      strWHERENet = "Prodotti_PubblicaWEB=1";
      dtProdotti = new DataTable("Prodotti");
      dtProdotti = Smartdesk.Sql.getTablePage("Prodotti_Vw", null, "Prodotti_Ky", strWHERENet, "Prodotti_Ky DESC", 1, 8,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      strWHERENet = "AnnunciStato_Ky=1 AND AnnunciTipo_Ky=1";
      dtAnnunci = new DataTable("Annunci");
      dtAnnunci = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky DESC", 1, 8,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      strWHERENet="(AsteEsperimentiEsiti_Ky=3)";
      dtAsteEsperimenti = new DataTable("AsteEsperimenti");
      dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti_Web_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_DataTermine ASC", 1, 10,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      strWHERENet = "CMSSlide_PubblicaWEB=1";
      dtCMSSlide = new DataTable("CMSSlide");
      dtCMSSlide = Smartdesk.Sql.getTablePage("CMSSlide", null, "CMSSlide_Ky", strWHERENet, "CMSSlide_Ky", 1, 10,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      strWHERENet = "Attributi_Annunci=1";
      strORDERNet = "Attributi_Ordine";
      strFROMNet = "Attributi_Vw";
      dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

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

    }
    public string getAttributi(int indiceRecord)
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";

        strOutput="";   
        strAttributi=dtAnnunci.Rows[indiceRecord]["AnnunciCategorie_AttributiElenchi"].ToString();
        if (strAttributi.Length>0){
          
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           if (dtAnnunci.Rows[indiceRecord][strCodice].ToString().Length>0 && dtAnnunci.Rows[indiceRecord][strCodice].ToString()!="0"){
              switch (strTipo){
                case "1":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "2":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "3":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "4":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-check-square-o fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
                    break;  
                case "5":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "6":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;                  
              }
           }

          }
        }

        return strOutput;
    }
}
