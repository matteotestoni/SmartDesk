<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/catalogo/numero-max-prodotti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Numero max prodotti</title>
    <!--#include file="/area-clienti/inc-head.aspx"--> 
	<link type="text/css" rel="stylesheet" href="/area-clienti/area-clienti.css" />
  <script type="text/javascript" src="/area-clienti/area-clienti.js"></script>
	<script type="text/javascript">
	jQuery(function() {
		jQuery( "input:submit").button();
		jQuery( "#tabs" ).tabs();
	});
	</script>
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
  <div id="main">
    <div id="contenuto">
              <h1>Contatta outlet mobili design</h1>
              
              Hai raggiunto il numero massimo di offerte che puoi inserire: <%=dtAnagrafiche.Rows[0]["Anagrafiche_NumeroProdotti"].ToString()%>
              
<form onsubmit="MM_validateForm('ragionesociale','','R','telefono','','R','email','','RisEmail');return document.MM_returnValue" id="frmContatti" name="frmContatti" method="get" action="/form/form-contatti.aspx">
                <div align="center"><h3 class="contenuti">Inserisci i tuoi riferimenti per essere ricontattato</h3>
                  <br>
                </div>
                <table width="100%" cellspacing="2" cellpadding="2" summary="inserisci i tuoi dati aziendali">
                  <tbody><tr>
                    <td width="120">Nome e cognome:</td>
                    <td><input type="text" class="txtsito" size="40" tabindex="1" accesskey="1" id="nome" name="nome" /></td>
                  </tr>
                  <tr>
                    <td>Ragione Sociale*</td>
                    <td><input type="text" class="txtsito" size="40" tabindex="2" accesskey="2" id="ragionesociale" name="ragionesociale" /></td>
                  </tr>
                  <tr>
                    <td>Telefono fisso*</td>
                    <td><input type="text" class="txtsito" size="40" tabindex="3" accesskey="3" id="telefono" name="telefono" /></td>
                  </tr>
                  <tr>
                    <td>Cellulare</td>
                    <td><input type="text" class="txtsito" size="40" tabindex="4" accesskey="4" id="cellulare" name="cellulare" /></td>
                  </tr>
                  <tr>
                    <td>Email*</td>
                    <td><input type="text" class="txtsito" size="40" tabindex="5" accesskey="5" id="email" name="email" /></td>
                  </tr>
                  <tr>
                    <td>Messaggio:</td>
                    <td><textarea class="txtsito" tabindex="6" accesskey="6" id="messaggio" rows="4" cols="31" name="messaggio"></textarea></td>
                  </tr>
                </tbody></table>
              <input type="checkbox" checked="checked" value="acconsento" name="consenso" />
                <font size="2">Dichiaro di aver preso visione di quanto riportato nell' <a href="/privacy.aspx">Informativa sulla Privacy</a> e autorizzo espressamente il trattamento dei dati da me forniti da parte di <strong>OutletMobiliDesign</strong> Qualora non venga fornito il consenso, i dati inseriti non saranno registrati in alcun modo!              
                </font>          
                <p class="sitoweb">
                  <input type="submit" value="Contattaci" id="button" name="button" />
                </p>
              </form>

            <br /><br /><br />
      </div>  
  </div>
  <div id="footer">
    <!--#include file="/area-clienti/inc-footer.aspx" -->
  </div>

</body>
</html>
