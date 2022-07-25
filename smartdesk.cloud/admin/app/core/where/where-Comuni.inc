<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
<legend>Cerca</legend>
<form id="formRicerca" class="formRicerca" method="get" action="/admin/view.aspx">
<input type="hidden" name="CoreModules_Ky" value="12" />
<input type="hidden" name="CoreEntities_Ky" value="8" />
<input type="hidden" name="CoreGrids_Ky" value="9" />
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="Comuni_Ky" class="large-text-right small-text-left middle">id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="Comuni_Ky" id="Comuni_Ky" class="input-group-field" placeholder="ricerca per id">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Comuni_CapoKy" class="large-text-right small-text-left middle">Comune padre</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<div class="grid-x grid-padding-x">
<div class="shrink cell hide-for-small-only"><input type="text" name="Comuni_CapoKy" id="Comuni_CapoKy" placeholder="Comune padre"></div>
<div class="auto cell"><input type="text" name="Comuni_CapoComune" id="Comuni_CapoComune" placeholder="Comune padre"></div>
<script type="text/javascript">
		jQuery("#Comuni_CapoComune").autocomplete({
			source: "/admin/app/core/autosuggest-GetComuni-json.aspx",
			minLength: 2,
			select: function( event, ui ) {
				jQuery("#Comuni_CapoKy").val(ui.item.value);
				jQuery("#Comuni_CapoComune").val(ui.item.label);
				return false;
			}
		});
