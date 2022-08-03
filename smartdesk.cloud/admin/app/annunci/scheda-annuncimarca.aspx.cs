using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtAnnunciMarca;
    public DataTable dtAnnunciModello;
    public DataTable dtAnnunciModelloTipo;
    public string strFROMNet = "";
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strH1 = "Annunci > Marca e modelli";
    public string strAzione = "";
    
    public string strTipo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
          strAzione = Request["azione"];
          if (strAzione!="new"){
              strAzione = "modifica";
              dtAnnunciMarca = Smartdesk.Data.Read("AnnunciMarca", "AnnunciMarca_Ky",Smartdesk.Current.QueryString("AnnunciMarca_Ky"));
              dtAnnunciModello = Smartdesk.Data.Read("AnnunciModello_Vw", "AnnunciMarca_Ky",Smartdesk.Current.QueryString("AnnunciMarca_Ky"));
			        strWHERENet = "";
              strORDERNet = "AnnunciModelloTipo_Titolo";
              strFROMNet = "AnnunciModelloTipo";
              dtAnnunciModelloTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciModelloTipo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
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
        if (dtTabella!=null && dtTabella.Rows.Count>0){
		  strValore=dtTabella.Rows[0][strField].ToString();
		}else{
	  	  strValore="";
		}
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
}
