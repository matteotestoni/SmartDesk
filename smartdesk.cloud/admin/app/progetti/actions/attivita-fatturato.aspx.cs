using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.Request("redirect");
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strAzionidigruppo = Smartdesk.Current.Request("azionidigruppo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        string strSQL = "";

        if (Smartdesk.Login.Verify){
            switch(strAzionidigruppo){
                case "fatturato":
                    strSQL="UPDATE Attivita SET Attivita_Fatturato=1 WHERE Attivita_Ky IN (" + strIds + ")";
                    Response.Write(strSQL);
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                    break;
                case "nonfatturato":
                    strSQL="UPDATE Attivita SET Attivita_Fatturato=0 WHERE Attivita_Ky IN (" + strIds + ")";
                    Response.Write(strSQL);
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                    break;
            }
            Response.Write(strSorgente);
            Response.Redirect(strSorgente);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
