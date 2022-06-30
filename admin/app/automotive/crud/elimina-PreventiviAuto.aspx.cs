using System;
public partial class _Default : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    string strRedirect = Smartdesk.Current.LoginPageRoot;
    string strSorgente = Smartdesk.Current.Request("sorgente");
    string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
    string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
    string strPreventiviAuto_Ky = Smartdesk.Current.Request("PreventiviAuto_Ky");
    string strSQL;
    if (Smartdesk.Login.Verify)
    {
      if (strDeletemultiplo == "deletemultiplo")
      {
        string[] strIdsArray = strIds.Split(',');
        foreach (var word in strIdsArray)
        {
          strSQL = "DELETE FROM PreventiviAutoProdotti WHERE PreventiviAuto_Ky=" + word;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
        strSQL = "DELETE FROM PreventiviAutoProdotti WHERE PreventiviAuto_Ky=" + strPreventiviAuto_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Smartdesk.Functions.SqlDeleteKeyIn("PreventiviAuto", strIds);
      }
      else
      {
        Smartdesk.Functions.SqlDeleteKey("PreventiviAuto");
      }
      strRedirect = "/admin/view.aspx?CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270";
      Response.Redirect(strRedirect);
    }
    else
    {
      Response.Redirect(Smartdesk.Current.LoginPageRoot);
    }
  }
}
