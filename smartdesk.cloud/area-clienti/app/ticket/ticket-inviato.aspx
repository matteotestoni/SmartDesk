<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/ticket/ticket-inviato.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
	<script src="//cdn.ckeditor.com/4.19.2/full/ckeditor.js"></script>
	<link type="text/css" rel="stylesheet" href="/area-clienti/area-clienti.css">
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
<form action="/area-clienti/app/ticket/crud/salva-ticket.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
  <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
  <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=strAnagrafiche_Ky%>" size="3">
  <input type="hidden" name="Ticket_Ky" id="Ticket_Ky" value="<%=GetFieldValue("Ticket_Ky")%>">
  <input type="hidden" name="Lingue_Ky" id="Lingue_Ky" value="1">
  <input type="hidden" name="TicketStati_Ky" id="TicketStati_Ky" value="1">
<div class="content-header">
  <div class="grid-x grid-padding-x align-middle">
      <div class="large-4 medium-4 small-12 cell align-middle">
        <h1><i class="fa-duotone fa-ticket-alt fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><%=GetFieldValue("Ticket_Ky")%></span></h1>
      </div>
      <div class="large-8 medium-8 small-12 cell float-right align-middle">
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <div class="divform">
      
      <div class="callout success"><i class="fa-duotone fa-info-circle fa-2x fa-pull-left"></i>Ticket inviato correttamente</div>
      
      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="Ticket_Titolo" class="large-text-right small-text-left middle">Titolo*</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <span><%=GetFieldValue("Ticket_Titolo")%></span>						  
        </div>
      </div>

      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="TicketStati_Titolo" class="large-text-right small-text-left middle">Stato</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <span><%=GetFieldValue("TicketStati_Titolo")%></span>						  
        </div>
      </div>

      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="AnagraficheProdotti_Ky" class="large-text-right small-text-left middle">Prodotto *</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <span><%=GetFieldValue("AnagraficheProdotti_Titolo")%></span>						  
        </div>
      </div>
      
      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="TicketCategorie_Ky" class="large-text-right small-text-left middle">Categoria *</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <span><%=GetFieldValue("AnagraficheProdotti_Titolo")%> - Matricola: <%=GetFieldValue("AnagraficheProdotti_Matricola")%></span>						  
        </div>
      </div>

      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="Ticket_Richiesta" class="large-text-right small-text-left middle">Richiesta*</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <span><%=GetFieldValue("Ticket_Richiesta")%></span>						  
         </div>
      </div>

    </div>
  </div>
</div>
</form>  
<!--#include file=/area-clienti/inc-footer.aspx -->
</body>
</html>

