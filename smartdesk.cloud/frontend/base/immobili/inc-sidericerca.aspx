<div class="ricerca">
	<form name="formRicercaImmobili" id="formRicercaImmobili" method="get" action="/frontend/base/immobili/elenco-immobili.aspx" data-abide novalidate>
		<h5>Filtra Annunci Immobiliari</h5>
		<div data-abide-error class="alert callout" style="display: none;">
			<p><i class="fa-duotone fa-exclamation-triangle fa-fw"></i> Ci sono errori nel tuo modulo.</p>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-12 medium-12 small-12 cell">
				<select name="Province_Ky" id="Province_Ky" required="required"
					onchange="caricaComuni_Ky('Province_Ky','Comuni_Ky')">
					<option value="">Seleziona la provincia</option>
					<option value="">Seleziona la provincia</option>
					<option value="1">Agrigento</option>
					<option value="2">Alessandria</option>
					<option value="3">Ancona</option>
					<option value="4">Aosta</option>
					<option value="5">Ascoli Piceno</option>
					<option value="6">L'aquila</option>
					<option value="7">Arezzo</option>
					<option value="8">Asti</option>
					<option value="9">Avellino</option>
					<option value="10">Bari</option>
					<option value="11">Bergamo</option>
					<option value="12">Biella</option>
					<option value="13">Belluno</option>
					<option value="14">Benevento</option>
					<option value="15">Bologna</option>
					<option value="16">Brindisi</option>
					<option value="17">Brescia</option>
					<option value="18">Bolzano</option>
					<option value="19">Cagliari</option>
					<option value="20">Campobasso</option>
					<option value="21">Caserta</option>
					<option value="22">Chieti</option>
					<option value="23">Caltanissetta</option>
					<option value="24">Cuneo</option>
					<option value="25">Como</option>
					<option value="26">Cremona</option>
					<option value="27">Cosenza</option>
					<option value="28">Catania</option>
					<option value="29">Catanzaro</option>
					<option value="31">Enna</option>
					<option value="32">Ferrara</option>
					<option value="33">Foggia</option>
					<option value="34">Firenze</option>
					<option value="35">Forli-Cesena</option>
					<option value="36">Frosinone</option>
					<option value="37">Genova</option>
					<option value="38">Gorizia</option>
					<option value="39">Grosseto</option>
					<option value="40">Imperia</option>
					<option value="41">Isernia</option>
					<option value="42">Crotone</option>
					<option value="43">Lecco</option>
					<option value="44">Lecce</option>
					<option value="45">Livorno</option>
					<option value="46">Lodi</option>
					<option value="47">Latina</option>
					<option value="48">Lucca</option>
					<option value="49">Macerata</option>
					<option value="50">Messina</option>
					<option value="51">Milano</option>
					<option value="52">Mantova</option>
					<option value="53">Modena</option>
					<option value="54">Massa Carrara</option>
					<option value="55">Matera</option>
					<option value="56">Napoli</option>
					<option value="57">Novara</option>
					<option value="58">Nuoro</option>
					<option value="59">Oristano</option>
					<option value="60">Palermo</option>
					<option value="61">Piacenza</option>
					<option value="62">Padova</option>
					<option value="63">Pescara</option>
					<option value="64">Perugia</option>
					<option value="65">Pisa</option>
					<option value="66">Pordenone</option>
					<option value="67">Prato</option>
					<option value="68">Parma</option>
					<option value="69">Pesaro-Urbino</option>
					<option value="70">Pistoia</option>
					<option value="71">Pavia</option>
					<option value="72">Potenza</option>
					<option value="73">Ravenna</option>
					<option value="74">Reggio Calabria</option>
					<option value="75">Reggio Emilia</option>
					<option value="76">Ragusa</option>
					<option value="77">Rieti</option>
					<option value="78">Roma</option>
					<option value="79">Rimini</option>
					<option value="80">Rovigo</option>
					<option value="81">Salerno</option>
					<option value="82">Siena</option>
					<option value="83">Sondrio</option>
					<option value="84">La Spezia</option>
					<option value="85">Siracusa</option>
					<option value="86">Sassari</option>
					<option value="87">Savona</option>
					<option value="88">Taranto</option>
					<option value="89">Teramo</option>
					<option value="90">Trento</option>
					<option value="91">Torino</option>
					<option value="92">Trapani</option>
					<option value="93">Terni</option>
					<option value="94">Trieste</option>
					<option value="95">Treviso</option>
					<option value="96">Udine</option>
					<option value="97">Varese</option>
					<option value="98">Verbano-Cusio-Ossola</option>
					<option value="99">Vercelli</option>
					<option value="100">Venezia</option>
					<option value="101">Vicenza</option>
					<option value="102">Verona</option>
					<option value="103">Viterbo</option>
					<option value="104">Vibo Valentia</option>
					<option value="108">Monza Brianza</option>
					<option value="109">Estero</option>
					<option value="110">Carbonia-Iglesias</option>
					<option value="111">Medio Campidano</option>
					<option value="112">Olbia-Tempio</option>
					<option value="113">Fermo</option>
					<option value="114">Barletta-Andria-Trani</option>
					<option value="115">Ogliastra</option>
        </select>
				<script>
					selectSet('Province_Ky', '<%=Request["Province_Ky"]%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-12 medium-12 small-12 cell">
				<select name="Comuni_Ky" id="Comuni_Ky" onchange="caricaImmobiliZona_Ky('Comuni_Ky','ImmobiliZona_Ky')">
					<option value="">Seleziona un comune</option>
				</select>
				<script>
					caricaComuni_Ky('Province_Ky', 'Comuni_Ky');
					selectSet('Comuni_Ky', '<%=strComuni_Ky%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-3 medium-3 small-3 cell">
				<label>contratto</label>
			</div>
			<div class="large-9 medium-9 small-9 cell text-center">
				<input name="ImmobiliCategoria_Ky" id="ImmobiliCategoria_Ky1" type="radio" value="2"
					checked="checked" />
				<label>Vendita</label>
				<input name="ImmobiliCategoria_Ky" id="ImmobiliCategoria_Ky2" type="radio" value="1" />
				<label>Affitto</label>
				<script>
					radioSet('ImmobiliCategoria_Ky', '<%=Request["ImmobiliCategoria_Ky"]%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-3 medium-3 small-3 cell">
				<label>categoria</label>
			</div>
			<div class="large-9 medium-9 small-9 cell text-center">
				<select name="area" id="area" class="cboArea">
					<option value="">Categoria</option>
					<option value="1">Residenziali</option>
					<option value="2">Commerciali</option>
					<option value="3">Attivit&agrave;/aziende</option>
				</select>
				<script>
					selectSet('area', '<%=Request["area"]%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-6 medium-6 small-12 cell">
				<select name="bagni" id="bagni" class="cboCamereBagniAuto">
					<option value="">Bagni</option>
					<option value=">=1">1 bagno o pi&ugrave;</option>
					<option value=">=2">2 bagni o pi&ugrave;</option>
					<option value=">=3">3 bagni o pi&ugrave;</option>
					<option value=">=4">4 bagni o pi&ugrave;</option>
				</select>
				<script>
					selectSet('bagni', '<%=Request["bagni"]%>');
				</script>
			</div>
			<div class="large-6 medium-6 small-12 cell">
				<select name="mqmin" id="mqmin" class="cboMq">
					<option value="">m&sup2;</option>
					<option value=">=20">almeno 20m&sup2;</option>
					<option value=">=40">almeno 40m&sup2;</option>
					<option value=">=60">almeno 60m&sup2;</option>
					<option value=">=80">almeno 80m&sup2;</option>
					<option value=">=100">almeno 100m&sup2;</option>
					<option value=">=120">almeno 120m&sup2;</option>
					<option value=">=140">almeno 140m&sup2;</option>
					<option value=">=160">almeno 160m&sup2;</option>
				</select>
				<script>
					selectSet('mqmin', '<%=Request["mqmin"]%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-6 medium-6 small-12 cell">
				<select name="camere" id="camere" class="cboCamereBagniAuto">
					<option value="">Camere</option>
					<option value=">=1">1 camera o pi&ugrave;</option>
					<option value=">=2">2 camere o pi&ugrave;</option>
					<option value=">=3">3 camere o pi&ugrave;</option>
					<option value=">=4">4 camere o pi&ugrave;</option>
				</select>
				<script>
					selectSet('camere', '<%=Request["camere"]%>');
				</script>
			</div>
			<div class="large-6 medium-6 small-12 cell">
				<select name="prezzomax" id="prezzomax" class="cboPrezzo">
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
				<script>
					selectSet('prezzomax', '<%=Request["prezzomax"]%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-6 medium-6 small-12 cell">
				<input type="checkbox" name="incostruzione" id="incostruzione" />
				<label for="incostruzione">Nuovo</label>
				<script>
					checkSet('#incostruzione', <%=getChecked(Request["incostruzione"]) %>);
				</script>
			</div>
			<div class="large-6 medium-6 small-12 cell">
				<input type="checkbox" name="prestigio" id="prestigio" />
				<label for="prestigio">Prestigioso</label>
				<script>
					checkSet('#prestigio', <%=getChecked(Request["prestigio"]) %>);
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
				<div class="large-6 medium-6 small-12 cell">
				<input type="checkbox" name="turistico" id="turistico" />
				<label for="turistico">Turistico</label>
				<script>
					checkSet('#turistico', <%=getChecked(Request["turistico"]) %>);
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-12 medium-12 small-12 cell large-text-center small-text-center">
				<button class="button large success"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</button>
			</div>
		</div>
	</form>
</div>
<hr>