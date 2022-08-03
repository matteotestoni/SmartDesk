using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    public string strMetaDescription = "";
    public string strH1 = "";
    public string strP1 = "";
    public string strTitle = "";
    public int i = 0;
    public int intNumRecords = 0;
    public DataTable dtCasa;
    public string strImmobili_Ky="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    private string strAnnuncioMeta = "";
    private string strInviato = "";
    public string strScheda="";
    public string strCanonical="";
    public string strIndirizzo="";
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        string strWHERENet="";
        string strFROMNet = "";
        string strORDERNet = "";
        string strImmobili_Ky="";
    
    	  
    	  
        strImmobili_Ky= Request["Immobili_Ky"];
        if (strImmobili_Ky==null || strImmobili_Ky.Length<1){
          //Response.RedirectPermanent("/home.aspx");
        }else{
                strInviato= Request["inviato"];
                strWHERENet="Immobili_Ky=" + strImmobili_Ky;
                strFROMNet = "Immobili_SchedaWeb_Vw";
                strORDERNet = "Immobili_Ky";
                dtCasa = new DataTable("casa");
                dtCasa = Smartdesk.Sql.getTablePage(strFROMNet, null, "Immobili_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtCasa.Rows.Count>0){
		          
				    if (!(dtCasa.Rows[0]["Immobili_IndirizzoNascondi"].Equals(true)) && dtCasa.Rows[0]["Immobili_Indirizzo"].ToString().Length>0){
		              strIndirizzo=dtCasa.Rows[0]["Comuni_Comune"].ToString().Replace("'","\'") + "," + dtCasa.Rows[0]["Province_Codice"].ToString() + ",Italia";
		          }else{
		              strIndirizzo=dtCasa.Rows[0]["Utenti_Indirizzo"].ToString().Trim() + "," + dtCasa.Rows[0]["ComuneVenditore"].ToString().Trim() + ",Italia";
		          }

                  strCanonical="http://immobiliare.smartannunci.it/" + dtCasa.Rows[0]["Province_ProvinciaHTML"].ToString().Trim().ToLower() + "/" + dtCasa.Rows[0]["Province_ProvinciaHTML"].ToString().Trim().ToLower() + "_affitti-vendite.html";
                  strScheda="http://immobiliare.smartannunci.it/" + dtCasa.Rows[0]["Province_ProvinciaHTML"].ToString().Trim();
                  strScheda+="/" + dtCasa.Rows[0]["ImmobiliCategoria_Descrizione"].ToString().Trim();
                  if (dtCasa.Rows[0]["Immobili_Turistico"].Equals(true)){
                    strScheda+="-vacanza";
                  }
                  if (dtCasa.Rows[0]["Immobili_NuovaCostruzione"].Equals(true)){
                    strScheda+="-nuova-costruzione";
                  }
                  strScheda+="-" + dtCasa.Rows[0]["ImmobiliTipologia_DescrizioneHTML"].ToString().Trim();
                  strScheda+="-" + dtCasa.Rows[0]["Comuni_ComuneHTML"].ToString().Trim();
                  strScheda+="_" + dtCasa.Rows[0]["Immobili_Ky"].ToString().Trim() + "_1.html";


                  strTitle=dtCasa.Rows[0]["ImmobiliTipologia_Descrizione"].ToString();
                  if (dtCasa.Rows[0]["ImmobiliCategoria_Descrizione"].ToString().Length>0){
                    strTitle+=" in " + dtCasa.Rows[0]["ImmobiliCategoria_Descrizione"].ToString().Trim();
                  }
                  if (dtCasa.Rows[0]["ImmobiliZona_Descrizione"].ToString().Length>0){
                    strTitle+=" a " + dtCasa.Rows[0]["ImmobiliZona_Descrizione"].ToString();
                  }
                  if (dtCasa.Rows[0]["Comuni_Comune"].ToString().Length>0){
                    strTitle+=" " + dtCasa.Rows[0]["Comuni_Comune"].ToString();
                  }
                  if ((dtCasa.Rows[0]["Province_Provincia"].ToString().Length>0) && !(dtCasa.Rows[0]["Province_Provincia"].Equals(dtCasa.Rows[0]["Comuni_Comune"]))){
                    strTitle+=" in provincia di " + dtCasa.Rows[0]["Province_Provincia"].ToString();
                  }
                  if (dtCasa.Rows[0]["Immobili_Indirizzo"].ToString().Length>0){
                    strTitle+=" " + dtCasa.Rows[0]["Immobili_Indirizzo"].ToString();
                  }
                  strH1=strTitle;
                  if ((dtCasa.Rows[0]["Immobili_ValoreNascondi"].Equals(true)) || (dtCasa.Rows[0]["Immobili_Valore"].Equals(null)))
                  {
                    strTitle+=" in trattativa riservata";
                  }
                  else
                  { 
                    strTitle+=" a &euro; " + ((decimal)dtCasa.Rows[i]["Immobili_Valore"]).ToString("N0", ci);
                  }                        
                  strAnnuncioMeta=Server.HtmlEncode(dtCasa.Rows[0]["Immobili_Annuncio"].ToString().Trim());
                  if (strAnnuncioMeta.Length>200){
                    strAnnuncioMeta=strAnnuncioMeta.Substring(0,200);
                  }
                  strMetaDescription = strTitle + " | " + strAnnuncioMeta.Trim();
                  strP1=" " + dtCasa.Rows[0]["Immobili_NumeroLocali"].ToString() + " locali";
        
                  if (((dtCasa.Rows[0]["Immobili_NumeroBagni"]).ToString().Length>0) && (dtCasa.Rows[0]["Immobili_NumeroBagni"].ToString()!="0")){
                    strP1+=", " + (dtCasa.Rows[0]["Immobili_NumeroBagni"]).ToString() + " bagni";
                  }
                  if (((dtCasa.Rows[0]["Immobili_NumeroCamereLetto"]).ToString().Length>0) && (dtCasa.Rows[0]["Immobili_NumeroCamereLetto"].ToString()!="0")){
                    strP1+=", " + (dtCasa.Rows[0]["Immobili_NumeroCamereLetto"]).ToString()  + " camere da letto";
                  }
                  if (((dtCasa.Rows[0]["Immobili_Mq"]).ToString().Length>0) && (dtCasa.Rows[0]["Immobili_Mq"].ToString()!="0")){
                    strP1+=", " + (dtCasa.Rows[0]["Immobili_Mq"]).ToString().Replace(",0000","")  + " mq";
                  }
                }else{
                  //Response.RedirectPermanent("/home.aspx");
                } 
        }       
    }
}
