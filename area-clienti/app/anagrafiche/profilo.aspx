<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/anagrafiche/profilo.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
	<link type="text/css" rel="stylesheet" href="/area-clienti/area-clienti.css">
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
<form action="/area-clienti/app/anagrafiche/crud/salva-anagrafica.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
  <input type="hidden" name="azione" id="azione" value="modifica">
  <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString()%>">
  <div class="content-header">
      <div class="grid-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-user fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString()%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
  			<div class="stacked-for-small button-group small hide-for-print align-right">
  				<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-save fa-lg fa-fw"></i>Salva</button>
  			</div>
  	      </div>
      </div>
  </div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
   
        <div class="grid-x grid-padding-x">
          <div class="large-2 medium-2 small-4 cell">
            <label class="checkbox text-right align-middle" for="Anagrafiche_Privacy">Autorizzo al trattamento dati</label>
          </div>
          <div class="large-2 medium-2 small-8 cell align-middle">
          	<div class="switch tiny">                                         
              <input class="switch-input" type="checkbox" name="Anagrafiche_Privacy" id="Anagrafiche_Privacy" value="on" <% if (GetCheckValue(dtAnagrafiche, "Anagrafiche_Privacy")){ Response.Write("checked");} %> />
              <label class="switch-paddle" for="Anagrafiche_Privacy">
                <span class="show-for-sr">Privacy</span>
                <span class="switch-active" aria-hidden="true"><i class="fa-duotone fa-check-square fa-fw fa-lg"></i></span>
                <span class="switch-inactive" aria-hidden="true"></span>
              </label>
            </div> 
          </div>                                          

          <div class="large-2 medium-2 small-4 cell">
            <label class="checkbox text-right align-middle" for="Anagrafiche_Newsletter">Voglio ricevere la Newsletter</label>
          </div>
          <div class="large-2 medium-2 small-8 cell align-middle">
          	<div class="switch tiny">                                         
              <input class="switch-input" type="checkbox" name="Anagrafiche_Newsletter" id="Anagrafiche_Newsletter" value="on" <% if (GetCheckValue(dtAnagrafiche, "Anagrafiche_Newsletter")){ Response.Write("checked");} %> />
              <label class="switch-paddle" for="Anagrafiche_Newsletter">
                <span class="show-for-sr">Chiuso</span>
                <span class="switch-active" aria-hidden="true"><i class="fa-duotone fa-check-square fa-fw fa-lg"></i></span>
                <span class="switch-inactive" aria-hidden="true"></span>
              </label>
            </div> 
          </div>    
        </div>
                                                  
        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle">Rag.&nbsp;Sociale*</label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="Ragione Sociale" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%>" required="required" title="Ragione Sociale">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>

        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_Indirizzo" class="large-text-right small-text-left middle">Indirizzo<i class="fa-duotone fa-location-dot fa-fw"></i></label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_Indirizzo" id="Anagrafiche_Indirizzo" placeholder="Indirizzo" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_Indirizzo"].ToString()%>" required="required" title="Indirizzo">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>

        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_Telefono" class="large-text-right small-text-left middle">Telefono<i class="fa-duotone fa-phone fa-fw"></i></label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_Telefono" id="Anagrafiche_Telefono" placeholder="Telefono" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_Telefono"].ToString()%>" required="required" title="Telefono">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>

        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_PartitaIVA" class="large-text-right small-text-left middle">Partita IVA</label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_PartitaIVA" id="Anagrafiche_PartitaIVA" placeholder="Partita IVA" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString()%>" required="required" title="Partita IVA">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>

        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_CodiceFiscale" class="large-text-right small-text-left middle">Codice Fiscale</label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_CodiceFiscale" id="Anagrafiche_CodiceFiscale" placeholder="Partita IVA" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString()%>" title="Codice Fiscale">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>

        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_EmailContatti" class="large-text-right small-text-left middle">Email contatti<i class="fa-duotone fa-envelope fa-fw"></i></label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_EmailContatti" id="Anagrafiche_EmailContatti" placeholder="Email contatti" title="Email contatti" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_EmailContatti"].ToString()%>">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>

        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_EmailAmministrazione" class="large-text-right small-text-left middle">Email amministrazione<i class="fa-duotone fa-envelope fa-fw"></i></label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_EmailAmministrazione" id="Anagrafiche_EmailAmministrazione" placeholder="Email amministrazione" title="Email amministrazione" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_EmailAmministrazione"].ToString()%>">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>

        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_Password" class="large-text-right small-text-left middle">Password<i class="fa-duotone fa-envelope fa-fw"></i></label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_Password" id="Anagrafiche_Password" placeholder="Password" title="Password" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_Password"].ToString()%>">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>

        <div class="grid-x grid-padding-x">
            <div class="large-2 medium-2 small-4 cell">
            	<label for="Anagrafiche_SitoWeb" class="large-text-right small-text-left middle">Sito Web<i class="fa-duotone fa-globe fa-fw"></i></label>
            </div>
            <div class="large-10 medium-10 small-8 cell">
                <input type="text" name="Anagrafiche_SitoWeb" id="Anagrafiche_SitoWeb" placeholder="Sito web" title="Sito web" value="<%=dtAnagrafiche.Rows[0]["Anagrafiche_SitoWeb"].ToString()%>">							  
                <span class="form-error">Obbligatorio.</span>
            </div>
        </div>
  </div>
</div>
</form>
<!--#include file=/area-clienti/inc-footer.aspx -->
</body>
</html>
