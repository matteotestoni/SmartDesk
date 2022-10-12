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
            strH1="Commerciale > Prospetto lead per marca veicoli";
			      strAnno=Request["anno"];
			      strMese=Request["mese"];
            dtProspettoLead = new DataTable("Lead_Prospetto_VeicoliMarca_Vw");
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
            //Response.Write(strReportdatarangestart);
            //Response.Write(strReportdatarangeend);

            
            if (strAnno==null || strAnno==""){
              strAnno=intYear.ToString();
            }
            if (strMese==null || strMese==""){
              strMese=intMonth.ToString();
            }

            conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
            conn.Open();
            // HAVING (YEAR(dbo.Lead.Lead_Data) = " + strAnno + ") AND (MONTH(dbo.Lead.Lead_Data) = " + strMese + ") 
            strSQL="SELECT VeicoliMarca.VeicoliMarca_Ky, VeicoliMarca.VeicoliMarca_Titolo, COUNT(Lead.Lead_Ky) AS conteggio FROM Lead INNER JOIN VeicoliMarca ON Lead.VeicoliMarca_Ky = VeicoliMarca.VeicoliMarca_Ky";
            strSQL+=" WHERE (Lead.Lead_Data >= CONVERT(DATETIME, '" + strReportdatarangestart + "', 102)) AND (Lead.Lead_Data <= CONVERT(DATETIME, '" + strReportdatarangeend + "', 102))";
            strSQL+="  GROUP BY VeicoliMarca.VeicoliMarca_Ky, VeicoliMarca.VeicoliMarca_Titolo";
            strSQL+=" ORDER BY VeicoliMarca_Titolo";
            //Response.Write(strSQL);
            //strSQL="SELECT * FROM Lead_Prospetto_VeicoliMarca_Vw WHERE VeicoliMarca_Ky Is Not Null AND Anno=" + strAnno + " AND mese=" + strMese + " ORDER BY Anno, Mese, VeicoliMarca_Titolo";
            cmd = new SqlCommand(strSQL, conn);
            dtProspettoLead.Load(cmd.ExecuteReader());


            //strWHERENet="VeicoliMarca_Ky Is Not Null AND Anno=" + strAnno + " AND mese=" + strMese;
	          //strFROMNet = "Lead_Prospetto_VeicoliMarca_Vw";
            //strORDERNet = "Anno, Mese, VeicoliMarca_Titolo";
            //dtProspettoLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);         
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
