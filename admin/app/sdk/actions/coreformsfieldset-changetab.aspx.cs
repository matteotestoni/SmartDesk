using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strCoreFormsTabs_Ky = "";
    public string strCoreFormsFieldset_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
    if (Smartdesk.Login.Verify){
        strCoreFormsFieldset_Ky=Smartdesk.Current.Request("CoreFormsFieldset_Ky");
        strCoreFormsTabs_Ky=Smartdesk.Current.Request("CoreFormsTabs_Ky");
        strSQL= "UPDATE CoreFormsFieldset SET CoreFormsFieldset_DateUpdate=GETDATE(),  CoreFormsTabs_Ky=" + strCoreFormsTabs_Ky + " WHERE CoreFormsFieldset_Ky = " + strCoreFormsFieldset_Ky;
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Response.Write(strSQL);
      }else{
        Response.Write("ko");
      }
    }
}
