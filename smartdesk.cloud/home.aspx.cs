using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtLogin;
    public string strErrore="";
    public DataTable dtAnnunciCategorie;
    public DataTable dtCoreModulesOptionsValue;
    public DataTable dtCMSSlide;
    public string strTheme="base";
    
    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
  	  
      strErrore=Smartdesk.Current.Request("errore");
  	  strWHERENet = "AnnunciCategorie_Padre=0";
      dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      strWHERENet = "CMSSlide_PubblicaWEB=1";
      dtCMSSlide = new DataTable("CMSSlide");
      dtCMSSlide = Smartdesk.Sql.getTablePage("CMSSlide", null, "CMSSlide_Ky", strWHERENet, "CMSSlide_Ky", 1, 10,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

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
}
