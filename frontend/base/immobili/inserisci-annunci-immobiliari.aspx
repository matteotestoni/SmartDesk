<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it-IT">
  <head>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Inserisci annunci immobiliari gratuitamente, portale immobiliare gratuito</title>
	<meta name="description" content="Inserisci annunci immobiliari gratuitamente, portale immobiliare gratuito" />
	<meta property="og:title" content="Inserisci annunci immobiliari gratuitamente, portale immobiliare gratuito" />
  <meta name="robots" content="index,follow" />
 	<!--#include file="/frontend/base/inc-head.aspx"-->
 </head>
 <body>
	<!--#include file="/frontend/base/inc-tagmanager.aspx"-->
	<!--#include file="/frontend/base/inc-header.aspx"-->

	<div class="grid-x grid-padding-x">
		<div class="large-12 medium-12 small-12 cell">
      <h1 class="casa" itemprop="name">Inserisci annunci immobiliari gratuitamente</h1>
		</div>
	</div>

	<div class="grid-x grid-padding-x">
		<div class="large-12 medium-12 small-12 cell">        
			<nav aria-label="Sei in:" role="navigation">
			  <ul class="breadcrumbs" id="breadcrumb" itemscope itemtype="https://schema.org/BreadcrumbList">
			    <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem"><a href="/" title="Case, vendita e affitto appartamenti, annunci immobiliari, villette, rustici e uffici"><span itemprop="name">Home</span></a><meta itemprop="position" content="1" /></li>
			    <li itemprop="itemListElement" itemscope itemtype="https://schema.org/ListItem">
			      Inserisci annunci immobiliari gratuitamente, portale immobiliare gratuito
			    </li>
			  </ul>
			</nav>        
			<div class="grid-x grid-padding-x">
				<div class="large-8 medium-8 small-12 cell">    
					<h2>Se sei gi&agrave; registrato accedi all'area riservata</h2>
					<div id="divlogin" class="card">
					<form method="post" action="/admin2019/area_riservata.asp" name="formLogin" id="formLogin" data-abide>
						<div class="grid-x grid-padding-x">
							<div class="large-3 medium-3 small-4 cell text-right">Email di accesso:</div>
							<div class="large-9 medium-9 small-8 cell"><input type="text" name="email" id="email" placeholder="email" value="" required="required" /></div>
						</div>
						<div class="grid-x grid-padding-x">
							<div class="large-3 medium-3 small-4 cell text-right">Password di accesso:</div>
							<div class="large-9 medium-9 small-8 cell"><input type="password" name="password" id="password" placeholder="password" value="" required="required" /></div>
						</div>
						<div class="grid-x grid-padding-x">
							<div class="large-12 medium-12 small-12 cell text-center">
								<input name="accedi" type="submit" value="accedi all'area riservata" class="button" />
							</div>                        
						</div>
					</form>
					</div>
					<br>
					<h2>Se hai perso la password digita l'email e invia la richiesta</h2>
					<div id="divrecuperopassword" class="card">
						<form method="post" action="/form/form-recupera-password.aspx" name="formLogin" id="formLogin" data-abide>
						<div class="grid-x grid-padding-x">
							<div class="large-3 medium-3 small-4 cell text-right">Email di accesso:</div>
							<div class="large-9 medium-9 small-8 cell"><input type="text" name="email" id="email" placeholder="email" value="" required="required" /></div>
						</div>
						<div class="grid-x grid-padding-x">
							<div class="large-12 medium-12 small-12 cell text-center">
								<input name="recupera" type="submit" value="recupera la password" class="button" />
							</div>                        
						</div>
						</form>
					</div>
					<br>
					<h2>Non sei presente? registrati</h2>
					<ul class="menu vertical">
						<li><i class="fa-duotone fa-check fa-fw"></i>Completamente GRATIS</li>
						<li><i class="fa-duotone fa-check fa-fw"></i>Gestione annunci immobiliari</li>
						<li><i class="fa-duotone fa-check fa-fw"></i>Ricezione richieste su annunci/li>
						<li><i class="fa-duotone fa-check fa-fw"></i>Caricamento logo su profilo</li>
						<li><i class="fa-duotone fa-check fa-fw"></i>Gestione cantieri</li>
					</ul>
					<div id="registrazione" class="card">
					<form method="post" enctype="multipart/form-data" action="/form/form-registrazione-casecasa.aspx"" name="formAdesione" id="formAdesione" data-abide>
						<div class="grid-x grid-padding-x">
							<div class="large-3 medium-3 small-4 cell text-right">Tipo di utente:</div>
							<div class="large-9 medium-9 small-8 cell">
								<input name="tipoutente" type="radio" id="tipoutente2" accesskey="13" tabindex="13" onClick="tipoUtente(2);" value="2" checked="checked"/>
								Agenzia immobiliare
								<input name="tipoutente" type="radio" id="tipoutente" accesskey="13" tabindex="13" onClick="tipoUtente(2);" value="3"/>
								Impresa edile
								<input name="tipoutente" type="radio" id="tipoutente" accesskey="13" tabindex="13" onClick="tipoUtente(1);" value="1"/>
								Privato
							</div>
						</div>
						<div class="grid-x grid-padding-x" id="trragsoc">
								<div class="large-3 medium-3 small-4 cell text-right">Ragione Sociale*</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="ragsoc" id="ragsoc" accesskey="18" tabindex="18" class="txt" size="48" />
							   </div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trpiva">
							   <div class="large-3 medium-3 small-4 cell text-right">Partita IVA*</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="piva" id="piva" accesskey="18" tabindex="18" class="txt" size="48" />
							   </div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trcodfisc">
							   <div class="large-3 medium-3 small-4 cell text-right">Codice fisc. (se diverso da P.IVA)</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="codfisc" id="codfisc" accesskey="18" tabindex="18" class="txt" size="48" />
								</div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trnome">
							   <div class="large-3 medium-3 small-4 cell text-right">Nome</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="nome" id="nome" accesskey="16" tabindex="16" required="required" />
								</div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trcognome">
							   <div class="large-3 medium-3 small-4 cell text-right">Cognome</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="cognome" id="cognome" accesskey="17" tabindex="17" required="required" />
								</div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trtelefono">
							   <div class="large-3 medium-3 small-4 cell text-right">Telefono fisso*</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="telefono" id="telefono" accesskey="19" tabindex="19" required="required" />
								</div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trindirizzo">
							   <div class="large-3 medium-3 small-4 cell text-right">Indirizzo*</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="indirizzo" id="indirizzo" accesskey="21" tabindex="21" maxlength="50" size="48" class="txt" />
							   </div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trprovincia2">
							   <div class="large-3 medium-3 small-4 cell text-right">Provincia*</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <select name="provinciavenditore" id="provinciavenditore" class="selectFocus" onChange="ldComuni();" required="required">
								   <option value="1">Agrigento</option>
								   <option value="2">Alessandria</option>
								   <option value="3">Ancona</option>
								   <option value="4">Aosta</option>
								   <option value="7">Arezzo</option>
								   <option value="5">Ascoli Piceno</option>
								   <option value="8">Asti</option>
								   <option value="9">Avellino</option>
								   <option value="10">Bari</option>
								   <option value="114">Barletta-Andria-Trani</option>
								   <option value="13">Belluno</option>
								   <option value="14">Benevento</option>
								   <option value="11">Bergamo</option>
								   <option value="12">Biella</option>
								   <option value="15">Bologna</option>
								   <option value="18">Bolzano</option>
								   <option value="17">Brescia</option>
								   <option value="16">Brindisi</option>
								   <option value="19">Cagliari</option>
								   <option value="23">Caltanissetta</option>
								   <option value="20">Campobasso</option>
								   <option value="110">Carbonia-Iglesias</option>
								   <option value="21">Caserta</option>
								   <option value="28">Catania</option>
								   <option value="29">Catanzaro</option>
								   <option value="22">Chieti</option>
								   <option value="25">Como</option>
								   <option value="27">Cosenza</option>
								   <option value="26">Cremona</option>
								   <option value="42">Crotone</option>
								   <option value="24">Cuneo</option>
								   <option value="31">Enna</option>
								   <option value="109">Estero</option>
								   <option value="113">Fermo</option>
								   <option value="32">Ferrara</option>
								   <option value="34">Firenze</option>
								   <option value="33">Foggia</option>
								   <option value="35">Forli-Cesena</option>
								   <option value="36">Frosinone</option>
								   <option value="37">Genova</option>
								   <option value="38">Gorizia</option>
								   <option value="39">Grosseto</option>
								   <option value="40">Imperia</option>
								   <option value="41">Isernia</option>
								   <option value="6">L'aquila</option>
								   <option value="84">La Spezia</option>
								   <option value="47">Latina</option>
								   <option value="44">Lecce</option>
								   <option value="43">Lecco</option>
								   <option value="45">Livorno</option>
								   <option value="46">Lodi</option>
								   <option value="48">Lucca</option>
								   <option value="49">Macerata</option>
								   <option value="52">Mantova</option>
								   <option value="54">Massa Carrara</option>
								   <option value="55">Matera</option>
								   <option value="111">Medio Campidano</option>
								   <option value="50">Messina</option>
								   <option value="51">Milano</option>
								   <option value="53">Modena</option>
								   <option value="108">Monza Brianza</option>
								   <option value="56">Napoli</option>
								   <option value="57">Novara</option>
								   <option value="58">Nuoro</option>
								   <option value="115">Ogliastra</option>
								   <option value="112">Olbia-Tempio</option>
								   <option value="59">Oristano</option>
								   <option value="62">Padova</option>
								   <option value="60">Palermo</option>
								   <option value="68">Parma</option>
								   <option value="71">Pavia</option>
								   <option value="64">Perugia</option>
								   <option value="69">Pesaro-Urbino</option>
								   <option value="63">Pescara</option>
								   <option value="61">Piacenza</option>
								   <option value="65">Pisa</option>
								   <option value="70">Pistoia</option>
								   <option value="66">Pordenone</option>
								   <option value="72">Potenza</option>
								   <option value="67">Prato</option>
								   <option value="76">Ragusa</option>
								   <option value="73">Ravenna</option>
								   <option value="74">Reggio Calabria</option>
								   <option value="75">Reggio Emilia</option>
								   <option value="77">Rieti</option>
								   <option value="79">Rimini</option>
								   <option value="78">Roma</option>
								   <option value="80">Rovigo</option>
								   <option value="81">Salerno</option>
								   <option value="86">Sassari</option>
								   <option value="87">Savona</option>
								   <option value="82">Siena</option>
								   <option value="85">Siracusa</option>
								   <option value="83">Sondrio</option>
								   <option value="88">Taranto</option>
								   <option value="89">Teramo</option>
								   <option value="93">Terni</option>
								   <option value="91">Torino</option>
								   <option value="92">Trapani</option>
								   <option value="90">Trento</option>
								   <option value="95">Treviso</option>
								   <option value="94">Trieste</option>
								   <option value="96">Udine</option>
								   <option value="97">Varese</option>
								   <option value="100">Venezia</option>
								   <option value="98">Verbano-Cusio-Ossola</option>
								   <option value="99">Vercelli</option>
								   <option value="102">Verona</option>
								   <option value="104">Vibo Valentia</option>
								   <option value="101">Vicenza</option>
								   <option value="103">Viterbo</option>
								 </select>                </div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trcomune2">
							   <div class="large-3 medium-3 small-4 cell text-right">Comune*</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <select name="comunevenditore" id="comunevenditore"></select>                
								</div>
							 </div>
							 <div class="grid-x grid-padding-x" id="trmessaggio2">
							   <div class="large-3 medium-3 small-4 cell text-right">Note</div>
							   <div class="large-9 medium-9 small-8 cell"><textarea name="messaggio" id="messaggio" cols="39" rows="2" accesskey="24" tabindex="24" class="txtAreaFocus"></textarea></div>
							 </div>
							 <div class="grid-x grid-padding-x">
							   <div class="large-3 medium-3 small-4 cell text-right">Email*</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="emailregistrazione" id="emailregistrazione" required="required" />
							   </div>
							 </div>
							 <div class="grid-x grid-padding-x">
							   <div class="large-3 medium-3 small-4 cell text-right">Password*</div>
							   <div class="large-9 medium-9 small-8 cell">
								   <input type="text" name="passwordregistrazione" id="passwordregistrazione" required="required" />
							   </div>
							 </div>

							 <div class="grid-x grid-padding-x" id="trcaptcha">
							   <div class="large-3 medium-3 small-4 cell text-right">codice di controllo</div>
							   <div class="large-3 medium-3 small-8 cell"><img src="/captcha-3.aspx" align="left" hspace="20" /></div>
							   <div class="large-3 medium-3 small-8 cell"><input type="text" name="codice" id="codice" accesskey="25" tabindex="25" maxlength="15"  size="15" class="txt" /></div> 
							   <div class="large-3 medium-3 small-8 cell">scrivi qui a fianco il codice di 6 cifre</div>
							 </div>
							 <div class="grid-x grid-padding-x">
							   <div class="large-12 medium-12 small-12 cell"><p>Con l'invio del presente modulo,  esprimo il mio consenso al trattamento dei miei dati personali in  conformit&agrave; alle finalit&agrave; di cui all'<a href="/pag/condizioni-del-servizio.html#privacy" target="_blank" class="sommario" rel="nofollow">Informativa Privacy</a>.</p>
									<p align="justify">
										<strong><font color="#FF0000" size="4">ATTENZIONE:</font></strong><br />
										<strong>Si declina ogni responsabilit&agrave; derivante dagli scambi commerciali tra inserzionisti e utenti registrati al sito. Lo staff si riserva la possibilit&agrave; di sospendere e/o annullare l'adesione nel sito in caso di comportamenti scorretti o non aderenti alle regole del sito.</strong>
									</p>
							   </div>
							 </div>
							 <div class="grid-x grid-padding-x">
								<div class="large-12 medium-12 small-12 cell text-center">
									<input type="submit" name="registrati" value="Registrati ora" class="button">
								</div>
							 </div>
						   </table>
						   
						   <br />
						 </form>
		 
					</div>
	</div>
	<div class="large-4 medium-4 small-12 cell">
		<!--#include file="/frontend/base/inc-sidebar.aspx"-->		
	</div>
  </div>
  </div>
  </div>
	<!--#include file="/frontend/base/inc-footer.aspx"-->
 </body>
</html>
