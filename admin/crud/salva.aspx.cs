using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
  public int intNumRecords = 0;

  protected void Page_Load(object sender, EventArgs e)
  {
      string strKy = "";
	    string strSQL = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      bool boolAjax = false;
      string strJson = "";
      string strFormUrl = "";
      DataTable dtCoreForms;
      DataTable dtCoreEntities;
      DataTable dtCoreAttributes;
      DataTable dtCoreModules;
      DataTable dtRecord;
      int intCoreForms_Ky = 0;
      int intCoreGrids_Ky = 0;
      int intCoreEntities_Ky = 0;
      int intCoreModules_Ky = 0;

      if (Request["ajax"]!=null && Request["ajax"].ToString().Length>0){
        boolAjax = Convert.ToBoolean(Request["ajax"]);
      }
      if (Smartdesk.Login.Verify){
        intCoreForms_Ky=Convert.ToInt32(Smartdesk.Current.Request("CoreForms_Ky"));
        if (Smartdesk.Current.Request("CoreGrids_Ky").ToString().Length>0){
          intCoreGrids_Ky=Convert.ToInt32(Smartdesk.Current.Request("CoreGrids_Ky"));;
        }
        dtCoreForms = Smartdesk.Data.Read("CoreForms_Vw", "CoreForms_Ky", Smartdesk.Current.Request("CoreForms_Ky"));
        intCoreEntities_Ky=Convert.ToInt32(dtCoreForms.Rows[0]["CoreEntities_Ky"]);
        intCoreModules_Ky=Convert.ToInt32(dtCoreForms.Rows[0]["CoreModules_Ky"]);
        dtCoreEntities = Smartdesk.Data.Read("CoreEntities_Vw", "CoreEntities_Ky", dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString());
    	  dtCoreAttributes = Smartdesk.Sql.getTablePage("CoreAttributes_Vw", null, "CoreAttributes_Ky", "CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString(), "CoreAttributes_Ky", 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        dtCoreModules = Smartdesk.Data.Read("CoreModules", "CoreModules_Ky", dtCoreForms.Rows[0]["CoreModules_Ky"].ToString());
        Dictionary<string, object> frm = new Dictionary<string, object>();
		    for (int i = 0; i < dtCoreAttributes.Rows.Count; i++){
          //Response.Write("Tipo:" + dtCoreAttributes.Rows[i]["CoreAttributesType_Ky"].ToString() + "<br>");
          if (dtCoreAttributes.Rows[i]["CoreAttributesType_Ky"].ToString()=="4"){
            if (Smartdesk.Current.Request(dtCoreAttributes.Rows[i]["CoreAttributes_Code"].ToString()) == "") frm.Add(dtCoreAttributes.Rows[i]["CoreAttributes_Code"].ToString(), false);
            //Response.Write("Attributo bit:" + dtCoreAttributes.Rows[i]["CoreAttributes_Code"].ToString() + "<br>");
          }
        }
        //Response.Write("Entità:" + dtCoreForms.Rows[0]["CoreEntities_Code"].ToString());
        strKy = Smartdesk.Functions.SqlWriteKey(dtCoreForms.Rows[0]["CoreEntities_Code"].ToString(),frm);
        if (boolAjax==true){
          dtRecord = Smartdesk.Data.Read(dtCoreForms.Rows[0]["CoreEntities_Code"].ToString(), dtCoreForms.Rows[0]["CoreEntities_Key"].ToString(), strKy);
          strJson="{\"" + dtCoreForms.Rows[0]["CoreEntities_Key"].ToString() + "\": " + strKy + "\"}";
          Response.Write(strJson);
        }else{
      		if (dtCoreForms.Rows.Count>0){
              if (dtCoreForms.Rows[0]["CoreForms_Custom"].Equals(true)){
                strFormUrl="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky + "&CoreForms_Ky=" + intCoreForms_Ky;
              }else{
                strFormUrl="/admin/form.aspx?CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky + "&CoreForms_Ky=" + intCoreForms_Ky + "&custom=0";
              }
          }else{
            strFormUrl="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky;
          }
          strRedirect = strFormUrl + "&" + dtCoreForms.Rows[0]["CoreEntities_Key"].ToString() + "=" + strKy;
          Response.Redirect(strRedirect);
        }
      }else{
        if (boolAjax==true){
          strJson="{\"error\": \"not authorized\"}";
          Response.Write(strJson);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
	    }
  }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
