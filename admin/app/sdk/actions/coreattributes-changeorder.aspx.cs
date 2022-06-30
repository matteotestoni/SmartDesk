using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strCoreAttributes_Order = "";
    public string strCoreAttributes_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
    if (Smartdesk.Login.Verify){
        strCoreAttributes_Ky=Smartdesk.Current.Request("CoreAttributes_Ky");
        strCoreAttributes_Order=Smartdesk.Current.Request("CoreAttributes_Order");
        strSQL= "UPDATE CoreAttributes set CoreAttributes_Order=" + strCoreAttributes_Order + " WHERE CoreAttributes_Ky = " + strCoreAttributes_Ky;
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Response.Write(intKy.ToString());
      }else{
        Response.Write("ko");
      }
    }
}
