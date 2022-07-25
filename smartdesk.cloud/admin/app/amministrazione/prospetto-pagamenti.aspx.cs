using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");    
    public DataTable dtProspetto;
    public DataTable dtProspettoAnni;
    public DataTable dtLogin;
    public int intDocumenti_Ky = 0;
    public string strH1 = "Prospetto pagamenti";
    public DateTime dt;
    public int intYear;
    public int intMonth;
    public int intNumeroMesi=0;
    public int intNumeroAnni=0;
    public int intMeseCorrente=0;
    public int intAnnoCorrente=0;
    public int intAnnoIniziale=0;
    public int intAnnoFinale=0;
    public string[,] fatturato1;
    public string[,] fatturato2;
    public decimal[,] fatturato3;
    public decimal decTemp;
    public string strTemp;
    public string strAnnoIniziale;
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      
	  
      if (Smartdesk.Login.Verify){
	        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            dt=DateTime.Now;
            intYear=dt.Year;
			
            intMonth=dt.Month;
            strAnnoIniziale=Request["annoiniziale"];
      			if (strAnnoIniziale==null || strAnnoIniziale.Length<2){
      				strAnnoIniziale=(intYear-8).ToString();
      			}
      			strH1="Prospetto pagamenti dal " + strAnnoIniziale;
      			//Response.Write(strAnnoIniziale);			
            strWHERENet="Anno>=" + strAnnoIniziale;
            strFROMNet = "Prospetto_annifatturato_Vw";
            strORDERNet = "anno";
            dtProspettoAnni = new DataTable("prospettoanni");
            dtProspettoAnni = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1,10,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtProspettoAnni.Rows.Count>0){
              intAnnoIniziale=Convert.ToInt32(dtProspettoAnni.Rows[0]["anno"].ToString());
            }else{
              intAnnoIniziale=(intYear-8);
            }
			      //Response.Write(intAnnoIniziale);
            fatturato1 = new string[16,dtProspettoAnni.Rows.Count+5];            
            fatturato2 = new string[16,dtProspettoAnni.Rows.Count+5];
			      fatturato3 = new decimal[16,dtProspettoAnni.Rows.Count+5];

            for (int i = 0; i < dtProspettoAnni.Rows.Count; i++){
              intAnnoCorrente=Convert.ToInt32(dtProspettoAnni.Rows[i]["anno"].ToString())-Convert.ToInt32(dtProspettoAnni.Rows[0]["anno"].ToString());
              //Response.Write(intAnnoCorrente + "<br />");
              fatturato1[13,intAnnoCorrente]=(dtProspettoAnni.Rows[i]["fatturato"]).ToString();
              fatturato2[13,intAnnoCorrente]=((decimal)dtProspettoAnni.Rows[i]["fatturato"]).ToString("N2", ciit);
              fatturato3[13,intAnnoCorrente]=((decimal)dtProspettoAnni.Rows[i]["fatturato"]);
              intAnnoFinale=intAnnoCorrente;
            }
			//Response.Write(intAnnoFinale);
			strWHERENet="Anno>=" + strAnnoIniziale;
            strFROMNet = "Prospetto_fatturato_Vw";
            strORDERNet = "anno, mese";
            dtProspetto = new DataTable("prospetto");
            dtProspetto = Smartdesk.Sql.getTablePage(strFROMNet, null, "chiave", strWHERENet, strORDERNet, 1,300,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            for (int i = 0; i < dtProspetto.Rows.Count; i++){
              intAnnoCorrente=Convert.ToInt32(dtProspetto.Rows[i]["anno"].ToString())-Convert.ToInt32(dtProspettoAnni.Rows[0]["anno"].ToString());
              intMeseCorrente=Convert.ToInt32(dtProspetto.Rows[i]["mese"]);
              fatturato1[intMeseCorrente,intAnnoCorrente]=(dtProspetto.Rows[i]["fatturato"]).ToString();
              fatturato2[intMeseCorrente,intAnnoCorrente]=((decimal)dtProspetto.Rows[i]["fatturato"]).ToString("N2", ciit);
              fatturato3[intMeseCorrente,intAnnoCorrente]=((decimal)dtProspetto.Rows[i]["fatturato"]);
            }
          	//quanti mesi da calcolare
            for (int i = 0; i <= intAnnoFinale; i++){
		            intNumeroMesi=0;
								for (int j = 1; j <= 12; j++){
		            	if (fatturato3[j,i]!=0){
										intNumeroMesi=intNumeroMesi+1;
									}
								}
								fatturato1[14,i]=intNumeroMesi.ToString();
								fatturato2[14,i]=intNumeroMesi.ToString();
								fatturato3[14,i]=intNumeroMesi;
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

    public String GetAnno(int intAnnoIn)
    {
      int intAnnoOut=0;
      string strAnnoOut="";
      if (intAnnoIn!=0){
      	intAnnoOut=intAnnoIn+intAnnoIniziale;
				strAnnoOut=intAnnoOut.ToString();
      }else{
        strAnnoOut="";
      }
      return strAnnoOut;
    }   
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
