using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public bool fCaricato = false;
    public string strAzione = "";
    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtNegozi;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strSQL = "";
      
      
	  
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
		strAzione = Request["azione"];
		Dictionary<string, object> frm = new Dictionary<string, object>();
		if (Smartdesk.Current.Request("Negozi_Default") == "") frm.Add("Negozi_Default", false);
        strKy = Smartdesk.Functions.SqlWriteKey("Negozi", frm);
		if (Smartdesk.Current.Request("Negozi_Default")=="True" || Smartdesk.Current.Request("Negozi_Default").Equals(true)){
	        strSQL = "UPDATE Negozi SET Negozi_Default=0 WHERE Negozi_Ky<>" + strKy;
	        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
		}
	    Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=141&CoreGrids_Ky=21&custom=0&azione=edit&Negozi_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
