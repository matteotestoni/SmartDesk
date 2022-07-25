using System;
using System.Configuration;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
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
    
    public string strAnagrafiche_Ky="";
    public string strDocumenti_Ky="";
    public string strCommesse_Ky="";
    public string strDocumentiStato_Ky="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
		          strWHERENet = "DocumentiStato_Ky=2";
		          strORDERNet = "Documenti_Ky";
		          strFROMNet = "Documenti";
		          dtDocumenti = new DataTable("Documenti");
		          dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              SqlDataAdapter da = new SqlDataAdapter();
              DataTable dt = new DataTable("getTable");
             SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
              SqlCommand cm = new SqlCommand();
              
              cm.CommandType = CommandType.Text;
              cm.Connection = cn;
              cm.CommandTimeout = 300;
              da.SelectCommand = cm;
              cn.Open();
    					for (int i = 0; i < dtDocumenti.Rows.Count; i++){
    						strDocumenti_Ky=dtDocumenti.Rows[i]["Documenti_Ky"].ToString();
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


    					
    					}
              cn.Close();
				switch (strSorgente){
					case "scheda-documenti":
					  Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=" + strDocumenti_Ky);
					  break;
					case "elenco-documenti":
					  Response.Redirect("/admin/app/documenti/elenco-documenti.aspx");
					  break;
					default:
					  Response.Redirect("/admin/app/documenti/elenco-documenti.aspx");
					  break;
				}
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
