<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-commesse-scheda.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>Progetti > Progetto-<%=GetFieldValue("Commesse_Ky")%>-<%=GetUTF(GetFieldValue("Anagrafiche_RagioneSociale"))%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <link rel="stylesheet" href="/lib/fontawesome6/css/all.min.css" />
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
			table.headerhor{
			  width:27cm;
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
  <table border="0" cellpadding="0" cellspacing="0" class="headerhor">
  <tr>
    <td width="40%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:20px;width:7cm;text-align:left">
        <div class="tipodocumento">Scheda progetto</div>
          <div style="">
						Numero: <strong><%=GetFieldValue("Commesse_Ky")%></strong><br>
						Data: <strong><%=GetFieldValue("Commesse_Data_IT")%></strong><br />
          	Ns. Rif: <strong><%=GetFieldValue("Commesse_Riferimenti")%></strong><br />
           </div>
      </div>
    </td>
  </tr>
  </table>

  <h1><%=GetFieldValue("Commesse_Titolo")%></h1>
	<table border="1" cellpadding="4" cellspacing="0" class="corpo" style="margin:0.2cm 0 0 0;width:27cm;border-collapse:collapse;"">
  	<thead>
    <tr class="intestazionecorpo">
      <td width="100" class="titololast" align="center">Entro il<br>Chiusa il</td>
      <td class="titolo1" width="300">Descrizione dell'attivit&agrave;</td>
     	<td width="120" class="titololast text-center" align="center">Persona</td>
      <td width="60" class="titololast text-center" align="center">Ore</td>
      <td width="60" class="titololast text-center" align="center">Costo orario</td>
      <td width="60" class="titololast text-center" align="center">Totale costo</td>
    </tr>
  	</thead>
  	<tbody>
    <%
			decTotOre=0;
			decTotOreMese=0;
			decTotCostoOrario=0;
			decTotCostoOrarioMese=0;
			for (int i = 0; i < dtAttivita.Rows.Count; i++){
      %>
      <tr>
        <td align="left">
					<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivita.Rows[i]["Attivita_Scadenza_IT"].ToString()%><br>
					<strong><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAttivita.Rows[i]["Attivita_Chiusura_IT"].ToString()%></strong>
				</td>
        <td style="padding:5px">
        	<div style="max-width:300px;height:50px;max-height:50px;overflow:hidden">
					<i class="<%=dtAttivita.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
					<% if (dtAttivita.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
						<i class="fa-duotone fa-car fa-fw"></i>
					<% } %>
          <%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%>
          </div>
        </td>
        <td align="center"><i class="fa-duotone fa-user fa-fw"></i><%=dtAttivita.Rows[i]["Utenti_Nominativo"].ToString()%></td>
        <td class="large-text-right small-text-left" align="right">
					<% if (dtAttivita.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){ %>
						<strong><i class="fa-duotone fa-clock fa-fw"></i><%=Convert.ToDouble(dtAttivita.Rows[i]["Attivita_Ore"]).ToString("N2", ci)%></strong>
					<% } %>
				</td>
        <td class="large-text-right small-text-left" align="right">
					&euro; <%=Convert.ToDecimal(dtAttivita.Rows[i]["Persone_CostoOrario"]).ToString("N2", ci)%>
				</td>
        <td class="large-text-right small-text-left" align="right">
					<% if (dtAttivita.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){ %>
						&euro; <strong><%=(Convert.ToDecimal(dtAttivita.Rows[i]["Persone_CostoOrario"])*Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"])).ToString("N2", ci)%></strong>
					<% } %>
				</td>
      </tr>
    <%
				if (dtAttivita.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
					decTotOre+=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"]);
					decTotOreMese+=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"]);
			    decTotCostoOrario=decTotCostoOrario + (Convert.ToDecimal(dtAttivita.Rows[i]["Persone_CostoOrario"])*Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"])); 
			    decTotCostoOrarioMese=decTotCostoOrarioMese + (Convert.ToDecimal(dtAttivita.Rows[i]["Persone_CostoOrario"])*Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"])); 
				}
			}
		%>
    <tr>
		  <td width="100" class="titololast" align="right" colspan="3">Totali</td>
      <td width="60" class="titololast" align="right"><i class="fa-duotone fa-clock fa-fw"></i><%=decTotOre%></td>
      <td width="60" class="titololast" align="center"></td>
      <td width="60" class="titololast" align="right">&euro;<%=decTotCostoOrario.ToString("N2", ci)%></td>
    </tr>
  </tbody>

	</table>
  <div class="footerhor">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
