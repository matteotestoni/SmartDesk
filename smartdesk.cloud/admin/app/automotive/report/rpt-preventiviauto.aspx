<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-preventiviauto.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Numero"]%>-<%=GetUTF(dtPreventiviAuto.Rows[0]["Anagrafiche_RagioneSociale"].ToString().Trim())%>-<%=GetUTF(dtPreventiviAuto.Rows[0]["Utenti_Email"].ToString().Trim())%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link type="text/css" rel="stylesheet" href="https://cdn.smartdesk.cloud/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <link rel="stylesheet" href="https://cdn.smartdesk.cloud/lib/fontawesome6/css/all.min.css" />
  <link rel="shortcut icon" href="https://cdn.smartdesk.cloud/img/favicon/favicon.ico">
  <link rel="apple-touch-icon" sizes="57x57" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-57x57.png">
  <link rel="apple-touch-icon" sizes="60x60" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-60x60.png">
  <link rel="apple-touch-icon" sizes="72x72" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-72x72.png">
  <link rel="apple-touch-icon" sizes="76x76" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-76x76.png">
  <link rel="apple-touch-icon" sizes="114x114" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-114x114.png">
  <link rel="apple-touch-icon" sizes="120x120" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-120x120.png">
  <link rel="apple-touch-icon" sizes="144x144" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-144x144.png">
  <link rel="apple-touch-icon" sizes="152x152" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-152x152.png">
  <link rel="apple-touch-icon" sizes="180x180" href="https://cdn.smartdesk.cloud/img/favicon/apple-icon-180x180.png">
  <link rel="icon" type="image/png" sizes="192x192" href="https://cdn.smartdesk.cloud/img/favicon/android-icon-192x192.png">
  <link rel="icon" type="image/png" sizes="32x32" href="https://cdn.smartdesk.cloud/img/favicon/favicon-32x32.png">
  <link rel="icon" type="image/png" sizes="96x96" href="https://cdn.smartdesk.cloud/img/favicon/favicon-96x96.png">
  <link rel="icon" type="image/png" sizes="16x16" href="https://cdn.smartdesk.cloud/img/favicon/favicon-16x16.png">
  <link rel="manifest" href="https://cdn.smartdesk.cloud/img/favicon/manifest.json">
  <meta name="msapplication-TileColor" content="#ffffff">
  <meta name="msapplication-TileImage" content="https://cdn.smartdesk.cloud/img/favicon/ms-icon-144x144.png">
  <meta name="theme-color" content="#ffffff">  
  <style>
			a {
			  text-decoration : underline;
			  color : #000000;
			} 
			table.header{
			  width:19cm;
			  border-bottom:1px solid #a9a9a9;
			}
			div.titoloriga{
			  font-size:16px;
			  font-weight:700;
			}
			span.testoriga{
			  font-size:14px;
			  font-weight:300;
			}
			span.prezzotagliato{
			  font-size:14px;
			  font-weight:700;
			  text-decoration: line-through;
			}
			span.qta{
			  font-size:17px;
			  font-weight:700;
			}
			span.prezzo{
			  font-size:17px;
			  font-weight:700;
			}
			span.totaleriga{
			  font-size:19px;
			  font-weight:700;
			}
			div.slogan{
				font-size:13px;
			  font-weight:400;
			}
			td.totale{
			  padding:0 5px 0 0;
			  margin:0;
				font-weight:700;
			  background-color:#D5D5D5;
			}
			td.titolo{
			  border-width:1px;
			  border-style:solid;
			  border-color:#ffffff #ffffff #666666 #666666;
			}
			
			table.intestazione{
			  width:19cm;
			  margin-top:0.2cm;
			}
			div.corpodocumento{
			  border-width:0px;
			  border-style:solid;
			  border-color:#ffffff #666666 #666666 #666666;
			  width:19cm;
			  padding:0;
			  margin:0.2cm 0 0 0;
			}
			div.corpo{
			  border-width:0;
			  border-style:solid;
			  border-color:#ffffff #666666 #666666 #666666;
			  width:19cm;
			  padding:0;
			  margin:0.2cm 0 0 0;
			}
			table.corpo{
			  width:100%;
			  border-collapse:collapse;
			}
			table.corpo td.riga{
			  padding:10px 5px 10px 5px;
			}
			table.corpo td.rigaprezzo{
			  padding:10px 5px 10px 5px;
			}
			table.corpo td.titolo1{
			  font-weight:700;
			  font-size:14px;
			}
			table.corpo td.titololast{
			  font-weight:700;
			  border-top:1px solid #666666;
			  border-bottom:1px solid #666666;
			  font-size:14px;
			}
			table.corpo td.rigadocumento{
			  border-bottom:1px solid #666666;
			  border-right:1px solid #666666;
			  border-left:1px solid #666666;
			  padding:15px 5px 15px 5px;
			}
			
			table.standard{
			  width:19cm;
			}
			
			table.standard td{
			  border:1px solid #666666;
			  padding:1px;
			  margin:0px;
			}
			
			table.totali{
			  width:7cm;
			  border: 1px solid #666666;
			  margin-left:12cm;
			  margin-top:1cm;
			  margin-bottom:0.5cm;
			  border-collapse:collapse;
			}
			table.pagamenti{
			  width:19cm;
			  border-top: 1px solid #666666;
			  border-bottom: 1px solid #666666;
			  margin-top:0.2cm;
			}
			div.titolopagamento{
			  font-size:14px;
			  font-weight:700;
			}
			div.infopagamento{
			  font-size:14px;
			  font-weight:700;
			  margin-left:2cm;
			  line-height:1.5em;
			}
			div.titoloappoggio{
			  font-size:14px;
			  font-weight:700;
			  margin-top:0.5cm;
			}
			div.infoappoggio{
			  font-size:14px;
			  font-weight:700;
			  margin-left:2cm;
			}
			div.pagamenti{
			  width:19cm;
			  border-top:4px solid #666666;
			  border-bottom:4px solid #666666;
			  padding:0.2cm 0 0.2cm 0;
			}
			
			div.privacy{
			  margin-top:0.1cm;
			  width:19cm;
			  font-size:10px;
			  font-weight:700;
			  text-align:left;
			}
			
			div.corpo{
				height:100%;
				width:19cm;
			}
			@page {
			    margin:0.5cm;
			}
			div.header{
				display: block;
			  width:19cm;
			  height:10cm;
				z-index:12500;
				margin-bottom:5cm;
			}
  </style>
