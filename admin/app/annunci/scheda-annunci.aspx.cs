using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public string strSorgente = "";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtAste;
    public DataTable dtAnnunci;
    public DataTable dtAnnunciOfferte;
    public DataTable dtFiles;
    public string strH1 = "Scheda annuncio";
    public string strAzione = "";
    public string strAste_Ky = "";
    public DataTable dtAnnunciModello;
    public DataTable dtComuni;
    public DataTable dtAnnunciCategorie;
    public DataTable dtAttributi;
    public DataTable dtAttributiOpzioni;
    public string strProvince_Ky = "";
    public string strAnnunciMarca_Ky = "";
    public string strFROMNet = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
    public int intNumeroFoto = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            strAste_Ky=Smartdesk.Current.Request("Aste_Ky");
            strSorgente = Smartdesk.Current.Request("sorgente");
            if (strAzione!="new"){
            	strAzione = "modifica";
                strWHERENet = "Annunci_Ky=" + Request["Annunci_Ky"];
                strORDERNet = "Annunci_Ky";
                strFROMNet = "Annunci_Vw";
                dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            	//dtAnnunci = Smartdesk.Data.Read("Annunci_Vw", "Annunci_Ky",Smartdesk.Current.QueryString("Annunci_Ky"));
                dtAnnunciOfferte = Smartdesk.Data.Read("AnnunciOfferte_Vw", "Annunci_Ky", Smartdesk.Current.QueryString("Annunci_Ky"));
            	strAste_Ky = GetFieldValue(dtAnnunci, "Aste_Ky");
            	strProvince_Ky = GetFieldValue(dtAnnunci, "Province_Ky");
            	strAnnunciMarca_Ky = GetFieldValue(dtAnnunci, "AnnunciMarca_Ky");
              if (strAnnunciMarca_Ky!=null && strAnnunciMarca_Ky.Length>0){
                strWHERENet = "AnnunciMarca_Ky=" + strAnnunciMarca_Ky;
                strORDERNet = "AnnunciModello_Titolo";
                strFROMNet = "AnnunciModello";
                dtAnnunciModello = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciModello_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              }
              strWHERENet = "Chiave_Tabella='Annunci' AND Chiave_Ky=" + Smartdesk.Current.QueryString("Annunci_Ky");
              strORDERNet = "Files_Ky";
              strFROMNet = "Files_Vw";
              dtFiles = Smartdesk.Sql.getTablePage(strFROMNet, null, "Files_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              
              //attributi in base alla categoria
              if (GetFieldValue(dtAnnunci, "AnnunciCategorie_Ky").Length>0){
                strWHERENet = "AnnunciCategorie_Ky=" + GetFieldValue(dtAnnunci, "AnnunciCategorie_Ky");
                strORDERNet = "AnnunciCategorie_Ky";
                strFROMNet = "AnnunciCategorie_Vw";
                dtAnnunciCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciCategorie_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtAnnunciCategorie!=null && dtAnnunciCategorie.Rows.Count>0){
					if (GetFieldValue(dtAnnunciCategorie, "AnnunciCategorie_Attributi").Length>0){
	                    strWHERENet = "(Attributi_Annunci=1 AND Attributi_Ky IN (" + GetFieldValue(dtAnnunciCategorie, "AnnunciCategorie_Attributi") + "))";
	                }else{
	                    strWHERENet = "(Attributi_Annunci=1)";
	                }
	                strORDERNet = "Attributi_Ky";
	                strFROMNet = "Attributi_Vw";
	                dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              	}
			  }

        	}else{
              strWHERENet = "Attributi_Annunci=1";
              strORDERNet = "Attributi_Ky";
              strFROMNet = "Attributi_Vw";
              dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }
            if (strAste_Ky!=null && strAste_Ky.Length>0){
              strWHERENet = "Aste_Ky=" + strAste_Ky;
              strORDERNet = "Aste_Ky";
              strFROMNet = "Aste_Vw";
              dtAste = Smartdesk.Sql.getTablePage(strFROMNet, null, "Aste_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }


    public String GetDefaultValue(string strField)
    {
        string strValore = "";
        switch (strField)
        {
            case "Aste_Ky":
                strValore = strAste_Ky;
                break;
            case "AnnunciStato_Ky":
                strValore = "2";
                break;
            case "AnnunciTipo_Ky":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = "2";
                }else{
                    strValore = "1";
                }
                break;
            case "Anagrafiche_Ky":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Anagrafiche_Ky"].ToString();
                }else{
                    strValore = "";
                }
                break;
            case "Anagrafiche_RagioneSociale":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Anagrafiche_RagioneSociale"].ToString();
                }else{
                    strValore = "";
                }
                break;
            case "Nazioni_Ky":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Nazioni_Ky"].ToString();
                }else{
                    strValore = "105";
                }
                break;
            case "Regioni_Ky":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Regioni_Ky"].ToString();
                }else{
                    strValore = "";
                }
                break;
            case "Province_Ky":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Province_Ky"].ToString();
                }else{
                    strValore = "";
                }
                break;
            case "Comuni_Ky":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Comuni_Ky"].ToString();
                }else{
                    strValore = "";
                }
                break;
            case "Annunci_Cauzione":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Aste_Cauzione"].ToString();
                }else{
                    strValore = "0";
                }
                break;
            case "Annunci_Rilancio":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Aste_Rilancio"].ToString();
                }else{
                    strValore = "0";
                }
                break;
            case "Annunci_Descrizione":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Aste_Descrizione"].ToString();
                }else{
                    strValore = "0";
                }
                break;
            case "Annunci_Titolo":
                if (dtAste!=null && dtAste.Rows.Count>0){
                    strValore = dtAste.Rows[0]["Aste_Titolo"].ToString();
                }else{
                    strValore = "";
                }
                break;
        }
        return strValore;
    }

    public String GetAttributoValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        try{
			if (dtAnnunci!=null && dtAnnunci.Rows.Count>0){
			  strValore=dtAnnunci.Rows[0][strField].ToString();
			}else{
			  strValore="";
			}
        }catch{
        	strValore="";
				}
      }
      return strValore;
    }


    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore= GetDefaultValue(strField);
        }
        else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;

    }
    
    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
        Boolean boolValore = false;
        if (strAzione == "new")
        {
            boolValore = false;
        }
        else
        {
            boolValore = Smartdesk.Data.FieldBool(dtTabella,strField);
        }
        return boolValore;
    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
