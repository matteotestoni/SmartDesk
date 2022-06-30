<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="modifica-privacy.aspx.cs" Inherits="_Default" Debug="true"%>
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
					<div class="large-3 medium-3 small-12 cell">
            <!--#include file="/frontend/base/account/inc-sidebar.aspx"--> 
					</div>
          <div class="large-9 medium-9 small-12 cell">
							<h1>Consenso al trattamento dati</h1>
              <hr>
							<p>
								Spettabile Clietnte,<br><br>
								
								con la presente vi informiamo che attualmente la vs societ&agrave; &egrave; presente con uno o pi&ugrave; informazioni sui nostri sistemi.
							</p>
	            <form id="form-annunci" enctype="multipart/form-data" action="/frontend/base/account/form/salva-anagrafiche.aspx" method="post" data-abide novalidate>
              <input type="hidden" id="foo" name="foo" />
							<input type="hidden" name="proteggi" id="proteggi" value="">
              <input type="hidden" name="sorgente" id="sorgente" value="modifica-dati">
              <input type="hidden" name="azione" id="azione" value="modifica">
              <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=dtLogin.Rows[0]["Anagrafiche_Ky"].ToString()%>">
              <input type="hidden" name="Anagrafiche_EmailContatti" id="Anagrafiche_EmailContatti" value="<%=dtLogin.Rows[0]["Anagrafiche_EmailContatti"].ToString()%>">              
							<div class="grid-x grid-padding-x">
						  	<div class="large-12 medium-12 small-12 cell">
                  <h2>I tuoi dati</h2>
									<small><%=dtLogin.Rows[0]["AnagraficheTipologia_Titolo"].ToString()%></small><br>
                  <i class="fa-duotone fa-user fa-fw"></i><%=dtLogin.Rows[0]["Anagrafiche_Nome"].ToString()%> <%=dtLogin.Rows[0]["Anagrafiche_Cognome"].ToString()%><br>
                  <% if (dtLogin.Rows[0]["AnagraficheTipologia_Ky"].ToString()=="2"){%>
                  <i class="fa-duotone fa-users fa-fw"></i><%=dtLogin.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%><br>
                  <% } %>
							  </div>
						  </div>	
						  <hr>
							<% if (dtLogin.Rows[0]["Anagrafiche_Privacy"].Equals(true)){
							   	strChecked0="";
							   	strChecked1=" checked ";
								 }else{
							   	strChecked0=" checked ";
							   	strChecked1="";

								 }
							%>

						  <div class="grid-x grid-padding-x">
						  	<div class="large-12 medium-12 small-12 cell">
						  		<div class="text-left">
									<label for="Anagrafiche_Privacy" class="text-left">
						      <input type="radio" name="Anagrafiche_Privacy" id="Anagrafiche_Privacy1" title="Autorizzo" size="1" value="1" required="required" <%=strChecked1%>>
						      Autorizzo al trattamento dati
						      </label>
						      </div>
						  	</div>
						  </div>
						  <div class="grid-x grid-padding-x">
						  	<div class="large-12 medium-12 small-12 cell">
						  		<div class="text-left">
						  		<label for="Anagrafiche_Privacy" class="text-left">
						      <input type="radio" name="Anagrafiche_Privacy" id="Anagrafiche_Privacy0" title="NON Autorizzo" size="1" value="0" required="required" <%=strChecked0%>>
						      NON Autorizzo al trattamento dati
						      </label>
						      </div>
						  	</div>
						  </div>	
		
						  <div class="grid-x grid-padding-x">
						  	<div class="large-12 medium-12 small-12 cell text-left">
              		<button type="submit" value="salva" name="salva" class="button large success"><i class="fa-duotone fa-save fa-lg fa-fw"></i>Salva</button>
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