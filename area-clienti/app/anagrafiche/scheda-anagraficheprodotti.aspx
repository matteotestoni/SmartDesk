<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/anagrafiche/scheda-anagraficheprodotti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
	<link type="text/css" rel="stylesheet" href="/area-clienti/area-clienti.css">
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
<form action="/area-clienti/app/anagrafiche/crud/salva-anagraficheprodotti.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
  <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
  <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=strAnagrafiche_Ky%>" size="3">
  <input type="hidden" name="AnagraficheProdotti_Ky" id="AnagraficheProdotti_Ky" value="<%=GetFieldValue("AnagraficheProdotti_Ky")%>">
  <input type="hidden" name="AnagraficheProdotti_Qta" id="AnagraficheProdotti_Qta" value="1">
<div class="content-header">
  <div class="grid-x grid-padding-x align-middle">
      <div class="large-4 medium-4 small-12 cell align-middle">
        <h1><i class="fa-duotone fa-cube fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><%=GetFieldValue("AnagraficheProdotti_Ky")%></span></h1>
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
      <% if (strAzione=="new"){ %>
      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="AnagraficheProdotti_Titolo" class="large-text-right small-text-left middle">Titolo*</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <input type="text" name="AnagraficheProdotti_Titolo" id="AnagraficheProdotti_Titolo" placeholder="Titolo" title="Titolo" value="<%=GetFieldValue("AnagraficheProdotti_Titolo")%>" required="required">							  
            <span class="form-error">Obbligatorio.</span>
        </div>
      </div>

      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="AnagraficheProdotti_Matricola" class="large-text-right small-text-left middle">Matricola *</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <input type="text" name="AnagraficheProdotti_Matricola" id="AnagraficheProdotti_Matricola" placeholder="Matricola" title="Matricola" value="<%=GetFieldValue("AnagraficheProdotti_Matricola")%>" required="required">							  
            <span class="form-error">Obbligatorio.</span>
        </div>
      </div>

      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="AnagraficheProdotti_DataAcquisto" class="large-text-right small-text-left middle">Data acquisto *</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <input type="text" class="fdatepicker" name="AnagraficheProdotti_DataAcquisto" id="AnagraficheProdotti_DataAcquisto" placeholder="Data acquisto" title="Data acquisto" value="<%=GetFieldValue("AnagraficheProdotti_DataAcquisto")%>" required="required">							  
            <span class="form-error">Obbligatorio.</span>
        </div>
      </div>
      <% }else{ %>
        <div class="callout"><i class="fa-duotone fa-info-circle fa-2x fa-pull-left"></i>Dopo aver registrato il tuo prodotto non &egrave; possibile cambiare i dati del prodotto ma solo la descrizione.</div>
      <% } %>
      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="AnagraficheProdotti_Rivenditore" class="large-text-right small-text-left middle">Rivenditore *</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <input type="text" name="AnagraficheProdotti_Rivenditore" id="AnagraficheProdotti_Rivenditore" placeholder="Rivenditore" title="Rivenditore" value="<%=GetFieldValue("AnagraficheProdotti_Rivenditore")%>" required="required">							  
            <span class="form-error">Obbligatorio.</span>
        </div>
      </div>
      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="AnagraficheProdotti_Descrizione" class="large-text-right small-text-left middle">Descrizione*</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
          <textarea name="AnagraficheProdotti_Descrizione" id="AnagraficheProdotti_Descrizione" rows="5" cols="110"><%=GetFieldValue("AnagraficheProdotti_Descrizione")%></textarea>
          <span class="form-error">Obbligatorio.</span>
        </div>
      </div>

    </div>
  </div>
</div>
</form>  
<!--#include file=/area-clienti/inc-footer.aspx -->
</body>
</html>

