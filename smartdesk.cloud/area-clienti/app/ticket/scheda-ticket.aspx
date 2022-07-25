<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/ticket/scheda-ticket.aspx.cs" Inherits="_Default" Debug="true"%>
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
    <div class="stacked-for-small button-group small hide-for-print align-right">
      <% if (strAzione=="new"){ %>
        <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-save fa-lg fa-fw"></i>Salva</button>
      <% } %>
    </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <div class="divform">
      
      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="Ticket_Titolo" class="large-text-right small-text-left middle">Titolo*</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <% if (strAzione=="new"){ %>
                <input type="text" name="Ticket_Titolo" id="Ticket_Titolo" placeholder="Titolo" title="Titolo" value="<%=GetFieldValue("Ticket_Titolo")%>" required="required">
                <span class="form-error">Obbligatorio.</span>
            <% }else{ %>	
                <span><%=GetFieldValue("Ticket_Titolo")%></span>						  
            <% } %>							  
        </div>
      </div>

      <% if (strAzione!="new"){ %>
      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="TicketStati_Titolo" class="large-text-right small-text-left middle">Stato</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <span><%=GetFieldValue("TicketStati_Titolo")%></span>						  
        </div>
      </div>
      <% } %>							  

      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="AnagraficheProdotti_Ky" class="large-text-right small-text-left middle">Prodotto *</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <% if (strAzione=="new"){ %>
                <select name="AnagraficheProdotti_Ky" id="AnagraficheProdotti_Ky" value="<%=GetFieldValue("AnagraficheProdotti_Ky")%>" required="required">
                  <option value=""></option>
                  <% 
                  if (dtAnagraficheProdotti.Rows.Count>0 ){
                    for (int j = 0; j < dtAnagraficheProdotti.Rows.Count; j++){
                      Response.Write("<option value=\"" + dtAnagraficheProdotti.Rows[j]["AnagraficheProdotti_Ky"].ToString() + "\">" + dtAnagraficheProdotti.Rows[j]["AnagraficheProdotti_Titolo"].ToString() + "-" + dtAnagraficheProdotti.Rows[j]["AnagraficheProdotti_Matricola"].ToString() + "</option>");
                    }
                  }
                  %>
                </select>
      	        <span class="form-error">Obbligatorio.</span>
                <script type="text/javascript">
                  selectSet('AnagraficheProdotti_Ky', '<%=GetFieldValue("AnagraficheProdotti_Ky")%>');
                </script>
            <% }else{ %>	
                <span><%=GetFieldValue("AnagraficheProdotti_Titolo")%></span>						  
            <% } %>							  
        </div>
      </div>
      
      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="TicketCategorie_Ky" class="large-text-right small-text-left middle">Categoria *</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <% if (strAzione=="new"){ %>
                <select name="TicketCategorie_Ky" id="TicketCategorie_Ky" value="<%=GetFieldValue("TicketCategorie_Ky")%>" required="required">
                  <option value=""></option>
                  <% 
                  if (dtTicketCategorie.Rows.Count>0 ){
                    for (int j = 0; j < dtTicketCategorie.Rows.Count; j++){
                      Response.Write("<option value=\"" + dtTicketCategorie.Rows[j]["TicketCategorie_Ky"].ToString() + "\">" + dtTicketCategorie.Rows[j]["TicketCategorie_Titolo"].ToString() + "</option>");
                    }
                  }
                  %>
                </select>
      	        <span class="form-error">Obbligatorio.</span>
                <script type="text/javascript">
                  selectSet('TicketCategorie_Ky', '<%=GetFieldValue("TicketCategorie_Ky")%>');
                </script>
            <% }else{ %>	
                <span><%=GetFieldValue("AnagraficheProdotti_Titolo")%> - Matricola: <%=GetFieldValue("AnagraficheProdotti_Matricola")%></span>						  
            <% } %>							  
        </div>
      </div>

      <div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
          <label for="Ticket_Richiesta" class="large-text-right small-text-left middle">Richiesta*</label>
        </div>
        <div class="large-10 medium-10 small-8 cell">
            <% if (strAzione=="new"){ %>
              <textarea name="Ticket_Richiesta" id="Ticket_Richiesta" rows="5" cols="110" required="required"><%=GetFieldValue("Ticket_Richiesta")%></textarea>
              <span class="form-error">Obbligatorio.</span>
            <% }else{ %>	
                <span><%=GetFieldValue("Ticket_Richiesta")%></span>						  
            <% } %>							  
        </div>
      </div>

    </div>
  </div>
</div>
</form>  


