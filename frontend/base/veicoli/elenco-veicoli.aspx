<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="elenco-veicoli.aspx.cs" Inherits="_Default" Debug="false"%>
<!doctype html>
<html class="no-js" lang="it">
<head>
	<meta charset="utf-8" />
	<title><%=strMetaTitle%></title>
	<meta name="description" content="<%=strMetaDescription%>"/>
	<meta property="og:title" content="<%=strMetaTitle%>" />
	<meta property="og:description" content="<%=strMetaDescription%>" />
	<!-- #include file ="/frontend/base/inc-head.aspx" -->
	<style type="text/css">
  	header {
  		margin-bottom: 0;
  	}
	</style>
</head>
<body itemscope="" itemtype="https://schema.org/WebPage">
	<!--#include file="/frontend/base/inc-header.aspx"-->
	<% if (strVeicoliModello_Ky!=null && strVeicoliModello_Ky.Length>1){ %>
	<div class="grid-container">
		<div class="grid-x grid-padding-x">
			<div class="large-12 medium-12 small-12 cell">
				<nav role="navigation">
					<ul class="breadcrumbs">
						<li><a href="/home.aspx">Home</a></li>
						<% if (dtVeicoliCategoriaCorrente!=null && dtVeicoliCategoriaCorrente.Rows.Count>0){ %>
                            <li><a href="/auto/auto-<%=dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_UrlKey"].ToString().ToLower()%>.html"><%=dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_Descrizione"].ToString().ToLower()%></a></li>
    						<% if (dtVeicoliMarcaCorrente!=null && dtVeicoliMarcaCorrente.Rows.Count>0){ %>
                                <li><a href="/auto/<%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString().ToLower()%>-<%=dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_UrlKey"].ToString().ToLower()%>.html"><%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString().ToLower()%> <%=dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_DescrizioneWEB"].ToString().ToLower()%></a></li>
                            <% } %>
                        <% }else{ %>
    						<% if (dtVeicoliMarcaCorrente!=null && dtVeicoliMarcaCorrente.Rows.Count>0){ %>
                                <li><a href="/auto/<%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString().ToLower()%>.html"><%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString().ToLower()%></a></li>
                            <% } %>

                        <% } %>
						<li><span class="current"><%=strMetaTitle%></span></li>
					</ul>
				</nav>
			</div>
		</div>
	</div>
	<% } %>

	<div class="grid-container">
		<div class="grid-x grid-padding-x">
			<aside class="large-3 medium-12 small-12 cell ">
				<!--#include file="/frontend/base/veicoli/inc-sidebar-veicoli.aspx"-->
		  </aside>
			<div class="large-9 medium-12 small-12 cell main">
					<h1><%=strH1%></h1>
          <hr>
					<% if (Request["fromricerca"]==null){ %>
					<div class="text-justify"><%=strP1%></div>
					<% } %>
    
        			
	                <% if (strVeicoliModello_Ky!=null && strVeicoliModello_Ky.Length>1 && (strVeicoliCategoria_Ky==null || strVeicoliCategoria_Ky.Length<1)){ %>
          				<ul class="menu">
                      	     <li><a href="/auto/<%=dtVeicoliModelloCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString()%>/<%=dtVeicoliModelloCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString()%>-<%=dtVeicoliModelloCorrente.Rows[0]["VeicoliModello_UrlKey"].ToString()%>-usata.html"><%=dtVeicoliModelloCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%> <%=dtVeicoliModelloCorrente.Rows[0]["VeicoliModello_Titolo"].ToString()%> usata <i class="fa-duotone fa-angle-right fa-fw"></i></a></li>
                      	     <li><a href="/auto/<%=dtVeicoliModelloCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString()%>/<%=dtVeicoliModelloCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString()%>-<%=dtVeicoliModelloCorrente.Rows[0]["VeicoliModello_UrlKey"].ToString()%>-km-0.html"><%=dtVeicoliModelloCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%> <%=dtVeicoliModelloCorrente.Rows[0]["VeicoliModello_Titolo"].ToString()%> km 0 <i class="fa-duotone fa-angle-right fa-fw"></i></a></li>
          				</ul>
                    <% } %>
                    
                    <% if (strVeicoliCategoria_Ky!=null && strVeicoliCategoria_Ky.Length>0 && (strVeicoliMarca_Ky==null || strVeicoliMarca_Ky.Length<1) && (strFromRewrite!=null && strFromRewrite.Length>0)){ %>
    				    <h5>SELEZIONA LA MARCA DEL VEICOLO</h5>
                    	<div class="grid-container">
                    		<div class="grid-x grid-padding-x">
                    			<div class="large-12 medium-12 small-12 cell">
                    				<ul class="menu">
                    					<%
                    					for (i = 0; i < dtVeicoliMarca.Rows.Count; i++){
                        					if (dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString()!=strTemp){
                            					strMarcaUrl=dtVeicoliMarca.Rows[i]["VeicoliMarca_UrlKey"].ToString().ToLower();
                            					strUrl="<li><a title=\"" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_UrlKey"].ToString() + "\" href=\"/auto/" + strMarcaUrl + "-" + dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_UrlKey"].ToString() + ".html\">";
                                                strUrl+="<img class=\"item-auto-brand\" src=\"https://cdn.spaziogroup.com/spazio2019/img/marchi/48x48/logo-" + strMarcaUrl + ".png\" alt=\"" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_UrlKey"].ToString() + "\" loading=\"lazy\">";
                            					strUrl+="</a></li>";
                                                
                                                Response.Write(strUrl);
                        					}
                        					strTemp=dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString();
                    					}
                    					%>
                    				</ul>
                                </div>
                            </div>
                       </div>
                    <% } %>
        			<% if (strVeicoliMarca_Ky!=null && strVeicoliMarca_Ky.Length>0 && (strVeicoliModello_Ky==null || strVeicoliModello_Ky.Length<1)){ %>
                        <% if (dtVeicoliMarcaCorrente!=null && dtVeicoliMarcaCorrente.Rows.Count>0){ %>
                        <h5>MODELLI DI AUTO <%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%></h5>
                        <% } %>
          				<ul class="menu">
                            <% if (strVeicoliCategoria_Ky==null || strVeicoliCategoria_Ky.Length<1){ %>
                    					<li><a href="/auto/<%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString()%>-nuova.html" title="<%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%> usate"><%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%> nuova <i class="fa-duotone fa-angle-right fa-fw"></i></a></li>
                    					<li><a href="/auto/<%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString()%>-usata.html" title="<%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%> usate"><%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%> usate <i class="fa-duotone fa-angle-right fa-fw"></i></a></li>
                    					<li><a href="/auto/<%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_UrlKey"].ToString()%>-km-0.html" title="<%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%> km 0"><%=dtVeicoliMarcaCorrente.Rows[0]["VeicoliMarca_Titolo"].ToString()%> km 0 <i class="fa-duotone fa-angle-right fa-fw"></i></a></li>
                            <% } %>
          					<%
                              if (strVeicoliCategoria_Ky!=null && strVeicoliCategoria_Ky.Length>0){
              					strTemp="";
                        for (i = 0; i < dtVeicoloModello2.Rows.Count; i++){
                  					if (dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString()!=strTemp){
                      					strMarcaUrl=dtVeicoloModello2.Rows[i]["VeicoliMarca_UrlKey"].ToString().ToLower();
                      					strModelloUrl=dtVeicoloModello2.Rows[i]["VeicoliModello_UrlKey"].ToString().Replace(" ","-").Replace("(","").Replace(")","-").ToLower();
                      					strUrl="<li><a href=\"/auto/" + strMarcaUrl + "/" + strMarcaUrl + "-" + strModelloUrl + "-" + dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_UrlKey"].ToString() + ".html\">" + dtVeicoloModello2.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString() + " " + dtVeicoliCategoriaCorrente.Rows[0]["VeicoliCategoria_DescrizioneWEB"].ToString() + " <i class=\"fa-duotone fa-angle-right fa-fw\"></i></a></li>";
                      					Response.Write(strUrl);
                  					}
                  					strTemp=dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString();
              					}
                              }else{
              					for (i = 0; i < dtVeicoloModello2.Rows.Count; i++){
                  					if (dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString()!=strTemp){
                      					strMarcaUrl=dtVeicoloModello2.Rows[i]["VeicoliMarca_UrlKey"].ToString().ToLower();
                      					strModelloUrl=dtVeicoloModello2.Rows[i]["VeicoliModello_UrlKey"].ToString().Replace(" ","-").Replace("(","").Replace(")","-").ToLower();
                      					strUrl="<li><a href=\"/auto/" + strMarcaUrl + "/" + strMarcaUrl + "-" + strModelloUrl + ".html\">" + dtVeicoloModello2.Rows[i]["VeicoliMarca_Titolo"].ToString() + " " + dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString() + " <i class=\"fa-duotone fa-angle-right fa-fw\"></i></a></li>";
                      					Response.Write(strUrl);
                  					}
                  					strTemp=dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString();
              					}
                              }
          					%>
                          </ul>
                    <% } %>


 				<!--#include file="/frontend/base/veicoli/inc-elenco-veicoli.aspx"-->
			</div>
		</div>
	</div>
  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
</body>
</html>