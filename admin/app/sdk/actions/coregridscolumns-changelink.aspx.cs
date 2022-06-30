using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strCoreGridsColumns_Link = "";
    public string strCoreGridsColumns_Ky="";
    public string strCoreGrids_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
    if (Smartdesk.Login.Verify){
        strCoreGridsColumns_Ky=Smartdesk.Current.Request("CoreGridsColumns_Ky");
        strCoreGridsColumns_Link=Smartdesk.Current.Request("CoreGridsColumns_Link");
        strCoreGrids_Ky=Smartdesk.Current.Request("CoreGrids_Ky");
        strSQL= "UPDATE CoreGridsColumns set CoreGridsColumns_Link=" + strCoreGridsColumns_Link + " WHERE CoreGridsColumns_Ky = " + strCoreGridsColumns_Ky;
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Response.Write(intKy.ToString());
        Response.Redirect("/admin/app/sdk/scheda-coregrids.aspx?salvato=salvato&CoreGrids_Ky=" + strCoreGrids_Ky);
      }else{
        Response.Write("ko");
      }
    }
}
