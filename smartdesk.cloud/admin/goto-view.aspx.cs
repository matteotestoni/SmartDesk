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
    public string strFROMNet = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strAzione = "modifica";
    public string strSorgente = "";
    public DataTable dtCoreGrids;
    public DataTable dtCoreEntities;
    public string strUtentiGruppi_Ky = "";
    public int intCoreEntities_Ky = 1;
    public int intCoreGrids_Ky = 1;
    public int intCoreForms_Ky = 1;
    public int intCoreModules_Ky = 28;
    public string strFormUrl = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          strUtentiGruppi_Ky=dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          intCoreEntities_Ky = Convert.ToInt32(Request["CoreEntities_Ky"]);
          intCoreForms_Ky = Convert.ToInt32(Request["CoreForms_Ky"]);
          intCoreModules_Ky = Convert.ToInt32(Request["CoreModules_Ky"]);
          intCoreGrids_Ky = Convert.ToInt32(Request["CoreGrids_Ky"]);
          strAzione = Request["azione"];
          strSorgente = Request["sorgente"];

          strWHERENet = "(CoreEntities_Ky=" + intCoreEntities_Ky + ")";
          strFROMNet = "CoreEntities_Vw";
          strORDERNet = "CoreEntities_Ky";
          dtCoreEntities = new DataTable ("CoreEntities");
          dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);


          if (intCoreGrids_Ky == 0){
              strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
              strFROMNet = "UsergroupsGrids_Vw";
              strORDERNet = "CoreGrids_Ky";
              dtCoreGrids = new DataTable ("CoreGrids");
              dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtCoreGrids.Rows.Count>0){
                intCoreGrids_Ky = Convert.ToInt32(dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString());
              }else{
                intCoreGrids_Ky = 0;
              }
          }else{
              strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreGrids_Ky=" + intCoreGrids_Ky + ")";
              strFROMNet = "UsergroupsGrids_Vw";
              strORDERNet = "CoreGrids_Ky";
              dtCoreGrids = new DataTable ("CoreGrids");
              dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);              
          }

          if (dtCoreGrids.Rows[0]["CoreGrids_Custom"].Equals (true)){
              strFormUrl = "/admin/app/" + dtCoreGrids.Rows[0]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreGrids.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
          } else {
              strFormUrl = "/admin/view.aspx?CoreModules_Ky=" + dtCoreGrids.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreGrids.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString();
          }
          
			    foreach (String key in Request.QueryString.AllKeys){
            if (key!="CoreEntities_Ky" && key!="CoreGrids_Ky"){
              strFormUrl+="&" + key + "=" + Request.QueryString[key].ToString();
            }
            //Response.Write(key);
            //Response.Write(" - ");
            //Response.Write(Request.QueryString[key].ToString());
          }
          
          
          
          Response.Write(strFormUrl);
          Response.Redirect(strFormUrl);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
}
