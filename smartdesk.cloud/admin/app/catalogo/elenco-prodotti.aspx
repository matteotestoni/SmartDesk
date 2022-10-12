<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Catalogo > Elenco prodotti</title>
  <!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-cube fa-lg fa-fw"></i><%=strH1%></h1>
            <!--#include file=/admin/view-inc-grids.aspx --> 
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
        				<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</a>
                <a class="button dropdown clear" data-toggle="filtri-dropdown"><i class="fa-duotone fa-filter fa-lg fa-fw"></i>Filtri</a>
                <div class="dropdown-pane" id="filtri-dropdown" data-dropdown data-auto-focus="true">
          				<a href="/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&invetrina=1" class="secondary"><i class="fa-duotone fa-filter fa-fw"></i>In vetrina</a><br>
          				<a href="/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&inofferta=1" class="secondary"><i class="fa-duotone fa-filter fa-fw"></i>Offerte</a><br>
          				<a href="/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&inpromozione=1" class="secondary"><i class="fa-duotone fa-filter fa-fw"></i>Promozioni</a><br>
          				<a href="/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&outlet=1" class="secondary"><i class="fa-duotone fa-filter fa-fw"></i>Outlet</a><br>
          				<a href="/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&tutti=tutti" class="secondary"><i class="fa-duotone fa-filter-slash fa-fw"></i>TUTTI / Rimuovi filtri</a><br>
                </div>   
        				<a href="/admin/app/catalogo/scheda-prodotto.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        			</div>
  	      </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">

      <!--#include file=/admin/app/catalogo/where/where-prodotti.inc --> 
			<div class="divgrid">
      <div class="grid-x grid-padding-x">
        <div class="large-3 medium-3 small-8 cell left">
          <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
          <div class="input-group">
            <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
              <option value="">Azioni di gruppo</option>
              <option value="delete" data-action="/admin/app/catalogo/crud/elimina-prodotto.aspx">Elimina</option>
            </select>
            <div class="input-group-button">
              <input type="hidden" name="grid" value="elencoprodotti">
              <input type="hidden" id="azione" name="azione" value="">
              <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
              <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
              <input type="submit" id="doaction" class="button secondary" value="Applica">
            </div>
          </div>
          </form>
        </div>
        <div class="large-3 large-offset-6 medium-3 medium-offset-6 small-4 cell right">
          <form class="formRicerca" name="formOrderBy" method="get" acction="/admin/app/catalogo/elenco-prodotti.aspx">
          <div class="input-group">
            <select class="input-group-field" name="orderby" id="orderby">
              <option value="">Ordina per</option>
              <option value="Prodotti_Ky">ID prodotto</option>
              <option value="Prodotti_Codice">Codice prodotto</option>
              <option value="Prodotti_Titolo">Titolo prodotto</option>
              <option value="Prodotti_Ordine">Ordine prodotto</option>
            </select>
            <script type="text/javascript">
              selectSet('orderby', '<%=Request["orderby"]%>');
            </script>
            <div class="input-group-button">
              <%
    					foreach (String key in Request.QueryString.AllKeys){
    					  if (key!="orderby"){
                  Response.Write("<input type=\"hidden\" id=\"" + key + "\" name=\"" + key + "\" value=\"" + Request.QueryString[key] + "\">");
    						}
    					}
              %>
              <input type="submit" id="doorder" class="button secondary" value="Ordina">
            </div>
          </div>
          </form>
        </div>
      </div>
			<div class="filtriapplicati hide">
				<%=strWHERENet%>
			</div>
			<table id="elencoprodotti" class="grid table-scroll hover">
	    	<thead>
		      <tr>
	          <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
		        <th width="60" data-orderable="false">Foto</th>
		        <th width="30">ID</th>
		        <th width="40">Cod.</th>
		        <th width="40">Tipo</th>
		        <th width="300">Titolo / Categoria</th>
		        <th width="30">Qta</th>
		        <th width="70">Prezzo</th>
		        <th width="40">Ordine</th>
		        <th width="40">Pubblicato</th>
		        <th width="12" class="nowrap" data-orderable="false"></th>
		      </tr>
	    	</thead>
	    	<tbody>
			    <%for (int i = 0; i < dtGridData.Rows.Count; i++){ %>
			        <tr class="riga<%=i%2%>">
		            <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["Prodotti_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["Prodotti_Ky"].ToString()%>" /></td>
		            <td>
								<% if (dtGridData.Rows[i]["Prodotti_Foto1"].ToString().Length>0){ %>
									<img src="<%=dtGridData.Rows[i]["Prodotti_Foto1"].ToString()%>" width="60" height="60" alt="<%=dtGridData.Rows[i]["Prodotti_Codice"].ToString()%>">
								<% } %>
								</td>
			          <td><%=dtGridData.Rows[i]["Prodotti_Ky"].ToString()%></td>
			          <td><a href="/admin/app/catalogo/scheda-prodotto.aspx?Prodotti_Ky=<%=dtGridData.Rows[i]["Prodotti_Ky"].ToString()%>"><%=dtGridData.Rows[i]["Prodotti_Codice"].ToString()%></a></td>
			          <td><%=dtGridData.Rows[i]["ProdottiTipo_Codice"].ToString()%></td>
			          <td>
                  <% if (dtGridData.Rows[i]["Prodotti_CodicePadre"].ToString().Length>0){ %>
                     <%=dtGridData.Rows[i]["Prodotti_CodicePadre"].ToString()%> <i class="fa-duotone fa-angle-double-right fa-fw"></i>
                  <% }else{ %>
                    <% if (dtGridData.Rows[i]["Prodotti_Padre"].ToString().Length>0 && dtGridData.Rows[i]["Prodotti_Padre"].ToString()!="0" ){ %>
                       <%=dtGridData.Rows[i]["Prodotti_Padre"].ToString()%> <i class="fa-duotone fa-angle-double-right fa-fw"></i>
                    <% } %>
                  <% } %>
                  <a href="/admin/app/catalogo/scheda-prodotto.aspx?Prodotti_Ky=<%=dtGridData.Rows[i]["Prodotti_Ky"].ToString()%>"><%=dtGridData.Rows[i]["Prodotti_Titolo"].ToString()%></a>
                  <br><%=dtGridData.Rows[i]["ProdottiCategorie_Titolo"].ToString()%>
                </td>
			          <td class="large-text-center small-text-left"><%=dtGridData.Rows[i]["Prodotti_Qta"].ToString()%></td>
			          <td class="large-text-right small-text-left">&euro; <%=((decimal)dtGridData.Rows[i]["Prodotti_Prezzo"]).ToString("N2", ci)%></td>
			          <td class="large-text-right small-text-left"><%=dtGridData.Rows[i]["Prodotti_Ordine"].ToString()%></td>
  		          <td class="text-center">
  								<% if (dtGridData.Rows[i]["Prodotti_PubblicaWEB"].Equals(true)){ %>
  									<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
  								<% }else{  %>
  									<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
  								<% } %>
  							</td>
			          <td><a href="/admin/app/catalogo/crud/elimina-prodotto.aspx?azione=delete&Prodotti_Ky=<%=dtGridData.Rows[i]["Prodotti_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
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
