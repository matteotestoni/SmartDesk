using System;
using System.Data;
using System.Web.Security;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strAzione = "";
    
    
    public int intNumRecords = 0;
    public string strEmailContatti = "";
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    public string strKy = "";
    public string strFoto= "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
      string strFrom = "noreply@astebusiness.it";
      
      
      

        if (Request.Cookies["rswcrm-az"] != null){
            strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
            strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
            strORDERNet = "Anagrafiche_Ky";
            strFROMNet = "Anagrafiche";
            dtLogin = new DataTable("Login");
            dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtLogin.Rows.Count>0){
              strKy = Smartdesk.Functions.SqlWriteKey("Aste");
        	    caricafiles();
              System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
          		mail.From = new System.Net.Mail.MailAddress(strFrom);
          		mail.To.Add(new System.Net.Mail.MailAddress("info@astebusiness.it"));
          		mail.Bcc.Add(new System.Net.Mail.MailAddress(Smartdesk.Functions.getOption("core.webmasteremail")));
          		mail.Subject = "Nuova asta inserita";
          		mail.Body = "Un utente ha inserito una nuova asta da revisionare.<br><br><br>Lo staff";
          		mail.IsBodyHtml = true;
          		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(Smartdesk.Functions.getOption("core.serversmpt"),Smartdesk.Functions.getOption("core.serversmptport"));
                client.Port=Smartdesk.Functions.getOption("core.serversmptport");
                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(Smartdesk.Functions.getOption("core.serversmptuser"), Smartdesk.Functions.getOption("core.serversmptpassword"));
          		client.UseDefaultCredentials = false;
          		client.Credentials = mailAuthentication;
          		client.EnableSsl = Smartdesk.Functions.getOption("core.serversmptssl");
          		client.Send(mail);
    	        Response.Redirect("/pag/asta-inviata.html?Aste_Ky=" + strKy);
            }else{
              Response.Redirect("/account/login.html?errore=nonloggato");
            }
        }else
        {
            Response.Redirect("/account/login.html?errore=nonloggato");
        }
    }

    public void caricafiles()
    {
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                strFileName=Server.MapPath("/uploads/foto-aste/" + strKy + "_" + i + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-aste/" + strKy + "_" + i + ".jpg";
                aggiornaFoto(i);
              }      
            }
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Aste SET Aste_Foto" + (intNumeroFoto+1) + "='" + strFoto + "' WHERE Aste_Ky = " + strKy;
        Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
