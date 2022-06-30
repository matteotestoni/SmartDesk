using System;
public partial class _Default : System.Web.UI.Page
{
    public string strKy = "";
    public string strFoto= "";
    public string strUrlKey= "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("Aste");
            strUrlKey=Smartdesk.Current.Request("Annunci_UrlKey");
            if (strUrlKey==null || strUrlKey.Length<2){
              strUrlKey = Smartdesk.Current.Request("Aste_Titolo").ToLower().Replace(" ","-").Replace("/","").Replace("à","a").Replace("è","e").Replace("ì","i").Replace("ò","o").Replace("ù","u") + "-" + strKy;
              aggiornaUrlKey(strUrlKey);
            }
          	caricafiles();
            strRedirect = "/admin/app/aste/scheda-aste.aspx?salvato=salvato&Aste_Ky=" + strKy;
	        Response.Redirect(strRedirect);
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
                strFileName=Server.MapPath("/uploads/foto-aste/" + strKy + "_" + i + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-Aste/" + strKy + "_" + i + ".jpg";
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

    public bool aggiornaUrlKey(string strUrlKey)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Aste SET Aste_UrlKey='" + strUrlKey + "' WHERE Aste_Ky = " + strKy;
        //Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}