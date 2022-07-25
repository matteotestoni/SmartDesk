using System;
using System.Data;

public partial class _Default : System.Web.UI.Page {

    public string strLogin="";
    public string strDocumenti_Ky="";


    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
      string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

      if (Smartdesk.Login.Verify){
            strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
            strSQL = "DELETE FROM DocumentiCorpo WHERE Documenti_Ky=" + strDocumenti_Ky;
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL = "DELETE FROM Pagamenti WHERE Documenti_Ky=" + strDocumenti_Ky;
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL = "DELETE FROM Documenti WHERE Documenti_Ky=" + strDocumenti_Ky;
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            Response.Redirect("/admin/app/documenti/elenco-documenti.aspx");
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
