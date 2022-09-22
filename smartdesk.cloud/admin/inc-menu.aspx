<ul class="menu vertical medium-horizontal hide hide-for-print align-middle" data-responsive-menu="drilldown medium-dropdown">
	<%
 	 string strMainMenuActive="is-active";
	 System.Data.DataTable dtCoreModulesMainMenu;
	 dtCoreModulesMainMenu = Smartdesk.Sql.getTablePage("CoreModules", null, "CoreModules_Ky", "CoreModules_Active=1", "CoreModules_Order", 1, 200, Smartdesk.Config.Sql.ConnectionReadOnly,out this.intNumRecords);
	 for (int i = 0; i < dtCoreModulesMainMenu.Rows.Count; i++){
			System.Data.DataTable dtCoreEntitiesMainMenu;
		 	dtCoreEntitiesMainMenu = Smartdesk.Sql.getTablePage("CoreEntities", null, "CoreEntities_Ky", "CoreEntities_Config=0 AND CoreModules_Ky=" + dtCoreModulesMainMenu.Rows[i]["CoreModules_Ky"].ToString(), "CoreEntities_Title", 1, 200, Smartdesk.Config.Sql.ConnectionReadOnly,out this.intNumRecords);
			 	if (dtCoreEntitiesMainMenu.Rows.Count>0){
			  	for (int j = 0; j < dtCoreEntitiesMainMenu.Rows.Count; j++){
							if (Request["CoreModules_Ky"]==dtCoreModulesMainMenu.Rows[i]["CoreModules_Ky"].ToString()){
								strMainMenuActive="is-active";
							}else{
								strMainMenuActive="";
							}
		  				Response.Write("<li class=\"has-submenu " + strMainMenuActive + "\"><a href=\"/admin/app/" + dtCoreModulesMainMenu.Rows[i]["CoreModules_Code"].ToString() + "/" + dtCoreEntitiesMainMenu.Rows[j]["CoreEntities_Code"].ToString() + ".aspx\" title=\"" + dtCoreEntitiesMainMenu.Rows[j]["CoreEntities_Title"].ToString() + "\">" + dtCoreEntitiesMainMenu.Rows[j]["CoreEntities_Title"].ToString() + "</a></li>");
					}
				}
	 }
	%>
