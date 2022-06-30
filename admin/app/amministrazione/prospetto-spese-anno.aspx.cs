using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtProspettoSpese;
    public DataTable dtProspettoSpeseCentridiCR;
    public DataTable dtCentridiCRCiclo;
    public DataTable dtCentridiCR;
    public DataTable dtCentridiCRFigli;
    public string strH1 = "";
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public string strAnno="";
    public int intAnnoCorrente=0;
    public int intAnnoPrecedente=0;
    
	  public decimal decTot;
    public decimal decTotIVA;
    public decimal decTotRighe;
    public decimal decTotTemp;
    public decimal decTotCol1;
    public decimal decTotCol2;
    public decimal decTotCol3;
    public decimal decTotCol4;
    public decimal decTotCol5;
    public decimal decTotCol6;
    public decimal decTotCol7;
    public decimal decTotCol8;
    public decimal decTotCol9;
    public decimal decTotCol10;
    public decimal decTotCol11;
    public decimal decTotCol12;
	  public decimal decTotAnnoPrecedente;
    public decimal decTotIVAAnnoPrecedente;
    public decimal decTotRigheAnnoPrecedente;
    public decimal decTotTempAnnoPrecedente;
    public decimal decTotCol1AnnoPrecedente;
    public decimal decTotCol2AnnoPrecedente;
    public decimal decTotCol3AnnoPrecedente;
    public decimal decTotCol4AnnoPrecedente;
    public decimal decTotCol5AnnoPrecedente;
    public decimal decTotCol6AnnoPrecedente;
    public decimal decTotCol7AnnoPrecedente;
    public decimal decTotCol8AnnoPrecedente;
    public decimal decTotCol9AnnoPrecedente;
    public decimal decTotCol10AnnoPrecedente;
    public decimal decTotCol11AnnoPrecedente;
    public decimal decTotCol12AnnoPrecedente;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string[,] arrayspese;
    public string[,] arrayspeseannoprecedente;

    protected void Page_Load(object sender, EventArgs e)
    {

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());         
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strH1="Prospetto spese";
          dt=DateTime.Now;
          intYear=dt.Year;
          intMonth=dt.Month;
    			strAnno=Request["anno"];
    			if (strAnno==null || strAnno==""){
    				strAnno=intYear.ToString();
            intAnnoCorrente=intYear;
            intAnnoPrecedente=intAnnoCorrente-1;
    			}else{
            intAnnoCorrente=Convert.ToInt32(strAnno);
            intAnnoPrecedente=intAnnoCorrente-1;
          }

          strWHERENet="Anno=" + intAnnoCorrente;
		      strFROMNet = "Spese_Prospetto_Vw";
          strORDERNet = "Anno, Mese";
          dtProspettoSpese = new DataTable("ProspettoSpese");
          dtProspettoSpese = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
          
		      strWHERENet="CentridiCR_Attivo=1";
          strFROMNet = "CentridiCR";
          strORDERNet = "CentridiCR_Ky";
          dtCentridiCRCiclo = new DataTable("CentridiCRCiclo");
          dtCentridiCRCiclo = Smartdesk.Sql.getTablePage(strFROMNet, null, "CentridiCR_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
          
		      strWHERENet="(CentridiCR_Padre Is Null OR CentridiCR_Padre=0) AND CentridiCR_Attivo=1";
          strFROMNet = "CentridiCR";
          strORDERNet = "CentridiCR_Padre, CentridiCR_Titolo";
          dtCentridiCR = new DataTable("CentridiCR");
          dtCentridiCR = Smartdesk.Sql.getTablePage(strFROMNet, null, "CentridiCR_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
    			arrayspese = new string[1000,1000];            
    
    			strWHERENet="Anno=" + intAnnoCorrente;
          strFROMNet = "Spese_Prospetto_CentridiCR_Vw";
          strORDERNet = "CentridiCR_Titolo, Mese";
          dtProspettoSpeseCentridiCR = new DataTable("ProspettoSpeseCentridiCR");
          dtProspettoSpeseCentridiCR = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         

          for (int i = 0; i < dtProspettoSpeseCentridiCR.Rows.Count; i++){
            arrayspese[(int)(dtProspettoSpeseCentridiCR.Rows[i]["CentridiCR_Ky"]),0]="<a href=\"/admin/app/amministrazione/elenco-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreGrids_Ky=1&CentridiCR_Ky=" + (dtProspettoSpeseCentridiCR.Rows[i]["CentridiCR_Ky"]).ToString() + "&anno=" + intAnnoCorrente + "\">" + (dtProspettoSpeseCentridiCR.Rows[i]["CentridiCR_Titolo"]).ToString() + "</a>";
            arrayspese[(int)(dtProspettoSpeseCentridiCR.Rows[i]["CentridiCR_Ky"]),(int)(dtProspettoSpeseCentridiCR.Rows[i]["Mese"])]=(dtProspettoSpeseCentridiCR.Rows[i]["Spese_Totale"]).ToString();
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public String GetValoreGrafico(string strValore){
    string strReturn;
			if (strValore==null){
				strReturn="0";
			}else{
				strReturn=strValore.Replace(",",".");
			}
			return strReturn;
			
    }

    public String GetValore(string strValore){
    string strReturn;
			if (strValore==null){
				strReturn="0";
			}else{
				strReturn=strValore;
			}
			return strReturn;
			
    }
    
		public String GetDifferenza(string strValore){
    string strReturn;
			if (strValore==null){
				strReturn="0";
			}else{
				if (Convert.ToDouble(strValore)<0){
					strReturn="<font color=red><strong>" + strValore + "</strong></font>";
				}else{
					strReturn="<font color=green><strong>" + strValore + "</strong></font>";
				}
			}
			return strReturn;
			
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
