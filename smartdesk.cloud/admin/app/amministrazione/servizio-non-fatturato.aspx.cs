using System;
using System.Data;
using System.Data.SqlClient;


  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strAnagraficheServizi_Ky="";
    public string strAnagrafiche_Ky="";
    public string strAnagraficheServizi_Completo="";
    public string strSorgente="";
    
    public DataTable dtServizio;
    public string strMesi="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      
	  
      if (Smartdesk.Login.Verify){
          strAnagraficheServizi_Ky=Smartdesk.Current.Request("AnagraficheServizi_Ky");
          strAnagraficheServizi_Completo=Request["AnagraficheServizi_Completo"];
          strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
          strSorgente=Smartdesk.Current.Request("sorgente");
          strWHERENet = "AnagraficheServizi_Ky =" + strAnagraficheServizi_Ky;
          strORDERNet = "AnagraficheServizi_Ky";
          strFROMNet = "AnagraficheServizi_Vw";
          dtServizio = new DataTable("AnagraficheServizi");
          dtServizio = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strMesi = dtServizio.Rows[0]["AnagraficheServizi_Rinnovo"].ToString();
          //mesi di rinnovo da 0:no a 12:annuale
          strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, -" + strMesi + ", AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, -" + strMesi + ", AnagraficheServizi_Scadenza) WHERE AnagraficheServizi_Ky=" + strAnagraficheServizi_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          switch (strSorgente){
            case "home":
              Response.Redirect("/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
              break;
            case "dafatturare":
              Response.Redirect("/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx");
              break;
            case "scheda-anagrafiche":
              Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
              break;
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
