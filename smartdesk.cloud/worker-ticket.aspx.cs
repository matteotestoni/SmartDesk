using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtTicket;
    public DataTable dtAttivita;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strHtml = "";
    public DateTime dt;
    public string strEmail = "";
    public string strWHERENet="";
    public string strORDERNet = "";

    protected void Page_Load(object sender, EventArgs e)
    {

      
      strFROMNet = "Ticket_Vw";
      strWHERENet= "(TicketStati_Ky=1)";
      strORDERNet = "Ticket_Ky";
      dtTicket = new DataTable("Ticket");
      dtTicket = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ticket_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      dt=DateTime.Now;
     
     if (dtTicket.Rows.Count>0){
				strHtml="<html><head><style>*{font-size:15px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;padding:0;margin:0;font-weight:700} h2{font-size:18px;padding:0;margin:0;font-weight:700} table{border-collapse: collapse;}</style></head><body>";
				strHtml+="<h2 style=\"margin:20px 0 10px 0;\">Richieste di assistenza aperte</h2>";
        strHtml+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"4\" width=\"100%\">";
				strHtml+="<tr>";
				strHtml+="<th align=\"left\" width=\"90\">Titolo</th>";
				strHtml+="<th align=\"center\" width=\"90\">Data</th>";
				strHtml+="<th align=\"left\" width=\"90\">Categoria</th>";
				strHtml+="<th align=\"left\" width=\"90\">Anagrafica</th>";
				strHtml+="<th align=\"left\" width=\"90\">Utente</th>";
				strHtml+="<th align=\"center\" width=\"90\">Lingua</th>";
				strHtml+="<th align=\"center\" width=\"90\">Attivit&agrave;</th>";
				strHtml+="<th></th>";
				strHtml+="</tr>";
  			for (int j = 0; j < dtTicket.Rows.Count; j++){
  		      strFROMNet = "Attivita_Vw";
  		      strWHERENet= "(Ticket_Ky=" + dtTicket.Rows[j]["Ticket_Ky"].ToString() + ")";
  		      strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
  		      dtAttivita = new DataTable("Attivita");
  		      dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

						strHtml+="<tr>";
						strHtml+="<td align=\"left\">" + dtTicket.Rows[j]["Ticket_Titolo"].ToString() + "</td>";
						strHtml+="<td align=\"center\">" + dtTicket.Rows[j]["Ticket_Data"].ToString() + "</td>";
						strHtml+="<td align=\"left\">" + dtTicket.Rows[j]["TicketCategorie_Titolo"].ToString() + "</td>";
						strHtml+="<td align=\"left\">" + dtTicket.Rows[j]["Anagrafiche_RagioneSociale"].ToString() + "</td>";
						strHtml+="<td align=\"left\">" + dtTicket.Rows[j]["Utenti_Nominativo"].ToString() + "</td>";
						strHtml+="<td align=\"center\">" + dtTicket.Rows[j]["Lingue_Titolo"].ToString() + "</td>";
						strHtml+="<td align=\"center\">" + dtAttivita.Rows.Count + "</td>";
						strHtml+="<td align=\"center\"><a href=\"https://" + Request.Url.Host + "/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231&CoreForms_Ky=147&custom=0&azione=edit&Ticket_Ky=" + dtTicket.Rows[j]["Ticket_Ky"].ToString() + "\" target=\"blank\" class=\"button\">scheda</a></td>";
						strHtml+="</tr>";
  			}
			  strHtml+="</table>";
			  strHtml+="<br><a href=\"https://" + Request.Url.Host + "/admin/view.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231\" class=\"button\">Vai ai ticket</a>";
			  strHtml+="</body></html>";
        //Response.Write(strHtml);
        sendEmailAttivita(strHtml);
      }
      Response.Write("ok");
    }    
    
    public Boolean sendEmailAttivita(string strBody){
        string strFROM="";
        string strTO="";
        string strServerSMTP="";
        string strServerSMTPUser="";
        string strServerSMTPPassword="";
        string strServerSMTPPorta="";
        string strServerSMTPSSL="";
        string strEmailAnagrafica="";
        string strHtml = "";
        DataTable dtCoreModulesOptionsValue;
        
        strWHERENet="CoreModulesOptions_Code='core.serversmpt'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTP=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptuser'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPUser=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpassword'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPassword=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptport'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPorta=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptssl'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPSSL=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            

        strWHERENet="CoreModulesOptions_Code='ticket.emailreportticket'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }
        
        strWHERENet="CoreModulesOptions_Code='ticket.emailreportticket'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strTO=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }

	      System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    		mail.From = new System.Net.Mail.MailAddress(strFROM);
	      mail.To.Add(new System.Net.Mail.MailAddress(strTO));
	      mail.Subject = "Richieste di assistenza aperte " + dt.ToString();
	      mail.Body = strBody;
	      mail.IsBodyHtml = true;
    		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(strServerSMTP, Convert.ToInt32(strServerSMTPPorta));
    		System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(strServerSMTPUser, strServerSMTPPassword);
	      client.UseDefaultCredentials = false;
	      client.Credentials = mailAuthentication;
    		client.EnableSsl = Convert.ToBoolean(strServerSMTPSSL);
	      client.Send(mail);
        /*
        Response.Write("<br>From:" + strFROM + "<br>");
        Response.Write("To:" + strTO + "<br>");
        Response.Write("SMTP:" + strServerSMTP + "<br>");
        Response.Write("porta:" + strServerSMTPPorta + "<br>");
        Response.Write("username:" + strServerSMTPUser + "<br>");
        Response.Write("password:" + strServerSMTPPassword + "<br>");
        Response.Write("ssl:" + strServerSMTPSSL + "<hr>");
        */
        return true;
    }
}
