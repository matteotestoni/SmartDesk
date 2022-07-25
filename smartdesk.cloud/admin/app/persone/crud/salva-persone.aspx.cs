using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    public string strKy = "";
    public string strFoto= "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("Persone_Attivo") == "") frm.Add("Persone_Attivo", false);
            if (Smartdesk.Current.Request("Persone_RiceveEmail") == "") frm.Add("Persone_RiceveEmail", false);
            strKy = Smartdesk.Functions.SqlWriteKey("Persone", frm);
          	caricafiles();
            strRedirect = "/admin/form.aspx?CoreModules_Ky=22&CoreEntities_Ky=38&CoreGrids_Ky=114&CoreForms_Ky=144&custom=0&azione=edit&Persone_Ky=" + strKy;
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
                strFileName=Server.MapPath("/uploads/foto-persone/" + strKy + "_" + i + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-persone/" + strKy + "_" + i + ".jpg";
                aggiornaFoto(i);
              }      
            }
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Persone SET Persone_Foto='" + strFoto + "' WHERE Persone_Ky = " + strKy;
        Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}