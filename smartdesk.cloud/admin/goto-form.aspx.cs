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
    public DataTable dtCoreForms;
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

          strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
          strFROMNet = "UsergroupsForms_Vw";
          strORDERNet = "CoreForms_Ky";
          dtCoreForms = new DataTable ("CoreForms");
          dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          if (intCoreForms_Ky == 0){
              intCoreForms_Ky = Convert.ToInt32(dtCoreForms.Rows[0]["CoreForms_Ky"]);
          }

          if (dtCoreForms.Rows[0]["CoreForms_Custom"].Equals (true)){
              strFormUrl = "/admin/app/" + dtCoreForms.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreForms.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
          } else {
              strFormUrl = "/admin/form.aspx?CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString();
          }
          
			    foreach (String key in Request.QueryString.AllKeys){
            if (key!="CoreEntities_Ky"){
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
