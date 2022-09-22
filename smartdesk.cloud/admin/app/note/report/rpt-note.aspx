<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/note/report/rpt-note.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>Nota-<%=GetFieldValue("Note_Ky")%>-<%=GetUTF(GetFieldValue("Note_Titolo"))%></title>
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
			  border-color:#ffffff #ffffff #a9a9a9 #a9a9a9;
			}
			div.corpodocumento{
			  border-width:0px;
			  border-style:solid;
			  border-color:#ffffff #a9a9a9 #a9a9a9 #a9a9a9;
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
			  border-top:1px solid #a9a9a9;
			  border-bottom:1px solid #a9a9a9;
			  font-size:14px;
			}
			table.corpo td.rigadocumento{
			  border-bottom:1px solid #a9a9a9;
			  border-right:1px solid #a9a9a9;
			  border-left:1px solid #a9a9a9;
			  padding:15px 5px 15px 5px;
			}
			
			table.standard{
			  width:19cm;
			}
			
			table.standard td{
			  border:1px solid #a9a9a9;
			  padding:1px;
			  margin:0px;
			}
			
			table.totali{
			  width:7cm;
			  border: 1px solid #a9a9a9;
			  margin-left:12cm;
			  margin-top:1cm;
			  margin-bottom:0.5cm;
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
			  border-top:4px solid #a9a9a9;
			  border-bottom:4px solid #a9a9a9;
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
      <div style="border:0;padding:10px;width:7cm;text-align:left">
        <div class="tipodocumento">Scheda nota</div>
          <div class="riferimenti">Numero: </div><strong><%=GetFieldValue("Note_Ky")%></strong>
					<br style="clear:both">
          <div class="riferimenti">Data: </div><%=DateTime.Now%>
      </div>
    </td>
  </tr>
  </table>
  <table border="0" cellpadding="0" cellspacing="0" class="intestazione" style="width:19cm;margin-top:0.2cm;">
  <tr>
    <td valign="top" width="120" align="left"><strong style="margin-right:10px">Cliente:</strong></td>
    <td valign="top"><%=GetFieldValue("Anagrafiche_RagioneSociale")%></td>
  </tr>
  <tr>
    <td valign="top" width="120" align="left"><strong style="margin-right:10px">Categoria:</strong></td>
    <td valign="top"><%=GetFieldValue("NoteCategorie_Titolo")%></td>
  </tr>
  <tr>
    <td valign="top" width="120" align="left"><strong style="margin-right:10px">Lingue:</strong></td>
    <td valign="top"><%=GetFieldValue("Lingue_Titolo")%></td>
  </tr>
  </table>
  <table border="1" cellpadding="4" cellspacing="0" class="corpo" style="margin:0.2cm 0 0 0;width:19cm;border-collapse:collapse;border:0;">
  <tr>
  	<td>
			<h1><%=GetFieldValue("Note_Titolo")%></h1>
			<%=TextToHtml(GetFieldValue("Note_Descrizione"))%>
  	</td>
  </tr>
  </table>
  
  <div class="footer">
    <%=dtAzienda.Rows[0]["Aziende_Footer"].ToString()%>
  </div>
</body>
</html>
