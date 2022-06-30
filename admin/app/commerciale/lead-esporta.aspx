<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/lead-esporta.aspx.cs" Inherits="RandomPassword" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Commerciale > Lead > Esporta Lead</title>
  <!--#include file="/admin/inc-head.aspx"--> 
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
    <div class="grid-x grid-padding-x align-middle">
        <div class="large-5 medium-5 small-12 cell align-middle">
          	<h1><i class="fa-duotone fa-download fa-lg fa-fw"></i><%=strH1%></h1>
        </div>
        <div class="large-7 medium-7 small-12 cell float-right align-middle">
	      </div>
    </div>
  </div>
</div>


<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
			<div class="divform">
        <p><i class="fa-duotone fa-info-circle fa-fw fa-3x" style="--fa-primary-color: white;--fa-secondary-color: #0438a1;--fa-secondary-opacity: 1.0;"></i>
				Con la seguente funzione puoi esportare le leads in formato CSV con i filtri scelti:
				</p>
				<form id="form-lead-esporta" name="esporta" action="/admin/app/commerciale/esporta-lead.aspx" target="blank">
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Campi">Campi da esportare</label>
				  </div>
				  <div class="small-12 medium-10 large-10 cell">
		        <select name="campi" id="campi" multiple size="10" class="select2">
		          <option value="Lead_Ky" selected>Codice</option>
		          <option value="Lead_Titolo" selected>Titolo lead</option>
		          <option value="Lead_Data" selected>Data</option>
		          <option value="Anagrafiche_RagioneSociale" selected>Ragione Sociale</option>
		          <option value="Anagrafiche_Nome" selected>Cognome</option>
		          <option value="Anagrafiche_Cognome" selected>Nome</option>
		          <option value="Anagrafiche_EmailContatti" selected>Anagrafica: Email</option>
		          <option value="Anagrafiche_Telefono" selected>Anagrafica: Telefono</option>
		          <option value="utm_source">utm_source</option>
		          <option value="utm_medium">utm_medium</option>
		          <option value="utm_campaign">utm_campaign</option>
		          <option value="Lead_Link">Lead_Link</option>
		          <option value="VeicoliMarca_Titolo">Marca</option>
		          <option value="VeicoliModello_Titolo">Modello</option>
		          <option value="Veicoli_Targa">Targa</option>
		        </select>
				  </div>
				</div>	
                
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Lead_Titolo">Titolo</label>
				  </div>
				  <div class="small-12 medium-10 large-10 cell">
      			   <input type="text" name="Lead_Titolo" id="Lead_Titolo" title="Titolo" value="">
				  </div>
				</div>
                			  
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="Lead_DateInsert">Dalla data</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
      			   <input type="text" name="Lead_DateInsert" id="Lead_DateInsert" title="Data inserimento" value="<%=dt.ToString("dd/MM/yyyy")%>" size="8">
				  </div>
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="LeadSorgenti_Ky">Tipo</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
    		        <select name="LeadSorgenti_Ky" id="LeadSorgenti_Ky" class="select2">
    		          <option value=""></option>
    					<!--#include file="/var/cache/LeadSorgenti-options.htm"--> 
    		        </select>
				  </div>
				</div>
                
				<div class="grid-x grid-padding-x">
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="LeadTipo_Ky">Tipo</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
    		        <select name="LeadTipo_Ky" id="LeadTipo_Ky" class="select2">
    		          <option value=""></option>
    							<!--#include file="/var/cache/LeadTipo-options.htm"--> 
    		        </select>
				  </div>
				  <div class="small-12 medium-2 large-2 cell">
				  	<label class="large-text-right small-text-left middle" for="LeadCategorie_Ky">Categoria</label>
				  </div>
				  <div class="small-12 medium-4 large-4 cell">
    		        <select name="LeadCategorie_Ky" id="LeadCategorie_Ky" class="select2">
    		          <option value=""></option>
    							<!--#include file="/var/cache/LeadCategorie-options.htm"--> 
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
				  <div class="small-12 large-12 medium-12 large-centered cell text-center">
			        <button type="submit" value="esporta" name="esporta" class="button large success"><i class="fa-duotone fa-download fa-lg fa-fw"></i>Esporta</button>
				  </div>
				</div>
				</form>
     </div>
  </div> 
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
