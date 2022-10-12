using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public string strCommesse_Ky="";
    public string strAttivita_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strAzione = Smartdesk.Current.Request("azione");

	  
      if (Smartdesk.Login.Verify){
          strAttivita_Ky=Smartdesk.Current.Request("Attivita_Ky");
          strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
          switch(strAzione){
              case "fatturato":
                  strSQL="UPDATE Attivita SET Attivita_Fatturato=1 WHERE Attivita_Ky = " + strAttivita_Ky;
                  new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  break;
              case "nonfatturato":
                  strSQL="UPDATE Attivita SET Attivita_Fatturato=0 WHERE Attivita_Ky = " + strAttivita_Ky;
                  new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  break;
          }
          Response.Redirect("/admin/app/progetti/scheda-progetti.aspx?Commesse_Ky=" + strCommesse_Ky + "#trattivita" + strAttivita_Ky);
        }else{
          Response.Write("ko");
        }
    }
}
