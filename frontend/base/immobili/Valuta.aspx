<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="Valuta.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it-IT" >
  <head>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title><%=strTitle%></title>
  <meta property="og:title" content="<%=strTitle%>" />
	<meta name="description" content="<%=strMetaDescription%>" />
  <meta name="og:description" content="<%=strMetaDescription%>" />
  <meta name="robots" content="<%=strMetaRobots%>" />
 	<!--#include file="/frontend/base/inc-head.aspx"-->
 </head>
 <body>
	<!--#include file="/frontend/base/inc-tagmanager.aspx"-->
	<!--#include file="/frontend/base/inc-header.aspx"-->
	<div class="grid-x grid-padding-x">
		<div class="large-12 medium-12 small-12 cell">
      <nav aria-label="Sei in:" role="navigation">
        <ul class="breadcrumbs" id="breadcrumb" itemscope itemtype="https://schema.org/BreadcrumbList">
          <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem"><a href="/"
              title="Case, vendita e affitto appartamenti, annunci immobiliari, villette, rustici e uffici"><span
                itemprop="name">Home</span></a>
            <meta itemprop="position" content="1" />
          </li>
          <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
            <span class="show-for-sr">Current: </span> Valuta
          </li>
        </ul>
      </nav>
      <h1 itemprop="name"><%=strH1%></h1>
      <p itemprop="description">
			Descrivi l'immobile per il quale<strong> vuoi ricevere la valutazione</strong>, per <strong>venderlo</strong> o <strong>affittarlo</strong>.<br />
      Inviaci la tua valutazione e sar&agrave; inviata a tutte le agenzie immobiliari aderenti al portale che potranno risponderti.
			</p>
		</div>
	</div>

	<div class="grid-x grid-padding-x">
		<div class="large-12 medium-12 small-12 cell" id="annunci">        
    <form method="get" name="formValuta" id="formValuta" action="/form/form-valuta.aspx" data-abide>
      <div data-abide-error class="alert callout" style="display: none;">
        <p><i class="fa-duotone fa-exclamation-triangle fa-fw"></i> Ci sono errori nel tuo modulo.</p>
      </div>
      <div class="grid-x grid-padding-x">
        <div class="large-6 medium-6 small-12 cell">
          <h4 class="text-center">Descrivi l'immobile ricercato</h4>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Provincia*</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <select name="provincia" id="provincia" onchange="caricaComuni_Ky('provincia','comune')" required="required">
                <option value="">Seleziona una provincia</option>
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
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Comune*</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <select name="comune" id="comune" onchange="caricaImmobiliZona_Ky('comune','zona')" required="required">
                <option value="">Seleziona il comune</option>
              </select>
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Zona</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <select name="zona" id="zona">
                <option value="">Qualsiasi</option>
              </select>
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Contratto*</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <select name="contratto" id="contratto" required="required">
                <option value="1">Affitto</option>
                <option value="2">Vendita</option>
              </select>
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Tipologia*</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <select name="tipologia" id="tipologia"
                onchange="caricaImmobiliSottotipologia_Ky('ImmobiliTipologia_Ky','ImmobiliSottotipologia_Ky')"
                required="required">
                <OPTGROUP LABEL="Residenziale">
                  <option value="3" SELECTED>Appartamento</option>
                  <option value="5">attico</option>
                  <option value="110">baita-chalet-cottage</option>
                  <option value="111">bungalows</option>
                  <option value="89">Casa</option>
                  <option value="66">garage-Box-posto auto</option>
                  <option value="6">mansarda</option>
                  <option value="117">Masserie</option>
                  <option value="70">Palazzo-stabile</option>
                  <option value="109">Porzione di fabbricato</option>
                  <option value="64">Rustico-casale</option>
                  <option value="119">Stanze</option>
                  <option value="63">Terreno edificabile</option>
                  <option value="98">Trilocale</option>
                  <option value="116">Trulli</option>
                  <option value="87">Villa-Villetta</option>
                </OPTGROUP>
                <OPTGROUP LABEL="Commerciale">
                  <option value="112">Bed-and-Breakfast</option>
                  <option value="81">capannone</option>
                  <option value="78">centro commerciale</option>
                  <option value="75">cielo terra</option>
                  <option value="82">laboratorio</option>
                  <option value="93">magazzino</option>
                  <option value="86">negozio</option>
                  <option value="95">Terreno edificabile artigianale</option>
                  <option value="83">ufficio</option>
                  <option value="80">villaggio turistico</option>
                </OPTGROUP>
                <OPTGROUP LABEL="Attività">
                  <option value="43">abbigliamento</option>
                  <option value="52">agenzia viaggi</option>
                  <option value="39">agriturismo-azienda agricola</option>
                  <option value="38">attivita alberghiera albergo</option>
                  <option value="92">Attività commerciale</option>
                  <option value="23">bar-tabacchi-ricevitoria</option>
                  <option value="44">calzature</option>
                  <option value="59">camping</option>
                  <option value="54">cartoleria-libreria</option>
                  <option value="48">computer</option>
                  <option value="51">concessionaria auto-moto</option>
                  <option value="61">discoteca</option>
                  <option value="35">edicola</option>
                  <option value="55">fast food self service</option>
                  <option value="96">ferramenta</option>
                  <option value="58">fiori-giardinaggio-floricoltura</option>
                  <option value="99">fotografo-ottico</option>
                  <option value="32">gastronomia-rosticceria</option>
                  <option value="41">gelateria</option>
                  <option value="56">gioielleria-oreficeria-orologeria</option>
                  <option value="42">market alimentari</option>
                  <option value="37">palestra</option>
                  <option value="34">panetteria</option>
                  <option value="62">parrucchiere uomo-donna</option>
                  <option value="40">pasticceria</option>
                  <option value="91">Piadina</option>
                  <option value="26">pizzeria</option>
                  <option value="31">pizzeria da asporto</option>
                  <option value="46">profumeria</option>
                  <option value="53">pub-birreria-locali notturni</option>
                  <option value="25">ricevitoria</option>
                  <option value="27">ristorante</option>
                  <option value="28">ristorante-pizzeria</option>
                  <option value="45">solarium-centro estetico</option>
                  <option value="115">Stabilimenti balneari</option>
                  <option value="24">tabacchi</option>
                  <option value="47">telefonia</option>
                  <option value="60">tintoria-lavanderia</option>
                  <option value="118">Videonoleggio</option>
                </OPTGROUP>
                <OPTGROUP LABEL="Terreni">
                  <option value="17">terreno</option>
                </OPTGROUP>
              </select>
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Mq</label>
            </div>

            <div class="large-9 medium-9 small-10 cell end">
              <input name="mq" type="text" id="mq" value="" size="5" />
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Prezzo</label>
            </div>
            <div class="large-9 medium-9 small-10 cell end">
              <input name="prezzo" type="text" id="prezzo" value="" size="5" />
            </div>
          </div>
        </div>
        <div class="large-6 medium-6 small-12 cell">
          <h4 class="text-center">Inserisci i tuoi dati</h4>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Nome*</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <input name="nome" id="nome" type="text" value="" size="30" required="required" />
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Cognome*</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <input name="cognome" id="cognome" type="text" value="" size="30" required="required" />
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">E.mail*</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <input name="email" id="email" type="text" value="" size="30" required="required" />
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Telefono*</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <input name="telefono1" id="telefono1" type="text" value="" size="30" required="required" />
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Messaggio</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <textarea name="messaggio" id="messaggio" rows="3"></textarea>
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
              <label class="large-text-right small-text-left">Privacy</label>
            </div>
            <div class="large-9 medium-9 small-12 cell">
              <input type="checkbox" name="privacy" id="privacy" checked="checked" />
              <label>Acconsento</label>
            </div>
          </div>
          <div class="grid-x grid-padding-x">
            <div class="large-12 medium-12 small-12 cell small-text-center large-text-right">
              <button class="button large success"><i class="fa-duotone fa-envelope fa-fw fa-lg"></i>Invia richiesta</button>
            </div>
          </div>
        </div>
      </div>
    </form>
    </div>
  </div>
	<!--#include file="/frontend/base/inc-footer.aspx"-->
  </body>
</html>