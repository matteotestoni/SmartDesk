<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="registrazione.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<!--[if IE 9]><html class="lt-ie10" lang="it"><![endif]-->
<html class="no-js" dir="ltr" lang="it-IT">
	<head>	
		<title><%=strH1%></title>
    <meta name="description" content="<%=strH1%>"/>
    <meta name="robots" content="noindex,nofollow">
    <!--#include file="/frontend/base/inc-head.aspx"--> 
	</head>
	<body class="login">
		<!-- #include file ="/frontend/base/inc-header.aspx" -->
		<div class="grid-container">
			<div class="grid-x grid-padding-x">
						<div class="large-12 medium-12 small-12 cell">
							<div class="callout">
								<h2>Registrazione</h2>
								<div id="registrazione">
									<%=strUtentiLogin%><%=strErrore%>
								  	<%if (strErrore!=null && strErrore.Length>0){%>
									<div id="messaggio" class="callout alert small" data-closable>
										<h5><i class="fa-duotone fa-exclamation-triangle fa-lg fa-fw"></i>I dati inseriti non sono validi.</h5>
										<button class="close-button" data-close aria-label="Chiudi">&times;</button>
									</div>
									<% } %>
									<form action="/form/salva-anagrafiche.aspx" method="post" name="formRegistrazione" id="formRegistrazione" data-abide novalidate data-options="data-live-validate:true;data-validate-on-blur:true;">
                    <input type="hidden" id="proteggi" name="proteggi" value="" />
                    <input type="hidden" id="foo" name="foo" />
										<input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="" />
										<input type="hidden" name="Lingue_Ky" id="Lingue_Ky" value="1" />
										<input type="hidden" name="AliquoteIVA_Ky" id="AliquoteIVA_Ky" value="43" />
										<input type="hidden" name="SpedizioniTipo_Ky" id="SpedizioniTipo_Ky" value="1" />
										<input type="hidden" name="PagamentiMetodo_Ky" id="PagamentiMetodo_Ky" value="1" />
										<input type="hidden" name="Conti_Ky" id="Conti_Ky" value="1" />
                    <input type="hidden" name="azione" id="azione" value="new" />
                    <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="0" />
                    <input type="hidden" name="AnagraficheTipo_Ky" id="AnagraficheTipo_Ky" value="1" />
                    <input type="hidden" name="Anagrafiche_Attivo" id="Anagrafiche_Attivo" value="1" />
                    <input type="hidden" name="Anagrafiche_CAP" id="Anagrafiche_CAP" value="" />
                    <input type="hidden" name="Anagrafiche_Indirizzo" id="Anagrafiche_Indirizzo" value="" />

										<fieldset>
											<h5>I tuoi dati</h5>
											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_TipoUtente">Tipo di utente*:</label></div>
												<div class="large-10 medium-10 small-12 cell">
													<input type="radio" name="AnagraficheTipologia_Ky" id="AnagraficheTipologia_Ky1" value="1" required="required" onclick="chgAnagraficheTipologia(1)";><label for="Anagrafiche_TipoUtente">Privato</label>
													<input type="radio" name="AnagraficheTipologia_Ky" id="AnagraficheTipologia_Ky2" value="2" checked="checked" onclick="chgAnagraficheTipologia(2)";><label for="Anagrafiche_TipoUtente">Azienda</label>
												</div>
											</div>
											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_Nome">Nome*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<input type="text" name="Anagrafiche_Nome" id="Anagrafiche_Nome" required="required">
													<div class="form-error">Campo obbligatorio</div>
												</div>
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_Cognome">Cognome*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<input type="text" name="Anagrafiche_Cognome" id="Anagrafiche_Cognome" required="required">
													<div class="form-error">Campo obbligatorio</div>
												</div>
											</div>
											<div class="grid-x grid-padding-x" id="divRagioneSociale">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_RagioneSociale">Azienda*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale">
													<div class="form-error">Campo obbligatorio</div>
												</div>
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_PartitaIVA">Partita IVA*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<input type="text" name="Anagrafiche_PartitaIVA" id="Anagrafiche_PartitaIVA">
												</div>
											</div>
											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_CodiceFiscale">Codice fiscale:</label></div>
												<div class="large-10 medium-10 small-12 cell">
													<input type="text" name="Anagrafiche_CodiceFiscale" id="Anagrafiche_CodiceFiscale">
												</div>
											</div>
											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_Nazione">Nazione*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<select name="Nazioni_Ky" id="Nazioni_Ky" tabindex="14" required="required" onchange="loadCoreRegioni();">
                    			  <!--#include file="/var/cache/Nazioni-options.htm"--> 
													</select>
													<div class="form-error">Campo obbligatorio</div>
	                        <script type="text/javascript">
	                          selectSet('Nazioni_Ky', '105');
	                        </script>
												</div>
                      	<div class="large-2 medium-2 small-4 cell">
                    			<label>Regione</label>
                    		</div>
                    		<div class="large-4 medium-4 small-8 cell">
                    			<select name="Regioni_Ky" id="Regioni_Ky" required="required" onchange="loadCoreProvince();">
                    			  <!--#include file="/var/cache/Regioni-options.htm"--> 
                    			</select>
                        </div>
                      </div>

											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_Provincia">Provincia*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<select name="Province_Ky" id="Province_Ky" required="required" onchange="loadCoreComuni();">
														<option value="" label="Seleziona la Regione" selected="selected">Seleziona la provincia</option>
                    			  <!--#include file="/var/cache/Province-options.htm"--> 
													</select>
													<div class="form-error">Campo obbligatorio</div>
												</div>
												<div class="large-2 medium-2 small-12 cell"><label for="Comuni_Ky">Citt&agrave;*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<select name="Comuni_Ky" id="Comuni_Ky" required="required">
														<option value="" label="Seleziona la provincia" selected="selected">Seleziona la provincia</option>
                    			  <!--#include file="/var/cache/Province-options.htm"--> 
													</select>
													<div class="form-error">Campo obbligatorio</div>
												</div>
											</div>
											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_Cellulare">Cellulare*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<input type="text" name="Anagrafiche_Cellulare" id="Anagrafiche_Cellulare" required="required">
													<div class="form-error">Campo obbligatorio</div>
												</div>
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_Telefono">Telefono*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<input type="text" name="Anagrafiche_Telefono" id="Anagrafiche_Telefono" required="required">
													<div class="form-error">Campo obbligatorio</div>
												</div>
											</div>
											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_TipoAttivita">Vuoi ricevere informazioni per i seguenti interessi?:</label></div>
												<div class="large-10 medium-10 small-12 cell">
												<select name="Anagrafiche_Categorie" id="Anagrafiche_Categorie" class="select2" placeholder="Categoria" multiple>
													<!--#include file="/var/cache/AnagraficheCategorie-options.htm"--> 
												</select>
												</div>
											</div>
										</fieldset>
										
										<hr>

										<fieldset>
											<h5>Dati di accesso</h5>
											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_EmailContatti">Email*:</label></div>
												<div class="large-10 medium-10 small-12 cell">
													<input type="email" name="Anagrafiche_EmailContatti" id="Anagrafiche_EmailContatti" pattern="email" aria-describedby="helptext-email" required="required" onchange="controllaCliente()">
													<div class="form-error">Inserisci un indirizzo email valido</div>
												</div>
											</div>
											<div class="grid-x grid-padding-x">
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_Password">Password*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<input type="password" name="Anagrafiche_Password" id="Anagrafiche_Password" aria-describedby="helptext-password" required="required">
													<span class="form-error">Campo obbligatorio</span>
												</div>
												<div class="large-2 medium-2 small-12 cell"><label for="Anagrafiche_Password">Conferma password*:</label></div>
												<div class="large-4 medium-4 small-12 cell">
													<input type="password" name="Anagrafiche_Password2" id="Anagrafiche_Password2" aria-describedby="helptext-password" required="required" data-equalto="Anagrafiche_Password">
													<span class="form-error">La conferma della password deve essere uguale alla password</span>
												</div>
											</div>
										</fieldset>

										<hr>

										<fieldset>
											<h5>Condizioni di utilizzo</h5>
												<div class="grid-x grid-padding-x">
													<div class="large-12 medium-12 small-12 cell">
														<input type="checkbox" name="Anagrafiche_Privacy" id="Anagrafiche_Privacy" required="required" />
														<label for="Anagrafiche_Privacy">Accetto l'informativa sulla privacy</label><a href="/privacy.aspx" title="Leggi l'informativa sulla privacy" target="blank">(leggi)</a><br>
														<div class="form-error">Per proseguire devi accettare la privacy</div>
													</div>
												</div>
												<div class="grid-x grid-padding-x">
													<div class="large-12 medium-12 small-12 cell">
														<input type="checkbox" name="termini" id="termini" required="required" />
														<label for="termini">Accetto i termini e le condizioni di utilizzo</label><a href="/pag/condizioni-generali.html" title="Leggi le condizioni di utilizzo del sito" target="blank">(leggi)</a>
														<div class="form-error">Per proseguire devi accettare le condizioni di utilizzo</div>
													</div>
												</div>
												<div class="grid-x grid-padding-x">
													<div class="large-12 medium-12 small-12 cell">
														<input type="checkbox" name="Anagrafiche_Newsletter" id="Anagrafiche_Newsletter" value="1" />
														<label for="Anagrafiche_Newsletter">Iscrivimi alla newsletter</label><br>
													</div>
												</div>
										</fieldset>
										<div class="grid-x grid-padding-x">
											<div class="large-12 medium-12 small-12 cell text-right">
                        						<div data-abide-error class="alert callout">
    									    	<p><i class="fa-duotone fa-exclamation-triangle fa-fw"></i>Attenzione: controlla di aver compilato correttamente tutti i campi.</p>
    											</div>
												<input type="hidden" value="<%=strReturnUrl%>" id="ReturnUrl" name="ReturnUrl">
												<button class="button medium radius success"><i class="fa-duotone fa-user-plus fa-fw"></i>Registrami</button>
												<br><br>
											</div>
										</div>
									</form>
								</div>
							</div>
						</div>
				</div>
	</div>
	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  <script type="text/javascript">
    function controllaCliente(){
      //console.log(intKy);
      if (jQuery("#Anagrafiche_EmailContatti").val().Length>0){
		console.log("1");
	  }else{
		  console.log("2");
	  }
      
    } 


    function chgAnagraficheTipologia(intKy){
      //console.log(intKy);
      if (intKy==1){
        jQuery("#divRagioneSociale").hide();
        jQuery("#divPartitaIVA").hide();
      }else{
        jQuery("#divRagioneSociale").show();
        jQuery("#divPartitaIVA").show();
      }
      
    } 
  </script>
</body>
</html>			