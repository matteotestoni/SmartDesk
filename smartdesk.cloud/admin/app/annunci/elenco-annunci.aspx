<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Annunci > Elenco annunci</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-bullhorn fa-lg fa-fw"></i><%=strH1%></h1>
            <!--#include file=/admin/view-inc-grids.aspx --> 
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
        		<div class="stacked-for-small button-group small hide-for-print align-right">
        			<button class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca annunci</button>			
              <%
              System.Data.DataTable dtAnnunciStato = Smartdesk.Sql.getTablePage("AnnunciStato", null, "AnnunciStato_Ky", "", "AnnunciStato_Ordine", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              System.Data.DataTable dtAnnunciTipo = Smartdesk.Sql.getTablePage("AnnunciTipo", null, "AnnunciTipo_Ky", "AnnunciTipo_Attivo=1", "AnnunciTipo_Ordine", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              %>
              <a class="button dropdown clear" data-toggle="filtri-dropdown"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Filtri</a>
              <div class="dropdown-pane" id="filtri-dropdown" data-dropdown data-auto-focus="true">
        			  <a href="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42" class="clear"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Tutti gli annunci</a><br>
          			<% for (int i = 0; i < dtAnnunciTipo.Rows.Count; i++){ %>
          				<a href="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42&AnnunciTipo_Ky=<%=dtAnnunciTipo.Rows[i]["AnnunciTipo_Ky"].ToString()%>" class="secondary"><i class="fa-duotone fa-filter fa-lg fa-fw"></i><%=dtAnnunciTipo.Rows[i]["AnnunciTipo_Titolo"].ToString()%></a><br>
          			<% } %>
          			<% for (int i = 0; i < dtAnnunciStato.Rows.Count; i++){ %> 
          				<a href="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42&AnnunciStato_Ky=<%=dtAnnunciStato.Rows[i]["AnnunciStato_Ky"].ToString()%>" class="secondary"><i class="fa-duotone fa-filter fa-lg fa-fw"></i><%=dtAnnunciStato.Rows[i]["AnnunciStato_Titolo"].ToString()%></a><br>
          			<% } %>
              </div>   
        			<a href="/admin/app/annunci/scheda-annunci.aspx?azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        		</div>
          </div>
  	</div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
    <!--#include file=/admin/app/annunci/where/annunci_where.htm" --> 
    
    <div class="divgrid">
    <div class="grid-x grid-padding-x">
      <div class="large-3 medium-3 small-8 cell end">
        <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
        <div class="input-group">
          <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
            <option value="">Azioni di gruppo</option>
            <option value="delete" data-action="/admin/app/annunci/crud/elimina-annunci.aspx">Elimina</option>
          </select>
          <div class="input-group-button">
            <input type="hidden" name="grid" value="elencospese">
            <input type="hidden" id="sorgente" name="sorgente" value="elenco-annunci">
            <input type="hidden" id="azione" name="azione" value="">
            <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
            <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
            <input type="submit" id="doaction" class="button secondary" value="Applica">
          </div>
        </div>
        </form>
      </div>
    </div>
    
    <table id="elencoannunci" class="grid hover scroll" border="0" width="100%">
    	<thead>
	      <tr>
	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
	        <th width="100"></th>
	        <th width="30">Codice/N&deg;</th>
	        <th width="300">Titolo</th>
	        <th width="200">Anagrafica</th>
	        <th width="200">Tipo / Categoria</th>
	        <th width="200">Localizzazione</th>
	        <th width="60" class="text-right">Tipologia</th>
	        <th width="80" class="text-center">Stato</th>
	        <th width="60" class="text-right">Foto</th>
	        <th width="60" class="text-right">Visite</th>
	        <th width="12" class="nowrap" data-orderable="false"></th>
	      </tr>
    	</thead>
    	<tbody>
		    <%for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
		        <tr class="riga<%=i%2%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["Annunci_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["Annunci_Ky"].ToString()%>" /></td>
							<td class="text-center">
							<% if (dtGridData.Rows[i]["Annunci_Foto1"].ToString().Length>10){ %>
	          		<span data-tooltip aria-haspopup="true" data-allow-html="true" data-disable-hover="false" class="has-tip" title="<img src='<%=dtGridData.Rows[i]["Annunci_Foto1"].ToString()%>'>"><img src="<%=dtGridData.Rows[i]["Annunci_Foto1"].ToString()%>" width="100" height="75" style="width:100px;max-width:100px;height:75px;max-height:75px"></span>
							<% }else{ %>
								<i class="fa-duotone fa-bullhorn fa-fw fa-lg"></i>
							<% } %>
							</td>
		          <td>
								<%=dtGridData.Rows[i]["Annunci_Ky"].ToString()%><BR>
								<%=dtGridData.Rows[i]["Annunci_Numero"].ToString()%>
							</td>
		          <td>
								<div class="width300">
									<a href="/admin/app/annunci/scheda-annunci.aspx?Annunci_Ky=<%=dtGridData.Rows[i]["Annunci_Ky"].ToString()%>"><%=dtGridData.Rows[i]["Annunci_Titolo"].ToString()%></a><br>
								</div>
								<div style="max-height:70px;overflow:hidden;line-height:1rem;">
									<small><%=dtGridData.Rows[i]["Annunci_Descrizione"].ToString()%></small>
								</div>
							</td>
		          <td><%=dtGridData.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></td>
		          <td>
								<%=dtGridData.Rows[i]["AnnunciTipo_Titolo"].ToString()%><br>
		          	<%=dtGridData.Rows[i]["AnnunciCategorie_Titolo"].ToString()%>
							</td>
		          <td><div class="width300"><img src="https://cdn.smartdesk.cloud/img/flags/<%=dtGridData.Rows[i]["Nazioni_Codice"].ToString()%>.png" hspace="4" vspace="2" align="left"><%=dtGridData.Rows[i]["Nazioni_Codice"].ToString()%>/<%=dtGridData.Rows[i]["Regioni_Regione"].ToString()%>/<%=dtGridData.Rows[i]["Comuni_Comune"].ToString()%></div></td>
        			<td class="text-center">
		          	<%=dtGridData.Rows[i]["AnnunciTipologie_Titolo"].ToString()%>
              </td>
		          <td class="text-center"><span class="label" style="background-color:<%=dtGridData.Rows[i]["AnnunciStato_Colore"].ToString()%>"><i class="fa-duotone <%=dtGridData.Rows[i]["AnnunciStato_icona"].ToString()%> fa-fw"></i><%=dtGridData.Rows[i]["AnnunciStato_Titolo"].ToString()%></span></td>
		          <td class="text-right"><%=dtGridData.Rows[i]["Annunci_NumeroFoto"].ToString()%></td>
		          <td class="text-right"><span class="badge"><%=dtGridData.Rows[i]["Annunci_Visite"].ToString()%></span></td>
		          <td><a href="/admin/app/annunci/crud/elimina-annunci.aspx?azione=delete&sorgente=elenco-annunci&Annunci_Ky=<%=dtGridData.Rows[i]["Annunci_Ky"].ToString()%>&Aste_Ky=<%=dtGridData.Rows[i]["Annunci_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
		        </tr>
		    <% } %>
    	</tbody>
    </table>
    </div>
    <div class="paginazione">
    		<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
				<span class="pagination_info">
				&nbsp;&nbsp;<%=intNumRecords%> elementi
				</span>
    </div>
  </div>
 </div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
