using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strFieldValue = "";
    public string strFieldName = "";
    public string strFieldType = "";
    public string strAttivita_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
      if (Smartdesk.Login.Verify){
        strFieldValue=Smartdesk.Current.Request("fieldvalue");
        strFieldName=Smartdesk.Current.Request("fieldname");
        strFieldType=Smartdesk.Current.Request("fieldtype");
        strAttivita_Ky=Smartdesk.Current.Request("Attivita_Ky");
        if (strFieldType=="string"){
            strSQL= "UPDATE Attivita SET " + strFieldName + "='" + strFieldValue + "' WHERE Attivita_Ky = " + strAttivita_Ky;
        }else{
            strSQL= "UPDATE Attivita SET " + strFieldName + "=" + strFieldValue + " WHERE Attivita_Ky = " + strAttivita_Ky;
        }
        Response.Write(strSQL + "\n");
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        Response.Write(intKy.ToString() + "\n");
      }else{
        Response.Write("ko");
      }
    }
}
