using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public string strAnagrafiche_Ky="";
    public DataTable dtAnagrafica;
    public DataTable dtForms;
    public DataTable dtFormsFields;
    public DataTable dtFormsValori;
    public DataTable dtFormsAvanzamento;
    public string strFROMNet = "";
    public string strH1 = "Anteprima sondaggio";
    public string strAzione = "";
    public string strForms_Ky = "";
    
    public DataTable dtFormsFieldsConteggio;
    public decimal decPercCompilato = 0;
    public string strRequired="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
	  if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          	strAnagrafiche_Ky=Smartdesk.Session.CurrentUser.ToString();
            strAzione=Smartdesk.Current.Request("azione");
	            strForms_Ky=Smartdesk.Current.Request("Forms_Ky");
	            if ((strForms_Ky==null) || strForms_Ky.Length<1){
				  strForms_Ky="1";	
				}     
				strWHERENet="Forms_Ky=" + strForms_Ky;
	            strORDERNet = "Forms_Ky";
	            strFROMNet = "Forms";
	            dtForms = new DataTable("Forms");
	            dtForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "Forms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

				strWHERENet="Forms_Ky=" + strForms_Ky;
				strORDERNet = "FormsFields_Ordine ASC";
				strFROMNet = "FormsFields";
				dtFormsFields = new DataTable("FormsFields");
				dtFormsFields = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsFields_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

				strWHERENet="Forms_Ky=" + strForms_Ky + " And Anagrafiche_Ky=" + Smartdesk.Session.CurrentUser.ToString();
				strORDERNet = "FormsValori_Ky";
				strFROMNet = "FormsValori_Vw";
				dtFormsValori = new DataTable("FormsValori");
				dtFormsValori = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsValori_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				
				strWHERENet="Forms_Ky=" + strForms_Ky + " And FormsFieldsTipo_Ky<>5";
				strORDERNet = "FormsFields_Ky";
				strFROMNet = "FormsFields";
				dtFormsFieldsConteggio = new DataTable("FormsFieldsConteggio");
				dtFormsFieldsConteggio = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsFields_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
				strWHERENet="Forms_Ky=" + strForms_Ky + " And FormsAvanzamento_Stato=3";
				strORDERNet = "FormsAvanzamento_Ky";
				strFROMNet = "FormsAvanzamento";
				dtFormsAvanzamento = new DataTable("FormsAvanzamento");
				dtFormsAvanzamento = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsAvanzamento_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				if (dtFormsValori.Rows.Count>0){
          decPercCompilato=dtFormsValori.Rows.Count*100/dtFormsFieldsConteggio.Rows.Count;
        }else{
          decPercCompilato=0;
        }

      }else{
            Response.Redirect(".." + Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;

    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
