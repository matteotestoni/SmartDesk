using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strCoreGridsColumns_Ky = Smartdesk.Current.Request("CoreGridsColumns_Ky");
        string strCoreGrids_Ky = Smartdesk.Current.Request("CoreGrids_Ky");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");
        string strSQL="";

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("CoreGridsColumns",strIds);
                strSQL = "DELETE FROM CoreGridsColumns WHERE CoreGridsColumns_Ky IN (" + strIds + ")";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }else{
                Smartdesk.Functions.SqlDeleteKey("CoreGridsColumns");
                strSQL = "DELETE FROM CoreGridsColumns WHERE CoreGridsColumns_Ky=" + Smartdesk.Current.Request("CoreGridsColumns_Ky");
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            }
            strRedirect="/admin/app/sdk/scheda-coregrids.aspx?CoreGrids_Ky=" + strCoreGrids_Ky + "&CoreModules_Ky=" + strCoreModules_Ky;
        		Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}