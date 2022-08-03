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
    public DataTable dtAnnunci;
    public bool boolAdmin = false;
    public string strAnnunci_Ky="";
    public string strFoto="";
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strVecchiaFoto="";
      string strNuovaFoto="";
      string strCampo="";

      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          strAnnunci_Ky=Smartdesk.Current.Request("Annunci_Ky");
          strFoto=Smartdesk.Current.Request("foto");

          strWHERENet = "Annunci_Ky=" + strAnnunci_Ky;
          strORDERNet = "Annunci_Ky";
          strFROMNet = "Annunci";
          dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strVecchiaFoto=dtAnnunci.Rows[0]["Annunci_Foto1"].ToString();
          strCampo="Annunci_Foto" + strFoto;
          strNuovaFoto=dtAnnunci.Rows[0][strCampo].ToString();
          
          strSQL = "UPDATE Annunci set Annunci_Foto1='" + strNuovaFoto + "'," + strCampo + "='" + strVecchiaFoto + "' WHERE Annunci_Ky=" + strAnnunci_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          Response.Redirect("/admin/app/annunci/scheda-annunci.aspx?Annunci_Ky=" + strAnnunci_Ky + "#tabs-foto");
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
