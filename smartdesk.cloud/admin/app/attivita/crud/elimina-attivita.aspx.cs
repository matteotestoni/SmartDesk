using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
  
    public string strAttivita_Ky = "";
    public string strAnagrafiche_Ky = "";
    public string strCommesse_Ky = "";
    public string strOpportunita_Ky = "";
    public string strSorgente = "";
    public string strUtenti_Ky = "";
    public string strPagamenti_Ky = "";
    public string strDocumenti_Ky = "";
    public string strTicket_Ky = "";
    public string strAzione = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");

        if (Smartdesk.Login.Verify)
        {
                strAttivita_Ky = Smartdesk.Current.Request("Attivita_Ky");
                strUtenti_Ky = Smartdesk.Current.Request("Utenti_Ky");
                strAnagrafiche_Ky = Smartdesk.Current.Request("Anagrafiche_Ky");
                strCommesse_Ky = Smartdesk.Current.Request("Commesse_Ky");
                strOpportunita_Ky = Smartdesk.Current.Request("Opportunita_Ky");
                strDocumenti_Ky = Smartdesk.Current.Request("Documenti_Ky");
                strPagamenti_Ky = Smartdesk.Current.Request("Pagamenti_Ky");
                strTicket_Ky = Smartdesk.Current.Request("Ticket_Ky");
                strSorgente = Smartdesk.Current.Request("sorgente");
                if (strSorgente.Length>0){
                    strSorgente = strSorgente.ToLower();
                }

                if (strDeletemultiplo=="deletemultiplo"){
                    Smartdesk.Functions.SqlDeleteKeyIn("Attivita",strIds);
                }else{
            	      Smartdesk.Functions.SqlDeleteKey("Attivita");
                }
                aggiornaAnnuncio();               
                
                switch (strSorgente)
                {
                    case "home":
                        strRedirect="/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky + "#attivita";
                        break;
                    case "home-tecnici":
                        strRedirect="/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky + "#attivita";
                        break;
                    case "calendario":
                        strRedirect="/admin/app/calendario/calendario.aspx#tabs-4";
                        break;
                    case "prospetto":
                        strRedirect="/admin/app/attivita/attivita-da-fare.aspx?Utenti_Ky=" + strUtenti_Ky + "#attivita";
                        break;
                    case "scheda-anagrafiche":
                        strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + strAnagrafiche_Ky + "#attivita";
                        break;
                    case "scheda-commessa":
                        strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=" + strCommesse_Ky + "#attivita";
                        break;
                    case "scheda-progetti":
                        strRedirect="/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=" + strCommesse_Ky + "#attivita";
                        break;
                    case "scheda-opportunita":
                        strRedirect="/admin/app/commerciale/scheda-opportunita.aspx?Opportunita_Ky=" + strOpportunita_Ky + "#attivita";
                        break;
                    case "scheda-pagamenti":
                        strRedirect="/admin/app/pagamenti/scheda-pagamenti.aspx?Pagamenti_Ky=" + strPagamenti_Ky + "#attivita";
                        break;
                    case "scheda-documenti":
                        strRedirect="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=" + strDocumenti_Ky + "#attivita";
                        break;
                    case "scheda-ticket":
                        strRedirect="/admin/form.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231&CoreForms_Ky=147&salvato=salvato&Ticket_Ky=" + strTicket_Ky + "#attivita";
                        break;
                }
	        	Response.Redirect(strRedirect);
        }
        else
        {
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }

    public bool aggiornaAnnuncio()
    {
        string strSQL = "gg";
        bool output = false;
        
        if (strCommesse_Ky != null && strCommesse_Ky.Length > 0)
        {
            strSQL = "UPDATE Commesse SET";
            strSQL += " Commesse_OreImpiegate=Commesse_Totali_Vw.TotaleOreImpiegate,Commesse_OreResidue=Commesse_Totali_Vw.Commesse_OrePreviste-Commesse_Totali_Vw.TotaleOreImpiegate";
            strSQL += " FROM Commesse INNER JOIN Commesse_Totali_Vw ON Commesse.Commesse_Ky=Commesse_Totali_Vw.Commesse_Ky";
            strSQL += " WHERE Commesse.Commesse_Ky=" + strCommesse_Ky;
            //Response.Write(strSQL);
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
        
        output=true;
        return output;
    }

}
