using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{    
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    
    
    public string strAnnunci_Ky="";
    public string strAste_Ky="";
    public string strAsteEsperimenti_Ky="";
    public DataTable dtAnnuncio;
    public DataTable dtWishlist;
    public DataTable dtAnnunciOfferte;
    public DataTable dtAnagrafiche;
    public DataTable dtAste;
    public DataTable dtAsteEsperimenti;
    public DataTable dtAsteProxyBid;
    public string strSQL = "";
    public string strAsteProxyBid_ValoreMax = ""; 
    public int intNumRecords = 0;
    public int intRilancioMinimo = 0;
    public int intValoreMinimo = 0;
    public string strAnagrafiche_Ky_Vincitrice="";

    protected void Page_Load(object sender, EventArgs e){
      string strWHERENet = "";
      string strORDERNet = "";
      string strFROMNet = "";
      bool boolOffertaValida=false;
      string strHtml = "";
      string strOggetto = "";
      string strKy = "";
      string strDate = "";

      
      
      strAnnunci_Ky=Request["Annunci_Ky"];
      strAste_Ky=Request["Aste_Ky"];
      strAsteEsperimenti_Ky=Request["AsteEsperimenti_Ky"];

      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
              strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky + " AND AsteEsperimenti_DataTermine>GETDATE()";
              dtAsteEsperimenti = new DataTable("AsteEsperimenti");
              dtAsteEsperimenti = Smartdesk.Sql.getTablePage("AsteEsperimenti", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			  if (dtAsteEsperimenti!=null && dtAsteEsperimenti.Rows.Count>0){
					  strAsteProxyBid_ValoreMax=Request["AsteProxyBid_ValoreMax"];
	                  strAsteProxyBid_ValoreMax=strAsteProxyBid_ValoreMax.Replace(".","");
	                  strWHERENet = "Annunci_Ky=" + strAnnunci_Ky;
	                  dtAnnuncio = new DataTable("Annuncio");
	                  dtAnnuncio = Smartdesk.Sql.getTablePage("Annunci", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	                  if (dtAnnuncio.Rows.Count>0 && strAsteProxyBid_ValoreMax.Length>0){
	                    intRilancioMinimo=Convert.ToInt32(dtAnnuncio.Rows[0]["Annunci_Rilancio"]);
	                    //Response.Write("Rilancio minimo:" + intRilancioMinimo + "<br>");
	                    strWHERENet = "Annunci_Ky=" + strAnnunci_Ky;
	                    strORDERNet = "AnnunciOfferte_Ky DESC";
	                    dtAnnunciOfferte = new DataTable("AnnunciOfferte");
	                    dtAnnunciOfferte = Smartdesk.Sql.getTablePage("AnnunciOfferte", null, "AnnunciOfferte_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	                    if (dtAnnunciOfferte.Rows.Count>0){
	                        intValoreMinimo=Convert.ToInt32(dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"])+intRilancioMinimo;
	                        //Response.Write(dtAnnunciOfferte.Rows.Count + " offerte. Valore:" + Convert.ToInt32(dtAnnunciOfferte.Rows[0]["AnnunciOfferte_Valore"]) + "<hr>");
	                        if (Convert.ToInt32(strAsteProxyBid_ValoreMax)>=intValoreMinimo){
	                          boolOffertaValida=true;
	                        }
	                    }else{
	                        intValoreMinimo=Convert.ToInt32(dtAnnuncio.Rows[0]["Annunci_Valore"]);
	                        //Response.Write("nessuna offerta. Valore:" + Convert.ToInt32(dtAnnuncio.Rows[0]["Annunci_Valore"]) + "<hr>");
	                        if (Convert.ToInt32(strAsteProxyBid_ValoreMax)>=intValoreMinimo){
	                          boolOffertaValida=true;
	                        }
	                    }
	                    //Response.Write(boolOffertaValida + "<hr>");
	                    if (boolOffertaValida){
						  strKy = Smartdesk.Functions.SqlWriteKey("AsteProxyBid");
	                      
				          //ci sono proxybid maggiori del rilancio?
						  strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky + " AND Annunci_Ky=" + strAnnunci_Ky + " AND AsteProxyBid_ValoreMax>=" + intRilancioMinimo;
				          strORDERNet = "AsteProxyBid_ValoreMax DESC";
				          strFROMNet = "AsteProxyBid";
				          dtAsteProxyBid = new DataTable("AsteProxyBid");
				          dtAsteProxyBid = Smartdesk.Sql.getTablePage(strFROMNet, null, "AsteProxyBid_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				          if (dtAsteProxyBid!=null && dtAsteProxyBid.Rows.Count>0){
					          	//Response.Write("Numero proxybid:" + dtAsteProxyBid.Rows.Count + "<br>");
 								//Response.Write("Valore proxy bid 0:" + dtAsteProxyBid.Rows[0]["AsteProxyBid_ValoreMax"].ToString() + "<br>");								  
								if (dtAsteProxyBid.Rows.Count==1){
					          	  Response.Write("1 proxybid");
					          	  //c'è un solo proxybid cioè quello appena fatto
								  strAnagrafiche_Ky_Vincitrice=strUtentiLogin;
								  strSQL="INSERT INTO AnnunciOfferte (Anagrafiche_Ky, Annunci_Ky, Aste_Ky, AsteEsperimenti_Ky, AnnunciOfferte_Data, AnnunciOfferte_Millisecondi, AnnunciOfferte_Valore, AnnunciOfferte_Proxybid, AsteProxyBid_Ky) ";
			                      strSQL+=" VALUES (";
			                      strSQL+=strAnagrafiche_Ky_Vincitrice + ",";
			                      strSQL+=strAnnunci_Ky + ",";
			                      strSQL+=strAste_Ky + ",";
			                      strSQL+=strAsteEsperimenti_Ky + ",";
			                      strSQL+="GETDATE(),";
			                      strSQL+="DATEPART(millisecond,GETDATE()),";
			                      strSQL+=Convert.ToInt32(intValoreMinimo) + ",";
			                      strSQL+="1,";
			                      strSQL+=dtAsteProxyBid.Rows[0]["AsteProxyBid_Ky"].ToString();
			                      strSQL+=")";
			                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
					          	}
	
					          	if (dtAsteProxyBid.Rows.Count>=2){
                            //Response.Write("Valore proxy bid 1:" + dtAsteProxyBid.Rows[1]["AsteProxyBid_ValoreMax"].ToString() + "<br>");
                            //Response.Write("2 proxybid");
                            //+ di 1 proxy bid. Valgono i 2 più grandi
                            //il primo proxybid vince mentre il secondo non esiste perchè l'ho già superato con una puntata proxybid
          								  intValoreMinimo=Convert.ToInt32(dtAsteProxyBid.Rows[1]["AsteProxyBid_ValoreMax"]) + intRilancioMinimo;  
          								  strAnagrafiche_Ky_Vincitrice=dtAsteProxyBid.Rows[0]["Anagrafiche_Ky"].ToString();
          								  //inserisco offerta del proxybid vincente
          								  strSQL="INSERT INTO AnnunciOfferte (Anagrafiche_Ky, Annunci_Ky, Aste_Ky, AsteEsperimenti_Ky, AnnunciOfferte_Data, AnnunciOfferte_Millisecondi, AnnunciOfferte_Valore, AnnunciOfferte_Proxybid, AsteProxyBid_Ky) ";
			                      strSQL+=" VALUES (";
			                      strSQL+=strAnagrafiche_Ky_Vincitrice + ",";
			                      strSQL+=strAnnunci_Ky + ",";
			                      strSQL+=strAste_Ky + ",";
			                      strSQL+=strAsteEsperimenti_Ky + ",";
			                      strSQL+="GETDATE(),";
			                      strSQL+="DATEPART(millisecond,GETDATE()),";
			                      strSQL+=Convert.ToInt32(intValoreMinimo) + ",";
			                      strSQL+="1,";
			                      strSQL+=dtAsteProxyBid.Rows[0]["AsteProxyBid_Ky"].ToString();
			                      strSQL+=")";
			                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
					          	}
		                      //se scade entro 5 minuti aggiorno la scadenza dell'asta
		                      strSQL="UPDATE AsteEsperimenti SET ";
		                      strSQL+="AsteEsperimenti_DataTermine=DATEADD(minute,5,GETDATE()),";
		                      strSQL+="AsteEsperimenti_DataChiusura=DATEADD(minute,5,GETDATE())";
		                      strSQL+=" WHERE";
		                      strSQL+=" (AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky + ")";
		                      strSQL+=" AND (datediff(minute, AsteEsperimenti_DataTermine, GETDATE())>=-5)";
		                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
		
		                      //se non è in wishlist devo inserirlo
		                      strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin + " AND Annunci_Ky=" + strAnnunci_Ky + " AND Aste_Ky=" + strAste_Ky;
		                      strORDERNet = "Wishlist_Ky DESC";
		                      dtWishlist = new DataTable("Wishlist");
		                      dtWishlist = Smartdesk.Sql.getTablePage("Wishlist", null, "Wishlist_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		                      if (dtWishlist.Rows.Count<1){
		                        strSQL="INSERT INTO Wishlist (Anagrafiche_Ky, Annunci_Ky, Aste_Ky, Wishlist_Data, Wishlist_DateInsert, Wishlist_DateUpdate)";
		                        strSQL+=" VALUES (" + strUtentiLogin + "," + strAnnunci_Ky + "," + strAste_Ky + ",GETDATE(),GETDATE(),GETDATE())" ;
		                        //Response.Write(strSQL);
		                        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
		                      }
		                      //avviso tutti gli altri
		                      strWHERENet = "Aste_Ky=" + strAste_Ky;
		                      strORDERNet = "Aste_Ky DESC";
		                      dtAste = new DataTable("Aste");
		                      dtAste = Smartdesk.Sql.getTablePage("Aste", null, "Aste_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		
		                      strWHERENet = "AsteEsperimenti_Ky=" + strAsteEsperimenti_Ky + " AND Annunci_Ky=" + strAnnunci_Ky + " AND Aste_Ky=" + strAste_Ky;
		                      strORDERNet = "AnnunciOfferte_Ky DESC";
		                      dtAnagrafiche = new DataTable("Anagrafiche");
		                      dtAnagrafiche = Smartdesk.Sql.getTablePage("AnnunciOfferte_Anagrafiche_Vw", null, "AnnunciOfferte_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							            strHtml="";
		                      for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){
		                        if (dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()!=strAnagrafiche_Ky_Vincitrice){
		                          strOggetto="[ASTEBUSINESS] La tua offerta per il lotto nr " + dtAnnuncio.Rows[0]["Annunci_Numero"].ToString() + " dell'asta " + dtAste.Rows[0]["Aste_Numero"].ToString() + " è stata superata.";
		                          strHtml="<p>Stai perdendo l'asta per il lotto nr " + dtAnnuncio.Rows[0]["Annunci_Numero"].ToString() + "</p>";
		                          strHtml+="<p>Dettagli del lotto:";
		                          strHtml+="Titolo: " + dtAnnuncio.Rows[0]["Annunci_Titolo"].ToString() + "<br>";
		                          strHtml+="Numero: " + dtAnnuncio.Rows[0]["Annunci_Numero"].ToString() + "<br>";
		                          strHtml+="Scheda del lotto: <a href=\"https://www.astebusiness.it/scheda-lotto.aspx?Annunci_Ky=" + dtAnnuncio.Rows[0]["Annunci_Ky"].ToString() + "\">clicca qui</a><br>";
		                          strHtml+="</p>";
		                          inviaPromemoriaOfferta(dtAnagrafiche.Rows[i]["Anagrafiche_EmailContatti"].ToString(), strOggetto, strHtml, null);
		                        }
		                      }
		                      Response.Redirect("/frontend/base/aste/scheda-lotto.aspx?Annunci_Ky=" + strAnnunci_Ky);
		                    }else{
		                      Response.Redirect("/frontend/base/aste/scheda-lotto.aspx?errore=Valore%20non%20valido&Annunci_Ky=" + strAnnunci_Ky);
		                    }
      						  }else{
      						  	//nessun proxy bid. Impossibile visto che l'ho appena inserito. Vado in errore
      		                    Response.Redirect("/frontend/base/scheda-lotto.aspx?errore=Impossibile%20inserire%20un%20proxybid&Annunci_Ky=" + strAnnunci_Ky);
      						  }
                  }else{
                    Response.Redirect("/home.aspx");
                  }
            }else{
              Response.Redirect("/frontend/base/aste/scheda-lotto.aspx?errore=Asta%20scaduta&Annunci_Ky=" + strAnnunci_Ky);
            }
          }else{
            Response.Redirect("/frontend/base/aste/scheda-lotto.aspx?errore=Non%20sei%20loggato&Annunci_Ky" + strAnnunci_Ky);
          }
      }else{
        Response.Redirect("/frontend/base/aste/scheda-lotto.aspx?errore=Non%20sei%20loggato&Annunci_Ky=" + strAnnunci_Ky);
      }
    }


    public bool inviaPromemoriaOfferta(string strMailTO,string strMailSubject,string strMailBody, string strAttach){
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new System.Net.Mail.MailAddress("noreply@astebusiness.it");
        mail.To.Add(new System.Net.Mail.MailAddress(strMailTO));
        mail.Subject = strMailSubject;
        mail.Body = strMailBody;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = System.Net.Mail.MailPriority.High;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(Smartdesk.Functions.getOption("core.serversmpt"), Convert.ToInt32(Smartdesk.Functions.getOption("core.serversmptport")));
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(Smartdesk.Functions.getOption("core.serversmptuser"), Smartdesk.Functions.getOption("core.serversmptpassword"));
        client.UseDefaultCredentials = false;
        client.Credentials = mailAuthentication;
        client.EnableSsl = Convert.ToBoolean(Smartdesk.Functions.getOption("core.serversmptssl"));
        //client.Send(mail);
        return true;
    }
}
