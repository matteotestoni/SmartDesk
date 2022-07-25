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
    public DataTable dtProspettoLead;
    public string strH1 = "";
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public string strAnno="";
    public string strMese="";
    
    public int intTotLead=0;
    public string strVeicoliMarca_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strSQL = "";
      SqlConnection conn;
      SqlCommand cmd;
      
      string strReportdatarangestart = "";
      string strReportdatarangeend = "";
	  
      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            dtProspettoLead = new DataTable("Lead_Prospetto_VeicoliModello_Vw");
			      strAnno=Request["anno"];
			      strMese=Request["mese"];
			      strVeicoliMarca_Ky=Request["VeicoliMarca_Ky"];
            dt=DateTime.Now;
            intYear=dt.Year;
            intMonth=dt.Month;
            if (strAnno==null || strAnno==""){
              strAnno=intYear.ToString();
            }
            if (strMese==null || strMese==""){
              strMese=intMonth.ToString();
            }
            if (Request.Cookies["reportdatarangestart"]!=null){
              strReportdatarangestart=Request.Cookies["reportdatarangestart"].Value;
            }
            if (Request.Cookies["reportdatarangeend"]!=null){
              strReportdatarangeend=Request.Cookies["reportdatarangeend"].Value;
            }
            if (strReportdatarangestart==null || strReportdatarangestart==""){
              strReportdatarangestart=new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("MM-dd-yyyy");
            }
            if (strReportdatarangeend==null || strReportdatarangeend==""){
              strReportdatarangeend=DateTime.Now.ToString("MM-dd-yyyy");
            }
            strH1="Commerciale > Prospetto lead per modello";


            conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
            conn.Open();
            strSQL="SELECT COUNT(Lead.Lead_Ky) AS conteggio, Lead.LeadCategorie_Ky, LeadCategorie.LeadCategorie_Titolo, VeicoliModello.VeicoliModello_Ky, VeicoliModello.VeicoliModello_Titolo, VeicoliMarca.VeicoliMarca_Ky, VeicoliMarca.VeicoliMarca_Titolo";
            strSQL+=" FROM Lead LEFT OUTER JOIN VeicoliMarca ON Lead.VeicoliMarca_Ky = VeicoliMarca.VeicoliMarca_Ky LEFT OUTER JOIN VeicoliModello ON Lead.VeicoliModello_Ky = VeicoliModello.VeicoliModello_Ky LEFT OUTER JOIN LeadCategorie ON Lead.LeadCategorie_Ky = LeadCategorie.LeadCategorie_Ky";
            strSQL+=" WHERE (Lead.Lead_Data >= CONVERT(DATETIME, '" + strReportdatarangestart + "', 102)) AND (Lead.Lead_Data <= CONVERT(DATETIME, '" + strReportdatarangeend + "', 102))";
            if (strVeicoliMarca_Ky!=null && strVeicoliMarca_Ky.Length>0){
              strSQL+=" AND (Lead.VeicoliMarca_Ky=" + strVeicoliMarca_Ky + ")";
            }
            strSQL+=" GROUP BY Lead.LeadCategorie_Ky, LeadCategorie.LeadCategorie_Titolo, VeicoliMarca.VeicoliMarca_Ky, VeicoliMarca.VeicoliMarca_Titolo, VeicoliModello.VeicoliModello_Ky, VeicoliModello.VeicoliModello_Titolo";
            strSQL+=" ORDER BY VeicoliMarca_Titolo, VeicoliModello_Titolo";
            //Response.Write(strSQL);
            cmd = new SqlCommand(strSQL, conn);
            dtProspettoLead.Load(cmd.ExecuteReader());
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
