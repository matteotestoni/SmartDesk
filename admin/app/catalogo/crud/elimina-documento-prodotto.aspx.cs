using System;
using System.Data;

public partial class _Default : System.Web.UI.Page {
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strProdotti_Ky="";
    public string strDocumento="";
  
    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          strProdotti_Ky= Smartdesk.Current.Request("Prodotti_Ky");
          strDocumento= Smartdesk.Current.Request("documento");
          strSQL = "UPDATE Prodotti SET Prodotti_Documento" + strDocumento + "=null WHERE Prodotti_Ky=" + strProdotti_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          Response.Redirect("/admin/app/catalogo/scheda-prodotto.aspx?Prodotti_Ky=" + strProdotti_Ky);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
