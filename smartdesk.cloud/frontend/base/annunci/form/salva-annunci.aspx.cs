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
    public DataTable dtAnnunci;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    public string strKy = "";
    public string strFoto= "";
    public int intNumero=0;
    public string strUrlKey= "";
    public int intNumeroFoto=0;
    public string strNumeroFoto="";
    
    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
      
      
      

        if (Request.Cookies["astebusiness"] != null){
            strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["astebusiness"].Value)).UserData;
            strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
            strORDERNet = "Anagrafiche_Ky";
            strFROMNet = "Anagrafiche";
            dtLogin = new DataTable("Login");
            dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtLogin.Rows.Count>0){
                strNumeroFoto = Smartdesk.Current.Form("NumeroFoto");
                if (strNumeroFoto!=null && strNumeroFoto.Length>0){
                    intNumeroFoto=Convert.ToInt32(strNumeroFoto);    
                }else{
                    intNumeroFoto=0;
                }
            	strWHERENet = strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
            	dtAnnunci = new DataTable("Annunci");
            	dtAnnunci = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                intNumero = dtAnnunci.Rows.Count+1;
                Dictionary<string, object> frm = new Dictionary<string, object>();
                frm.Add("Annunci_Numero", intNumero);
                if (Smartdesk.Current.Request("Annunci_GruMunito") == "") frm.Add("Annunci_GruMunito", false);
                if (Smartdesk.Current.Request("Annunci_Gruppoidraulico") == "") frm.Add("Annunci_Gruppoidraulico", false);
                if (Smartdesk.Current.Request("Annunci_Retarder") == "") frm.Add("Annunci_Retarder", false);
                strKy = Smartdesk.Functions.SqlWriteKey("Annunci", frm);
                strUrlKey=Smartdesk.Current.Request("Annunci_UrlKey");
                if (strUrlKey==null || strUrlKey.Length<2){
                  strUrlKey = Smartdesk.Current.Request("Annunci_Titolo").ToLower().Replace(" ","-").Replace("/","").Replace("à","a").Replace("è","e").Replace("ì","i").Replace("ò","o").Replace("ù","u") + "-" + strKy;
                  aggiornaUrlKey(strUrlKey);
                }
          	    caricafiles();
    	        Response.Redirect("/annuncio-inserito.aspx?salvato=salvato&Annunci_Ky=" + strKy);
            }else{
                Response.Redirect("/login.aspx?errore=nonloggato");
            }
        }else
        {
            Response.Redirect("/login.aspx?errore=nonloggato");
        }
    }

    public void caricafiles()
    {
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      int intNumeroFotoTotali;

      if (myFiles.Length>0){
            intNumeroFotoTotali=intNumeroFoto;
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                strFileName=Server.MapPath("/uploads/foto-annunci/" + strKy + "_" + i + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-annunci/" + strKy + "_" + i + ".jpg";
                aggiornaFoto(intNumeroFotoTotali);
                intNumeroFotoTotali++;
              }      
            }
            aggiornaNumeroFoto(intNumeroFotoTotali);
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Annunci SET Annunci_Foto" + (intNumeroFoto+1) + "='" + strFoto + "' WHERE Annunci_Ky = " + strKy;
        Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }

    public bool aggiornaNumeroFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Annunci SET Annunci_NumeroFoto=" + (intNumeroFoto) + " WHERE Annunci_Ky = " + strKy;
        //Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }

    public bool aggiornaUrlKey(string strUrlKey)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Annunci SET Annunci_UrlKey='" + strUrlKey + "' WHERE Annunci_Ky = " + strKy;
        //Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}
