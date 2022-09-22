<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/veicoli/scheda-veicoliprenotazioni.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title><%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
  <script type="text/javascript" src="/admin/app/veicoli/veicoli.js?id=1"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-VeicoliPrenotazioni" action="/admin/crud/salva.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-car fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtFormsData, "VeicoliPrenotazioni_Ky")%></span></h1>
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">
  			<div class="stacked-for-small button-group small hide-for-print align-right">
  				<a href="/admin/goto-view.aspx?CoreEntities_Ky=258" class="button clear"><i class="fa-duotone fa-backward success fa-fw"></i>Torna all'elenco</a>
  				<a class="button clear" onclick="javascript:printPrenotazione()"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa</a>
  				<a href="/admin/app/veicoli/scheda-VeicoliPrenotazioni.aspx?CoreModules_Ky=29&CoreEntities_Ky=252&azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
          <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
  			</div>
			</div>
		</div>
	</div>
</div>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="VeicoliPrenotazioni_Ky" id="VeicoliPrenotazioni_Ky" value="<%=GetFieldValue(dtFormsData, "VeicoliPrenotazioni_Ky")%>">
      <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
      <input type="hidden" name="UtentiGruppi_Ky" id="UtentiGruppi_Ky" value="<%=dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString()%>">
			<input type="hidden" name="CoreModules_Ky" id="CoreModules_Ky" value="<%=intCoreModules_Ky%>">
			<input type="hidden" name="CoreEntities_Ky" id="CoreEntities_Ky" value="<%=intCoreEntities_Ky%>">
			<input type="hidden" name="CoreGrids_Ky" id="CoreGrids_Ky" value="<%=intCoreGrids_Ky%>">
			<input type="hidden" name="CoreForms_Ky" id="CoreForms_Ky" value="<%=intCoreForms_Ky%>">
      <!--#include file=/admin/forms_messaggi.inc -->
	 		<div class="divform">
      <!--#include file=/admin/app/veicoli/forms/VeicoliPrenotazioni_form.htm -->
      </div>
  </div>
