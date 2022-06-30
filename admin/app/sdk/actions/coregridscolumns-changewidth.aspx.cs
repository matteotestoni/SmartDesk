using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strCoreGridsColumns_Width = "";
    public string strCoreGridsColumns_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
    if (Smartdesk.Login.Verify){
        strCoreGridsColumns_Ky=Smartdesk.Current.Request("CoreGridsColumns_Ky");
        strCoreGridsColumns_Width=Smartdesk.Current.Request("CoreGridsColumns_Width");
        strSQL= "UPDATE CoreGridsColumns set CoreGridsColumns_Width=" + strCoreGridsColumns_Width + " WHERE CoreGridsColumns_Ky = " + strCoreGridsColumns_Ky;
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Response.Write(intKy.ToString());
      }else{
        Response.Write("ko");
      }
    }
}
