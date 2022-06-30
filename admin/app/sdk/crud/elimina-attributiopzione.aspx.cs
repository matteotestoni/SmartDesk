using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
   	  	string strAttributi_Ky="";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            strAttributi_Ky=Smartdesk.Current.Request("Attributi_Ky");
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("AttributiOpzioni",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("AttributiOpzioni");
            }
        	strRedirect="/admin/app/sdk/scheda-attributi.aspx?Attributi_Ky=" + strAttributi_Ky;
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}