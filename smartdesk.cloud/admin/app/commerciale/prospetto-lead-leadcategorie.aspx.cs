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
    public DataTable dtLeadCategorie;
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
    protected void Page_Load(object sender, EventArgs e)
    {

      string strSQL = "";
      SqlConnection conn;
      SqlCommand cmd;
      
      string strReportdatarangestart = "";
      string strReportdatarangeend = "";
	  
      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strH1="Commerciale > Prospetto lead per categoria";
			      strAnno=Request["anno"];
			      strMese=Request["mese"];
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
            
            
            strWHERENet="";
	          strFROMNet = "LeadCategorie";
            strORDERNet = "LeadCategorie_Ordine";
            dtLeadCategorie = new DataTable("LeadCategorie");
            dtLeadCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadCategorie_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         

            strWHERENet="Anno=" + strAnno + " AND mese=" + strMese;
	          strFROMNet = "Lead_Prospetto_LeadCategorie_Vw";
            strORDERNet = "Anno, Mese, LeadCategorie_Titolo";
            dtProspettoLead = new DataTable("Lead_Prospetto_Campagne_Vw");
            dtProspettoLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
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
