using System;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strSQL="";

        if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
                Smartdesk.Functions.SqlDeleteKeyIn("Aste",strIds);
                strSQL = "DELETE FROM AsteEsperimenti WHERE Aste_Ky IN (" + strIds + ")";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL = "DELETE FROM AsteCauzioni WHERE Aste_Ky IN (" + strIds + ")";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL = "DELETE FROM AnnunciOfferte WHERE Aste_Ky IN (" + strIds + ")";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL = "DELETE FROM Annunci WHERE Aste_Ky IN (" + strIds + ")";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL = "DELETE FROM Files WHERE Chiave_Tabella='Aste' AND Chiave_Ky IN (" + strIds + ")";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }else{
                Smartdesk.Functions.SqlDeleteKey("Aste");
                strSQL = "DELETE FROM AsteEsperimenti WHERE Aste_Ky=" + Smartdesk.Current.Request("Aste_Ky");
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL = "DELETE FROM AsteCauzioni WHERE Aste_Ky=" + Smartdesk.Current.Request("Aste_Ky");
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL = "DELETE FROM AnnunciOfferte WHERE Aste_Ky=" + Smartdesk.Current.Request("Aste_Ky");
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL = "DELETE FROM Annunci WHERE Aste_Ky=" + Smartdesk.Current.Request("Aste_Ky");
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strSQL = "DELETE FROM Files WHERE Chiave_Tabella='Aste' AND Chiave_Ky=" + Smartdesk.Current.Request("Aste_Ky");
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            strRedirect="/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=60&CoreGrids_Ky=50";
        	Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}