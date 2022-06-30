<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/catalogo/scheda-prodotto.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
  <title>amministrazione</title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<script src="//cdn.ckeditor.com/4.19.0/full/ckeditor.js"></script>
  <script type="text/javascript" src="../lib/livevalidation/livevalidation_standalone.js"></script>
	<script type="text/javascript" src="../lib/jquery/jquery-1.9.1.min.js"></script>
  <script type="text/javascript" src="../lib/jquery/jquery-ui-git.js"></script>
  <script type="text/javascript" src="../lib/jquery/jquery.ui.datepicker-it.js"></script>
	<link rel="stylesheet" href="../lib/jquery/themes/base/jquery-ui-git.css">
  <script type="text/javascript" src="/area-clienti/rswcrm.js"></script>
  <link rel="stylesheet" type="text/css" href="/area-clienti/rswcrm.css" media="screen, print" />
  <link rel="shortcut icon" href="/area-clienti/img/favicon.ico">
  <script type="text/javascript" src="../lib/autosuggest/js/bsn.AutoSuggest_2.1.3.js"></script>
  <link rel="stylesheet" href="../lib/autosuggest/css/autosuggest_inquisitor.css" type="text/css" media="screen, print" charset="utf-8" />
	<style>
	#gallery { float: left; width: 65%; min-height: 12em; } * html #gallery { height: 12em; } /* IE6 */
	.gallery.custom-state-active { background: #eee; }
	.gallery li { float: left; min-height:120px;width: 96px; padding: 0.4em; margin: 0 0.4em 0.4em 0; text-align: center; }
	.gallery li h5 { margin: 0 0 0.4em; }
	.gallery li a { float: right; }
	.gallery li a.ui-icon-zoomin { float: left; }
	.gallery li img { width: 100%;  }
	</style>
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
  <div id="main">
    <div id="contenuto">
    <form action="/area-clienti/app/catalogo/crud/salva-prodotti.aspx" method="post" enctype="multipart/form-data">
    <div id="tabs">
    	<ul>
    		<li><a href="#tabs-1">Scheda</a></li>
    		<li><a href="#tabs-2">Dati tecnici</a></li>
    		<li><a href="#tabs-3">Inventario</a></li>
    		<li><a href="#tabs-4">Foto</a></li>
    		<li><a href="#tabs-5">Allegati</a></li>
    	</ul>
	  <div id="tabs-1">
          <table class="form" width="100%" border="0">
            <tr>
              <td width="85" class="lbl">Codice *</td>
              <td width="275" colspan="3">
                <input type="text" class="txt" name="Prodotti_Codice" id="Prodotti_Codice" title="Codice alfanumerico del prodotto" value="<%=dtProdotto.Rows[0]["Prodotti_Codice"].ToString()%>" size="15">
                <script type="text/javascript">
                  var Prodotti_Codice = new LiveValidation('Prodotti_Codice', { validMessage: "ok" });
                  Prodotti_Codice.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
                Attivo
                <input type="checkbox" name="Prodotti_PubblicaWEB" id="Prodotti_PubblicaWEB" value="on" <%if (dtProdotto.Rows[0]["Prodotti_PubblicaWEB"].Equals(true)){ Response.Write("checked");}%> />
                <script type="text/javascript">
                  var Prodotti_PubblicaWEB = new LiveValidation('Prodotti_PubblicaWEB', { validMessage: "ok" });
                  Prodotti_PubblicaWEB.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
                In vetrina
                <input type="checkbox" name="Prodotti_InVetrina" id="Prodotti_InVetrina" value="on" <%if (dtProdotto.Rows[0]["Prodotti_InVetrina"].Equals(true)){ Response.Write("checked");}%> />
                <script type="text/javascript">
                  var Prodotti_InVetrina = new LiveValidation('Prodotti_InVetrina', { validMessage: "ok" });
                  Prodotti_InVetrina.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
                In Offerta
                <input type="checkbox" name="Prodotti_InOfferta" id="Prodotti_InOfferta" value="on" <%if (dtProdotto.Rows[0]["Prodotti_InOfferta"].Equals(true)){ Response.Write("checked");}%> />
                <script type="text/javascript">
                  var Prodotti_InOfferta = new LiveValidation('Prodotti_InOfferta', { validMessage: "ok" });
                  Prodotti_InOfferta.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
                In Promozione
                <input type="checkbox" name="Prodotti_InPromozione" id="Prodotti_InPromozione" value="on" <%if (dtProdotto.Rows[0]["Prodotti_InPromozione"].Equals(true)){ Response.Write("checked");}%> />
                <script type="text/javascript">
                  var Prodotti_InPromozione = new LiveValidation('Prodotti_InPromozione', { validMessage: "ok" });
                  Prodotti_InPromozione.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
                Outlet
                <input type="checkbox" name="Prodotti_Outlet" id="Prodotti_Outlet" value="on" <%if (dtProdotto.Rows[0]["Prodotti_Outlet"].Equals(true)){ Response.Write("checked");}%> />
                <script type="text/javascript">
                  var Prodotti_Outlet = new LiveValidation('Prodotti_Outlet', { validMessage: "ok" });
                  Prodotti_Outlet.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
                Ordine
                <input type="text" class="txt" name="Prodotti_Ordine" id="Prodotti_Ordine" title="Ordine di visualizzazione in elenco prodotti" value="<%=dtProdotto.Rows[0]["Prodotti_Ordine"].ToString()%>" size="5">
              </td>
            </tr>
            <tr>
              <td width="85" class="lbl">Prezzo &euro;</td>
              <td colspan="3">
                <input type="text" class="txt" name="Prodotti_Prezzo" id="Prodotti_Prezzo"  value="<%=dtProdotto.Rows[0]["Prodotti_Prezzo"].ToString()%>" size="10">
                <script type="text/javascript">
                  var Prodotti_Prezzo = new LiveValidation('Prodotti_Prezzo', { validMessage: "ok" });
                  Prodotti_Prezzo.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
                Prezzo Speciale
                <input type="text" class="txt" name="Prodotti_PrezzoSpeciale" id="Prodotti_PrezzoSpeciale"  value="<%=dtProdotto.Rows[0]["Prodotti_PrezzoSpeciale"].ToString()%>" size="10">
                Dal
                <input type="text" class="txt datepicker" name="Prodotti_PrezzoSpecialeDal" id="Prodotti_PrezzoSpecialeDal" value="<%=dtProdotto.Rows[0]["Prodotti_PrezzoSpecialeDal_IT"].ToString()%>" size="10">
                Al
                <input type="text" class="txt datepicker" name="Prodotti_PrezzoSpecialeAl" id="Prodotti_PrezzoSpecialeAl" value="<%=dtProdotto.Rows[0]["Prodotti_PrezzoSpecialeAl_IT"].ToString()%>" size="10">
              </td>
            </tr>
            <tr>
              <td width="85" class="lbl">Titolo *</td>
              <td colspan="3">
                <input type="text" class="txt" name="Prodotti_Titolo" id="Prodotti_Titolo" value="<%=dtProdotto.Rows[0]["Prodotti_Titolo"].ToString()%>" size="83" required="required">
                <script type="text/javascript">
                  var Prodotti_Titolo = new LiveValidation('Prodotti_Titolo', { validMessage: "ok" });
                  Prodotti_Titolo.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
              </td>
            </tr>
            <tr>
              <td class="lbl">Sottotitolo</td>
              <td colspan="3"><input type="text" class="txt" name="Prodotti_Sottotitolo" id="Prodotti_Sottotitolo" value="<%=dtProdotto.Rows[0]["Prodotti_Sottotitolo"].ToString()%>" size="83"></td>
            </tr>
            <tr>
              <td class="lbl">Descrizione</td>
              <td colspan="3">
                <textarea name="Prodotti_Descrizione" id="Prodotti_Descrizione" rows="5" cols="110" class="ckeditor"><%=dtProdotto.Rows[0]["Prodotti_Descrizione"].ToString()%></textarea>
                <script type="text/javascript">
                CKEDITOR.replace('Prodotti_Descrizione',
                	{
                  	filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
                    skin: 'jquery-mobile',
                  	filebrowserUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files'
                	});
                </script>
              </td>
            </tr>
            <tr>
              <td class="lbl">Cat. prodotto</td>
              <td>
                <select name="ProdottiCategorie_Ky" id="ProdottiCategorie_Ky" class="combo" value="<%=dtProdotto.Rows[0]["ProdottiCategorie_Ky"].ToString()%>" style="width:250px;">
                  <!--#include file="/var/cache/ProdottiCategorie-options.htm"--> 
                </select>
                <script type="text/javascript">
                  selectSet('ProdottiCategorie_Ky', <%=dtProdotto.Rows[0]["ProdottiCategorie_Ky"].ToString()%>);
                  var ProdottiCategorie_Ky = new LiveValidation('ProdottiCategorie_Ky', { validMessage: "ok" });
                  ProdottiCategorie_Ky.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
              </td>
              <td class="lbl">Imposizione IVA</td>
              <td>
                <select name="AliquoteIVA_Ky" id="AliquoteIVA_Ky" class="combo" value="<%=dtProdotto.Rows[0]["AliquoteIVA_Ky"].ToString()%>" style="width:210px;">
                  <!--#include file="/var/cache/AliquoteIVA-options.htm"--> 
                </select>
                <script type="text/javascript">
                  selectSet('AliquoteIVA_Ky', '<%=dtProdotto.Rows[0]["AliquoteIVA_Ky"].ToString()%>');
                  var AliquoteIVA_Ky = new LiveValidation('AliquoteIVA_Ky', { validMessage: "ok" });
                  AliquoteIVA_Ky.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
              </td>
            </tr>
            <tr>
              <td class="lbl">Categoria anagrafica</td>
              <td>
                <select name="AnagraficheCategorie_Ky" id="AnagraficheCategorie_Ky" class="combo" value="<%=dtProdotto.Rows[0]["AnagraficheCategorie_Ky"].ToString()%>" style="width:250px;">
                  <!--#include file="/var/cache/AnagraficheCategorie-options.htm"--> 
                </select>
                <script type="text/javascript">
                  selectSet('AnagraficheCategorie_Ky', '<%=dtProdotto.Rows[0]["AnagraficheCategorie_Ky"].ToString()%>');
                </script>
              </td>
              <td class="lbl">Anagrafica</td>
              <td>
                <input type="text" class="txt" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=dtProdotto.Rows[0]["Anagrafiche_Ky"].ToString()%>" size="3">
                <input type="text" class="txt" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" value="<%=dtProdotto.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%>" size="26">
                <script type="text/javascript">
                  	var options_xmlAnagrafiche = {
                  		script:"autosuggest-GetAnagrafiche.aspx?",
                  		varname:"input",
                  		cache:false,
                  		json: false,
                  		minchars:2,
                  		delay:100,
                  		callback: function (obj) {
                                                  document.getElementById("Anagrafiche_Ky").value = obj.id;
                                                  document.getElementById("Anagrafiche_RagioneSociale").value = obj.value;
                                               }		
                  	};
                  	var as_xmlAnagrafiche;
                    as_xmlAnagrafiche = new bsn.AutoSuggest("Anagrafiche_RagioneSociale", options_xmlAnagrafiche);
                </script>
              </td>
            </tr>
            <tr>
              <td class="lbl">Produttore</td>
              <td>
                <select name="Produttori_Ky" id="Produttori_Ky" class="combo" style="width:250px;">
                  <!--#include file="/var/cache/Produttori-options.htm"--> 
                </select>
                <script type="text/javascript">
                  selectSet('Produttori_Ky', <%=dtProdotto.Rows[0]["Produttori_Ky"].ToString()%>);
                </script>
              </td>
              <td></td>
              <td></td>
            </tr>
            <tr>
              <td class="lbl">Note</td>
              <td colspan="3">
                <textarea name="Prodotti_Note" id="Prodotti_Note" rows="2" cols="80"><%=dtProdotto.Rows[0]["Prodotti_Note"].ToString()%></textarea>
              </td>
            </tr>
          </table>
    	</div>
    	<div id="tabs-2">
          <table class="form" width="100%" border="0">
            <tr>
              <td class="lbl">Montaggio</td>
              <td>
                  <select name="ProdottiMontaggio_Ky" id="ProdottiMontaggio_Ky" class="combo" value="<%=dtProdotto.Rows[0]["ProdottiMontaggio_Ky"].ToString()%>" style="width:200px;">
                    <!--#include file="/var/cache/ProdottiMontaggio-options.htm"--> 
                  </select>
                  <script type="text/javascript">
                    selectSet('ProdottiMontaggio_Ky', <%=dtProdotto.Rows[0]["ProdottiMontaggio_Ky"].ToString()%>);
                  </script>
              </td>
              <td class="lbl">Paese di produzione</td>
              <td>
                  <select name="Nazioni_Ky" id="Nazioni_Ky" class="combo" value="<%=dtProdotto.Rows[0]["Nazioni_Ky"].ToString()%>" style="width:200px;">
                    <!--#include file="/var/cache/Nazioni-options.htm"--> 
                  </select>
                  <script type="text/javascript">
                    selectSet('Nazioni_Ky', <%=dtProdotto.Rows[0]["Nazioni_Ky"].ToString()%>);
                  </script>
              </td>
            </tr>
            <tr>
              <td class="lbl">Peso</td>
              <td>
                <input type="text" class="txt" name="Prodotti_Peso" id="Prodotti_Peso" value="<%=dtProdotto.Rows[0]["Prodotti_Peso"].ToString()%>" size="5">
                <script type="text/javascript">
                  var Prodotti_Peso = new LiveValidation('Prodotti_Peso', { validMessage: "ok" });
                  Prodotti_Peso.add( Validate.Numericality,{ notANumberMessage: "solo numeri"} );
                </script>
              </td>
            </tr>
          </table>
    	</div>
    	<div id="tabs-3">
          <table class="form" width="100%" border="0">
            <tr>
              <td class="lbl">Disponibilit&agrave;</td>
              <td>
                <select name="ProdottiDisponibilita_Ky" id="ProdottiDisponibilita_Ky" class="combo" value="<%=dtProdotto.Rows[0]["ProdottiDisponibilita_Ky"].ToString()%>" style="width:200px;">
                  <!--#include file="/var/cache/ProdottiDisponibilita-options.htm"--> 
                </select>
                <script type="text/javascript">
                  selectSet('ProdottiDisponibilita_Ky', <%=dtProdotto.Rows[0]["ProdottiDisponibilita_Ky"].ToString()%>);
                  var ProdottiDisponibilita_Ky = new LiveValidation('ProdottiDisponibilita_Ky', { validMessage: "ok" });
                  ProdottiDisponibilita_Ky.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
              </td>
              <td class="lbl">Tempi di consegna</td>
              <td>
                  <select name="ProdottiConsegna_Ky" id="ProdottiConsegna_Ky" class="combo" value="<%=dtProdotto.Rows[0]["ProdottiConsegna_Ky"].ToString()%>" style="width:200px;">
                    <!--#include file="/var/cache/ProdottiConsegna-options.htm"--> 
                  </select>
                  <script type="text/javascript">
                    selectSet('ProdottiConsegna_Ky', <%=dtProdotto.Rows[0]["ProdottiConsegna_Ky"].ToString()%>);
                  </script>
              </td>
            </tr>
            <tr>
              <td class="lbl">Quantit&agrave;</td>
              <td>
                <input type="text" class="txt" name="Prodotti_Qta" id="Prodotti_Qta"  value="<%=dtProdotto.Rows[0]["Prodotti_Qta"].ToString()%>" size="10">
                <script type="text/javascript">
                  var Prodotti_Qta = new LiveValidation('Prodotti_Qta', { validMessage: "ok" });
                  Prodotti_Qta.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                </script>
              </td>
            </tr>
          </table>
   	</div>
    	<div id="tabs-4">
        <ul id="gallery" class="gallery ui-helper-reset ui-helper-clearfix">
          <%
            intNumDoc=1;
            for (int i = 1; i <= 10; i++){
              if (dtProdotto.Rows[0]["Prodotti_Foto" + i].ToString().Length>0){
              	Response.Write("<li class=\"ui-widget-content ui-corner-tr\">");
              	Response.Write("<h5 class=\"ui-widget-header\">Foto " + i + "</h5>");
              	Response.Write("<img src=\"" + dtProdotto.Rows[0]["Prodotti_Foto" + i].ToString() + "\" alt=\"foto\" width=\"96\" height=\"72\" />");
              	Response.Write("<a href=\"" + dtProdotto.Rows[0]["Prodotti_Foto" + i].ToString() + "\" title=\"ingrandisci\" target=\"_blank\" class=\"ui-icon ui-icon-zoomin\">ingrandisci</a>");
              	Response.Write("<a href=\"elimina-foto-prodotto.aspx?foto=" + i + "&Prodotti_Ky=" + dtProdotto.Rows[0]["Prodotti_Ky"].ToString() + "\" title=\"elimina\" class=\"ui-icon ui-icon-trash\">elimina</a>");
              	Response.Write("</li>");
                intNumDoc=i+1;
              }else{
                intNumDocVuoto=i;
              }
            }
          %>
        </ul>
        <div class="caricadocumento">
          Seleziona una foto sul tuo computer da associare al prodotto<br>
          <input type="file" name="foto" id="foto" size="25" class="txt" /><br /><br />
          <input type="hidden" name="NumeroFoto" id="NumeroFoto" value="<%=intNumDocVuoto%>" />
        </div>
    	</div>
    	<div id="tabs-5">
        <ul id="gallery" class="gallery ui-helper-reset ui-helper-clearfix">
          <%
            intNumDoc=1;
            for (int i = 1; i <= 5; i++){
              if (dtProdotto.Rows[0]["Prodotti_Documento" + i].ToString().Length>0){
              	Response.Write("<li class=\"ui-widget-content ui-corner-tr\">");
              	Response.Write("<h5 class=\"ui-widget-header\">Documento " + i + "</h5>");
                Response.Write("<img src=\"img/application_pdf.png\" border=\"0\" width=\"16\" height=\"16\" hspace=\"8\" vspace=\"16\" align=\"top\" /><br />");
                Response.Write("<a href=\"" + dtProdotto.Rows[0]["Prodotti_Documento" + i].ToString() + "\" id=\"d" + i + "\" title=\"ingrandisci\" target=\"_blank\" class=\"ui-icon ui-icon-zoomin\">ingrandisci</a>");
                Response.Write("<a href=\"elimina-documento-prodotti.asp?documento=" + i + "&Prodotti_Ky=" + dtProdotto.Rows[0]["Prodotti_Ky"].ToString() + "\" class=\"ui-icon ui-icon-trash\"></a>");
              	Response.Write("</li>");
                intNumDoc=i+1;
              }
            }
          %>
        </ul>
        <div class="caricadocumento">
          Seleziona un documento PDF sul tuo computer da associare al prodotto<br>
          <input type="file" name="documento" id="documento" size="25" class="txt" /><br /><br />
          <input type="hidden" name="NumeroDocumento" id="NumeroDocumento" value="<%=intNumDoc%>" />
        </div>
    	</div>
      <table class="form" width="100%" border="0">
        <tr>
          <td colspan="4" align="center">
            <input type="hidden" name="azione" id="azione" value="modifica">
            <input type="hidden" name="Prodotti_Ky" id="Prodotti_Ky" value="<%=dtProdotto.Rows[0]["Prodotti_Ky"].ToString()%>">
            <button type="submit" value="salva" name="salva" class="salva">salva</button>
          </td>
        </tr>
      </table>
    </form>    
  </div>
 </div>
  <div id="footer">
    <!--#include file="/area-clienti/inc-footer.aspx" -->
  </div>
</body>
</html>
