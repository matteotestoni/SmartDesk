<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/frontend/base/veicoli/elenco-categorie-veicoli.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
<head>
	<title><%=strTitle%></title>
 	<meta name="description" content="<%=strMetaDescription%>"/>
  <meta name="og:description" content="<%=strMetaDescription%>" />
	<meta name="robots" content="index,follow">
	<!-- #include file ="/frontend/base/inc-head.aspx" -->
</head>
<body>
  <!--#include file="/frontend/base/inc-tagmanager.aspx"-->
  <!--#include file="/frontend/base/inc-header.aspx"-->
  <div class="grid-container">
     <div class="grid-x grid-padding-x">
      <div class="large-12 medium-12 small-12 cell">
        <h1>Elenco Categoria veicoli</h1>
        <div class="grid-x grid-padding-x grid-padding-y small-up-2 medium-up-5 large-up-5">
	        <% for (int xy = 0; xy < dtVeicoliCategoria.Rows.Count; xy++){%>
           <div class="cell">
            <div class="card">
              <div class="card-divider">
    					 <!-- <h2><a href="/<%=dtVeicoliCategoria.Rows[xy]["VeicoliTipo_UrlKey"].ToString()%>/<%=dtVeicoliCategoria.Rows[xy]["VeicoliCategoria_UrlKey"].ToString()%>.html"><%=dtVeicoliCategoria.Rows[xy]["VeicoliCategoria_Descrizione"].ToString()%></h2></a> -->
    					 <h2><a href="/frontend/base/veicoli/elenco-veicoli.aspx?VeicoliCategoria_Ky=<%=dtVeicoliCategoria.Rows[xy]["VeicoliCategoria_Ky"].ToString()%>&VeicoliTipo_Ky=<%=dtVeicoliCategoria.Rows[xy]["VeicoliTipo_Ky"].ToString()%>"><%=dtVeicoliCategoria.Rows[xy]["VeicoliCategoria_Descrizione"].ToString()%></h2></a>
              </div>
              <% 
              if (dtVeicoliCategoria.Rows[xy]["VeicoliCategoria_Foto"].ToString().Length>0){
                strFoto=dtVeicoliCategoria.Rows[xy]["VeicoliCategoria_Foto"].ToString();
              }else{
                strFoto="https://via.placeholder.com/400x300.webp?text=nessun+immagine";
              } %>
              <a href="/frontend/base/veicoli/elenco-veicoli.aspx?VeicoliCategoria_Ky=<%=dtVeicoliCategoria.Rows[xy]["VeicoliCategoria_Ky"].ToString()%>"><img src="<%=strFoto%>" alt="<%=dtVeicoliCategoria.Rows[xy]["VeicoliCategoria_Descrizione"].ToString()%>" class="lazy" border="0" loading="lazy" /></a>
              <div class="card-section">
              </div>
            </div>
          </div>
			    <% } %>
        </div>
      </div>                
   	</div>
    </div>
  	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
  	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
