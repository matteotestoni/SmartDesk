using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
   	  string strCoreGrids_Ky=Smartdesk.Current.Request("CoreGrids_Ky");
   	  string strCoreGridsColumns_Ky=Smartdesk.Current.Request("CoreGridsColumns_Ky");

      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
        if (Smartdesk.Current.Request("CoreGridsColumns_Link") == "") frm.Add("CoreGridsColumns_Link", false);
				strCoreGridsColumns_Ky = Smartdesk.Functions.SqlWriteKey("CoreGridsColumns",frm);
				Response.Redirect("/admin/app/sdk/scheda-coregridscolumns.aspx?salvato=salvato&CoreModules_Ky=" + Request["CoreModules_Ky"] + "&CoreGridsColumns_Ky=" + strCoreGridsColumns_Ky + "&CoreGrids_Ky=" + strCoreGrids_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
