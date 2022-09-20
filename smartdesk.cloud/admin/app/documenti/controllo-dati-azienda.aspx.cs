using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtTemp;
    public DataTable dtTemp2;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strRisultato = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      int i=0;

      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          if (dtLogin.Rows.Count>0){
            strRisultato="<ul>";
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strWHERENet="";
            strORDERNet = "Documenti_Ky";
            strFROMNet = "Documenti";
            dtTemp = new DataTable("Documenti");
            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            for (i = 0; i < dtTemp.Rows.Count; i++){
							strWHERENet="Pagamenti_Pagato=0 And Documenti_Ky=" + dtTemp.Rows[i]["Documenti_Ky"].ToString();
              strORDERNet = "Pagamenti_Ky";
              strFROMNet = "Pagamenti";
              dtTemp2 = new DataTable("Pagamenti");
              dtTemp2 = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							if (dtTemp2.Rows.Count>0){
            		strSQL = "UPDATE Documenti SET DocumentiStato_Ky=2 WHERE Documenti_Ky=" + dtTemp.Rows[i]["Documenti_Ky"].ToString();
							}else{
            		strSQL = "UPDATE Documenti SET DocumentiStato_Ky=6 WHERE Documenti_Ky=" + dtTemp.Rows[i]["Documenti_Ky"].ToString();
							}
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            strRisultato="dati aggiornati";        
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
}