</ul>
<ul class="menu vertical medium-horizontal hide-for-print" data-responsive-menu="drilldown medium-dropdown">
  <% if (dtLogin.Rows[0]["UtentiGruppi_Calendario"].Equals(true)){ %>
  <li class="has-submenu"><a href="/admin/app/attivita/calendario.aspx" title="Calendario"><i class="fa-duotone fa-calendar-days fa-xl fa-fw"></i></a></li>
  <% } %>
  <% if (dtLogin.Rows[0]["UtentiGruppi_Anagrafiche"].Equals(true)){ %>
  <li class="has-submenu"><a href="/admin/goto-view.aspx?CoreEntities_Ky=162&CoreGrids_Ky=198" title="Anagrafiche">Anagrafiche</a>
    <ul class="submenu menu vertical" data-submenu>
  		<% if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheClienti"].Equals(true)){ %>
  		<li><a href="/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=36" title="Clienti">Clienti</a></li>
  		<% } %>
  		<% if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheConcorrenti"].Equals(true)){ %>
  		<li><a href="/admin/goto-view.aspx?CoreEntities_Ky=162&CoreGrids_Ky=197" title="Concorrenti">Concorrenti</a></li>
  		<% } %>
  		<% if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheFornitori"].Equals(true)){ %>
  		<li><a href="/admin/goto-view.aspx?CoreEntities_Ky=162&CoreGrids_Ky=196" title="Fornitori">Fornitori</a></li>
  		<% } %>
  		<% if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheFornitori"].Equals(true)){ %>
  		<li><a href="/admin/goto-view.aspx?CoreEntities_Ky=162&CoreGrids_Ky=243" title="Fornitori">Rivenditori</a></li>
  		<% } %>
  		<% if (dtLogin.Rows[0]["UtentiGruppi_Lead"].Equals(true)){ %>
  		<li><a href="/admin/goto-view.aspx?CoreEntities_Ky=162&CoreGrids_Ky=199" title="Lead">Lead</a></li>
  		<% } %>
  		<li><a href="/admin/goto-view.aspx?CoreEntities_Ky=24" title="Contatti">Contatti</a></li>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Rapporti"].Equals(true)){ %>
      <li><a href="#Rapporti" title="Rapporti">Rapporti</a>
	        <ul class="submenu menu vertical" data-submenu>
	          <li><a href="/admin/app/anagrafiche/elenco-anagrafiche-statistiche.aspx">Statistiche amministrative</a></li>
	          <li><a href="/admin/app/anagrafiche/elenco-anagrafiche-statistiche-fatturato.aspx">Statistiche fatturato</a></li>
	        </ul>
      </li>
      <% } %>
  	</ul>
	</li>
  <% } %>
  <% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
  <li class="has-submenu">
		<a href="#Amminitrazione" title="Amministrazione">Amministrazione</a>
    <ul class="submenu menu vertical" data-submenu>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Spese"].Equals(true)){ %>
      <li><a href="/admin/app/amministrazione/elenco-spese.aspx?CoreModules_Ky=2&CoreEntities_Ky=1&CoreGrids_Ky=1" title="Spese">Spese</a></li>
      <% } %>
  		<% if (dtLogin.Rows[0]["UtentiGruppi_Servizi"].Equals(true)){ %>
  		<li><a href="/admin/app/anagrafiche/elenco-anagrafiche-servizi.aspx" title="Servizi anagrafiche">Servizi anagrafiche</a></li>
      <li><a href="/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx">Servizi da fatturare</a></li>
  		<% } %>
  		<% if (dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){ %>
      <li><a href="/admin/app/pagamenti/elenco-pagamenti.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=110">Incassi da ricevere e solleciti</a></li>
      <li><a href="/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=233">Incassi ricevuti</a></li>
      <li><a href="/admin/app/pagamenti/elenco-pagamenti-da-fare.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=110">Pagamenti da fare</a></li>
      <li><a href="/admin/view.aspx?CoreModules_Ky=21&CoreEntities_Ky=75&CoreGrids_Ky=159">Pagamenti fatti</a></li>
  		<% } %>
        <% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
	        <li><a href="/admin/app/attivita/elenco-attivita-trasferte.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=273">Trasferte</a></li>
  	    <% } %>    		<% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>

		      <% if (dtLogin.Rows[0]["UtentiGruppi_Rapporti"].Equals(true)){ %>
		      <li><a href="#Rapporti" title="Rapporti">Rapporti</a>
			        <ul class="submenu menu vertical" data-submenu>
			      		<% if (dtLogin.Rows[0]["UtentiGruppi_Fatturato"].Equals(true)){ %>
				          <li><a href="/admin/app/amministrazione/prospetto-spese-anno.aspx">Prospetto spese anno</a></li>
				          <li><a href="/admin/app/amministrazione/prospetto-spese.aspx">Prospetto spese</a></li>
			          	<li><a href="/admin/app/amministrazione/prospetto-fatturato.aspx">Prospetto fatturato</a></li>
			          	<li><a href="/admin/app/amministrazione/prospetto-servizi.aspx">Prospetto servizi</a></li>
	      				<% } %>
			        </ul>
		      </li>
		      <% } %>

  		<% } %>
     
    </ul>
  </li>
  <% } %>

  <% if (dtLogin.Rows[0]["UtentiGruppi_Persone"].Equals(true) || dtLogin.Rows[0]["UtentiGruppi_PersonaleAssenze"].Equals(true)){ %>
    <li class="has-submenu">
	    <a href="#Personale" title="Personale">Personale</a>
        <ul class="submenu menu vertical" data-submenu>
      	    <% if (dtLogin.Rows[0]["UtentiGruppi_Persone"].Equals(true)){ %>
	            <li><a href="/admin/view.aspx?CoreModules_Ky=22&CoreEntities_Ky=38&CoreGrids_Ky=114">Elenco Personale</a></li>
  		    <% } %>
      	    <% if (dtLogin.Rows[0]["UtentiGruppi_PersonaleAssenze"].Equals(true)){ %>
	            <li><a href="/admin/app/persone/elenco-personeassenze.aspx?CoreModules_Ky=22&CoreEntities_Ky=39&CoreGrids_Ky=115">Assenze/Presenze</a></li>
  		    <% } %>
        </ul>
    </li>
  <% } %>
    
  <% if (dtLogin.Rows[0]["UtentiGruppi_Contenuti"].Equals(true)){ %>
  <li class="has-submenu"><a href="#Contenuti" title="Contenuti">Contenuti</a>
    <ul class="submenu menu vertical" data-submenu>
  		<% if (dtLogin.Rows[0]["UtentiGruppi_Preferiti"].Equals(true)){ %>
      <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=102&CoreGrids_Ky=85">Preferiti e link</a></li>
      <% } %>
      
  		<% if (dtLogin.Rows[0]["UtentiGruppi_Contenuti"].Equals(true)){ %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=96&CoreGrids_Ky=79">Pagine e articoli</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=101&CoreGrids_Ky=84">Gallerie</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=103&CoreGrids_Ky=86">Slide</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=257&CoreGrids_Ky=282">Popup</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=168&CoreGrids_Ky=156">Blocchi</a></li>
        <li class="hide"><a href="/admin/app/contenuti/elenco-gallerie.aspx">Gallerie immagini</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=16&CoreEntities_Ky=146&CoreGrids_Ky=96">Sondaggi</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=73&CoreGrids_Ky=94">Faq</a>
          <ul class="submenu menu vertical" data-submenu>
            <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=73&CoreGrids_Ky=94">Faq</a></li>
            <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=74&CoreGrids_Ky=95">Categorie Faq</a></li>
          </ul>
        </li>        
      <% } %>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Note"].Equals(true)){ %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=19&CoreEntities_Ky=161&CoreGrids_Ky=106">Annotazioni</a></li>
  		<% } %>
      <li><a href="/admin/app/contenuti/elenco-cmsads.aspx?CoreModules_Ky=9&CoreEntities_Ky=97&CoreGrids_Ky=80">Banner</a></li>
      
      <li class="has-submenu"><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=97&CoreGrids_Ky=80">Banner</a>
        <ul class="submenu menu vertical" data-submenu>
          <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=97&CoreGrids_Ky=80">Banner</a></li>
          <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=99&CoreGrids_Ky=82">Zone banner</a></li>
        </ul>
      </li>

      
      <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=224&CoreGrids_Ky=236">Files</a></li>
      <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=100&CoreGrids_Ky=83">Categorie</a></li>
      <li><a href="/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=104&CoreGrids_Ky=87">Tags</a></li>
    </ul>
  </li>
  <% } %>

  <% if (dtLogin.Rows[0]["UtentiGruppi_Catalogo"].Equals(true)){ %>
  <li class="has-submenu"><a href="#Catalogo" title="Catalogo">Catalogo</a>
    <ul class="submenu menu vertical" data-submenu>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Prodotti"].Equals(true)){ %>
      <li class="has-submenu"><a href="/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66" title="Prodotti">Prodotti</a>
        <ul class="submenu menu vertical" data-submenu>
          <li><a href="/admin/goto-view.aspx?CoreEntities_Ky=83">Prodotti</a></li>
          <li><a href="/admin/goto-view.aspx?CoreEntities_Ky=203">Categorie prodotti</a></li>
          <li><a href="/admin/goto-view.aspx?CoreEntities_Ky=89">Gruppi di prodotti</a></li>
        </ul>
      </li>
      <% } %>
      <% if (dtLogin.Rows[0]["UtentiGruppi_ServiziCatalogo"].Equals(true)){ %>
      <li class="has-submenu"><a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=195&CoreGrids_Ky=203" title="Servizi">Servizi</a>
        <ul class="submenu menu vertical" data-submenu>
          <li><a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=195&CoreGrids_Ky=203">Servizi</a></li>
          <li><a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=196&CoreGrids_Ky=204">Categorie di servizi</a></li>
        </ul>
      </li>
      <% } %>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Veicoli"].Equals(true)){ %>
      <li class="has-submenu"><a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=109&CoreGrids_Ky=130" title="Veicoli">Veicoli</a>
        <ul class="submenu menu vertical" data-submenu>
            <li><a href="/admin/goto-view.aspx?CoreEntities_Ky=109">Veicoli</a></li>
            <li><a href="/admin/goto-view.aspx?CoreEntities_Ky=109&CoreGrids_Ky=284">Auto Sostitutive</a></li>
            <li><a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=126&CoreGrids_Ky=147">Offerte veicoli</a></li>
            <li><a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=258&CoreGrids_Ky=283">Prenotazioni veicoli</a></li>
            <li><a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=127&CoreGrids_Ky=148">Ricerce veicoli</a></li>
            <li><a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=252&CoreGrids_Ky=275">Veicoli in vetrina</a></li>
            <li><a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=214&CoreGrids_Ky=223">Testi SEO</a></li>
        </ul>
      </li>
      <% } %>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true)){ %>
      <li class="has-submenu"><a href="/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=60&CoreGrids_Ky=50">Aste</a>
        <ul class="submenu menu vertical" data-submenu>
          <li><a href="/admin/view.aspx?CoreModules_Ky=5&CoreEntities_Ky=60&CoreGrids_Ky=50">Aste</a></li>
          <li><a href="/admin/app/aste/elenco-astecauzioni.aspx?CoreModules_Ky=5&CoreEntities_Ky=62&CoreGrids_Ky=52">Cauzioni</a></li>
          <li><a href="/admin/app/annunci/elenco-annunciofferte.aspx?CoreModules_Ky=5&CoreEntities_Ky=160&CoreGrids_Ky=61">Offerte sui lotti</a></li>
        </ul>
      </li>
      <% } %>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Annunci"].Equals(true)){ %>
      <li class="has-submenu"><a href="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42">Annunci</a>
        <ul class="submenu menu vertical" data-submenu>
      			<% if (dtLogin.Rows[0]["UtentiGruppi_Aste"].Equals(true)){ %>
              <li><a href="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42">Annunci</a></li>
              <li><a href="/admin/view.aspx?CoreModules_Ky=3&CoreEntities_Ky=51&CoreGrids_Ky=43">Categorie annunci</a></li>
      			<%}else{ %>
              <li><a href="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42">Annunci</a></li>
              <li><a href="/admin/view.aspx?CoreModules_Ky=3&CoreEntities_Ky=51&CoreGrids_Ky=43">Categorie annunci</a></li>
      			<% } %>
        </ul>
      </li>
      <% } %>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Immobili"].Equals(true)){ %>
      <li><a href="/admin/view.aspx?CoreModules_Ky=17&CoreEntities_Ky=170&CoreGrids_Ky=160">Immobili</a></li>
      <li><a href="/admin/view.aspx?CoreModules_Ky=17&CoreEntities_Ky=199&CoreGrids_Ky=207">Cantieri</a></li>
      <% } %>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Prodotti"].Equals(true)){ %>
          <li><a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=92&CoreGrids_Ky=75">Tag</a></li>
          <li><a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=84&CoreGrids_Ky=67">Applicazioni</a></li>
      <% } %>
      <li><a href="/admin/view.aspx?CoreModules_Ky=8&CoreEntities_Ky=95&CoreGrids_Ky=78">Produttori</a></li>
    </ul>
  </li>
  <% } %>


  <% if (dtLogin.Rows[0]["UtentiGruppi_Marketing"].Equals(true)){ %>
  <li class="has-submenu"><a href="#" title="Marketing">Marketing</a>
    <ul class="submenu menu vertical" data-submenu>
  			<% if (dtLogin.Rows[0]["UtentiGruppi_Campagne"].Equals(true)){ %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=31&CoreEntities_Ky=198&CoreGrids_Ky=206">Campagne di Marketing</a></li>
    		<% } %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=31&CoreEntities_Ky=189&CoreGrids_Ky=180">Canali Social</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=31&CoreEntities_Ky=235&CoreGrids_Ky=250">Eventi</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=31&CoreEntities_Ky=190&CoreGrids_Ky=181">Piani editoriali Social</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=31&CoreEntities_Ky=211&CoreGrids_Ky=219">Recensioni</a></li>
     </ul>
  </li>
  <% } %>


  <% if (dtLogin.Rows[0]["UtentiGruppi_Commerciale"].Equals(true)){ %>
  <li class="has-submenu"><a href="#" title="Commerciale">Commerciale</a>
    <ul class="submenu menu vertical" data-submenu>

  			<% if (dtLogin.Rows[0]["UtentiGruppi_Lead"].Equals(true)){ %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=185&CoreGrids_Ky=175">Lead</a></li>
  		  <li><a href="/admin/app/commerciale/assegna-lead.aspx" title="Lead">Assegn Lead</a></li>
        <li><a href="/admin/app/commerciale/elenco-lead-prospetto.aspx">Prospetto Lead</a></li>
    		<% } %>
  			<% if (dtLogin.Rows[0]["UtentiGruppi_Opportunita"].Equals(true)){ %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=20&CoreEntities_Ky=138&CoreGrids_Ky=107">Trattative</a></li>
        <li><a href="/admin/app/commerciale/elenco-opportunita-prospetto.aspx">Prospetto trattative</a></li>
    		<% } %>
  			<% if (dtLogin.Rows[0]["UtentiGruppi_Preventivi"].Equals(true)){ %>
        	<li><a href="/admin/view.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreGrids_Ky=274&DocumentiTipo_Ky=4">Preventivi</a></li>
    		<% } %>
  			<% if (dtLogin.Rows[0]["UtentiGruppi_PreventiviAuto"].Equals(true)){ %>
        	<li><a href="/admin/view.aspx?CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270">Preventivi auto</a></li>
    		<% } %>
        <li><a href="/admin/app/attivita/attivita-da-fare.aspx?AttivitaSettore_Ky=2&attivita-scadute=1&prossime-scadenze=1&scadenze-future=1">Prospetto attivit&agrave;</a></li>
        <% if (dtLogin.Rows[0]["UtentiGruppi_Rapporti"].Equals(true)){ %>
        <li><a href="#Rapporticommerciale" title="Rapporticommerciale">Rapporti</a>
            <ul class="submenu menu vertical" data-submenu>
              <li><a href="/admin/app/commerciale/prospetto-lead-veicolimarca.aspx">Per marca</a></li>
              <li><a href="/admin/app/commerciale/prospetto-lead-veicolimodello.aspx">Per modello</a></li>
              <li><a href="/admin/app/commerciale/prospetto-lead-utm_source.aspx">Per utm source</a></li>
              <li><a href="/admin/app/commerciale/prospetto-lead-utm_medium.aspx">Per utm medium</a></li>
              <li><a href="/admin/app/commerciale/prospetto-lead-campagna.aspx">Per utm campaign</a></li>
              <li><a href="/admin/app/commerciale/prospetto-lead-lead-orario.aspx">Per orario arrivo lead</a></li>
              <li><a href="/admin/app/commerciale/prospetto-lead-leadcategorie.aspx">Per categoria lead</a></li>
              <li><a href="/admin/app/commerciale/prospetto-lead-leadsorgenti.aspx">Per sorgente lead</a></li>
            </ul>
        </li>
        <% } %>
    </ul>
  </li>
  <% } %>
  
  <% if (dtLogin.Rows[0]["UtentiGruppi_Vendite"].Equals(true)){ %>
  <li class="has-submenu"><a href="#" title="Vendite">Vendite</a>
    <ul class="submenu menu vertical" data-submenu>
			<% if (dtLogin.Rows[0]["UtentiGruppi_Fatture"].Equals(true) && dtLogin.Rows[0]["UtentiGruppi_Notedicredito"].Equals(true)){ %>
        <li><a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=1,2,5,7">Fatture e Note di credito</a></li>
  		<% } %>
			<% if (dtLogin.Rows[0]["UtentiGruppi_Fatture"].Equals(true)){ %>
        <li><a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=1">Fatture</a></li>
        <li><a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=7">Fatture Pro Forma</a></li>
  		<% } %>
			<% if (dtLogin.Rows[0]["UtentiGruppi_Notedicredito"].Equals(true)){ %>
        <li><a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=2">Note di Credito</a></li>
  		<% } %>
			<% if (dtLogin.Rows[0]["UtentiGruppi_Fatture"].Equals(true)){ %>
        <li><a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=5">Autofatture</a></li>
  		<% } %>
			<% if (dtLogin.Rows[0]["UtentiGruppi_Ordini"].Equals(true)){ %>
      	<li><a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=3">Ordini</a></li>
      	<li><a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=8">Spedizioni</a></li>
      	<li><a href="/admin/app/documenti/elenco-documenti.aspx?DocumentiTipo_Ky=9">RMA</a></li>
  		<% } %>
    </ul>
  </li>
  <% } %>
  <% if (dtLogin.Rows[0]["UtentiGruppi_Produzione"].Equals(true)){ %>
  <li class="has-submenu"><a href="#" title="Produzione">Produzione</a>
    <ul class="submenu menu vertical" data-submenu>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Progetti"].Equals(true)){ %>
        <li><a href="/admin/app/progetti/elenco-commesse.aspx?CommesseStato_Ky=4&CoreModules_Ky=24&CoreEntities_Ky=107&CoreGrids_Ky=118&custom=1"><i class="fa-duotone fa-building fa-fw"></i>Progetti e Contratti</a></li>
  		<% } %>
      <% if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){ %>
        <li><a href="/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1"><i class="fa-duotone fa-calendar-days fa-fw"></i>Prospetto per scadenza</a></li>
        <li><a href="/admin/app/attivita/attivita-da-fare-stato.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per stato</a></li>
        <li><a href="/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62"><i class="fa-duotone fa-calendar-days fa-fw"></i>Tutte le attivit&agrave;</a></li>
  		<% } %>

  		<% if (dtLogin.Rows[0]["UtentiGruppi_SitiWeb"].Equals(true)){ %>
      	<li><a href="/admin/view.aspx?CoreModules_Ky=27&CoreEntities_Ky=142&CoreGrids_Ky=126"><i class="fa-duotone fa-globe fa-fw"></i>Siti Web</a></li>
        <% } %>
      <li><a href="/admin/view.aspx?CoreModules_Ky=30&CoreEntities_Ky=166&CoreGrids_Ky=153"><i class="fa-duotone fa-key fa-fw"></i>Password Manager</a></li>
      <li><a href="/admin/RandomPassword.aspx"><i class="fa-duotone fa-key fa-fw"></i>Genera password</a></li>
    </ul>
  </li>
  <% } %>  
  <% if (dtLogin.Rows[0]["UtentiGruppi_Assistenza"].Equals(true)){ %>
  <li class="has-submenu"><a href="#" title="Assistenza">Assistenza</a>
    <ul class="submenu menu vertical" data-submenu>
        <% if (dtLogin.Rows[0]["UtentiGruppi_Knowledgebase"].Equals(true)){ %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=32&CoreEntities_Ky=237&CoreGrids_Ky=252"><i class="fa-duotone fa-circle-question fa-fw"></i>Knowledge base</a></li>
        <% } %>  
        <% if (dtLogin.Rows[0]["UtentiGruppi_Ticket"].Equals(true)){ %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=32&CoreEntities_Ky=221&CoreGrids_Ky=231"><i class="fa-duotone fa-ticket-simple fa-fw"></i>Ticket</a></li>
        <% } %>  
        <% if (dtLogin.Rows[0]["UtentiGruppi_Officina"].Equals(true)){ %>
        <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=244"><i class="fa-duotone fa-screwdriver-wrench fa-fw"></i>Officina (accettazione)</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=247"><i class="fa-duotone fa-screwdriver-wrench fa-fw"></i>Officina (preparatore)</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=264"><i class="fa-duotone fa-screwdriver-wrench fa-fw"></i>Service Officina</a></li>
        <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=263"><i class="fa-duotone fa-screwdriver-wrench fa-fw"></i>Archivio Officina</a></li>
        <li><a href="/admin/app/officina/calendario.aspx"><i class="fa-duotone fa-calendar-days fa-fw"></i>Planning officina</a></li>
        <% } %>  
    </ul>
  </li>
  <% } %>  
</ul>