</script>
</div>
</div>
</div>
<div class="grid-x grid-padding-x number">
<div class="large-2 medium-2 small-4 cell">
<label for="ImmobiliZona_Ky" class="large-text-right small-text-left middle">Zona</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<input type="text" name="ImmobiliZona_Ky" id="ImmobiliZona_Ky" class="input-group-field" placeholder="ricerca per Zona">
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Province_Ky" class="large-text-right small-text-left middle">Provincia id</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Province_Ky" id="Comuni_Ky" placeholder="Provincia id">
<option></option>
<option value="1">
1 - Agrigento</option>
<option value="2">
2 - Alessandria</option>
<option value="3">
3 - Ancona</option>
<option value="4">
4 - Aosta</option>
<option value="7">
7 - Arezzo</option>
<option value="5">
5 - Ascoli Piceno</option>
<option value="8">
8 - Asti</option>
<option value="9">
9 - Avellino</option>
<option value="10">
10 - Bari</option>
<option value="114">
114 - Barletta-Andria-Trani</option>
<option value="13">
13 - Belluno</option>
<option value="14">
14 - Benevento</option>
<option value="11">
11 - Bergamo</option>
<option value="12">
12 - Biella</option>
<option value="15">
15 - Bologna</option>
<option value="18">
18 - Bolzano</option>
<option value="17">
17 - Brescia</option>
<option value="16">
16 - Brindisi</option>
<option value="19">
19 - Cagliari</option>
<option value="23">
23 - Caltanissetta</option>
<option value="20">
20 - Campobasso</option>
<option value="116">
116 - Cara&#537;-Severin</option>
<option value="110">
110 - Carbonia-Iglesias</option>
<option value="21">
21 - Caserta</option>
<option value="28">
28 - Catania</option>
<option value="29">
29 - Catanzaro</option>
<option value="22">
22 - Chieti</option>
<option value="25">
25 - Como</option>
<option value="27">
27 - Cosenza</option>
<option value="26">
26 - Cremona</option>
<option value="42">
42 - Crotone</option>
<option value="24">
24 - Cuneo</option>
<option value="31">
31 - Enna</option>
<option value="109">
109 - Estero</option>
<option value="113">
113 - Fermo</option>
<option value="32">
32 - Ferrara</option>
<option value="34">
34 - Firenze</option>
<option value="33">
33 - Foggia</option>
<option value="35">
35 - Forli-Cesena</option>
<option value="36">
36 - Frosinone</option>
<option value="37">
37 - Genova</option>
<option value="38">
38 - Gorizia</option>
<option value="120">
120 - Gran Canaria</option>
<option value="39">
39 - Grosseto</option>
<option value="40">
40 - Imperia</option>
<option value="41">
41 - Isernia</option>
<option value="84">
84 - La Spezia</option>
<option value="6">
6 - L'aquila</option>
<option value="47">
47 - Latina</option>
<option value="44">
44 - Lecce</option>
<option value="43">
43 - Lecco</option>
<option value="45">
45 - Livorno</option>
<option value="46">
46 - Lodi</option>
<option value="117">
117 - Londra</option>
<option value="48">
48 - Lucca</option>
<option value="49">
49 - Macerata</option>
<option value="52">
52 - Mantova</option>
<option value="54">
54 - Massa Carrara</option>
<option value="55">
55 - Matera</option>
<option value="111">
111 - Medio Campidano</option>
<option value="50">
50 - Messina</option>
<option value="51">
51 - Milano</option>
<option value="53">
53 - Modena</option>
<option value="108">
108 - Monza Brianza</option>
<option value="56">
56 - Napoli</option>
<option value="57">
57 - Novara</option>
<option value="58">
58 - Nuoro</option>
<option value="115">
115 - Ogliastra</option>
<option value="112">
112 - Olbia-Tempio</option>
<option value="59">
59 - Oristano</option>
<option value="62">
62 - Padova</option>
<option value="60">
60 - Palermo</option>
<option value="68">
68 - Parma</option>
<option value="71">
71 - Pavia</option>
<option value="64">
64 - Perugia</option>
<option value="69">
69 - Pesaro-Urbino</option>
<option value="63">
63 - Pescara</option>
<option value="61">
61 - Piacenza</option>
<option value="65">
65 - Pisa</option>
<option value="70">
70 - Pistoia</option>
<option value="66">
66 - Pordenone</option>
<option value="72">
72 - Potenza</option>
<option value="67">
67 - Prato</option>
<option value="76">
76 - Ragusa</option>
<option value="73">
73 - Ravenna</option>
<option value="74">
74 - Reggio Calabria</option>
<option value="75">
75 - Reggio Emilia</option>
<option value="77">
77 - Rieti</option>
<option value="79">
79 - Rimini</option>
<option value="78">
78 - Roma</option>
<option value="80">
80 - Rovigo</option>
<option value="81">
81 - Salerno</option>
<option value="118">
118 - Santa Barbara</option>
<option value="86">
86 - Sassari</option>
<option value="87">
87 - Savona</option>
<option value="82">
82 - Siena</option>
<option value="85">
85 - Siracusa</option>
<option value="83">
83 - Sondrio</option>
<option value="119">
119 - Sud Sardegna</option>
<option value="88">
88 - Taranto</option>
<option value="89">
89 - Teramo</option>
<option value="93">
93 - Terni</option>
<option value="91">
91 - Torino</option>
<option value="92">
92 - Trapani</option>
<option value="90">
90 - Trento</option>
<option value="95">
95 - Treviso</option>
<option value="94">
94 - Trieste</option>
<option value="96">
96 - Udine</option>
<option value="97">
97 - Varese</option>
<option value="100">
100 - Venezia</option>
<option value="98">
98 - Verbano-Cusio-Ossola</option>
<option value="99">
99 - Vercelli</option>
<option value="102">
102 - Verona</option>
<option value="104">
104 - Vibo Valentia</option>
<option value="101">
101 - Vicenza</option>
<option value="103">
103 - Viterbo</option>
</select>
</div>
</div>
<div class="grid-x grid-padding-x join">
<div class="large-2 medium-2 small-4 cell">
<label for="Province_Codice" class="large-text-right small-text-left middle">Provincia codice</label>
</div>
<div class="large-10 medium-10 small-8 cell">
<select name="Province_Codice" id="Comuni_Ky" placeholder="Provincia codice">
<option></option>
<option value="AG">
AG - Agrigento</option>
<option value="AL">
AL - Alessandria</option>
<option value="AN">
AN - Ancona</option>
<option value="AO">
AO - Aosta</option>
<option value="AP">
AP - Ascoli Piceno</option>
<option value="AQ">
AQ - L'aquila</option>
<option value="AR">
AR - Arezzo</option>
<option value="AT">
AT - Asti</option>
<option value="AV">
AV - Avellino</option>
<option value="BA">
BA - Bari</option>
<option value="BG">
BG - Bergamo</option>
<option value="BI">
BI - Biella</option>
<option value="BL">
BL - Belluno</option>
<option value="BN">
BN - Benevento</option>
<option value="BO">
BO - Bologna</option>
<option value="BR">
BR - Brindisi</option>
<option value="BS">
BS - Brescia</option>
<option value="BT">
BT - Barletta-Andria-Trani</option>
<option value="BZ">
BZ - Bolzano</option>
<option value="CA">
CA - Cagliari</option>
<option value="CB">
CB - Campobasso</option>
<option value="CE">
CE - Caserta</option>
<option value="CH">
CH - Chieti</option>
<option value="CI">
CI - Carbonia-Iglesias</option>
<option value="CL">
CL - Caltanissetta</option>
<option value="CN">
CN - Cuneo</option>
<option value="CO">
CO - Como</option>
<option value="CR">
CR - Cremona</option>
<option value="CS">
CS - Cosenza</option>
<option value="CT">
CT - Catania</option>
<option value="CZ">
CZ - Catanzaro</option>
<option value="EE">
EE - Estero</option>
<option value="EN">
EN - Enna</option>
<option value="FC">
FC - Forli-Cesena</option>
<option value="FE">
FE - Ferrara</option>
<option value="FG">
FG - Foggia</option>
<option value="FI">
FI - Firenze</option>
<option value="FM">
FM - Fermo</option>
<option value="FR">
FR - Frosinone</option>
<option value="gc">
gc - Gran Canaria</option>
<option value="GE">
GE - Genova</option>
<option value="GO">
GO - Gorizia</option>
<option value="GR">
GR - Grosseto</option>
<option value="IM">
IM - Imperia</option>
<option value="IS">
IS - Isernia</option>
<option value="KR">
KR - Crotone</option>
<option value="LC">
LC - Lecco</option>
<option value="LE">
LE - Lecce</option>
<option value="LI">
LI - Livorno</option>
<option value="LO">
LO - Lodi</option>
<option value="LO">
LO - Londra</option>
<option value="LT">
LT - Latina</option>
<option value="LU">
LU - Lucca</option>
<option value="MB">
MB - Monza Brianza</option>
<option value="MC">
MC - Macerata</option>
<option value="MD">
MD - Medio Campidano</option>
<option value="ME">
ME - Messina</option>
<option value="MI">
MI - Milano</option>
<option value="MN">
MN - Mantova</option>
<option value="MO">
MO - Modena</option>
<option value="MS">
MS - Massa Carrara</option>
<option value="MT">
MT - Matera</option>
<option value="NA">
NA - Napoli</option>
<option value="NO">
NO - Novara</option>
<option value="NU">
NU - Nuoro</option>
<option value="OG">
OG - Ogliastra</option>
<option value="OR">
OR - Oristano</option>
<option value="OT">
OT - Olbia-Tempio</option>
<option value="PA">
PA - Palermo</option>
<option value="PC">
PC - Piacenza</option>
<option value="PD">
PD - Padova</option>
<option value="PE">
PE - Pescara</option>
<option value="PG">
PG - Perugia</option>
<option value="PI">
PI - Pisa</option>
<option value="PN">
PN - Pordenone</option>
<option value="PO">
PO - Prato</option>
<option value="PR">
PR - Parma</option>
<option value="PT">
PT - Pistoia</option>
<option value="PU">
PU - Pesaro-Urbino</option>
<option value="PV">
PV - Pavia</option>
<option value="PZ">
PZ - Potenza</option>
<option value="RA">
RA - Ravenna</option>
<option value="RC">
RC - Reggio Calabria</option>
<option value="RE">
RE - Reggio Emilia</option>
<option value="RG">
RG - Ragusa</option>
<option value="RI">
RI - Rieti</option>
<option value="RM">
RM - Roma</option>
<option value="RN">
RN - Rimini</option>
<option value="RO">
RO - Rovigo</option>
<option value="RO-CS">
RO-CS - Cara&#537;-Severin</option>
<option value="SA">
SA - Salerno</option>
<option value="sb">
sb - Santa Barbara</option>
<option value="SI">
SI - Siena</option>
<option value="SO">
SO - Sondrio</option>
<option value="SP">
SP - La Spezia</option>
<option value="SR">
SR - Siracusa</option>
<option value="SS">
SS - Sassari</option>
<option value="SU">
SU - Sud Sardegna</option>
<option value="SV">
SV - Savona</option>
<option value="TA">
TA - Taranto</option>
<option value="TE">
TE - Teramo</option>
<option value="TN">
TN - Trento</option>
<option value="TO">
TO - Torino</option>
<option value="TP">
TP - Trapani</option>
<option value="TR">
TR - Terni</option>
<option value="TS">
TS - Trieste</option>
<option value="TV">
TV - Treviso</option>
<option value="UD">
UD - Udine</option>
<option value="VA">
VA - Varese</option>
<option value="VB">
VB - Verbano-Cusio-Ossola</option>
<option value="VC">
VC - Vercelli</option>
<option value="VE">
VE - Venezia</option>
<option value="VI">
VI - Vicenza</option>
<option value="VR">
VR - Verona</option>
<option value="VT">
VT - Viterbo</option>
<option value="VV">
VV - Vibo Valentia</option>
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
