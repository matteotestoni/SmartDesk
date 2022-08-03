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
    public DataTable dtOfficina;
    public string strFROMNet = "";
    public string strH1 = "Scheda officina";
    public string strAzione = "modifica";
    public string strOfficina_Ky = "";
    public string strSorgente = "";
    public string strUrlRedirect = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strOfficina_Ky=Smartdesk.Current.Request("Officina_Ky");
          strAzione = Request["azione"];
          //form per utente corrente
          //accettazione 3
          //preparatori 6
          if (dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString()=="3"){
            strUrlRedirect="/admin/form.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=247&CoreForms_Ky=166&custom=0&azione=" + strAzione + "&Officina_Ky=" + strOfficina_Ky;
          }else{
            strUrlRedirect="/admin/form.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=247&CoreForms_Ky=169&custom=0&azione=" + strAzione + "&Officina_Ky=" + strOfficina_Ky;
          }
          Response.Write(strUrlRedirect);
          Response.Redirect(strUrlRedirect);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
}
