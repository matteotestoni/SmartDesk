<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/catalogo/scheda-prodotto.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
	<script src="//cdn.ckeditor.com/4.19.2/full/ckeditor.js"></script>
	<link type="text/css" rel="stylesheet" href="/area-clienti/area-clienti.css">
    <script type="text/javascript" src="/area-clienti/area-clienti.js"></script>
	<style>
	#gallery { float: left; width: 65%; min-height: 12em; } * html #gallery { height: 12em; } /* IE6 */
	.gallery.custom-state-active { background: #eee; }
	.gallery li { float: left; width: 96px; padding: 0.4em; margin: 0 0.4em 0.4em 0; text-align: center; }
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
							<h1>Scheda prodotto</h1>
              <form action="/area-clienti/app/catalogo/crud/salva-prodotti.aspx" method="post" enctype="multipart/form-data">
              <div id="tabs">
              	<ul>
              		<li><a href="#tabs-1">Scheda</a></li>
              		<li><a href="#tabs-2">Dati tecnici</a></li>
              		<li><a href="#tabs-3">Inventario</a></li>
            			<%if (strAzione!="new"){%>
              		<li><a href="#tabs-4">Foto</a></li>
            			<%}%>
              	</ul>
          	  <div id="tabs-1">
                    <table class="form" width="100%" border="0">
                      <tr>
                        <td width="85" class="lbl">Codice *</td>
                        <td width="275" colspan="3">
                          <input type="text" class="txt" name="Prodotti_Codice" id="Prodotti_Codice" title="Codice alfanumerico del prodotto" value="<%=GetFieldValue("Prodotti_Codice")%>" size="15">
                          <script type="text/javascript">
                            var Prodotti_Codice = new LiveValidation('Prodotti_Codice', { validMessage: "ok" });
                            Prodotti_Codice.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                          </script>
                          Attivo
                          <input type="checkbox" name="Prodotti_PubblicaWEB" id="Prodotti_PubblicaWEB" value="on" <%if (GetCheckValue("Prodotti_PubblicaWEB")){ Response.Write("checked");}%> />
                          <script type="text/javascript">
                            var Prodotti_PubblicaWEB = new LiveValidation('Prodotti_PubblicaWEB', { validMessage: "ok" });
                            Prodotti_PubblicaWEB.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                          </script>
                        </td>
                      </tr>
                      <tr>
                        <td width="85" class="lbl">Prezzo &euro;</td>
                        <td colspan="3">
                          <input type="text" class="txt" name="Prodotti_Prezzo" id="Prodotti_Prezzo"  value="<%=GetFieldValue("Prodotti_Prezzo")%>" size="10">
                          <script type="text/javascript">
                            var Prodotti_Prezzo = new LiveValidation('Prodotti_Prezzo', { validMessage: "ok" });
                            Prodotti_Prezzo.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                          </script>
                          Prezzo Speciale
                          <input type="text" class="txt" name="Prodotti_PrezzoSpeciale" id="Prodotti_PrezzoSpeciale"  value="<%=GetFieldValue("Prodotti_PrezzoSpeciale")%>" size="10">
                          Dal
                          <input type="text" class="txt datepicker" name="Prodotti_PrezzoSpecialeDal" id="Prodotti_PrezzoSpecialeDal" value="<%=GetFieldValue("Prodotti_PrezzoSpecialeDal_IT")%>" size="10">
                          Al
                          <input type="text" class="txt datepicker" name="Prodotti_PrezzoSpecialeAl" id="Prodotti_PrezzoSpecialeAl" value="<%=GetFieldValue("Prodotti_PrezzoSpecialeAl_IT")%>" size="10">
                        </td>
                      </tr>
                      <tr>
                        <td width="85" class="lbl">Titolo *</td>
                        <td colspan="3">
                          <input type="text" class="txt" name="Prodotti_Titolo" id="Prodotti_Titolo" value="<%=GetFieldValue("Prodotti_Titolo")%>" size="83" required="required">
                          <script type="text/javascript">
                            var Prodotti_Titolo = new LiveValidation('Prodotti_Titolo', { validMessage: "ok" });
                            Prodotti_Titolo.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                          </script>
                        </td>
                      </tr>
                      <tr>
                        <td class="lbl">Sottotitolo</td>
                        <td colspan="3"><input type="text" class="txt" name="Prodotti_Sottotitolo" id="Prodotti_Sottotitolo" value="<%=GetFieldValue("Prodotti_Sottotitolo")%>" size="83"></td>
                      </tr>
                      <tr>
                        <td class="lbl">Descrizione</td>
                        <td colspan="3">
                          <textarea name="Prodotti_Descrizione" id="Prodotti_Descrizione" rows="5" cols="110" class="ckeditor"><%=GetFieldValue("Prodotti_Descrizione")%></textarea>
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
                          <select name="ProdottiCategorie_Ky" id="ProdottiCategorie_Ky" class="combo" value="<%=GetFieldValue("ProdottiCategorie_Ky")%>" style="width:250px;">
                            <!--#include file="/var/cache/ProdottiCategorie-options.htm"--> 
                          </select>
                          <script type="text/javascript">
                            selectSet('ProdottiCategorie_Ky', '<%=GetFieldValue("ProdottiCategorie_Ky")%>');
                            var ProdottiCategorie_Ky = new LiveValidation('ProdottiCategorie_Ky', { validMessage: "ok" });
                            ProdottiCategorie_Ky.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
                          </script>
                        </td>
                        <td class="lbl">Imposizione IVA</td>
                        <td>
                          <select name="AliquoteIVA_Ky" id="AliquoteIVA_Ky" class="combo" value="<%=GetFieldValue("AliquoteIVA_Ky")%>" style="width:210px;">
                            <!--#include file="/var/cache/AliquoteIVA-options.htm"--> 
                          </select>
                          <script type="text/javascript">
                            selectSet('AliquoteIVA_Ky', '<%=GetFieldValue("AliquoteIVA_Ky")%>');
                            var AliquoteIVA_Ky = new LiveValidation('AliquoteIVA_Ky', { validMessage: "ok" });
                            AliquoteIVA_Ky.add( Validate.Presence,{ failureMessage: "obbligatorio"} );
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
                            selectSet('Produttori_Ky', '<%=GetFieldValue("Produttori_Ky")%>');
                          </script>
                        </td>
                        <td></td>
                        <td></td>
                      </tr>
                      <tr>
                        <td class="lbl">Note</td>
                        <td colspan="3">
                          <textarea name="Prodotti_Note" id="Prodotti_Note" rows="2" cols="80"><%=GetFieldValue("Prodotti_Note")%></textarea>
                        </td>
                      </tr>
                    </table>
              	</div>
              	<div id="tabs-2">
                    <table class="form" width="100%" border="0">
                      <tr>
                        <td class="lbl">Montaggio</td>
                        <td>
                            <select name="ProdottiMontaggio_Ky" id="ProdottiMontaggio_Ky" class="combo" value="<%=GetFieldValue("ProdottiMontaggio_Ky")%>" style="width:200px;">
                              <!--#include file="/var/cache/ProdottiMontaggio-options.htm"--> 
                            </select>
                            <script type="text/javascript">
                              selectSet('ProdottiMontaggio_Ky', '<%=GetFieldValue("ProdottiMontaggio_Ky")%>');
                            </script>
                        </td>
                        <td class="lbl">Paese di produzione</td>
                        <td>
                            <select name="Nazioni_Ky" id="Nazioni_Ky" class="combo" value="<%=GetFieldValue("Nazioni_Ky")%>" style="width:200px;">
                              <!--#include file="/var/cache/Nazioni-options.htm"--> 
                            </select>
                            <script type="text/javascript">
                              selectSet('Nazioni_Ky', '<%=GetFieldValue("Nazioni_Ky")%>');
                            </script>
                        </td>
                      </tr>
                      <tr>
                        <td class="lbl">Peso</td>
                        <td>
                          <input type="text" class="txt" name="Prodotti_Peso" id="Prodotti_Peso" value="<%=GetFieldValue("Prodotti_Peso")%>" size="5">
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
                          <select name="ProdottiDisponibilita_Ky" id="ProdottiDisponibilita_Ky" class="combo" value="<%=GetFieldValue("ProdottiDisponibilita_Ky")%>" style="width:200px;">
                            <!--#include file="/var/cache/ProdottiDisponibilita-options.htm"--> 
                          </select>
                          <script type="text/javascript">
                            selectSet('ProdottiDisponibilita_Ky', '<%=GetFieldValue("ProdottiDisponibilita_Ky")%>');
                            var ProdottiDisponibilita_Ky = new LiveValidation('ProdottiDisponibilita_Ky', { validMessage: "ok" });
                            ProdottiDisponibilita_Ky.add( Validate.Numericality );
                          </script>
                        </td>
                        <td class="lbl">Tempi di consegna</td>
                        <td>
                            <select name="ProdottiConsegna_Ky" id="ProdottiConsegna_Ky" class="combo" value="<%=GetFieldValue("ProdottiConsegna_Ky")%>" style="width:200px;">
                              <!--#include file="/var/cache/ProdottiConsegna-options.htm"--> 
                            </select>
                            <script type="text/javascript">
                              selectSet('ProdottiConsegna_Ky', '<%=GetFieldValue("ProdottiConsegna_Ky")%>');
                            </script>
                        </td>
                      </tr>
                      <tr>
                        <td class="lbl">Quantit&agrave;</td>
                        <td>
                          <input type="text" class="txt" name="Prodotti_Qta" id="Prodotti_Qta"  value="<%=GetFieldValue("Prodotti_Qta")%>" size="10">
                          <script type="text/javascript">
                            var Prodotti_Qta = new LiveValidation('Prodotti_Qta', { validMessage: "ok" });
                            Prodotti_Qta.add( Validate.Numericality );
                          </script>
                        </td>
                      </tr>
                    </table>
             	</div>
            	<%if (strAzione!="new"){%>
              <div id="tabs-4">
                  <ul id="gallery" class="gallery ui-helper-reset ui-helper-clearfix">
						          <%
						            intNumDoc=1;
						            for (int i = 1; i <= 10; i++){
						              if (GetFieldValue("Prodotti_Foto" + i).Length>0){
						              	Response.Write("<li class=\"ui-widget-content ui-corner-tr\">");
						              	Response.Write("<h5 class=\"ui-widget-header\">Foto " + i + "</h5>");
						              	Response.Write("<img src=\"" + GetFieldValue("Prodotti_Foto" + i) + "\" alt=\"foto\" width=\"96\" height=\"72\" />");
						              	Response.Write("<a href=\"" + GetFieldValue("Prodotti_Foto" + i) + "\" title=\"ingrandisci\" target=\"_blank\" class=\"ui-icon ui-icon-zoomin\">ingrandisci</a>");
						              	Response.Write("<a href=\"elimina-foto-prodotto.aspx?foto=" + i + "&Prodotti_Ky=" + GetFieldValue("Prodotti_Ky") + "\" title=\"elimina\" class=\"ui-icon ui-icon-trash\">elimina</a>");
						              	Response.Write("</li>");
						                intNumDoc=i+1;
						              }else{
						                if (intNumDocVuoto==0){
															intNumDoc=i;
															intNumDocVuoto=1;
														}
						              }
						            }
						          %>
                  </ul>
                  <div class="caricadocumento">
                    Seleziona una foto sul tuo computer da associare al prodotto<br>
                    <input type="file" name="foto" id="foto" size="25" class="txt" /><br /><br />
                    <input type="hidden" name="NumeroFoto" id="NumeroFoto" value="<%=intNumDoc%>" />
                  </div>
              	</div>
            		<%}%>	
                <table class="form" width="100%" border="0">
                  <tr>
                    <td colspan="4" align="center">
                      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
                      <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>" size="3">
                      <input type="hidden" name="Prodotti_Ky" id="Prodotti_Ky" value="<%=GetFieldValue("Prodotti_Ky")%>">
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

