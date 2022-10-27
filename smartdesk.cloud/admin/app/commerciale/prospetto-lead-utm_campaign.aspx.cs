using System;
using System.Data;
using System.Data.SqlClient;

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
    public string strUtm_campaign="";
    public string strReportdatarangestart = "";
    public string strReportdatarangeend = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strSQL = "";
      SqlConnection conn;
      SqlCommand cmd;
      
	  
      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
			      strAnno=Request["anno"];
			      strMese=Request["mese"];
			      strUtm_campaign=Request["utm_campaign"];
            strH1="Commerciale > Prospetto lead per utm_campaign";
            dtProspettoLead = new DataTable("Lead_Prospetto_utm_campaign_Vw");
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

            conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
            conn.Open();
            strSQL="SELECT MAX(Lead.Lead_Ky) AS Lead_Ky, COUNT(Lead.Lead_Ky) AS conteggio, Lead.LeadCategorie_Ky, LeadCategorie.LeadCategorie_Titolo, Lead.utm_campaign";
            strSQL+=" FROM Lead LEFT OUTER JOIN LeadCategorie ON Lead.LeadCategorie_Ky = LeadCategorie.LeadCategorie_Ky";
            strSQL+=" WHERE " + getWhere();
            strSQL+=" GROUP BY Lead.LeadCategorie_Ky,LeadCategorie.LeadCategorie_Titolo, Lead.utm_campaign";
            
            //Response.Write(strSQL);
            cmd = new SqlCommand(strSQL, conn);
            dtProspettoLead.Load(cmd.ExecuteReader());
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public String getWhere(){
    string strReturn="";      
			strReturn="(Lead.Lead_Data >= CONVERT(DATETIME, '" + strReportdatarangestart + "', 102)) AND (Lead.Lead_Data <= CONVERT(DATETIME, '" + strReportdatarangeend + "', 102))";
      
      if (strUtm_campaign!=null && strUtm_campaign!="" && strUtm_campaign.Length>0){
        if (strReturn.Length<1){
          strReturn="utm_campaign='" + strUtm_campaign + "'";
        }else{
          strReturn+=" AND utm_campaign='" + strUtm_campaign + "'";
        }
      }
			return strReturn;
			
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
        strReturn = "0";
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
