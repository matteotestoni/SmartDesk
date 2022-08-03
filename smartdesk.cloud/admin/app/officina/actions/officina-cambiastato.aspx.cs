using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public int intKy = 0;
    public int intRecensioni_Ky = 0;
    public string strOfficina_Ky="";
    public string strOfficinaStati_Ky="";
    public string strUtenti_Ky="";
    public DataTable dtOfficinaStati;
    public DataTable dtOfficina;
    public DataTable dtCoreEmailTemplate;
    public DataTable dtCoreModulesOptionsValue;
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strTO="";
    public string strEmailBody="";
    public string strSubject="";
    public DataTable dtLogin;
    public string strFROM="";
    public string strLingue_Ky="1";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
    if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
        strOfficina_Ky=Smartdesk.Current.Request("Officina_Ky");
        strOfficinaStati_Ky=Smartdesk.Current.Request("OfficinaStati_Ky");
        strUtenti_Ky=Smartdesk.Current.Request("Utenti_Ky");

        strWHERENet="Officina_Ky=" + strOfficina_Ky;
        strORDERNet = "Officina_Ky";
        strFROMNet = "Officina_Vw";
        dtOfficina = new DataTable("Officina");
        dtOfficina = Smartdesk.Sql.getTablePage(strFROMNet, null, "Officina_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

        strSQL= "UPDATE Officina SET OfficinaStati_Ky=" + strOfficinaStati_Ky + ", Officina_DateUpdate=GETDATE(), Officina_UserUpdate=" + strUtenti_Ky + "  WHERE Officina_Ky = " + strOfficina_Ky;
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strSQL= "INSERT INTO OfficinaAvanzamenti (OfficinaAvanzamenti_Data,Officina_Ky,OfficinaStati_Ky,OfficinaAvanzamenti_UserInsert,OfficinaAvanzamenti_DateInsert,Utenti_Ky)";
        strSQL+= " VALUES (GETDATE()," + strOfficina_Ky + "," + strOfficinaStati_Ky + "," + strUtenti_Ky + ",GETDATE()," + strUtenti_Ky + ");"; 
        intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        strWHERENet="OfficinaStati_Ky=" + strOfficinaStati_Ky;
        strORDERNet = "OfficinaStati_Ky";
        strFROMNet = "OfficinaStati";
        dtOfficinaStati = new DataTable("OfficinaStati");
        dtOfficinaStati = Smartdesk.Sql.getTablePage(strFROMNet, null, "OfficinaStati_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
        strTO=dtOfficinaStati.Rows[0]["OfficinaStati_Email"].ToString();
        strSubject="[OFFICINA] > [" + dtOfficina.Rows[0]["OfficinaTipoauto_Titolo"].ToString().ToUpper() + "] > [" + dtOfficinaStati.Rows[0]["OfficinaStati_Titolo"].ToString() + "]" + " > " + dtOfficina.Rows[0]["Officina_Vettura"].ToString() + " " + dtOfficina.Rows[0]["Officina_Colore"].ToString() + " di " + dtOfficina.Rows[0]["Officina_Nominativo"].ToString() + " > " + dtOfficina.Rows[0]["Officina_TargaVettura"].ToString() + " > " + dtOfficina.Rows[0]["Officina_NumeroTelaio"].ToString();
        //notifica responsabili per auto pronta per tipo di auto
        if (strOfficinaStati_Ky=="3"){
          sendEmail();
        }
        
        //se chiusa accodo email per richiesta recensioni
        if (Convert.ToBoolean(dtOfficinaStati.Rows[0]["OfficinaStati_Chiusa"])==true){
          if (dtOfficina.Rows[0]["Lingue_Ky"].ToString().Trim().Length>0){
            strLingue_Ky=dtOfficina.Rows[0]["Lingue_Ky"].ToString();
          }else{
            strLingue_Ky="1";
          }
          strWHERENet="CoreEmailTemplate_Codice='officinareviewrequest' AND Lingue_Ky=" + strLingue_Ky;
          strORDERNet = "CoreEmailTemplate_Ky";
          strFROMNet = "CoreEmailTemplate";
          dtCoreEmailTemplate = new DataTable("CoreEmailTemplate");
          dtCoreEmailTemplate = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEmailTemplate_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

          strFROM=Smartdesk.Functions.getOption("recensioni.fromemail");
          strEmailBody=dtCoreEmailTemplate.Rows[0]["CoreEmailTemplate_MailText"].ToString();
          strEmailBody=strEmailBody.Replace("[Officina_Vettura]", dtOfficina.Rows[0]["Officina_Vettura"].ToString());          
          strEmailBody=strEmailBody.Replace("[Officina_Colore]", dtOfficina.Rows[0]["Officina_Colore"].ToString());          
          strEmailBody=strEmailBody.Replace("[Officina_Nominativo]", dtOfficina.Rows[0]["Officina_Nominativo"].ToString());          
          strSQL= "INSERT INTO CoreEmailQueue (CoreEmailQueue_From ,CoreEmailQueue_To,CoreEmailQueue_Cc,CoreEmailQueue_Ccn,CoreEmailQueue_Subject,CoreEmailQueue_Body,CoreEmailQueue_Sent,CoreEmailQueue_UserInsert,CoreEmailQueue_DateInsert)";
          strSQL+= " VALUES ('" + strFROM + "','" + dtOfficina.Rows[0]["Officina_Email"].ToString() + "','studiorsw@gmail.com','" + strFROM + "','" + dtCoreEmailTemplate.Rows[0]["CoreEmailTemplate_Subject"].ToString() + "', '" + strEmailBody + "',0," + strUtenti_Ky + ", GETDATE() )";
          Response.Write(strSQL);
          intRecensioni_Ky = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
        Response.Write("ok");
        //Response.Write(intKy.ToString());
        //Response.Redirect("/admin/app/sdk/scheda-Officina.aspx?salvato=salvato&Officina_Ky=" + strOfficina_Ky);
      }else{
        Response.Write("ko");
      }
    }
    
    public Boolean sendEmail(){
        string strEmailAnagrafica="";
        string strHtml = "";
        string strMessage = "";
        DataTable dtCoreModulesOptionsValue;
        DataTable dtOfficinaAvanzamenti;
        DataTable dtOfficinaTipoauto;
        DataTable dtAzienda;

        

        strWHERENet="Aziende_Ky=1";
        strORDERNet = "Aziende_Ky";
        strFROMNet = "Aziende_Vw";
        dtAzienda = new DataTable("Azienda");
        dtAzienda = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aziende_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
        
        strWHERENet="Officina_Ky=" + strOfficina_Ky;
        strORDERNet = "OfficinaAvanzamenti_Ky DESC";
        strFROMNet = "OfficinaAvanzamenti_Vw";
        dtOfficinaAvanzamenti = new DataTable("OfficinaAvanzamenti");
        dtOfficinaAvanzamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "OfficinaAvanzamenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

        //il mittente è l'utente corrente
        strFROM=dtLogin.Rows[0]["Utenti_Email"].ToString();

        /*
        dtCoreModulesOptionsValue = new DataTable("Options");
        strWHERENet="CoreModulesOptions_Code='officina.emailfrom'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }*/          
        
        /*
        strWHERENet="OfficinaTipoauto_Ky=" + dtOfficina.Rows[0]["OfficinaTipoauto_Ky"].ToString();
        strORDERNet = "OfficinaTipoauto_Ky";
        strFROMNet = "OfficinaTipoauto";
        dtOfficinaTipoauto = Smartdesk.Sql.getTablePage(strFROMNet, null, "OfficinaTipoauto_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        strTO=dtOfficinaTipoauto.Rows[0]["OfficinaTipoauto_EmailResponsabili"].ToString();
        */
        
    	  strHtml="<html><head><style>*{font-size:14px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;font-weight:700;padding:0;margin:0;} h2{font-size:18px;font-weight:700;padding:0;margin:0;} table{border-collapse: collapse;}</style></head><body>";
    	  strHtml+="<h1 style=\"color:green;margin:5px 0;\">Scheda Officina aggiornata</h1>";


        strHtml+="<fieldset class=\"fieldset\" style=\"margin-bottom:10px\">";
        strHtml+="<legend>Dati scheda</legend>";
        strHtml+="<table border=\"0\" style=\"width:100%\">";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Inserita il</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_DateInsert"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Aggiornata il</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_DateUpdate"].ToString() + "</td>";
        strHtml+="</tr>";
        strHtml+="</table>";
        strHtml+="</fieldset>";

        strHtml+="<fieldset class=\"fieldset\" style=\"margin-bottom:10px\">";
        strHtml+="<legend>Dati vettura</legend>";
        strHtml+="<table border=\"0\" style=\"width:100%\">";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Tipo auto</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["OfficinaTipoauto_Titolo"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Colore</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_Colore"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\"></td><td style=\"text-align:left;padding-right:5px;\"></td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Vettura</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_Vettura"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Targa</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_TargaVettura"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Telaio</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_NumeroTelaio"].ToString() + "</td>";
        strHtml+="</tr>";
        strHtml+="</table>";
        strHtml+="</fieldset>";
        
        strHtml+="<fieldset class=\"fieldset\" style=\"margin-bottom:10px\">";
        strHtml+="<legend>Dati proprietario</legend>";
        strHtml+="<table border=\"0\" style=\"width:100%\">";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Nominativo</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_Nominativo"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Email</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_Email"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Telefono</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_Telefono"].ToString() + "</td>";
        strHtml+="</tr>";
        strHtml+="</table>";
        strHtml+="</fieldset>";
        
        strHtml+="<fieldset class=\"fieldset\" style=\"margin-bottom:10px\">";
        strHtml+="<legend>Dati officina</legend>";
        strHtml+="<table border=\"0\" style=\"width:100%\">";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Stato</td><td style=\"text-align:left;padding-right:5px;\"><span style=\"padding:3px;border-radius:5px;background-color:" + dtOfficina.Rows[0]["OfficinaStati_Colore"].ToString() + "\">" + dtOfficina.Rows[0]["OfficinaStati_Titolo"].ToString() + "</span></td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Priorit&agrave;</td><td style=\"text-align:left;padding-right:5px;\"><span style=\"padding:3px;border-radius:5px;background-color:" + dtOfficina.Rows[0]["Priorita_Colore"].ToString() + "\">" + dtOfficina.Rows[0]["Priorita_Descrizione"].ToString() + "</span></td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Accettazione</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_DataAccettazione"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Venditore</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_Venditore"].ToString() + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Data consegna</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["Officina_DataConsegna"].ToString() + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Ora consegna</td><td style=\"text-align:left;padding-right:5px;\">" + dtOfficina.Rows[0]["OfficinaOrari_Orario"].ToString() + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Marchiatura</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Marchiatura") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Mapo</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Mapo") + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Accessori</td><td style=\"text-align:left;padding-right:5px;\" colspan=\"3\">" + dtOfficina.Rows[0]["Officina_AccessoriOfficina"].ToString() + "</td>";
        strHtml+="</tr>";
        strHtml+="</table>";
        strHtml+="</fieldset>";

        strHtml+="<fieldset class=\"fieldset\" style=\"margin-bottom:10px\">";
        strHtml+="<legend>Preparazione</legend>";
        strHtml+="<table border=\"0\" style=\"width:100%\">";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"120\">Preparatore</td><td style=\"text-align:left;padding-right:5px;\" colspan=\"3\">" + dtOfficina.Rows[0]["OfficinaPreparatori_Nominativo"].ToString() + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"120\">Telaio</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Telaio") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Targa</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Targa") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Doppie Chiavi</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_DoppieChiavi") + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"120\">Manuali</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Manuali") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Accessori</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Accessori") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Controllo livelli</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_ControlloLivelli") + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"120\">Controllo batteria</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_ControlloBatteria") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Vetrofania</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Vetrofania") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Spie</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Spie") + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"120\">Data e ora</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_DataOra") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Tappeti</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Tappeti") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Pressione gomme</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_PressioneGomme") + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"120\">Carburante</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Carburante") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Carrozzeria</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Carrozzeria") + "</td>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"100\">Kit fix & go ruotino</td><td style=\"text-align:left;padding-right:5px;\">" + GetCheckValue(dtOfficina,"Officina_Kitfixgoruotino") + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"120\">Portatarghe</td><td style=\"text-align:left;padding-right:5px;\" colspam=\"3\">" + GetCheckValue(dtOfficina,"Officina_Portatarghe") + "</td>";
        strHtml+="</tr>";
        strHtml+="<tr>";
        strHtml+="<td style=\"text-align:right;padding-right:5px;\" width=\"120\">Note</td><td style=\"text-align:left;padding-right:5px;\" colspam=\"3\">" + dtOfficina.Rows[0]["Officina_Note"].ToString() + "</td>";
        strHtml+="</tr>";
        strHtml+="</table>";
        strHtml+="</fieldset>";
        
        strHtml+="<fieldset class=\"fieldset\" style=\"margin-bottom:10px\">";
        strHtml+="<legend>Cronologia</legend>";
        strHtml+="<table border=\"0\" style=\"width:100%\">";
        strHtml+="<tr><td>Data</td><td>Stato</td><td>Utente</td></tr>";
				for (int x = 0; x < dtOfficinaAvanzamenti.Rows.Count; x++){
          strHtml+="<tr><td>" + dtOfficinaAvanzamenti.Rows[x]["OfficinaAvanzamenti_Data"].ToString() + "</td><td><span style=\"padding:3px;border-radius:5px;background-color:" + dtOfficinaAvanzamenti.Rows[x]["OfficinaStati_Colore"].ToString() + "\">" + dtOfficinaAvanzamenti.Rows[x]["OfficinaStati_Titolo"].ToString() + "</span></td><td>" + dtOfficinaAvanzamenti.Rows[x]["Utenti_Nominativo"].ToString() + "</td></tr>";
        }
        strHtml+="</table></fieldset>";
    	  strHtml+="<p>Puoi consultare lo storico del Officina alla tua area riservata al seguente indirizzo: <a href=\"https://" + Request.Url.Host + "/admin/\">" + Request.Url.Host + "/admin/</a></p>";
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new System.Net.Mail.MailAddress(strFROM);
        string[] strEmails = strTO.Split(',');
        foreach (var strEmail in strEmails)
        {
          if (strEmail!=null && strEmail.Length>0){
            mail.To.Add(new System.Net.Mail.MailAddress(strEmail));
          }
        }
        mail.Subject = strSubject;
        mail.Body = strHtml;
        mail.IsBodyHtml = true;
        //Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTP"].ToString() + "<br>");
        //Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTPUtente"].ToString() + "<br>");
        //Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTPPassword"].ToString() + "<br>");
        //Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTPPorta"].ToString() + "<br>");
        //Response.Write(dtAzienda.Rows[0]["Aziende_ServerSMTPSSL"].ToString() + "<br>");
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(dtAzienda.Rows[0]["Aziende_ServerSMTP"].ToString(), Convert.ToInt32(dtAzienda.Rows[0]["Aziende_ServerSMTPPorta"].ToString()));
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(dtAzienda.Rows[0]["Aziende_ServerSMTPUtente"].ToString(), dtAzienda.Rows[0]["Aziende_ServerSMTPPassword"].ToString());
        client.UseDefaultCredentials = false;
        client.Credentials = mailAuthentication;
        client.EnableSsl = (bool)dtAzienda.Rows[0]["Aziende_ServerSMTPSSL"];
        client.Send(mail);
      return true;
    }

    public String GetCheckValue (DataTable dtTabella, string strField) {
        Boolean boolValore = false;
        String strValore = "<i class=\"fa-duotone fa-square fa-fw\"></i>";
        boolValore = Smartdesk.Data.FieldBool (dtTabella, strField);
        if (boolValore){
          strValore = "<div style=\"border:1px solid #000000;width:25px;height:15px;padding:2px;font-size:11px;text-align:center;vertical-align:middle;font-weight:700\"> S&igrave;</div>";
        }else{
          strValore = "<div style=\"border:1px solid #000000;width:25px;height:15px;padding:2px;font-size:11px;text-align:center;vertical-align:middle;font-weight:700\"> No</div>";
        }
        return strValore;
    }
}
