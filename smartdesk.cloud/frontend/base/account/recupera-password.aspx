<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="recupera-password.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<!--[if IE 9]><html class="lt-ie10" lang="it"><![endif]-->
<html class="no-js" dir="ltr" lang="it-IT">
<head>	
	<title>Recupera Password</title>
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
								<h2>Recupera la tua password</h2>
								<div id="login">
									<form method="post" action="/form/form-recupera-password.aspx" name="formRecuperaPassword" id="formRecuperaPassword" data-abide novalidate>
                  <input type="hidden" id="proteggi" name="proteggi" value="" />
                  <input type="hidden" id="foo" name="foo" />
										<div data-abide-error class="alert callout" style="display: none;">
									    	<p><i class="fa-duotone fa-alert fa-fw"></i> Errori di validazione.</p>
										</div>
										
										<div class="grid-x grid-padding-x">
											<div class="large-12 medium-12 small-12 cell">
								      			<input style="width:100%;float: none;max-width: 100%;" type="email" name="email" id="email" aria-describedby="helptext-email" tabindex="1" required="required" placeholder="Il tuo indirizzo Email">
								      			<div class="form-error">Email obbligatoria</div>
												<p class="help-text" id="helptext-email"><i class="fa-duotone fa-envelope fa-fw"></i>Inserisci il tuo indirizzo email</p>
											</div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-12 medium-12 small-12 cell">
												<p>Se sei gi&agrave; registrato ma non ricordi la tua password, inserisci la tua email e la manderemo alla tua casella di posta.</p>
                        <p>Ricordati di controllare i filtri antispam</p>
                        <br><br>
												<button class="button medium radius success"><i class="fa-duotone fa-lock fa-fw"></i>Recupera la tua password</button>
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