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
    public bool boolAdmin = false;
    public bool boolWysiwyg = false;
    public DataTable dtVeicoliMarca;
    public DataTable dtVeicoliModello;
    public DataTable dtVeicoliTipo;
    public DataTable dtVeicoli;
    public string strVeicoliMarca_Ky = "";
    public int intVeicoliMarca_Ky = 0;
    public string strFROMNet = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strH1 = "";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
					boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
	    		boolWysiwyg=(dtLogin.Rows[0]["Utenti_Wysiwyg"]).Equals(true);
					strAzione = Request["azione"];
					strWHERENet="";
					strORDERNet = "VeicoliTipo_Ky";
					strFROMNet = "VeicoliTipo";
					dtVeicoliTipo = new DataTable("VeicoliTipo");
					dtVeicoliTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
					if (strAzione!="new"){
							//Response.Write("ok");
							strAzione = "modifica";
							strVeicoliMarca_Ky=Smartdesk.Current.Request("VeicoliMarca_Ky");
							dtVeicoliMarca = Smartdesk.Data.Read("VeicoliMarca", "VeicoliMarca_Ky",Smartdesk.Current.QueryString("VeicoliMarca_Ky"));
							strWHERENet="VeicoliMarca_Ky=" + strVeicoliMarca_Ky;
							strORDERNet = "VeicoliModello_Descrizione";
							strFROMNet = "VeicoliModello_Vw";
							dtVeicoliModello = new DataTable("VeicoliModello");
							dtVeicoliModello = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliModello_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							//Response.Write(dtVeicoliModello.Rows.Count);
	          }
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
        strValore=dtVeicoliMarca.Rows[0][strField].ToString();
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
}
