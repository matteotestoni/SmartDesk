using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
    	string strPersone_Ky="";
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify){
            strPersone_Ky=Smartdesk.Current.Request("Persone_Ky");
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("PersoneAssenze",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("PersoneAssenze");
            }
            strRedirect="/admin/app/persone/elenco-personeassenze.aspx?Persone_Ky=" + strPersone_Ky;
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
