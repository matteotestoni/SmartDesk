using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public bool fCaricato = false;
    public string strAzione = "";
    public string strKy = "";
    public int intNumeroFoto = 0;
    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtAziende;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    public string strFoto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      
	  
      if (Smartdesk.Login.Verify){
		dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
		strAzione = Request["azione"];
        Dictionary<string, object> frm = new Dictionary<string, object>();
        if (Smartdesk.Current.Request("Aziende_ServerSMTPSSL") == "") frm.Add("Aziende_ServerSMTPSSL", false);
        if (Smartdesk.Current.Request("Aziende_Attiva") == "") frm.Add("Aziende_Attiva", false);
        if (Smartdesk.Current.Request("Aziende_Default") == "") frm.Add("Aziende_Default", false);
		strKy = Smartdesk.Functions.SqlWriteKey("Aziende", frm);
		caricafiles();
		Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=20&CoreGrids_Ky=19&CoreForms_Ky=100&custom=0&azione=edit&salvato=salvato&Aziende_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public void caricafiles()
    {
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                strFileName=Server.MapPath("/uploads/foto-aziende/" + strKy + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-aziende/" + strKy + ".jpg";
                aggiornaFoto();
              }      
            }
      }
    }

    public bool aggiornaFoto()
    {
        string strSQL="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        
        strSQL = "UPDATE Aziende SET Aziende_Logo='" + strFoto + "' WHERE Aziende_Ky = " + strKy;
        //Response.Write(strSQL);
        cm.CommandText = strSQL;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;

        cm.CommandTimeout = 300;
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            cm.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("csLoadData->CreateXslInsUpdXls_In: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }
        return output;
    }
    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
