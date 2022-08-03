namespace Smartdesk{

  public static class Documenti{
    public static int CoreModules_Ky = 13;
    public static string CoreModules_Code = "documenti";
    public static string[] CoreEntities = {"Aziende","AziendeSedi","AziendeSediOrari","AziendeSediReparti","BlacklistEmail","Colori","Comuni","ComuniZone","CoreEmailQueue","CoreEmailTemplate","Divise","Lingue","Nazioni","Ore","Priorita","Province","Regioni","TimeZones","Titoli","Utenti","UtentiGruppi","UtentiLog","UtentiTeams","UtentiTipo","AliquoteIVA","CentridiCR","Conti","ContiMovimentiCausali","ImposizioniIVA","Spese","TerminiCondizioni","Anagrafiche","AnagraficheTipologia","AnagraficheCategorie","AnagraficheContatti","AnagraficheContattiTipo","AnagraficheIndirizzi","AnagraficheLog","AnagraficheStati","AnagraficheTipo","AnagraficheGruppi","AnagraficheTag","AnagraficheProdotti","AnagraficheServizi","Annunci","AnnunciCategorie","AnnunciMarca","AnnunciModello","AnnunciModelloTipo","AnnunciStato","AnnunciTipo","AnnunciTipologie","AnnunciSorgenti","Ticket","TicketCategorie","TicketStati","TicketMessaggi","Knowledgebase","KnowledgebaseCategorie","Aste","AsteCategorie","AsteCauzioni","AsteCommissioni","AsteCommissioniDefault","AsteEsperimentiEsiti","AsteNatura","AsteProxyBid","AsteRitiri","AsteTipo","AsteVendita","AnnunciOfferte","Attivita","AttivitaSettore","AttivitaStati","AttivitaTipo","PreventiviAuto","PreventiviAutoProdotti","PreventiviAutoStati","Prodotti","ProdottiCategorie","ProdottiApplicazioni","ProdottiApplicazioniCategorie","ProdottiColore","ProdottiGruppi","ProdottiMateriale","ProdottiMontaggio","ProdottiTag","ProdottiTipo","ProdottiVisibilita","Produttori","Servizi","ServiziCategorie","Opportunita","OpportunitaSorgenti","OpportunitaStati","LeadTipo","LeadStato","LeadSorgenti","LeadSedi","LeadFormulaAcquisto","Lead","LeadTag","LeadCategorie","CMSAds","CMSAdsStatistiche","CMSAdsZone","CMSBlocchi","CMSCategorie","CMSContenuti","CMSContenutiTipo","CMSGallerie","CMSLink","CMSSlide","CMSTags","Faq","FaqCategorie","Files","FilesTipo","Documenti","DocumentiCorpo","DocumentiStato","DocumentiTipo"};

    public static string Documenti_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string Documenti_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }

    public static string DocumentiCorpo_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string DocumentiCorpo_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }

    public static string DocumentiStato_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string DocumentiStato_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }

    public static string DocumentiTipo_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string DocumentiTipo_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }
    

    public static string getStato (string strDocumentiStato_Ky, string strDocumentiStato_Descrizione) {
        string strStatoOut = "";
        if (strDocumentiStato_Ky != null) {
            switch (strDocumentiStato_Ky) {
                case "1":
                    strStatoOut = "<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
                    break;
                case "2":
                    strStatoOut = "<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
                    break;
                case "3":
                    strStatoOut = "<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
                    break;
                case "4":
                    strStatoOut = "<span class=\"label radius alert\">" + strDocumentiStato_Descrizione + "</span>";
                    break;
                case "5":
                    strStatoOut = "<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
                    break;
                case "6":
                    strStatoOut = "<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
                    break;
                case "7":
                    strStatoOut = "<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
                    break;
                case "8":
                    strStatoOut = "<span class=\"label radius alert\">" + strDocumentiStato_Descrizione + "</span>";
                    break;
            }
        } else {
            strStatoOut = "";
        }
        return strStatoOut;
    }
    
    

  }

}
