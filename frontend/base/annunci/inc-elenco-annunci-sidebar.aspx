<div>
	<div class="callout-filtri clearfix sticky hide-for-small-only">
		<form name="layeredView" id="layeredView" method="get" action="/elenco-annunci.aspx">
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
					<select class="select2" name="Regioni_Ky" id="Regioni_Ky" onchange="loadCoreProvince();">
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
				<% if (dtComuni.Rows.Count>0){ %>
					<div class="rigafiltrosidebar">
					<label>Comuni</label>
					<select class="select2" name="Comuni_Ky" id="Comuni_Ky" multiple="multiple" onchange="javascript:jQuery('#layeredView').submit()">
					<% for (int xy = 0; xy < dtComuni.Rows.Count; xy++){%>
					<option id="filtrocomuni<%=dtComuni.Rows[xy]["Comuni_Ky"].ToString()%>" value="<%=dtComuni.Rows[xy]["Comuni_Ky"].ToString()%>"><%=dtComuni.Rows[xy]["Comuni_Comune"].ToString()%></option>
					<% } %>
					</select>
					<script type="text/javascript">
					var input = "<%=Request["Comuni_Ky"]%>";
					var comuni = input.split(',');
					comuni.forEach(function(entry) {
						jQuery("#filtrocomuni" + entry).prop('selected', true);;
					});
					</script>
					</div>
				<% } %>
        
  			<div class="rigafiltrosidebar">
				    <label>Camere</label>
            <select class="select2" name="camere" id="camere">
            <option value="">Camere</option><option value=">=1">1 o pi&ugrave;</option><option value=">=2">2 o pi&ugrave;</option><option value=">=3">3 o pi&ugrave;</option><option value=">=4">4 o pi&ugrave;</option>
            </select> 
			      <script type="text/javascript">selectSet('camere', '<%=Request["camere"]%>');</script>
      	</div>
  			<div class="rigafiltrosidebar">
				    <label>Bagni</label>
            <select name="bagni" id="bagni">
            <option value="">Bagni</option><option value=">=1">1 o pi&ugrave;</option><option value=">=2">2 o pi&ugrave;</option><option value=">=3">3 o pi&ugrave;</option><option value=">=4">4 o pi&ugrave;</option>
            </select> 
		      <script type="text/javascript">selectSet('bagni', '<%=Request["bagni"]%>');</script>
      	</div>
  			<div class="rigafiltrosidebar">
				    <label>Mq</label>
            <select class="select2" name="mqmin" id="mqmin">
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
		      <script type="text/javascript">selectSet('mqmin', '<%=Request["mqmin"]%>');</script>
  		  </div>
  			<div class="rigafiltrosidebar">
				    <label>Prezzo</label>
            <select class="select2" name="prezzoa" id="prezzoa">
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
		      <script type="text/javascript">selectSet('prezzoa', '<%=Request["prezzoa"]%>');</script>
  		    </div>
  		  </div>
      
        
				<div class="rigafiltrosidebar">
            <input name="AnnunciTipologie_Ky" id="AnnunciTipologie_Ky1" type="radio" value="1" checked="checked" autocomplete="off"><label for="free-search-AnnunciTipologie_Ky1" title="Vendita">Vendita</label> 
            <input name="AnnunciTipologie_Ky" id="AnnunciTipologie_Ky2" type="radio" value="2" autocomplete="off"><label for="AnnunciTipologie_Ky2" title="Affitto"> Affitto </label>
				</div>
				<script type="text/javascript">
          jQuery(document).ready(function () {
				    radioSet("AnnunciTipologie_Ky","<%=Request["AnnunciTipologie_Ky"]%>");
            aggiornaFiltroPrezzo("<%=Request["AnnunciTipologie_Ky"]%>");
            jQuery('input[type=radio][name=AnnunciTipologie_Ky]').change(function() {
                if (this.value == '1') {
                    var newOptions = {"Prezzo":"","max 50.000":"<=50000","max 100.000":"<=100000","max 150.000":"<=150000","max 200.000":"<=200000","max 250.000":"<=250000","max 300.000":"<=300000","max 350.000":"<=350000","max 400.000":"<=400000","max 500.000":"<=500000","max 1 mil.":"<=1000000","max 5 mil.":"<=5000000"};
                }
                else if (this.value == '2') {
                     var newOptions = {"Prezzo":"","max 200":"<=200","max 250":"<=250","max 300":"<=300","max 350":"<=350","max 400":"<=400","max 450":"<=450","max 500":"<=500","max 550":"<=550","max 600":"<=600","max 650":"<=650","max 700":"<=700","max 1.000":"<=1000","max 1.500":"<=1500"};
                }
                var $el = jQuery("#prezzoa");
                $el.empty();
                $.each(newOptions, function(key,value) {
                  $el.append($("<option></option>")
                     .attr("value", value).text(key));
                });                                    
            });
          });
				</script>

				<br>
				<div class="text-center">
				<button type="submit" class="button small radius" value="Cerca">Cerca<i class="fa-duotone fa-search fa-fw"></i></button>
				</div>
			</form> 
	</div>
	<% if ((dtBannerSidebar1!=null && dtBannerSidebar1.Rows.Count>0) || (dtBannerSidebar2!=null && dtBannerSidebar2.Rows.Count>0) || (dtBannerSidebar3!=null && dtBannerSidebar3.Rows.Count>0) || (dtBannerSidebar4!=null && dtBannerSidebar4.Rows.Count>0)) { %>
		<hr>
		<% if (dtBannerSidebar1!=null && dtBannerSidebar1.Rows.Count>0){ %>
		<div class="callout">
			<span class="label">Pubblicit&agrave;</span>
				<% for (int i = 0; i < dtBannerSidebar1.Rows.Count; i++){
					%>
					<a href="<%=dtBannerSidebar1.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank" rel="nofollow" onclick="bannerClick(<%=dtBannerSidebar1.Rows[i]["CMSAds_Ky"].ToString()%>)"><img src="<%=dtBannerSidebar1.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
				<% } %>
		</div>
		<% } %>
		
		<% if (dtBannerSidebar2!=null && dtBannerSidebar2.Rows.Count>0){ %>
		<div class="callout">
			<span class="label">Pubblicit&agrave;</span>
			<% for (int i = 0; i < dtBannerSidebar2.Rows.Count; i++){
				%>
				<a href="<%=dtBannerSidebar2.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank" rel="nofollow" onclick="bannerClick(<%=dtBannerSidebar2.Rows[i]["CMSAds_Ky"].ToString()%>)"><img src="<%=dtBannerSidebar2.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
			<% } %> 
		</div>
		<% } %>
		
		<% if (dtBannerSidebar3!=null && dtBannerSidebar3.Rows.Count>0){ %>
		<div class="callout">
			<span class="label">Pubblicit&agrave;</span>
			<% for (int i = 0; i < dtBannerSidebar3.Rows.Count; i++){
				%>
				<a href="<%=dtBannerSidebar3.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank" rel="nofollow" onclick="bannerClick(<%=dtBannerSidebar3.Rows[i]["CMSAds_Ky"].ToString()%>)"><img src="<%=dtBannerSidebar3.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
			<% } %> 
		</div>
		<% } %>
		
		<% if (dtBannerSidebar4!=null && dtBannerSidebar4.Rows.Count>0){ %>
		<div class="callout">
			<span class="label">Pubblicit&agrave;</span>
			<% for (int i = 0; i < dtBannerSidebar4.Rows.Count; i++){
				%>
				<a href="<%=dtBannerSidebar4.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank" rel="nofollow" onclick="bannerClick(<%=dtBannerSidebar4.Rows[i]["CMSAds_Ky"].ToString()%>)"><img src="<%=dtBannerSidebar4.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
			<% } %> 
		</div>
		<% } %>
	<% } %>
  
	<hr>
    
  <% if (dtAnnunciCategorieFigli!=null && dtAnnunciCategorieFigli.Rows.Count>0){ %>
	 <h4>Filtra per categoria</h4>
    	<ul class="fa-ul categoriesidebar">
    	<% for (int i = 0; i < dtAnnunciCategorieFigli.Rows.Count; i++){ %>
    			<li><i class="fa-li fa fa-table fa-fw"></i><a href="/attivita/<%=dtAnnunciCategorieFigli.Rows[i]["AnnunciCategorie_Url"].ToString().ToLower()%>.html" title="<%=dtAnnunciCategorieFigli.Rows[i]["AnnunciCategorie_Titolo"].ToString()%> in vendita"><%=dtAnnunciCategorieFigli.Rows[i]["AnnunciCategorie_Titolo"].ToString()%></a></li>
    	<% } %>
    	</ul>
  <% } %>
	<hr>
  
</div>
