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
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtCoreModules;
    public DataTable dtCoreFormsFieldset;
    public string strRisultato = "";
    
    public string strH1 = "Opzioni moduli";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strFROMNet = "";
      string strWHERENet="";
      string strORDERNet = "";
      string strSQL="";

      

      if (Smartdesk.Login.Verify){
          	dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strWHERENet="";
            strORDERNet = "CoreModules_Ky";
            strFROMNet = "CoreModules";
            dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtCoreModules.Rows.Count>0){
              strRisultato="<ul>";        
              for (int i = 0; i < dtCoreModules.Rows.Count; i++){
                try {
                //strSQL="ALTER TABLE UtentiGruppi add UtentiGruppi_" + FirstLetterToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + " bit default(0)";
                //new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                //strRisultato=strRisultato + "<li>" + strSQL + "</li>";        
                
                strSQL="UPDATE UtentiGruppi SET UtentiGruppi_" + FirstLetterToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + "=0 WHERE UtentiGruppi_" + FirstLetterToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + " Is Null";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strRisultato=strRisultato + "<li>" + strSQL + "</li>";        
                //strSQL="ALTER TABLE UtentiGruppi add UtentiGruppi_" + FirstLetterToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + "Quali tinyint";
                //new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                //strRisultato=strRisultato + "<li>" + strSQL + "</li>";        
                strSQL="UPDATE UtentiGruppi SET UtentiGruppi_" + FirstLetterToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + "Quali=1 WHERE UtentiGruppi_" + FirstLetterToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + "Quali Is Null";
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strRisultato=strRisultato + "<li>" + strSQL + "</li>";        
                Response.Write(strSQL);
                }catch (Exception ex){
                }
              }
              

              /*
              for (int i = 0; i < dtCoreModules.Rows.Count; i++){

                strWHERENet="CoreFormsFieldset_Title='" + FirstLetterToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + "' AND CoreForms_Ky=156";
                //Response.Write(strWHERENet);
                strORDERNet = "CoreFormsFieldset_Ky";
                strFROMNet = "CoreFormsFieldset";
                dtCoreFormsFieldset = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFieldset_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtCoreFormsFieldset.Rows.Count>=1){
                  strRisultato=strRisultato + "<li>Fieldset presente</li>";        
                }else{
                  strSQL="INSERT INTO CoreFormsFieldset (CoreForms_Ky,CoreFormsTabs_Ky,CoreFormsFieldset_Title,CoreFormsFieldset_Order) VALUES (156,Null,'" + FirstLetterToUpper(dtCoreModules.Rows[i]["CoreModules_Code"].ToString()) + "',10)";
                  strRisultato=strRisultato + "<li>" + strSQL + "</li>";        
                  new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                }
              }*/

              
              
              
              strRisultato=strRisultato + "</ul>";        
            }                    

      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
  public string FirstLetterToUpper(string str)
  {
      if (str == null)
          return null;

      if (str.Length > 1)
          return char.ToUpper(str[0]) + str.Substring(1);

      return str.ToUpper();
  }
}
