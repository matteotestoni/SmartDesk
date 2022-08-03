using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    public string strMetaDescription = "";
    public string strMetaKeywords = "";
    public string strMetaRobots = "noindex,nofollow";
    public string strH1 = "";
    public string strP1 = "";
    public string strTitle = "";
    public int i = 0;
    public int intNumRecords = 0;
    public DataTable dtVeicolo;
    public DataRow drVeicolo;
    public string strVeicoli_Ky="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    private string strAnnuncioMeta = "";
    private string strInviato = "";
    public string VeicoliTipo_Ky = "1"; // 1 - Auto , 2 - Moto
    public string strCategoriaWEB = "";
    public string strRequestUrl = "";
    public string strPage = "";
    public string strRequestUrlPage = "";
    public string strVeicoliCategoria_Ky = "";
    public string strRequestUrlBack = "";
    public int VeicoloCaratteristicheCount=2;
    public int VeicoloMiniatureCount = 1;
        
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    public string strNominativo="";
    
    

  protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        string strWHERENet="";
        string strFROMNet = "";
        string strORDERNet = "";
    
    	  
    	  
        //verifico se ho fatto login
        if(Request.Cookies["rswcrm-az"] != null)
        {
            strUtentiLogin = Server.HtmlEncode(Request.Cookies["rswcrm-az"].Value);
            strWHERENet = "Utenti_Ky =" + strUtentiLogin;
            strORDERNet = "Utenti_Ky";
            strFROMNet = "Utenti_Vw";
            dtLogin = new DataTable("Login");
            dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtLogin.Rows.Count>0){
              boolLogin=true;
              strLogin="<a href=\"/account/area-personale.html\" class=\"login\">" + dtLogin.Rows[0]["Utenti_Email"].ToString() + "</a> | <a href=\"/logout.aspx\" class=\"login\">Esci</a>";
            }else{
              boolLogin=false;
              strLogin="<a class=\"login\" href=\"/account/login.html\">>> accedi all'area riservata</a>";
            }
        }else{
          boolLogin=false;
          strLogin="<a class=\"login\" href=\"/account/login.html\">>> accedi all'area riservata</a>";
        }
        strPage = Request["page"];
        strRequestUrl = Request["url"];
        strRequestUrlPage = Request.RawUrl;
        strRequestUrlBack = Request["urlback"] + "?page="+Request["page"];
        strVeicoli_Ky= Request["Veicoli_Ky"];
        strInviato= Request["inviato"];
        strWHERENet="Veicoli_Ky=" + strVeicoli_Ky;
        strFROMNet = "Veicoli_SchedaWeb_Vw";
        strORDERNet = "Veicoli_Ky";
        strVeicoliCategoria_Ky = Request["VeicoliCategoria_Ky"];
        dtVeicolo = new DataTable("auto");
        dtVeicolo = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtVeicolo.Rows.Count>0){
          drVeicolo = dtVeicolo.Rows[0];
          strTitle="";
          if (drVeicolo["VeicoliMarca_Descrizione"].ToString().Length>0){
            strTitle+=" " + drVeicolo["VeicoliMarca_Descrizione"].ToString();
            strH1+=drVeicolo["VeicoliMarca_Descrizione"].ToString();
          }
          if (drVeicolo["Veicoli_Modello"].ToString().Length>0){
            strTitle+=" " + drVeicolo["Veicoli_Modello"].ToString();
            strH1+=" " + drVeicolo["Veicoli_Modello"].ToString();
          }
          strTitle+=" usato";
          strH1=strTitle;
          strMetaDescription = strTitle + " | " + strAnnuncioMeta.Trim();
          strAnnuncioMeta=Server.HtmlEncode(drVeicolo["Veicoli_Annuncio"].ToString().Trim());
          if (strAnnuncioMeta.Length>300){
            strAnnuncioMeta=strAnnuncioMeta.Substring(0,300);
          }
          strP1=" in vendita.";
          aggiornaStatistiche();
        }else{
          Response.Redirect("/home.aspx");
        }        
    }

    public bool aggiornaStatistiche()
    {
        DataTable dtStatistiche;
        string strSQL="";
        bool output = false;
        if (Request.ServerVariables["HTTP_USER_AGENT"].Contains("Googlebot")==false){        
                output = false;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable("getTable");
                SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
                SqlCommand cm = new SqlCommand();
                SqlParameter pm = null;
                strSQL="UPDATE Veicoli SET Veicoli_Visite=Veicoli_Visite+1 WHERE Veicoli_Ky='" + strVeicoli_Ky + "'";
                //Response.Write(strSQL);
                cm.CommandText = strSQL;
                cm.CommandType = CommandType.Text;
                cm.Connection = cn;
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
       }else{
         output = true;
       }
       return output;
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
    }

    public string VeicoloCaratteristiche(string Descrizione, string Field)
    {
        string html = "";
        if ((drVeicolo[Field].ToString() != "") && (drVeicolo[Field].ToString() != "0"))
        {
            html = "<div class=\"legenda" + VeicoloCaratteristicheCount.ToString() + "\"><div class=\"lbl\">" + Descrizione + ":</div><div class=\"lbl2\">";
            html += "<strong>" + drVeicolo[Field].ToString().Trim() + "</strong></div></div>";
            VeicoloCaratteristicheCount++;
            if (VeicoloCaratteristicheCount > 2) VeicoloCaratteristicheCount=1;
        }
        return html;
    }

    public string VeicoloCaratteristicheInt(string Descrizione, string Field)
    {
        string html = "";
        if ((drVeicolo[Field].ToString() != "") && (drVeicolo[Field].ToString() != "0"))
        {
            html = "<div class=\"legenda" + VeicoloCaratteristicheCount.ToString() + "\"><div class=\"lbl\">" + Descrizione + ":</div><div class=\"lbl2\">";
            html += "<strong>" +  ((int)drVeicolo[Field]).ToString("N0", ci) + "</strong></div></div>";
            VeicoloCaratteristicheCount++;
            if (VeicoloCaratteristicheCount > 2) VeicoloCaratteristicheCount=1;
        }
        return html;
    }

    public string VeicoloMiniature(string Field, int width, int height)
    {
        return VeicoloMiniature(Field, Field, width, height);
    }
    public string VeicoloFotoPrincipale(string Field, string FieldHref, int width, int height)
    {
        string html = "";
        if (drVeicolo[Field].ToString().Length > 0 )
        {
            html = "";
            if (drVeicolo[FieldHref].ToString().Length > 0)
            {
                html += "<a style=\"cursor:hand;cursor:pointer\" href=\"" + drVeicolo[FieldHref].ToString() + "\"";
                html += "rel=\"gallery[myset]\" class=\"lightview\" id=\"f" + VeicoloMiniatureCount.ToString() + "\"";
                html += ">";
            }
            html +="<img src=\""+ drVeicolo[Field].ToString() + "\"";
            html += "border=\"0\" width=\"" + width.ToString()+"\" height=\""+ height.ToString() + "\" hspace=\"2\" vspace=\"2\" align=\"left\"  ";
            html += "></a>";
            html += "";
            VeicoloMiniatureCount++;
        }else{
            html ="<img src=\"/images/camion/no-image-annuncio.gif\" border=\"0\" width=\"" + width.ToString()+"\" height=\""+ height.ToString() + "\" hspace=\"2\" vspace=\"2\" align=\"left\">";
        }
        return html;
    }
    public string VeicoloMiniature(string Field, string FieldHref, int width, int height)
    {
        string html = "";
        if (drVeicolo[Field].ToString().Length > 0 )
        {
            html = "<div>";
            if (drVeicolo[FieldHref].ToString().Length > 0)
            {
                html += "<a style=\"cursor:hand;cursor:pointer\" href=\"" + drVeicolo[FieldHref].ToString() + "\"";
                html += "rel=\"gallery[myset]\" class=\"lightview\" id=\"f" + VeicoloMiniatureCount.ToString() + "\"";
                html += ">";
            }
            html +="<img src=\""+ drVeicolo[Field].ToString() + "\"";
            html += "border=\"0\" width=\"" + width.ToString()+"\" height=\""+ height.ToString() + "\" hspace=\"2\" vspace=\"2\" align=\"left\"  ";
            html += "></a>";
            html += "</div>";
            VeicoloMiniatureCount++;
        }
        return html;
    }

    public string VeicoloCaratteristichePrezzo(string Descrizione, string Field,string FieldCheck)
    {
        string html = "", prezzo="";
        if ((drVeicolo[FieldCheck].Equals(true)) || (drVeicolo[FieldCheck].Equals(null)) || (drVeicolo[Field].ToString() == "0,0000"))
                  {
             prezzo="<small>Trattativa&nbsp;riservata</small>";
          }
          else
          { 
            prezzo= "<b>&euro; " + ((decimal)dtVeicolo.Rows[i][Field]).ToString("N0", ci)+"</b>";
          }         
        if (drVeicolo["ImposizioniIVA_Ky"].ToString() == "1")
        {
            prezzo += " Iva deducibile";
        }
        if (drVeicolo[Field].ToString() != "")
        {
            html = "<div class=\"legenda" + VeicoloCaratteristicheCount.ToString() + "\"><div class=\"lbl\">" + Descrizione + ":</div><div class=\"lbl2\">";
            html += "<strong>" + prezzo + "</strong></div></div>";
            VeicoloCaratteristicheCount++;
            if (VeicoloCaratteristicheCount > 2) VeicoloCaratteristicheCount = 1;
        }
        return html;
    }
}
