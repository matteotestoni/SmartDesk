using System;
using System.Data;


  public partial class _Default : System.Web.UI.Page 
	{

    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public string strVeicoliMarca_Ky="";
    public string strVeicoliModello_Ky="";
 

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            if (dtLogin.Rows.Count>0){
                strVeicoliModello_Ky=Smartdesk.Current.Request("VeicoliModello_Ky");
                strVeicoliMarca_Ky=Smartdesk.Current.Request("VeicoliMarca_Ky");
                strSQL = "DELETE FROM VeicoliModello WHERE VeicoliModello_Ky=" + strVeicoliModello_Ky;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                Response.Redirect("/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=122&CoreGrids_Ky=143");
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
