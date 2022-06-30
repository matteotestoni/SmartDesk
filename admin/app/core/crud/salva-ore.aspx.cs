using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
	  
      if (Smartdesk.Login.Verify){
          Dictionary<string, object> frm = new Dictionary<string, object>();
          if (Smartdesk.Current.Request("Ore_Disabilita") == "") frm.Add("Ore_Disabilita", false);
	  	  strKy = Smartdesk.Functions.SqlWriteKey("Ore");
          Response.Redirect("/admin/app/core/scheda-ore.aspx?salvato=salvato&Ore_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
