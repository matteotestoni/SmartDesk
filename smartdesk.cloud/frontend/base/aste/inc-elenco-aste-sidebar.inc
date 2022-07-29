<div class="sidebar">
	<h5>Filtra Aste</h5>
  <form name="layeredView" id="layeredView" method="get" action="/frontend/base/aste/elenco-aste.aspx">
      <input type="hidden" name="search" id="searchsidebar" value="<%=Request["search"]%>">
      <input type="hidden" name="prezzo" value="<%=Request["prezzo"]%>">
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
      <div class="grid-x grid-padding-x">
        <div class="large-6 medium-6 small-12 cell text-center">
          <a href="#">Aste</a>
        </div>
        <div class="large-6 medium-6 small-12 cell text-center">
          <a href="/elenco-risultati.aspx?AnnunciTipo_Ky=2">Lotti</a>
        </div>
      </div>
      <br>

      <span class="titolo-filtro">Categoria</span>
      <hr class="filtro">
		     <% for (int xy = 0; xy < dtAsteCategorie.Rows.Count; xy++){%>
           <input type="checkbox" id="filtrocategoria<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Ky"].ToString()%>" name="AsteCategorie_Ky" value="<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Ky"].ToString()%>" />
           <label for="filtrocategoria<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Ky"].ToString()%>">
           <%=dtAsteCategorie.Rows[xy]["AsteCategorie_Titolo"].ToString()%>
           </label>
           <br>
				 <% } %>
         <script type="text/javascript">
           var input = "<%=Request["AsteCategorie_Ky"]%>";
           var categorie = input.split(',');
            categorie.forEach(function(entry) {
              jQuery("#filtrocategoria" + entry).prop('checked', true);;
            });
         </script>
       <p></p>
       <span class="titolo-filtro">Regione</span>
       <hr class="filtro">
				 <% for (int xy = 0; xy < dtRegioni.Rows.Count; xy++){%>
            <input type="checkbox" id="filtroregione<%=dtRegioni.Rows[xy]["Regioni_Ky"].ToString()%>" name="Regioni_Ky" value="<%=dtRegioni.Rows[xy]["Regioni_Ky"].ToString()%>" />
            <label for="filtroregione<%=dtRegioni.Rows[xy]["Regioni_Ky"].ToString()%>">
            <%=dtRegioni.Rows[xy]["Regioni_Regione"].ToString()%>
            </label><br>
				 <% } %>
         <script type="text/javascript">
           var input = "<%=Request["Regioni_Ky"]%>";
           var regioni = input.split(',');
            regioni.forEach(function(entry) {
              jQuery("#filtroregione" + entry).prop('checked', true);;
            });
         </script>
  </form>  
</div>


