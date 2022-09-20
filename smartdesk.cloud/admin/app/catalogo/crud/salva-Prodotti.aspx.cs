using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    public bool fCaricato = false;
    public string strAzione = "";
    public string strProdotti_Ky = "";
    public string strCheck = "";
    public string strProdotti_Foto1 = "";
    public string strProdotti_Foto1s = "";
    public string strProdotti_Documento = "";
    public string strKy = "";
    public int intNumeroFoto = 0;
    public int intNumeroDocumento = 0;
    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtProdotto;
    public int intNumRecords = 0;
    public string strUrlKey= "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      
      
	  
      if (Smartdesk.Login.Verify){
	      strAzione = Request["azione"];
	      if (Request["NumeroFoto"]!=null && Request["NumeroFoto"].ToString()!=""){
	        intNumeroFoto=Convert.ToInt32(Request["NumeroFoto"]);
	      }else{
	        intNumeroFoto=1;
	      }
	      if (Request["NumeroDocumento"]!=null && Request["NumeroDocumento"].ToString()!=""){
	        intNumeroDocumento=Convert.ToInt32(Request["NumeroDocumento"]);
	      }else{
	        intNumeroDocumento=1;
	      }
          Dictionary<string, object> frm = new Dictionary<string, object>();
          if (Smartdesk.Current.Request("Prodotti_PubblicaWEB") == "") frm.Add("Prodotti_PubblicaWEB", false);
          if (Smartdesk.Current.Request("Prodotti_InVetrina") == "") frm.Add("Prodotti_InVetrina", false);
          if (Smartdesk.Current.Request("Prodotti_InOfferta") == "") frm.Add("Prodotti_InOfferta", false);
          if (Smartdesk.Current.Request("Prodotti_InPromozione") == "") frm.Add("Prodotti_InPromozione", false);
          if (Smartdesk.Current.Request("Prodotti_Outlet") == "") frm.Add("Prodotti_Outlet", false);
          if (Smartdesk.Current.Request("Prodotti_Recensioni") == "") frm.Add("Prodotti_Recensioni", false);
          if (Smartdesk.Current.Request("Prodotti_Magazzino") == "") frm.Add("Prodotti_Magazzino", false);
      	  //Response.Write(Smartdesk.Current.Request("Prodotti_Faq"));
          strKy = Smartdesk.Functions.SqlWriteKey("Prodotti", frm);
	      strProdotti_Ky=strKy;
          strUrlKey=Smartdesk.Current.Request("Prodotti_UrlKey");
          if (strUrlKey==null || strUrlKey.Length<2){
            strUrlKey = Smartdesk.Current.Request("Prodotti_Titolo").ToLower().Replace(" ","-").Replace("/","").Replace("à","a").Replace("è","e").Replace("ì","i").Replace("ò","o").Replace("ù","u") + "-" + strKy;
            aggiornaUrlKey(strUrlKey);
          }
	      caricafiles();
	      //Response.Write(Request.Files.AllKeys.Length);
		  //Response.Write("fotoprodotto:" + Request["fotoprodotto"]);
		  Response.Redirect("/admin/app/catalogo/scheda-prodotto.aspx?salvato=salvato&Prodotti_Ky=" + strProdotti_Ky);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public void caricafiles()
    {
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
          Response.Write(myFiles.Length);
          for ( int i = 0; i < myFiles.Length; i++ ) {
			  if (Request.Files[i].FileName !=""){
				if (Request.Files[i].ContentType=="image/jpeg"){
    				  strFileName=Server.MapPath("/uploads/foto-prodotti/" + strProdotti_Ky + "-" + intNumeroFoto + ".jpg");
    	              Request.Files.Get(i).SaveAs(strFileName);
    	              strProdotti_Foto1="/uploads/foto-prodotti/" + strProdotti_Ky + "-" + intNumeroFoto + ".jpg";
    	              strProdotti_Foto1s="/uploads/foto-prodotti/" + strProdotti_Ky + "-" + intNumeroFoto + ".jpg";
    	              aggiornaFoto(intNumeroFoto);
                      intNumeroFoto=intNumeroFoto+1;
				}
				if (Request.Files[i].ContentType=="application/pdf"){
                      strFileName=Server.MapPath("/uploads/allegati-prodotti/" + strProdotti_Ky + "-" + intNumeroDocumento + ".pdf");
    	              Request.Files.Get(i).SaveAs(strFileName);
    	              strProdotti_Documento="/uploads/allegati-prodotti/" + strProdotti_Ky + "-" + intNumeroDocumento + ".pdf";
                        aggiornaDocumento(intNumeroDocumento);
                        intNumeroDocumento=intNumeroDocumento+1;
				}
              }      
          }
      }
    }

    public bool aggiornaDocumento(int intNumeroDocumentoPar)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Prodotti SET Prodotti_Documento" + intNumeroDocumentoPar + "='" + strProdotti_Documento + "' WHERE Prodotti_Ky = " + strProdotti_Ky;
        //Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }

    public bool aggiornaFoto(int intNumeroFotoPar)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Prodotti SET ";
        strSQL+= " Prodotti_Foto" + intNumeroFotoPar + "s='" + strProdotti_Foto1s + "',";
        strSQL+= " Prodotti_Foto" + intNumeroFotoPar + "='" + strProdotti_Foto1 + "'";
        strSQL+= " WHERE Prodotti_Ky = " + strProdotti_Ky;
        //Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }

    public bool aggiornaUrlKey(string strUrlKey)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Prodotti SET Prodotti_UrlKey='" + strUrlKey + "' WHERE Prodotti_Ky=" + strProdotti_Ky;
        //Response.Write(strSQL);
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}
