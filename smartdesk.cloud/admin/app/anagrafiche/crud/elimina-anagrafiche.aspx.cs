using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
				string strSQL="";

        if (Smartdesk.Login.Verify)
        {
            if (strDeletemultiplo=="deletemultiplo"){
								string[] strIdsArray = strIds.Split(',');
								foreach (var word in strIdsArray)
								{
		                strSQL="DELETE FROM Annunci WHERE Anagrafiche_Ky=" + word;
		            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
		                strSQL="DELETE FROM Lead WHERE Anagrafiche_Ky=" + word;
		            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
								}
                Smartdesk.Functions.SqlDeleteKeyIn("Anagrafiche",strIds);
            }else{
                strSQL="DELETE FROM Annunci WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL="DELETE FROM Lead WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
            		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
								Smartdesk.Functions.SqlDeleteKey("Anagrafiche");
            }
						switch (strSorgente)
            {
                case "elenco-lead":
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&AnagraficheTipo_Ky=3";
                    break;
                case "elenco-anagrafiche":
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198";
                    break;
                default:
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198";
                    break;
            }
	        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}

