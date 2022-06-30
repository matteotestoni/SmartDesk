using System;
using System.Data;
using System.Globalization;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtVeicoliRicerche;
    public DataTable dtVeicoliMarca;
    public DataTable dtVeicoliModello;
    public string strVeicoliRicerche_Ky = "";
    public int intVeicoliRicerche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
            strAzione = Request["azione"];

            strWHERENet="VeicoliTipo_Ky=1";
            strORDERNet = "VeicoliMarca_Descrizione";
            strFROMNet = "VeicoliMarca";
            dtVeicoliMarca = new DataTable("VeicoliMarca");
            dtVeicoliMarca = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliMarca_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
           if (strAzione!="new"){
                    strAzione = "modifica";
	            strVeicoliRicerche_Ky=Smartdesk.Current.Request("VeicoliRicerche_Ky");
    	  	  	dtVeicoliRicerche = Smartdesk.Data.Read("VeicoliRicerche_Vw", "VeicoliRicerche_Ky",Smartdesk.Current.QueryString("VeicoliRicerche_Ky"));

	            strFROMNet = "VeicoliModello";
	            strWHERENet = "VeicoliMarca_Ky=" + dtVeicoliRicerche.Rows[0]["VeicoliMarca_Ky"].ToString();
	            strORDERNet = "VeicoliModello_Descrizione";
	            dtVeicoliModello = new DataTable("VeicoliModello");
	            dtVeicoliModello = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliModello_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			}
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetMoneyValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="0";
      }else{
        strValore=dtVeicoliRicerche.Rows[0][strField].ToString();
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
        strValore=Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
    }

    
    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtTabella.Rows[0][strField].Equals(true)){
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
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
