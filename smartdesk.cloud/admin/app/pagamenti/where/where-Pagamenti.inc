<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="21" />
<input type="hidden" name="CoreEntities_Ky" value="75" />
<input type="hidden" name="CoreGrids_Ky" value="110" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Pagamenti_Ky" id="Pagamenti_Ky" class="input-group-field" placeholder="ricerca per id">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Anagrafiche_Ky" class="large-text-right small-text-left middle">Anagrafica</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<div class="grid-x grid-padding-x">
<div class="shrink cell hide-for-small-only"><input type="text" name="Anagrafiche_Ky" id="Anagrafiche_Ky" placeholder="Anagrafica"></div>
<div class="auto cell"><input type="text" name="Anagrafiche_RagioneSociale" id="Anagrafiche_RagioneSociale" placeholder="Anagrafica"></div>
<script type="text/javascript">
		jQuery("#Anagrafiche_RagioneSociale").autocomplete({
			source: "/admin/app/pagamenti/autosuggest-GetAnagrafiche-json.aspx",
			minLength: 2,
			select: function( event, ui ) {
				jQuery("#Anagrafiche_Ky").val(ui.item.value);
				jQuery("#Anagrafiche_RagioneSociale").val(ui.item.label);
				return false;
			}
		});
</script>
</div>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Commesse_Ky" class="large-text-right small-text-left middle">Progetto</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Commesse_Ky" id="Pagamenti_Ky" placeholder="Progetto">
<option></option>
<option value="4195">
[ANNULLATA] E-commerce Magento, mantenimento dominio e posta elettronica, motori di ricerca (SEO)</option>
<option value="4182">
[SOSPESA] Progetto web Ecommerce per Ventifive</option>
<option value="10532">
10 ore</option>
<option value="10533">
20 ore ottobre 2018</option>
<option value="4154">
2siti+hosting</option>
<option value="40">
3 minisiti</option>
<option value="10554">
a consuntivo</option>
<option value="10458">
a consuntivo (fatt 151/2013)</option>
<option value="5248">
Adv Company srl</option>
<option value="41">
adwords</option>
<option value="45">
adwords+natale</option>
<option value="73">
Aggiornamento catalogo sito</option>
<option value="10397">
Aggiornamento sito</option>
<option value="60">
aggiornamento sito + nonsolochef</option>
<option value="10367">
Amazon m2epro</option>
<option value="4188">
Amministrazione RSW Studio</option>
<option value="2146">
Analisi usabilità, Analisi SEO, campagna adwords test</option>
<option value="101">
annuncicamion</option>
<option value="10404">
area job</option>
<option value="83">
area riservata biscopan</option>
<option value="23">
arredomobilionline</option>
<option value="10465">
assistenza a ore</option>
<option value="10524">
assistenza tecnica</option>
<option value="2144">
attivita 2014 - 2015</option>
<option value="10349">
attività 2019</option>
<option value="10386">
attività annuali + facebook ads</option>
<option value="10391">
attività marketing 2020</option>
<option value="2143">
Attività RSW Studio</option>
<option value="10571">
biscopan</option>
<option value="74">
Blog banca Ifili</option>
<option value="84">
blog+interventi</option>
<option value="10455">
bollicinemodellismo</option>
<option value="10379">
Brochure</option>
<option value="10380">
campagna</option>
<option value="10326">
Campagna ads</option>
<option value="9313">
Campagna Fb Ads e Campagna Google Adwords </option>
<option value="10371">
Campagna google ads</option>
<option value="8296">
Campagna sponsorizzazione Youtube </option>
<option value="107">
captcha + foto</option>
<option value="4">
Catalogo agricoltura - integrazione opere industriali</option>
<option value="71">
centro benessere seta</option>
<option value="4248">
Ceramic Pro Italy - Landing Page, ADV, Facebook 6 mesi</option>
<option value="4187">
Commerciale RSW Studio</option>
<option value="114">
Completamento ecommerce</option>
<option value="4193">
Concorso Succovivo Imetec</option>
<option value="10383">
Consulente amazon </option>
<option value="10457">
consuntivo</option>
<option value="10447">
Consuntivo Biscopan</option>
<option value="10449">
Consuntivo ore</option>
<option value="10460">
consuntivo ore</option>
<option value="10481">
Contratto (chiuso)</option>
<option value="10469">
Contratto 10 ore</option>
<option value="10508">
Contratto 10 ore</option>
<option value="10516">
Contratto 10 ore</option>
<option value="10504">
Contratto 10 ore</option>
<option value="10505">
Contratto 10 ore</option>
<option value="10579">
contratto 10 ore</option>
<option value="10557">
Contratto 10 ore</option>
<option value="127">
Contratto 10 ore - Assistenza tecnica</option>
<option value="10487">
Contratto 10 ore assistenza Sito Web </option>
<option value="10470">
Contratto 10 ore assistenza Web</option>
<option value="10509">
Contratto 10 ore ottobre 2017</option>
<option value="10454">
Contratto 10 ore web</option>
<option value="10510">
contratto 14-11-2017</option>
<option value="10520">
contratto 150 ore</option>
<option value="10466">
Contratto 20 ore</option>
<option value="10561">
Contratto 20 ore</option>
<option value="10462">
Contratto 20 ore - Assistenza tecnica sito</option>
<option value="10474">
Contratto 20 ore assistenza Sito Web </option>
<option value="10472">
Contratto 20 ore assistenza web</option>
<option value="10473">
Contratto 20 ore assistenza web</option>
<option value="10434">
Contratto 2011- 20+4</option>
<option value="10478">
Contratto 2016 20 ore</option>
<option value="10495">
Contratto 2017 -  30 ore</option>
<option value="10538">
Contratto 23 ore voucher</option>
<option value="10558">
contratto 30 ore</option>
<option value="10475">
Contratto 40 ore</option>
<option value="10471">
Contratto 40 ore</option>
<option value="10488">
Contratto 5 ore </option>
<option value="10476">
Contratto 50 ore</option>
<option value="10500">
contratto 50 ore</option>
<option value="10572">
Contratto 60 ore</option>
<option value="10450">
Contratto a consuntivo It4You</option>
<option value="10452">
Contratto a ore</option>
<option value="10453">
Contratto a ore</option>
<option value="10496">
Contratto a ore</option>
<option value="10497">
Contratto a ore</option>
<option value="10498">
Contratto a ore</option>
<option value="10491">
Contratto a ore</option>
<option value="10492">
Contratto a ore</option>
<option value="10493">
Contratto a ore</option>
<option value="10494">
Contratto a ore</option>
<option value="10489">
Contratto a ore</option>
<option value="10477">
Contratto a ore (5 ore)</option>
<option value="10479">
Contratto a ore (consuntivo)</option>
<option value="10485">
Contratto a ore (consuntivo) Luglio 2016</option>
<option value="10468">
Contratto a ore 09-01-2015fattura a 20 ore</option>
<option value="10480">
Contratto a ore 20 ore</option>
<option value="10563">
Contratto ad ore</option>
<option value="10502">
Contratto ad ore 10 ore</option>
<option value="10547">
Contratto ad ore consuntivo anno 2020</option>
<option value="10565">
Contratto ad ore consuntivo anno 2021</option>
<option value="10484">
Contratto ad ore magento</option>
<option value="10536">
Contratto assistenza 20 ore </option>
<option value="10482">
Contratto assistenza a ore (5 ore)</option>
<option value="10499">
Contratto assistenza a ore 10 ore</option>
<option value="10511">
Contratto assistenza ad ore (10 ore + 2 ore in omaggio)</option>
<option value="10517">
Contratto assistenza ad ore (10 ore)</option>
<option value="10518">
Contratto assistenza ad ore (10 ore)</option>
<option value="10522">
Contratto assistenza ad ore (10 ore)</option>
<option value="10537">
Contratto assistenza ad ore (10 ore)</option>
<option value="10543">
Contratto assistenza ad ore (10 ore)</option>
<option value="10544">
Contratto assistenza ad ore (10 ore)</option>
<option value="10555">
Contratto assistenza ad ore (10 ore)</option>
<option value="10552">
Contratto assistenza ad ore (10 ore)</option>
<option value="10570">
Contratto assistenza ad ore (10 ore)</option>
<option value="10577">
Contratto assistenza ad ore (10 ore)</option>
<option value="10523">
Contratto assistenza ad ore (10 ore) sito web</option>
<option value="10542">
Contratto assistenza ad ore (100 ore) Magento Commerce</option>
<option value="10526">
Contratto assistenza ad ore (12 ore)</option>
<option value="10514">
Contratto assistenza ad ore (20 ore + 3 ore omaggio)</option>
<option value="10512">
Contratto assistenza ad ore (20 ore)</option>
<option value="10534">
Contratto assistenza ad ore (20 ore)</option>
<option value="10539">
Contratto assistenza ad ore (20 ore)</option>
<option value="10540">
Contratto assistenza ad ore (20 ore)</option>
<option value="10541">
Contratto assistenza ad ore (20 ore)</option>
<option value="10562">
Contratto assistenza ad ore (20 ore)</option>
<option value="10560">
Contratto assistenza ad ore (20 ore)</option>
<option value="10432">
Contratto assistenza ad ore (20 ore)</option>
<option value="10525">
Contratto assistenza ad ore (30 ore)</option>
<option value="10483">
Contratto assistenza ad ore (40 ore)</option>
<option value="10576">
Contratto assistenza ad ore (40 ore)</option>
<option value="10531">
Contratto assistenza ad ore (40 ore)</option>
<option value="10529">
Contratto assistenza ad ore (40 ore)</option>
<option value="10550">
Contratto assistenza ad ore (tot. 10 ore)</option>
<option value="10549">
Contratto assistenza ad ore (tot. 20 ore)</option>
<option value="10515">
Contratto assistenza ad ore (tot. 40 ore)</option>
<option value="10507">
Contratto assistenza ad ore 10 ore</option>
<option value="10501">
Contratto assistenza ad ore 10 ore</option>
<option value="10513">
Contratto assistenza ad ore Magento (10 ore)</option>
<option value="10521">
Contratto assistenza ad ore Magento (tot. 40 ore)</option>
<option value="10506">
Contratto assistenza ad ore Magento Commerce 10 ore</option>
<option value="10503">
Contratto assistenza Magento 10 ore</option>
<option value="10486">
Contratto assistenza sito web 10 ore</option>
<option value="10467">
Contratto assistenza sito web 10 ore</option>
<option value="10463">
Contratto assistenza sito web 40 ore</option>
<option value="10535">
Contratto assistenza tecnica Wordpress 10 ore</option>
<option value="10464">
Contratto dal 3 aprile 2014</option>
<option value="10459">
contratto dal 31-05-2013</option>
<option value="10461">
contratto del 10-05-2013</option>
<option value="10546">
Contratto di assistenza ad ore (totale 10 ore)</option>
<option value="10548">
Contratto di assistenza ad ore (totale 10 ore)</option>
<option value="10556">
Contratto di assistenza ad ore (totale 10 ore)</option>
<option value="10566">
Contratto di assistenza ad ore (totale 10 ore)</option>
<option value="10564">
Contratto di assistenza ad ore (totale 20 ore)</option>
<option value="10578">
Contratto di assistenza ad ore (totale 20 ore)</option>
<option value="10553">
Contratto di assistenza ad ore (totale 20 ore)</option>
<option value="10559">
Contratto di assistenza ad ore (totale 20 ore)</option>
<option value="10519">
Contratto flat fino 28-02-2019</option>
<option value="10569">
Contratto flat fino 28-02-2020</option>
<option value="10568">
Contratto flat fino 28-02-2022</option>
<option value="10490">
contratto novembre 2016</option>
<option value="10448">
Contratto Ore</option>
<option value="10451">
Contratto ore</option>
<option value="10435">
Contratto Ore</option>
<option value="10436">
Contratto Ore</option>
<option value="10437">
Contratto Ore</option>
<option value="10438">
Contratto Ore</option>
<option value="10439">
Contratto Ore</option>
<option value="10440">
Contratto Ore</option>
<option value="10441">
Contratto Ore</option>
<option value="10442">
Contratto Ore</option>
<option value="10443">
Contratto Ore</option>
<option value="10444">
Contratto Ore</option>
<option value="10445">
Contratto Ore</option>
<option value="10446">
Contratto Ore 2012</option>
<option value="10456">
Contratto Ore 2013</option>
<option value="10530">
Contratto ore consuntivo</option>
<option value="87">
conversine sito in wp</option>
<option value="8297">
Creazione e messa on line Landing Page </option>
<option value="7288">
Creazione Landing Page </option>
<option value="4208">
Creazione landing page lingua italiana</option>
<option value="1133">
Creazione nuovo sito, motori di ricerca italiano ed estero, social pack 3 mesi</option>
<option value="4240">
Creazione pagina "Lavora con noi" e Form raccolta CV sito mediabarter.it</option>
<option value="1143">
Creazione sito web University&Research, 3 bozze grafiche</option>
<option value="4235">
Creazione versione russa sito Ruthinium</option>
<option value="2147">
CRM Agenti, Manutenzione annuale e Contratto assistenza 10 ore </option>
<option value="4173">
Dalve sito responsive</option>
<option value="5264">
dominio asteannuncionline.it</option>
<option value="5263">
dominio zeggio rottami</option>
<option value="10424">
Drinkfood delivery</option>
<option value="70">
ecommerce</option>
<option value="62">
ecommerce + motori base</option>
<option value="7286">
Ecommerce B2B e Seo B2C</option>
<option value="25">
e-commerce congedo editore</option>
<option value="58">
ecommerce corsi-ecm.net</option>
<option value="52">
ecommerce magento</option>
<option value="5257">
ecommerce magento</option>
<option value="8302">
Ecommerce Magento 1, SEO onsite startup, hosting</option>
<option value="5254">
ecommerce magento 3 lingue</option>
<option value="4153">
ecommerce, hosting, seo, social</option>
<option value="35">
ecommerce+motori</option>
<option value="10392">
estensione + nuovo server</option>
<option value="1129">
Estensione modulo per pagamento online prodotto 4banking</option>
<option value="4166">
etichette gelatine e vino</option>
<option value="10429">
Feed kelkoo</option>
<option value="79">
fiori & fiori</option>
<option value="1136">
formazione erickson</option>
<option value="56">
formazione magento seo</option>
<option value="4228">
Gadget software elettronico Top 70</option>
<option value="4171">
gestional social pizzeria da ketty e pizzeria da davide</option>
<option value="10343">
Gestione social</option>
<option value="17">
Habita</option>
<option value="5261">
hosting</option>
<option value="10390">
hosting +landing</option>
<option value="10415">
iennezeta ecommerce mobzilla</option>
<option value="10411">
Il faro</option>
<option value="20">
ilfaro:sito+motori</option>
<option value="59">
imbustamento figurine</option>
<option value="8306">
Impaginazione sito lingua francese e tedesca</option>
<option value="7285">
Impaginazione Sito lingua inglese e spagnolo</option>
<option value="8298">
Integrazioni sito www.astebusiness.it</option>
<option value="1128">
Interfaccia grafica per SOFIA - UI e EX</option>
<option value="8307">
Interventi attuale sito web</option>
<option value="5249">
Interventi migliorativi ecommerce</option>
<option value="5276">
Interventi sito, sistemaz.scheda prodotto, clear line, applicativo interno</option>
<option value="5262">
iocollezionista.com</option>
<option value="10433">
Istituto nastro azzurro</option>
<option value="91">
landing + web marketing</option>
<option value="5267">
landing facebook ads banner</option>
<option value="8300">
Landing Page Adwords, Web Marketing, mantenim.domini e posta, certif.ssl, assistenza Wordpress</option>
<option value="1131">
Landing page per newsletter biodermol</option>
<option value="1134">
landing page porte aperte + campagna ppc google</option>
<option value="5256">
landing page promo ruthinium</option>
<option value="5275">
Landing Page, creatività grafica, logo web, immagini</option>
<option value="4211">
Landing Page, Dominio e email</option>
<option value="6279">
Landing Page, Setup campagne adwords, gestione campagne adwords, 3 newsletter</option>
<option value="43">
landing+adwords</option>
<option value="5269">
landing-adwords-banner</option>
<option value="10353">
Logo deep desk</option>
<option value="77">
lucidinatale responsive</option>
<option value="126">
Magento, grafiche e SEO </option>
<option value="4181">
Magento,B2B hosting, SEO, Social</option>
<option value="92">
magento+marketing</option>
<option value="10395">
Maritan Verona</option>
<option value="13">
marketing mix</option>
<option value="3148">
mediabarter.it</option>
<option value="76">
Migrazione joomla wp</option>
<option value="102">
Minisito hyundai.spaziogroup.com</option>
<option value="10412">
Mobili Bombati</option>
<option value="10346">
modifiche</option>
<option value="10573">
modifiche al sito</option>
<option value="10574">
Modifiche come da email del 30/12</option>
<option value="10551">
modifiche spese + mobile</option>
<option value="4178">
modulo prenotazione-preventivo</option>
<option value="106">
Motori di ricerca - Posizionamento motori di ricerca</option>
<option value="1141">
Motori di ricerca PRO, Social Pack 3 mesi e article marketing con blog</option>
<option value="12">
motori ricerca</option>
<option value="4234">
Motori ricerca ita e ted., gestione newsletter, server dedicato, dominio, soft restyling sito</option>
<option value="4241">
Motori ricerca SEO Italiano (6 mesi)</option>
<option value="4210">
Motori ricerca SEO Upgrade (passaggio da versione base a versione pro)</option>
<option value="18">
motori trattamento superfici</option>
<option value="7">
motori+adwords+cs</option>
<option value="36">
newsletter luglio 2012</option>
<option value="68">
newsletter mailchimp alajmo</option>
<option value="10567">
Nuove modifiche</option>
<option value="4176">
Nuovi layout responsive</option>
<option value="28">
nuovo dominio, area riservata, contratto ore</option>
<option value="53">
Nuovo ecommerce</option>
<option value="125">
Nuovo ecommerce Perfetta</option>
<option value="6281">
Nuovo layout alvicalzature.it, gestione facebook, ottimizzazione Seo, hosting e posta</option>
<option value="6283">
Nuovo layout shop.roces, sistemaz.tema roces.com, ottimizzaz.seo, hosting e posta, certificato ssl d</option>
<option value="4160">
nuovo sito</option>
<option value="2142">
nuovo sito</option>
<option value="94">
nuovo sito</option>
<option value="97">
nuovo sito</option>
<option value="86">
nuovo sito</option>
<option value="38">
nuovo sito</option>
<option value="66">
nuovo sito - minisiti - webmarketing</option>
<option value="1">
Nuovo sito + motori</option>
<option value="2140">
nuovo sito + seo</option>
<option value="4150">
nuovo sito ecommerce, formazione ecommerce e seo</option>
<option value="49">
Nuovo sito internet</option>
<option value="105">
nuovo sito responsive</option>
<option value="6284">
nuovo sito responsive</option>
<option value="116">
Nuovo sito responsive design in 4 lingue e attività seo - web marketing</option>
<option value="4175">
nuovo sito responsive in quattro lingue con traduzioni professionali</option>
<option value="10400">
nuovo sito web</option>
<option value="10396">
Nuovo sito web</option>
<option value="1142">
Nuovo sito web 4 lingue - Motori 4 lingue - SMS</option>
<option value="4149">
Nuovo sito web Responsive design</option>
<option value="1135">
Nuovo sito web responsive, hosting e motori ricerca base</option>
<option value="1140">
Nuovo sito web responsive, web marketing e social network</option>
<option value="9307">
Nuovo sito web, modulo take away, trasferim.dominio ed email</option>
<option value="4159">
Nuovo sito web, motori ricerca base e hosting</option>
<option value="1144">
Nuovo tema responsive design con template WP ready</option>
<option value="10545">
ore</option>
<option value="10527">
Ore a consuntivo</option>
<option value="22">
outletmobilidesign.com</option>
<option value="10351">
pigozzolegno.it - 024-019 del 22/03/2019</option>
<option value="5258">
portale annunci ed aste</option>
<option value="5265">
portale aste</option>
<option value="4245">
Posizionamento SEO  locale, hosting e mantenimento dominio  torneriapolesanascale.it, posta elettr.</option>
<option value="95">
potenziamento motori cani</option>
<option value="54">
potenziamento seo</option>
<option value="4165">
potenziamento seo con rafforzamento parole chiave</option>
<option value="1137">
Potenziamento Web Marketing</option>
<option value="4148">
Potenziamento Web Marketing - server dedicato - sito tedesco e varie</option>
<option value="10387">
privacy sito</option>
<option value="10359">
progetto 2019-2020</option>
<option value="2145">
Progetto E-Learning basato su Moodle</option>
<option value="122">
Progetto Hymach 019-014-rev2 come da conferma del 08/04/2014</option>
<option value="10575">
Progetto n. 057-020 del 03/02/2021</option>
<option value="10405">
Progetto per residenziale e vendita immobili </option>
<option value="6278">
Progetto sviluppo nuova immagine sul web</option>
<option value="10331">
Progetto We n. 003-019 del 11/01/19</option>
<option value="10375">
Progetto Web 012T-019 del 03/10/2019</option>
<option value="5272">
progetto web 2017</option>
<option value="4170">
Progetto Web e Digital Marketing 2015</option>
<option value="4232">
Progetto Web e Digital Marketing 2016</option>
<option value="9315">
Progetto web email del 13/04/2018</option>
<option value="10365">
Progetto Web email del 17/05/2019</option>
<option value="10322">
Progetto Web email del 26/09/2018</option>
<option value="4242">
Progetto Web incremento link populary</option>
<option value="4216">
Progetto Web Marketing </option>
<option value="8303">
Progetto Web Mockup grafico+ux e tool analisi,SEO,campagne adwords,</option>
<option value="10355">
Progetto Web n. 001-019 del 08/01/2019</option>
<option value="10377">
Progetto Web n. 001-020 del 20/01/2020</option>
<option value="10421">
Progetto Web n. 001-021 rev 2 del 19/02/2021</option>
<option value="10332">
Progetto Web n. 002-019 del 16/01/19</option>
<option value="10417">
Progetto Web n. 002-021 del 11/01/2021</option>
<option value="10333">
Progetto Web n. 002-19 del 08/01/2019</option>
<option value="10336">
Progetto Web n. 002T-019 del 24/01/2019</option>
<option value="10418">
Progetto Web n. 003-021 del 12/01/2021</option>
<option value="9312">
Progetto Web n. 003T-018 del 26/04/2018</option>
<option value="10337">
Progetto Web n. 003T-019 del 28/01/2019</option>
<option value="10419">
Progetto Web n. 003T-021 del 03/02/2021</option>
<option value="10425">
Progetto Web n. 004T-021-rev2</option>
<option value="9317">
Progetto Web n. 005T-018 del 25/06/2018</option>
<option value="10381">
Progetto Web n. 006-020 del 29/01/2020</option>
<option value="10382">
Progetto Web n. 006T-020 del 24/02/2020</option>
<option value="10384">
Progetto Web n. 007-020 del 20/02/2020</option>
<option value="10416">
Progetto Web n. 007-021 del 21/01/2021</option>
<option value="9318">
Progetto Web n. 007T-018 del 10/07/2018</option>
<option value="10431">
Progetto Web n. 007T-021 del 02/08/2021</option>
<option value="10334">
Progetto Web n. 008-19 del 22/01/19</option>
<option value="10420">
Progetto Web n. 009-021 del 08/02/2021</option>
<option value="9306">
Progetto Web n. 010-018 del 02/02/2018 Modulo Magento Ad-hoc per eliminazione ordini (+contratto ass</option>
<option value="10335">
Progetto Web n. 010-019 del 28/01/2019</option>
<option value="6282">
Progetto Web n. 011-017 del 28.02.2017</option>
<option value="10362">
Progetto Web n. 011-019 rev 2 del 21/03/2019</option>
<option value="10373">
Progetto Web n. 011-019T rev 2 del 14/10/2019</option>
<option value="10394">
Progetto Web n. 011-020 rev 2 del 11/06/2020</option>
<option value="10376">
Progetto Web n. 011-19 rev 3 del 31/10/2019</option>
<option value="10423">
Progetto Web n. 012T-rev2-020 del 24/03/2021</option>
<option value="10422">
Progetto Web n. 013-021 del 22/02/2021</option>
<option value="10320">
Progetto Web n. 013T-018 del 11/09/2018</option>
<option value="10340">
Progetto Web n. 015-19 rev 2 del 06/03/2019</option>
<option value="9309">
Progetto Web n. 016-018 del 15/03/2018</option>
<option value="10406">
Progetto Web n. 016T-020 del 29/10/2020</option>
<option value="10426">
Progetto Web n. 017-021 rev 3 del 25/03/2021</option>
<option value="9308">
Progetto Web n. 017-18 del 20/03/2018</option>
<option value="9310">
Progetto Web n. 019-018 del 28/03/2018</option>
<option value="10363">
Progetto Web n. 019-019 rev 3 del 10/04/2019</option>
<option value="10414">
Progetto Web n. 019T-020 rev3 del 20/01/2021</option>
<option value="10407">
Progetto Web n. 022T-020 del 2/12/2020</option>
<option value="9311">
Progetto Web n. 023-018 del 04/05/2018</option>
<option value="10388">
Progetto Web n. 024-020 del 21/03/2020</option>
<option value="10330">
Progetto Web n. 025T-018 rev2 del 11/12/18</option>
<option value="9319">
Progetto Web n. 027-018 del 19/07/2018</option>
<option value="10364">
Progetto Web n. 027-019 del 17/04/2019</option>
<option value="10360">
Progetto Web n. 027T-018 rev 2 del 19/03/19</option>
<option value="7289">
Progetto Web n. 030-017 rev 2 del 30/08/2017</option>
<option value="10361">
Progetto Web n. 030-019 del 06/05/2019</option>
<option value="10366">
Progetto Web n. 032-019 del 09/05/2019</option>
<option value="10319">
Progetto Web n. 033-018 del 27/07/2018</option>
<option value="10372">
Progetto Web n. 039-019 rev 2 del 28/08/2019</option>
<option value="10327">
Progetto Web n. 041-018 del 05/09/2018</option>
<option value="10368">
Progetto Web n. 041-019 del 22/08/2019</option>
<option value="10321">
Progetto Web n. 042-018 del 19/09/2018</option>
<option value="10370">
Progetto Web n. 043-019 del 13/09/2019</option>
<option value="10329">
Progetto Web n. 045-019 del 21/11/2018</option>
<option value="10374">
Progetto Web n. 047-019 del 06/11/2019</option>
<option value="10323">
Progetto Web n. 048-018 del 10/10/2018</option>
<option value="10528">
Progetto Web n. 049-018  del 10/10/2018</option>
<option value="10393">
Progetto Web n. 056-020 del 04/05/2020</option>
<option value="10401">
Progetto Web n. 061-020 del 25/05/2020</option>
<option value="10378">
Progetto Web n. 063-020 del 29/05/2020</option>
<option value="10398">
Progetto Web n. 065-020 rev 2 del 25/06/2020</option>
<option value="10410">
Progetto Web n. 069-020 del 08/07/2020</option>
<option value="10399">
Progetto Web n. 070-020 del 17/07/2020</option>
<option value="10402">
Progetto Web n. 072-020 del 22/07/2020</option>
<option value="10403">
Progetto Web n. 077-020 del 07/10/2020</option>
<option value="10409">
Progetto Web n. 077-020 rev 2 del 10/12/2020</option>
<option value="10408">
Progetto Web n. 084-020 rev 2 del 26/11/2020</option>
<option value="5250">
Progetto Web nuova grafica home page ecommerce Magento base e revisione menù header.</option>
<option value="7294">
Progetto Web nuova immagine sito, grafica personalizzata, impaginazione in 5 lingue</option>
<option value="5274">
Progetto Web per Progetto E</option>
<option value="4179">
Progetto web Roces - Rsw Studio 2015-2016</option>
<option value="6280">
Progetto Web sistemaz.sito, ecommerce, motori ricerca, nuovo dominio, gestionem pagina fb</option>
<option value="7295">
Progetto Web Social Media Marketing </option>
<option value="4190">
Realizz sito web, social pack basic e formazione, aggregatore contenuti social</option>
<option value="4222">
Realizz. e-commerce Magento, Motori di ricerca Geoloc. Milano, Dominio e posta elettr.</option>
<option value="4207">
Realizz. sito Web, manten. dominio e posta elettr., campagna comparatori prezzi (3 mesi)</option>
<option value="4226">
Realizz.sito Mediabarter inglese, dominio inglese, SEO base inglese, Brochure digit.</option>
<option value="5253">
Realizz.sito web ita e ing, Seo base ita, Seo base ing, Copywriting, reg.nuovo dominio</option>
<option value="4227">
Realizzaz. sito web ecommerce magento, sviluppo programmatore magento</option>
<option value="4191">
Realizzazione banner pubblicitari promoway.it e mediabarter.it e pagine pubblicitarie</option>
<option value="4199">
Realizzazione e progettazione grafica pubblicitaria su misura formato </option>
<option value="3146">
Realizzazione ecommerce</option>
<option value="4194">
Realizzazione e-commerce, mantenimento dominio e posta elettronica, motori di ricerca</option>
<option value="7291">
Realizzazione landing pag lavaggio cisterne industriale e posizionamento seo sito cisaf.net</option>
<option value="5278">
Realizzazione nuovo layout sito, inserim.nuovi video,sito in 3 lingue</option>
<option value="4239">
Realizzazione nuovo sito web moderno e grafica personalizzata italiano e logo da web</option>
<option value="4205">
Realizzazione nuovo sito web, dominio e posta elettronica, motori di ricerca base</option>
<option value="4243">
Realizzazione Progetto Web Quarto di pagina e Web banner donow.it</option>
<option value="10325">
Realizzazione sito</option>
<option value="8301">
Realizzazione sito + ecommerce, web marketing, campagne adwords e fb 4 lingue</option>
<option value="4168">
realizzazione sito multilingua con traduzioni per Francese-spagnolo-tedesco</option>
<option value="4147">
Realizzazione sito web e hosting</option>
<option value="8305">
Realizzazione sito web ITA, grafica personalizzata, formazione, registraz dominio ed email, seo stan</option>
<option value="4198">
Realizzazione Sito Web Monopage Marco Melega Investments+Sito lingua inglese+Logo Web</option>
<option value="4196">
Realizzazione sito Web, mantenimento dominio e posta elettronica</option>
<option value="4197">
Realizzazione sito Web, mantenimento dominio e posta elettronica, motori di ricerca</option>
<option value="4192">
Realizzazione sito web, minisito, motori base</option>
<option value="1139">
Realizzazione sito web, motori di ricerca, social pack e hosting</option>
<option value="4200">
Realizzazione versione spagnola sito SuccoVivo di Imetec</option>
<option value="10339">
Recupero ecommerce</option>
<option value="5266">
rental ice skate</option>
<option value="4184">
responsive</option>
<option value="111">
responsive+seo</option>
<option value="48">
restyling + cms</option>
<option value="6">
restyling + motori</option>
<option value="3">
restyling fly2bus</option>
<option value="10">
restyling home + callcenter</option>
<option value="5271">
restyling sito 2017</option>
<option value="4172">
Restyling sito pigozzoambiente.com in responsive design e formazione Mailchimp</option>
<option value="89">
Restyling sito web</option>
<option value="4224">
Restyling Sito Web e motori di ricerca base geolocalizzato</option>
<option value="4231">
Restyling Sito Web www.pigozzo.it tecnologia Responsive Design</option>
<option value="29">
restyling, solar clean</option>
<option value="10413">
revisione seo</option>
<option value="10389">
Riattivazione shop.maritan.it</option>
<option value="75">
ristoranet.it</option>
<option value="8295">
Rivisitazione Sito Web - grafica home e pagine interne</option>
<option value="10347">
RSW Studio</option>
<option value="123">
seo</option>
<option value="93">
seo + adwords</option>
<option value="4186">
SEO annuale clienti RSW Studio</option>
<option value="1132">
seo arredomobilionline</option>
<option value="64">
seo avanzato</option>
<option value="67">
seo gruppo turmo travel ita+eng</option>
<option value="100">
seo sul sito con reviosione</option>
<option value="4158">
SEO+adwords</option>
<option value="115">
seo+social+responsive</option>
<option value="108">
server+seo+responsive</option>
<option value="3147">
shop</option>
<option value="4230">
Sistemaz.account Alibaba e Amazon, n.2 land.page,SEM,setup account adwords,formaz.</option>
<option value="9316">
sistemazione applicazione asp</option>
<option value="7292">
Sistemazione pagina scarpone Idea, attivazione gestione e monitoraggio 4 campagne adwords e fb</option>
<option value="10428">
Sistemazione php + aggiornamento sito</option>
<option value="10430">
Sistemazione sito</option>
<option value="10344">
sistemazione sito</option>
<option value="10356">
sistemazione sito</option>
<option value="10357">
Sistemazione sito</option>
<option value="10350">
Sistemazione sito</option>
<option value="9">
sistemazione sito + motori</option>
<option value="7290">
Sistemazione sito web</option>
<option value="7293">
Sistemazione Sito Web Mobile e Restyling</option>
<option value="55">
sistemazioni al sito</option>
<option value="10345">
sistemazioni sito</option>
<option value="10427">
sistemazioni sito</option>
<option value="10338">
Sistemazioni Sito, SEO, trasferimento</option>
<option value="44">
sito</option>
<option value="46">
sito</option>
<option value="11">
sito</option>
<option value="42">
sito</option>
<option value="5273">
sito</option>
<option value="5">
Sito + motori</option>
<option value="124">
Sito biscopan 2014</option>
<option value="8299">
Sito biscopan 2017</option>
<option value="21">
SITO e MOTORI</option>
<option value="5259">
sito in inglese con wpml</option>
<option value="5260">
sito italiano inglese</option>
<option value="72">
sito marketing arena</option>
<option value="47">
sito responsive</option>
<option value="4183">
sito responsive</option>
<option value="4169">
sito responsive + seo</option>
<option value="4163">
Sito responsive da Template per Stefano Boraso Fotografo</option>
<option value="10341">
sito responsive design</option>
<option value="4174">
sito responsive in due lignue, social network e potenziamento seo italiano/inglese</option>
<option value="1138">
Sito responsive, dominio, social pack e web marketing</option>
<option value="98">
sito russo, inglese</option>
<option value="26">
Sito web</option>
<option value="4161">
sito web</option>
<option value="27">
sito web + motori</option>
<option value="63">
sito web + seo</option>
<option value="8294">
sito web 2017 + seo base</option>
<option value="69">
sito web degrea</option>
<option value="4223">
Sito Web Ecommerce magento, sincronizz.dati dekaferr, dominio e posta, ottimizz.seo</option>
<option value="96">
sito web inglese su biosigma.com e Article Marketing</option>
<option value="4244">
Sito Web Ita, motori ricerca SEO Ita, studio fotografico mezza giornata</option>
<option value="4218">
Sito Web italiano e inglese, Motori di ricerca SEO base italiano e inglese</option>
<option value="4219">
Sito Web Italiano, posizionamento avanzato motori di ricerca ita, hosting</option>
<option value="5277">
Sito Web multilingua</option>
<option value="4209">
Sito Web responsive design</option>
<option value="128">
Sito web responsive design gestibile e startup seo</option>
<option value="121">
Sito web responsive, mini siti, motori e newsletter</option>
<option value="99">
sito web wordpress</option>
<option value="65">
sito web wordpress</option>
<option value="4151">
sito web, hosting, seo base</option>
<option value="4180">
sito wordpress con hosting</option>
<option value="10358">
sito, multilingua, seo, foto, hosting</option>
<option value="10352">
sito, seo, mybusiness, hosting</option>
<option value="10342">
sito, social, ads, blog</option>
<option value="4157">
sito+brochure promoway</option>
<option value="39">
sito+hosting+motori base</option>
<option value="34">
sito+motori</option>
<option value="8">
sito+motori</option>
<option value="14">
sito+motori</option>
<option value="15">
sito+motori</option>
<option value="80">
sito+motori+hosting+fotografo</option>
<option value="16">
sito+pec</option>
<option value="103">
sito+seo</option>
<option value="5270">
sito+seo</option>
<option value="85">
sito+seo+hosting</option>
<option value="37">
sito+social</option>
<option value="50">
social faro</option>
<option value="109">
social network</option>
<option value="4167">
Social network - Social pack 3 mesi </option>
<option value="4177">
Social Pack 12 mesi</option>
<option value="4212">
Social Pack 6 mesi</option>
<option value="4204">
Social Pack 6 mesi</option>
<option value="7284">
Social Pack Facebook + Instagram 12 mesi</option>
<option value="4246">
Spazio 4 - Cartest Landing Page/Infografica/3 Articoli</option>
<option value="81">
speed date</option>
<option value="1130">
Splash page di login GIADA - EPRO - SOFIA</option>
<option value="10328">
ssl su siti</option>
<option value="7287">
Sviluppo sito in lingua inglese</option>
<option value="113">
Sviluppo sito web responsive design in tre lingue</option>
<option value="4162">
sviluppo tema WP + plugin immobiliare</option>
<option value="4217">
Template Magento avanzato e setup account Google Analytics</option>
<option value="5247">
The Barter Company</option>
<option value="24">
toparredi.net</option>
<option value="5251">
Trasferim.url vecchio sito in WooCommerce a nuovo sito Magento Commerce</option>
<option value="4247">
Trasferimento e mantenimento domini</option>
<option value="82">
trasferimento frommomtodaughter.com</option>
<option value="10369">
trasferimento hosting</option>
<option value="61">
trasferimento rivamar.it</option>
<option value="57">
trasferimento sito</option>
<option value="4156">
Trasferimento sito, miglioramento sito e posizionamento motori ricerca</option>
<option value="104">
Trasformazione dell'attuale sito bngonfiabili.it in responsive design</option>
<option value="4164">
Trasformazione sito in Responsive Design</option>
<option value="5255">
trasformazione sito in responsive design</option>
<option value="5279">
Trofeo fotografico Ruthinium 2017</option>
<option value="5268">
ux adwords</option>
<option value="19">
vasche biogas</option>
<option value="10348">
Voucher</option>
<option value="4213">
Web Marketing 12 mesi, Performance interventi tecnici sito brianzaoutlet.com</option>
<option value="112">
Web marketing piano strategico</option>
<option value="2">
Web Marketing Plan </option>
<option value="4203">
webmarketing 2016</option>
<option value="51">
wp commerce</option>
<option value="88">
wp+hosting</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Conti_Ky" class="large-text-right small-text-left middle">Conto</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Conti_Ky" id="Pagamenti_Ky" placeholder="Conto">
<option></option>
<option value="1">
C/C Banca Annia</option>
<option value="2">
C/C TFM</option>
<option value="3">
Cassa</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Documenti_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<div class="grid-x grid-padding-x">
<div class="shrink cell hide-for-small-only"><input type="text" name="Documenti_Ky" id="Documenti_Ky" placeholder="id"></div>
<div class="auto cell"><input type="text" name="Documenti_Riferimenti" id="Documenti_Riferimenti" placeholder="id"></div>
<script type="text/javascript">
		jQuery("#Documenti_Riferimenti").autocomplete({
			source: "/admin/app/pagamenti/autosuggest-GetDocumenti-json.aspx",
			minLength: 2,
			select: function( event, ui ) {
				jQuery("#Documenti_Ky").val(ui.item.value);
				jQuery("#Documenti_Riferimenti").val(ui.item.label);
				return false;
			}
		});
</script>
</div>
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_Data" class="large-text-right small-text-left middle">Scadenza</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Pagamenti_Data" id="Pagamenti_Data" class="input-group-field" placeholder="ricerca per Scadenza">
</div>
</div>
<div class="grid-x grid-padding-x data">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_DataPagato" class="large-text-right small-text-left middle">Pagato il</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Pagamenti_DataPagato" id="Pagamenti_DataPagato" class="input-group-field" placeholder="ricerca per Pagato il">
</div>
</div>
<div class="grid-x grid-padding-x checkbox">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_Pagato" class="large-text-right small-text-left middle">Pagato</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="checkbox" name="Pagamenti_Pagato" id="Pagamenti_Pagato" class="input-group-field" placeholder="ricerca per Pagato" value="1">
</div>
</div>
<div class="grid-x grid-padding-x text">
<div class="large-2 medium-2 small-4 cell">
<label for="Pagamenti_Riferimenti" class="large-text-right small-text-left middle">Riferimenti</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Pagamenti_Riferimenti" id="Pagamenti_Riferimenti" class="input-group-field" placeholder="ricerca per Riferimenti">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="PagamentiMetodo_Ky" class="large-text-right small-text-left middle">Metodo pagamento</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="PagamentiMetodo_Ky" id="Pagamenti_Ky" placeholder="Metodo pagamento">
<option></option>
<option value="2">
Assegno</option>
<option value="1">
Bonifico</option>
<option value="4">
Carta di Credito</option>
<option value="3">
Contanti</option>
<option value="6">
Paypal</option>
<option value="7">
RID</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="PagamentiTipo_Ky" class="large-text-right small-text-left middle">Tipo pagamento</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="PagamentiTipo_Ky" id="Pagamenti_Ky" placeholder="Tipo pagamento">
<option></option>
<option value="1">
in entrata</option>
<option value="2">
In uscita</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x">
<div class="large-12 medium-12 small-12 text-center">
<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>
</div>
</div>
</form>
</fieldset>
