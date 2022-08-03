using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;


public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public bool boolWysiwyg = false;
    public DataTable dtDocumenti;
    public DataTable dtDocumentiCorpo;
    public DataTable dtDocumentiCorpoAttributi;
    public DataTable dtPagamenti;
    public DataTable dtCommesse;
    public DataTable dtProdotti;
    public DataTable dtServizi;
    public string strAnagrafiche_Ky = "";
    public string strDocumenti_Ky = "";
    public string strProdotti_Ky = "";
    public string strServizi_Ky = "";
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "modifica";
    public string strSorgente = "documento";
    public string strTipo = "1";
    
    public DataTable dtAttributi;
    public DataTable dtAttributiGruppi;
    public DataTable dtAttributiOpzioni;
    public string strORDERNet = "";
   	public string strWHERENet="";
    public string strDescrizione = "";
    public string strTitolo = "";
    public string strPrezzo = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            boolWysiwyg=(dtLogin.Rows[0]["Utenti_Wysiwyg"]).Equals(true);
            strAzione = Request["azione"];
            strSorgente=Smartdesk.Current.Request("sorgente");
            strDocumenti_Ky=Smartdesk.Current.Request("Documenti_Ky");
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            strProdotti_Ky=Smartdesk.Current.Request("Prodotti_Ky");
            strServizi_Ky=Request["Servizi_Ky"];
            strTipo=Request["tipo"];
            if (strAzione!="new"){
              strAzione = "modifica";
    	  	  dtDocumentiCorpo = Smartdesk.Data.Read("DocumentiCorpo_Vw", "DocumentiCorpo_Ky",Smartdesk.Current.QueryString("DocumentiCorpo_Ky"));

              strWHERENet="DocumentiCorpo_Ky=" + Smartdesk.Current.Request("DocumentiCorpo_Ky");
              strORDERNet = "DocumentiCorpo_Ky";
              strFROMNet = "DocumentiCorpo";
              dtDocumentiCorpoAttributi = new DataTable("DocumentiCorpoAttributi");
              dtDocumentiCorpoAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "DocumentiCorpo_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							
	            if (GetFieldValue("AttributiGruppi_Ky")!=null && GetFieldValue("AttributiGruppi_Ky").Length>0){
								
								strWHERENet="AttributiGruppi_Ky=" + GetFieldValue("AttributiGruppi_Ky");
		            strORDERNet = "AttributiGruppi_Ky";
		            strFROMNet = "AttributiGruppi";
		            dtAttributiGruppi = new DataTable("AttributiGruppi");
		            dtAttributiGruppi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiGruppi_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

								strWHERENet="Attributi_Ky in (" + dtAttributiGruppi.Rows[0]["AttributiGruppi_Attributi"].ToString() + ")";
		            strORDERNet = "Attributi_Ky";
		            strFROMNet = "Attributi_Vw";
		            dtAttributi = new DataTable("Attributi");
		            dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

					      dtAttributiOpzioni = new DataTable("AttributiOpzioni");
	            }
							strTipo="1";
              if (dtDocumentiCorpo.Rows[0]["Prodotti_Ky"].ToString().Length>0){
								strTipo="2";
							}
              if (dtDocumentiCorpo.Rows[0]["Servizi_Ky"].ToString().Length>0){
								strTipo="3";
							}
            }else{
							if (strTipo=="2"){
              	if (strProdotti_Ky!=null){
										strWHERENet="Prodotti_Ky=" + strProdotti_Ky;
				            strORDERNet = "Prodotti_Ky";
				            strFROMNet = "Prodotti_Vw";
				            dtProdotti = new DataTable("Prodotti");
				            dtProdotti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				            strDescrizione=dtProdotti.Rows[0]["Prodotti_Descrizione"].ToString();
				            strTitolo=dtProdotti.Rows[0]["Prodotti_Titolo"].ToString();
				            strPrezzo=dtProdotti.Rows[0]["Prodotti_Prezzo"].ToString();
				        }
							}
							if (strTipo=="3"){
               	if (strServizi_Ky!=null){
		             		strWHERENet="Servizi_Ky=" + strServizi_Ky;
				            strORDERNet = "Servizi_Ky";
				            strFROMNet = "Servizi_Vw";
				            dtServizi = new DataTable("Servizi");
				            dtServizi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Servizi_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				            strDescrizione=dtServizi.Rows[0]["Servizi_Descrizione"].ToString();
				            strTitolo=dtServizi.Rows[0]["Servizi_Titolo"].ToString();
				            strPrezzo=dtServizi.Rows[0]["Servizi_Prezzo"].ToString();
				        }
							}

						}
            strWHERENet="Documenti_Ky=" + strDocumenti_Ky;
            strORDERNet = "Documenti_Data DESC";
            strFROMNet = "Documenti_Vw";
            dtDocumenti = new DataTable("Documenti");
            dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);						          
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
				case "Prodotti_Ky":
					strValore=strProdotti_Ky;
					break;
				case "Prodotti_Titolo":
					strValore=strTitolo;
					break;
				case "Servizi_Ky":
					strValore=strServizi_Ky;
					break;
				case "Servizi_Titolo":
					strValore=strTitolo;
					break;
				case "AliquoteIVA_Ky":
					strValore="43";
					break;
				case "AliquoteIVA_Aliquota":
					strValore="22";
					break;
				case "DocumentiCorpo_Qta":
					strValore="1";
					break;
				case "DocumentiCorpo_Titolo":
					strValore=strTitolo;
					break;
				case "DocumentiCorpo_Importo":
					strValore=strPrezzo;
					break;
				case "DocumentiCorpo_Descrizione":
					strValore=strDescrizione;
					break;
				case "DocumentiCorpo_Totale":
					strValore="0";
					break;
				case "DocumentiCorpo_TotaleIVA":
					strValore="0";
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
			if (dtDocumentiCorpoAttributi!=null && dtDocumentiCorpoAttributi.Rows.Count>0){
			  strValore=dtDocumentiCorpoAttributi.Rows[0][strField].ToString();
			}else{
			  strValore="";
			}
        }catch{
        	strValore="";
				}
      }
      return strValore;
    }

    public String GetFieldValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtDocumentiCorpo.Rows[0][strField].ToString();
      }
      return strValore;
    }

    public decimal GetDecimalValue(string strField)
    {
      decimal dclValore=0;
      if (strAzione=="new"){
        dclValore=Convert.ToDecimal(GetDefaultValue(strField));
      }else{
        try{
        	dclValore=(decimal)dtDocumentiCorpo.Rows[0][strField];
        }catch{
        	dclValore=0;
		}
      }
      return dclValore;
    }
    
    public String GetMoneyValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtDocumentiCorpo.Rows[0][strField].ToString();
        strValore=strValore.Replace(",0000","");
      }
      return strValore;
    }
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtDocumentiCorpo.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }
}
