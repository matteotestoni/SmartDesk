<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/frontend/base/aste/elenco-categorie-aste.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
		<title>Elenco categorie aste</title>
   	<meta name="description" content="Home"/>
		<meta name="robots" content="index,follow">
		<!-- #include file ="/frontend/base/inc-head.aspx" -->
  </head>
  <body>
	<!-- #include file ="/frontend/base/inc-header.aspx" -->
  <div class="grid-container">
     <div class="grid-x grid-padding-x">
     	<aside class="large-3 medium-4 small-12 cell hide-for-small-only"> 
  	     <!-- #include file ="/frontend/base/aste/inc-elenco-aste-sidebar.inc" -->
      </aside> 
      <main class="large-9 medium-8 small-12 cell">
        <h1>Categorie aste disponibili</h1>
        <hr>
        <div class="grid-x grid-padding-x grid-padding-y small-up-2 medium-up-3 large-up-4" data-equalizer="astecategorie">
	        <% for (int xy = 0; xy < dtAsteCategorie.Rows.Count; xy++){%>
           <div class="cell">
            <div class="card" data-equalizer-watch="astecategorie">
              <div class="card-divider text-center">
    					 <h2 class="subheader"><a href="/aste/<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Url"].ToString()%>/<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Url"].ToString()%>.html"><%=dtAsteCategorie.Rows[xy]["AsteCategorie_Titolo"].ToString()%></a></h2>
              </div>
              <a href="/aste/<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Url"].ToString()%>/<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Url"].ToString()%>.html">
              <%
              strTemp=dtAsteCategorie.Rows[xy]["AsteCategorie_Foto"].ToString();
              if (strTemp.Length>0){
              %>
              <img src="<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Foto"].ToString()%>" alt="<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Titolo"].ToString()%>" width="100%" border="0" />
              <% }else{ %>
              <img src="/img/no-image-300x150.jpg" alt="<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Titolo"].ToString()%>" border="0" width="300" height="150" style="width:300px;height:150px" />
              <% } %>
              </a>
              <div class="card-section text-center">
                <a href="/aste/<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Url"].ToString()%>/<%=dtAsteCategorie.Rows[xy]["AsteCategorie_Url"].ToString()%>.html" class="button tiny">Visualizza</a>
              </div>
            </div>
          </div>
			    <% } %>
        </div>
      </main>                
   	</div>
    </div>
  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
