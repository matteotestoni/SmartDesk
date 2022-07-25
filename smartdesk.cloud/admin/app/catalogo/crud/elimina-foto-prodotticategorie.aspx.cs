using System;
using System.Data;

public partial class _Default : System.Web.UI.Page {
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    public string strProdottiCategorie_Ky="";
    public string strFoto="";
  
    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          strProdottiCategorie_Ky= Smartdesk.Current.Request("ProdottiCategorie_Ky");
          strSQL = "UPDATE ProdottiCategorie SET ProdottiCategorie_Logo=null WHERE ProdottiCategorie_Ky=" + strProdottiCategorie_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          Response.Redirect("/admin/app/catalogo/scheda-prodotticategorie.aspx?ProdottiCategorie_Ky=" + strProdottiCategorie_Ky);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

}
