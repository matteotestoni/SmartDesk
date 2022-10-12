<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-commesse-campagna.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>Progetto-<%=GetFieldValue("Commesse_Ky")%>-<%=GetUTF(GetFieldValue("Anagrafiche_RagioneSociale"))%></title>
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
			  font-weight:700;
			}
			span.prezzo{
			  font-size:17px;
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
			div.corpodocumento{
			  border-width:0px;
			  border-style:solid;
			  border-color:#ffffff #666666 #666666 #666666;
			  width:19cm;
			  padding:0;
			  margin:0.2cm 0 0 0;
			}
			table.corpo{
			  margin:0.2cm 0 0 0;
			  width:19cm;
			  border-collapse:collapse;
			}
			table.corpo td.riga{
			  padding:15px 5px 15px 5px;
			}
			table.corpo td.rigaprezzo{
			  padding:15px 5px 15px 5px;
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
			
  </style>
</head>
<body style="margin:0;padding:0;background : #ffffff;color : #000000;border:0;font-size:13px;">
  <table border="0" cellpadding="0" cellspacing="0" class="header">
  <tr>
    <td width="40%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:10px;width:8cm;text-align:left">
        <div class="tipodocumento">Progetto</div>
          <div class="riferimenti">Numero: </div><strong><%=GetFieldValue("Commesse_Ky")%></strong>
					<br style="clear:both">                                                                 
          <div class="riferimenti">Ns. Rif: </div><%=GetFieldValue("Commesse_Riferimenti")%><br />
      </div>
    </td>
  </tr>
  </table>
  <table border="0" cellpadding="0" cellspacing="0" class="intestazione" style="width:19cm;margin-top:0.2cm;">
  <tr>
    <td valign="top" width="150" align="right"><strong style="margin-right:10px">Destinatario:</strong></td>
    <td valign="top">
      <div class="spettabile">Spettabile</div>
      <div class="ragionesociale"><%=GetFieldValue("Anagrafiche_RagioneSociale")%></div>
      <%=GetFieldValue("Anagrafiche_Indirizzo")%><br />
      <%=GetFieldValue("Comuni_Comune")%> (<%=GetFieldValue("Province_Provincia")%>)<br />
      <% if (GetFieldValue("Anagrafiche_PartitaIVA").Length>0){ %>
	      <strong>Partita IVA: <%=GetFieldValue("Anagrafiche_PartitaIVA")%></strong><br />
      <% } %>
      <% if (GetFieldValue("Anagrafiche_CodiceFiscale").Length>0){ %>
        <strong>Codice Fiscale: <%=GetFieldValue("Anagrafiche_CodiceFiscale")%></strong><br />
      <% } %>
    </td>
  </tr>
  </table>
  <h1><%=GetFieldValue("Commesse_Titolo")%></h1>
	<table border="1" cellpadding="4" cellspacing="0" class="corpo" style="margin:0.2cm 0 0 0;width:19cm;border-collapse:collapse;"">
    <tr class="intestazionecorpo">
      <td width="70" class="titololast" align="center">Chiusura</td>
      <td class="titolo1">Descrizione dell'attivit&agrave;</td>
     	<td width="120" class="titololast" align="center">Utente</td>
			<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaCampagna")){ %>
     	<td width="100" class="titololast" align="center">Campagna</td>
      <% } %>
			<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")){ %>
     	<td width="80" class="titololast" align="center">Budget &euro; </td>
      <% } %>
     	<td width="100" class="titololast" align="center">Categoria</td>
      <td width="30" class="titololast" align="right">Ore</td>
    </tr>
    <%
			decTotOre=0;
			decTotOreMese=0;
			for (int i = 0; i < dtAttivita.Rows.Count; i++){
        intMese=Convert.ToDateTime(dtAttivita.Rows[i]["Attivita_Chiusura"]).Month;
        intAnno=Convert.ToDateTime(dtAttivita.Rows[i]["Attivita_Chiusura"]).Year;
      %>
      <tr>
        <td align="center"><strong><%=dtAttivita.Rows[i]["Attivita_Chiusura"].ToString()%></strong></td>
        <td align="left" style="padding:5px">
					<i class="<%=dtAttivita.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
				 	<% if (dtAttivita.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
						<i class="fa-duotone fa-car fa-fw"></i>
				 	<% } %>
          <%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%>
        </td>
        <td align="center"><%=dtAttivita.Rows[i]["Utenti_Nominativo"].ToString()%></td>
  			<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaCampagna")){ %>
        <td align="center"><%=dtAttivita.Rows[i]["Attivita_Campagna"].ToString()%></td>
        <% } %>
  			<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")){ %>
        <td align="right">
          <%
				    if (dtAttivita.Rows[i]["Attivita_Budget"]!=System.DBNull.Value){
              Response.Write(Convert.ToDouble(dtAttivita.Rows[i]["Attivita_Budget"]).ToString("N2", ci));
            }
          %>
        </td>
        <% } %>
        <td align="center"><i class="<%=dtAttivita.Rows[i]["AttivitaCategorie_Icona"].ToString()%> fa-fw"></i><%=dtAttivita.Rows[i]["AttivitaCategorie_Titolo"].ToString()%></td>
        <td align="right" class="large-text-right small-text-left">
					<% if (dtAttivita.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){ %>
						<strong><%=Convert.ToDouble(dtAttivita.Rows[i]["Attivita_Ore"]).ToString("N2", ci)%></strong>
					<% } %>
				</td>
      </tr>
    <%
				if (dtAttivita.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
					decTotOre+=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"]);
					decTotOreMese+=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"]);
				}
				if (dtAttivita.Rows[i]["Attivita_Budget"]!=System.DBNull.Value){
					decTotBudget+=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Budget"]);
					decTotBudgetMese+=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Budget"]);
				}
			}
		%>
    <tfoot>
    <tr>
      <td class="riga" align="right" colspan="<%=intColonne%>"><strong>Totali</strong></td>
      <td class="large-text-right" align="right">
  			<% if (GetCheckValue(dtCommesse, "Commesse_AbilitaBudget")){ %>
        <strong>&euro; <%=decTotBudget.ToString("N2", ci)%></strong>
        <% } %>
      </td>
      <td></td>
      <td class="large-text-right" align="right"><strong><%=decTotOre.ToString("N2", ci)%></strong></td>
    </tr>
    </tfoot>
  </table>
  <div class="footer">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