</head>
<body>
	<header id="header">
	    <div id="header_content">
    	  <table border="0" cellpadding="0" cellspacing="0" class="header" style="border:0;width:100%;" >
    	  <tr>
    	    <td width="100%" align="center">
              <img src="/uploads/files/header-preventivo.jpg" border="0" style="max-width:100%;padding:10px 0 10px 0" />
    	    </td>
    	  </tr>
    	  </table>
	    </div>
	</header>
	<main id="maincontainer" style="margin-top:1cm">
	  <div id="content">
    	  <table border="0" cellpadding="0" cellspacing="0" class="intestazione" style="margin-bottom:0.5cm">
    	  <tr>
          <td valign="top" width="100" align="right"><strong style="margin-right:10px">Destinatario:</strong></td>
    	    <td valign="top" width="300">
    	      <div class="spettabile">Spettabile</div>
    	      <div class="ragionesociale"><%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%></div>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_Indirizzo"].ToString().Length>0){ %>
    	       <%=dtAnagrafiche.Rows[0]["Anagrafiche_Indirizzo"].ToString()%><br />
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Comuni_Comune"].ToString().Length>0){ %>
    	       <%=dtAnagrafiche.Rows[0]["Anagrafiche_CAP"].ToString()%> <%=dtAnagrafiche.Rows[0]["Comuni_Comune"].ToString()%> 
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Province_Provincia"].ToString().Length>0){ %>
            (<%=dtAnagrafiche.Rows[0]["Province_Provincia"].ToString()%>)<br />
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString().Length>0){ %>
    		      <strong>Partita IVA: <%=dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString()%></strong><br />
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString().Length>0){ %>
    	        <strong>Codice Fiscale: <%=dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString()%></strong><br />
    	      <% } %>
    	      <i class="fa-duotone fa-envelope fa-fw"></i><%=dtAnagrafiche.Rows[0]["Anagrafiche_EmailContatti"].ToString()%><br />
    	      <i class="fa-duotone fa-phone fa-fw"></i><%=dtAnagrafiche.Rows[0]["Anagrafiche_Telefono"].ToString()%><br />
    	    </td>
          <td valign="top" width="200" align="right"><strong style="margin-right:10px">Responsabile vendite:</strong></td>
    	    <td valign="top" width="300">
    	      <div class="ragionesociale"><%=dtUtenti.Rows[0]["Utenti_Nominativo"].ToString()%></div>
    	      <i class="fa-duotone fa-envelope fa-fw"></i><%=dtUtenti.Rows[0]["Utenti_Email"].ToString()%><br />
    	      <i class="fa-duotone fa-phone fa-fw"></i><%=dtUtenti.Rows[0]["Utenti_Telefono1"].ToString()%><br />
            La miglior offerta del: <i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=Convert.ToDateTime(dtPreventiviAuto.Rows[0]["PreventiviAuto_Data"]).ToString("d/M/yyyy")%></strong>    	        
    	    </td>
    	  </tr>
    	  </table>

        <div class="tipodocumento" style="font-size:20px;font-weight:bold;color:#b71212;text-align:center;padding:0.2cm;border:2px solid #000000;margin-bottom:0.2cm">PREVENTIVO D'ACQUISTO</div>
          <div style="border:1px solid #000000;page-break-inside:avoid;margin-bottom:0.2cm;padding:0.2cm">
              <table border="0" cellpadding="4" cellspacing="4" class="corpo">
               <tr style="border-bottom:1px solid #000000">
                <td style="padding:1rem 0;">
    	            <div class="riga">
    	              <div class="titoloriga"><%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Marca"].ToString()%> <%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Modello"].ToString()%></div>
    	                <div class="testoriga" style="margin-top:1rem;">
                        <i class="fa-duotone fa-gauge-high fa-fw"></i>Km: <%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Km"].ToString()%> - 
                        <i class="fa-duotone fa-droplet fa-fw"></i>Colore: <%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Colore"].ToString()%>
                        <i class="fa-duotone fa-calendar fa-fw"></i>Anno: <%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Anno"].ToString()%>
                        </div>
    	            </div>
                </td>
                <td align="right">
                  <span class="prezzo">&euro; <%=((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_Prezzo"]).ToString("N2", ci)%></span>
                  <% decTotale=decTotale + ((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_Prezzo"]); %>
                </td>
                </tr>
                <%for (int j = 0; j < dtPreventiviAutoProdotti.Rows.Count; j++){ %>
                  <tr style="border-bottom:1px solid #000000" id="row<%=dtPreventiviAutoProdotti.Rows[j]["PreventiviAutoProdotti_Ky"].ToString()%>">
                    <td style="padding:1rem 0;"><div class="titoloriga"><%=dtPreventiviAutoProdotti.Rows[j]["PreventiviAutoProdotti_Descrizione"].ToString()%></div></td>
                    <td align="right"><span class="prezzo">&euro; <%=((decimal)dtPreventiviAutoProdotti.Rows[j]["PreventiviAutoProdotti_Prezzo"]).ToString("N2", ci)%></span></td>
                  </tr>
                  <% decTotale=decTotale + ((decimal)dtPreventiviAutoProdotti.Rows[j]["PreventiviAutoProdotti_Prezzo"]); %>
                <% } %>

                
                
                <% if (dtPreventiviAuto.Rows[0]["PreventiviAuto_Voltura"].Equals(true)){%>
               <tr style="border-bottom:1px solid #000000">
                <td style="padding:1rem 0;">
    	            <div class="riga">
    	              <div class="titoloriga">Voltura <%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Marca"].ToString()%> <%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Modello"].ToString()%></div>
    	            </div>
                </td>
                <td align="right">
                  <span class="prezzo">&euro; <%=((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_VolturaPrezzo"]).ToString("N2", ci)%></span>
                </td>
                </tr>
                <% decTotale=decTotale + ((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_VolturaPrezzo"]); %>
                <% }%>
                <% if (dtPreventiviAuto.Rows[0]["PreventiviAuto_Immatricolazione"].Equals(true)){%>
                <tr style="border-bottom:1px solid #000000">
                <td style="padding:1rem 0;">
    	            <div class="riga">
    	              <div class="titoloriga">Immatricolazione</div>
    	            </div>
                </td>
                <td align="right">
                  <span class="prezzo">&euro; <%=((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_ImmatricolazionePrezzo"]).ToString("N2", ci)%></span>
                </td>
                </tr>
                <% decTotale=decTotale + ((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_ImmatricolazionePrezzo"]); %>
                <% }%>
                
                <% if (dtPreventiviAuto.Rows[0]["PreventiviAuto_Permuta"].Equals(true)){%>
                <tr style="border-bottom:1px solid #000000">
                  <td style="padding:1rem 0;">
      	            <div class="riga">
      	              <div class="titoloriga">Auto in permuta</div>
                      <%=dtPreventiviAuto.Rows[0]["PreventiviAuto_PermutaAuto"].ToString()%>
      	            </div>
                  </td>
                  <td align="right">
      
                    <table border="0">
                      <tr>
                        <td align="right"><div style="margin-right:10px">Valore auto</div></td>
                        <td align="right">
                          <span class="prezzo">- &euro; <%=((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_PermutaValore"]).ToString("N2", ci)%></span>
                        </td>
                      </tr>
                      <tr style="border-bottom:1px solid #000000">
                        <td align="right"><div style="margin-right:10px">Minivoltura</div></td>
                        <td align="right">
                          <span class="prezzo"> &euro; <%=((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_PermutaVoltura"]).ToString("N2", ci)%></span>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
                <% decTotale=decTotale - ((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_PermutaValore"]); %>
                <% decTotale=decTotale + ((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_PermutaVoltura"]); %>
                <% }%>
                <tr style="border-bottom:1px solid #000000;display:none">
                <td style="padding:1rem 0;">
    	            <div class="riga">
    	              <div class="titoloriga">Totale</div>
    	            </div>
                </td>
                <td align="right">
                  <span class="prezzo">&euro; <%=decTotale.ToString("N2", ci)%></span>
                </td>
                </tr>

                <% if (Convert.ToDecimal(dtPreventiviAuto.Rows[0]["PreventiviAuto_Sconto"])>0){%>
                <tr style="border-bottom:1px solid #000000">
                <td style="padding:1rem 0;">
    	            <div class="riga">
    	              <div class="titoloriga">Sconto AutoFrancia</div>
    	            </div>
                </td>
                <td align="right">
                  <span class="prezzo">- &euro; <%=((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_Sconto"]).ToString("N2", ci)%></span>
                </td>
                </tr>
                <% decTotale=decTotale - ((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_Sconto"]); %>
                <% } %>
                <% if (Convert.ToDecimal(dtPreventiviAuto.Rows[0]["PreventiviAuto_ScontoPromozione"])>0){%>
                <tr style="border-bottom:1px solid #000000">
                <td style="padding:1rem 0;">
    	            <div class="riga">
    	              <div class="titoloriga">Sconto promo pack TTC</div>
    	            </div>
                </td>
                <td align="right">
                  <span class="prezzo">- &euro; <%=((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_ScontoPromozione"]).ToString("N2", ci)%></span>
                </td>
                </tr>
                <% decTotale=decTotale - ((decimal)dtPreventiviAuto.Rows[0]["PreventiviAuto_ScontoPromozione"]); %>
                <% }%>
                <tr style="border-bottom:1px solid #000000">
                <td style="padding:1rem 0;">
    	            <div class="riga">
    	              <div class="titoloriga">Totale a voi riservato</div>
    	            </div>
                </td>
                <td align="right">
                  <span class="prezzo" style="font-size:22px">&euro; <%=decTotale.ToString("N2", ci)%></span>
                </td>
                </tr>
               </table>
          </div>
        <% if (dtPreventiviAuto.Rows[0]["PagamentiMetodo_Titolo"].ToString().Length>0){ %>
    	  <h2>Pagamento: <%=dtPreventiviAuto.Rows[0]["PagamentiMetodo_Titolo"].ToString()%></h2> 
        <% } %>
        
        <% if (dtPreventiviAuto.Rows[0]["PreventiviAuto_NotePagamento"].ToString().Length>0){ %>
        <p style="font-size:1.125rem"><%=dtPreventiviAuto.Rows[0]["PreventiviAuto_NotePagamento"].ToString()%></p>
        <% } %>
    	  
        <% if (dtPreventiviAuto.Rows[0]["PreventiviAuto_Note"].ToString().Length>0){ %>
        <h2>Note</h2> 
        <p style="font-size:1.125rem"><%=dtPreventiviAuto.Rows[0]["PreventiviAuto_Note"].ToString()%></p>
        <% } %>
	   </div>
        
	</main>
	<footer id="footer_container">
	    <div id="footer_content">
			    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
	    </div>
	</footer>
</body>
</html>
