<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/frontend/base/annunci/elenco-annunci-categorie.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
   	<title>Categorie annunci</title>
  	<meta name="description" content="Home"/>
		<meta name="robots" content="index,follow">
  	<!-- #include file ="/frontend/base/inc-head.aspx" -->
  </head>
  <body>
	<!-- #include file ="/frontend/base/inc-header.aspx" -->
     <div class="grid-x grid-padding-x">
			<aside class="large-3 medium-3 small-12 medium-order-1 cell cellzero">
				<div id="sidebar" class="sidebar">
					<!-- #include file ="/frontend/base/annunci/inc-elenco-annunci-sidebar.aspx" -->
				</div>
			</aside>
      <div class="large-9 medium-9 small-12 cell">
        <h1>Elenco categorie dei prodotti disponibili</h1>
        <hr>
        <div class="grid-x grid-padding-x small-up-2 medium-up-3 large-up-4 elencocategorie">
	        <% for (int xy = 0; xy < dtAnnunciCategorie.Rows.Count; xy++){%>
          <div class="column single-cat"> 
            <a href="/frontend/base/annunci/elenco-annunci.aspx?search=&AnnunciCategorie_Ky=<%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Ky"].ToString()%>">
              <%
              strTemp=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Foto"].ToString();
              if (strTemp.Length>0){
              %>
              <img src="<%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Foto"].ToString()%>" alt="<%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Titolo"].ToString()%>" border="0" />
              <% }else{ %>
              <img src="/img/no-image-400x300.jpg" alt="<%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Titolo"].ToString()%>" border="0" width="300" height="150" style="width:300px;height:150px" />
              <% } %>
            </a>
            <span class="etichetta-cat-in-evidenza"><%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Titolo"].ToString()%></span>
          </div>
			    <% } %>
        </div>
      </div>                
   	</div>
 	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
