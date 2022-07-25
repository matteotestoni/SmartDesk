<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="area-personale.aspx.cs" Inherits="_Default" Debug="false"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
	<head>
  	<title><%=strH1%></title>
    <meta name="description" content="<%=strH1%>"/>
    <meta name="robots" content="noindex,nofollow">
    <!--#include file="/frontend/base/inc-head.aspx"--> 
	</head>
	<body>
		<!-- #include file ="/frontend/base/inc-header.aspx" -->
		<div class="grid-container">
          <div class="grid-x grid-padding-x">
						<div class="large-3 medium-3 small-12 cell">
              <!--#include file="/frontend/base/account/inc-sidebar.aspx"--> 
						</div>
            <div class="large-9 medium-9 small-12 cell">
            	<h1>I miei dati</h1>
              <hr>
    					<div class="grid-x grid-padding-x">
    						<div class="large-12 medium-12 small-12 cell">
       	        <div class="grid-x grid-padding-x">
      	          <div class="large-6 medium-6 small-12 cell">
                     <p>
                      <%=dtLogin.Rows[0]["AnagraficheTipologia_Titolo"].ToString()%><br>
                      <i class="fa-duotone fa-user fa-fw"></i><%=dtLogin.Rows[0]["Anagrafiche_Nome"].ToString()%> <%=dtLogin.Rows[0]["Anagrafiche_Cognome"].ToString()%><br>
                      <% if (dtLogin.Rows[0]["AnagraficheTipologia_Ky"].ToString()=="2"){%>
                      <i class="fa-duotone fa-users fa-fw"></i><%=dtLogin.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%><br>
                      <% } %>
                      <i class="fa-duotone fa-map-marker fa-fw"></i><%=dtLogin.Rows[0]["Anagrafiche_Indirizzo"].ToString()%><br>
                      <i class="fa-duotone fa-user fa-fw"></i><%=dtLogin.Rows[0]["Comuni_Comune"].ToString()%> (<%=dtLogin.Rows[0]["Province_Provincia"].ToString()%>)<br>
                      <i class="fa-duotone fa-phone-square fa-fw"></i><%=dtLogin.Rows[0]["Anagrafiche_Telefono"].ToString()%><br>
                      <i class="fa-duotone fa-user-secret fa-fw"></i>
											<% if (dtLogin.Rows[0]["Anagrafiche_Privacy"].Equals(true)){
											   	Response.Write("Autorizzazione al trattamento dati accettata");
												 }else{
											   	Response.Write("Autorizzazione al trattamento dati NON accettata");
												 }
											%>
                    </p>
                    <a href="/account/modifica-dati.html" class="button small secondary"><i class="fa-duotone fa-edit fa-fw"></i>Modifica dati</a> 
                    <a href="/account/modifica-password.html" class="button small secondary"><i class="fa-duotone fa-key fa-fw"></i>Modifica password</a> 
                    <a href="/account/modifica-privacy.html" class="button small secondary"><i class="fa-duotone fa-edit fa-fw"></i>Modifica privacy</a>
                </div>
    	          <div class="large-6 medium-6 small-12 cell">
                    <p>
                      <% 
                      for (int i = 0; i < dtAnagraficheServizi.Rows.Count; i++){
                        Response.Write("<i class=\"fa-duotone fa-table fa-fw\"></i>" + dtAnagraficheServizi.Rows[i]["Servizi_Titolo"].ToString() + "<br>");  
                      } 
                      %>
                    </p>
                </div>
              </div>
              <!-- #include file ="/frontend/base/account/areapersonale/inc-elenco-annunci.inc" -->
              <!-- #include file ="/frontend/base/account/areapersonale/inc-elenco-cauzioni.inc" -->
              <!-- #include file ="/frontend/base/account/areapersonale/inc-elenco-aste-wishlist.inc" -->
              <!-- #include file ="/frontend/base/account/areapersonale/inc-elenco-lotti-wishlist.inc" -->
              <!-- #include file ="/frontend/base/account/areapersonale/inc-elenco-annunci-wishlist.inc" -->
            
						</div>                
					</div>
        </div>
      </div>
    </div>
		<!-- #include file ="/frontend/base/inc-footer.aspx" -->
		<!-- #include file ="/frontend/base/inc-foot.aspx" -->
	</body>
</html>