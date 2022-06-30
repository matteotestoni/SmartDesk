using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strProdottiCategorie_Ky="";
    public DataTable dtProdottiCategoria;
    public string strAzione = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strFROMNet = "";
    public string strFoto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        
          Dictionary<string, object> frm = new Dictionary<string, object>();
          if (Smartdesk.Current.Request("ProdottiCategorie_PubblicaWEB") == "") frm.Add("ProdottiCategorie_PubblicaWEB", false);
          if (Smartdesk.Current.Request("ProdottiCategorie_InMenu") == "") frm.Add("ProdottiCategorie_InMenu", false);
          if (Smartdesk.Current.Request("ProdottiCategorie_InSitemap") == "") frm.Add("ProdottiCategorie_InSitemap", false);
          strKy = Smartdesk.Functions.SqlWriteKey("ProdottiCategorie", frm);
          strProdottiCategorie_Ky=strKy;
          caricafiles();
          Response.Redirect("/admin/form.aspx?CoreModules_Ky=8&CoreEntities_Ky=203&CoreForms_Ky=104&salvato=salvato&ProdottiCategorie_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public void caricafiles()
    {
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      Response.Write("1");
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                strFileName=Server.MapPath("/uploads/foto-prodotticategorie/" + strProdottiCategorie_Ky + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strFoto="/uploads/foto-prodotticategorie/" + strProdottiCategorie_Ky + ".jpg";
                aggiornaFoto();
              }      
            }
      }
    }

    public bool aggiornaFoto()
    {
        string strSQL="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        
        strSQL = "UPDATE ProdottiCategorie SET  ProdottiCategorie_Logo='" + strFoto + "' WHERE ProdottiCategorie_Ky = " + strProdottiCategorie_Ky;
        //Response.Write(strSQL);
        cm.CommandText = strSQL;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;

        cm.CommandTimeout = 300;
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            cm.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("csLoadData->CreateXslInsUpdXls_In: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }
        return output;
    }

    public string FnNum(object o)
    {
        string ret = "null";

        if (o != null)
        {
            if (o.ToString()== "")
            {
                ret = "null";
            }
            else
            {
                ret = o.ToString().Replace(",", ".");
            }
        }
        return ret;
    }

    public string FnText(object o)
    {

        string ret = "";

        if (o != null)
        {
            if (o.ToString() == "")
            {
                ret = "null";
            }
            else
            {
                ret = "'"+o.ToString().Replace("'", "''")+"'";
            }
        }

        return ret;
    }

        public string FnCheck(object o)
    {
        string ret = "null";

        if (o != null)
        {
            ret = (o.ToString() == "on") ? "1" : "0";

        }
        return ret;
    }

	/**/
     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
