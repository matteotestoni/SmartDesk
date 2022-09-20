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
        strSQL = "UPDATE Aziende SET Aziende_Logo='" + strFoto + "' WHERE Aziende_Ky = " + strKy;
        //Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }
}
