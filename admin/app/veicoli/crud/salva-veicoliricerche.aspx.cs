using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
	    
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
	  
	      if (Smartdesk.Login.Verify){
				  Dictionary<string, object> frm = new Dictionary<string, object>();
				  if (Smartdesk.Current.Request("VeicoliRicerche_Attivo") == "") frm.Add("VeicoliRicerche_Attivo", false);
				  strKy = Smartdesk.Functions.SqlWriteKey("VeicoliRicerche", frm);
		      strRedirect="/admin/app/veicoli/scheda-veicoliricerche.aspx?salvato=salvato&VeicoliRicerche_Ky=" + strKy;
					Response.Redirect(strRedirect);
	      }else{
	        Response.Redirect(Smartdesk.Current.LoginPageRoot);
	      }
    }
    
}
