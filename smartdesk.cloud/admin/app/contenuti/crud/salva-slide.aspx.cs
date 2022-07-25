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
            if (Smartdesk.Current.Request("CMSSlide_PubblicaWEB") == "") frm.Add("CMSSlide_PubblicaWEB", false);
            strKy=Smartdesk.Functions.SqlWriteKey("CMSSlide", frm);
          	caricafiles();
		    strRedirect="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=224&CoreGrids_Ky=236";
            Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }

    public void caricafiles()
    {
      long milliseconds=0;
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                strFileName=Server.MapPath("/uploads/foto-slide/" + strKy + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-slide/" + strKy + ".jpg";
                aggiornaFoto(i);
              }      
            }
      }
    }

    public bool aggiornaFoto(int intNumeroFoto)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE CMSSlide SET CMSSlide_Foto='" + strFoto + "' WHERE CMSSlide_Ky = " + strKy;
        /*
        strSQL="INSERT INTO Files (Files_PadreKy,Chiave_Ky,Chiave_Tabella,FilesTipo_Ky,Files_Titolo,Files_Path,Files_Data,Lingue_Ky,Files_Contenttype,Files_Extension,Files_UserInsert,Files_UserUpdate,Files_UserDelete,Files_DateInsert,Files_DateUpdate,Files_DateDelete)";
        strSQL+=" VALUES";
        strSQL+=" (null";
        strSQL+="," + strKy;
        strSQL+=",'Slide'";
        strSQL+=",1";
        strSQL+=",'" + Request["Slide_Titolo"] + "'";
        strSQL+=",'" + strFoto + "'";
        strSQL+=",GETDATE()";
        strSQL+=",1";
        strSQL+=",'image/jpeg'";
        strSQL+=",'jpg'";
        strSQL+=",1";
        strSQL+=",1";
        strSQL+=",null";
        strSQL+=",GETDATE()";
        strSQL+=",GETDATE()";
        strSQL+=",null)";
        */
        //Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}