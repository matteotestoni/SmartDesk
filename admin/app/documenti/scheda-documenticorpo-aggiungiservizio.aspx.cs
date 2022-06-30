using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtServizi;
    public string strH1 = "";
    
    public int intRecxPag = 20;
    public int intNumPagine=1;

    public string strAnagrafiche_Ky="";
    public string strDocumenti_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";
      int intPage = 0;

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strPage = Request["page"];
            strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            strDocumenti_Ky = Smartdesk.Current.Request("Documenti_Ky");
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            strH1="Aggiungi serzio al documento";
            strWHERENet="";
            strFROMNet = "Servizi_Vw";
            strORDERNet = "Servizi_Ordine, Servizi_Titolo";
            dtServizi = new DataTable("Servizi");
            dtServizi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Servizi_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		    		this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtServizi,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
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
