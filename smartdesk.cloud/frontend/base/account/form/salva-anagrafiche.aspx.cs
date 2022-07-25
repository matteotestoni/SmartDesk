using System;
using System.Collections.Generic;
using System.Data;

public partial class _Default : System.Web.UI.Page {
  public string strAzione = "";
  
  
  public string strWHERENet = "";
  public int intNumRecords = 0;
  public DataTable dtAnagrafiche;
  public DataTable dtAnagraficheGruppi;
  public string strEmailContatti = "";
  public string strReturnUrl = "";
  public string strTemp = "";
  public string strSQL = "";
  public string strAnagraficheGruppi_Titolo = "";
	public string strFoo = "";
	public string strProteggi = "";

  protected void Page_Load (object sender, EventArgs e) {
    string strKy = "";
    string strFrom = "noreply@linkbiz.it";
    bool recaptchaValid=false;
    strProteggi = Request["proteggi"];
    strFoo=Request["foo"]; 		

    recaptchaValid=ReCaptchaPassed(strFoo);
    if (strFoo!=null && strFoo.Length>0 && strFoo!="False"){
          if (recaptchaValid){      
                  strEmailContatti = Request["Anagrafiche_EmailContatti"];
                  strReturnUrl = Request["ReturnUrl"];
                  strWHERENet = "Anagrafiche_EmailContatti='" + strEmailContatti + "'";
                  dtAnagrafiche = new DataTable ("Anagrafiche");
                  dtAnagrafiche = Smartdesk.Sql.getTablePage("Anagrafiche", null, "Anagrafiche_Ky", strWHERENet, "Anagrafiche_EmailContatti", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtAnagrafiche.Rows.Count < 1) {
                    Dictionary<string, object> frm = new Dictionary<string, object> ();
                    frm.Add ("Anagrafiche_EmailAmministrazione", Request["Anagrafiche_EmailContatti"]);
                    if (Smartdesk.Current.Request ("Anagrafiche_Privacy") == "") frm.Add ("Anagrafiche_Privacy", false);
                    if (Smartdesk.Current.Request ("Anagrafiche_Newsletter") == "") frm.Add ("Anagrafiche_Newsletter", false);
                    strTemp = Request["Anagrafiche_RagioneSociale"];
                    if (strTemp.Length < 1) {
                      strTemp = Request["Anagrafiche_Nome"] + " " + Request["Anagrafiche_Cognome"];
                      frm.Add ("Anagrafiche_RagioneSociale", strTemp);
                    }
                    strKy = Smartdesk.Functions.SqlWriteKey ("Anagrafiche", frm);
                    strSQL = "INSERT INTO AnagraficheServizi (AnagraficheServizi_Qta,Servizi_Ky,Anagrafiche_Ky,AnagraficheServizi_Descrizione,AnagraficheServizi_Prezzo,AnagraficheServizi_Importo,AnagraficheServizi_Inizio,AnagraficheServizi_Termine,AnagraficheServizi_Scadenza,AttributiGruppi_Ky,AnagraficheServizi_Rinnovo,AnagraficheServizi_Chiuso,AnagraficheServizi_UserInsert,AnagraficheServizi_UserUpdate,AnagraficheServizi_UserDelete,AnagraficheServizi_DateInsert,AnagraficheServizi_DateUpdate,AnagraficheServizi_DateDelete)";
                    strSQL += " VALUES (1,1," + strKy + ",'Abbonamento GRATIS fino a 5 annunci',0,0,GETDATE(),DATEADD(year, 10, GETDATE()),DATEADD(year, 10, GETDATE()),Null,12,0,0,0,0,GETDATE(),GETDATE(),GETDATE())";
                    new Smartdesk.Sql ().SQLScriptExecuteNonQuery (strSQL);
                    strWHERENet = "Anagrafiche_Ky=" + strKy;
                    dtAnagrafiche = new DataTable ("Anagrafiche");
                    dtAnagrafiche = Smartdesk.Sql.getTablePage("Anagrafiche", null, "Anagrafiche_Ky", strWHERENet, "Anagrafiche_EmailContatti", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              
                    strWHERENet = "AnagraficheGruppi_Ky=" + Request["AnagraficheGruppi_Ky"];
                    dtAnagraficheGruppi = new DataTable ("AnagraficheGruppi");
                    dtAnagraficheGruppi = Smartdesk.Sql.getTablePage("AnagraficheGruppi", null, "AnagraficheGruppi_Ky", strWHERENet, "AnagraficheGruppi_Titolo", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                    if (dtAnagraficheGruppi.Rows.Count>0){
                      strAnagraficheGruppi_Titolo = dtAnagraficheGruppi.Rows[0]["AnagraficheGruppi_Titolo"].ToString ();
                    }
              
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage ();
                    mail.From = new System.Net.Mail.MailAddress (strFrom);
                    mail.To.Add (new System.Net.Mail.MailAddress (strEmailContatti));
                    mail.Bcc.Add (new System.Net.Mail.MailAddress (Smartdesk.Functions.getOption("core.webmasteremail")));
                    mail.Bcc.Add (new System.Net.Mail.MailAddress ("nicolabr1965@gmail.com"));
                    mail.Subject = "[LINKBIZ] Conferma registrazione al sito ";
                    mail.Body = "Confermiamo l'avvenuta registrazione al sito www.linkbiz.it.<br>I tuoi dati di accesso sono:<br>username:" + dtAnagrafiche.Rows[0]["Anagrafiche_EmailContatti"].ToString () + "<br>password:" + dtAnagrafiche.Rows[0]["Anagrafiche_Password"].ToString () + "<br><br>Hai scelto che i tuoi annunci saranno sicronizzati con : " + strAnagraficheGruppi_Titolo + " <br><br><br> Lo staff di linkbiz.it ";
                    mail.IsBodyHtml = true;
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient (Smartdesk.Functions.getOption("core.serversmpt"), Smartdesk.Functions.getOption("core.serversmpt"));
                    client.Port = Convert.ToInt32(Smartdesk.Functions.getOption("core.serversmptport"));
                    System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential (Smartdesk.Functions.getOption("core.serversmptuser"), Smartdesk.Functions.getOption("core.serversmptpassword"));
                    client.UseDefaultCredentials = false;
                    client.Credentials = mailAuthentication;
                    client.EnableSsl = Smartdesk.Functions.getOption("core.serversmptssl");
                    client.Send (mail);
                    Response.Redirect ("/pag/registrazione-completata.html?salvato=salvato&messaggio=email&Anagrafiche_Ky=" + strKy + "&ReturnUrl=" + strReturnUrl);
                  } else {
                    strAzione=Request["azione"];
                    if (strAzione=="modifica"){
                      Dictionary<string, object> frm = new Dictionary<string, object> ();
                      if (Smartdesk.Current.Request ("Anagrafiche_Privacy") == "") frm.Add ("Anagrafiche_Privacy", false);
                      if (Smartdesk.Current.Request ("Anagrafiche_Newsletter") == "") frm.Add ("Anagrafiche_Newsletter", false);
                      strKy = Smartdesk.Functions.SqlWriteKey ("Anagrafiche", frm);
                      Response.Redirect ("/account/area-personale.html");
                    }
                  }
      }else{
        Response.Write("recaptcha");
      }
    }else{
      Response.Write("foo");
    }
  }

    public bool ReCaptchaPassed(string gRecaptchaResponse)
    {
        bool boolReturn=false;
        string strUrl="https://www.google.com/recaptcha/api/siteverify?secret=6Lf1wK0UAAAAAAiluEdjt3urM-ejWd7HpJnb9h9S&response=" + gRecaptchaResponse;
        //Response.Write(strUrl);
        System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        var res = httpClient.GetAsync(strUrl).Result;
        //Response.Write(res);
        if (res.StatusCode != System.Net.HttpStatusCode.OK)
            return false;
        string JSONres = res.Content.ReadAsStringAsync().Result;
        dynamic JSONdata = Newtonsoft.Json.Linq.JObject.Parse(JSONres);            
        //Response.Write("<hr>" + JSONdata.success);
        if (JSONdata.success != "true"){
          boolReturn=false;
        }else{
          boolReturn=true;
        }
        return boolReturn;
    }

  public DataTable getTablePage (string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) {
    DataTable dt = Smartdesk.Sql.getTablePage (table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
    return dt;
  }
}
