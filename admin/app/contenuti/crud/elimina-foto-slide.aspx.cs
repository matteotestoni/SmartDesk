using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strCMSSlide_Ky = Smartdesk.Current.Request("CMSSlide_Ky");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        
        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("Files",strIds);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Files");
            }
            strRedirect="/admin/app/contenuti/scheda-slide.aspx?CMSSlide_Ky=" + strCMSSlide_Ky;
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}