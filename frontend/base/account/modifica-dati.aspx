<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="modifica-dati.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<!--[if IE 9]><html class="lt-ie10" lang="it"><![endif]-->
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
					<div class="large-3 medium-3 small-12 cell">
            <!--#include file="/frontend/base/account/inc-sidebar.aspx"--> 
					</div>
          <div class="large-9 medium-9 small-12 cell">
							<h1>Modifica i tuoi dati</h1>
              <hr>
	            <form id="form-annunci" enctype="multipart/form-data" action="/frontend/base/account/form/salva-anagrafiche.aspx" method="post" data-abide novalidate>
              <input type="hidden" id="foo" name="foo" />
              <input type="hidden" name="sorgente" id="sorgente" value="modifica-dati">
              <input type="hidden" name="azione" id="azione" value="modifica">
              <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=dtLogin.Rows[0]["Anagrafiche_Ky"].ToString()%>">
              <input type="hidden" name="Anagrafiche_EmailContatti" id="Anagrafiche_EmailContatti" value="<%=dtLogin.Rows[0]["Anagrafiche_EmailContatti"].ToString()%>">              
							<input type="hidden" name="proteggi" id="proteggi" value="">
							<div class="grid-x grid-padding-x">
						  	<div class="large-2 medium-2 small-4 cell">
						  		<label for="Anagrafiche_RagioneSociale" class="large-text-right small-text-left middle">I tuoi dati <i class="fa-duotone fa-user fa-fw"></i></label>
						  	</div>
						  	<div class="large-10 medium-10 small-8 cell">
                  <small><%=dtLogin.Rows[0]["AnagraficheTipologia_Titolo"].ToString()%></small><br>
                  <i class="fa-duotone fa-user fa-fw"></i><%=dtLogin.Rows[0]["Anagrafiche_Nome"].ToString()%> <%=dtLogin.Rows[0]["Anagrafiche_Cognome"].ToString()%><br>
                  <% if (dtLogin.Rows[0]["AnagraficheTipologia_Ky"].ToString()=="2"){%>
                  <i class="fa-duotone fa-users fa-fw"></i><%=dtLogin.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%><br>
                  <% } %>
							  </div>
						  </div>	

						  <div class="grid-x grid-padding-x">
						  	<div class="large-2 medium-2 small-4 cell">
						  		<label for="Anagrafiche_Indirizzo" class="large-text-right small-text-left middle">Indirizzo* <i class="fa-duotone fa-location-dot fa-fw"></i></label>
						  	</div>
						  	<div class="large-10 medium-10 small-8 cell">
						      <input type="text" name="Anagrafiche_Indirizzo" id="Anagrafiche_Indirizzo" title="Indirizzo" size="150" value="<%=GetFieldValue(dtLogin, "Anagrafiche_Indirizzo")%>" required="required">
						      <span class="form-error">Obbligatorio</span>
						  	</div>
						  </div>	
						  	
						  <div class="grid-x grid-padding-x">
						  	<div class="large-2 medium-2 small-4 cell">
						  		<label for="Anagrafiche_Telefono" class="large-text-right small-text-left middle">Telefono <i class="fa-duotone fa-phone fa-fw"></i></label>
						  	</div>
						  	<div class="large-10 medium-10 small-8 cell">
						      <input type="text" name="Anagrafiche_Telefono" id="Anagrafiche_Telefono" title="Anagrafiche_Telefono" value="<%=GetFieldValue(dtLogin, "Anagrafiche_Telefono")%>" size="60">
						      <span class="form-error">Obbligatorio</span>
						  	</div>
						  </div>
						  <div class="grid-x grid-padding-x">
						  	<div class="large-10 large-offset-2 medium-12 small-12 cell">
                  <div data-abide-error class="alert callout">
  							    <p><i class="fa-duotone fa-exclamation-triangle fa-fw"></i>Attenzione: controlla di aver compilato correttamente tutti i campi.</p>
  								</div>
						  	</div>
						  </div>
              
						  <div class="grid-x grid-padding-x">
						  	<div class="large-12 medium-12 small-12 cell large-centered">
                  	<div class="text-center align-center">
                    <button type="submit" value="salva" name="salva" class="button large success"><i class="fa-duotone fa-save fa-lg fa-fw"></i>Salva</button>
                    </div>
						  	</div>
						  </div>
              
              </form>
					</div>
			</div>
		</div>
		<!-- #include file ="/frontend/base/inc-footer.aspx" -->
		<!-- #include file ="/frontend/base/inc-foot.aspx" -->
	</body>
</html>			