using System;
using System.Data;
using System.IO;

public partial class _Default : System.Web.UI.Page{

    
    
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtAnagrafiche;
    public int intNumRecords = 0;
    
    public string strAnagrafiche_Ky="";
    public string strSorgente="";
    public bool boolLogoOk = false;
    public string strNomeFile="";

	protected void Page_Load(object sender, EventArgs e){
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strUrl="";
      string strValue="";
      string strUri="";
      int intPosizione=0;

      
      
	  
      if (Smartdesk.Login.Verify){
      strSorgente=Smartdesk.Current.Request("sorgente");
      strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
      strWHERENet=getWhere();;
      strFROMNet = "Anagrafiche";
      strORDERNet = "Anagrafiche_RagioneSociale";
      dtAnagrafiche = new DataTable("Anagrafiche");
      dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1,1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			Response.Write(strWHERENet + "<hr>");
			for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){
				boolLogoOk=false;
				strUrl=dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString();
				if (strUrl!=null && strUrl.Length>7){
					if (strUrl.Substring(0, 7)!="http://" && strUrl.Substring(0, 8)!="https://"){
						strUrl="https://" + strUrl;
						aggiornaLogo("Anagrafiche_SitoWeb", strUrl,dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
					}
					Response.Write("<hr>");
					Response.Write(strUrl + "<br>");
			        try{
                HtmlAgilityPack.HtmlWeb webGet = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument document = webGet.Load(strUrl);
				        Response.Write("<hr><strong>rilevo social</strong><br>");
								foreach (HtmlAgilityPack.HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]")){
										strValue=link.Attributes["href"].Value;
										//facebook
										intPosizione=strValue.IndexOf("facebook.com");
										if (intPosizione>=0){
					        				aggiornaSocial("Anagrafiche_Facebook", strValue,dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
											    Response.Write("facebook:" + strValue + "<br>");
										}
                                        //instagram
                                        intPosizione = strValue.IndexOf("instagram.com");
                                        if (intPosizione >= 0)
                                        {
                                            aggiornaSocial("Anagrafiche_Instagram", strValue, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                                            Response.Write("instagram:" + strValue + "<br>");
                                        }

                                        //youtube
                                        intPosizione =strValue.IndexOf("youtube.com");
										if (intPosizione>=0){
					        				aggiornaSocial("Anagrafiche_Youtube", strValue,dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
											//Response.Write("Youtube:" + strValue + "<br>");
										}
										//google mybusiness
										intPosizione=strValue.IndexOf("/maps/place/");
										if (intPosizione>=0){
					        				aggiornaSocial("Anagrafiche_Mybusiness", strValue,dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                                            //Response.Write("Mybusiness:" + strValue + "<br>");
                                        }
                                        //pinterest
                                        intPosizione =strValue.IndexOf("pinterest.com");
										if (intPosizione>=0){
					        				aggiornaSocial("Anagrafiche_Pinterest", strValue,dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
											//Response.Write("Pinterest:" + strValue + "<br>");
										}
										//twitter
										intPosizione=strValue.IndexOf("twitter.com");
										if (intPosizione>=0){
					        				aggiornaSocial("Anagrafiche_Twitter", strValue,dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
											//Response.Write("Twitter:" + strValue + "<br>");
										}
										//linkedin
										intPosizione=strValue.IndexOf("linkedin.com");
										if (intPosizione>=0){
					        				aggiornaSocial("Anagrafiche_Linkedin", strValue,dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
											//Response.Write("Linkedin:" + strValue + "<br>");
										}
								}
								//Response.Write("<br><strong>rilevo logo<strong><br>");
								foreach (HtmlAgilityPack.HtmlNode link in document.DocumentNode.SelectNodes("//img/@src")){
										strValue=link.Attributes["src"].Value;
										strNomeFile=Path.GetFileName(strValue);
										
										Uri baseUri= new Uri(strUrl);
										//Response.Write("baseuri: " + baseUri + "<br>");
										//Response.Write(strValue + "<br>");
										strUri=new Uri(baseUri,strValue).AbsoluteUri;
										//Response.Write("uri: " + strUri + "<br>");

										//Response.Write(strValue + "<hr>");
										//Response.Write(strUri + "<hr>");
										
										if (strNomeFile=="logo.gif" || strNomeFile=="logo.png" || strNomeFile== "logo.jpg" || strNomeFile.IndexOf("logo-")>=0){
										  aggiornaLogo("Anagrafiche_Logo", strUri,dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
										  Response.Write("Logo 1:" + strValue + "<br>");
										  boolLogoOk=true;
										  break;
										}
								}                           
				        }catch{
					        Response.Write("errore");
						}
    				  }
					}
					/*
          switch (strSorgente){
						case "scheda-anagrafiche":
		          Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
							break;
						default:
		          Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
							break;
					}*/
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public string getWhere()
    {
        string strWHERE="";
        string strValue="";

        strWHERE="(Anagrafiche_SitoWeb Is Not Null) And (Anagrafiche_Disdetto Is Null or Anagrafiche_Disdetto=0)";
        strValue = Smartdesk.Current.Request("Anagrafiche_Ky");
        if (strValue != null && strValue != ""){
            strWHERE += " And (Anagrafiche_Ky=" + strValue + ")";
        }
        strValue = Request["tutti"];
        if (strValue != null && strValue != ""){
        	strWHERE="(Anagrafiche_SitoWeb Is Not Null) And (Anagrafiche_Disdetta Is Null or Anagrafiche_Disdetta=0)";
        }
        return strWHERE;
    }

	public bool aggiornaLogo(string strField, string strUrl, string strAnagrafiche_Ky)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Anagrafiche SET " + strField + " ='" + strUrl + "' WHERE Anagrafiche_Ky = " + strAnagrafiche_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }

	public bool aggiornaSocial(string strField, string strUrl, string strAnagrafiche_Ky)
    {
        string strSQL="";
        bool output = false;
        strSQL = "UPDATE Anagrafiche SET " + strField + " ='" + strUrl + "' WHERE Anagrafiche_Ky = " + strAnagrafiche_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}