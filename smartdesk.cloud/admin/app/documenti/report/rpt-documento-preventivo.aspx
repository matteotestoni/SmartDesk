<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-documento-preventivo.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=dtDocumenti.Rows[0]["Documenti_Riferimenti"]%>-<%=GetUTF(dtDocumenti.Rows[0]["Anagrafiche_RagioneSociale"].ToString().Trim())%>-<%=GetUTF(dtDocumenti.Rows[0]["Documenti_Descrizione"].ToString().Trim())%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
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
				height:100%
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
				margin-bottom:5cmd;
			}
  </style>
</head>
<body>
	<header id="header_container">
	    <div id="header_content">
				  <table border="0" cellpadding="0" cellspacing="0" class="header" style="border:0">
				  <tr>
				    <td width="40%" align="left">
                <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:60px;max-width:230px;padding-top:10px;" />
				    </td>
				    <td width="60%" align="right">
				      <div style="border:0;padding:0;width:7cm;text-align:left">
				        <div class="tipodocumento"><%=dtDocumenti.Rows[0]["DocumentiTipo_Descrizione"].ToString()%></div>
				          <table border="0" cellpadding="0" cellspacing="5">
                          <tr> 
                            <td align="left" class="riferimenti">Numero:</td><td align="left"><strong><%=dtDocumenti.Rows[0]["Documenti_Numero"].ToString()%></strong></td>
                            <td width="60" align="right" class="riferimenti">Data:</td><td align="left"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtDocumenti.Rows[0]["Documenti_Data_IT"].ToString()%></strong></td>
                          </tr>
				          <% if (dtDocumenti.Rows[0]["Documenti_Riferimenti"].ToString().Length>0){ %>
						  <tr>
				             <td align="left" class="riferimenti">Ns. Rif:</td><td colspan="3"><%=dtDocumenti.Rows[0]["Documenti_Riferimenti"].ToString()%></td>
                          </tr>
				          <% } %>
                          </table>                            
				      </div>
				    </td>
				  </tr>
				  </table>
	    </div>
	</header>
	<main id="container">
	  <div id="content">
    	  <table border="0" cellpadding="0" cellspacing="0" class="intestazione" style="margin-bottom:0.5cm">
    	  <tr>
        <td valign="top" width="150" align="right"><strong style="margin-right:10px">Destinatario:</strong></td>
    	    <td valign="top">
    	      <div class="spettabile">Spettabile</div>
    	      <div class="ragionesociale"><%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%></div>
    	      <%=dtAnagrafiche.Rows[0]["Anagrafiche_Indirizzo"].ToString()%><br />
    	      <%=dtAnagrafiche.Rows[0]["Anagrafiche_CAP"].ToString()%> <%=dtAnagrafiche.Rows[0]["Comuni_Comune"].ToString()%> (<%=dtAnagrafiche.Rows[0]["Province_Provincia"].ToString()%>)<br />
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString().Length>0){ %>
    		      <strong>Partita IVA: <%=dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString()%></strong><br />
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString().Length>0){ %>
    	        - <strong>Codice Fiscale: <%=dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString()%></strong><br />
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_CodiceDestinatario"].ToString().Length>0){ %>
    	        <strong>SDI: <%=dtAnagrafiche.Rows[0]["Anagrafiche_CodiceDestinatario"].ToString()%></strong> 
    	      <% } %>
    	      <% if (dtAnagrafiche.Rows[0]["Anagrafiche_PEC"].ToString().Length>0){ %>
    	        - <strong>PEC: <%=dtAnagrafiche.Rows[0]["Anagrafiche_PEC"].ToString()%></strong><br />
    	      <% } %>
    	    </td>
    	  </tr>
    	  </table>

	        <%for (int i = 0; i < dtDocumentiCorpo.Rows.Count; i++){ %>
	          <div style="border:1px solid #000000;page-break-inside:avoid;margin-bottom:0.2cm;padding:0.2cm">
	            <div class="riga">
	              <div class="titoloriga"><%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Titolo"].ToString()%></div>
	              <span class="testoriga"><%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Descrizione"].ToString()%></span>
  							<% 
  								if (dtDocumenti.Rows[0]["AliquoteIVA_Aliquota"]!=DBNull.Value){
  									if ((decimal)dtDocumenti.Rows[0]["AliquoteIVA_Aliquota"]==0){
  										Response.Write(dtDocumentiCorpo.Rows[i]["AliquoteIVA_Descrizione"].ToString());
  									} 
  								}
  							%>
	            </div>
	            <div class="rigaprezzo" align="right">
                <table border="0" cellpadding="4" cellspacing="0" class="corpo">
	               <tr>
                  <td align="right" width="80">Quantit&agrave;:</td>
                  <td>
                    <span class="qta"><%=(dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Qta"]).ToString()%></span>
                  </td>
                  <td align="right" width="80">Prezzo:</td>
                  <td>
                    <% if (dtDocumentiCorpo.Rows[i]["DocumentiCorpo_ImportoTagliato"].ToString().Length>0){ %>
                    <span class="prezzotagliato">&euro; <%=((decimal)dtDocumentiCorpo.Rows[i]["DocumentiCorpo_ImportoTagliato"]).ToString("N2", ci)%></span>
                    <% } %>
                    <span class="prezzo">&euro; <%=((decimal)dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Importo"]).ToString("N2", ci)%></span>
                  </td>
                  <td align="right" width="80">Totale:</td>
                  <td align="right" width="100">
                    <span class="totaleriga">&euro; <%=((decimal)dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Totale_IT"]).ToString("N2", ci)%></span><br>
                    <span class="iva">+ <%=dtDocumentiCorpo.Rows[i]["AliquoteIVA_Descrizione"].ToString()%></span>
                  </td>
                  </tr>
                 </table>
              </div>
	          </div>
	        <% } %>


    	  <div class="privacy">I dati personali forniti dal Cliente sono tutelati dalla legge sulla privacy recante disposizioni a tutela delle persone e degli altri soggetti rispetto al trattamento dei dati personali, e pertanto saranno utilizzati in relazione alle esigenze contrattuali e di Legge.</div>
    	   
    	  <div class="pagamenti" style="page-break-before: always;">
    	    
    	    <h2>Modalit&agrave; di fatturazione e pagamento</h2>
    	    <hr>
    	    <strong><%=dtDocumenti.Rows[0]["Documenti_Note"].ToString()%></strong>
    				<%=dtAnagrafiche.Rows[0]["PagamentiCondizioni_Descrizione"].ToString() %><br>
            Pagamento tramite: <%=dtAnagrafiche.Rows[0]["PagamentiMetodo_Descrizione"].ToString() %><br>
    				Prezzi IVA Esclusa<br>
    				<h3>Banca di appoggio</h3>
    				<%=dtAzienda.Rows[0]["Aziende_BancaAppoggio"].ToString() %>
            
    		<div class="corpodocumento">
    		<strong><u>
    			Sottoscrivendo tutte le pagine del presente documento lo si approva e altresi si approvano le condizioni generali
    			di contratto presenti al seguente indirizzo https://www.rswstudio.it/condizioni-di-vendita/
    		</u></strong>
    		</div>
    		<div class="corpodocumento">
    			<strong>Per accettazione del presente Preventivo:</strong><br><br>
    			<table border="0" width="100%">
    				<tr>
    					<td width="50%">
    						<div style="border-bottom:1px dotted #000000;width:100%;line-height:1em">Luogo e data ,</div>
    						<br>
    						<small>(Apponendo la firma, questo documento sar&agrave; considerato come un ordine e per tale si approvano espressamente le clausole
    						delle Modalit&agrave; di fatturazione e condizioni di pagamento e Condizioni di collaborazione e di fornitura del servizio )</small>
    					</td>
    					<td width="50%" align="center" valign="middle">
    						<div style="width:100%;line-height:1em">Timbro e Firma</div>
    						<div style="border:1px solid #000000;width:300px;height:150px;"></div><br>
    					</td>
    				</tr>
    			</table>
    			<br>
    			<strong>A norma dell'articolo 1341 del c.c. si approvano espressamente le seguenti condizioni generali di contratto: artt.
    			5, 6, 9, 10, 12, 13, 14, 18 nonch&egrave; le modalit&agrave; di fatturazione e condizioni di pagamento del presente documento.</strong>
    			<br><br>
    			<table border="0" width="100%">
    				<tr>
    					<td width="50%">
    						<div style="border-bottom:1px dotted #000000;width:100%;line-height:2em">Luogo e data ,</div>
    					</td>
    					<td width="50%" align="center" valign="middle">
    						<div style="border-bottom:1px dotted #000000;width:100%;line-height:2em">Firma ,</div>
    					</td>
    				</tr>
    			</table>
    	  </div> 
    		<div class="corpodocumento">
    			<h2>DA FATTURARE A:</h2>
          <small>Specificare i dati se nuovo clienti o differiscono dall'intestazione del preventivo</small>
          <br><br>
    			<div style="border-bottom:1px dotted #000000;width:100%;line-height:1em">RAGIONE SOCIALE </div><br>
    			<div style="border-bottom:1px dotted #000000;width:100%;line-height:1em">INDIRIZZO</div><br>
    			<div style="border-bottom:1px dotted #000000;width:100%;line-height:1em">C.A.P. - CITT&Agrave; - PROVINCIA </div><br>
    			<div style="border-bottom:1px dotted #000000;width:100%;line-height:1em">TELEFONO </div><br>
    			<div style="border-bottom:1px dotted #000000;width:100%;line-height:1em">FAX </div><br>
    			<div style="border-bottom:1px dotted #000000;width:100%;line-height:1em">PARTITA I.V.A. </div><br>
    			<div style="border-bottom:1px dotted #000000;width:100%;line-height:1em">PEC e SDI</div><br>
    	  </div> 
    	</div>
    

	  </div>
	</div>  

	    </div>
	</main>
	<footer id="footer_container">
	    <div id="footer_content">
			    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
	    </div>
	</footer>
</body>
</html>
