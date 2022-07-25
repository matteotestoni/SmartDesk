using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strH1 = "Impostazioni generali";
    public int intRecxPag = 150;
    public int intNumPagine=1;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public DataTable dtCoreModulesOptionsValue;
    public string strChecked = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strPage="";
      int intPage = 0;
      
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strPage = Request["page"];
          if ((strPage == null) || (strPage == "")){
            intPage = 1;
          }
          else{
            intPage = Convert.ToInt32(strPage);
          }
          strWHERENet="";
          strFROMNet = "CoreModulesOptionsValue_Vw";
          strORDERNet = "CoreModules_Order, CoreModulesOptions_Order, CoreModulesOptions_Code ASC";
          dtCoreModulesOptionsValue = new DataTable("CoreModulesOptionsValue");
          dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  		    this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtCoreModulesOptionsValue,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }   
	 
    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="";
        strValue = Request["CoreModulesOptions_Title"];
        if (strValue != null && strValue != ""){
            strWHERE = "(CoreModulesOptions_Title like '%" + strValue + "%')";
        }
        return strWHERE;
    }


	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
