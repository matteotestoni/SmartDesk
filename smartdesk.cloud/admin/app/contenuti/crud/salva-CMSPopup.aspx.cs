using System;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{
    public string strKy = "";
    public string strFoto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          Dictionary<string, object> frm = new Dictionary<string, object>();
      	  if (Smartdesk.Current.Request("CMSPopup_PubblicaWEB") == "") frm.Add("CMSPopup_PubblicaWEB", false);
          strKy = Smartdesk.Functions.SqlWriteKey("CMSPopup", frm);
        	caricafiles();
          strRedirect = "/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=257&CoreGrids_Ky=282";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }

    public void caricafiles()
    {
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                strFileName=Server.MapPath("/uploads/foto-popup/" + strKy + "_" + i + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-popup/" + strKy + "_" + i + ".jpg";
                aggiornaFoto(i);
              }      
            }
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE CMSPopup SET CMSPopup_Foto='" + strFoto + "' WHERE CMSPopup_Ky = " + strKy;
        Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}
