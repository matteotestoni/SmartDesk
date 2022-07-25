using System;
public partial class _Default : System.Web.UI.Page
{
    public string strKy = "";
    public string strFoto= "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            strKy = Smartdesk.Functions.SqlWriteKey("Providers");
            caricafiles();
            strRedirect = "/admin/form.aspx?CoreModules_Ky=27&CoreEntities_Ky=145&CoreForms_Ky=114&salvato=salvato&Providers_Ky=" + strKy;
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
                strFileName=Server.MapPath("/uploads/foto-providers/" + strKy + "_" + i + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                //Response.Write(strFileName);
                strFoto="/uploads/foto-providers/" + strKy + "_" + i + ".jpg";
                aggiornaFoto(i);
              }      
            }
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        //Response.Write(strFoto);
        strSQL = "UPDATE Providers SET Providers_Logo='" + strFoto + "' WHERE Providers_Ky = " + strKy;
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}