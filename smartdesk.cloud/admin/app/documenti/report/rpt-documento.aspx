<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-documento.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=dtDocumenti.Rows[0]["Documenti_Anno"]%>-<%=dtDocumenti.Rows[0]["Documenti_Numero"].ToString()%>-<%=GetUTF(dtDocumenti.Rows[0]["Anagrafiche_RagioneSociale"].ToString().Trim())%>-<%=GetUTF(dtDocumenti.Rows[0]["Documenti_Descrizione"].ToString().Trim())%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
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
			  font-size:15px;
			  font-weight:700;
			}
			span.testoriga{
			  font-size:13px;
			  font-weight:300;
			}
			span.prezzo{
			  font-size:16px;
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
			  border-color:#ffffff #a9a9a9 #a9a9a9 #a9a9a9;
			  width:19cm;
			  padding:0;
			  margin:0.2cm 0 0 0;
			}
			div.corpo{
			  border-width:1px;
			  border-style:solid;
			  border-color:#ffffff #a9a9a9 #a9a9a9 #a9a9a9;
			  width:19cm;
			  height:14.3cm;
			  padding:0;
			  margin:0.2cm 0 0 0;
			}
			table.corpo{
			  width:100%;
			  border-collapse:collapse;
			  border-top:1px solid #a9a9a9;
			  border-bottom:1px solid #a9a9a9;
			  border-right:1px solid #ffffff;
			  border-left:1px solid #ffffff;
			}
			table.corpo td.riga{
			  border-top:1px solid #a9a9a9;
			  border-bottom:1px solid #a9a9a9;
			  border-right:1px solid #a9a9a9;
			  padding:5px 5px 5px 5px;
			}
			table.corpo td.rigaprezzo{
			  border-top:1px solid #a9a9a9;
			  padding:5px 5px 5px 5px;
			}
			table.corpo td.titolo1{
			  font-weight:700;
			  font-size:12px;
			  color:#000000;
			  border-top:0;
			  border-left:0;
			  border-right:0;
				border-bottom:1px solid #a9a9a9;
			}
			table.corpo td.titololast{
			  font-weight:700;
			  border-top:0;
			  border-bottom:1px solid #a9a9a9;
			  font-size:12px;
			  color:#000000;
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
			  border: 0;
			  margin-left:12cm;
			  margin-top:0.2cm;
			  margin-bottom:0.2cm;
			  border-collapse:collapse;
			}
			table.pagamenti{
			  width:19cm;
			  border-top: 1px solid #a9a9a9;
			  border-bottom: 1px solid #a9a9a9;
			  margin-top:0.2cm;
			}
			div.titolopagamento{
			  font-size:14px;
			  font-weight:700;
			  width:4cm;
			  color:#000000;
			  text-align:right;
			}
			div.infopagamento{
			  font-size:12px;
			  font-weight:700;
			  line-height:1.5em;
			}
			div.titoloappoggio{
			  font-size:14px;
			  font-weight:700;
			  width:4cm;
			  text-align:right;
			  color:#000000;
			}
			div.infoappoggio{
			  font-size:12px;
			  font-weight:700;
			}
			div.infoIVA{
			  width:19cm;
			  padding:0;
			  margin:0.2cm 0 0.2cm 0;
			  font-size:12px;
			  font-weight:normal;
			}
			div.azienda{
				text-align:left;
				font-size:12px;
				margin-left:4em;
			}
			div.pagamenti{
			  width:19cm;
			  border-top:4px solid #a9a9a9;
			  border-bottom:4px solid #a9a9a9;
			  padding:0.2cm 0 0.2cm 0;
			}
			
			div.privacy{
			  margin-top:0.1cm;
			  width:19cm;
			  font-size:10px;
			  font-weight:300;
			  text-align:left;
			}
			
			div.footer{
			  margin-top:0.2cm;
			  width:19cm;
			  padding:0;
			  font-size:9px;
			  font-weight:700;
			  text-align:center;
			}  
  </style>
