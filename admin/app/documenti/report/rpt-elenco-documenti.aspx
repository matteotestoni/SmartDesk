<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="rpt-elenco-documenti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title><%=dtDocumenti.Rows[0]["Documenti_Anno"]%>-<%=dtDocumenti.Rows[0]["Documenti_Numero"].ToString()%>-<%=GetUTF(dtDocumenti.Rows[0]["Anagrafiche_RagioneSociale"].ToString().Trim())%>-<%=GetUTF(dtDocumenti.Rows[0]["Documenti_Descrizione"].ToString().Trim())%></title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="preconnect" href="https://fonts.gstatic.com">
  <link type="text/css" rel="stylesheet" href="/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link rel="stylesheet" type="text/css" href="/admin/rswcrm-print.css" media="screen, print" />
  <link rel="stylesheet" href="/lib/fontawesome6/css/all.min.css" />
  <link rel="shortcut icon" href="/img/favicon/favicon.ico">
  <link rel="apple-touch-icon" sizes="57x57" href="/img/favicon/apple-icon-57x57.png">
  <link rel="apple-touch-icon" sizes="60x60" href="/img/favicon/apple-icon-60x60.png">
  <link rel="apple-touch-icon" sizes="72x72" href="/img/favicon/apple-icon-72x72.png">
  <link rel="apple-touch-icon" sizes="76x76" href="/img/favicon/apple-icon-76x76.png">
  <link rel="apple-touch-icon" sizes="114x114" href="/img/favicon/apple-icon-114x114.png">
  <link rel="apple-touch-icon" sizes="120x120" href="/img/favicon/apple-icon-120x120.png">
  <link rel="apple-touch-icon" sizes="144x144" href="/img/favicon/apple-icon-144x144.png">
  <link rel="apple-touch-icon" sizes="152x152" href="/img/favicon/apple-icon-152x152.png">
  <link rel="apple-touch-icon" sizes="180x180" href="/img/favicon/apple-icon-180x180.png">
  <link rel="icon" type="image/png" sizes="192x192" href="/img/favicon/android-icon-192x192.png">
  <link rel="icon" type="image/png" sizes="32x32" href="/img/favicon/favicon-32x32.png">
  <link rel="icon" type="image/png" sizes="96x96" href="/img/favicon/favicon-96x96.png">
  <link rel="icon" type="image/png" sizes="16x16" href="/img/favicon/favicon-16x16.png">
  <link rel="manifest" href="/img/favicon/manifest.json">
  <meta name="msapplication-TileColor" content="#ffffff">
  <meta name="msapplication-TileImage" content="/img/favicon/ms-icon-144x144.png">
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
			  width:25cm;
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
			.corpohor{
			  width:25cm;
			}
			div.corpo{
			  border-width:1px;
			  border-style:solid;
			  border-color:#ffffff #666666 #666666 #666666;
			  width:19cm;
			  height:12.5cm;
			  padding:0;
			  margin:0.2cm 0 0 0;
			}
			table.corpo{
			  width:100%;
			  border-collapse:collapse;
			  border-top:1px solid #666666;
			  border-bottom:1px solid #666666;
			  border-right:1px solid #ffffff;
			  border-left:1px solid #ffffff;
			}
			table.corpo td.riga{
			  border-top:1px solid #666666;
			  border-bottom:1px solid #666666;
			  border-right:1px solid #666666;
			  padding:10px 5px 10px 5px;
			}
			table.corpo td.rigaprezzo{
			  border-top:1px solid #666666;
			  padding:10px 5px 10px 5px;
			}
			table.corpo td.titolo1{
			  font-weight:700;
			  font-size:12px;
			  border-right:1px solid #666666;
			}
			table.corpo td.titololast{
			  font-weight:700;
			  border-top:1px solid #666666;
			  border-bottom:1px solid #666666;
			  font-size:12px;
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
			  margin-top:0.2cm;
			  margin-bottom:0.2cm;
			  border-collapse:collapse;
			}
			table.pagamenti{
			  width:19cm;
			  border-top: 1px solid #666666;
			  border-bottom: 1px solid #666666;
			  margin-top:0.2cm;
			}
			div.titolopagamento{
			  font-size:12px;
			  font-weight:700;
			  width:4cm;
			}
			div.infopagamento{
			  font-size:12px;
			  font-weight:700;
			  line-height:1.5em;
			}
			div.titoloappoggio{
			  font-size:12px;
			  font-weight:700;
			  width:4cm;
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
			  border-top:4px solid #666666;
			  border-bottom:4px solid #666666;
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
			  border-top:1px solid #a9a9a9;
			  padding:0;
			  font-size:9px;
			  font-weight:700;
			  text-align:center;
			}  
			div.footerhor{
			  margin-top:0.2cm;
			  width:25cm;
			  border-top:1px solid #a9a9a9;
			  padding:0;
			  font-size:9px;
			  font-weight:700;
			  text-align:center;
			}  
  </style>
