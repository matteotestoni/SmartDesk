<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/sdk/scheda-attributi.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>SDK > Scheda attributi</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div class="grid-container fluid">
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
    <form id="form-attributi" action="/admin/app/sdk/crud/salva-attributi.aspx" method="post" data-abide>
    <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-gear fa-lg fa-fw"></i>Scheda attributo: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAttributi, "Attributi_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
            <div class="stacked-for-small button-group small hide-for-print align-right">
              <a href="/admin/view.aspx?CoreModules_Ky=26&CoreEntities_Ky=210&CoreGrids_Ky=218" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna ad elenco</a>
              <a href="/admin/app/sdk/scheda-attributi.aspx?azione=new&sorgente=scheda-attributo" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
              <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
            </div>
          </div>
      </div>
    </div>
		<div class="divform">  
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="Attributi_Ky" id="Attributi_Ky" value="<%=GetFieldValue(dtAttributi, "Attributi_Ky")%>">
      <!--#include file=/admin/forms_messaggi.inc -->
 			<!--#include file=/admin/app/sdk/forms/attributi_form.htm -->
    
    </div>
    </form>

<% if (strAzione!="new"){ %>
<br>
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
    <a name="opzioni"></a>
		<div class="card">
		  <div class="card-divider">
				<h2>Opzioni (<%=dtAttributiOpzioni.Rows.Count%>)</h2>
				<div class="button-group tiny">
						<button class="tiny button secondary" data-toggle="nuovaopzione"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuova opzione</button>
				</div>
		</div>
	  <div class="card-section">
    <% if (dtAttributiOpzioni!=null && dtAttributiOpzioni.Rows.Count>0){ %>
      <div class="grid-x grid-padding-x">
        <div class="large-3 medium-3 small-8 cell end">
          <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
          <div class="input-group">
            <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
              <option value="">Azioni di gruppo</option>
              <option value="delete" data-action="/admin/app/sdk/crud/elimina-attributiopzione.aspx">Elimina</option>
            </select>
            <div class="input-group-button">
              <input type="hidden" name="grid" value="elencoattributiopzioni">
              <input type="hidden" name="Attributi_Ky" value="<%=GetFieldValue(dtAttributi, "Attributi_Ky")%>">
              <input type="hidden" id="sorgente" name="sorgente" value="scheda-attributi">
              <input type="hidden" id="azione" name="azione" value="">
              <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
              <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
              <input type="submit" id="doaction" class="button secondary" value="Applica">
            </div>
          </div>
          </form>
        </div>
      </div>
  
      <table id="elencoattributiopzioni" class="grid hover scroll" border="0" width="100%">
	    	<thead>
        <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
          <th align="left" width="250">Opzione</th>
					<th width="100" class="text-left">Ordine</th>
					<th width="40" class="text-center">Default</th>
					<th width="12" class="nowrap"></th>
        </tr>
	    	</thead>
	    	<tbody>
        <%for (int i = 0; i < dtAttributiOpzioni.Rows.Count; i++){ %>
            <tr>
		          <td><input type="checkbox" class="checkrow" id="record<%=dtAttributiOpzioni.Rows[i]["AttributiOpzioni_Ky"].ToString()%>" data-value="<%=dtAttributiOpzioni.Rows[i]["AttributiOpzioni_Ky"].ToString()%>" /></td>
              <td align="left" width="300"><%=dtAttributiOpzioni.Rows[i]["AttributiOpzioni_Opzione"].ToString()%></td>
              <td class="text-left"><%=dtAttributiOpzioni.Rows[i]["AttributiOpzioni_Ordine"].ToString()%></td>
              <td class="large-text-center small-text-left">
								<% if (dtAttributiOpzioni.Rows[i]["AttributiOpzioni_Default"].Equals(true)){ %>
									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
								<% }else{ %>
									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
								<% } %>
              </td>
              <td width="10">
                <a href="/admin/app/sdk/crud/elimina-attributiopzione.aspx?azione=delete&Attributi_Ky=<%=dtAttributiOpzioni.Rows[i]["Attributi_Ky"].ToString()%>&AttributiOpzioni_Ky=<%=dtAttributiOpzioni.Rows[i]["AttributiOpzioni_Ky"].ToString()%>&sorgente=scheda-attributo" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
              </td>
            </tr>
        <% } %>
	    	</tbody>
      </table>
    <% }else{
			 Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><span class=\"messaggio\"><i class=\"fa-duotone fa-circle-info fa-fw\"></i>Nessun dato</span></div></div>");
    } %>
    
    <fieldset class="fieldset hide" id="nuovaopzione" name="nuovaopzione" data-toggler=".hide">
    <legend class="radius">Inserisci opzione</legend>
    <form id="form-attributiopzione" action="/admin/app/sdk/crud/salva-attributiopzione.aspx" method="post" data-abide novalidate>
      <input type="hidden" name="sorgente" id="sorgente" documento="scheda-attributo">
      <input type="hidden" name="azione" id="azione" value="new">
      <input type="hidden" name="AttributiOpzioni_Ky" id="AttributiOpzioni_Ky" value="">
      <input type="hidden" name="Attributi_Ky" id="Attributi_Ky" value="<%=GetFieldValue(dtAttributi, "Attributi_Ky")%>">
			<div data-abide-error class="alert callout" style="display: none;">
				<p><i class="fa-duotone fa-triangle-exclamation-triangle fa-lg fa-fw"></i> Ci sono errori nel tuo modulo: compila tutti i campi richiesti e controlla i formati.</p>
			</div>
 			<!--#include file=/admin/app/sdk/forms/attributiopzioni_form.htm -->
    </form>
    </fieldset>
	</div>
	</div>
    
	</div>    
</div>    
<% } %>


  </div>
</div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
