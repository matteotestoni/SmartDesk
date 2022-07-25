using System;
using System.Data;


  public partial class _Default : System.Web.UI.Page 
	{
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strComuni_Ky="";
    public string strProvince_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
                strProvince_Ky=Smartdesk.Current.Request("Province_Ky");
                strComuni_Ky=Smartdesk.Current.Request("Comuni_Ky");
                strSQL = "DELETE FROM Comuni WHERE Comuni_Ky=" + strComuni_Ky;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                Response.Redirect("/admin/app/core/scheda-pronvince.aspx?Province_Ky=" + strProvince_Ky);
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
