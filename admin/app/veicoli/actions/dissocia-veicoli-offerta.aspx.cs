using System;
using System.Data;


public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");    
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");    
    public string strFROMNet = "";
    
    public string strVeicoliOfferte_Ky="";
    public string strSorgente="";
    public DataTable dtVeicoliOfferte;
    public DataTable dtVeicoli;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strSQL="";
      decimal intValore=0;
      decimal intValoreInOfferta=0;
      decimal intSconto=0;

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          strVeicoliOfferte_Ky = Smartdesk.Current.Request("VeicoliOfferte_Ky");
          strWHERENet="";
          strORDERNet = "Veicoli_Ky";
          strFROMNet = "Veicoli";
          dtVeicoli = new DataTable("Veicoli");
          dtVeicoli = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strSQL="DELETE FROM VeicoliOfferteAuto WHERE VeicoliOfferte_Ky=" + strVeicoliOfferte_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

          switch (strSorgente){
            case "scheda-veicoliofferte":
              Response.Redirect("/admin/app/veicoli/scheda-VeicoliOfferte.aspx?custom=1&CoreModules_Ky=29&CoreEntities_Ky=126&CoreGrids_Ky=147&CoreForms_Ky=117&azione=edit&VeicoliOfferte_Ky=" + strVeicoliOfferte_Ky);
              break;
           default:
              Response.Redirect("/admin/app/veicoli/scheda-VeicoliOfferte.aspx?custom=1&CoreModules_Ky=29&CoreEntities_Ky=126&CoreGrids_Ky=147&CoreForms_Ky=117&azione=edit&VeicoliOfferte_Ky=" + strVeicoliOfferte_Ky);
              break;
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageBack +"?errore=datinoninseriti");
      }
    }    
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
