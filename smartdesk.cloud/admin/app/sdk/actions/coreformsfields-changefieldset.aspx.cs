using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strCoreFormsFieldset_Ky = "";
    public string strCoreFormsFields_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
    if (Smartdesk.Login.Verify){
        strCoreFormsFields_Ky=Smartdesk.Current.Request("CoreFormsFields_Ky");
        strCoreFormsFieldset_Ky=Smartdesk.Current.Request("CoreFormsFieldset_Ky");
        strSQL= "UPDATE CoreFormsFields set CoreFormsFieldset_Ky=" + strCoreFormsFieldset_Ky + " WHERE CoreFormsFields_Ky = " + strCoreFormsFields_Ky;
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Response.Write(strSQL);
      }else{
        Response.Write("ko");
      }
    }
}