using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    string strSorgente = Smartdesk.Current.Request("sorgente");
        string strKy ="";

        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy=Smartdesk.Functions.SqlWriteKey("Divise");
		    strRedirect="/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=16&CoreGrids_Ky=15";
            Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}