<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="contenuto.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
	<head>
		<title>Categorie annunci</title>
  	<meta name="description" content="Categorie annunci"/>
		<meta name="robots" content="index,follow">
  	<!-- #include file ="/frontend/base/inc-head.aspx" -->
	</head>
	<body>
	<!-- #include file ="/frontend/base/inc-header.aspx" -->
		<div class="grid-container">
			<div class="grid-x grid-padding-x">
				<div class="large-12 xlarge-12 medium-12 small-12 cell">
					<h1>Annunci in vendita: scegli la categoria di tuo interesse</h1>
          <hr>
					<p>Seleziona la categoria dell'annuncio immobiliare di tuo interesse dall'elenco qui sotto.</p>
            <div class="categories">
            	<div class="grid-x grid-padding-x grid-padding-y small-up-2 medium-up-4 large-up-4" data-equalizer="annuncicategorie">
            		<% 
            			string strFoto="";
            			for (int xy = 0; xy < dtAnnunciCategorie.Rows.Count; xy++){
            			if (dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Foto"].ToString().Length>0){
            				strFoto=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Foto"].ToString();	
            			}else{
            				strFoto="https://static.pexels.com/photos/248064/pexels-photo-248064.jpeg";	
            			}
            			
            		%>
            			<div class="cell">
                    <div class="card" data-equalizer-watch="annuncicategorie">
                      <div class="card-divider">
            					 <h2 class="hero-box-title"><a href="/annunci/<%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Url"].ToString()%>.html"><%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Titolo"].ToString()%></h2></a>
                      </div>
                      <a href="/frontend/base/annunci/elenco-annunci.aspx?AnnunciCategorie_Ky=<%=dtAnnunciCategorie.Rows[xy]["AnnunciCategorie_Ky"].ToString()%>" class="lazyload" loading="lazy" data-bg="<%=strFoto%>"><img src="<%=strFoto%>"></a>
                    </div>
            			</div>
            		<% } %>
            	</div>
            </div>
				</div>                
			</div>
		</div>
 	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
	</body>
</html>
