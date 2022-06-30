using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";

      if (Smartdesk.Login.Verify){
				Dictionary<string, object> frm = new Dictionary<string, object>();
				if (Smartdesk.Current.Request("CoreEntities_Config") == "") frm.Add("CoreEntities_Config", false);
				if (Smartdesk.Current.Request("CoreEntities_Tree") == "") frm.Add("CoreEntities_Tree", false);
				if (Smartdesk.Current.Request("CoreEntities_InMenu") == "") frm.Add("CoreEntities_InMenu", false);
				if (Smartdesk.Current.Request("CoreEntities_CustomSave") == "") frm.Add("CoreEntities_CustomSave", false);
				if (Smartdesk.Current.Request("CoreEntities_CustomDelete") == "") frm.Add("CoreEntities_CustomDelete", false);
				strKy = Smartdesk.Functions.SqlWriteKey("CoreEntities",frm);
				Response.Redirect("/admin/app/sdk/scheda-coreentities.aspx?salvato=salvato&CoreEntities_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
