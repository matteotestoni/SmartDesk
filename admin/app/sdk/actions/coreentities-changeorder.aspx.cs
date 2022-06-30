using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strCoreEntities_Order = "";
    public string strCoreEntities_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
    if (Smartdesk.Login.Verify){
        strCoreEntities_Ky=Smartdesk.Current.Request("CoreEntities_Ky");
        strCoreEntities_Order=Smartdesk.Current.Request("CoreEntities_Order");
        strSQL= "UPDATE CoreEntities set CoreEntities_Order=" + strCoreEntities_Order + " WHERE CoreEntities_Ky = " + strCoreEntities_Ky;
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Response.Write(intKy.ToString());
      }else{
        Response.Write("ko");
      }
    }
}
