using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtPersone;
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

      
      strFROMNet = "Persone_Vw";
      strWHERENet= "(Persone_Attivo=1) AND (Persone_RiceveEmail=1)";
      strORDERNet = "Persone_Ky";
      dtPersone = new DataTable("Persone");
      dtPersone = Smartdesk.Sql.getTablePage(strFROMNet, null, "Persone_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      dt=DateTime.Now;
     
			for (int j = 0; j < dtPersone.Rows.Count; j++){
		      strFROMNet = "Attivita_Vw";
		      strWHERENet= "(Attivita_Completo<>'si' And Persone_Ky=" + dtPersone.Rows[j]["Persone_Ky"].ToString() + ")";
		      strORDERNet = "Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
		      dtAttivita = new DataTable("attivita");
		      dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	  		  strEmail=dtPersone.Rows[j]["Persone_Email"].ToString();
				  if (dtAttivita.Rows.Count>0){
						strHtml="<html><head><style>*{font-size:15px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;padding:0;margin:0;font-weight:700} h2{font-size:18px;padding:0;margin:0;font-weight:700} table{border-collapse: collapse;}</style></head><body>";
						strHtml+="<h2 style=\"margin:20px 0 10px 0;\">" + dtPersone.Rows[j]["Persone_Nome"].ToString() + " " + dtPersone.Rows[j]["Persone_Cognome"].ToString() + " " + dtPersone.Rows[j]["Persone_Email"].ToString() + "</h2>";
						strHtml+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"4\" width=\"100%\">";
						strHtml+="<tr><td align=\"center\" width=\"90\">Scadenza</td><td align=\"left\">Descrizione</td><td align=\"center\" style=\"width:100px\" width=\"150\">Riferimenti</td><td align=\"center\" width=\"80\">Ore Previste</td><td width=\"80\"></td></tr>";
					  for (i = 0; i < dtAttivita.Rows.Count; i++){
							strHtml+="<tr>";
							strHtml+="<td align=\"center\">" + dtAttivita.Rows[i]["Attivita_Scadenza_IT"].ToString() + "</td>";
							strHtml+="<td>" + dtAttivita.Rows[i]["Attivita_Descrizione"].ToString() + "<br><strong>" + dtAttivita.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</strong></td>";
							strHtml+="<td align=\"center\">" + dtAttivita.Rows[i]["Commesse_Riferimenti"].ToString() + "</td>";
							strHtml+="<td align=\"center\">" + dtAttivita.Rows[i]["Attivita_OrePreviste"].ToString() + "</td>";
							strHtml+="<td align=\"center\"><a href=\"https://" + Request.Url.Host + "/admin/app/attivita/scheda-attivita.aspx?Attivita_Ky=" + dtAttivita.Rows[i]["Attivita_Ky"].ToString() + "&Persone_Ky=" + dtPersone.Rows[j]["Persone_Ky"].ToString() + "&sorgente=elenco-attivita\">scheda</a></td>";
			    		strHtml+="</tr>\n";
		
					  }
					  strHtml+="</table>";
					  strHtml+="<br><a href=\"https://" + Request.Url.Host + "/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1&Persone_Ky=" + dtPersone.Rows[j]["Persone_Ky"].ToString() + "\" class=\"button\">Vai al prospetto attivit&agrave;</a> - <a href=\"https://" + Request.Url.Host + "/admin/app/attivita/elenco-attivita.aspx?Persone_Ky=" + dtPersone.Rows[j]["Persone_Ky"].ToString() + "\" class=\"button\">Vai all'elenco attivit&agrave;</a>";
					  strHtml+="</body></html>";
            sendEmailAttivita(strHtml,strEmail);
				  }
			}
      Response.Write("ok");

    }    
    
    
    public Boolean sendEmailAttivita(string strBody, string strDestinatario){
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

        strWHERENet="CoreModulesOptions_Code='attivita.emailreport'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }
        
	      System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    		mail.From = new System.Net.Mail.MailAddress(strFROM);
	      mail.To.Add(new System.Net.Mail.MailAddress(strDestinatario));
	      mail.Subject = "[GESTIONALE] Attivita' da fare " + dt.ToString();
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
  
    public String GetMese(string strMeseIn)
    {
      string strMeseOut="";
      if (strMeseIn!=null){
        switch (strMeseIn){
          case "1":
            strMeseOut="gennaio";
            break;
          case "2":
            strMeseOut="febbraio";
            break;
          case "3":
            strMeseOut="marzo";
            break;
          case "4":
            strMeseOut="aprile";
            break;
          case "5":
            strMeseOut="maggio";
            break;
          case "6":
            strMeseOut="giugno";
            break;
          case "7":
            strMeseOut="luglio";
            break;
          case "8":
            strMeseOut="agosto";
            break;
          case "9":
            strMeseOut="settembre";
            break;
          case "10":
            strMeseOut="ottobre";
            break;
          case "11":
            strMeseOut="novembre";
            break;
          case "12":
            strMeseOut="dicembre";
            break;
        }
      }else{
        strMeseOut="";
      }
      return strMeseOut;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }

}