</div>
</form>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <dialog id="formQuickEditAnagrafiche" class="reveal large" data-reveal>
      <input type="hidden" name="formaction" value="/admin/app/anagrafiche/crud/salva-anagrafiche.aspx">
      <input type="hidden" name="azione" value="new">
      <input type="hidden" name="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
      <input type="hidden" name="Anagrafiche_Ky" value="<%=GetFieldValue(dtFormsData, "Anagrafiche_Ky")%>">
      <input type="hidden" name="AnagraficheTipo_Ky" value="3">
      <input type="hidden" name="Lingue_Ky" value="1">
      <input type="hidden" name="Nazioni_Ky" value="105">
      <input type="hidden" name="Aziende_Ky" value="1">
      <input type="hidden" name="Anagrafiche_Attivo" value="1">
      <input type="hidden" name="ajax" value="1">
        <div class="grid-x grid-padding-x">
          <div class="large-2 medium-2 small-4 cell">
            <label id="lblAnagraficheTipologia_Ky" for="AnagraficheTipologia_Ky" class="large-text-right small-text-left middle">Tipo </label>
          </div>
          <div class="large-4 medium-4 small-8 cell">
              <select name="AnagraficheTipologia_Ky" id="AnagraficheTipologia_Ky" required="required" value="<%=GetFieldValue(dtFormsData, "AnagraficheTipologia_Ky")%>" onchange="AnagraficheTipologia_Ky_Change(this)">
                <!--#include file="/var/cache/AnagraficheTipologia-options.htm"--> 
              </select>
    	        <span class="form-error">Obbligatorio.</span>
              <script type="text/javascript">
  	            selectSet('AnagraficheTipologia_Ky', '<%=GetFieldValue(dtFormsData, "AnagraficheTipologia_Ky")%>');
                AnagraficheTipologia_Ky_Change(document.getElementById('AnagraficheTipologia_Ky'));
              </script>
          </div>
					<div class="large-2 medium-2 small-4 cell">
              <label class="checkbox text-right align-middle" for="Anagrafiche_Privacy">Privacy</label>
          </div>
          <div class="large-4 medium-4 small-8 cell align-middle">
							<div class="switch tiny">                                         
                <input class="switch-input" type="checkbox" name="Anagrafiche_Privacy" id="Anagrafiche_Privacy" value="on" <% if (GetCheckValue(dtFormsData, "Anagrafiche_Privacy")){ Response.Write("checked");} %>/>
                <label class="switch-paddle" for="Anagrafiche_Privacy">
                  <span class="show-for-sr">Privacy</span>
                  <span class="switch-active" aria-hidden="true"><i class="fa-duotone fa-square-check fa-fw fa-lg"></i></span>
                  <span class="switch-inactive" aria-hidden="true"></span>
                </label>
              </div> 
          </div>                                          
          
        </div>
        <div class="grid-x grid-padding-x">
          <div class="large-2 medium-2 small-4 cell">
            <label id="lblAnagrafiche_RagioneSocialeForm" for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle" style="display:hidden">Rag. Soc. </label>
          </div>
          <div class="large-10 medium-10 small-8 cell">
            <input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" value="<%=GetFieldValue(dtFormsData, "Anagrafiche_RagioneSociale")%>" placeholder="Ragione Sociale" maxlength="100" style="display:hidden">
          </div>
        </div>
        <div class="grid-x grid-padding-x">
          <div class="large-2 medium-2 small-4 cell">
            <label id="lblAnagrafiche_Nome" for="Anagrafiche_Nome" class="large-text-right small-text-left middle">Nome</label>
          </div>
          <div class="large-4 medium-4 small-8 cell">
            <input type="text" name="Anagrafiche_Nome" id="Anagrafiche_Nome" value="<%=GetFieldValue(dtFormsData, "Anagrafiche_Nome")%>" placeholder="Nome" maxlength="100">
          </div>
          <div class="large-2 medium-2 small-4 cell">
            <label id="lblAnagrafiche_Cognome" for="Anagrafiche_Cognome" class="large-text-right small-text-left middle">Cognome</label>
          </div>
          <div class="large-4 medium-4 small-8 cell">
            <input type="text" name="Anagrafiche_Cognome" id="Anagrafiche_Cognome" value="<%=GetFieldValue(dtFormsData, "Anagrafiche_Cognome")%>" placeholder="Cognome" maxlength="100">
          </div>
        </div>            
                    
        <div class="grid-x grid-padding-x">
          <div class="large-2 medium-2 small-4 cell">
            <label id="lblAnagrafiche_EmailContatti" for="Anagrafiche_EmailContatti" class="large-text-right small-text-left middle">Email contatti</label>
          </div>
          <div class="large-4 medium-4 small-8 cell">
            <input type="text" class="email" name="Anagrafiche_EmailContatti" id="Anagrafiche_EmailContatti" value="<%=GetFieldValue(dtFormsData, "Anagrafiche_EmailContatti")%>" placeholder="Email contatti">
          </div>
          <div class="large-2 medium-2 small-4 cell">
            <label id="lblAnagrafiche_Telefono" for="Anagrafiche_Telefono" class="large-text-right small-text-left middle">Telefono</label>
          </div>
          <div class="large-4 medium-4 small-8 cell">
            <input type="text" class="phone" name="Anagrafiche_Telefono" id="Anagrafiche_Telefono" value="<%=GetFieldValue(dtFormsData, "Anagrafiche_Telefono")%>" placeholder="Telefono">
          </div>
        </div>            
        <div class="grid-x grid-padding-x">
           <div class="large-12 medium-12 small-12 cell text-center">
            <button class="button large success" onclick="javascript:salvaAnagraficaQuickEdit()">Salva</button>
          </div>
        </div>

        <button class="close-button" data-close aria-label="Close modal" type="button">
          <span aria-hidden="true">&times;</span>
        </button>
    </dialog>        
    
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
