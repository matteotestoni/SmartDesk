using System;
using System.Data;
using HtmlAgilityPack;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public DataTable dtAnagrafiche;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strHtml = "";
    public string strLog = "";
    public DateTime dt;
    public bool boolLogoOk = false;
    public string strNomeFile = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strWHERENet = "";
        string strUrl = "";
        string strValue = "";
        string strUri = "";
        int intPosizione = 0;

        
        
        strWHERENet = "(LEN(Anagrafiche_SitoWeb)>1) AND (Anagrafiche_SitoWeb Is Not Null) AND (Anagrafiche_Disdetto Is Null OR Anagrafiche_Disdetto=0)";
        dtAnagrafiche = new DataTable("Anagrafiche");
        dtAnagrafiche = Smartdesk.Sql.getTablePage("Anagrafiche", null, "Anagrafiche_Ky", strWHERENet, "Anagrafiche_Ky", 1, 500,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        for (int i = 0; i < dtAnagrafiche.Rows.Count; i++)
        {
            boolLogoOk = false;
            strUrl = dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString();
            if (strUrl != null && strUrl.Length > 7)
            {
                if (strUrl.Substring(0, 7) != "http://" && strUrl.Substring(0, 8) != "https://")
                {
                    strUrl = "https://" + strUrl;
                    aggiornaLogo("Anagrafiche_SitoWeb", strUrl, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                }
                //Response.Write("<hr>");
                //Response.Write(strUrl + "<br>");
                try
                {
                    HtmlAgilityPack.HtmlWeb webGet = new HtmlAgilityPack.HtmlWeb();
                    HtmlAgilityPack.HtmlDocument document = webGet.Load(strUrl);
                    //Response.Write("<hr><strong>rilevo social</strong><br>");
                    foreach (HtmlAgilityPack.HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        strValue = link.Attributes["href"].Value;
                        //facebook
                        intPosizione = strValue.IndexOf("facebook.com");
                        if (intPosizione >= 0)
                        {
                            aggiornaSocial("Anagrafiche_Facebook", strValue, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                            //Response.Write("facebook:" + strValue + "<br>");
                        }
                        //instagram
                        intPosizione = strValue.IndexOf("instagram.com");
                        if (intPosizione >= 0)
                        {
                            aggiornaSocial("Anagrafiche_Instagram", strValue, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                            //Response.Write("instagram:" + strValue + "<br>");
                        }

                        //youtube
                        intPosizione = strValue.IndexOf("youtube.com");
                        if (intPosizione >= 0)
                        {
                            aggiornaSocial("Anagrafiche_Youtube", strValue, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                            //Response.Write("Youtube:" + strValue + "<br>");
                        }
                        //google mybusiness
                        intPosizione = strValue.IndexOf("/maps/place");
                        if (intPosizione >= 0)
                        {
                            aggiornaSocial("Anagrafiche_Mybusiness", strValue, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                            //Response.Write("Mybusiness:" + strValue + "<br>");
                        }
                        //pinterest
                        intPosizione = strValue.IndexOf("pinterest.com");
                        if (intPosizione >= 0)
                        {
                            aggiornaSocial("Anagrafiche_Pinterest", strValue, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                            //Response.Write("Pinterest:" + strValue + "<br>");
                        }
                        //twitter
                        intPosizione = strValue.IndexOf("twitter.com");
                        if (intPosizione >= 0)
                        {
                            aggiornaSocial("Anagrafiche_Twitter", strValue, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                            //Response.Write("Twitter:" + strValue + "<br>");
                        }
                        //linkedin
                        intPosizione = strValue.IndexOf("linkedin.com");
                        if (intPosizione >= 0)
                        {
                            aggiornaSocial("Anagrafiche_Linkedin", strValue, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                            //Response.Write("Linkedin:" + strValue + "<br>");
                        }
                    }
                    //Response.Write("<br><strong>rilevo logo<strong><br>");
                    foreach (HtmlAgilityPack.HtmlNode link in document.DocumentNode.SelectNodes("//img/@src"))
                    {
                        strValue = link.Attributes["src"].Value;
                        strNomeFile = Path.GetFileName(strValue);
                        Uri baseUri = new Uri(strUrl);
                        strUri = new Uri(baseUri, strValue).AbsoluteUri;
                        if (strNomeFile == "logo.gif" || strNomeFile == "logo.png" || strNomeFile == "logo.jpg" || strNomeFile.IndexOf("logo-") >= 0)
                        {
                            aggiornaLogo("Anagrafiche_Logo", strUri, dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
                            Response.Write("Logo:" + strValue + "<br>");
                            boolLogoOk = true;
                            break;
                        }
                    }
                }
                catch
                {
                    Response.Write("errore");
                }
            }
        }
    }

    public bool aggiornaLogo(string strField, string strUrl, string strAnagrafiche_Ky)
    {
        string strSQL = "";
        bool output = false;
        strSQL = "UPDATE Anagrafiche SET " + strField + " ='" + strUrl + "' WHERE Anagrafiche_Ky = " + strAnagrafiche_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }


    public bool aggiornaSocial(string strField, string strUrl, string strAnagrafiche_Ky)
    {
        string strSQL = "";
        bool output = false;
        strSQL = "UPDATE Anagrafiche SET " + strField + " ='" + strUrl + "' WHERE Anagrafiche_Ky = " + strAnagrafiche_Ky;
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        return output;
    }
}
