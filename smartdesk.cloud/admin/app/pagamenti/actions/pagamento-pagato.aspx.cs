using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtPagamenti;
    public DataTable dtDocumenti;
    
    public bool boolAdmin = false;
    public string strPagamenti_Ky="";
    public string strAnagrafiche_Ky="";
    public string strDocumenti_Ky="";
    public string strSpese_Ky="";
    public string strPagamenti_Pagato="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      
        
      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            strPagamenti_Ky=Smartdesk.Current.Request("Pagamenti_Ky");
            strPagamenti_Pagato=Request["Pagamenti_Pagato"];
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
            strSpese_Ky=Smartdesk.Current.Request("Spese_Ky");
  	        strSorgente=Smartdesk.Current.Request("sorgente");
            
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable("getTable");
            SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
            SqlCommand cm = new SqlCommand();
            
            strSQL = "UPDATE Pagamenti SET Pagamenti_Pagato=" + strPagamenti_Pagato + ", Pagamenti_DataPagato=GETDATE() WHERE Pagamenti_Ky=" + strPagamenti_Ky;
            //Response.Write(strSQL);
            cm.CommandText = strSQL;
            cm.CommandType = CommandType.Text;
            cm.Connection = cn;
            cm.CommandTimeout = 300;
            da.SelectCommand = cm;
            cn.Open();
            cm.ExecuteNonQuery();
            
            if (strDocumenti_Ky!=null && strDocumenti_Ky.Length>0){
  						strWHERENet="(Pagamenti_Pagato=0 Or Pagamenti_Pagato Is Null) And (Documenti_Ky=" + strDocumenti_Ky + ")";
              strORDERNet = "Pagamenti_Ky";
              strFROMNet = "Pagamenti";
              dtPagamenti = new DataTable("Pagamenti");
              dtPagamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  						if (dtPagamenti!=null && dtPagamenti.Rows.Count>0){
            		strSQL = "UPDATE Documenti SET DocumentiStato_Ky=2 WHERE Documenti_Ky=" + strDocumenti_Ky;
  						}else{
            		strSQL = "UPDATE Documenti SET DocumentiStato_Ky=6 WHERE Documenti_Ky=" + strDocumenti_Ky;
  						}
            	cm.CommandText = strSQL;
            	cm.ExecuteNonQuery();								
  					}            
            cn.Close();
            switch (strSorgente){
              case "home":
                Response.Redirect("/admin/home.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&CoreForms_Ky=145&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                break;
              case "elenco-pagamenti":
                Response.Redirect("/admin/app/pagamenti/elenco-pagamenti.aspx");
                break;
              case "scheda-anagrafiche":
                Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
                break;
              case "scheda-documenti":
                Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=" + strDocumenti_Ky);
                break;
              case "scheda-spese":
                Response.Redirect("/admin/app/amministrazione/scheda-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreForms_Ky=211&Spese_Ky=" + strSpese_Ky);
                break;
            }
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
