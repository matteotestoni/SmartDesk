using System;
using System.Data;


  public partial class _Default : System.Web.UI.Page 
	{

    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public string strVeicoliTipo_Ky="";


    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            if (dtLogin.Rows.Count>0){
                strVeicoliTipo_Ky=Smartdesk.Current.Request("VeicoliTipo_Ky");
                strSQL = "DELETE FROM VeicoliTipo WHERE VeicoliTipo_Ky=" + strVeicoliTipo_Ky;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                Response.Redirect("/admin/app/veicoli/elenco-VeicoliTipo.aspx?VeicoliTipo_Ky=" + strVeicoliTipo_Ky);
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
