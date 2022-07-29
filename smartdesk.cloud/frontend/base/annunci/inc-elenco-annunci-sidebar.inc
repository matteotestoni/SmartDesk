<div>
	<div class="callout-filtri clearfix sticky">
		<form name="layeredView" id="layeredView" method="get" action="/frontend/base/annunci/elenco-annunci.aspx">
			<input type="hidden" name="search" id="searchsidebar" value="<%=Request["search"]%>">
				<h4>Ricerca annunci</h4>
				<% if (dtAnnunciCategorie.Rows.Count>0){ %>
					<div class="rigafiltrosidebar">
					<label>Categoria</label>
					<select class="select2" name="AnnunciCategorie_Ky" id="AnnunciCategorie_Ky" multiple="multiple" onchange="javascript:jQuery('#layeredView').submit()";>
					<% for (int xy = 0; xy < dtAnnunciCategorie.Rows.Count; xy++){%>
					<option id="filtrocategoria<%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Ky"].ToString()%>" value="<%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Ky"].ToString()%>"><%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Titolo"].ToString()%></option>
					<% } %>
					</select>
					<script type="text/javascript">
					var input = "<%=Request["AnnunciCategorie_Ky"]%>";
					var categorie = input.split(',');
						categorie.forEach(function(entry) {
						jQuery("#filtrocategoria" + entry).prop('selected', true);;
						});
					</script>
					</div>
				<% } %>
				<% if (dtRegioni.Rows.Count>0){ %>
					<div class="rigafiltrosidebar">
					<label for="Regioni_Ky">Regione</label>
					<select name="Regioni_Ky" id="Regioni_Ky" onchange="loadCoreProvince();">
					<option value=""></option>
					<% for (int xy = 0; xy < dtRegioni.Rows.Count; xy++){%>
						<option id="filtroregione<%=dtRegioni.Rows[xy]["Regioni_Ky"].ToString()%>" value="<%=dtRegioni.Rows[xy]["Regioni_Ky"].ToString()%>"><%=dtRegioni.Rows[xy]["Regioni_Regione"].ToString()%></option>
					<% } %>
					</select>
					<script type="text/javascript">
					var input = "<%=Request["Regioni_Ky"]%>";
					var regioni = input.split(',');
						regioni.forEach(function(entry) {
						jQuery("#filtroregione" + entry).prop('selected', true);;
						});
					</script>
					</div>
				<% } %>       
					<% if (dtProvince.Rows.Count>0){ %>
					<div class="rigafiltrosidebar">
					<label>Province</label>
					<select class="select2" name="Province_Ky" id="Province_Ky" multiple="multiple" onchange="javascript:jQuery('#layeredView').submit()">
					<% for (int xy = 0; xy < dtProvince.Rows.Count; xy++){%>
					<option id="filtroprovince<%=dtProvince.Rows[xy]["Province_Ky"].ToString()%>" value="<%=dtProvince.Rows[xy]["Province_Ky"].ToString()%>"><%=dtProvince.Rows[xy]["Province_Provincia"].ToString()%></option>
					<% } %>
					</select>
					<script type="text/javascript">
					var input = "<%=Request["Province_Ky"]%>";
					var province = input.split(',');
					province.forEach(function(entry) {
						jQuery("#filtroprovince" + entry).prop('selected', true);;
					});
					</script>
					</div>
				<% } %>
			<div class="rigafiltrosidebar">
          <select name="camere" id="camere">
          <option value="">Camere</option><option value=">=1">1 o pi&ugrave;</option><option value=">=2">2 o pi&ugrave;</option><option value=">=3">3 o pi&ugrave;</option><option value=">=4">4 o pi&ugrave;</option>
          </select> 
    	</div>
			<div class="rigafiltrosidebar">
          <select name="bagni" id="bagni">
          <option value="">Bagni</option><option value=">=1">1 o pi&ugrave;</option><option value=">=2">2 o pi&ugrave;</option><option value=">=3">3 o pi&ugrave;</option><option value=">=4">4 o pi&ugrave;</option>
          </select> 
    	</div>
			<div class="rigafiltrosidebar">
          <select name="mqmin" id="mqmin">
          <option value="">m&sup2;</option>
          <option value=">=20">almeno 20</option>
          <option value=">=40">almeno 40</option>
          <option value=">=60">almeno 60</option>
          <option value=">=80">almeno 80</option>
          <option value=">=100">almeno 100</option>
          <option value=">=120">almeno 120</option>
          <option value=">=140">almeno 140</option>
          <option value=">=160">almeno 160</option>
          </select> 
		  </div>
			<div class="rigafiltrosidebar">
          <select name="prezzoa" id="prezzoa">
          <option value="">Prezzo</option>
          <option value="<=50000">max 50.000</option>
          <option value="<=100000">max 100.000</option>
          <option value="<=150000">max 150.000</option>
          <option value="<=200000">max 200.000</option>
          <option value="<=250000">max 250.000</option>
          <option value="<=300000">max 300.000</option>
          <option value="<=350000">max 350.000</option>
          <option value="<=400000">max 400.000</option>
          <option value="<=500000">max 500.000</option>
          <option value="<=1000000">max 1 mil.</option>
          <option value="<=5000000">max 5 mil.</option>
          </select> 
		    </div>
		  </div>
        

				<br>
				<div class="text-center">
				<button type="submit" class="button small radius" value="Cerca">Cerca<i class="fa-duotone fa-search fa-fw"></i></button>
				</div>
			</form> 
	</div>
	<% if ((dtBannerSidebar1!=null && dtBannerSidebar1.Rows.Count>0) || (dtBannerSidebar2!=null && dtBannerSidebar2.Rows.Count>0)) { %>
		<hr>
		<div class="callout">
		<span class="label">Pubblicit&agrave;</span>
		<% 
		if (dtBannerSidebar1!=null && dtBannerSidebar1.Rows.Count>0){
				for (int i = 0; i < dtBannerSidebar1.Rows.Count; i++){
					%>
					<a href="<%=dtBannerSidebar1.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank"><img src="<%=dtBannerSidebar1.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
				<% } 
		}
		%>
		
		<% 
		if (dtBannerSidebar2!=null && dtBannerSidebar2.Rows.Count>0){
			for (int i = 0; i < dtBannerSidebar2.Rows.Count; i++){
				%>
				<a href="<%=dtBannerSidebar2.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank"><img src="<%=dtBannerSidebar2.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
			<% } 
		} %>
		</div>
	<% } %>
</div>
