using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtCMSAds;
    public DataTable dtCMSAdsZone;
    public DataTable dtProvince;
    public DataTable dtCMSTags;
    public string strFROMNet = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strH1 = "Contenuto";
    public string strAzione = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
      
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          if (strAzione!="new"){
            strAzione = "modifica";
            dtCMSAds = Smartdesk.Data.Read("CMSAds", "CMSAds_Ky",Smartdesk.Current.QueryString("CMSAds_Ky"));
          }
          //zone
      	  strWHERENet = "";
          strORDERNet = "CMSAdsZone_Titolo";
          strFROMNet = "CMSAdsZone";
          dtCMSAdsZone = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAdsZone_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          //province
      	  strWHERENet = "Nazioni_Ky=105";
          strORDERNet = "Province_Provincia";
          strFROMNet = "Province_Vw";
          dtProvince = Smartdesk.Sql.getTablePage(strFROMNet, null, "Province_Ky", strWHERENet, strORDERNet, 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          //tags
          strWHERENet="";
          strORDERNet = "CMSTags_Titolo";
          strFROMNet = "CMSTags";
          dtCMSTags = new DataTable("CMSTags");
          dtCMSTags = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSTags_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
        Boolean boolValore = false;
        if (strAzione == "new")
        {
            boolValore = false;
        }
        else
        {
            boolValore = Smartdesk.Data.FieldBool(dtTabella,strField);
        }
        return boolValore;
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
}
