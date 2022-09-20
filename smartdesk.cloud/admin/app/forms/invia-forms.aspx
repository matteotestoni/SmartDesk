<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/forms/invia-forms.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Elenco anagrafiche</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-envelope fa-lg fa-fw"></i><%=strH1%></h1>
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">
  			<div class="stacked-for-small button-group small hide-for-print align-right">
          <a class="button dropdown clear" data-toggle="filtri-dropdown"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Filtri</a>
          <div class="dropdown-pane" id="filtri-dropdown" data-dropdown data-auto-focus="true">
    				<a href="/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=36" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Clienti</a>
    				<a href="/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&AnagraficheTipo_Ky=4" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Fornitori</a>
    				<a href="/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&AnagraficheTipo_Ky=3" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Lead</a>
    				<a href="/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&Anagrafiche_Disdetto=1" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Anagrafiche chiuse</a>
    				<a href="/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198&tutti=tutti" class="button clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Tutte le anagrafiche</a>
          </div>   
  				<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Aggiungi nuova anagrafica</a>
  			</div>
			</div>
		</div>
	</div>
</div>

<div class="grid-container fluid">
<div class="grid-x grid-padding-x">
   <div class="large-12 medium-12 small-12 cell">
      <div class="divgrid">
      <div class="grid-x grid-padding-x">
        <div class="large-3 medium-3 small-8 cell end">
          <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
          <div class="input-group">
            <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
              <option value="">Azioni di gruppo</option>
              <option value="delete" data-action="/admin/app/anagrafiche/crud/elimina-anagrafiche.aspx">Elimina</option>
            </select>
            <div class="input-group-button">
              <input type="hidden" id="sorgente" name="sorgente" value="elenco-anagrafiche">
              <input type="hidden" id="azione" name="azione" value="">
              <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
              <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
              <input type="submit" id="doaction" class="button secondary" value="Applica">
            </div>
          </div>
          </form>
        </div>
      </div>

		    <table class="grid hover scroll" id="griddatatables">
		    	<thead>
		      <tr>
	        	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
		        <th width="30">Cod.</th>
		        <th width="300">Ragione Sociale</th>
		        <th width="80">Tipologia</th>
		        <th width="80">Tipo</th>
		        <th width="150">Comune</th>
		        <th width="120">Prov.</th>
		        <th width="80">Nazione</th>
		        <th width="120">Stato sondaggio</th>
		        <th width="120"></th>
		      </tr>
			   </thead>
			   <tbody>
		    <%for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>" data-value="<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>" /></td>
		          <td class="show-for-medium-up large-text-center small-text-left nowrap"><a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>"><%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%></a></td>
		          <td>
								<div class="width300">
			            <% if (dtAnagrafiche.Rows[i]["Anagrafiche_Disdetto"].Equals(true)){ %>
				            <i class="fa-duotone fa-circle-info fa-fw" style="color:#ec5840" title="chiuso"></i>
				          <% } %>
									<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>">
                  <% if (dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
                  <img src="https://www.google.com/s2/favicons?domain=<%=dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>&size=16" width="16" height="16" border="0">
                  <% }else{ %>
                  <i class="fa-duotone fa-user fa-fw"></i>
                  <% } %>  
                  <%=dtAnagrafiche.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%>
                  </a>
								</div>
							</td>
		          <td><%=dtAnagrafiche.Rows[i]["AnagraficheTipologia_Titolo"].ToString()%></td>
		          <td><%=dtAnagrafiche.Rows[i]["AnagraficheTipo_Descrizione"].ToString()%></td>
		          <td><div class="width150"><i class="fa-duotone fa-location-dot fa-fw"></i><%=dtAnagrafiche.Rows[i]["Comuni_Comune"].ToString()%></div></td>
		          <td><i class="fa-duotone fa-location-dot fa-fw"></i><%=dtAnagrafiche.Rows[i]["Province_Provincia"].ToString()%></td>
		          <td><img src="/img/flags/<%=dtAnagrafiche.Rows[i]["Nazioni_Codice"].ToString()%>.png" hspace="5"><%=dtAnagrafiche.Rows[i]["Nazioni_Nazione"].ToString()%></td>
		          <td>stato sondaggio<td>
		          <td><a href="/admin/app/forms/actions/invia-forms.aspx?Forms_Ky=1&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>"><i class="fa-duotone fa-envelope fa-fw"></i>Invia richiesta di compilazione al cliente</a><td>
		        </tr>
		    <%
		      intAnagrafiche_Ky=Convert.ToInt32(dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
		    } %>
			    </tbody>
			  </table>
    		<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
				<span class="pagination_info">
				&nbsp;&nbsp;<%=intNumRecords%> elementi
				</span>
        </div>
  </div>
 </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
