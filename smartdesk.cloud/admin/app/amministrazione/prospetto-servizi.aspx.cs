using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
  public int intNumRecords = 0;
  public int i = 0;
  public int j = 0;
  public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
  public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
  public DataTable dtProspettoServizi;
  public DataTable dtProspetto;
  public DataTable dtProspettoAnni;
  public DataTable dtLogin;
  public int intNumeroMesi=0;
  public int intNumeroAnni=0;
  public int intMeseCorrente=0;
  public int intAnnoCorrente=0;
  public int intAnnoIniziale=0;
  public int intAnnoFinale=0;
  public string[] fatturato1 = new string[15];
  public string[] servizi1 = new string[15];
  public string strH1 = "Prospetto servizi";
  public DateTime dt;
  public int intYear;
  public int intMonth;
  public decimal decTemp;
  public decimal decPrevisionale;
  public string strTemp;
    
	public char[] charsToTrim = {'*', ' '};
	
    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
	  
      if (Smartdesk.Login.Verify){
        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
        strH1="Prospetto fatturato";
        dt=DateTime.Now;
        intYear=dt.Year;
        intMonth=dt.Month;
        strWHERENet="";
        strFROMNet = "AnagraficheServizi_Prospetto_Vw";
        strORDERNet = "AnagraficheServizi_MeseScadenza";
        dtProspettoServizi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_MeseScadenza", strWHERENet, strORDERNet, 1,12,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        decTemp=0;
        decPrevisionale=0;
			  for (int i = 0; i < dtProspettoServizi.Rows.Count; i++){
  			  servizi1[Convert.ToInt32(dtProspettoServizi.Rows[i]["AnagraficheServizi_MeseScadenza"])]=((decimal)dtProspettoServizi.Rows[i]["TotaleDaFatturare"]).ToString("N2", ciit);
  			  decTemp=decTemp+((decimal)dtProspettoServizi.Rows[i]["TotaleDaFatturare"]);
  			  if (Convert.ToInt32(dtProspettoServizi.Rows[i]["AnagraficheServizi_MeseScadenza"])>intMonth){
  			  	decPrevisionale=decPrevisionale+((decimal)dtProspettoServizi.Rows[i]["TotaleDaFatturare"]);	
  			  }
        }
  			servizi1[13]=decTemp.ToString("N2", ciit);
  			servizi1[14]=(decTemp/12).ToString("N2", ciit);
       }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
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
}
