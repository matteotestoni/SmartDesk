using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;


public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strForms_Ky = "";
    public string strAnagrafiche_Ky = "";
    public DataTable dtForms;
    public DataTable dtFormsFields;
    public DataTable dtAnagrafiche;
    public string strDataOra=DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +  DateTime.Now.Second.ToString();
    
    public string strFirma = "";
    public string strAccessi = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
	  string strCorpo="";
      string strTo = "";
      string strSubject = "";
      string strDomain ="";
      string strBcc = "";
      string strFrom = "";

      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strForms_Ky=Smartdesk.Current.Request("Forms_Ky");
          strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
          
          //forms
          strWHERENet="Forms_Ky=" + strForms_Ky;
          strORDERNet = "Forms_Ky";
          strFROMNet = "Forms";
          dtForms = new DataTable("Forms");
          dtForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "Forms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
          //anagrafica
          strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_Ky;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche_Vw";
          dtAnagrafiche = new DataTable("Anagrafiche");
          dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
          if (dtAnagrafiche.Rows.Count>0){
             strTo=dtAnagrafiche.Rows[0]["Anagrafiche_EmailContatti"].ToString();
             strSubject=dtForms.Rows[0]["Forms_EmailSubjectRequest"].ToString();
             strCorpo=dtForms.Rows[0]["Forms_EmailBodyRequest"].ToString();
             strBcc=dtForms.Rows[0]["Forms_EmailBcc"].ToString();
             strFrom=dtForms.Rows[0]["Forms_EmailFrom"].ToString();
              strDomain = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + "/area-clienti/";
              strAccessi="<p>I tuoi dati di accesso sono i seguenti:";
              strAccessi+="<ul>";
              strAccessi+="<li>Indirizzo: <a href=\"" +strDomain + "\">" + strDomain + "</a></li>";
              strAccessi+="<li>Utente: " + dtAnagrafiche.Rows[0]["Anagrafiche_EmailContatti"].ToString() + "</li>";
              strAccessi+="<li>Password: " + dtAnagrafiche.Rows[0]["Anagrafiche_Password"].ToString() + "</li>";
              strAccessi+="</ul>";
              Response.Write(strAccessi);
              Response.Write("<hr>");
              strCorpo = strCorpo.Replace("[ACCESSI]", strAccessi);
              Response.Write(strSubject);
              Response.Write("<hr>");
              Response.Write(strCorpo);
              inviaForms(strFrom, strTo,strBcc,strSubject,strCorpo);
              aggiornaAvanzamento();
              Response.Redirect("/admin/app/forms/invia-forms.aspx");
          }else{
            Response.Redirect("/admin/app/forms/invia-forms.aspx");
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public bool inviaForms(string strMailFROM,string strMailTO,string strMailBCC,string strMailSubject,string strMailBody){
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new MailAddress(strMailFROM);
        mail.To.Add(new MailAddress(strMailTO));
        mail.Bcc.Add(new MailAddress(strMailBCC));
        mail.Subject = strMailSubject;
        mail.Body = strMailBody;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.Normal;
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(Smartdesk.Functions.getOption("core.serversmptuser"), Smartdesk.Functions.getOption("core.serversmptpassword"));
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(Smartdesk.Functions.getOption("core.serversmpt"),Convert.ToInt32(Smartdesk.Functions.getOption("core.serversmptport")));
    		client.Host=Smartdesk.Functions.getOption("core.serversmpt");
    		client.Port=Convert.ToInt32(Smartdesk.Functions.getOption("core.serversmptport"));
        client.UseDefaultCredentials = false;
        client.EnableSsl = Smartdesk.Functions.getOption("core.serversmptssl");
        client.Credentials = mailAuthentication;
        client.Send(mail);
        return true;
    }

    public bool aggiornaAvanzamento()
    {
        string strSQL="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        
        strSQL = "INSERT INTO FormsAvanzamento (Forms_Ky, Anagrafiche_Ky,FormsAvanzamento_Data, FormsAvanzamento_Descrizione, FormsAvanzamento_Stato)";
        strSQL += " VALUES (" + strForms_Ky + "," + strAnagrafiche_Ky + ", GETDATE(), 'Inviata email richiesta compilazione', 1)";
        cm.CommandText = strSQL;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;

        cm.CommandTimeout = 300;
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            cm.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("csLoadData->CreateXslInsUpdXls_In: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }
        return output;
    }
}
