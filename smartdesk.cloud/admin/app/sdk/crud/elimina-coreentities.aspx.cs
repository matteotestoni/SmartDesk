using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");
        string strCoreEntities_Ky = Smartdesk.Current.Request("CoreEntities_Ky");
				string strSQL="";

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
								string[] strIdsArray = strIds.Split(',');
								foreach (var word in strIdsArray)
								{
              		strSQL="DELETE FROM CoreAttributes WHERE CoreEntities_Ky=" + word;
	            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
	                strSQL="DELETE FROM CoreForms WHERE CoreEntities_Ky=" + word;
	            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
	                strSQL="DELETE FROM CoreGrids WHERE CoreEntities_Ky=" + word;
	            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
								}
                Smartdesk.Functions.SqlDeleteKeyIn("CoreEntities",strIds);
            }else{
                strSQL="DELETE FROM CoreAttributes WHERE CoreEntities_Ky=" + strCoreEntities_Ky;
            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL="DELETE FROM CoreForms WHERE CoreEntities_Ky=" + strCoreEntities_Ky;
            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL="DELETE FROM CoreGrids WHERE CoreEntities_Ky=" + strCoreEntities_Ky;
            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

                Smartdesk.Functions.SqlDeleteKey("CoreEntities");
            }
            strRedirect="/admin/app/sdk/scheda-coremodules.aspx?CoreModules_Ky=" + strCoreModules_Ky;
        		Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}