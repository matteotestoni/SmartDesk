<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="/area-clienti/login.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>	
	<title>area clienti</title>
  <!--#include file="/area-clienti/inc-head-login.aspx"--> 
  <link type="text/css" rel="stylesheet" href="/area-clienti/login.css" media="screen">
</head>
<body class="login">
<div class="grid-container fluid">
	<div class="grid-x grid-padding-x">
	  <div class="large-4 large-offset-4 end medium-12 small-12 cell">
			<div id="login">
      	<div class="logo text-left large-5 medium-6 small-12 cell end">
      		<a href="/" title="RSW Studio Gestione"><img src="/img/logo.png" alt="realizzazione siti web" /></a>
      	</div>
		  	<%if (strErrore!=null && strErrore.Length>0){%>
				<div id="messaggio" class="callout alert small" data-closable>
				  <h5><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw"></i>I dati inseriti non sono validi.</h5><h6><%=strErrore%></h6>
				  <button class="close-button" data-close aria-label="Chiudi">&times;</button>
				</div>
				<% } %>
        <form method="post" action="/area-clienti/accesso.aspx" name="formLogin" id="formLogin" data-abide novalidate>
					<div data-abide-error class="alert callout" style="display: none;">
			    	<p><i class="fa-duotone fa-triangle-exclamation fa-fw"></i> Ci sono errori nel form.</p>
			  	</div>
					<div class="grid-x grid-padding-x">
	      		<div class="large-12 medium-12 small-12 cell">
		      			<input type="email" name="email" id="email" aria-describedby="helptext-email" autocomplete="username" tabindex="1" required="required" placeholder="Il tuo indirizzo Email">
		      			<span class="form-error">Email obbligatoria</span>
								<p class="help-text" id="helptext-email"><i class="fa-duotone fa-envelope fa-fw"></i>Inserisci il tuo indirizzo email</p>
	      		</div>
	      	</div>
					<div class="grid-x grid-padding-x">
	      		<div class="large-12 medium-12 small-12 cell">
		      			<input type="password" name="password" id="password" aria-describedby="helptext-password" autocomplete="current-password" required="required" placeholder="La tua password" tabindex="2">
		      			<span class="form-error">Password obbligatoria</span>
								<p class="help-text" id="helptext-password"><i class="fa-duotone fa-key fa-fw"></i>Inserisci la tua password</p>
	      		</div>
	      	</div>
					<div class="grid-x grid-padding-x">
	      		<div class="large-12 medium-12 small-12 cell">
		      			<input type="checkbox" name="chkPersistCookie" id="chkPersistCookie" checked value="1" tabindex="3">
		      			<label for="chkPersistCookie">Resta collegato</label>
	      		</div>
	      	</div>

	      	<div class="grid-x grid-padding-x">
	      		<div class="large-12 medium-12 small-12 cell text-right">
							<input type="hidden" value="<%=strReturnUrl%>" id="ReturnUrl" name="ReturnUrl">
		          <button class="button medium radius"><i class="fa-duotone fa-right-to-bracket fa-fw"></i>Collegati</button>
		          <br><br>
	        	</div>
	        </div>
        </p>
      </form>
    </div>
  <script type="text/javascript">
  	try{document.getElementById('email').focus();}catch(e){}
  	<%if (strErrore!=null && strErrore.Length>0){%>
  	jQuery( "#login" ).effect("shake", "", 100);
		<%}else{%>
  	jQuery( "#login" ).effect("highlight", "", 1000);
		<%}%>
  </script>
	<!--#include file=/area-clienti/inc-footer.aspx -->
  </body>
</html>
