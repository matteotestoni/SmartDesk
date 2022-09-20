using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;   
    public DataTable dtAziende;
    public DataTable dtPagamentiFuturi;
    public DataTable dtPagamentiScaduti;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public int intAnno = 0;
    public int intMese = 0;
    public DateTime dt;
    public string strFirma = "";
    public string strTipo = "";
    public string strTutti = "";
    public string strLivello = "";
    public string strAnteprima = "";
    public string strPagamenti_Ky = "";
    public string strRisultatoFuturi="";
    public string strRisultatoScaduti="";
    
    public string strH1 = "";
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strHTML="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strCorpo="";
      string strTo = "";
      string strSubject = "";
      string strOggi="";
      string strDataScadenza="";

		  
		  
	      
      dtAziende = Smartdesk.Data.Read("Aziende", "Aziende_Ky", "1");
      strFirma = dtAziende.Rows[0]["Aziende_FirmaEmail"].ToString();
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strH1="Esito di invio promemoria e solleciti";
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strTipo = Request["tipo"];
            strTutti = Request["tutti"];
            strLivello = Request["livello"];
            strAnteprima = Request["anteprima"];
            strPagamenti_Ky = Request["Pagamenti_Ky"];
            dt=DateTime.Now;
            int intYear=dt.Year;
            int intMonth=dt.Month;
            int intDay=dt.Day;
            strDataScadenza=intDay + "-" + intMonth + "-" + intYear;
			
						if (strTipo=="2"){
                strFROMNet = "Pagamenti_Vw";
                if (strAnteprima=="anteprima"){
        					   strWHERENet="(Pagamenti_Ky=" + strPagamenti_Ky + ")";
                }else{
                      if (strTutti=="tutti"){
      									strWHERENet="(Month(Pagamenti_Data)=" + intMonth + ") AND (Year(Pagamenti_Data)=" + intYear + ") AND (Pagamenti_Pagato!='si') AND (Pagamenti_Data>=(GETDATE()-1)) And (Pagamenti_AttivaPromemoria=1) AND (PagamentiTipo_Ky=1) And (Pagamenti_NumeroPromemoria=0)";
      								}else{
      									strWHERENet="(PagamentiTipo_Ky=1 AND Pagamenti_Ky=" + strPagamenti_Ky + ") And (Pagamenti_NumeroPromemoria=0)";
      								}
                }
                strORDERNet = "Anagrafiche_Ky DESC";
                dtPagamentiFuturi = new DataTable("AnagrafichePagamenti");
                dtPagamentiFuturi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
                strRisultatoFuturi="<table class=\"grid\">";
              	strRisultatoFuturi+="<tr><th width=\"20\"></th><th>Anagrafica</th><th>Tipo</th><th>Data invio</th><th>Scadenza</th><th>gg</th><th>Email di destinazione</th><th>Inviato tramite</th></tr>";
								for (int i = 0; i < dtPagamentiFuturi.Rows.Count; i++){
								  strSubject = "Promemoria prossima scadenza pagamento " + dtPagamentiFuturi.Rows[i]["DocumentiTipo_Descrizione"].ToString();
								  strCorpo="<table class=\"container\"><tbody><tr><td>\n";
								  strCorpo+="<table class=\"row\"><tr><td class=\"wrapper\">\n<table class=\"twelve cell\"><tr><td>\n";
                  strCorpo+="<p align=\"left\"><i>Importante: Questa mail viene spedita da un sistema automatico.</i></p>";
                  strCorpo+="<p align=\"left\"><strong>Rovigo, " + dt.ToString() + "</strong><br /><strong>Oggetto: " + strSubject + "</strong></p>";
                  strCorpo+="<br />Spettabile <strong>" + dtPagamentiFuturi.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</strong>,<br /><br />";
                  strCorpo+="con la presente le ricordiamo che &egrave; in scadenza il giorno <strong style=\"color:#ff0000\">" +  dtPagamentiFuturi.Rows[i]["Pagamenti_Data_IT"].ToString() + strOggi + "</strong> il pagamento della <strong>" + dtPagamentiFuturi.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtPagamentiFuturi.Rows[i]["Pagamenti_Riferimenti"].ToString() + "</strong> per un importo di <strong>" + dtPagamentiFuturi.Rows[i]["Pagamenti_Importo_IT"].ToString() + " &euro; IVA Compresa</strong>.";
                  strCorpo+="<p>La invitiamo a contattarci prontamente nel caso in cui non disponesse di una o pi&ugrave; fatture, ovvero qualora una o pi&ugrave; di esse siano oggetto di controversia.</p>";
                  strCorpo+="<p>Vi ricordiamo quindi di effettuare il prossimo pagamento tramite bonifico bancario con le seguenti coordinate:<br /><br />";
                  strCorpo+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"4\" style=\"border-collapse: collapse;\">";
                  strCorpo+="<tr><td>Banca:</td><td><strong>BANCA ANNIA CRED. COOP CARTURA E POLESINE</strong></td></tr>";
                  strCorpo+="<tr><td>EUR IBAN:</td><td><strong>IT23 H084 5212 2010 0000 0027 069</strong></td></tr>";
                  strCorpo+="<tr><td>Causale:</td><td><strong>" + dtPagamentiFuturi.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtPagamentiFuturi.Rows[i]["Documenti_Numero"].ToString() + " del " + dtPagamentiFuturi.Rows[i]["Documenti_Data_IT"].ToString() + "</strong></td></tr>";
                  strCorpo+="<tr><td>Importo:</td><td><strong>" + dtPagamentiFuturi.Rows[i]["Pagamenti_Importo_IT"].ToString() + " &euro;</strong></td></tr>";
                  strCorpo+="<tr><td>Entro il:</td><td><strong style=\"color:#ff0000\">" + dtPagamentiFuturi.Rows[i]["Pagamenti_Data_IT"].ToString() + "</strong></td></tr>";
                  strCorpo+="</table></p>";
                  strCorpo+="<p>Nota Bene: In caso di mancato pagamento dei servizi di hosting, registrazione domini e gestione caselle di posta questi non verranno rinnovati e termineranno di funzionare alla scadenza naturale pertanto ad esempio le <strong>caselle di posta non saranno pi&ugrave; funzionanti</strong>.</p></p>";
                  strCorpo+="Cordiali saluti,<br /><br />Amministrazione RSW Studio";
                  strCorpo+=strFirma;
								  strCorpo+="</td><td class=\"expander\"></td></tr>\n</table>\n</td></tr>\n</table>\n</td></tr>\n</tbody></table>\n";
				          strTo = dtPagamentiFuturi.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString();
									strHTML="<!DOCTYPE html>\n";
									strHTML+="<html>\n";
									strHTML+="<head>\n";
									strHTML+="<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\n";
									strHTML+="<title>" + strSubject + "</title>\n";
									strHTML+="<meta name=\"viewport\" content=\"width=device-width\"/>\n";
									strHTML+="<link href='https://fonts.googleapis.com/css?family=Google+Sans' rel='stylesheet' type='text/css' />\n";
									strHTML+="<style type=\"text/css\">\n";
									strHTML+="@import url(https://fonts.googleapis.com/css?family=Google+Sans:400,500,700);";
									strHTML+="#outlook a{padding:0; } body{font-family:\"Google Sans\";width:100% !important;   min-width:100%;  -webkit-text-size-adjust:100%;   -ms-text-size-adjust:100%;   margin:0;   padding:0;} .ExternalClass{width:100%;} .ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div{line-height:100%; } #backgroundTable{margin:0;   padding:0;   width:100% !important;   line-height:100% !important; } img{outline:none;   text-decoration:none;   -ms-interpolation-mode:bicubic;  width:auto;  max-width:100%;   float:left;   clear:both;   display:block;} center{width:100%;  min-width:580px;} a img{border:none;} p{margin:0 0 0 10px;} table{border-spacing:0;  border-collapse:collapse;} td{word-break:break-word;  -webkit-hyphens:auto;  -moz-hyphens:auto;  hyphens:auto;  border-collapse:collapse !important; } table,tr,td{padding:0;  vertical-align:top;  text-align:left;} hr{color:#d9d9d9;   background-color:#d9d9d9;   height:1px;   border:none;} /* Responsive Grid */ table.body{height:100%;  width:100%;}\n";
									strHTML+="table.container{width:580px;  margin:0 auto;  text-align:inherit;} table.row{padding:0px;   width:100%;  position:relative;} table.container table.row{display:block;} td.wrapper{padding:10px 20px 0px 0px;  position:relative;} table.cell, table.column{margin:0 auto;} table.cell td, table.column td{padding:0px 0px 10px; } table.cell td.sub-cell, table.column td.sub-cell, table.cell td.sub-column, table.column td.sub-column{padding-right:10px;} td.sub-column,td.sub-cell{min-width:0px;} table.row td.last, table.container td.last{padding-right:0px;} table.one{width:30px; } table.two{width:80px; } table.three{width:130px; } table.four{width:180px; } table.five{width:230px; } table.six{width:280px; } table.seven{width:330px; } table.eight{width:380px; } table.nine{width:430px; } table.ten{width:480px; } table.eleven{width:530px; } table.twelve{width:580px; } table.one center{min-width:30px; } table.two center{min-width:80px; } table.three center{min-width:130px; }\n";                              
									strHTML+="table.four center{min-width:180px; } table.five center{min-width:230px; } table.six center{min-width:280px; } table.seven center{min-width:330px; } table.eight center{min-width:380px; } table.nine center{min-width:430px; } table.ten center{min-width:480px; } table.eleven center{min-width:530px; } table.twelve center{min-width:580px; } table.one .panel center{min-width:10px; } table.two .panel center{min-width:60px; } table.three .panel center{min-width:110px; } table.four .panel center{min-width:160px; } table.five .panel center{min-width:210px; } table.six .panel center{min-width:260px; } table.seven .panel center{min-width:310px; } table.eight .panel center{min-width:360px; } table.nine .panel center{min-width:410px; } table.ten .panel center{min-width:460px; } table.eleven .panel center{min-width:510px; } table.twelve .panel center{min-width:560px; } .body .cell td.one, .body .column td.one{width:8.333333%; } .body .cell td.two, .body .column td.two{width:16.666666%; }\n";
									strHTML+=".body .cell td.three, .body .column td.three{width:25%; } .body .cell td.four, .body .column td.four{width:33.333333%; } .body .cell td.five, .body .column td.five{width:41.666666%; } .body .cell td.six, .body .column td.six{width:50%; } .body .cell td.seven, .body .column td.seven{width:58.333333%; } .body .cell td.eight, .body .column td.eight{width:66.666666%; } .body .cell td.nine, .body .column td.nine{width:75%; } .body .cell td.ten, .body .column td.ten{width:83.333333%; } .body .cell td.eleven, .body .column td.eleven{width:91.666666%; } .body .cell td.twelve, .body .column td.twelve{width:100%; } td.offset-by-one{padding-left:50px; } td.offset-by-two{padding-left:100px; } td.offset-by-three{padding-left:150px; } td.offset-by-four{padding-left:200px; } td.offset-by-five{padding-left:250px; } td.offset-by-six{padding-left:300px; } td.offset-by-seven{padding-left:350px; } td.offset-by-eight{padding-left:400px; } td.offset-by-nine{padding-left:450px; }\n";
									strHTML+="td.offset-by-ten{padding-left:500px; } td.offset-by-eleven{padding-left:550px; } td.expander{visibility:hidden;  width:0px;  padding:0 !important;} table.cell .text-pad, table.column .text-pad{padding-left:10px;  padding-right:10px;} table.cell .left-text-pad, table.cell .text-pad-left, table.column .left-text-pad, table.column .text-pad-left{padding-left:10px;} table.cell .right-text-pad, table.cell .text-pad-right, table.column .right-text-pad, table.column .text-pad-right{padding-right:10px;} /* Block Grid */ .block-grid{width:100%;  max-width:580px;} .block-grid td{display:inline-block;  padding:10px;} .two-up td{width:270px;} .three-up td{width:173px;} .four-up td{width:125px;} .five-up td{width:96px;} .six-up td{width:76px;} .seven-up td{width:62px;} .eight-up td{width:52px;} /* Alignment & Visibility Classes */ table.center,td.center{text-align:center;} h1.center, h2.center, h3.center, h4.center, h5.center, h6.center{text-align:center;}\n";
									strHTML+="span.center{display:block;  width:100%;  text-align:center;} img.center{margin:0 auto;  float:none;} .show-for-small, .hide-for-desktop{display:none;} /* Typography */ body,table.body,h1,h2,h3,h4,h5,h6,p,td{color:#222222;  font-family:\"Google Sans\",\"Helvetica\",\"Arial\",sans-serif;   font-weight:normal;   padding:0;   margin:0;  text-align:left;   line-height:1.3;} h1,h2,h3,h4,h5,h6{word-break:normal;} h1.email{font-size:40px;} h2{font-size:36px;} h3{font-size:32px;} h4{font-size:28px;} h5{font-size:24px;} h6{font-size:20px;} body,table.body,p,td{font-size:14px;line-height:19px;} p.lead,p.lede,p.leed{font-size:18px;  line-height:21px;} p{margin-bottom:10px;} small{font-size:10px;} a{color:#2ba6cb;   text-decoration:none;} a:hover{color:#2795b6 !important;} a:active{color:#2795b6 !important;} a:visited{color:#2ba6cb !important;} h1 a,h2 a,h3 a,h4 a,h5 a,h6 a{color:#2ba6cb;} h1 a:active,h2 a:active,h3 a:active,h4 a:active,h5 a:active,h6 a:active{color:#2ba6cb !important; }\n";
									strHTML+="h1.email a:visited,h2 a:visited,h3 a:visited,h4 a:visited,h5 a:visited,h6 a:visited{font-family:\"Google Sans\";color:#2ba6cb !important; } /* Panels */ .panel{background:#f2f2f2;  border:1px solid #d9d9d9;  padding:10px !important;} .sub-grid table{width:100%;} .sub-grid td.sub-cell{padding-bottom:0;} /* Buttons */ table.button, table.tiny-button, table.small-button, table.medium-button, table.large-button{width:100%;  overflow:hidden;} table.button td, table.tiny-button td, table.small-button td, table.medium-button td, table.large-button td{display:block;  width:auto !important;  text-align:center;  background:#2ba6cb;  border:1px solid #2284a1;  color:#ffffff;  padding:8px 0;} table.tiny-button td{padding:5px 0 4px;} table.small-button td{padding:8px 0 7px;} table.medium-button td{padding:12px 0 10px;} table.large-button td{padding:21px 0 18px;}                                                                                                                                             \n";
									strHTML+="table.button td a, table.tiny-button td a, table.small-button td a, table.medium-button td a, table.large-button td a{font-weight:bold;  text-decoration:none;  font-family:\"Google Sans\",Helvetica,Arial,sans-serif;  color:#ffffff;  font-size:16px;} table.tiny-button td a{font-size:12px;  font-weight:normal;} table.small-button td a{font-size:16px;} table.medium-button td a{font-size:20px;} table.large-button td a{font-size:24px;} table.button:hover td, table.button:visited td, table.button:active td{background:#2795b6 !important;} table.button:hover td a, table.button:visited td a, table.button:active td a{color:#fff !important;} table.button:hover td, table.tiny-button:hover td, table.small-button:hover td, table.medium-button:hover td, table.large-button:hover td{background:#2795b6 !important;}                                                                                                                                                                                       \n";
									strHTML+="table.button:hover td a, table.button:active td a, table.button td a:visited, table.tiny-button:hover td a, table.tiny-button:active td a, table.tiny-button td a:visited, table.small-button:hover td a, table.small-button:active td a, table.small-button td a:visited, table.medium-button:hover td a, table.medium-button:active td a, table.medium-button td a:visited, table.large-button:hover td a, table.large-button:active td a, table.large-button td a:visited{color:#ffffff !important; } table.secondary td{background:#e9e9e9;  border-color:#d0d0d0;  color:#555;} table.secondary td a{color:#555;} table.secondary:hover td{background:#d0d0d0 !important;  color:#555;} table.secondary:hover td a, table.secondary td a:visited, table.secondary:active td a{color:#555 !important;} table.success td{background:#5da423;  border-color:#457a1a;} table.success:hover td{background:#457a1a !important;} table.alert td{background:#c60f13;  border-color:#970b0e;} table.alert:hover td{background:#970b0e !important;}\n";
									strHTML+="table.radius td{-webkit-border-radius:3px;  -moz-border-radius:3px;  border-radius:3px;} table.round td{-webkit-border-radius:500px;  -moz-border-radius:500px;  border-radius:500px;} /* Outlook First */ body.outlook p{display:inline !important;} /*  Media Queries */ @media only screen and (max-width:600px){table[class=\"body\"] img{width:auto !important;    height:auto !important;  } table[class=\"body\"] center{min-width:0 !important;  } table[class=\"body\"] .container{width:95% !important;  } table[class=\"body\"] .row{width:100% !important;    display:block !important;  } table[class=\"body\"] .wrapper{display:block !important;    padding-right:0 !important;  } table[class=\"body\"] .cell,table[class=\"body\"] .column{table-layout:fixed !important;    float:none !important;    width:100% !important;    padding-right:0px !important;    padding-left:0px !important;    display:block !important;  } table[class=\"body\"] .wrapper.first .cell,table[class=\"body\"] .wrapper.first .column{display:table !important;  }\n";
									strHTML+="table[class=\"body\"] table.cell td,table[class=\"body\"] table.column td{width:100% !important;  } table[class=\"body\"] .cell td.one,table[class=\"body\"] .column td.one{width:8.333333% !important; } table[class=\"body\"] .cell td.two,table[class=\"body\"] .column td.two{width:16.666666% !important; } table[class=\"body\"] .cell td.three,table[class=\"body\"] .column td.three{width:25% !important; } table[class=\"body\"] .cell td.four,table[class=\"body\"] .column td.four{width:33.333333% !important; } table[class=\"body\"] .cell td.five,table[class=\"body\"] .column td.five{width:41.666666% !important; } table[class=\"body\"] .cell td.six,table[class=\"body\"] .column td.six{width:50% !important; } table[class=\"body\"] .cell td.seven,table[class=\"body\"] .column td.seven{width:58.333333% !important; } table[class=\"body\"] .cell td.eight,table[class=\"body\"] .column td.eight{width:66.666666% !important; } table[class=\"body\"] .cell td.nine,table[class=\"body\"] .column td.nine{width:75% !important; }\n";
									strHTML+="table[class=\"body\"] .cell td.ten,table[class=\"body\"] .column td.ten{width:83.333333% !important; } table[class=\"body\"] .cell td.eleven,table[class=\"body\"] .column td.eleven{width:91.666666% !important; } table[class=\"body\"] .cell td.twelve,table[class=\"body\"] .column td.twelve{width:100% !important; } table[class=\"body\"] td.offset-by-one,table[class=\"body\"] td.offset-by-two,table[class=\"body\"] td.offset-by-three,table[class=\"body\"] td.offset-by-four,table[class=\"body\"] td.offset-by-five,table[class=\"body\"] td.offset-by-six,table[class=\"body\"] td.offset-by-seven,table[class=\"body\"] td.offset-by-eight,table[class=\"body\"] td.offset-by-nine,table[class=\"body\"] td.offset-by-ten,table[class=\"body\"] td.offset-by-eleven{padding-left:0 !important;  } table[class=\"body\"] table.cell td.expander{width:1px !important;  } table[class=\"body\"] .right-text-pad,table[class=\"body\"] .text-pad-right{padding-left:10px !important;  }\n";
									strHTML+="table[class=\"body\"] .left-text-pad,table[class=\"body\"] .text-pad-left{padding-right:10px !important;  } table[class=\"body\"] .hide-for-small,table[class=\"body\"] .show-for-desktop{display:none !important;  } table[class=\"body\"] .show-for-small,table[class=\"body\"] .hide-for-desktop{display:inherit !important;  } } table.facebook td{background:#3b5998;      border-color:#2d4473;    } table.facebook:hover td{background:#2d4473 !important;    } table.twitter td{background:#00acee;      border-color:#0087bb;    } table.twitter:hover td{background:#0087bb !important;    } table.google-plus td{background-color:#DB4A39;      border-color:#CC0000;    } table.google-plus:hover td{background:#CC0000 !important;    } .template-label{color:#ffffff;      font-weight:bold;      font-size:11px;    } .callout .wrapper{padding-bottom:20px;    } .callout .panel{background:#ECF8FF;      border-color:#b9e5ff;    } .header{background:#999999;    } .footer .wrapper{background:#ebebeb;    }\n";
									strHTML+=".footer h5{padding-bottom:10px;    } table.cell .text-pad{padding-left:10px;      padding-right:10px;    } table.cell .left-text-pad{padding-left:10px;    } table.cell .right-text-pad{padding-right:10px;    } @media only screen and (max-width:600px){table[class=\"body\"] .right-text-pad{padding-left:10px !important;      } table[class=\"body\"] .left-text-pad{padding-right:10px !important;      } }\n";					
									strHTML+="</style>\n";
									strHTML+="</head>\n";
									strHTML+="<body>\n";
									strHTML+="<table class=\"body\">\n";
									strHTML+="<tr>\n";
									strHTML+="<td class=\"center\" align=\"center\" valign=\"top\">\n";
									strHTML+="<center>" + strCorpo + "</center>\n";
									strHTML+="</td>\n";
									strHTML+="</tr>\n";
									strHTML+="</table>\n";
									strHTML+="</body>\n";
									strHTML+="</html>\n"; 
                  if (strAnteprima=="anteprima"){
								  	//Response.Write(strHTML);
										//inviaPromemoria(strTo,strSubject,strCorpo, dtPagamentiFuturi.Rows[i]["Documenti_PDF"].ToString());
								  }else{
					          //strTo="studiorsw@gmail.com";
							      strRisultatoFuturi+="<tr><td>" + (i+1) + "</td><td><a href=\"/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + dtPagamentiFuturi.Rows[i]["Anagrafiche_Ky"].ToString() + "\"><i class=\"fa-duotone fa-user fa-fw\"></i>" + dtPagamentiFuturi.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</a></td>";
										strRisultatoFuturi+="<td>Promemoria</td>";
										strRisultatoFuturi+="<td>" + DateTime.Now.ToString() + "</td>";
										strRisultatoFuturi+="<td>" +  dtPagamentiFuturi.Rows[i]["Pagamenti_Data_IT"].ToString() + "</td>";
										strRisultatoFuturi+="<td>" + Smartdesk.Functions.getGG(dtPagamentiFuturi.Rows[i]["ggTrascorsi"].ToString()) + "</td>";
										strRisultatoFuturi+="<td>" + dtPagamentiFuturi.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString() + "</td>";
										strRisultatoFuturi+="<td>" + Smartdesk.Functions.getOption("core.serversmpt") + "</td></tr>";
										inviaPromemoria(strTo,strSubject,strCorpo, dtPagamentiFuturi.Rows[i]["Documenti_PDF"].ToString());
                  	aggiornaPromemoria(dtPagamentiFuturi.Rows[i]["Pagamenti_Ky"].ToString());
                  	aggiungiAttivita(dtPagamentiFuturi, i);
								  }
				        }
                strRisultatoFuturi+="</table>";
            }
            if (strTipo=="1"){
                strFROMNet = "Pagamenti_Vw";
                if (strTutti=="tutti"){
            			strWHERENet= "(Pagamenti_Pagato!='si' AND Pagamenti_Data<=(GETDATE()-1) AND (Pagamenti_AttivaPromemoria=1) AND (PagamentiTipo_Ky=1))";
								}else{
									strWHERENet="(PagamentiTipo_Ky=1 AND Pagamenti_Ky=" + strPagamenti_Ky + ")";
								}
                strORDERNet = "Anagrafiche_Ky DESC";
                dtPagamentiScaduti = new DataTable("AnagrafichePagamenti");
                dtPagamentiScaduti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                strRisultatoScaduti="<table class=\"grid\">";
              	strRisultatoScaduti+="<tr><th width=\"20\"></th><th>Anagrafica</th><th>Tipo</th><th>Data invio</th><th>Scadenza</th><th>gg</th><th>Email di destinazione</th><th>Inviato tramite</th></tr>";
                for (int i = 0; i < dtPagamentiScaduti.Rows.Count; i++){
                  switch (strLivello){
						  			case "1":
											strSubject = "Promemoria mancato pagamento " + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString();
											
											strCorpo="<table class=\"container\"><tbody><tr><td>";
						  					strCorpo+="<table class=\"row\"><tr><td class=\"wrapper\">\n<table class=\"twelve cell\"><tr><td>";
											strCorpo+="<p align=\"left\"><i>Importante: Questa mail viene spedita da un sistema automatico.</i></p>\n";
											strCorpo+="<p align=\"left\"><strong>Rovigo, " + dt.ToString() + "</strong><br /><strong>Oggetto: " + strSubject + "</strong></p>\n";
											strCorpo+="<br />Spettabile <strong>" + dtPagamentiScaduti.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</strong>,<br /><br />\n";
											strCorpo+="nel controllare le nostre scritture contabili, abbiamo rilevato un mancato pagamento da parte Vostra della <strong>" + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtPagamentiScaduti.Rows[i]["Pagamenti_Riferimenti"].ToString() + "</strong> per un importo di <strong>" + dtPagamentiScaduti.Rows[i]["Pagamenti_Importo_IT"].ToString() + " &euro; IVA Compresa</strong>\n";
											strCorpo+="scadente il <strong>" +  dtPagamentiScaduti.Rows[i]["Pagamenti_Data_IT"].ToString() + "</strong> e quindi sono trascorsi <font color=\"#ff0000\"><strong>" + dtPagamentiScaduti.Rows[i]["ggTrascorsi"].ToString() + " giorni</strong></font> dalla scadenza.\n";
											strCorpo+="<p>La invitiamo a contattarci prontamente nel caso in cui non disponesse di una o pi&ugrave; fatture.</p>\n";
											strCorpo+="<p>Vi chiediamo quindi di effettuare il pagamento tramite BONIFICO BANCARIO con le seguenti coordinate:</p>\n";
											strCorpo+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"4\" style=\"border-collapse: collapse;\">\n";
											strCorpo+="<tr><td>Banca:</td><td><strong>BANCA ANNIA CRED. COOP CARTURA E POLESINE</strong></td></tr>\n";
											strCorpo+="<tr><td>EUR IBAN:</td><td><strong>IT23 H084 5212 2010 0000 0027 069</strong></td></tr>\n";
											strCorpo+="<tr><td>Causale:</td><td><strong>" + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtPagamentiScaduti.Rows[i]["Documenti_Numero"].ToString() + " del " + dtPagamentiScaduti.Rows[i]["Documenti_Data_IT"].ToString() + "</strong></td></tr>\n";
											strCorpo+="<tr><td>Importo:</td><td><strong>" + dtPagamentiScaduti.Rows[i]["Pagamenti_Importo_IT"].ToString() + " &euro;</strong></td></tr>\n";
											strCorpo+="</table>\n";
											strCorpo+="<p>Qualora abbiate gi&agrave; provveduto al pagamento negli ultimissimi giorni vi chiediamo di non tener in considerazione questo nostro promemoria.</p>\n";
											strCorpo+="Cordiali saluti,<br /><br />Amministrazione RSW Studio\n";
											strCorpo+=strFirma;
								  		strCorpo+="</td><td class=\"expander\"></td></tr>\n</table>\n</td></tr>\n</table>\n</td></tr>\n</tbody></table>\n";
								  		break;
							  	case "2":
										strSubject = "Sollecito mancato pagamento " + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString();
										strCorpo="<table class=\"container\"><tbody><tr><td>\n";
					  					strCorpo+="<table class=\"row\"><tr><td class=\"wrapper\">\n<table class=\"twelve cell\"><tr><td>\n";
										strCorpo+="<p align=\"left\"><i>Importante: Questa mail viene spedita da un sistema automatico.</i></p>\n";
										strCorpo+="<p align=\"left\"><strong>Rovigo, " + dt.ToString() + "</strong><br /><strong>Oggetto: " + strSubject + "</strong></p>\n";
										strCorpo+="<br />Spettabile <strong>" + dtPagamentiScaduti.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</strong>,<br /><br />\n";
										strCorpo+="nel controllare le nostre scritture contabili, abbiamo rilevato un mancato pagamento da parte Vostra della <strong>" + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtPagamentiScaduti.Rows[i]["Pagamenti_Riferimenti"].ToString() + "</strong> per un importo di <strong>" + dtPagamentiScaduti.Rows[i]["Pagamenti_Importo_IT"].ToString() + " &euro; IVA Compresa</strong>\n";
										strCorpo+="scadente il <strong>" +  dtPagamentiScaduti.Rows[i]["Pagamenti_Data_IT"].ToString() + "</strong> e quindi sono trascorsi <font color=\"#ff0000\"><strong>" + dtPagamentiScaduti.Rows[i]["ggTrascorsi"].ToString() + " giorni</strong></font> dalla scadenza di pagamento.\n";
										strCorpo+="<p>Vi chiediamo quindi di <strong>effettuare tempestivamente</strong> il pagamento tramite BONIFICO BANCARIO con le seguenti coordinate per evitare l'<strong>imminente sospensione dei servizi attivi (email, hosting, posizionamento sui motori, ecc)</strong>:</p>\n";
										strCorpo+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"4\" style=\"border-collapse: collapse;\">\n";
										strCorpo+="<tr><td>Banca:</td><td><strong>BANCA ANNIA CRED. COOP CARTURA E POLESINE</strong></td></tr>\n";
										strCorpo+="<tr><td>EUR IBAN:</td><td><strong>IT23 H084 5212 2010 0000 0027 069</strong></td></tr>\n";
										strCorpo+="<tr><td>Causale:</td><td><strong>" + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtPagamentiScaduti.Rows[i]["Documenti_Numero"].ToString() + " del " + dtPagamentiScaduti.Rows[i]["Documenti_Data_IT"].ToString() + "</strong></td></tr>\n";
										strCorpo+="<tr><td>Importo:</td><td><strong>" + dtPagamentiScaduti.Rows[i]["Pagamenti_Importo_IT"].ToString() + " &euro;</strong></td></tr>\n";
										strCorpo+="</table>\n";
										strCorpo+="<p>Qualora abbiate gi&agrave; provveduto al pagamento negli ultimissimi giorni vi chiediamo di non tener in considerazione questo nostro promemoria.</p>\n";
										strCorpo+="Cordiali saluti,<br /><br />Amministrazione RSW Studio\n";
										strCorpo+=strFirma;
							  		strCorpo+="</td><td class=\"expander\"></td></tr>\n</table>\n</td></tr>\n</table>\n</td></tr>\n</tbody></table>\n";
							  		break;
							  	case "3":
										strSubject = "Preavviso sospensione servizi per mancato pagamento " + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString() + "";
										strCorpo="<table class=\"container\"><tbody><tr><td>";
					  				strCorpo+="<table class=\"row\"><tr><td class=\"wrapper\">\n<table class=\"twelve cell\"><tr><td>";
										strCorpo+="<p align=\"left\"><i>Importante: Questa mail viene spedita da un sistema automatico.</i></p>";
										strCorpo+="<p align=\"left\"><strong>Rovigo, " + dt.ToString() + "</strong><br /><strong>Oggetto: " + strSubject + "</strong></p>";
										strCorpo+="<br />Spettabile <strong>" + dtPagamentiScaduti.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</strong>,<br /><br />";
										strCorpo+="facendo seguito alle precedenti comunicazioni di promemoria e sollecito di pagamento da parte Vostra della <strong>" + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtPagamentiScaduti.Rows[i]["Pagamenti_Riferimenti"].ToString() + "</strong> per un importo di <strong>" + dtPagamentiScaduti.Rows[i]["Pagamenti_Importo_IT"].ToString() + " &euro; IVA Compresa</strong> ";
										strCorpo+="scadente il <strong>" +  dtPagamentiScaduti.Rows[i]["Pagamenti_Data_IT"].ToString() + "</strong> e per la quale sono trascorsi <font color=\"#ff0000\"><strong>" + dtPagamentiScaduti.Rows[i]["ggTrascorsi"].ToString() + " giorni</strong></font> dalla scadenza di pagamento, siamo a comunicarvi <strong>nostro malgrado</strong> la sospensione dei servizi attivi con RSW Studio con possibile perdita dei dati <strong>entro i prossimi 5 gg lavorativi</strong>.";
										strCorpo+="<p>Vi chiediamo quindi di <strong>effettuare tempestivamente</strong> il pagamento tramite BONIFICO BANCARIO con le seguenti coordinate per evitare la <strong>sospensione dei servizi attivi</strong> e di comunicarci l'avvenuto pagamento:</p>";
										strCorpo+="<table border=\"1\" cellpadding=\"4\" cellspacing=\"4\" style=\"border-collapse: collapse;\">";
										strCorpo+="<tr><td>Banca:</td><td><strong>BANCA ANNIA CRED. COOP CARTURA E POLESINE</strong></td></tr>";
										strCorpo+="<tr><td>EUR IBAN:</td><td><strong>IT23 H084 5212 2010 0000 0027 069</strong></td></tr>";
										strCorpo+="<tr><td>Causale:</td><td><strong>" + dtPagamentiScaduti.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtPagamentiScaduti.Rows[i]["Documenti_Numero"].ToString() + " del " + dtPagamentiScaduti.Rows[i]["Documenti_Data_IT"].ToString() + "</strong></td></tr>";
										strCorpo+="<tr><td>Importo:</td><td><strong>" + dtPagamentiScaduti.Rows[i]["Pagamenti_Importo_IT"].ToString() + " &euro;</strong></td></tr>";
										strCorpo+="</table>";
										strCorpo+="<p><strong>Trascorso il termine preannunciato, affideremo la pratica al nostro legale di fiducia per la tutela dei nostri interessi e per il recupero forzoso del credito cos&igrave; come previsto dalle norme vigenti.</strong></p>"; 
										strCorpo+="Cordiali saluti,<br /><br />Amministrazione RSW Studio";
										strCorpo+=strFirma;
							  		strCorpo+="</td><td class=\"expander\"></td></tr>\n</table>\n</td></tr>\n</table>\n</td></tr>\n</tbody></table>\n";
							  		break;
	
					  		}
				  strTo = dtPagamentiScaduti.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString();
					strHTML="<!DOCTYPE html>\n";
					strHTML+="<html>\n";
					strHTML+="<head>\n";
					strHTML+="<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\n";
					strHTML+="<title>" + strSubject + "</title>\n";
					strHTML+="<meta name=\"viewport\" content=\"width=device-width\"/>\n";
					strHTML+="<link href='https://fonts.googleapis.com/css?family=Google+Sans' rel='stylesheet' type='text/css' />\n";
					strHTML+="<style type=\"text/css\">\n";
					strHTML+="@import url(https://fonts.googleapis.com/css?family=Google+Sans:400,500,700);";
					strHTML+="#outlook a{padding:0; } body{font-family:\"Google Sans\";width:100% !important;   min-width:100%;  -webkit-text-size-adjust:100%;   -ms-text-size-adjust:100%;   margin:0;   padding:0;} .ExternalClass{width:100%;} .ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div{line-height:100%; } #backgroundTable{margin:0;   padding:0;   width:100% !important;   line-height:100% !important; } img{outline:none;   text-decoration:none;   -ms-interpolation-mode:bicubic;  width:auto;  max-width:100%;   float:left;   clear:both;   display:block;} center{width:100%;  min-width:580px;} a img{border:none;} p{margin:0 0 0 10px;} table{border-spacing:0;  border-collapse:collapse;} td{word-break:break-word;  -webkit-hyphens:auto;  -moz-hyphens:auto;  hyphens:auto;  border-collapse:collapse !important; } table,tr,td{padding:0;  vertical-align:top;  text-align:left;} hr{color:#d9d9d9;   background-color:#d9d9d9;   height:1px;   border:none;} /* Responsive Grid */ table.body{height:100%;  width:100%;}\n";
					strHTML+="table.container{width:580px;  margin:0 auto;  text-align:inherit;} table.row{padding:0px;   width:100%;  position:relative;} table.container table.row{display:block;} td.wrapper{padding:10px 20px 0px 0px;  position:relative;} table.cell, table.column{margin:0 auto;} table.cell td, table.column td{padding:0px 0px 10px; } table.cell td.sub-cell, table.column td.sub-cell, table.cell td.sub-column, table.column td.sub-column{padding-right:10px;} td.sub-column,td.sub-cell{min-width:0px;} table.row td.last, table.container td.last{padding-right:0px;} table.one{width:30px; } table.two{width:80px; } table.three{width:130px; } table.four{width:180px; } table.five{width:230px; } table.six{width:280px; } table.seven{width:330px; } table.eight{width:380px; } table.nine{width:430px; } table.ten{width:480px; } table.eleven{width:530px; } table.twelve{width:580px; } table.one center{min-width:30px; } table.two center{min-width:80px; } table.three center{min-width:130px; }\n";                              
					strHTML+="table.four center{min-width:180px; } table.five center{min-width:230px; } table.six center{min-width:280px; } table.seven center{min-width:330px; } table.eight center{min-width:380px; } table.nine center{min-width:430px; } table.ten center{min-width:480px; } table.eleven center{min-width:530px; } table.twelve center{min-width:580px; } table.one .panel center{min-width:10px; } table.two .panel center{min-width:60px; } table.three .panel center{min-width:110px; } table.four .panel center{min-width:160px; } table.five .panel center{min-width:210px; } table.six .panel center{min-width:260px; } table.seven .panel center{min-width:310px; } table.eight .panel center{min-width:360px; } table.nine .panel center{min-width:410px; } table.ten .panel center{min-width:460px; } table.eleven .panel center{min-width:510px; } table.twelve .panel center{min-width:560px; } .body .cell td.one, .body .column td.one{width:8.333333%; } .body .cell td.two, .body .column td.two{width:16.666666%; }\n";
					strHTML+=".body .cell td.three, .body .column td.three{width:25%; } .body .cell td.four, .body .column td.four{width:33.333333%; } .body .cell td.five, .body .column td.five{width:41.666666%; } .body .cell td.six, .body .column td.six{width:50%; } .body .cell td.seven, .body .column td.seven{width:58.333333%; } .body .cell td.eight, .body .column td.eight{width:66.666666%; } .body .cell td.nine, .body .column td.nine{width:75%; } .body .cell td.ten, .body .column td.ten{width:83.333333%; } .body .cell td.eleven, .body .column td.eleven{width:91.666666%; } .body .cell td.twelve, .body .column td.twelve{width:100%; } td.offset-by-one{padding-left:50px; } td.offset-by-two{padding-left:100px; } td.offset-by-three{padding-left:150px; } td.offset-by-four{padding-left:200px; } td.offset-by-five{padding-left:250px; } td.offset-by-six{padding-left:300px; } td.offset-by-seven{padding-left:350px; } td.offset-by-eight{padding-left:400px; } td.offset-by-nine{padding-left:450px; }\n";
					strHTML+="td.offset-by-ten{padding-left:500px; } td.offset-by-eleven{padding-left:550px; } td.expander{visibility:hidden;  width:0px;  padding:0 !important;} table.cell .text-pad, table.column .text-pad{padding-left:10px;  padding-right:10px;} table.cell .left-text-pad, table.cell .text-pad-left, table.column .left-text-pad, table.column .text-pad-left{padding-left:10px;} table.cell .right-text-pad, table.cell .text-pad-right, table.column .right-text-pad, table.column .text-pad-right{padding-right:10px;} /* Block Grid */ .block-grid{width:100%;  max-width:580px;} .block-grid td{display:inline-block;  padding:10px;} .two-up td{width:270px;} .three-up td{width:173px;} .four-up td{width:125px;} .five-up td{width:96px;} .six-up td{width:76px;} .seven-up td{width:62px;} .eight-up td{width:52px;} /* Alignment & Visibility Classes */ table.center,td.center{text-align:center;} h1.center, h2.center, h3.center, h4.center, h5.center, h6.center{text-align:center;}\n";
					strHTML+="span.center{display:block;  width:100%;  text-align:center;} img.center{margin:0 auto;  float:none;} .show-for-small, .hide-for-desktop{display:none;} /* Typography */ body,table.body,h1,h2,h3,h4,h5,h6,p,td{color:#222222;  font-family:\"Google Sans\",\"Helvetica\",\"Arial\",sans-serif;   font-weight:normal;   padding:0;   margin:0;  text-align:left;   line-height:1.3;} h1,h2,h3,h4,h5,h6{word-break:normal;} h1.email{font-size:40px;} h2{font-size:36px;} h3{font-size:32px;} h4{font-size:28px;} h5{font-size:24px;} h6{font-size:20px;} body,table.body,p,td{font-size:14px;line-height:19px;} p.lead,p.lede,p.leed{font-size:18px;  line-height:21px;} p{margin-bottom:10px;} small{font-size:10px;} a{color:#2ba6cb;   text-decoration:none;} a:hover{color:#2795b6 !important;} a:active{color:#2795b6 !important;} a:visited{color:#2ba6cb !important;} h1 a,h2 a,h3 a,h4 a,h5 a,h6 a{color:#2ba6cb;} h1 a:active,h2 a:active,h3 a:active,h4 a:active,h5 a:active,h6 a:active{color:#2ba6cb !important; }\n";
					strHTML+="h1.email a:visited,h2 a:visited,h3 a:visited,h4 a:visited,h5 a:visited,h6 a:visited{font-family:\"Google Sans\";color:#2ba6cb !important; } /* Panels */ .panel{background:#f2f2f2;  border:1px solid #d9d9d9;  padding:10px !important;} .sub-grid table{width:100%;} .sub-grid td.sub-cell{padding-bottom:0;} /* Buttons */ table.button, table.tiny-button, table.small-button, table.medium-button, table.large-button{width:100%;  overflow:hidden;} table.button td, table.tiny-button td, table.small-button td, table.medium-button td, table.large-button td{display:block;  width:auto !important;  text-align:center;  background:#2ba6cb;  border:1px solid #2284a1;  color:#ffffff;  padding:8px 0;} table.tiny-button td{padding:5px 0 4px;} table.small-button td{padding:8px 0 7px;} table.medium-button td{padding:12px 0 10px;} table.large-button td{padding:21px 0 18px;}                                                                                                                                             \n";
					strHTML+="table.button td a, table.tiny-button td a, table.small-button td a, table.medium-button td a, table.large-button td a{font-weight:bold;  text-decoration:none;  font-family:\"Google Sans\",Helvetica,Arial,sans-serif;  color:#ffffff;  font-size:16px;} table.tiny-button td a{font-size:12px;  font-weight:normal;} table.small-button td a{font-size:16px;} table.medium-button td a{font-size:20px;} table.large-button td a{font-size:24px;} table.button:hover td, table.button:visited td, table.button:active td{background:#2795b6 !important;} table.button:hover td a, table.button:visited td a, table.button:active td a{color:#fff !important;} table.button:hover td, table.tiny-button:hover td, table.small-button:hover td, table.medium-button:hover td, table.large-button:hover td{background:#2795b6 !important;}                                                                                                                                                                                       \n";
					strHTML+="table.button:hover td a, table.button:active td a, table.button td a:visited, table.tiny-button:hover td a, table.tiny-button:active td a, table.tiny-button td a:visited, table.small-button:hover td a, table.small-button:active td a, table.small-button td a:visited, table.medium-button:hover td a, table.medium-button:active td a, table.medium-button td a:visited, table.large-button:hover td a, table.large-button:active td a, table.large-button td a:visited{color:#ffffff !important; } table.secondary td{background:#e9e9e9;  border-color:#d0d0d0;  color:#555;} table.secondary td a{color:#555;} table.secondary:hover td{background:#d0d0d0 !important;  color:#555;} table.secondary:hover td a, table.secondary td a:visited, table.secondary:active td a{color:#555 !important;} table.success td{background:#5da423;  border-color:#457a1a;} table.success:hover td{background:#457a1a !important;} table.alert td{background:#c60f13;  border-color:#970b0e;} table.alert:hover td{background:#970b0e !important;}\n";
					strHTML+="table.radius td{-webkit-border-radius:3px;  -moz-border-radius:3px;  border-radius:3px;} table.round td{-webkit-border-radius:500px;  -moz-border-radius:500px;  border-radius:500px;} /* Outlook First */ body.outlook p{display:inline !important;} /*  Media Queries */ @media only screen and (max-width:600px){table[class=\"body\"] img{width:auto !important;    height:auto !important;  } table[class=\"body\"] center{min-width:0 !important;  } table[class=\"body\"] .container{width:95% !important;  } table[class=\"body\"] .row{width:100% !important;    display:block !important;  } table[class=\"body\"] .wrapper{display:block !important;    padding-right:0 !important;  } table[class=\"body\"] .cell,table[class=\"body\"] .column{table-layout:fixed !important;    float:none !important;    width:100% !important;    padding-right:0px !important;    padding-left:0px !important;    display:block !important;  } table[class=\"body\"] .wrapper.first .cell,table[class=\"body\"] .wrapper.first .column{display:table !important;  }\n";
					strHTML+="table[class=\"body\"] table.cell td,table[class=\"body\"] table.column td{width:100% !important;  } table[class=\"body\"] .cell td.one,table[class=\"body\"] .column td.one{width:8.333333% !important; } table[class=\"body\"] .cell td.two,table[class=\"body\"] .column td.two{width:16.666666% !important; } table[class=\"body\"] .cell td.three,table[class=\"body\"] .column td.three{width:25% !important; } table[class=\"body\"] .cell td.four,table[class=\"body\"] .column td.four{width:33.333333% !important; } table[class=\"body\"] .cell td.five,table[class=\"body\"] .column td.five{width:41.666666% !important; } table[class=\"body\"] .cell td.six,table[class=\"body\"] .column td.six{width:50% !important; } table[class=\"body\"] .cell td.seven,table[class=\"body\"] .column td.seven{width:58.333333% !important; } table[class=\"body\"] .cell td.eight,table[class=\"body\"] .column td.eight{width:66.666666% !important; } table[class=\"body\"] .cell td.nine,table[class=\"body\"] .column td.nine{width:75% !important; }\n";
					strHTML+="table[class=\"body\"] .cell td.ten,table[class=\"body\"] .column td.ten{width:83.333333% !important; } table[class=\"body\"] .cell td.eleven,table[class=\"body\"] .column td.eleven{width:91.666666% !important; } table[class=\"body\"] .cell td.twelve,table[class=\"body\"] .column td.twelve{width:100% !important; } table[class=\"body\"] td.offset-by-one,table[class=\"body\"] td.offset-by-two,table[class=\"body\"] td.offset-by-three,table[class=\"body\"] td.offset-by-four,table[class=\"body\"] td.offset-by-five,table[class=\"body\"] td.offset-by-six,table[class=\"body\"] td.offset-by-seven,table[class=\"body\"] td.offset-by-eight,table[class=\"body\"] td.offset-by-nine,table[class=\"body\"] td.offset-by-ten,table[class=\"body\"] td.offset-by-eleven{padding-left:0 !important;  } table[class=\"body\"] table.cell td.expander{width:1px !important;  } table[class=\"body\"] .right-text-pad,table[class=\"body\"] .text-pad-right{padding-left:10px !important;  }\n";
					strHTML+="table[class=\"body\"] .left-text-pad,table[class=\"body\"] .text-pad-left{padding-right:10px !important;  } table[class=\"body\"] .hide-for-small,table[class=\"body\"] .show-for-desktop{display:none !important;  } table[class=\"body\"] .show-for-small,table[class=\"body\"] .hide-for-desktop{display:inherit !important;  } } table.facebook td{background:#3b5998;      border-color:#2d4473;    } table.facebook:hover td{background:#2d4473 !important;    } table.twitter td{background:#00acee;      border-color:#0087bb;    } table.twitter:hover td{background:#0087bb !important;    } table.google-plus td{background-color:#DB4A39;      border-color:#CC0000;    } table.google-plus:hover td{background:#CC0000 !important;    } .template-label{color:#ffffff;      font-weight:bold;      font-size:11px;    } .callout .wrapper{padding-bottom:20px;    } .callout .panel{background:#ECF8FF;      border-color:#b9e5ff;    } .header{background:#999999;    } .footer .wrapper{background:#ebebeb;    }\n";
					strHTML+=".footer h5{padding-bottom:10px;    } table.cell .text-pad{padding-left:10px;      padding-right:10px;    } table.cell .left-text-pad{padding-left:10px;    } table.cell .right-text-pad{padding-right:10px;    } @media only screen and (max-width:600px){table[class=\"body\"] .right-text-pad{padding-left:10px !important;      } table[class=\"body\"] .left-text-pad{padding-right:10px !important;      } }\n";					
					strHTML+="</style>\n";
					strHTML+="</head>\n";
					strHTML+="<body>\n";
					strHTML+="<table class=\"body\">\n";
					strHTML+="<tr>\n";
					strHTML+="<td class=\"center\" align=\"center\" valign=\"top\">\n";
					strHTML+="<center>" + strCorpo + "</center>\n";
					strHTML+="</td>\n";
					strHTML+="</tr>\n";
					strHTML+="</table>\n";
					strHTML+="</body>\n";
					strHTML+="</html>\n"; 
          if (strAnteprima=="anteprima"){
							//inviaPromemoria(strTo,strSubject,strCorpo,dtPagamentiScaduti.Rows[i]["Documenti_PDF"].ToString());
				  }else{
	            strRisultatoScaduti+="<tr><td>" + (i+1) + "</td><td><a href=\"/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + dtPagamentiScaduti.Rows[i]["Anagrafiche_Ky"].ToString() + "\"><i class=\"fa-duotone fa-user fa-fw\"></i>" + dtPagamentiScaduti.Rows[i]["Anagrafiche_RagioneSociale"].ToString() + "</a></td>";
							strRisultatoScaduti+="<td>Sollecito</td>";
							strRisultatoScaduti+="<td>" + DateTime.Now.ToString() + "</td>";
							strRisultatoScaduti+="<td>" + dtPagamentiScaduti.Rows[i]["Pagamenti_Data_IT"].ToString() + "</td>";
							strRisultatoScaduti+="<td>" + Smartdesk.Functions.getGG(dtPagamentiScaduti.Rows[i]["ggTrascorsi"].ToString()) + "</td>";
							strRisultatoScaduti+="<td>" + dtPagamentiScaduti.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString() + "</td>";
							strRisultatoScaduti+="<td>" + Smartdesk.Functions.getOption("core.serversmpt") + "</td></tr>";
              switch (strLivello){
				  			case "1":
    							inviaPromemoria(strTo,strSubject,strCorpo,dtPagamentiScaduti.Rows[i]["Documenti_PDF"].ToString());
						  		break;
					  	  case "2":
    							inviaPromemoria(strTo,strSubject,strCorpo,dtPagamentiScaduti.Rows[i]["Documenti_PDF"].ToString());
						  		break;
					  	  case "3":
    							inviaPromemoria(strTo,strSubject,strCorpo,dtPagamentiScaduti.Rows[i]["Documenti_PDF"].ToString());
                  break;
                default:
    							inviaPromemoriaPEC(strTo,strSubject,strCorpo,dtPagamentiScaduti.Rows[i]["Documenti_PDF"].ToString());
                  break;
              }

							aggiornaPromemoria(dtPagamentiScaduti.Rows[i]["Pagamenti_Ky"].ToString());
		          aggiungiAttivita(dtPagamentiScaduti, i);
					}
		    }
        strRisultatoScaduti+="</table>";
        }
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageBack +"?errore=datinoninseriti");
      }
    }    

		public bool aggiungiAttivita(DataTable dtPagamentoOrigine, int intRiga){
      string strSQL="";
      
      strSQL = "INSERT INTO Attivita ";
      strSQL += "(Attivita_Descrizione";
      strSQL += ",Attivita_Inizio";
      strSQL += ",Attivita_Scadenza";
      strSQL += ",Attivita_Chiusura";
      strSQL += ",Anagrafiche_Ky";
      strSQL += ",AttivitaTipo_Ky";
      strSQL += ",Attivita_Completo";
      strSQL += ",Priorita_Ky";
      strSQL += ",Commesse_Ky";
      strSQL += ",Opportunita_Ky";
      strSQL += ",Attivita_Ore";
      strSQL += ",Attivita_Trasferta";
      strSQL += ",Attivita_Km";
      strSQL += ",Attivita_RimborsoKm";
      strSQL += ",Attivita_SpeseKm";
      strSQL += ",Attivita_SpeseAutostrada";
      strSQL += ",Attivita_SpeseParcheggi";
      strSQL += ",Attivita_SpesePasti";
      strSQL += ",Attivita_SpeseMezziPubblici";
      strSQL += ",Attivita_SpeseTotali";
      strSQL += ",AttivitaSettore_Ky";
      strSQL += ",Utenti_Ky";
      strSQL += ",Pagamenti_Ky";
      strSQL += ",Documenti_Ky)";
      strSQL += " VALUES ";
      strSQL += "('Promemoria pagamento documento " + dtPagamentoOrigine.Rows[intRiga]["Pagamenti_Riferimenti"].ToString() + " per un importo di " + dtPagamentoOrigine.Rows[intRiga]["Pagamenti_Importo"].ToString() + "'";
      strSQL += ",GETDATE()";
      strSQL += ",GETDATE()";
      strSQL += ",GETDATE()";
      strSQL += "," + dtPagamentoOrigine.Rows[intRiga]["Anagrafiche_Ky"].ToString();
      strSQL += ",6";
      strSQL += ",1";
      strSQL += ",1";
      if (dtPagamentoOrigine.Rows[intRiga]["Commesse_Ky"].ToString().Length>0){
				strSQL += "," + dtPagamentoOrigine.Rows[intRiga]["Commesse_Ky"].ToString();
		  }else{
	      	strSQL += ",Null";
		  }
      strSQL += ",Null";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",0";
      strSQL += ",3";
      strSQL += "," + dtLogin.Rows[0]["Utenti_Ky"].ToString();
      if (dtPagamentoOrigine.Rows[intRiga]["Pagamenti_Ky"].ToString().Length>0){
				strSQL += "," + dtPagamentoOrigine.Rows[intRiga]["Pagamenti_Ky"].ToString();
		  }else{
	      	strSQL += ",Null";
		  }
      if (dtPagamentoOrigine.Rows[intRiga]["Documenti_Ky"].ToString().Length>0){
				strSQL += "," + dtPagamentoOrigine.Rows[intRiga]["Documenti_Ky"].ToString();
		  }else{
	      strSQL += ",Null";
		  }
      strSQL += ")";
	  	//Response.Write(strSQL);
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    	return true;
    }

    public bool inviaPromemoria(string strMailTO,string strMailSubject,string strMailBody, string strAttach){
        string strFROM="";
        string strServerSMTP="";
        string strServerSMTPUser="";
        string strServerSMTPPassword="";
        string strServerSMTPPorta="";
        string strServerSMTPSSL="";
        string strEmailAnagrafica="";
        string strHtml = "";
        DataTable dtCoreModulesOptionsValue;
        
        strWHERENet="CoreModulesOptions_Code='core.serversmpt'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTP=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptuser'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPUser=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpassword'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPassword=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptport'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPorta=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptssl'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPSSL=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            

        strWHERENet="CoreModulesOptions_Code='pagamenti.from'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new MailAddress(strFROM);
        mail.To.Add(new MailAddress(strMailTO));
        mail.Bcc.Add(new MailAddress(strFROM));
        mail.Subject = strMailSubject;
        mail.Body = strMailBody;
        mail.IsBodyHtml = true;
        if (strAttach != null && strAttach.Length>0)
        {
            strAttach="/uploads/documenti" + strAttach;
            strAttach=Server.MapPath(strAttach);
						mail.Attachments.Add(new Attachment(strAttach));
        }
        mail.Priority = MailPriority.Normal;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(strServerSMTP,Convert.ToInt32(strServerSMTPPorta));
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(strServerSMTPUser, strServerSMTPPassword);
				client.Host=Smartdesk.Functions.getOption("core.serversmpt");
				client.Port=Convert.ToInt32(Smartdesk.Functions.getOption("core.serversmptport"));
        client.UseDefaultCredentials = false;
    		client.EnableSsl = Convert.ToBoolean(strServerSMTPSSL);
        client.Credentials = mailAuthentication;
        client.Send(mail);
        return true;
    }

    public bool inviaPromemoriaPEC(string strMailTO,string strMailSubject,string strMailBody, string strAttach){
        string strFROM="";
        string strServerSMTP="";
        string strServerSMTPUser="";
        string strServerSMTPPassword="";
        string strServerSMTPPorta="";
        string strServerSMTPSSL="";
        string strEmailAnagrafica="";
        string strHtml = "";
        DataTable dtCoreModulesOptionsValue;
        
        strWHERENet="CoreModulesOptions_Code='core.serversmptpec'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTP=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpecuser'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPUser=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpecpassword'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPassword=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpecport'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPPorta=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            
        strWHERENet="CoreModulesOptions_Code='core.serversmptpecssl'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strServerSMTPSSL=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }            

        strWHERENet="CoreModulesOptions_Code='pagamenti.frompec'";
        strORDERNet = "CoreModulesOptionsValue_Ky";
        strFROMNet = "CoreModulesOptionsValue";
        dtCoreModulesOptionsValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModulesOptionsValue_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtCoreModulesOptionsValue.Rows.Count>0){
            strFROM=dtCoreModulesOptionsValue.Rows[0]["CoreModulesOptionsValue_Value"].ToString();
        }

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new System.Net.Mail.MailAddress(strFROM);
        mail.To.Add(new System.Net.Mail.MailAddress(strMailTO));
        mail.Bcc.Add(new MailAddress(strFROM));
        mail.Subject = strMailSubject;
        mail.Body = strMailBody;
        if (strAttach != null && strAttach.Length > 0)
        {
            mail.Attachments.Add(new Attachment(strAttach));
        }
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = System.Net.Mail.MailPriority.High;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(strServerSMTP,Convert.ToInt32(strServerSMTPPorta));
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(strServerSMTPUser, strServerSMTPPassword);
        client.UseDefaultCredentials = false;
        client.Credentials = mailAuthentication;
    		client.EnableSsl = Convert.ToBoolean(strServerSMTPSSL);
        client.Send(mail);
        return true;       
    }
    
		public bool aggiornaPromemoria(string strPagamenti_Ky){
      string strSQL="";      
      strSQL = "UPDATE Pagamenti SET Pagamenti_NumeroPromemoria=Pagamenti_NumeroPromemoria+1,Pagamenti_UltimoPromemoria=GETDATE() WHERE Pagamenti_Ky=" + strPagamenti_Ky;
      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
    	return true;
    } 
}
