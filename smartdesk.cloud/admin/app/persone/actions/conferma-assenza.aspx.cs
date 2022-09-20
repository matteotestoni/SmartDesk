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
    
    public string strPersone_Ky="";
    public string strPersoneAssenze_Ky="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          if (dtLogin.Rows.Count>0){
                strPersoneAssenze_Ky=Request["PersoneAssenze_Ky"];
                strPersone_Ky=Smartdesk.Current.Request("Persone_Ky");
          		  strSorgente=Smartdesk.Current.Request("sorgente");
                strSQL = "UPDATE PersoneAssenze SET PersoneAssenze_Lock=1 WHERE PersoneAssenze_Ky=" + strPersoneAssenze_Ky;
                //Response.Write(strSQL);
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                switch (strSorgente){
                    case "elenco-personeassenze":
                        Response.Redirect("/admin/app/persone/elenco-personeassenze.aspx?Persone_Ky=" + strPersone_Ky);
                        break;
                    default:
                        Response.Redirect("/admin/app/persone/elenco-personeassenze.aspx?tutti=tutti");
                        break;
                }
                Response.Redirect("/admin/app/persone/elenco-personeassenze.aspx?tutti=tutti");
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
