using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strAste_Ky="";
    public string strAzione = "";
    public string strSorgente="";
    public string strKy = "";
    public string strFoto= "";
    public string strAnnunci_Ky="";
    public string strNumeroFoto="";
    public int intNumeroFoto=0;
    public string strUrlKey= "";
  	public DataTable dtCoreUrlRewrite;
    public DataTable dtAnnunci;
    
    
    public int intNumRecords = 0;
	  public string strFROMNet = "";
	  public string strWHERENet = "";
	  public string strORDERNet = "";
	  public string strSQL = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strRedirect = Smartdesk.Current.LoginPageRoot;
			string strWHERENet="";
			string strFROMNet = "";
			string strORDERNet = "";
      bool boolAjax = false;

			  
			  

        if (Smartdesk.Login.Verify)
        {
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("Annunci_GruMunito") == "") frm.Add("Annunci_GruMunito", false);
            if (Smartdesk.Current.Request("Annunci_Gruppoidraulico") == "") frm.Add("Annunci_Gruppoidraulico", false);
            if (Smartdesk.Current.Request("Annunci_Retarder") == "") frm.Add("Annunci_Retarder", false);
			if (Smartdesk.Current.Request("Annunci_TrattoriDT") == "") frm.Add("Annunci_TrattoriDT", false);
			if (Smartdesk.Current.Request("Annunci_ClimaCabina") == "") frm.Add("Annunci_ClimaCabina", false);
			if (Smartdesk.Current.Request("Annunci_MarchioCE") == "") frm.Add("Annunci_MarchioCE", false);
			if (Smartdesk.Current.Request("Annunci_ImmobiliDisponibilita") == "") frm.Add("Annunci_ImmobiliDisponibilita", false);
			if (Smartdesk.Current.Request("Annunci_ImmobiliAscensore") == "") frm.Add("Annunci_ImmobiliAscensore", false);
			if (Smartdesk.Current.Request("Annunci_ImmobiliCondizionatore") == "") frm.Add("Annunci_ImmobiliCondizionatore", false);
			if (Smartdesk.Current.Request("Annunci_ImmobiliTerrazzo") == "") frm.Add("Annunci_ImmobiliTerrazzo", false);
			if (Smartdesk.Current.Request("Annunci_ImmobiliAllarme") == "") frm.Add("Annunci_ImmobiliAllarme", false);
			if (Smartdesk.Current.Request("Annunci_ImmobileCablato") == "") frm.Add("Annunci_ImmobileCablato", false);
			if (Smartdesk.Current.Request("Annunci_Cerco") == "") frm.Add("Annunci_Cerco", false);
            if (Smartdesk.Current.Request("Annunci_Offro") == "") frm.Add("Annunci_Offro", false);
            if (Smartdesk.Current.Request("Annunci_ConRiserva") == "") frm.Add("Annunci_ConRiserva", false);
            if (Smartdesk.Current.Request("Annunci_GestionaleImmobiliare") == "") frm.Add("Annunci_GestionaleImmobiliare", false);
            if (Smartdesk.Current.Request("Annunci_Agestanet") == "") frm.Add("Annunci_Agestanet", false);
            if (Smartdesk.Current.Request("Annunci_Vetrina") == "") frm.Add("Annunci_Vetrina", false);
            //Response.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
						//frm.Add("Annunci_DataScadenza", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            strAste_Ky =  Smartdesk.Current.Form("Aste_Ky");
            strSorgente = Smartdesk.Current.Form("sorgente");
            strNumeroFoto = Request["numerofoto"];
        		//Response.Write(strNumeroFoto + "<br>");
            if (strNumeroFoto!=null && strNumeroFoto.Length>0){
                intNumeroFoto=Convert.ToInt32(strNumeroFoto);    
            }else{
                intNumeroFoto=0;
            }
        		//Response.Write(intNumeroFoto + "<br>");
            strKy = Smartdesk.Functions.SqlWriteKey("Annunci", frm);            
						strWHERENet = "Annunci_Ky=" + strKy;
            strORDERNet = "Annunci_Ky";
            strFROMNet = "Annunci";
            dtAnnunci = new DataTable("Annunci");
            dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            //aggiornaNumeroFoto();
            strUrlKey=Smartdesk.Current.Request("Annunci_UrlKey");
            if (strUrlKey==null || strUrlKey.Length<2){
              strUrlKey = Smartdesk.Current.Request("Annunci_Titolo").ToLower().Replace(" ","-").Replace("/","").Replace("à","a").Replace("è","e").Replace("ì","i").Replace("ò","o").Replace("ù","u") + "-" + strKy;
              aggiornaUrlKey(strUrlKey);
            }
          	caricafiles();
            updateUrlRewrite();
            switch (strSorgente)
            {
              case "scheda-aste":
                  strRedirect = "/admin/app/annunci/scheda-annunci.aspx?salvato=salvato&Annunci_Ky=" + strKy + "&Aste_Ky=" + strAste_Ky;
                  break;
              case "elenco-annunci":
                  strRedirect = "/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42&salvato=salvato&Annunci_Ky=" + strKy;
                  break;
              default:
                  strRedirect = "/admin/app/annunci/scheda-annunci.aspx?salvato=salvato&Annunci_Ky=" + strKy;
                  break;
            }
        }
        Response.Redirect(strRedirect);
    }


  public void updateUrlRewrite()
  {
    string strSource="";
    string strDestination="";
		
		strWHERENet = "Annunci_Ky=" + strKy;
        strORDERNet = "Annunci_Ky";
        strFROMNet = "Annunci_Vw";
        dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		strSource="/attivita/" + dtAnnunci.Rows[0]["Province_ProvinciaHTML"].ToString().ToLower() + "/" + dtAnnunci.Rows[0]["Comuni_ComuneHTML"].ToString().ToLower() + "/" + dtAnnunci.Rows[0]["Annunci_UrlKey"].ToString() + ".html";
    		strDestination="/scheda-annuncio.aspx?Annunci_Ky=" + strKy;
    		strWHERENet = "CoreEntities_Code='annunci' AND CoreEntities_KeyValue='" + strKy + "'";
    		//Response.Write(strWHERENet);
        strORDERNet = "CoreUrlRewrite_Ky";
        strFROMNet = "CoreUrlRewrite";
        dtCoreUrlRewrite = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreUrlRewrite_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreUrlRewrite.Rows.Count>0){
            strSQL = "UPDATE CoreUrlRewrite SET ";
            strSQL += "CoreUrlRewrite_UrlSource='" + strSource + "',";
            strSQL += "CoreUrlRewrite_UrlDestination='" + strDestination + "'";
            strSQL += " WHERE CoreUrlRewrite_Ky=" + dtCoreUrlRewrite.Rows[0]["CoreUrlRewrite_Ky"].ToString();
    	}else{
          strSQL = "INSERT INTO CoreUrlRewrite (CoreEntities_Code,CoreEntities_KeyValue,CoreUrlRewrite_UrlSource,CoreUrlRewrite_UrlDestination) VALUES (";
          strSQL += " 'annunci',";
          strSQL += "'" + strKy + "',";
          strSQL += "'" + strSource + "',";
          strSQL += "'" + strDestination + "'";
          strSQL += ")";
		}
		//Response.Write(strSQL);
    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
  }

  public void caricafiles()
  {
    string strFileName;
    string [ ] myFiles = Request.Files.AllKeys;
    int intNumeroFotoTotali;
    string strName;
    int intRandom=0;
    Random rnd = new Random();

    if (myFiles.Length>0){
          intNumeroFotoTotali=intNumeroFoto;
          for ( int i = 0; i < myFiles.Length; i++ ) {
            if (Request.Files[i].FileName !="" && intNumeroFotoTotali<51){
              strName=Request.Files[i].FileName;
              strName = strName.ToLower().Replace(".jpg","").Replace(".png","").Replace(".gif","").Replace(".jpeg","").Replace(" ","-").Replace("/","").Replace("à","a").Replace("è","e").Replace("ì","i").Replace("ò","o").Replace("ù","u");
              intRandom=rnd.Next(1, 99999);
			        strFileName=Server.MapPath("/uploads/foto-annunci/" + strKy + "_" + strName + "_" + intRandom + ".jpg");
              Request.Files.Get(i).SaveAs(strFileName);
              strFoto="/uploads/foto-annunci/" + strKy + "_" + strName + "_" + intRandom + ".jpg";
              aggiornaFoto(intNumeroFotoTotali);
              intNumeroFotoTotali++;
            }      
          }
          aggiornaNumeroFoto();
    }
  }

  public bool aggiornaFoto(int intNumeroFoto)
  {
      string strSQL="";
      bool output = false;
      strSQL = "UPDATE Annunci SET Annunci_Foto" + (intNumeroFoto+1) + "='" + strFoto + "' WHERE Annunci_Ky = " + strKy;
      Response.Write(strSQL);
    	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      output=true;
      return output;
  }

  public bool aggiornaNumeroFoto()
  {
    string strSQL="";
    string strTemp="";
  	int intNumeroFoto=0;
    bool output = false;
		string strWHERENet="";
		string strFROMNet = "";
		string strORDERNet = "";
  	DataTable dtAnnuncioPerFoto;

	strWHERENet = "Annunci_Ky=" + strKy;
      strORDERNet = "Annunci_Ky";
      strFROMNet = "Annunci";
      dtAnnuncioPerFoto = new DataTable("AnnuncioPerFoto");
      dtAnnuncioPerFoto = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

		for (int i = 1; i < 51; i++){
  		strTemp="Annunci_Foto" + i;
  		if (dtAnnuncioPerFoto.Rows[0][strTemp].ToString().Length>0){
  			intNumeroFoto++;
  		}
		}
    strSQL = "UPDATE Annunci SET Annunci_NumeroFoto=" + (intNumeroFoto) + " WHERE Annunci_Ky = " + strKy;
  	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    output=true;
    return output;
  }

  public bool aggiornaUrlKey(string strUrlKey)
  {
      string strSQL="";
      bool output = false;
      strSQL = "UPDATE Annunci SET Annunci_UrlKey='" + strUrlKey + "' WHERE Annunci_Ky = " + strKy;
      //Response.Write(strSQL);
    	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      output=true;
      return output;
  }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
