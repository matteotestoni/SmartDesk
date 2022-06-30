using System;
using System.Data;
using System.Web.Security;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strAzione = "";
    public string strKy = "";
    public string strFoto= "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
      if (Smartdesk.Login.Verify){
		  Dictionary<string, object> frm = new Dictionary<string, object>();
		  if (Smartdesk.Current.Request("Utenti_Attivo") == "") frm.Add("Utenti_Attivo", false);
		  if (Smartdesk.Current.Request("Utenti_Admin") == "") frm.Add("Utenti_Admin", false);
		  if (Smartdesk.Current.Request("Utenti_Wysiwyg") == "") frm.Add("Utenti_Wysiwyg", false);
		  if (Smartdesk.Current.Request("Utenti_Telefono1Nascondi") == "") frm.Add("Utenti_Telefono1Nascondi", false);
		  if (Smartdesk.Current.Request("Utenti_CambioGrid") == "") frm.Add("Utenti_CambioGrid", false);
 		  if (Smartdesk.Current.Request("Utenti_CambioForm") == "") frm.Add("Utenti_CambioForm", false);
         strKy = Smartdesk.Functions.SqlWriteKey("Utenti", frm);
        	caricafiles();
          Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=17&CoreForms_Ky=101&Utenti_Ky=" + strKy);

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
                strFileName=Server.MapPath("/uploads/foto-utenti/" + strKy + "_" + i + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-utenti/" + strKy + "_" + i + ".jpg";
                aggiornaFoto(i);
              }      
            }
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Utenti SET Utenti_Logo='" + strFoto + "' WHERE Utenti_Ky = " + strKy;
        Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}
