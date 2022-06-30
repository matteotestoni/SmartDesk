using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtAttributi;
    public DataTable dtAttributiTipo;
    public DataTable dtAttributiOpzioni;
    public string strFROMNet = "";
    public string strH1 = "Attributo";
    public string strAzione = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            if (strAzione!="new"){
                strAzione = "modifica";
      	  	  	dtAttributi = Smartdesk.Data.Read("Attributi", "Attributi_Ky",Smartdesk.Current.QueryString("Attributi_Ky"));
                strWHERENet="Attributi_Ky=" + Smartdesk.Current.QueryString("Attributi_Ky");
                strORDERNet = "AttributiOpzioni_Ordine";
                strFROMNet = "AttributiOpzioni";
                dtAttributiOpzioni = new DataTable("AttributiOpzioni");
                dtAttributiOpzioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiOpzioni_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            }
            strWHERENet="";
            strORDERNet = "AttributiTipo_Codice";
            strFROMNet = "AttributiTipo";
            dtAttributiTipo = new DataTable("AttributiTipo");
            dtAttributiTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiTipo_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
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
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
