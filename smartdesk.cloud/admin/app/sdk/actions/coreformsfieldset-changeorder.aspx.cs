using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strCoreFormsFieldset_Order = "";
    public string strCoreFormsFieldset_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
    if (Smartdesk.Login.Verify){
        strCoreFormsFieldset_Ky=Smartdesk.Current.Request("CoreFormsFieldset_Ky");
        strCoreFormsFieldset_Order=Smartdesk.Current.Request("CoreFormsFieldset_Order");
        strSQL= "UPDATE CoreFormsFieldset SET CoreFormsFieldset_DateUpdate=GETDATE(), CoreFormsFieldset_Order=" + strCoreFormsFieldset_Order + " WHERE CoreFormsFieldset_Ky = " + strCoreFormsFieldset_Ky;
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Response.Write(strSQL);
        Response.Write(intKy.ToString());
      }else{
        Response.Write("ko");
      }
    }
}
