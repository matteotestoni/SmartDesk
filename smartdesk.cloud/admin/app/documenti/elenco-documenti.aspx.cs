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
    public DataTable dtDocumenti;
    public DataTable dtDocumentiTipo;
    public int intDocumenti_Ky = 0;
    public string strH1 = "";
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public int intAnno = 0;
    public int intMese = 0;
    public decimal decTotMese=0; 
    public decimal decTotIVAMese=0; 
    public decimal decTotServiziMese=0; 
    public decimal decTot=0; 
    public decimal decTotServizi=0; 
    public decimal decTotIVA=0; 
    
    public int intRecxPag = 50;
    public int intPage = 0;
    public string strWHERENet="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";
      int intPage = 0;

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            checkPermessi();
			       strPage = Request["page"];
            if ((strPage == null) || (strPage == "")){
              intPage = 1;
            }
            else{
              intPage = Convert.ToInt32(strPage);
            }
            dt=DateTime.Now;
            intYear=dt.Year;
            intMonth=dt.Month;

            strWHERENet="";
            strFROMNet = "DocumentiTipo";
            strORDERNet = "DocumentiTipo_Ordine";
            dtDocumentiTipo = new DataTable("DocumentiTipo");
            dtDocumentiTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "DocumentiTipo_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

            strWHERENet=getWhere();
            //Response.Write(strWHERENet);
            strFROMNet = "Documenti_Vw";
            strORDERNet = "Documenti_Anno DESC, MONTH(Documenti_Data) DESC, Aziende_Ky,Documenti_Numero DESC";
            dtDocumenti = new DataTable("Documenti");
            dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
						if (dtDocumenti.Rows.Count==1){
							//Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=" + dtDocumenti.Rows[0]["Documenti_Ky"].ToString());
							this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtDocumenti,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
						}else{
							this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtDocumenti,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
						}            
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public bool checkPermessi(){
	  bool boolReturn=false;
      if (dtLogin.Rows[0]["UtentiGruppi_Fatture"].Equals(true)){
	    boolReturn=true;
	  }else{
	  	boolReturn=false;
	  	Response.Redirect("/admin/403.aspx");
	  }
	  return boolReturn;
	}

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="";
        strH1="Documenti:";

        strValue = Smartdesk.Current.Request("Aziende_Ky");
        if (strValue != null && strValue != ""){
            strWHERE = "(Aziende_Ky=" + strValue + ")";
            strH1="Documenti: per azienda " + strValue;
        }


        strValue = Request["DocumentiTipo_Ky"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
            	strWHERE += " And (DocumentiTipo_Ky in (" + strValue + "))";
						}else{
            	strWHERE = "(DocumentiTipo_Ky in (" + strValue + "))";
						}

            strH1="Documenti: per tipo documento " + strValue;
        }
        strValue = Request["Aziende_Ky"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
            	strWHERE += " And (Aziende_Ky in (" + strValue + "))";
						}else{
            	strWHERE = "(Aziende_Ky in (" + strValue + "))";
						}

            strH1="Documenti: per azienda " + strValue;
        }
        strValue = Request["Anagrafiche_RagioneSociale"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
							strWHERE += " And (Anagrafiche_RagioneSociale like '%" + strValue + "%')";
						}else{
							strWHERE += "(Anagrafiche_RagioneSociale like '%" + strValue + "%')";
						}
            strH1="Documenti: per ragione sociale" + strValue;
        }

 
        strValue = Request["anno"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
							strWHERE += " And (Year(Documenti_Data)=" + strValue + ")";
						}else{
							strWHERE += "(Year(Documenti_Data)=" + strValue + ")";
						}
            strH1="Documenti: per anno " + strValue;
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "";
            strH1="Documenti: tutto";
        }
        return strWHERE;
    }

    public String getStato(string strDocumentiStato_Ky, string strDocumentiStato_Descrizione)
    {
      string strStatoOut="";
      if (strDocumentiStato_Ky!=null){
        switch (strDocumentiStato_Ky){
          case "1":
            strStatoOut="<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "2":
            strStatoOut="<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "3":
            strStatoOut="<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "4":
            strStatoOut="<span class=\"label radius alert\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "5":
            strStatoOut="<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "6":
            strStatoOut="<span class=\"label radius success\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "7":
            strStatoOut="<span class=\"label radius warning\">" + strDocumentiStato_Descrizione + "</span>";
            break;
          case "8":
            strStatoOut="<span class=\"label radius alert\">" + strDocumentiStato_Descrizione + "</span>";
            break;
        }
      }else{
        strStatoOut="";
      }
      return strStatoOut;
    }   

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
