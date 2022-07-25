using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";

      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
        if (Smartdesk.Current.Request("CoreGrids_Default") == "") frm.Add("CoreGrids_Default", false);
        if (Smartdesk.Current.Request("CoreGrids_Custom") == "") frm.Add("CoreGrids_Custom", false);
				strKy = Smartdesk.Functions.SqlWriteKey("CoreGrids",frm);
				Response.Redirect("/admin/app/sdk/scheda-coregrids.aspx?salvato=salvato&CoreModules_Ky=" + Request["CoreModules_Ky"] + "&CoreGrids_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
