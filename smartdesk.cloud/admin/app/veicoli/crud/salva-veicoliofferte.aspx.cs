using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public int intNumeroFoto;
    public string strKy = "";
    public string strFoto = "";
    
    
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("VeicoliOfferte_Abilitata") == "") frm.Add("VeicoliOfferte_Abilitata", false);
            if (Smartdesk.Current.Request("VeicoliOfferte_MostraEtichetta") == "") frm.Add("VeicoliOfferte_MostraEtichetta", false);
            strKy = Smartdesk.Functions.SqlWriteKey("VeicoliOfferte", frm);
            caricafiles();
            strRedirect = "/admin/app/veicoli/scheda-VeicoliOfferte.aspx?custom=1&azione=edit&VeicoliOfferte_Ky=" + strKy;
	        Response.Redirect(strRedirect);
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
    public void caricafiles()
    {
        string strFileName;
        string[] myFiles = Request.Files.AllKeys;
        string strName;
        string strFieldName;
        int intRandom = 0;
        Random rnd = new Random();

        if (myFiles.Length > 0)
        {
            for (int i = 0; i < myFiles.Length; i++)
            {
                if (Request.Files[i].FileName != ""){
                    strName = Request.Files[i].FileName;
                    strName = strName.ToLower().Replace(".jpg", "").Replace(".png", "").Replace(".gif", "").Replace(".jpeg", "").Replace(" ", "-").Replace("/", "").Replace("à", "a").Replace("è", "e").Replace("ì", "i").Replace("ò", "o").Replace("ù", "u");
                    intRandom = rnd.Next(1, 99999);
                    strFileName = Server.MapPath("/uploads/foto-veicoliofferte/" + strKy + "_" + strName + "_" + intRandom + ".jpg");
                    strFieldName = Request.Files.Keys[i].ToString();
                    Response.Write(strFieldName);
                    Request.Files.Get(i).SaveAs(strFileName);
                    strFoto = "/uploads/foto-veicoliofferte/" + strKy + "_" + strName + "_" + intRandom + ".jpg";
                    aggiornaFoto(strFieldName, strFoto);
                }
            }
        }
    }


    public bool aggiornaFoto(string strFieldName, string strFoto)
    {
        string strSQL = "";
        bool output = false;
        strSQL = "UPDATE VeicoliOfferte SET " + strFieldName + "='" + strFoto + "' WHERE VeicoliOfferte_Ky = " + strKy;
        //Response.Write(strSQL + "<hr>");
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output = true;
        return output;
    }
}
