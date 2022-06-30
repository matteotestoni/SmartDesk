using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
	{
    public bool fCaricato = false;
    public string strAzione = "";
    public string strProduttori_Ky = "";
    public string strCheck = "";
    public string strKy = "";
    public string strDispobilita = "";
    public string strCategoria = "";
    public int intNumeroFoto = 0;
    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtProduttori;
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    public string strFoto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
	      strAzione = Request["azione"];
          Dictionary<string, object> frm = new Dictionary<string, object>();
          if (Smartdesk.Current.Request("Produttori_PubblicaWEB") == "") frm.Add("Produttori_PubblicaWEB", false);
      	  strKy = Smartdesk.Functions.SqlWriteKey("Produttori", frm);
      	  strProduttori_Ky=strKy;
          caricafiles();
	      Response.Redirect("/admin/form.aspx?CoreModules_Ky=8&CoreEntities_Ky=95&CoreGrids_Ky=78&CoreForms_Ky=165&custom=0&azione=edit&salvato=salvato&Produttori_Ky=" + strKy);
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
                strFileName=Server.MapPath("/uploads/foto-produttori/" + strProduttori_Ky + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-produttori/" + strProduttori_Ky + ".jpg";
                aggiornaFoto();
              }      
            }
      }
    }

    public bool aggiornaFoto()
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Produttori SET Produttori_Logo='" + strFoto + "' WHERE Produttori_Ky = " + strProduttori_Ky;
  		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
		//Response.Write(strSQL);
        return output;
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
