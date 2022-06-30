using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        bool boolAjax = false;
        if (Smartdesk.Login.Verify){
            boolAjax = Convert.ToBoolean(Smartdesk.Current.Request("ajax"));
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheTag");
            if (boolAjax==true){
              Response.Write("ok");
            }else{
              strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=169&CoreGrids_Ky=158";
              Response.Redirect(strRedirect);
            }

        }
        Response.Redirect(strRedirect);
    }
}
