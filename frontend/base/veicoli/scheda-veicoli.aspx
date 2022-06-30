<%@ Page Language="C#" Culture="it-IT" uiCulture="it-IT" codepage=1252 AutoEventWireup="true" CodeFile="scheda-veicoli.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it-IT">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title><%=strTitle%></title>
  <meta property="og:title" content="<%=strTitle%>" />
  <meta name="description" content="<%=strMetaDescription%>" />
  <meta name="og:description" content="<%=strMetaDescription%>" />
  <meta name="robots" content="<%=strMetaRobots%>" />
	<!-- #include file ="/frontend/base/inc-head.aspx" -->
</head>

<body>
  <!--#include file="/frontend/base/inc-tagmanager.aspx"-->
  <!--#include file="/frontend/base/inc-header.aspx"-->
  <div class="grid-container">
  <div class="grid-x grid-padding-x">
    <div class="large-9 medium-9 small-12 cell">
          <div class="grid-x grid-padding-x">
            <div class="large-12 medium-12 small-12 cell">
              <h1 itemprop="name"><%=strH1%></h1>
              <hr>
              <p itemprop="description">
                <%=strP1%>
              </p>
            </div>
          </div>
                              <div id="schedafoto">
                                <div id="schedafoto1">
                                  <% = VeicoloFotoPrincipale("Veicoli_Foto1","Veicoli_Foto1",600,450) %>
                                  <br style="clear:both" />
                                  <div id="miniature">
                                    <% = VeicoloMiniature("Veicoli_Foto2s", "Veicoli_Foto2", 75, 60)%>
                                    <% = VeicoloMiniature("Veicoli_Foto3s", "Veicoli_Foto3", 75, 60)%>
                                    <% = VeicoloMiniature("Veicoli_Foto4s", "Veicoli_Foto4", 75, 60)%>
                                    <% = VeicoloMiniature("Veicoli_Foto5s", "Veicoli_Foto5", 75, 60)%>
                                    <% = VeicoloMiniature("Veicoli_Foto6s", "Veicoli_Foto6", 75, 60)%>
                                    <% = VeicoloMiniature("Veicoli_Foto7s", "Veicoli_Foto7", 75, 60)%>
                                    <% = VeicoloMiniature("Veicoli_Foto8s", "Veicoli_Foto8", 75, 60)%>
                                    <% = VeicoloMiniature("Veicoli_Foto9s", "Veicoli_Foto9", 75, 60)%>
                                  </div>
                                </div>
                              </div>

                                <% = VeicoloCaratteristichePrezzo("Prezzo", "Veicoli_Valore", "Veicoli_ValoreNascondi")%>
                                <% = VeicoloCaratteristiche("Categoria","VeicoliCategoria_Descrizione") %>
                                <% = VeicoloCaratteristiche("Marca", "VeicoliMarca_Descrizione")%>
                                <% = VeicoloCaratteristiche("Modello", "Veicoli_Modello")%>
                                <% = VeicoloCaratteristiche("Allestimento", "Veicoli_Allestimento")%>
                                <% = VeicoloCaratteristiche("Anno", "Veicoli_ImmatricolazioneAnno")%>
                                <% = VeicoloCaratteristiche("Mese", "Veicoli_ImmatricolazioneMese")%>
                                <% = VeicoloCaratteristiche("Alimentazione", "VeicoliCarburante_Descrizione")%>
                                <% = VeicoloCaratteristiche("Normativa", "VeicoliNormativeEuro_Descrizione")%>
                                <% = VeicoloCaratteristiche("Trazione", "Veicoli_Trazione")%>
                                <% = VeicoloCaratteristiche("Tipo Cambio", "Veicoli_TipoCambio")%>
                                <% = VeicoloCaratteristiche("Marce", "Veicoli_NumeroMarce")%>
                                <% = VeicoloCaratteristiche("Colore", "VeicoliColore_Descrizione")%>
                                <% = VeicoloCaratteristiche("Carrozzeria", "Veicoli_Carrozzeria")%>
                                <% = VeicoloCaratteristiche("Porte", "Veicoli_NumeroPorte")%>
                                <% = VeicoloCaratteristiche("CV", "Veicoli_CV")%>
                                <% = VeicoloCaratteristiche("Potenza Kw", "Veicoli_CVKW")%>
                                <% = VeicoloCaratteristiche("Cilindrata", "Veicoli_Cilindrata")%>
                                <% = VeicoloCaratteristiche("Immatricolazione", "Veicoli_DataPrimaImmatricolazione")%>
                                <% = VeicoloCaratteristiche("Riferimento", "Veicoli_Riferimento")%>
                                <% = VeicoloCaratteristicheInt("Km percorsi", "Veicoli_KM")%>
                                <% = VeicoloCaratteristiche("Assi", "Veicoli_Assi")%>
                                <% = VeicoloCaratteristiche("Ore", "Veicoli_Ore")%>
                                <%=dtVeicolo.Rows[0]["Veicoli_Annuncio"].ToString()%>
    </div>
    <aside class="large-3 medium-3 small-12 cell">
      <div class="sidebar callout primary" id="sidebar">
                                        <%if (drVeicolo["UtentiTipo_Ky"].ToString()=="11"){%>
                                        <font size="3"><b><%=drVeicolo["Utenti_Nominativo"].ToString()%></b></font><br />
                                        <%}else{%>
                                        <font size="3"><b><%=drVeicolo["Utenti_Nome"].ToString()%></b></font><br />
                                        <%}%>
                                                                                 <%=drVeicolo["Utenti_Indirizzo"].ToString()%><br />
                                        <%=drVeicolo["ComuneVenditore"].ToString()%><br />
                                        <%if (drVeicolo["Utenti_Telefono1Nascondi"].Equals(false)){%>
                                        Telefono: <%=drVeicolo["Utenti_Telefono1"].ToString()%><br />
                                        <%}%>
                                                                                <%
                                                                                  if (drVeicolo["UtentiTipo_Ky"].ToString()=="11"){
                                                                                    Response.Write("<br style=\"clear:both\" /><a href=\"/venditore/annuncicamion_" + drVeicolo["Utenti_Ky"].ToString().Trim() + ".html\" class=\"button-info\">Visualizza tutti gli annunci</a>");
                                                                                  }                                                    
                                                                                %>
                                    <form action="/fronent/base/veicoli/form/form-contatti-annuncio.aspx" name="contattavenditore" id="contattavenditore" method="post">
                                      <table width="100%" border="0" align="left" cellpadding="2" cellspacing="2" style="padding-left:2px">
                                        <tr>
                                          <td class="contatta" align="left">Il tuo nome:&nbsp;</td>
                                        </tr>
                                        <tr>
                                          <td><input name="nome" type="text" id="nome" size="28" />
                                            <script type="text/javascript">
                                              var nome = new LiveValidation('nome', { validMessage: "ok" });
                                              nome.add(Validate.Presence, { failureMessage: "obbligatorio" });
                                            </script>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td class="contatta" align="left">Telefono:&nbsp;</td>
                                        </tr>
                                        <tr>
                                          <td><input name="telefono" type="text" id="telefono" size="28" />
                                            <script type="text/javascript">
                                              var telefono = new LiveValidation('telefono', { validMessage: "ok" });
                                              telefono.add(Validate.Presence, { failureMessage: "obbligatorio" });
                                            </script>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td class="contatta" align="left">Provincia:&nbsp;</td>
                                        </tr>
                                        <tr>
                                          <td>
                                            <select name="provincia" id="provincia" tabindex="1" style="width:210PX;">
                                              <option value=""></option>
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
                                            </select>
                                            <script type="text/javascript">
                                              var provincia = new LiveValidation('provincia', { validMessage: "ok" });
                                              provincia.add(Validate.Presence, { failureMessage: "obbligatorio" });
                                            </script>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td class="contatta" valign="top" align="left">Richiesta:&nbsp;</td>
                                        </tr>
                                        <tr>
                                          <td valign="top">
                                            <textarea name="messaggio" rows="5" id="messaggio" style="width:210px"></textarea>
                                            <script type="text/javascript">
                                              var messaggio = new LiveValidation('messaggio', { validMessage: "ok" });
                                              messaggio.add(Validate.Presence, { failureMessage: "obbligatorio" });
                                            </script>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td class="contatta" align="left">Email:&nbsp;</td>
                                        </tr>
                                        <tr>
                                          <td>
                                            <input name="email" type="text" id="email" size="28" />
                                            <script type="text/javascript">
                                              var email = new LiveValidation('email', { validMessage: "ok" });
                                              email.add(Validate.Presence, { failureMessage: "obbligatorio" });
                                              email.add(Validate.Email, { failureMessage: "inserisci un valore corretto" });
                                            </script>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td><input type="checkbox" name="privacy" id="privacy" checked="checked" value="si" /> Acconsento al trattamento
                                            dei dati personali</td>
                                        </tr>
                                        <tr>
                                          <td align="center">
                                            <input type="hidden" name="Veicoli_Ky" id="Veicoli_Ky"
                                              value="<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>" />
                                            <input class="button-info" type="submit" name="invia" id="invia" value="Invia Richiesta" />
                                    
                                          </td>
                                        </tr>
                                      </table>
                                    </form>    
        </div>
      </aside>
  </div>
  </div>      

  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
</body>
</html>
