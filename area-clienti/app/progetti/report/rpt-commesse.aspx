<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-Commesse.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>Commessa-<%=GetFieldValue("Commesse_Ky")%>-<%=GetUTF(GetFieldValue("Anagrafiche_RagioneSociale"))%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="stylesheet" href="/lib/fontawesome6/css/all.min.css" />
  <link rel="stylesheet" type="text/css" href="../rswcrm-print.css" media="screen, print" />
  <link rel="shortcut icon" href="img/favicon.ico">
  <style>
			*{
			  font-family: arial,sans-serif;
			}			
			a {
			  text-decoration : underline;
			  color : #000000;
			} 
			table.header{
			  width:20cm;
			  border:0;
			}
			div.titoloriga{
			  font-size:16px;
			  font-weight:bolder;
			}
			span.testoriga{
			  font-size:14px;
			  font-weight:bolder;
			}
			span.prezzo{
			  font-size:17px;
			  font-weight:bolder;
			}
			div.slogan{
			  font-size:12px;
			  font-style:italic;
			  font-weight:bolder;
			}
			td.totale{
			  padding:0 5px 0 0;
			  margin:0;
				font-weight:bolder;
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
			  width:20cm;
			  padding:0;
			  margin:0.2cm 0 0 0;
			}
			table.corpo{
			  margin:0.2cm 0 0 0;
			  width:20cm;
			  border-collapse:collapse;
			}
			table.corpo td.riga{
			  padding:15px 5px 15px 5px;
			}
			table.corpo td.rigaprezzo{
			  padding:15px 5px 15px 5px;
			}
			table.corpo td.titolo1{
			  font-weight:bolder;
			  font-size:14px;
			}
			table.corpo td.titololast{
			  font-weight:bolder;
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
			  width:20cm;
			}
			
			table.standard td{
			  border:1px solid #666666;
			  padding:1px;
			  margin:0px;
			}
			
			table.totali{
			  width:7cm;
			  border: 1px solid #666666;
			  margin-left:13cm;
			  margin-top:1cm;
			  margin-bottom:0.5cm;
			  border-collapse:collapse;
			}
			table.pagamenti{
			  width:20cm;
			  border-top: 1px solid #666666;
			  border-bottom: 1px solid #666666;
			  margin-top:0.2cm;
			}
			tr.intestazionecorpo{
			  background-color:#D5D5D5;
			}
			div.titolopagamento{
			  font-size:14px;
			  font-weight:bolder;
			}
			div.infopagamento{
			  font-size:14px;
			  font-weight:bolder;
			  margin-left:2cm;
			  line-height:1.5em;
			}
			div.titoloappoggio{
			  font-size:14px;
			  font-weight:bolder;
			  margin-top:0.5cm;
			}
			div.infoappoggio{
			  font-size:14px;
			  font-weight:bolder;
			  margin-left:2cm;
			}
			div.spettabile{
			  font-size:11px;
			}
			div.ragionesociale{
			  font-size:18px;
			  font-weight:bolder;
			}
			div.tipodocumento{
			  font-size:20px;
			  font-weight:bolder;
			}
			div.riferimenti{
			  font-size:14px;
			  font-weight:bolder;
			  width:65px;
			  padding-right:5px;
			  float:left;
			  text-align:left;
			}
			div.pagamenti{
			  width:20cm;
			  border-top:4px solid #666666;
			  border-bottom:4px solid #666666;
			  padding:0.2cm 0 0.2cm 0;
			}
			
			div.privacy{
			  margin-top:0.1cm;
			  width:20cm;
			  font-size:10px;
			  font-weight:bolder;
			  text-align:left;
			}
			
  </style>
