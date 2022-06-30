<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="anagrafiche-esporta.aspx.cs" Inherits="RandomPassword" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Esporta anagrafiche</title>
  <!--#include file="/admin/inc-head.aspx"--> 
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-anagrafiche-esporta" name="esporta" action="/admin/app/anagrafiche/esporta-anagrafiche.aspx" target="blank">
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
        <div class="large-5 medium-5 small-12 cell align-middle">
          <h1><i class="fa-duotone fa-download fa-lg fa-fw"></i><%=strH1%></h1>
        </div>
        <div class="large-7 medium-7 small-12 cell float-right align-middle">
      			<div class="button-group small hide-for-print align-right">
  		        <button type="submit" value="esporta" name="esporta" class="button large success"><i class="fa-duotone fa-download fa-lg fa-fw"></i>Esporta</button>
      			</div>
        </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
		<div class="divform">
    		<p><i class="fa-duotone fa-info-circle fa-fw fa-3x" style="--fa-primary-color: white;--fa-secondary-color: #0438a1;--fa-secondary-opacity: 1.0;"></i>
				Con la seguente funzione puoi esportare le anagrafiche in formato CSV con i filtri scelti:
				</p>
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Campi">Campi da esportare</label>
				  </div>
				  <div class="small-12 medium-10 large-10 cell">
		        <select name="campi" id="campi" multiple size="10" class="select2">
		          <option value="Anagrafiche_Ky" selected>Codice</option>
		          <option value="Anagrafiche_RagioneSociale" selected>Ragione Sociale</option>
		          <option value="Comuni_Ky">Codice comune</option>
		          <option value="Comuni_Comune" selected>Comune</option>
		          <option value="Province_Ky">Codice provincia</option>
		          <option value="Province_Provincia" selected>Provincia</option>
		          <option value="Regioni_Ky">Codice regione</option>
		          <option value="Regioni_Regione" selected>Regione</option>
		          <option value="Nazioni_Ky">Codice Nazione</option>
		          <option value="Nazioni_Nazione" selected>Nazione</option>
		          <option value="Anagrafiche_EmailContatti" selected>Email contatti</option>
		          <option value="Anagrafiche_EmailAmministrazione" selected>Email amministrazione</option>
		          <option value="Anagrafiche_PEC" selected>Email PEC</option>
		          <option value="Anagrafiche_Telefono" selected>Telefono</option>
		          <option value="Anagrafiche_DataInserimento" selected>Data Inserimento</option>
		          <option value="Anagrafiche_CodiceDestinatario" selected>Codice Destinatario</option>
		          <option value="Anagrafiche_Origine" selected>Origine</option>
		          <option value="Anagrafiche_Privacy" selected>Privacy</option>
		          <option value="Anagrafiche_Newsletter">Newsletter</option>
		        </select>
				  </div>
				</div>				  
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="AnagraficheTipo_Ky">Tipo</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
		        <select name="AnagraficheTipo_Ky" id="AnagraficheTipo_Ky" class="select2">
		          <option value=""></option>
							<!--#include file="/var/cache/AnagraficheTipo-options.htm"--> 
		        </select>
				  </div>
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Anagrafiche_Categorie">Categoria</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
            <select name="Anagrafiche_Categorie" id="Anagrafiche_Categorie" class="select2" multiple>
		          <option value=""></option>
              <!--#include file="/var/cache/AnagraficheCategorie-options.htm"--> 
            </select>
				  </div>
				</div>
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Nazioni_Ky">Nazioni</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
            <select name="Nazioni_Ky" id="Nazioni_Ky" value="" onchange="loadCoreRegioni();" class="select2">
              <!--#include file="/var/cache/Nazioni-options.htm"--> 
            </select>
				  </div>
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Regioni_Ky">Regione</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
            <select name="Regioni_Ky" id="Regioni_Ky" value="" onchange="loadCoreProvince();" class="select2">
            </select>
				  </div>
				</div>
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Province_Ky">Provincia</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
						<select name="Province_Ky" id="Province_Ky" onchange="loadCoreComuni();" class="select2">
      			  <!--#include file="/var/cache/Province-options.htm"--> 
						</select>
				  </div>
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Comuni_Ky">Comune</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
            <select name="Comuni_Ky" id="Comuni_Ky" value="" class="select2">
            </select>
				  </div>
				</div>
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Anagrafiche_DateInsert">Dalla data</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
      			<input type="date" name="Anagrafiche_DateInsert" id="Anagrafiche_DateInsert" title="Anno" value="" size="8">
				  </div>
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Anagrafiche_CodiceDestinatario">Con codice destinatario</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
      			<input type="checkbox" name="Anagrafiche_CodiceDestinatario" id="Anagrafiche_CodiceDestinatario" title="Codice destinatario" value="1">
				  </div>
				</div>				
				<div class="grid-x grid-padding-x">
				  <div class="small-12 large-12 medium-12 large-centered cell text-center">
				  </div>
				</div>
     </div>
  </div> 
</div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
