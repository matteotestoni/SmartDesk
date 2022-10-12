using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    public string strKy = "";
    public string strFoto = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strCoreForms_Ky = Request["CoreForms_Ky"];
        
        if (Smartdesk.Login.Verify)
        {
					Dictionary<string, object> frm = new Dictionary<string, object>();
					if (Smartdesk.Current.Request("Veicoli_PubblicaWEB") == "") frm.Add("Veicoli_PubblicaWEB", false);
					if (Smartdesk.Current.Request("Veicoli_Premium") == "") frm.Add("Veicoli_Premium", false);
					if (Smartdesk.Current.Request("Veicoli_Inevidenza") == "") frm.Add("Veicoli_Inevidenza", false);
					if (Smartdesk.Current.Request("Veicoli_Prime") == "") frm.Add("Veicoli_Prime", false);
					if (Smartdesk.Current.Request("Veicoli_LastMinute") == "") frm.Add("Veicoli_LastMinute", false);
          strKy = Smartdesk.Functions.SqlWriteKey("Veicoli",frm);
		      caricafiles();
          strRedirect = "/admin/goto-form.aspx?CoreEntities_Ky=109&CoreForms_Ky=" + strCoreForms_Ky + "&salvato=salvato&Veicoli_Ky=" + strKy;
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
                strFileName=Server.MapPath("/uploads/foto-veicoli/" + strKy + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-veicoli/" + strKy + ".jpg";
                aggiornaFoto();
              }      
            }
      }
    }

    public bool aggiornaFoto()
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Veicoli SET Veicoli_Foto1='" + strFoto + "' WHERE Veicoli_Ky = " + strKy;
        //Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }


}
