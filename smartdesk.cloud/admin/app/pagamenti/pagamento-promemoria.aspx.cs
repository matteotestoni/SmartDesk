using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    public string strPagamenti_Ky="";
    public string strAnagrafiche_Ky="";
    public string strPagamenti_AttivaPromemoria="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
	  
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
                strPagamenti_Ky=Smartdesk.Current.Request("Pagamenti_Ky");
                strPagamenti_AttivaPromemoria=Request["Pagamenti_AttivaPromemoria"];
                strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
                strSorgente=Smartdesk.Current.Request("sorgente");
                strSQL = "UPDATE Pagamenti SET Pagamenti_AttivaPromemoria=" + strPagamenti_AttivaPromemoria + " WHERE Pagamenti_Ky=" + strPagamenti_Ky;
                //Response.Write(strSQL);
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

                switch (strSorgente){
                  case "home":
                    Response.Redirect("/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
                  case "elenco-pagamenti":
                    Response.Redirect("/admin/app/pagamenti/elenco-pagamenti.aspx");
                    break;
                  case "scheda-anagrafiche":
                    Response.Redirect("/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
                }
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