</head>
<body style="margin-left:5px;">
	<div id="header_container">
	    <div id="header_content">
        <table border="0" cellpadding="0" cellspacing="0" class="header" style="border:0">
        <tr>
          <td width="40%" align="left">
              <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
          </td>
          <td width="60%" align="right">
            <div style="border:0;padding:10px;width:7cm;text-align:left">
              <div class="tipodocumento"><%=dtDocumenti.Rows[0]["DocumentiTipo_Descrizione"].ToString()%></div>
      				          <table border="0" cellpadding="0" cellspacing="5">
                                <tr> 
                                  <td align="left" class="riferimenti">Numero:</td><td align="left"><strong><%=dtDocumenti.Rows[0]["Documenti_Numero"].ToString()%></strong></td>
                                  <td width="60" align="right" class="riferimenti">Data:</td><td align="left"><i class="fa-duotone fa-calendar-days fa-fw"></i></div><strong><%=dtDocumenti.Rows[0]["Documenti_Data_IT"].ToString()%></strong></td>
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
	</div>
	<div id="container" style="margin-top:3.5cm">
	  <div id="content">

        <table border="0" cellpadding="0" cellspacing="0" class="intestazione">
        <tr>
          <td valign="top" width="150" align="right"><strong style="margin-right:10px">Destinatario:</strong></td>
          <td valign="top">
            <div class="spettabile">Spettabile</div>
            <div class="ragionesociale"><%=dtDocumenti.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%></div>
            <%=dtDocumenti.Rows[0]["Anagrafiche_Indirizzo"].ToString()%><br />
            <%=dtDocumenti.Rows[0]["Anagrafiche_CAP"].ToString()%> <%=dtDocumenti.Rows[0]["Comuni_Comune"].ToString()%> (<%=dtDocumenti.Rows[0]["Province_Provincia"].ToString()%>)<br />
            <% if (dtDocumenti.Rows[0]["Anagrafiche_PartitaIVA"].ToString().Length>0){ %>
      	      <strong>Partita IVA: <%=dtDocumenti.Rows[0]["Anagrafiche_PartitaIVA"].ToString()%></strong>
            <% } %>
            <% if (dtDocumenti.Rows[0]["Anagrafiche_CodiceFiscale"].ToString().Length>0){ %>
              - <strong>Codice Fiscale: <%=dtDocumenti.Rows[0]["Anagrafiche_CodiceFiscale"].ToString()%></strong><br />
            <% } %>
          </td>
        </tr>
        </table>
      
        <div class="corpo">
            <table border="0" cellpadding="4" cellspacing="0" class="corpo">
              <tr class="intestazionecorpo">
                <td class="titolo1">Descrizione</td>
                <td width="90" class="titololast" align="center">Importo &euro;</td>
              </tr>
              <%for (int i = 0; i < dtDocumentiCorpo.Rows.Count; i++){ %>
                <tr>
                  <td class="riga">
                    <div class="titoloriga"><%=dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Titolo"].ToString()%></div>
                    <span class="testoriga"><%=StripTagsCharArray(dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Descrizione"].ToString())%></span>
                  </td>
                  <td class="rigaprezzo" align="right" valign="top"><span class="prezzo">&euro; <%=((decimal)dtDocumentiCorpo.Rows[i]["DocumentiCorpo_Totale_IT"]).ToString("N2", ci)%></span></td>
                </tr>
              <% } %>
            </table>
        </div>
        
        <table border="0" cellpadding="2" cellspacing="0" class="totali">
          <% if ((decimal)dtDocumenti.Rows[0]["Documenti_TotaleIVA"]!=0){ %>
          <tr>
            <td class="totale" align="right"><strong>Totale</strong></td>
            <td width="100" align="right"><span class="prezzo">&euro; <%=Math.Abs((decimal)dtDocumenti.Rows[0]["Documenti_TotaleRighe_IT"]).ToString("N2", ci)%></span></td>
          </tr>
      		<tr>
            <td class="totale" align="right"><strong>IVA <%=((decimal)dtDocumenti.Rows[0]["AliquoteIVA_Aliquota"]).ToString("N0", ci)%>%</strong></td>
            <td width="100" align="right"><span class="prezzo">&euro; <%=Math.Abs((decimal)dtDocumenti.Rows[0]["Documenti_TotaleIVA_IT"]).ToString("N2", ci)%></span></td>
          </tr>
      		<% } %>
          <tr>
            <td class="totale" align="right"><strong>Importo Totale</strong></td>
            <td width="100" align="right"><span class="prezzo">&euro; <%=Math.Abs((decimal)dtDocumenti.Rows[0]["Documenti_Totale_IT"]).ToString("N2", ci)%></span></td>
          </tr>
        </table>
         
        <% if (((decimal)dtAzienda.Rows[0]["AliquoteIVA_Aliquota"])==0){ %>
      	<div class="infoIVA">
      		<%=dtAzienda.Rows[0]["AliquoteIVA_Descrizione"].ToString()%>
        </div> 
        <% } %>
      
        <div class="pagamenti">
          <strong><%=dtDocumenti.Rows[0]["Documenti_Note"].ToString()%></strong>
      
          <% if (dtPagamenti.Rows.Count>0){ %>
          <table border="0">
          	<tr>
          		<td valign="top"><div class="titolopagamento">Pagamento:</div></td>
          		<td valign="top">
      			    <div class="infopagamento">
      			      <%for (int i = 0; i < dtPagamenti.Rows.Count; i++){ %>
      			      	<% if (dtPagamenti.Rows[i]["Pagamenti_Pagato"].ToString()=="no"){ %>
      			        	&euro; <%=dtPagamenti.Rows[i]["Pagamenti_Importo_IT"].ToString()%> IVA Compresa tramite <strong><%=dtPagamenti.Rows[i]["PagamentiMetodo_Descrizione"].ToString()%></strong> 
      								<%
      								if (dtPagamenti.Rows[i]["Pagamenti_Data_IT"].ToString()==dtDocumenti.Rows[0]["Documenti_Data_IT"].ToString()){
      									Response.Write(" RIMESSA DIRETTA");
      								}else{
      									Response.Write(" entro il " + dtPagamenti.Rows[i]["Pagamenti_Data_IT"].ToString());
      								}
      									%><br />
      			        <% }else{ %>
      			        	&euro; <%=dtPagamenti.Rows[i]["Pagamenti_Importo_IT"].ToString()%> IVA Compresa <strong>PAGATI</strong> il <%=dtPagamenti.Rows[i]["Pagamenti_DataPagato_IT"].ToString()%><br />
      							<% } %>
      			      <% } %>
      			    </div> 
      				</td>
      			</tr>
      		</table>  
          <% } %>
          <table border="0">
          	<tr>
          		<td valign="top"><div class="titoloappoggio">Banca di appoggio:</div></td>
          		<td valign="top">
      			    <div class="infoappoggio">
      			  		<%=dtAzienda.Rows[0]["Aziende_BancaAppoggio"].ToString()%>
      			    </div>  
      				</td>
      			</tr>
      		</table>  
        </div>  
        <div class="privacy">I dati personali forniti dal Cliente sono tutelati dal GPDR recante disposizioni a tutela delle persone e degli altri soggetti rispetto al trattamento dei dati personali, e pertanto saranno utilizzati in relazione alle esigenze contrattuali e di Legge.</div>
	    </div>
	</div>
	<div id="footer_container">
	    <div id="footer_content">
          <div class="footer">
            <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
          </div>
	    </div>
	</div>
</body>
</html>
