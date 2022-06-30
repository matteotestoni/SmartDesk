using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strAzione = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
	  
      if (Smartdesk.Login.Verify){
          Dictionary<string, object> frm = new Dictionary<string, object>();
          if (Smartdesk.Current.Request("AttivitaSettore_Attiva") == "") frm.Add("AttivitaSettore_Attiva", false);
	  	  strKy = Smartdesk.Functions.SqlWriteKey("AttivitaSettore", frm);
          Response.Redirect("/admin/view.aspx?CoreModules_Ky=6&CoreEntities_Ky=80&CoreGrids_Ky=63");
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
