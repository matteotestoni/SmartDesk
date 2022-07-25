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
    public string strUtm_source="";
    public string strUtm_medium="";
    public string strUtm_campaign="";

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
            dtProspettoLead = new DataTable("Lead_Prospetto_utmmedium_utmcampaign_Vw");
            strH1="Commerciale > Prospetto lead per utm_medium utm_campaign";
			      strUtm_source=Request["utm_source"];
			      strUtm_medium=Request["utm_medium"];
			      strUtm_campaign=Request["utm_campaign"];
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

            conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
            conn.Open();
            strSQL="SELECT MAX(Lead_Ky) AS Lead_Ky, COUNT(Lead_Ky) AS conteggio, utm_medium, utm_campaign, utm_source";
            strSQL+=" FROM Lead";
            strSQL+=" WHERE (" + getWhere() + " AND Lead.Lead_Data >= CONVERT(DATETIME, '" + strReportdatarangestart + "', 102)) AND (Lead.Lead_Data <= CONVERT(DATETIME, '" + strReportdatarangeend + "', 102))";
            strSQL+=" GROUP BY utm_medium, utm_campaign, utm_source";
            strSQL+=" ORDER BY Lead.utm_source";
            //Response.Write(strSQL);
            cmd = new SqlCommand(strSQL, conn);
            dtProspettoLead.Load(cmd.ExecuteReader());
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public String getWhere(){
    string strReturn="";
			if (strUtm_source!=null && strUtm_source!="" && strUtm_source.Length>0){
        if (strReturn.Length<1){
          strReturn="Lead.utm_source='" + strUtm_source + "'";
        }else{
          strReturn+=" AND Lead.utm_source='" + strUtm_source + "'";
        }
      }
			if (strUtm_medium!=null && strUtm_medium!="" && strUtm_medium.Length>0){
        if (strReturn.Length<1){
          strReturn="Lead.utm_medium='" + strUtm_medium + "'";
        }else{
          strReturn+=" AND Lead.utm_medium='" + strUtm_medium + "'";
        }
      }
			if (strUtm_campaign!=null && strUtm_campaign!="" && strUtm_campaign.Length>0){
        if (strReturn.Length<1){
          strReturn="Lead.utm_campaign='" + strUtm_campaign + "'";
        }else{
          strReturn+=" AND Lead.utm_campaign='" + strUtm_campaign + "'";
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
