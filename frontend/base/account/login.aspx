<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" Debug="true"%>
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
		<br><br>
		<div class="grid-container" data-equalizer="foo" id="accediregistrati">
			<div class="grid-x grid-padding-x">
						<div class="large-6 medium-12 small-12 cell">
							<div class="callout" data-equalizer-watch="foo">
								<h2>Sei gi&agrave; registrato? Accedi con i tuoi dati</h2>
								<div id="login">
								  	<%if (strErrore!=null && strErrore.Length>0){%>
    									<div id="messaggio" class="callout alert small" data-closable>
    										<h5><i class="fa-duotone fa-exclamation-triangle fa-lg fa-fw"></i><%=strErrore%></h5>
    										<button class="close-button" data-close aria-label="Chiudi">&times;</button>
    									</div>
									<% } %>
									<form method="post" action="/frontend/base/account/accessoanagrafiche.aspx" name="formLogin" id="formLogin" data-abide novalidate>
										<div data-abide-error class="alert callout" style="display: none;">
									    	<p><i class="fa-duotone fa-alert fa-fw"></i> Errori di validazione.</p>
										</div>
										
										<div class="grid-x grid-padding-x">
											<div class="large-12 medium-12 small-12 cell">
								      			<input style="width:100%;float: none;max-width: 100%;" type="email" name="email" id="email" aria-describedby="helptext-email" tabindex="1" required="required" placeholder="Il tuo indirizzo Email">
								      			<div class="form-error">Email obbligatoria</div>
											</div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-12 medium-12 small-12 cell">
								      			<input type="password" name="password" id="password" aria-describedby="helptext-password" required="required" placeholder="La tua password" tabindex="2">
								      			<span class="form-error">Password obbligatoria</span>
											</div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-6 medium-6 small-12 cell text-left align-middle">
                        <a href="/account/recupera-password.html">Hai dimenticato la tua password?</a>
											</div>
											<div class="large-6 medium-6 small-12 cell text-right align-middle">
												<input type="hidden" value="<%=strReturnUrl%>" id="ReturnUrl" name="ReturnUrl">
												<br>
												<button class="button medium radius success"><i class="fa-duotone fa-lock fa-fw"></i>Collegati</button>
												<br>
											</div>
                      
										</div>
									</form>
								</div>
							</div>
						</div>
						<div class="large-6 medium-12 small-12 cell">
							<div class="callout" data-equalizer-watch="foo">
								<h2>Non sei gi&agrave; registrato? registrati</h2>
								<p>Registrandoti potrai:</p>
								<ul class="no-bullet">
									<li><i class="fa-duotone fa-square-check fa-fw fa-lg"></i>Pubblicare i tuoi annunci</li>
									<li><i class="fa-duotone fa-square-check fa-fw fa-lg"></i>Seguire gli annunci preferiti</li>
									<li><i class="fa-duotone fa-square-check fa-fw fa-lg"></i>Essere contattato per i tuoi annunci</li>
								</ul>
								<a href="/account/registrazione.html" class="button medium radius warning"><i class="fa-duotone fa-user-plus fa-fw"></i>Registrati</a>
							</div>
						</div>
					</div>
				</div>
			<!-- #include file ="/frontend/base/inc-footer.aspx" -->
			<!-- #include file ="/frontend/base/inc-foot.aspx" -->
		</body>
	</html>			