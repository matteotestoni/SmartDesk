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
}
