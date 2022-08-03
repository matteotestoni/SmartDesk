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
    public DataTable dtLeadSorgenti;
    public DataTable dtConteggioLead;
    public string strH1 = "";
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public string strAnno="";
    public string strMese="";
    public int intGiorni=0;
    
    public int intTotLead=0;
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public DateTime currentDate;
    public string strReportdatarangestart = "";
    public string strReportdatarangeend = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {

      string strSQL = "";
      SqlConnection conn;
      SqlCommand cmd;
      
	  
      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            dtLeadSorgenti = new DataTable("LeadSorgenti");
            dtProspettoLead = new DataTable("Lead_Prospetto_Campagne_Vw");
            strH1="Commerciale > Prospetto lead per sorgenti";
			      strAnno=Request["anno"];
			      strMese=Request["mese"];
            if (Request.Cookies["reportdatarangestart"]!=null && Request.Cookies["reportdatarangestart"].ToString()!=""){
              strReportdatarangestart=Request.Cookies["reportdatarangestart"].Value;
            }
            if (Request.Cookies["reportdatarangeend"]!=null && Request.Cookies["reportdatarangeend"].ToString()!=""){
              strReportdatarangeend=Request.Cookies["reportdatarangeend"].Value;
            }
            if (strReportdatarangestart==null || strReportdatarangestart==""){
              strReportdatarangestart=new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("MM-dd-yyyy");
            }
            if (strReportdatarangeend==null || strReportdatarangeend==""){
              strReportdatarangeend=DateTime.Now.ToString("MM-dd-yyyy");
            }
            dt=DateTime.Now;
            intYear=dt.Year;
            intMonth=dt.Month;

            if (strAnno==null || strAnno==""){
              strAnno=intYear.ToString();
            }
            if (strMese==null || strMese==""){
              strMese=intMonth.ToString();
            }
            intGiorni=DateTime.DaysInMonth(Convert.ToInt32(strAnno),Convert.ToInt32(strMese) );
            //Response.Write(strReportdatarangeend);
            //Response.Write(Convert.ToDateTime(strReportdatarangeend,cien).ToString() );
            intGiorni=Convert.ToInt32((Convert.ToDateTime(strReportdatarangeend,cien) - Convert.ToDateTime(strReportdatarangestart,cien)).TotalDays);

            conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
            conn.Open();
            strSQL="SELECT COUNT(Lead.Lead_Ky) AS conteggio, Lead.LeadSorgenti_Ky, LeadSorgenti.LeadSorgenti_Titolo";
            strSQL+=" FROM  Lead INNER JOIN LeadSorgenti ON Lead.LeadSorgenti_Ky = LeadSorgenti.LeadSorgenti_Ky";
            strSQL+=" WHERE (Lead.Lead_Data >= CONVERT(DATETIME, '" + strReportdatarangestart + "', 102)) AND (Lead.Lead_Data <= CONVERT(DATETIME, '" + strReportdatarangeend + "', 102))";
            strSQL+=" GROUP BY Lead.LeadSorgenti_Ky, LeadSorgenti.LeadSorgenti_Titolo";
            strSQL+=" ORDER BY LeadSorgenti.LeadSorgenti_Titolo";
            //Response.Write(strSQL);
            cmd = new SqlCommand(strSQL, conn);
            dtProspettoLead.Load(cmd.ExecuteReader());
            strWHERENet="";
	          strFROMNet = "LeadSorgenti";
            strORDERNet = "LeadSorgenti_Ordine";
            dtLeadSorgenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadSorgenti_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         

            /*
            strWHERENet="Anno=" + strAnno + " AND mese=" + strMese;
	          strFROMNet = "Lead_Prospetto_LeadSorgenti_Vw";
            strORDERNet = "Anno, Mese, LeadSorgenti_Titolo";
            dtProspettoLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords); */        
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
}
