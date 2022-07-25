using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    public string strKy = "";
    public string strFoto= "";

    protected void Page_Load(object sender, EventArgs e){
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("CMSAds_PubblicaWEB") == "") frm.Add("CMSAds_PubblicaWEB", false);
            strKy=Smartdesk.Functions.SqlWriteKey("CMSAds", frm);
          	caricafiles();
		    strRedirect="/admin/app/contenuti/scheda-cmsads.aspx?salvato=salvato&CMSAds_Ky=" + strKy;
			Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }

    public void caricafiles()
    {
      long milliseconds=0;
      string strFileName;
      string strExtension;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                strExtension=System.IO.Path.GetExtension(Request.Files[i].FileName);
                milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                strFileName=Server.MapPath("/uploads/foto-ads/" + strKy + strExtension);
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-ads/" + strKy + strExtension;
                aggiornaFoto(i);
              }      
            }
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE CMSAds SET CMSAds_Foto='" + strFoto + "' WHERE CMSAds_Ky = " + strKy;
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}