<div class="callout-filtri clearfix">
  <form name="layeredView" id="layeredView" method="get" action="/elenco-risultati.aspx">
      <input type="hidden" name="search" id="searchsidebar" value="<%=Request["search"]%>">
      <div class="grid-x grid-padding-x">
        <div class="large-6 medium-6 small-12 cell text-left">
          <input type="reset" class="button tiny secondary" value="Reset">
        </div>
        <div class="large-6 medium-6 small-12 cell text-right">
          <input type="submit" class="button tiny warning" value="Applica">
        </div>
      </div>
      <span class="titolo-filtro">Tipo</span>
      <hr class="filtro">
      <input type="radio" id="AnnunciTipo_Ky1" name="AnnunciTipo_Ky" value="1">Annunci
      <input type="radio" id="AnnunciTipo_Ky2" name="AnnunciTipo_Ky" value="2">Lotti
      <script type="text/javascript">
        radioSet("AnnunciTipo_Ky", "<%=Request["AnnunciTipo_Ky"]%>");
      </script>
      <br>
      <% if (dtAnnunciCategorie.Rows.Count>0){ %>
      <span class="titolo-filtro">Categoria</span>
      <hr class="filtro">
		     
				 <ul class="vertical menu accordion-menu" data-accordion-menu data-submenu-toggle="false">
				 <% 
					 for (int intCategorie = 0; intCategorie < dtAnnunciCategorie.Rows.Count; intCategorie++){%>
					 <li>
						 <a href="#" onclick="document.getElementById('filtrocategoria<%=dtAnnunciCategorie.Rows[intCategorie]["AnnunciCategorie_Ky"].ToString()%>').checked=true">
					   <input type="checkbox" class="hide" id="filtrocategoria<%=dtAnnunciCategorie.Rows[intCategorie]["AnnunciCategorie_Ky"].ToString()%>" name="AnnunciCategorie_Ky" value="<%=dtAnnunciCategorie.Rows[intCategorie]["AnnunciCategorie_Ky"].ToString()%>" />
	           <label for="aaaafiltrocategoria<%=dtAnnunciCategorie.Rows[intCategorie]["AnnunciCategorie_Ky"].ToString()%>">
	           <%=dtAnnunciCategorie.Rows[intCategorie]["AnnunciCategorie_Titolo"].ToString()%>
	           </label>
	           </a>
	           <%
	            if (strAnnunciCategorie_Ky!=null && dtAnnunciCategorie!=null && strAnnunciCategorie_Ky.Contains(dtAnnunciCategorie.Rows[intCategorie]["AnnunciCategorie_Ky"].ToString())){
								VisualizzaFigli(dtAnnunciCategorie.Rows[intCategorie]["AnnunciCategorie_Ky"].ToString(),true);
							}else{
								VisualizzaFigli(dtAnnunciCategorie.Rows[intCategorie]["AnnunciCategorie_Ky"].ToString(),false);
							}	
						 %>
           </li>
				 <% } %>
				 </ul>

         <script type="text/javascript">
					 var input = "<%=Request["AnnunciCategorie_Ky"]%>";
           var categorie = input.split(',');
            categorie.forEach(function(entry) {
              jQuery("#filtrocategoria" + entry).prop('checked', true);;
            });
         </script>
       <p></p>
       <% } %>
       <div>
       <span class="titolo-filtro">Prezzo</span>
       <hr class="filtro">
        <div class="input-group tiny">
          <span class="input-group-label">da</span>
          <%
           string strPrezzoDa=Request["prezzoda"];
           if (strPrezzoDa==null || strPrezzoDa=="" || strPrezzoDa.Length<1){
            strPrezzoDa="0";
           }
          %>
          <input name="prezzoda" id="prezzoda" class="input-group-field" type="text" min="0" max="499000" step="1000" value="<%=strPrezzoDa%>">
        </div>
        <div class="input-group tiny">
          <span class="input-group-label">a&nbsp;</span>
          <%
           string strPrezzoA=Request["prezzoa"];
           if (strPrezzoA==null || strPrezzoA=="" || strPrezzoA.Length<1){
            strPrezzoA="500000";
           }
          %>
          <input name="prezzoa" id="prezzoa" class="input-group-field" type="text" min="1000" max="500000" step="1000" value="<%=strPrezzoA%>">
        </div>
       <span class="titolo-filtro">Regione</span>
       <hr class="filtro">
				 <% for (int xy = 0; xy < dtRegioni.Rows.Count; xy++){%>
            <input type="checkbox" id="filtroregione<%=dtRegioni.Rows[xy]["Regioni_Ky"].ToString()%>" name="Regioni_Ky" value="<%=dtRegioni.Rows[xy]["Regioni_Ky"].ToString()%>" />
            <label for="filtroregione<%=dtRegioni.Rows[xy]["Regioni_Ky"].ToString()%>"><%=dtRegioni.Rows[xy]["Regioni_Regione"].ToString()%></label><br>
				 <% } %>
         <script type="text/javascript">
           var input = "<%=Request["Regioni_Ky"]%>";
           var regioni = input.split(',');
            regioni.forEach(function(entry) {
              jQuery("#filtroregione" + entry).prop('checked', true);;
            });
         </script>
       </div> 
    </form>
  </div>


