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
    public DataTable dtLead;
    public DataTable dtUtenti;
    public int intLead_Ky = 0;
    public string strH1 = "Assegna Lead";
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public int intAnno = 0;
    public int intMese = 0;
    
    public int intRecxPag = 100;
    public int intPage = 0;
    public string strWHERENet="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strORDERNet = "";
      string strFROMNet = "";
      string strPage="";
      int intPage = 0;

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
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

            strWHERENet="Utenti_Attivo=1 AND UtentiGruppi_Lead=1 AND Utenti_Admin=0";
            strFROMNet = "Utenti_Vw";
            strORDERNet = "Utenti_Nominativo";
            dtUtenti = new DataTable("Utenti");
            dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

            strWHERENet="Utenti_Ky Is Null Or Utenti_Ky=0";
            //Response.Write(strWHERENet);
            strFROMNet = "Lead_Vw";
            strORDERNet = "Lead_Ky DESC";
            dtLead = new DataTable("Documenti");
            dtLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
			if (dtLead.Rows.Count==1){
				this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtLead,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
			}else{
				this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtLead,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
			}            
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public bool checkPermessi(){
	  bool boolReturn=false;
      if (dtLogin.Rows[0]["UtentiGruppi_Lead"].Equals(true)){
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
        strH1="Assegna lead";

        strValue = Smartdesk.Current.Request("Aziende_Ky");
        if (strValue != null && strValue != ""){
            strWHERE = "(Aziende_Ky=" + strValue + ")";
        }

        if (strWHERE.Length>0){
        	strWHERE += " And (DocumentiTipo_Ky=4)";
				}else{
        	strWHERE = "(DocumentiTipo_Ky=4)";
				}

        strValue = Request["Aziende_Ky"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
            	strWHERE += " And (Aziende_Ky in (" + strValue + "))";
						}else{
            	strWHERE = "(Aziende_Ky in (" + strValue + "))";
						}
        }
        strValue = Request["Anagrafiche_RagioneSociale"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
							strWHERE += " And (Anagrafiche_RagioneSociale like '%" + strValue + "%')";
						}else{
							strWHERE += "(Anagrafiche_RagioneSociale like '%" + strValue + "%')";
						}
        }

 
        strValue = Request["anno"];
        if (strValue != null && strValue != ""){
            if (strWHERE.Length>0){
							strWHERE += " And (Year(Lead_Data)=" + strValue + ")";
						}else{
							strWHERE += "(Year(Lead_Data)=" + strValue + ")";
						}
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
            strWHERE = "";
        }
        return strWHERE;
    }

    public String getStato(string strLeadStato_Ky, string strLeadStato_Titolo, string strLeadStato_Icona)
    {
      string strStatoOut="";
      if (strLeadStato_Ky!=null){
        switch (strLeadStato_Ky){
          case "1":
            strStatoOut="<span class=\"label radius\" style=\"background-color:#35602f\"><i class=\"" + strLeadStato_Icona + " fa-fw\"></i>" + strLeadStato_Titolo + "</span>";
            break;
          case "2":
            strStatoOut="<span class=\"label radius\" style=\"background-color:#000000\"><i class=\"" + strLeadStato_Icona + " fa-fw\"></i>" + strLeadStato_Titolo + "</span>";
            break;
          case "3":
            strStatoOut="<span class=\"label radius\" style=\"background-color:#e6931e\"><i class=\"" + strLeadStato_Icona + " fa-fw\"></i>" + strLeadStato_Titolo + "</span>";
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
