using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";

      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
				strKy = Smartdesk.Functions.SqlWriteKey("CoreGridsButtons",frm);
                Response.Redirect("/admin/app/sdk/scheda-coregrids.aspx?CoreGrids_Ky=" + Request["CoreGrids_Ky"] + "&CoreModules_Ky=16&sorgente=scheda-entities");
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
