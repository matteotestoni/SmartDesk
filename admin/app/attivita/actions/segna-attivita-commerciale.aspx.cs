using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin = "";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    public string strAnagrafiche_Ky = "";
    public string strOpportunita_Ky = "";
    public string strFROMNet = "";
    public string strSorgente = "";
    public DateTime dt;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Smartdesk.Login.Verify)
        {
            dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            if (dtLogin.Rows.Count > 0)
            {
                boolAdmin = (dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
                strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
                strOpportunita_Ky = Smartdesk.Current.Request("Opportunita_Ky");
                if (strOpportunita_Ky == null || strOpportunita_Ky.Length < 1)
                {
                    strOpportunita_Ky = "null";
                }
                strSorgente = Smartdesk.Current.Request("sorgente");
                segnaFattaAttivita();
                switch (strSorgente)
                {
                    case "scheda-opportunita":
                        Response.Redirect("/admin/app/commerciale/scheda-opportunita.aspxsalvato=salvato&?Opportunita_ky=" + strOpportunita_Ky + "&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                        break;
                    case "scheda-anagrafiche":
                        Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                        break;
                    default:
                        Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                        break;

                }
            }
            else
            {
                Response.Redirect(Smartdesk.Current.LoginPageBack + "?errore=nessunutente");
            }
        }
        else
        {
            Response.Redirect(Smartdesk.Current.LoginPageBack + "?errore=datinoninseriti");
        }
    }

    public bool segnaFattaAttivita()
    {
        string strSQL = "";
        strSQL = "INSERT INTO Attivita";
        strSQL += "(Attivita_Descrizione";
        strSQL += ",Attivita_Inizio";
        strSQL += ",Attivita_OraInizio";
        strSQL += ",Attivita_Scadenza";
        strSQL += ",Attivita_OraScadenza";
        strSQL += ",Attivita_Chiusura";
        strSQL += ",Anagrafiche_Ky";
        strSQL += ",Opportunita_Ky";
        strSQL += ",AttivitaTipo_Ky";
        strSQL += ",Attivita_Completo";
        strSQL += ",Priorita_Ky";
        strSQL += ",Attivita_Ore";
        strSQL += ",Attivita_Trasferta";
        strSQL += ",Attivita_Km";
        strSQL += ",Attivita_RimborsoKm";
        strSQL += ",Attivita_SpeseKm";
        strSQL += ",Attivita_SpeseAutostrada";
        strSQL += ",Attivita_SpeseParcheggi";
        strSQL += ",Attivita_SpesePasti";
        strSQL += ",Attivita_SpeseMezziPubblici";
        strSQL += ",Attivita_SpeseTotali";
        strSQL += ",AttivitaSettore_Ky";
        strSQL += ",Utenti_Ky";
        strSQL += ")";
        strSQL += " VALUES";
        strSQL += "('attivita commerciale'";
        strSQL += ",GETDATE()";
        strSQL += ",CONVERT (time, SYSDATETIME())";
        strSQL += ",GETDATE()";
        strSQL += ",CONVERT (time, SYSDATETIME())";
        strSQL += ",GETDATE()";
        strSQL += "," + strAnagrafiche_Ky;
        strSQL += "," + strOpportunita_Ky;
        strSQL += ",3";
        strSQL += ",1";
        strSQL += ",1";
        strSQL += ",0.25";
        strSQL += ",1";
        strSQL += ",0";
        strSQL += ",0";
        strSQL += ",0";
        strSQL += ",0";
        strSQL += ",0";
        strSQL += ",0";
        strSQL += ",0";
        strSQL += ",0";
        strSQL += ",2";
        strSQL += "," + Smartdesk.Session.CurrentUser.ToString();
        strSQL += ")";

        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

        return true;
    }

   
}
