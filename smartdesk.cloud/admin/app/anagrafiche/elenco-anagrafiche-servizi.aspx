<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/elenco-anagrafiche-servizi.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Elenco anagrafiche servizi</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-5 small-12 cell align-middle">
              <h1><i class="fa-duotone fa-users fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-8 medium-7 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
        				<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca anagrafiche</a>
        				<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
          		</div>
        </div>
  	</div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
      <!--#include file=/admin/app/anagrafiche/where/where-anagrafiche.inc --> 
	   <div class="divgrid">
        <form action="/admin/app/anagrafiche/elenco-anagrafiche-servizi.aspx">
        <div class="grid-x grid-padding-x hide-for-print">
			<div class="shrink cell">
                <label class="large-text-right small-text-left" for="Servizi_Ky">Servizio</label>
			</div>
			<div class="cell auto">
                  <select name="Servizi_Ky" id="Servizi_Ky">
                    <option value=""></option>
                    <!--#include file="/var/cache/Servizi-options.htm"--> 
                  </select>
			</div>
			<div class="shrink cell">
                <label class="large-text-right small-text-left">Filtro per prezzo</label>
			</div>
			<div class="cell auto">
                  <div class="grid-x grid-padding-x">
                    <div class="cell auto">
                        <input type="number" name="prezzoda" id="prezzoda" value="0">
                    </div>
                    <div class="cell auto">
                        <input type="number" name="prezzoa" id="prezzoa" value="150">
                    </div>
                    <div class="cell auto">
                        <button type="submit" class="tiny button secondary" name="cerca"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
                    </div>
                  </div>
			</div>
			<div class="shrink cell">
				<a href="/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=198" class="button secondary"><i class="fa-duotone fa-filter fa-fw"></i>TUTTI</a>		
			</div>
		</div>
        </form>
    
    <table class="grid hover scroll" border="0" width="100%">
    	<thead>
        <tr>
          <th width="30" data-property="Anagrafiche_Ky">Cod.</th>
          <th width="300" data-property="Anagrafiche_RagioneSociale">Ragione Sociale</th>
          <th width="110">Scadenza</th>
          <th width="500" data-property="Servizi_Descrizione">Servizio</th>
          <th width="80" data-property="AttributiGruppi_Ky">Attributo</th>
          <th width="80" data-property="AnagraficheServizi_Importo">Importo &euro;</th>
          <th width="12" class="nowrap"></th>
        </tr>
	   </thead>
	   <tbody>
    <%for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){ %>
        <tr class="riga<%=i%2%>">
          <td><%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%></td>
          <td>
						<div class="width400">
		            <% if (dtAnagrafiche.Rows[i]["Anagrafiche_Disdetto"].Equals(true)){ %>
				            <i class="fa-duotone fa-circle-info fa-fw" style="color:#ec5840" title="chiuso"></i>
		            <% } %>
								<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>"><i class="fa-duotone fa-users fa-fw"></i><%=dtAnagrafiche.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
						</div>
					</td>
          <td><i class="fa-duotone fa-calendar-days fa-fw"></i><strong><%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Scadenza_IT"].ToString()%></strong></td>
          <td>
            <a href="/admin/app/anagrafiche/scheda-anagraficheservizi.aspx?AnagraficheServizi_Ky=<%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Ky"].ToString()%>&sorgente=scheda-anagrafiche">
            <small><%=dtAnagrafiche.Rows[i]["Servizi_Titolo"].ToString()%> | <%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Descrizione"].ToString()%> | <%=dtAnagrafiche.Rows[i]["SitiWeb_Dominio"].ToString()%></small>
            </a>
            <small>
            <% for (int j = 0; j < dtAttributixServizi.Rows.Count; j++){
                strCodiceAttributo="attr-" + dtAttributixServizi.Rows[j]["Attributi_Codice"].ToString();
                strValoreAttributo=dtAnagrafiche.Rows[i][strCodiceAttributo].ToString();
                if (strValoreAttributo.Length>0){
                    Response.Write("<br>" + dtAttributixServizi.Rows[j]["Attributi_Titolo"].ToString() + ":&nbsp;" + strValoreAttributo);
                }
             } %>
             </small>

          </td>
          <td><div class="width150"><%=dtAnagrafiche.Rows[i]["AttributiGruppi_Titolo"].ToString()%></div></td>
          <td class="large-text-right small-text-left" style="padding-right:10px">&euro; <%=dtAnagrafiche.Rows[i]["AnagraficheServizi_Importo"].ToString()%></td>
          <td><a href="/admin/app/anagrafiche/crud/elimina-anagrafiche.aspx?azione=delete&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>" class="trash" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
        </tr>
    <%
      intAnagrafiche_Ky=Convert.ToInt32(dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
      decTot+=Convert.ToDecimal(dtAnagrafiche.Rows[i]["AnagraficheServizi_Importo"]);
    } %>
	    </tbody>
	   <tfoot>
	      <tr class="totale">
	        <td colspan="4" class="text-right">Totale</td>
	        <td class="large-text-right small-text-left" style="padding-right:10px">&euro; <%=decTot.ToString("N2", ci)%></td>
	        <td></td>
	      </tr>
	    </tfoot>
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
