<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="partecipa-asta.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
	<head>	
		<title><%=strH1%></title>
    <meta name="description" content="<%=strH1%>"/>
    <meta name="robots" content="noindex,nofollow">
    <!--#include file="/frontend/base/inc-head.aspx"--> 
	</head>
	<body class="login">
		<!-- #include file ="/frontend/base/inc-header.aspx" -->
		<div class="grid-container">
          <div class="grid-x grid-padding-x">
						<div class="large-12 medium-12 small-12 cell">
							<h1>Partecipa all'asta di: <%=dtAste.Rows[0]["Aste_Titolo"].ToString()%></h1>
              <div class="label secondary"><span style="color: #ff6c00">ID ASTA:&nbsp;</span><strong><%=dtAste.Rows[0]["Aste_Numero"].ToString()%></strong></div>
              <div class="label secondary"><span style="color: #ff6c00">ESPERIMENTO:&nbsp;</span><strong><%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Numero"].ToString()%></strong></div>
              <div class="label secondary"><span style="color: #ff6c00">CATEGORIA:&nbsp;</span><strong><%=dtAste.Rows[0]["AsteCategorie_Titolo"].ToString()%></strong></div>
              <div class="label secondary"><span style="color: #ff6c00">CAUZIONE:&nbsp;</span><strong><%=Convert.ToInt32(dtAste.Rows[0]["Aste_Cauzione"]).ToString("N2", ci)%> &euro;</strong></div>
              <div class="label secondary"><span style="color: #ff6c00">SCADENZA:&nbsp;</span><strong><i class="fa-duotone fa-calendar-days fa-fw"></i><%=Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"]).ToString("d/M/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture)%></strong></div>
            </div>
          </div> 
          
					<div class="grid-x grid-padding-x">
						<div class="large-12 medium-12 small-12 cell">
              <p>
              Puoi partecipare all'asta versando la cauzione indicata nella scheda informativa.<br>
              Mancano ancora 
							<%
								Response.Write(Convert.ToInt32((Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"])-DateTime.Now).TotalDays));
							%> giorni alla scadenza dell'asta.
              </p>
            </div>
          </div> 

          <div class="grid-x grid-padding-x">
            <div class="large-6 medium-6 small-6 cell">                        
              <h2>Paga la cauzione con carta di credito</h2>
							<h5>Possibile negli ultimi 4 giorni dell'asta</h5>
              <p>
              Il pagamento sar&agrave; immediato e potrai fare subito la tua offerta.
              </p>
              <p>
                <img src="/img/cartedicredito/f2_cartasi-logo.png" align="left" hspace="10">
                
                Sarai reindirizzato al sito di CartaS&igrave; dove inserirai i dati della tua carta di credito.
              </p>
              <ul class="check">
	              <li>In caso di non vincita: la cauzione verr&agrave; restituita automaticamente entro 3 giorni dal termine dell'asta.</li>
	              <li>In caso di vincita: la cauzione verr&agrave; restituita al momento dell'intero saldo del prezzo.</li>
	              <li><strong>Non sar&agrave; applicata alcuna commissione</strong> sull'importo pagato con tale metodo.</li>
              </ul>
              <table>
                <tr>
                  <td class="text-left" width="150">Importo cauzione:</td>
                  <td class="text-left"><strong><%=Convert.ToInt32(dtAste.Rows[0]["Aste_Cauzione"]).ToString("N2", ci)%> &euro;</strong></td>
                </tr>
              </table>
              
              <div class="grid-x grid-padding-x small-up-10 medium-up-10 large-up-10">
                <div class="cell"><img src="/img/cartedicredito/f2_americanexpress-logo.png"></div>
                <div class="cell"><img src="/img/cartedicredito/f2_dinersclub-logo.png"></div>
                <div class="cell"><img src="/img/cartedicredito/f2_maestro-logo.png"></div>
                <div class="cell"><img src="/img/cartedicredito/f2_mastercard-logo.png"></div>
                <div class="cell"><img src="/img/cartedicredito/f2_masterpass-logo_0.png"></div>
                <div class="cell"><img src="/img/cartedicredito/f2_mybank-logo.png"></div>
                <div class="cell"><img src="/img/cartedicredito/f2_pago-logo.png"></div>
                <div class="cell"><img src="/img/cartedicredito/f2_paypal-logo.png"></div>
                <div class="cell"><img src="/img/cartedicredito/logo-visa_1.png"></div>
                <div class="cell"><img src="/img/cartedicredito/Logo-VPay.png"></div>
              </div>

							<%
							if ((Convert.ToDateTime(dtAsteEsperimenti.Rows[0]["AsteEsperimenti_DataTermine"])-DateTime.Now).TotalDays<=4){
							%>
              <div class="text-center">
                <i class="fa-duotone fa-long-arrow-down fa-3x fa-fw"></i>
              </div>
              <div class="text-center">
                <form action="/frontend/base/xpay/paga.aspx" method="post" name="formXpay">
                  <input type="hidden" name="importo" value="<%=((decimal)dtAste.Rows[0]["Aste_Cauzione"]).ToString("N0",ci)%>">
                  <input type="hidden" name="Aste_Ky" value="<%=dtAste.Rows[0]["Aste_Ky"].ToString()%>">
                  <input type="hidden" name="AsteEsperimenti_Ky" value="<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>">
                  <button class="button large warning radius">Paga ora</button>
                </form>
              </div>
              <% }else{ %>
              <div class="text-center">
                <i class="fa-duotone fa-long-arrow-down fa-3x fa-fw"></i>
              </div>
              <div class="text-center">
                <form action="/frontend/base/xpay/paga.aspx" method="post" name="formXpay">
                  <input type="hidden" name="importo" value="<%=((decimal)dtAste.Rows[0]["Aste_Cauzione"]).ToString("N0",ci)%>">
                  <input type="hidden" name="Aste_Ky" value="<%=dtAste.Rows[0]["Aste_Ky"].ToString()%>">
                  <input type="hidden" name="AsteEsperimenti_Ky" value="<%=dtAsteEsperimenti.Rows[0]["AsteEsperimenti_Ky"].ToString()%>">
                  <button class="button large warning radius" disabled>Paga ora</button>
                </form>
              </div>
							<% } %>
            
            </div>
            <div class="large-6 medium-6 small-6 cell">
              <h2>Paga la cauzione con bonifico bancario</h2>
              <p>
              Hai scelto di inviare la cauzione tramite BONIFICO BANCARIO. 
              Scarica la ricevuta e compilala con i tuoi dati (nome azienda e IBAN) e inviala a info@esempio.it insieme alla contabile del versamento (le coordinate bancarie nostre sono sulla ricevuta stessa).
              Una volta che avremo ricevuto entrambi i documenti e l'accredito, abiliteremo il tuo account per partecipare all'asta.
              </p>
              <ul class="check">
	              <li>In caso di non vincita: la cauzione verr&agrave; restituita entro 7 giorni dalla chiusura dell'asta <strong>al netto delle spese relative</strong>.</li>
	              <li>In caso di vincita: la cauzione verr&agrave; restituita al momento dell'intero saldo del prezzo.</li>
              </ul>
              <table>
                <tr>
                  <td class="text-left" width="150">Importo cauzione:</td>
                  <td class="text-left"><strong><%=Convert.ToInt32(dtAste.Rows[0]["Aste_Cauzione"]).ToString("N2", ci)%> &euro;</strong></td>
                </tr>
              </table>
              <div class="text-center">
                <i class="fa-duotone fa-long-arrow-down fa-3x fa-fw"></i>
              </div>
              <div class="text-center">
                <a href="/frontend/base/pdf/ricevuta-deposito-cauzionale.pdf" class="button large warning" target="blank">Scarica la ricevuta</a>
              </div>
            </div>
          </div>
              
              
						</div>
					</div>
    </div>
 		<!-- #include file ="/frontend/base/inc-footer.aspx" -->
		<!-- #include file ="/frontend/base/inc-foot.aspx" -->
	</body>
</html>			