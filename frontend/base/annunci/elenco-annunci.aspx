<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="/frontend/base/annunci/elenco-annunci.aspx.cs" Inherits="_Default" Debug="true"%>
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
		<div class="grid-container" id="maincontainer">
				<div class="grid-x grid-padding-x">
          <hr style="margin: 0px 0 20px 0">
      	</div>
        <div class="grid-x grid-padding-x">
          	<div class="large-8 medium-8 small-12 cell medium-order-2" id="main">
              <h2><b>Elenco Annunci</b> on line</h2>
              <hr class="linea-blu"/>
              <% if ((dtBannerTop1!=null && dtBannerTop1.Rows.Count>0) || (dtBannerTop2!=null && dtBannerTop2.Rows.Count>0)) { %>
				<% 
				if (dtBannerTop1!=null && dtBannerTop1.Rows.Count>0){
						for (int i = 0; i < dtBannerTop1.Rows.Count; i++){
							%>
							<div class="callout"><a href="<%=dtBannerTop1.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank" rel="nofollow" onclick="bannerClick(<%=dtBannerTop1.Rows[i]["CMSAds_Ky"].ToString()%>)"><img src="<%=dtBannerTop1.Rows[i]["CMSAds_Foto"].ToString()%>" vspace="20"></a></div>
						<% } 
				}
				%>
				
				<% 
				if (dtBannerTop2!=null && dtBannerTop2.Rows.Count>0){
					for (int i = 0; i < dtBannerTop2.Rows.Count; i++){
						%>
						<div class="callout"><a href="<%=dtBannerTop2.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank" rel="nofollow" onclick="bannerClick(<%=dtBannerTop2.Rows[i]["CMSAds_Ky"].ToString()%>)"><img src="<%=dtBannerTop2.Rows[i]["CMSAds_Foto"].ToString()%>" vspace="20"></a></div>
					<% } 
				} %>
              	<hr class="linea-blu"/>
              <% } %>
            	<!-- #include file ="/frontend/base/annunci/inc-elenco-annunci.aspx" -->
              <% if ((dtBannerBottom1!=null && dtBannerBottom1.Rows.Count>0) || (dtBannerBottom2!=null && dtBannerBottom2.Rows.Count>0)) { %>
              <hr class="linea-blu"/>
							<div class="callout">
								<% 
								if (dtBannerBottom1!=null && dtBannerBottom1.Rows.Count>0){
									for (int i = 0; i < dtBannerBottom1.Rows.Count; i++){
									%>
									<div class="banner"><a href="<%=dtBannerBottom1.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank" rel="nofollow" onclick="bannerClick(<%=dtBannerBottom1.Rows[i]["CMSAds_Ky"].ToString()%>)"><img src="<%=dtBannerBottom1.Rows[i]["CMSAds_Foto"].ToString()%>" vspace="20"></a></div>
								  <%
									} 
								}
								%>
								<% 
								if (dtBannerBottom2!=null && dtBannerBottom2.Rows.Count>0){
									for (int i = 0; i < dtBannerBottom2.Rows.Count; i++){
										%>
										<div class="banner"><a href="<%=dtBannerBottom2.Rows[i]["CMSAds_Url"].ToString()%>" target="_blank" rel="nofollow" onclick="bannerClick(<%=dtBannerBottom2.Rows[i]["CMSAds_Ky"].ToString()%>)"><img src="<%=dtBannerBottom2.Rows[i]["CMSAds_Foto"].ToString()%>" vspace="20"></a></div>
									<% }
								}
								%>
							</div>
            	<% } %>
			</div>                           
			<aside class="large-4 medium-4 small-12 medium-order-1 cell cellzero">
				<div id="sidebar" class="sidebar">
					<!-- #include file ="/frontend/base/annunci/inc-elenco-annunci-sidebar.aspx" -->
				</div>
			</aside>
         </div>
       <p class="hide-for-small-only"><br><br></p> 
					<div class="js-off-canvas-exit"></div>
        </div>



 	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>

