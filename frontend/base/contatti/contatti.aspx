<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/frontend/base/contatti/contatti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
	<head>
   	<title>Contatti</title>
  	<meta name="description" content="Home"/>
		<meta name="robots" content="index,follow">
  	<!-- #include file ="/frontend/base/inc-head.aspx" -->
	</head>
	<body>
	<!-- #include file ="/frontend/base/inc-header.aspx" -->
  <div class="grid-container">
     <div class="grid-x grid-padding-x">
						<div class="large-12 xlarge-12 medium-12 small-12 cell">
							<h1>Contatti</h1>
							<div id="contatti">
								<h4>Aste Business S.r.l.</h4>
								<p>Via G.Mazzini 65<br>
								45020 Castelguglielmo<br>
								Tel. <a href="tel:+393420591175" target="_blank">342 0591175</a>
								</p>
								<p>Per qualsiasi richiesta informazioni compila il seguente modulo, verrai ricontattato a breve dal nostro team:</p>
								<form method="post" action="/frontend/base/form/form-contatti.aspx" name="formContatti" id="formContatti" data-abide novalidate>
                  <input type="hidden" id="proteggi" name="proteggi" value="" />
                  <input type="hidden" id="foo" name="foo" />
									<fieldset>
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell"><label for="nome">Nome e cognome*:</label></div>
											<div class="large-10 medium-10 small-12 cell">
                        <input type="text" name="nome" id="nome" tabindex="1" required="required">
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>	
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell"><label for="email">Email*:</label></div>
											<div class="large-10 medium-10 small-12 cell">
                        <input type="email" name="email" id="email" tabindex="1" required="required">
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell"><label for="telefono">Cellulare/Tel.*:</label></div>
											<div class="large-10 medium-10 small-12 cell">
                        <input type="text" name="telefono" id="telefono" tabindex="1" required="required">
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-2 medium-2 small-12 cell"><label for="messaggio">Messaggio*:</label></div>
											<div class="large-10 medium-10 small-12 cell">
                        <textarea name="messaggio" id="messaggio" required="required"></textarea>
                        <span class="form-error">Obbligatorio</span>
                      </div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-10 medium-10 small-1 cell">
                        <input name="consenso" id="consenso" type="checkbox" required="required" checked="checked" />
                        <span class="form-error">Obbligatorio</span>
                      </div>
											<div class="large-2 medium-2 small-11 cell">
												<p><label for="privacy"><a href="/contenuto.aspx?CMSContenuti_Ky=4">Accetto il trattamento dei miei dati personali ed ho letto l'informativa privacy</a></label></p>
											</div>
										</div>
										<div class="grid-x grid-padding-x">
											<div class="large-12 medium-12 small-12 cell text-center">
												<button type="submit"class="button large radius success">Invia <i class="fa-duotone fa-envelope fa-fw fa-lg"></i></button>
											</div>
										</div>
									</fieldset>								
								</form>							
							</div>
						</div>                
			</div>
    </div>
  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
	</body>
</html>
