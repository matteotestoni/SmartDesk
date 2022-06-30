<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="visualizza-categoria.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
    <title><%=strMetaTitle%></title>
    <meta name="description" content="<%=strMetaDescription%>"/>
    <meta name="robots" content="index,follow">
  	<!-- #include file ="/frontend/base/inc-head.aspx" -->
    <style>
			.callout-scheda-foto {
			    padding: 0;
			    border: 0;
			    border-radius: 0;
			    color: #0a0a0a;
			    background-repeat: no-repeat;
			    background-position: center;
			}
			div.sfumatura-foto {
			    position: absolute;
			    bottom: 0;
			    width: 100%;
			    height: 192px;
			    background: -moz-linear-gradient(top, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 1) 100%);
			    background: -webkit-linear-gradient(top, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 1) 100%);
			    background: linear-gradient(to bottom, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 1) 100%);
			    filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#000000', endColorstr='#000000', GradientType=0);
			}			
			span.aggiungiwishlist {
			    color: #fff;
			    border: 0;
			    height: 45px;
			    display: block;
			    position: absolute;
			    top: 5px;
			    left: 15px;
			    padding-top: 10px;
			    font-weight: 600;
			    text-align: center;
			}			
			
				@media screen and (min-width: 40em){
					.callout-scheda-foto {
					    position: relative;
					    margin: 2rem 0 1rem 0;
					    background-size: cover;
					    height: 520px !important;
					    max-height: 520px;
					}			
				}
    </style>
  </head>
  <body>
  	<!-- #include file ="/frontend/base/inc-header.aspx" -->
	<div class="grid-container">
		<div class="grid-x grid-padding-x">
          <hr style="margin: 0px 0 20px 0">
      	</div>
        <div class="grid-x grid-padding-x">
          	<div class="large-8 medium-8 small-12 cell medium-order-2 main" id="main">
              <h1><%=strH1%></h1>
              <small><%=dtAnnunciCategorieCorrente.Rows[0]["AnnunciCategorie_Descrizione"].ToString()%></small>
							<% if ((dtBannerTop1!=null && dtBannerTop1.Rows.Count>0) || (dtBannerTop2!=null && dtBannerTop2.Rows.Count>0)){ %>
							
								<% if (dtBannerTop1!=null && dtBannerTop1.Rows.Count>0){ %>
										<div class="callout">
											<span class="label">Pubblicit&agrave;</span>
											<% for (int i = 0; i < dtBannerTop1.Rows.Count; i++){ %>
												<a href="<%=dtBannerTop1.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank"><img src="<%=dtBannerTop1.Rows[i]["CMSAds_Foto"].ToString()%>"></a><hr>
											<% } %>
										</div>
								<% } %>
								
								<% if (dtBannerTop2!=null && dtBannerTop2.Rows.Count>0){ %>
									<div class="callout">
										<span class="label">Pubblicit&agrave;</span>
										<% for (int i = 0; i < dtBannerTop2.Rows.Count; i++){ %>
											<a href="<%=dtBannerTop2.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank"><img src="<%=dtBannerTop2.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
										<% } %>
									</div>
								<% } %>
							
              <hr class="linea-blu"/>
							<% } %>
				<h2>Annunci di <%=strH1%></h2>
            	<!-- #include file ="/frontend/base/annunci/inc-elenco-annunci.aspx" -->

							<% if ((dtBannerBottom1!=null && dtBannerBottom1.Rows.Count>0) || (dtBannerBottom2!=null && dtBannerBottom2.Rows.Count>0)){ %>
                <hr class="linea-blu"/>
  							
  								<% if (dtBannerBottom1!=null && dtBannerBottom1.Rows.Count>0){%>
									<div class="callout">
										<span class="label">Pubblicit&agrave;</span>
										<% for (int i = 0; i < dtBannerBottom1.Rows.Count; i++){ %>
											<a href="<%=dtBannerBottom1.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank"><img src="<%=dtBannerBottom1.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
										<% } %>
									</div>
  								<% } %>
  								<% if (dtBannerBottom2!=null && dtBannerBottom2.Rows.Count>0){ %>
									<div class="callout">
										<span class="label">Pubblicit&agrave;</span>
  										<% for (int i = 0; i < dtBannerBottom2.Rows.Count; i++){ %>
  										 <a href="<%=dtBannerBottom2.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank"><img src="<%=dtBannerBottom2.Rows[i]["CMSAds_Foto"].ToString()%>"></a>
									  	<% } %>
									</div>
  								<% } %>
							<% } %>
          	</div>                           
			<aside class="large-4 medium-4 small-12 cell medium-order-1 cellzero hide-for-small-only">
				<div id="sidebar" class="sidebar">
					<!-- #include file ="/frontend/base/annunci/inc-visualizzacategoria-sidebar.inc" -->
					<small><%=dtAnnunciCategorieCorrente.Rows[0]["AnnunciCategorie_DescrizioneSidebar"].ToString()%></small>
				</div>
			</aside>
		 </div>
	</div>
	<div class="testofooterseo">
		<div class="grid-container">
			<div class="grid-x grid-padding-x">
				<div class="large-12 medium-12 small-12 cell"> 		
				<%=dtAnnunciCategorieCorrente.Rows[0]["AnnunciCategorie_DescrizioneFooter"].ToString()%>
				</div>
			</div>  	
		</div>
	</div>
	<div class="js-off-canvas-exit"></div>
        
	</div>
 	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
