using System;
using System.Data;
using System.Globalization;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtVeicoli;
    public DataTable dtVeicoliMarca;
    public DataTable dtVeicoliModello;
    public string strVeicoli_Ky = "";
    public int intVeicoli_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    
    public DataTable dtRegioni;
    public DataTable dtProvince;
    public DataTable dtComuni;

    protected void Page_Load(object sender, EventArgs e)
    {
      
      string strWHERENet="";
      string strORDERNet = "";
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strAzione = Request["azione"];
              if (strAzione!="new"){
                strAzione = "modifica";
		            strVeicoli_Ky=Smartdesk.Current.Request("Veicoli_Ky");
	    	  	  	dtVeicoli = Smartdesk.Data.Read("Veicoli", "Veicoli_Ky",Smartdesk.Current.QueryString("Veicoli_Ky"));

                //regioni
                if (dtVeicoli.Rows[0]["Nazioni_Ky"].ToString()!=""){
                    strWHERENet = "Nazioni_Ky=" + dtVeicoli.Rows[0]["Nazioni_Ky"].ToString();
                }else{
                    strWHERENet = "";
                }
                strORDERNet = "Regioni_Regione";
                strFROMNet = "Regioni";
                dtRegioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Regioni_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                //province
                if (dtVeicoli.Rows[0]["Regioni_Ky"].ToString()!=""){
                    strWHERENet = "Regioni_Ky=" + dtVeicoli.Rows[0]["Regioni_Ky"].ToString();
                }else{
                    strWHERENet = "";
                }
                strORDERNet = "Province_Provincia";
                strFROMNet = "Province";
                dtProvince = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                //Comuni
                if (dtVeicoli.Rows[0]["Province_Ky"].ToString()!=""){
                  strWHERENet = "Province_Ky=" + dtVeicoli.Rows[0]["Province_Ky"].ToString();
                }else{
                  if (dtVeicoli.Rows[0]["Regioni_Ky"].ToString()!=""){
                      strWHERENet = "Regioni_Ky=" + dtVeicoli.Rows[0]["Regioni_Ky"].ToString();
                  }else{
                    if (dtVeicoli.Rows[0]["Nazioni_Ky"].ToString()!=""){
                        strWHERENet = "Nazioni_Ky=" + dtVeicoli.Rows[0]["Nazioni_Ky"].ToString();
                    }else{
                        strWHERENet = "";
                    }
                  }
                }
								strORDERNet = "Comuni_Comune";
                strFROMNet = "Comuni_Vw";
                dtComuni = Smartdesk.Sql.getTablePage(strFROMNet, null, "Comuni_Ky", strWHERENet, strORDERNet, 1, 400,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	          }
              strWHERENet="VeicoliTipo_Ky=1";
              strORDERNet = "VeicoliMarca_Titolo";
              strFROMNet = "VeicoliMarca";
              dtVeicoliMarca = new DataTable("VeicoliMarca");
              dtVeicoliMarca = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliMarca_Ky", strWHERENet, strORDERNet, 1, 400,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              
              if (strAzione!="new" && dtVeicoli.Rows[0]["VeicoliMarca_Ky"].ToString().Length>0){
                strWHERENet="VeicoliMarca_Ky=" + dtVeicoli.Rows[0]["VeicoliMarca_Ky"].ToString();
              }else{
                strWHERENet="";
              }
              strORDERNet = "VeicoliModello_Titolo";
              strFROMNet = "VeicoliModello";
              dtVeicoliModello = new DataTable("VeicoliModello");
              dtVeicoliModello = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliModello_Ky", strWHERENet, strORDERNet, 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetMoneyValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="0";
      }else{
        strValore=dtVeicoli.Rows[0][strField].ToString();
        strValore=strValore.Replace(",0000","");
      }
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;

    }
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtVeicoli.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }
        
    public string getOre(decimal decOre){
	    string strReturn;   
		strReturn=""; 

		if (decOre<=160){
		  strReturn="<span class=\"badge success\">" + decOre + "</span>";
		}
		if (decOre>160 && decOre<240){
		  strReturn="<span class=\"badge warning\">" + decOre + "</span>";
		}
		if (decOre>240){
		  strReturn="<span class=\"badge alert\">" + decOre + "</span>";
		}
		return strReturn;
	}
}
