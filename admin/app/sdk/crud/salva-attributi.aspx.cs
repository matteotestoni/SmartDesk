using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public bool fCaricato = false;
    public string strAzione = "";
    public string strAttributi_Ky = "";
    public string strCheck = "";
    public string strKy = "";
    public int intNumeroFoto = 0;
    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtAttributi;
    public int intNumRecords = 0;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
    			strKy=Smartdesk.Current.Request("ky");
    			strAzione = Request["azione"];
    			strAttributi_Ky=Smartdesk.Current.Request("Attributi_Ky");
    			Dictionary<string, object> frm = new Dictionary<string, object>();
    			if (Smartdesk.Current.Request("Attributi_Obbligatorio") == "") frm.Add("Attributi_Obbligatorio", false);
    			if (Smartdesk.Current.Request("Attributi_InRicerca") == "") frm.Add("Attributi_InRicerca", false);
    			if (Smartdesk.Current.Request("Attributi_InFiltri") == "") frm.Add("Attributi_InFiltri", false);
    			if (Smartdesk.Current.Request("Attributi_InComparazione") == "") frm.Add("Attributi_InComparazione", false);
    			if (Smartdesk.Current.Request("Attributi_Visibile") == "") frm.Add("Attributi_Visibile", false);
    			if (Smartdesk.Current.Request("Attributi_Annunci") == "") frm.Add("Attributi_Annunci", false);
    			if (Smartdesk.Current.Request("Attributi_Documenti") == "") frm.Add("Attributi_Documenti", false);
    			if (Smartdesk.Current.Request("Attributi_Anagrafiche") == "") frm.Add("Attributi_Anagrafiche", false);
    			if (Smartdesk.Current.Request("Attributi_Prodotti") == "") frm.Add("Attributi_Prodotti", false);
    			if (Smartdesk.Current.Request("Attributi_Commesse") == "") frm.Add("Attributi_Commesse", false);
    			if (Smartdesk.Current.Request("Attributi_Attivita") == "") frm.Add("Attributi_Attivita", false);
    			if (Smartdesk.Current.Request("Attributi_Servizi") == "") frm.Add("Attributi_Servizi", false);
    			strKy = Smartdesk.Functions.SqlWriteKey("Attributi", frm);
    			Response.Redirect("/admin/app/sdk/scheda-attributi.aspx?salvato=salvato&Attributi_Ky=" + strKy);
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
