using System;
using System.Data;

public partial class RandomPassword : System.Web.UI.Page
{
    
    public int intNumRecords = 0;
    
    public string strH1 = "Esporta anagrafiche";
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      
      strH1="Esportazione anagrafiche";
      if (Smartdesk.Login.Verify){
	      dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}    
}
