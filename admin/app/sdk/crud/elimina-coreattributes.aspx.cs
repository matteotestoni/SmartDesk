using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strCoreEntities_Ky = Smartdesk.Current.Request("CoreEntities_Ky");
        string strCoreModules_Ky = Smartdesk.Current.Request("CoreModules_Ky");
        string strCoreAttributes_Ky = Smartdesk.Current.Request("CoreAttributes_Ky");
				string strSQL="";

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
    						string[] strIdsArray = strIds.Split(',');
    						foreach (var word in strIdsArray)
    						{
                  strSQL="DELETE FROM CoreGridsColumns WHERE CoreAttributes_Ky=" + word;
              		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  strSQL="DELETE FROM CoreFormsFields WHERE CoreAttributes_Ky=" + word;
              		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    						}
                Smartdesk.Functions.SqlDeleteKeyIn("CoreAttributes",strIds);
            }else{
                strSQL="DELETE FROM CoreGridsColumns WHERE CoreAttributes_Ky=" + strCoreAttributes_Ky;
            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL="DELETE FROM CoreFormsFields WHERE CoreAttributes_Ky=" + strCoreAttributes_Ky;
            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                Smartdesk.Functions.SqlDeleteKey("CoreAttributes");
            }
			      switch (strSorgente)
            {
                case "scheda-coreentities":
                    strRedirect = "/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky;
                    break;
                default:
                    strRedirect = "/admin/app/sdk/elenco-coreattributes.aspx";
                    break;
            }
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
