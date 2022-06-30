<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-documenticorpo.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Documenti > Scheda corpo documento</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<% if (boolWysiwyg==true){ %>
	<script src="//cdn.ckeditor.com/4.19.0/full/ckeditor.js"></script>
	<% } %>
  <script type="text/javascript">
		var strContenuto;
 		function calcolaTotali(){
			jQuery("#DocumentiCorpo_Totale").val(  jQuery("#DocumentiCorpo_Qta").val()*jQuery("#DocumentiCorpo_Importo").val() );
			jQuery("#DocumentiCorpo_TotaleIVA").val(  jQuery("#DocumentiCorpo_Qta").val()*jQuery("#DocumentiCorpo_Importo").val()*jQuery("#AliquoteIVA_Aliquota").val()/100 );
		}
	</script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<form id="form-documentocorpo" action="/admin/app/documenti/crud/salva-documento-corpo.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-file fa-lg fa-fw"></i>Scheda Riga documento</h1>
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/app/documenti/scheda-documenti.aspx?Documenti_Ky=<%=strDocumenti_Ky%>" class="button secondary"><i class="fa-duotone fa-backward fa-fw"></i>Torna al documento senza salvare</a> 
      				<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-fw"></i> Salva riga e torna al documento</button>
      			</div>
  	      </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
		    <div class="divform">
				<input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
				<input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
				<input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=GetFieldValue("Anagrafiche_Ky")%>">
				<input type="hidden" name="DocumentiCorpo_Ky" id="DocumentiCorpo_Ky" value="<%=GetFieldValue("DocumentiCorpo_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
        <div class="grid-x grid-padding-x">
		    	<div class="large-1 medium-1 small-12 cell">
		    		<label class="large-text-right small-text-left middle">Anagrafica<i class="fa-duotone fa-user fa-fw"></i></label>
		    	</div>
		    	<div class="large-3 medium-3 small-12 cell">
						<%=dtDocumenti.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%>
		    	</div>
		    	<div class="large-1 medium-1 small-12 cell">
		    		<label class="large-text-right small-text-left middle">Documento</label>
		    	</div>
		    	<div class="large-3 medium-3 small-12 cell">
	          	<% if (dtDocumenti!=null && dtDocumenti.Rows.Count>0){ %>
	              <select name="Documenti_Ky" id="Documenti_Ky" value="<%=GetFieldValue("Documenti_Ky")%>" required="required">
	              <option value=""></option>
	  							<%
									for (int i = 0; i < dtDocumenti.Rows.Count; i++){
	  								Response.Write("<option value=\"" + dtDocumenti.Rows[i]["Documenti_Ky"].ToString() + "\">" + dtDocumenti.Rows[i]["DocumentiTipo_Descrizione"].ToString() + " " + dtDocumenti.Rows[i]["Documenti_Numero"].ToString() + " del " + dtDocumenti.Rows[i]["Documenti_Anno"].ToString() + "</option>");
									}
									%>
	              </select>
	              <span class="form-error">Obbligatorio</span>
	              <script type="text/javascript">
	                selectSet('Documenti_Ky', '<%=strDocumenti_Ky%>');
	              </script>
	            <% }else{ %>
	            	Nessun progetto attivo sull'anagrafica
	            <% } %>
		    	</div>
		    	<div class="large-1 medium-1 small-12 cell">
		    		<label class="large-text-right small-text-left middle">Set attributi:</label>
		    	</div>
		    	<div class="large-3 medium-3 small-12 cell">
            <select name="AttributiGruppi_Ky" id="AttributiGruppi_Ky">
              <option value=""></option>
							<!--#include file="/var/cache/AttributiGruppi-options.htm"--> 
            </select>
            <script type="text/javascript">
              selectSet('AttributiGruppi_Ky', '<%=GetFieldValue("AttributiGruppi_Ky")%>');
            </script>
		    	</div>
		    </div>
		    
		    <div class="grid-x grid-padding-x">
		    	<div class="large-1 medium-1 small-12 cell">
		    		<label class="large-text-right small-text-left middle">Titolo <i class="fa-duotone fa-tag fa-fw"></i></label>
		    	</div>
		    	<div class="large-11 medium-11 small-12 cell">
            <input type="text" name="DocumentiCorpo_Titolo" id="DocumentiCorpo_Titolo" value="<%=GetFieldValue("DocumentiCorpo_Titolo")%>" size="85" required="required">
            <span class="form-error">Obbligatorio</span>
		    	</div>
		    </div>

	      <% if (strTipo=="2"){ %>
				<div class="grid-x grid-padding-x">
		    	<div class="large-1 medium-1 small-12 cell">
		    		<label class="large-text-right small-text-left middle">Prodotto</label>
		    	</div>
		    	<div class="large-11 medium-11 small-12 cell">
						<div class="grid-x grid-padding-x">
						  	<div class="large-1 medium-1 small-1 cell"><input type="text" name="Prodotti_Ky" id="Prodotti_Ky" value="<%=GetFieldValue("Prodotti_Ky")%>" size="3"></div>
						  	<div class="large-9 medium-9 small-9 cell"><input type="text" name="Prodotti_Titolo" id="Prodotti_Titolo" placeholder="Titolo prodotto" value="<%=GetFieldValue("Prodotti_Titolo")%>" size="50"></div>
						  	<div class="large-2 medium-2 small-2 cell">
				          <% if (strProdotti_Ky!=null && strProdotti_Ky.Length>0){ %>
										<a href="/admin/app/catalogo/scheda-prodotti.aspx?Prodotti_Ky=<%=GetFieldValue("strProdotti_Ky")%>">Scheda</a>
									<% } %>
								</div>
				  	</div>
		          <script type="text/javascript">
									jQuery("#Prodotti_Titolo" ).autocomplete({
										source: "/admin/app/catalogo/autosuggest-GetProdotti-json.aspx",
										minLength: 2,
										select: function( event, ui ) {
											jQuery("#Servizi_Ky").val("");
											jQuery("#Servizi_Titolo").val("");
											jQuery("#Prodotti_Ky").val(ui.item.value);
											jQuery("#Prodotti_Titolo").val(ui.item.label);
											jQuery("#DocumentiCorpo_Titolo").val(ui.item.label);
											strContenuto=String(window.atob(ui.item.descrizione)).trim();
											CKEDITOR.instances.DocumentiCorpo_Descrizione.setData(strContenuto, function() {
											    this.checkDirty(); // true
											});
											jQuery("#DocumentiCorpo_Descrizione").val(strContenuto);
											jQuery("#DocumentiCorpo_Importo").val(ui.item.prezzo.replace(",0000",""));
											jQuery("#AttributiGruppi_Ky").val(ui.item.attributigruppi_ky);
											selectSet("AttributiGruppi_Ky",ui.item.attributigruppi_ky);
											calcolaTotali();
											return false;
										}
									});
		          </script>
			    	</div>
			  </div>
		    <% } %>
		    <% if (strTipo=="3"){ %>
				<div class="grid-x grid-padding-x">
		    	<div class="large-1 medium-1 small-12 cell">
		    		<label class="large-text-right small-text-left middle">Servizio</label>
		    	</div>
		    	<div class="large-11 medium-11 small-12 cell">
							<div class="grid-x grid-padding-x">
						  	<div class="large-1 medium-1 small-1 cell"><input type="text" name="Servizi_Ky" id="Servizi_Ky" value="<%=GetFieldValue("Servizi_Ky")%>" size="3"></div>
						  	<div class="large-9 medium-9 small-9 cell"><input type="text" name="Servizi_Titolo" id="Servizi_Titolo" placeholder="Titolo" value="<%=GetFieldValue("Servizi_Titolo")%>" size="50"></div>
						  	<div class="large-2 medium-2 small-2 cell">
				          <% if (strProdotti_Ky!=null && strProdotti_Ky.Length>0){ %>
										<a href="/admin/app/catalogo/scheda-prodotti.aspx?Prodotti_Ky=<%=GetFieldValue("strProdotti_Ky")%>">Scheda</a>
									<% } %>
								</div>
						  </div>
		          <script type="text/javascript">
									jQuery("#Servizi_Titolo" ).autocomplete({
										source: "/admin/app/catalogo/autosuggest-GetServizi-json.aspx",
										minLength: 2,
										select: function( event, ui ) {
											jQuery("#Prodotti_Ky").val("");
											jQuery("#Prodotti_Titolo").val("");
											jQuery("#Servizi_Ky").val(ui.item.value);
											jQuery("#Servizi_Titolo").val(ui.item.label);
											jQuery("#DocumentiCorpo_Titolo").val(ui.item.label);
											strContenuto=String(window.atob(ui.item.descrizione)).trim();
											CKEDITOR.instances.DocumentiCorpo_Descrizione.setData(strContenuto, function() {
											    this.checkDirty(); // true
											});
											//jQuery("#DocumentiCorpo_Descrizione").val(strContenuto);
											jQuery("#DocumentiCorpo_Importo").val(ui.item.prezzo);
											jQuery("#AttributiGruppi_Ky").val(ui.item.attributigruppi_ky);
											selectSet("AttributiGruppi_Ky",ui.item.attributigruppi_ky);
											calcolaTotali();
											return false;
										}
									});
		          </script>
		      	</div>
					</div>
		      <% } %>

          <div class="grid-x grid-padding-x">
			    	<div class="large-1 medium-1 small-12 cell">
			    		<label class="large-text-right small-text-left middle">Aliquota IVA:</label>
			    	</div>
			    	<div class="large-2 medium-2 small-12 cell">
              <select name="AliquoteIVA_Ky" id="AliquoteIVA_Ky" value="<%=GetFieldValue("AliquoteIVA_Ky")%>" required="required">
                <!--#include file="/var/cache/AliquoteIVA-options.htm"--> 
              </select>
              <span class="form-error">Obbligatorio</span>
              <script type="text/javascript">
                selectSet('AliquoteIVA_Ky', '<%=GetFieldValue("AliquoteIVA_Ky")%>');
              </script>
            </div>
			    	<div class="large-2 medium-1 small-12 cell">
			    		<label class="large-text-right small-text-left middle">Aliquota:</label>
			    	</div>
			    	<div class="large-2 medium-2 small-12 cell">
              <input type="text" name="AliquoteIVA_Aliquota" id="AliquoteIVA_Aliquota" value="<%=GetMoneyValue("AliquoteIVA_Aliquota")%>" size="4" required="required" pattern="number" />
			        <span class="form-error">Obbligatorio</span>
            </div>
				  	<div class="large-1 medium-1 small-12 cell">
							<label class="large-text-right small-text-left middle">Costo</label>
						</div>
				  	<div class="large-4 medium-5 small-12 cell">
              	<select name="CentridiCR_Ky" id="CentridiCR_Ky" required="required" placeholder="Centro di costo" value="<%=GetFieldValue("CentridiCR_Ky")%>">
                  <!--#include file="/var/cache/CentridiCR-options.htm"--> 
                </select>
              	<span class="form-error">Obbligatorio.</span>
                <script type="text/javascript">
                  selectSet('CentridiCR_Ky', '<%=GetFieldValue("CentridiCR_Ky")%>');
                </script>
						</div>
          </div>

          <div class="grid-x grid-padding-x">
			    	<div class="large-1 medium-1 small-12 cell">
			    		<label class="large-text-right small-text-left middle">Qt&agrave;</label>
			    	</div>
			    	<div class="large-2 medium-2 small-12 cell">
					    <input type="text" name="DocumentiCorpo_Qta" id="DocumentiCorpo_Qta" size="2" value="<%=GetFieldValue("DocumentiCorpo_Qta")%>" required="required" pattern="number" min="1" max="1000000" value="1" onchange="calcolaTotali()" />
			        <span class="form-error">Obbligatorio</span>
			    	</div>
			    	<div class="large-2 medium-1 small-12 cell">
			    		<label for="DocumentiCorpo_ImportoTagliato" class="large-text-right small-text-left middle">Prezzo Scontato &euro;:</label>
			    	</div>
			    	<div class="large-2 medium-2 small-12 cell">
              <input type="text" name="DocumentiCorpo_ImportoTagliato" id="DocumentiCorpo_ImportoTagliato" size="8" value="<%=GetMoneyValue("DocumentiCorpo_ImportoTagliato")%>" pattern="number" />
			        <span class="form-error">Obbligatorio</span>
			    	</div>
			    	<div class="large-1 medium-1 small-12 cell">
			    		<label for="DocumentiCorpo_Importo" class="large-text-right small-text-left middle">Prezzo &euro;:</label>
			    	</div>
			    	<div class="large-2 medium-2 small-12 cell">
              <input type="text" name="DocumentiCorpo_Importo" id="DocumentiCorpo_Importo" size="8" value="<%=GetMoneyValue("DocumentiCorpo_Importo")%>" onchange="calcolaTotali()" required="required" pattern="number" />
			        <span class="form-error">Obbligatorio</span>
			    	</div>
					</div>
          <div class="grid-x grid-padding-x">
			    	<div class="large-3 medium-3 small-0 cell"></div>
			    	<div class="large-2 medium-1 small-12 cell">
			    		<label class="large-text-right small-text-left middle">Totale &euro;:</label>
			    	</div>
			    	<div class="large-2 medium-2 small-12 cell">
              <input type="text" name="DocumentiCorpo_Totale" id="DocumentiCorpo_Totale" size="8" value="<%=GetMoneyValue("DocumentiCorpo_Totale")%>" readonly="readonly" onchange="calcolaTotali()" required="required" pattern="number" />
			        <span class="form-error">Obbligatorio</span>
			    	</div>
			    	<div class="large-1 medium-1 small-12 cell">
			    		<label class="large-text-right small-text-left middle">Totale IVA &euro;:</label>
			    	</div>
			    	<div class="large-2 medium-2 small-12 cell">
              <input type="text" name="DocumentiCorpo_TotaleIVA" id="DocumentiCorpo_TotaleIVA" size="8" value="<%=GetMoneyValue("DocumentiCorpo_TotaleIVA")%>" readonly="readonly" onchange="calcolaTotali()" />
			    	</div>
					</div>

          
          
          
          

          <div class="grid-x grid-padding-x">
			    	<div class="large-12 medium-12 small-12 cell text-center">
              <textarea name="DocumentiCorpo_Descrizione" id="DocumentiCorpo_Descrizione" class="ckeditor" rows="8" cols="160" required="required"><%=GetFieldValue("DocumentiCorpo_Descrizione")%></textarea>
              <span class="form-error">Obbligatorio</span>
            </div>
          </div>


		    	<table class="form" border="0">
					<% if (strAzione!="new"){
					if (dtAttributi!=null){ %>
	        <tr>
	          <td align="left" colspan="6">
										<h2>Opzioni aggiuntive sul servizio (definite nel set di attributi)</h2>
								    <% if (dtAttributi!=null && dtAttributi.Rows.Count>0){ %>
								        <%for (int i = 0; i < dtAttributi.Rows.Count; i++){ %>
														<div class="grid-x grid-padding-x">
								              <div class="large-2 medium-2 small-4 cell">
																<label class="large-text-right small-text-left middle"><%=dtAttributi.Rows[i]["Attributi_Titolo"].ToString()%></label>
															</div>
								              <div class="large-10 medium-10 small-8 cell">
															<%
																switch (dtAttributi.Rows[i]["AttributiTipo_Ky"].ToString()){
																	case "1":
																		Response.Write("<input type=\"text\" required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\" />");
																		break;
																	case "2":
																		Response.Write("<textarea required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" value=\"\">" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "</textarea>");
																		break;
																	case "3":
																		Response.Write("<input type=\"text\" required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" class=\"datepicker txt\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\" />");
																		break;
																	case "4":
																		Response.Write("<input type=\"checkbox\" required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\" />");
																		break;
																	case "5":
																		Response.Write("<input type=\"text\" required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" class=\"price\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\" />");
																		break;
																	case "6":
																		Response.Write("<select required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\"><option value=\"\"></option>");
																		strWHERENet="Attributi_Ky=" + dtAttributi.Rows[i]["Attributi_Ky"].ToString();
												            strORDERNet = "AttributiOpzioni_Ky";
												            strFROMNet = "AttributiOpzioni";
												            dtAttributiOpzioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiOpzioni_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
								        						for (int j = 0; j < dtAttributiOpzioni.Rows.Count; j++){
								        							Response.Write("<option value=\"" + dtAttributiOpzioni.Rows[j]["AttributiOpzioni_Opzione"].ToString() + "\">" + dtAttributiOpzioni.Rows[j]["AttributiOpzioni_Opzione"].ToString() + "</option>");
																		}
																		Response.Write("</select>\n");
												            Response.Write("<script type=\"text/javascript\">\n");
																		Response.Write("selectSet('attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "', '" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "');\n");
												            Response.Write("</script>\n");
	
	
																		break;
																}
															%>
															</div>
								            </div>
								        <% } %>
								    <% } %>							    
						</td>
	        </tr>
					<% }
					} %>
          </table>

      </div>
  </div>
</div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
