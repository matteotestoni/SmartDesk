using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin = "";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strAttivita_Ky = "";
    public string strAnagrafiche_Ky = "";
    public string strUtenti_Ky = "";
    public string strCommesse_Ky = "";
    public string strOpportunita_Ky = "";
    public string strPagamenti_Ky = "";
    public string strDocumenti_Ky = "";
    public string strTicket_Ky = "";
    public DataTable dtAttivita;
    public string strAzione = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strSorgente = "";
    public string strAttivitaSettore_Ky = "1";
    public string strAttivitaStati_Ky = "";
    
    public string strKy = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        

        if (Smartdesk.Login.Verify)
        {
            dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString()); 
            strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
            strUtenti_Ky = Smartdesk.Current.Request("Utenti_Ky");
            strCommesse_Ky = Smartdesk.Current.Request("Commesse_Ky");
            strOpportunita_Ky = Smartdesk.Current.Request("Opportunita_Ky");
            strDocumenti_Ky = Smartdesk.Current.Request("Documenti_Ky");
            strPagamenti_Ky = Smartdesk.Current.Request("Pagamenti_Ky");
            strSorgente = Request["sorgente"];
            strTicket_Ky = Smartdesk.Current.Request("Ticket_Ky");
            strAttivitaStati_Ky = Smartdesk.Current.Request("AttivitaStati_Ky");
           //Response.Write(strSorgente);
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (strAttivitaStati_Ky=="5"){
              if (Smartdesk.Current.Request("Attivita_Completo") == "") frm.Add("Attivita_Completo", true);
              if (Smartdesk.Current.Request("Attivita_Chiusura") == "") frm.Add("Attivita_Chiusura", Smartdesk.Current.Request("Attivita_Scadenza"));
            }else{
              if (Smartdesk.Current.Request("Attivita_Completo") == "") frm.Add("Attivita_Completo", false);
            }
            if (Smartdesk.Current.Request("Attivita_Trasferta") == "") frm.Add("Attivita_Trasferta", false);
            if (Smartdesk.Current.Request("AttivitaSettore_Ky") == "") frm.Add("AttivitaSettore_Ky", 1);
        		strKy = Smartdesk.Functions.SqlWriteKey("Attivita", frm);
            aggiornaAnnuncio();
            if (strTicket_Ky.Length>0){
              sendEmailTicket();
            }
            //strSorgente="aa";
            //Response.Write(strSorgente);
            switch (strSorgente)
            {
                case "scheda-attivita":
                    Response.Redirect("/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky + "&Attivita_Ky=" + strAttivita_Ky + "&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "prospetto":
                    Response.Redirect("/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1&salvato=salvato&Attivita_Ky=" + strAttivita_Ky + "&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "scheda-anagrafiche":
                    Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky + "#attivita");
                    break;
                case "scheda-commessa":
                    Response.Redirect("/admin/app/progetti/scheda-commesse.aspx?salvato=salvato&Commesse_Ky=" + strCommesse_Ky + "&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "scheda-progetti":
                    Response.Redirect("/admin/app/progetti/scheda-progetti.aspx?salvato=salvato&Commesse_Ky=" + strCommesse_Ky + "&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "scheda-opportunita":
                    Response.Redirect("/admin/app/commerciale/scheda-opportunita.aspx?salvato=salvato&Opportunita_Ky=" + strOpportunita_Ky + "&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "scheda-trasferta":
                    Response.Redirect("/admin/app/attivita/elenco-attivita-trasferte.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=273&salvato=salvato&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "elenco-trasferte":
                    Response.Redirect("/admin/app/attivita/elenco-attivita-trasferte.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=273&salvato=salvato&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "elenco-attivita":
                    Response.Redirect("/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62&salvato=salvato&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "calendario":
                    Response.Redirect("/admin/app/calendario/calendario.aspx?salvato=salvato&Utenti_Ky=" + strUtenti_Ky + "#tabs-4");
                    break;
                case "scheda-pagamenti":
                    Response.Redirect("/admin/app/pagamenti/scheda-pagamenti.aspx?salvato=salvato&Pagamenti_Ky=" + strPagamenti_Ky + "&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "scheda-documenti":
                    Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?salvato=salvato&Documenti_Ky=" + strDocumenti_Ky + "&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                case "home":
                    Response.Redirect("/admin/home.aspx");
                    break;
                case "form-147":
                    Response.Redirect("/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231&CoreForms_Ky=147&custom=0&azione=edit&Ticket_Ky="+ strTicket_Ky + "&Utenti_Ky=" + strUtenti_Ky + "#attivita");
                    break;
                default:
                    Response.Redirect("/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky + "&Attivita_Ky=" + strAttivita_Ky + "&Utenti_Ky=" + strUtenti_Ky);
                    break;
            }
        }
        else
        {
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }

    public Boolean sendEmailTicket(){
      string strFROM="";
      string strTO="";
      string strServerSMTP="";
      string strServerSMTPUser="";
      string strServerSMTPPassword="";
      string strServerSMTPPorta="";
      string strServerSMTPSSL="";
      string strEmailAnagrafica="";
      string strHtml = "";
      DataTable dtTicket;
      DataTable dtAttivita;
        
      strServerSMTP=Smartdesk.Functions.getOption("core.serversmptuser");
      strServerSMTPUser=Smartdesk.Functions.getOption("core.serversmptuser");
      strServerSMTPPassword = Smartdesk.Functions.getOption("core.serversmptpassword");
      strServerSMTPPorta = Smartdesk.Functions.getOption("core.serversmptport");
      strServerSMTPSSL = Smartdesk.Functions.getOption("core.serversmptssl");
      strFROM = Smartdesk.Functions.getOption("ticket.emailfrom");
      strTO = Smartdesk.Functions.getOption("ticket.emailto");

        strWHERENet="Ticket_Ky=" + strTicket_Ky;
        strORDERNet = "Ticket_Ky";
        strFROMNet = "Ticket_Vw";
        dtTicket = new DataTable("Ticket");
        dtTicket = Smartdesk.Sql.getTablePage(strFROMNet, null, "Ticket_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtTicket.Rows.Count>0){
            strEmailAnagrafica=dtTicket.Rows[0]["Anagrafiche_EmailContatti"].ToString();
        }            

        strWHERENet="Attivita_Ky=" + strKy;
        strORDERNet = "Attivita_Ky";
        strFROMNet = "Attivita_Vw";
        dtAttivita = new DataTable("Attivita");
        dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        strHtml="<html><head><style>*{font-size:14px;font-family: 'Google Sans', Roboto;} h1{font-size:26px;font-weight:700;padding:0;margin:0;} h2{font-size:18px;font-weight:700;padding:0;margin:0;} table{border-collapse: collapse;}</style></head><body>";
        strHtml+="<h1 style=\"color:green;margin:5px 0;\">Ticket aggiornato</h1>";
        strHtml+="<p>Puoi consultare lo storico del ticket alla tua area riservata al seguente indirizzo:&nbsp;<a href=\"https://" + Request.Url.Host + "/area-clienti/\">" + Request.Url.Host + "/area-clienti/</a></p>";
        strHtml+="<h2>Dati del ticket</h2>";
        strHtml+="<p>" + dtAttivita.Rows[0]["Attivita_Descrizione"].ToString() + "</p>";
        
        /*
        Response.Write("Email anagrafica:" + strEmailAnagrafica + "<br>");
        Response.Write("From:" + strFROM + "<br>");
        Response.Write("To:" + strTO + "<br>");
        Response.Write("SMTP:" + strServerSMTP + "<br>");
        Response.Write("porta:" + strServerSMTPPorta + "<br>");
        Response.Write("username:" + strServerSMTPUser + "<br>");
        Response.Write("password:" + strServerSMTPPassword + "<br>");
        Response.Write("ssl:" + strServerSMTPSSL + "<br>");
        */
        
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    		mail.From = new System.Net.Mail.MailAddress(strFROM);
    		mail.To.Add(new System.Net.Mail.MailAddress(strEmailAnagrafica));
    		mail.Bcc.Add(new System.Net.Mail.MailAddress(strTO));
    		mail.Subject = "Ticket aggiornato";
    		mail.Body = strHtml;
    		mail.IsBodyHtml = true;
    		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(strServerSMTP, Convert.ToInt32(strServerSMTPPorta));
    		System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(strServerSMTPUser, strServerSMTPPassword);
    		client.UseDefaultCredentials = false;
    		client.Credentials = mailAuthentication;
    		client.EnableSsl = Convert.ToBoolean(strServerSMTPSSL);
    		client.Send(mail);
        return true;
    }


    public string dta2EN(string strData)
    {
        string strReturn = strData;
        if (strReturn != null && strReturn.Length == 10)
        {
            strReturn = strReturn.Substring(3, 2) + "/" + strReturn.Substring(0, 2) + "/" + strReturn.Substring(6, 4);
        }
        return strReturn;
    }

    public bool aggiornaAnnuncio()
    {
        string strSQL = "gg";
        string strValue = "";
        bool output = false;

        strAzione = Smartdesk.Current.Request("azione");
        
        if (strCommesse_Ky != null && strCommesse_Ky.Length > 0 && Request["Attivita_Ore"] != null)
        {
            strSQL = "UPDATE Commesse SET";
            strSQL += " Commesse_OreImpiegate=Commesse_Totali_Vw.TotaleOreImpiegate,Commesse_OreResidue=Commesse_Totali_Vw.Commesse_OrePreviste-Commesse_Totali_Vw.TotaleOreImpiegate";
            strSQL += " FROM Commesse INNER JOIN Commesse_Totali_Vw ON Commesse.Commesse_Ky=Commesse_Totali_Vw.Commesse_Ky";
            strSQL += " WHERE Commesse.Commesse_Ky=" + strCommesse_Ky;
            //Response.Write(strSQL);
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
        
        //ultime date
        strAttivitaSettore_Ky = Request["AttivitaSettore_Ky"];
        //Response.Write("<hr>settore:"+strAttivitaSettore_Ky);
        strValue = Request["Attivita_Chiusura"];
        if (strValue!=null && strValue.Length > 0)
        {
            strValue = dta2EN(strValue);
            switch (strAttivitaSettore_Ky)
            {
                case "1":
                    strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaTecnica='" + strValue + "' WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                    break;
                case "2":
                    strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaCommerciale='" + strValue + "' WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

                    if (strOpportunita_Ky != null && strOpportunita_Ky.Length > 0)
                    {
                        strSQL = "UPDATE Opportunita SET Opportunita_AttivitaCommerciale='" + strValue + "' WHERE Opportunita_Ky=" + strOpportunita_Ky;
                        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

                        strValue = Request["Attivita_Descrizione"];
                        strSQL = "UPDATE Opportunita SET Opportunita_Stato='" + strValue + "' WHERE Opportunita_Ky=" + strOpportunita_Ky;
                        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                    }
                    break;
                case "3":
                    strSQL = "UPDATE Anagrafiche SET Anagrafiche_AttivitaAmministrazione='" + strValue + "' WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
                    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                    break;
            }
        }
        output=true;
        return output;
    }

    public string FnNum(object o)
    {
        string ret = "null";

        if (o != null)
        {
            if (o.ToString() == "")
            {
                ret = "null";
            }
            else
            {
                ret = o.ToString().Replace(",", ".");
            }
        }
        return ret;
    }

    public string FnText(object o)
    {

        string ret = "";

        if (o != null)
        {
            if (o.ToString() == "")
            {
                ret = "null";
            }
            else
            {
                ret = "'" + o.ToString().Replace("'", "''") + "'";
            }
        }

        return ret;
    }

    public string FnCheck(object o)
    {
        string ret = "null";

        if (o != null)
        {
            ret = (o.ToString() == "on") ? "1" : "0";

        }
        return ret;
    }


    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