</head>
<body style="margin:0;padding:0;background : #ffffff;color : #000000;border:0;font-size:13px;">
  <table border="0" cellpadding="0" cellspacing="0" class="header">
  <tr>
    <td width="40%">
      <div style="border:1px solid #666666;padding:20px;width:8cm;">
        <div class="tipodocumento"><%=GetFieldValue("Commesse_Titolo")%></div>
          <div class="riferimenti">Numero: </div><b><%=GetFieldValue("Commesse_Ky")%></b>
					<br style="clear:both">
					<br style="clear:both">
          <div class="riferimenti">Ns. Rif: </div><%=GetFieldValue("Commesse_Riferimenti")%><br />
      </div>
    </td>
    <td width="60%" align="center">
        <img src="/img/logo-print.jpg" border="0" width="260" style="padding-top:10px;" />
        <div class="slogan">
          Realizzazione siti web - Internet Marketing<br />
          Posizionamento motori ricerca<br />
          Realizzazione e-commerce<br />
        </div>
    </td>
  </tr>
  </table>
  <table border="0" cellpadding="0" cellspacing="0" class="intestazione" style="width:20cm;margin-top:0.2cm;">
  <tr>
    <td valign="top" width="150"><b>Destinatario:</b></td>
    <td valign="top">
      <div class="spettabile">Spettabile</div>
      <div class="ragionesociale"><%=GetFieldValue("Anagrafiche_RagioneSociale")%></div>
      <%=GetFieldValue("Anagrafiche_Indirizzo")%><br />
      <%=GetFieldValue("Comuni_Comune")%> (<%=GetFieldValue("Province_Provincia")%>)<br />
      <%if (GetFieldValue("Anagrafiche_PartitaIVA").Length>0){%>
	      <b>Partita IVA: <%=GetFieldValue("Anagrafiche_PartitaIVA")%></b><br />
      <%}%>
      <%if (GetFieldValue("Anagrafiche_CodiceFiscale").Length>0){%>
        <b>Codice Fiscale: <%=GetFieldValue("Anagrafiche_CodiceFiscale")%></b><br />
      <%}%>
    </td>
  </tr>
  </table>
  <table border="1" cellpadding="4" cellspacing="0" class="corpo" style="margin:0.2cm 0 0 0;width:20cm;border-collapse:collapse;"">
    <tr class="intestazionecorpo">
      <td width="70" class="titololast" align="center">Chiusura</td>
      <td class="titolo1" colspan="2">Descrizione dell'attivit&agrave;</td>
     	<td width="120" class="titololast">Persona</td>
      <td width="30" class="titololast" align="center">Ore</td>
    </tr>
    <%
			decTotOre=0;
			decTotOreMese=0;
			for (int i = 0; i < dtAttivita.Rows.Count; i++){
        if (intMese!=Convert.ToDateTime(dtAttivita.Rows[i]["Attivita_Chiusura"]).Month && i>0){%>
            <tr class="intestazionecorpo">
              <td colspan="4" align="right" style="padding-right:5px" class="titololast">Totale mese <%=intMese%>/<%=intAnno%></td>
              <td class="text-right" style="padding-right:5px" class="titololast"><b><%=decTotOreMese.ToString("N2", ci)%></b></td>
            </tr>
          <%
          decTotOreMese=0;
        }
        intMese=Convert.ToDateTime(dtAttivita.Rows[i]["Attivita_Chiusura"]).Month;
        intAnno=Convert.ToDateTime(dtAttivita.Rows[i]["Attivita_Chiusura"]).Year;
      %>
      <tr>
        <td class="text-center"><b><%=dtAttivita.Rows[i]["Attivita_Chiusura_IT"].ToString()%></b></td>
        <td class="text-center" width="36">
					<i class="<%=dtAttivita.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
				 	<%if (dtAttivita.Rows[i]["Attivita_Trasferta"].Equals(true)){%>
				 	  <i class="fa-duotone fa-car fa-fw"></i>
				 	<%}%>
				</td>
        <td style="padding:5px">
          <%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%>
        </td>
        <td class="text-center"><%=dtAttivita.Rows[i]["Utenti_Nominativo"].ToString()%></td>
        <td class="text-right">
					<%if (dtAttivita.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){%>
						<b><%=Convert.ToDouble(dtAttivita.Rows[i]["Attivita_Ore"]).ToString("N2", ci)%></b>
					<%}%>
				</td>
      </tr>
    <%
				if (dtAttivita.Rows[i]["Attivita_Ore"]!=System.DBNull.Value){
					decTotOre+=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"]);
					decTotOreMese+=Convert.ToDecimal(dtAttivita.Rows[i]["Attivita_Ore"]);
				}
			}
		%>
    <tr class="intestazionecorpo">
      <td colspan="4" align="right" style="padding-right:5px" class="titololast">Totale mese <%=intMese%>/<%=intAnno%></td>
      <td class="text-right" style="padding-right:5px" class="titololast"><b><%=decTotOreMese.ToString("N2", ci)%></b></td>
    </tr>
  </table>
  <table border="1" cellpadding="2" cellspacing="0" class="totali">
    <tr>
      <td class="riga" align="right"><b>Totale ore impiegate</b></td>
      <td class="text-right"><b><%=decTotOre.ToString("N2", ci)%></b></td>
    </tr>
  </table>
  <table border="0" cellpadding="4" cellspacing="0" style="margin-top:2.2cm;width:20cm;border-top:1px solid #000000;padding:0;font-size:9px;font-weight:bolder;text-align:center;">
    <tr>
    	<td>
        <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
			</td>
		</tr>
  </table>
</body>
</html>
