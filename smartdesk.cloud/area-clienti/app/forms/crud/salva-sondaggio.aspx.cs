using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtForms;
    public DataTable dtFormsFields;
    public DataTable dtFormsValori;
    public DataTable dtAnagrafica;
    public string strAnagrafiche_Ky="";
    public string strForms_Ky = "";
    public string strFROMNet = "";
    public int intAnno = 0;
    public int intMese = 0;
    public DateTime dt;
    public string strFirma = "";
    public string strTipo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strCorpo="";
      string strTo = "";
      string strBcc = "";
      string strSubject = "";
      string strValori = "";
      string strFrom = "";

            
      strAnagrafiche_Ky=(FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
	  if (strAnagrafiche_Ky!=null){
          strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
         
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            //Anagrafica
            strWHERENet="Anagrafiche_Ky =" + strAnagrafiche_Ky;
            strFROMNet = "Anagrafiche_Vw";
            strORDERNet = "Anagrafiche_RagioneSociale ASC";
            dtAnagrafica = new DataTable("Anagrafiche");
            dtAnagrafica = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strForms_Ky=Smartdesk.Current.Request("Forms_Ky");
            if ((strForms_Ky==null) || strForms_Ky.Length<1){
			  strForms_Ky="1";	
			}     
			strWHERENet="Forms_Ky=" + strForms_Ky;
            strORDERNet = "Forms_Ky";
            strFROMNet = "Forms";
            dtForms = new DataTable("Forms");
            dtForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "Forms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

    		strWHERENet="(Forms_Ky=" + strForms_Ky + "  And Anagrafiche_Ky=" + strAnagrafiche_Ky + ")";
    		//Response.Write(strWHERENet);
    		strORDERNet = "FormsFields_Ordine ASC";
    		strFROMNet = "FormsValori_Vw";
    		dtFormsValori = new DataTable("FormsValori");
    		dtFormsValori = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            dt=DateTime.Now;
            int intYear=dt.Year;
            int intMonth=dt.Month;

            strSubject=dtForms.Rows[0]["Forms_EmailSubjectThankyou"].ToString();
            strCorpo=dtForms.Rows[0]["Forms_EmailBodyThankyou"].ToString();
            strBcc=dtForms.Rows[0]["Forms_EmailBcc"].ToString();
            strFrom=dtForms.Rows[0]["Forms_EmailFrom"].ToString();

            strValori="<p>Di seguito i valori scelti:</p>";
            strValori+="<table border=\"1\" cellpadding=\"5\" cellspacing=\"5\">";
            for (int i = 0; i < dtFormsValori.Rows.Count; i++){
                switch (dtFormsValori.Rows[i]["FormsFieldsTipo_Ky"].ToString()){
					case "1":
						strValori+="<tr><td>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</td><td>" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "</td></tr>";
						break;
					case "2":
						strValori+="<tr><td>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</td><td>" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "</td></tr>";
						break;
					case "3":
						strValori+="<tr><td>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</td><td>" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "</td></tr>";
						break;
					case "4":
						strValori+="<tr><td>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</td><td>" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "</td></tr>";
						break;
					case "5":
						strValori+="<tr><td bgcolor=\"#ededed\" colspan=\"2\"><strong>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</strong></td></tr>";
						break;
					case "6":
						strValori+="<tr><td bgcolor=\"#ededed\" colspan=\"2\"><h2>" + dtFormsValori.Rows[i]["FormsFields_Descrizione"].ToString() + "</h2></td></tr>";
						break;
					
				}
            }
            strValori+="</table>";
            strCorpo = strCorpo.Replace("[VALORI]", strValori);
            strTo = dtAnagrafica.Rows[0]["Anagrafiche_EmailContatti"].ToString();
            inviaSondaggio(strFrom,strTo,strBcc,strSubject,strCorpo, "");
            aggiornaSondaggio(strAnagrafiche_Ky,strForms_Ky);
            Response.Redirect("/area-clienti/app/forms/sondaggio-inviato.aspx?Forms_Ky=" + strForms_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);
       }else{
            Response.Redirect("/area-clienti/login.aspx?errore=nessunutente");
      }
      }else{
          Response.Redirect("/area-clienti/login.aspx?errore=datinoninseriti");
      }
    }    

    public bool inviaSondaggio(string strMailFROM,string strMailTO,string strMailBCC,string strMailSubject,string strMailBody, string strAttach){
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new MailAddress(strMailFROM);
        mail.To.Add(new MailAddress(strMailTO));
        mail.Bcc.Add(new MailAddress(strMailBCC));
        mail.Subject = strMailSubject;
        mail.Body = strMailBody;
        mail.IsBodyHtml = true;
        if (strAttach != null && strAttach.Length>0)
        {
            mail.Attachments.Add(new Attachment(strAttach));
        }
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
    
	public bool aggiornaSondaggio(string strAnagrafiche_Ky,string strForms_Ky){
      string strSQL="";
      SqlDataAdapter da = new SqlDataAdapter();
      SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
      SqlCommand cm = new SqlCommand();
      strSQL = "INSERT INTO FormsAvanzamento (Forms_Ky, Anagrafiche_Ky,FormsAvanzamento_Data, FormsAvanzamento_Descrizione, FormsAvanzamento_Stato)";
      strSQL += " VALUES (" + strForms_Ky + "," + strAnagrafiche_Ky + ", GETDATE(), 'Complemento modulo', 3)";
      //Response.Write(strSQL);
      cm.CommandText = strSQL;
      cm.CommandType = CommandType.Text;
      cm.Connection = cn;
      cm.CommandTimeout = 300;
      da.SelectCommand = cm;
      cn.Open();
      cm.ExecuteNonQuery();
      cn.Close();
    return true;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }

}