</head>
<body style="margin-left:5px;">

	<table border="0" cellpadding="0" cellspacing="0" class="headerhor">
  <tr>
    <td width="40%" align="left">
        <img src="<%=dtAzienda.Rows[0]["Aziende_Logo"].ToString()%>" border="0" style="max-height:70px;max-width:250px;padding-top:10px;" />
    </td>
    <td width="60%" align="right">
      <div style="border:0;padding:10px;width:8cm;text-align:left">
        <div class="tipodocumento">Elenco documenti</div>
				<br style="clear:both">                                                                 
        <div class="riferimenti">Data: </div><%=DateTime.Now%><br />
      </div>
    </td>
  </tr>
  </table>
  

  <table class="grid hover stack corpohor" border="0" width="100%">
  	<thead>
      <tr>
		    <th width="5"></th>
        <th width="30">Cod</th>
        <th width="130">Tipo</th>
        <th width="40">N&deg;</th>
        <th width="110" align="center">Data</th>
        <th width="200">Anagrafica</th>
        <th width="80">Stato</th>
        <th width="100" align="center">Imponibile &euro;</th>
        <th width="90" align="center">IVA &euro;</th>
        <th width="80" align="center">Totale &euro;</th>
        <th width="150" data-orderable="false">Riferimenti</th>
      </tr>
  	</thead>
  	<tbody>
	    <%for (int i = 0; i < dtDocumenti.Rows.Count; i++){
        if (intMese!=Convert.ToDateTime(dtDocumenti.Rows[i]["Documenti_Data"]).Month && i>0){
          %>
					<tr style="border-top:1px solid #aaaaaa;margin-bottom:5px;border-bottom:5px solid #ffffff;border-right:1px solid #ffffff;border-left:1px solid #ffffff">
	          <td class="large-text-right small-text-left" bgcolor="#ffffff" colspan="4"></td>
            <td colspan="3" class="text-right" bgcolor="#cccccc" style="padding-right:5px"><strong>Totale fatturato mese <%=intMese%>/<%=intAnno%></strong></td>
            <td class="large-text-right small-text-left" style="padding-right:5px" bgcolor="#cccccc"><font color="#009933"><strong>&euro; <%=decTotServiziMese.ToString("N2", ci)%></strong></font></td>
            <td class="large-text-right small-text-left" style="padding-right:5px" bgcolor="#cccccc"><font color="#009933"><strong>&euro; <%=decTotIVAMese.ToString("N2", ci)%></strong></font></td>
            <td class="large-text-right small-text-left" style="padding-right:5px" bgcolor="#cccccc"><font color="#009933"><strong>&euro; <%=decTotMese.ToString("N2", ci)%></strong></font></td>
            <td colspan="3" bgcolor="#ffffff"></td>
          </tr>
          <%
          decTotMese=0;
          decTotServiziMese=0;
          decTotIVAMese=0;
        }
        intMese=Convert.ToDateTime(dtDocumenti.Rows[i]["Documenti_Data"]).Month;
        intAnno=Convert.ToDateTime(dtDocumenti.Rows[i]["Documenti_Data"]).Year;

	      if (intAnno!=Convert.ToInt32(dtDocumenti.Rows[i]["Documenti_Anno"].ToString()) && i>1){
	      %>
					<tr style="border-top:2px solid #cccccc;margin-bottom:5px;">
	          <td class="large-text-right small-text-left" bgcolor="#ffffff" colspan="4"></td>
	          <td class="large-text-right small-text-left" bgcolor="#cccccc" colspan="3">Totale fatturato:</td>
	          <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong>&euro; <%=decTotServizi.ToString("N2", ci)%></strong></td>
	          <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong>&euro; <%=decTotIVA.ToString("N2", ci)%></strong></td>
	          <td class="large-text-right small-text-left" bgcolor="#cccccc"><strong>&euro; <%=decTot.ToString("N2", ci)%></strong></td>
	          <td colspan="2" bgcolor="#ffffff"></td>
	        </tr>
				<%						
					decTot=0;
					decTotIVA=0;
					decTotServizi=0;
				} %>
	        <tr class="riga<%=i%2%>">
		        <td width="5" valign="top"><%=i+1%></td>
	          <td>
	            <a href="/admin/app/documenti/scheda-documenti.aspx?Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica" class="funzione"><%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%></a> 
	          </td>
	          <td class="large-text-center small-text-left"><strong><%=dtDocumenti.Rows[i]["DocumentiTipo_Descrizione"].ToString()%></strong></td>
	          <td class="large-text-center small-text-left"><a href="/admin/app/documenti/scheda-documenti.aspx?Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica" class="funzione"><strong><%=dtDocumenti.Rows[i]["Documenti_Numero"].ToString()%></strong></a></td>
	          <td class="large-text-center small-text-left"><a href="/admin/app/documenti/scheda-documenti.aspx?Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica" class="funzione"><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtDocumenti.Rows[i]["Documenti_Data_IT"].ToString()%></strong></a></td>
	          <td>
	          	<div class="width200">
	            <a href="/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=<%=dtDocumenti.Rows[i]["Anagrafiche_Ky"].ToString()%>&Documenti_Ky=<%=dtDocumenti.Rows[i]["Documenti_Ky"].ToString()%>&azione=modifica" class="funzione" title="Telefono: <%=dtDocumenti.Rows[i]["Anagrafiche_Telefono"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtDocumenti.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
							</div> 
	          </td>
	          <td class="large-text-center small-text-left"><%=getStato(dtDocumenti.Rows[i]["DocumentiStato_Ky"].ToString(), dtDocumenti.Rows[i]["DocumentiStato_Descrizione"].ToString())%></td>
	          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>">&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleRighe"]).ToString("N2", ci)%></td>
	          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>">&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_TotaleIVA"]).ToString("N2", ci)%></td>
	          <td class="large-text-right small-text-left" style="padding-right:5px" class="segno<%=dtDocumenti.Rows[i]["DocumentiTipo_Segno"].ToString()%>">&euro; <%=((decimal)dtDocumenti.Rows[i]["Documenti_Totale"]).ToString("N2", ci)%></td>
	          <td class="text-left">
							<div class="width150">
							<%=dtDocumenti.Rows[i]["Documenti_Riferimenti"].ToString()%>
							<% if (dtDocumenti.Rows[i]["Commesse_Ky"].ToString().Length>0){ %>
								| Progetto:<a href="/admin/app/progetti/scheda-commesse.aspx?Commesse_Ky=<%=dtDocumenti.Rows[i]["Commesse_Ky"].ToString()%>&sorgente=elenco-documenti" class="funzione" title="<%=dtDocumenti.Rows[i]["Commesse_Titolo"].ToString()%>"><i class="fa-duotone fa-circle-info fa-fw"></i><%=dtDocumenti.Rows[i]["Commesse_Riferimenti"].ToString()%></a>
							<% } %>
							</div>
						</td>
	        </tr>
	    <%
	      intAnno=Convert.ToInt32(dtDocumenti.Rows[i]["Documenti_Anno"].ToString());
				intDocumenti_Ky=Convert.ToInt32(dtDocumenti.Rows[i]["Documenti_Ky"].ToString());
	      if (Convert.ToInt32(dtDocumenti.Rows[i]["DocumentiTipo_Ky"])==1 || Convert.ToInt32(dtDocumenti.Rows[i]["DocumentiTipo_Ky"])==2){ 
					decTot+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_Totale"]);
          decTotMese+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_Totale"]);
		      decTotServizi+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleRighe"]);
		      decTotServiziMese+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleRighe"]);
		      decTotIVA+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleIVA"]);
		      decTotIVAMese+=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleIVA"]);
	      }
	      /*
	      if (Convert.ToInt32(dtDocumenti.Rows[i]["DocumentiTipo_Ky"])==2){ 
					decTot-=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_Totale"]);
          decTotMese-=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_Totale"]);
		      decTotServizi-=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleRighe"]);
		      decTotServiziMese-=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleRighe"]);
		      decTotIVA-=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleIVA"]);
		      decTotIVAMese-=Convert.ToDecimal(dtDocumenti.Rows[i]["Documenti_TotaleIVA"]);
	      }*/
	    } %>
			<tr style="border-top:2px solid #cccccc;margin-bottom:5px;">
        <td class="large-text-right small-text-left" bgcolor="#ffffff" colspan="5"></td>
        <td class="large-text-right small-text-left" bgcolor="#cccccc" colspan="2"><strong>Totale visualizzato:</strong></td>
        <td class="large-text-right small-text-left" bgcolor="#cccccc">&euro; <strong><%=decTotServizi.ToString("N2", ci)%></strong></td>
        <td class="large-text-right small-text-left" bgcolor="#cccccc">&euro; <strong><%=decTotIVA.ToString("N2", ci)%></strong></td>
        <td class="large-text-right small-text-left" bgcolor="#cccccc">&euro; <strong><%=decTot.ToString("N2", ci)%></strong></td>
        <td colspan="2" bgcolor="#ffffff"></td>
      </tr>
    	</tbody>
    </table>
   
  <div class="footerhor">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
  <script type="text/javascript" language="javascript">       
    //window.print();
  </script> 
</body>
</html>
