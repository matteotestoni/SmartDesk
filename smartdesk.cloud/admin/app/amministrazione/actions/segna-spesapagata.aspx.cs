using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");    
    public string strFROMNet = "";
    public DateTime dt;
    public string strSpese_Ky="";
    public string strPagamentiMetodo_Ky="";
    public string strSorgente="";
    public DataTable dtSpese;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          strSpese_Ky = Smartdesk.Current.Request("Spese_Ky");
          strSorgente=Smartdesk.Current.Request("sorgente");
          strPagamentiMetodo_Ky = Request["PagamentiMetodo_Ky"];
          strWHERENet="Spese_Ky=" + strSpese_Ky;
          strORDERNet = "Spese_Ky";
          strFROMNet = "Spese_Vw";
          dtSpese = new DataTable("Spese");
          dtSpese = Smartdesk.Sql.getTablePage(strFROMNet, null, "Spese_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          aggiornaPagamento();
		  switch (strSorgente){
            case "scheda-spese":
              Response.Redirect("/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&salvato=salvato&Spese_Ky=" + strSpese_Ky);
              break;
           default:
              Response.Redirect("/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&salvato=salvato&Spese_Ky=" + strSpese_Ky);
              break;
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageBack +"?errore=datinoninseriti");
      }
    }    

    
    public bool aggiornaPagamento(){
      string strSQL="";
	  strSQL = "INSERT INTO Pagamenti";
      strSQL += "([Pagamenti_Riferimenti]";
      strSQL += ",[Pagamenti_Data]";
      strSQL += ",[Pagamenti_DataPagato]";
      strSQL += ",[Pagamenti_Importo]";
      strSQL += ",[Anagrafiche_Ky]";
      strSQL += ",[Spese_Ky]";
	  if (dtSpese.Rows[0]["Commesse_Ky"].ToString().Length>0){
      	strSQL += ",[Commesse_Ky]";
      }
      strSQL += ",[PagamentiTipo_Ky]";
      strSQL += ",[PagamentiMetodo_Ky]";
      strSQL += ",[Pagamenti_Pagato]";
      strSQL += ")";
      strSQL += " VALUES";
      strSQL += "(";
      strSQL += "'" + dtSpese.Rows[0]["Spese_Titolo"].ToString() + "',";
      strSQL += "GETDATE(),";
      strSQL += "GETDATE(),";
      strSQL += dtSpese.Rows[0]["Spese_Totale"].ToString().Replace(",",".") + ",";
      strSQL += dtSpese.Rows[0]["Anagrafiche_Ky"].ToString() + ",";
      strSQL += dtSpese.Rows[0]["Spese_Ky"].ToString() + ",";
	  if (dtSpese.Rows[0]["Commesse_Ky"].ToString().Length>0){
      	strSQL += dtSpese.Rows[0]["Commesse_Ky"].ToString() + ",";
      }
      strSQL += "2,";
      strSQL += strPagamentiMetodo_Ky + ",";
      strSQL += "1";
      strSQL += ")";
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    return true;
    } 
}