<%
if (strAzione!="new"){
	System.Data.DataTable dtAttivita;
    strWHERENet="(Ticket_Ky=" + strTicket_Ky + ")";
	strFROMNet = "Attivita_Vw";
	strORDERNet = "Attivita_Inizio DESC";
	dtAttivita = new System.Data.DataTable("Attivita");
	dtAttivita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
 %>            
<% if (dtAttivita.Rows.Count>0){ %>
        <div class="grid-x grid-padding-x">
          <div class="large-12 medium-12 small-12 cell">
              <div class="card" id="sectionAttivita">
              	<div class="card-divider">
                  <h2>Risposte al ticket</h2>
                </div>		  
              	<div class="card-section">
                    <table id="rswgrid" class="grid stack hover" border="0">
                    	<thead>
                	      <tr>
                	        <th width="60">Codice</th>
                	        <th width="120">Scritto da</th>
                	        <th width="600">Risposta</th>
                	        <th width="160">Data</th>
                	      </tr>
                    	</thead>
                    	<tbody>
                		    <% for (int i = 0; i < dtAttivita.Rows.Count; i++){ %>
                		        <tr class="riga<%=i%2%>">
                		          <td><%=dtAttivita.Rows[i]["Attivita_Ky"].ToString()%></td>
                              <% if (dtAttivita.Rows[i]["Utenti_Ky"].ToString().Length>0){ %>
                                <td><%=dtAttivita.Rows[i]["Utenti_Nome"].ToString()%></td>
                              <% }else{ %>
                                <td><%=dtAttivita.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
                                <td></td>
  

                              <% } %>
                		          <td><%=dtAttivita.Rows[i]["Attivita_Descrizione"].ToString()%></td>
                		          <td class="text-left"><i class="fa-duotone fa-calendar fa-fw"></i><%=dtAttivita.Rows[i]["Attivita_Inizio"].ToString()%></td>
                		        </tr>
                		    <% } %>
                    	</tbody>
                    </table>
                </div>		  
              </div>
            </div>
        </div>
<% } %>


<% if (dtTicket.Rows[0]["TicketStati_Ky"].ToString()=="1"){ %>
  <% if (dtAttivita.Rows.Count>0){ %>
            <form action="/area-clienti/app/attivita/crud/salva-attivita.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
              <input type="hidden" name="azione" id="azione" value="new">
              <input type="hidden" name="Attivita_Ky" id="Attivita_Ky" value="">
              <input type="hidden" name="Ticket_Ky" id="Ticket_Ky" value="<%=GetFieldValue("Ticket_Ky")%>">
              <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=strAnagrafiche_Ky%>" size="3">
              <input type="hidden" name="AnagraficheProdotti_Ky" id="AnagraficheProdotti_Ky" value="<%=GetFieldValue("AnagraficheProdotti_Ky")%>">
              <input type="hidden" name="Attivita_OrePreviste" id="Attivita_OrePreviste" value="0">
              <input type="hidden" name="Attivita_Ore" id="Attivita_Ore" value="0">
              <input type="hidden" name="Attivita_Inizio" id="Attivita_Inizio" value="<%=DateTime.Now.ToString("dd-MM-yyyy HH:mm")%>">
              <input type="hidden" name="Attivita_OraInizio" id="Attivita_OraInizio" value="<%=DateTime.Now.ToString("HH:mm tt")%>">
              <input type="hidden" name="Attivita_Scadenza" id="Attivita_Scadenza" value="<%=DateTime.Now.ToString("dd-MM-yyyy HH:mm")%>">
              <input type="hidden" name="Attivita_OraScadenza" id="Attivita_OraScadenza" value="<%=DateTime.Now.ToString("HH:mm")%>">
              <input type="hidden" name="Attivita_Chiusura" id="Attivita_Chiusura" value="<%=DateTime.Now.ToString("dd-MM-yyyy HH:mm")%>">
              <input type="hidden" name="AttivitaTipo_Ky" id="AttivitaTipo_Ky" value="1">
              <input type="hidden" name="Priorita_Ky" id="Priorita_Ky" value="1">
              <input type="hidden" name="AttivitaSettore_Ky" id="AttivitaSettore_Ky" value="1">
              <input type="hidden" name="AttivitaStati_Ky" id="AttivitaStati_Ky" value="1">
              <input type="hidden" name="Attivita_Trasferta" id="Attivita_Trasferta" value="0">
              <input type="hidden" name="Attivita_Completo" id="Attivita_Completo" value="1">
            
            <div class="grid-x grid-padding-x">
              <div class="large-12 medium-12 small-12 cell">
                  <div class="card" id="sectionAttivita">
                    <div class="card-divider">
                      <h2>Rispondi al ticket</h2>
                    </div>		  
                    <div class="card-section">
                        <div class="grid-x grid-padding-x">
                          <div class="large-12 medium-12 small-8 cell">
                            <textarea name="Attivita_Descrizione" id="Attivita_Descrizione" rows="5" cols="110"></textarea>
                            <span class="form-error">Obbligatorio.</span>
                            <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-save fa-lg fa-fw"></i>Rispondi ora</button>
                          </div>
                        </div>
                    </div>
                </div>
            
                </div>
              </div>
            </div>
            </form>  
    <% }else{ %>
            <div class="grid-x grid-padding-x">
              <div class="large-12 medium-12 small-12 cell">
                    <div class="callout success"><i class="fa-duotone fa-info-circle fa-2x fa-pull-left"></i> Il ticket &egrave; stato preso in carico dai nostri tecnici e riceverai una risposta quanto prima</div>
              </div>
            </div>
    <% } %>
<% }else{ %>
  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
          <div class="callout success"><i class="fa-duotone fa-info-circle fa-2x fa-pull-left"></i> Il ticket &egrave; chiuso</div>
    </div>
  </div>
<% } %>


<% } %>

<!--#include file=/area-clienti/inc-footer.aspx -->
</body>
</html>

