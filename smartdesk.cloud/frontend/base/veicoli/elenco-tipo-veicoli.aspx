<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/frontend/base/veicoli/elenco-tipo-veicoli.aspx.cs" Inherits="_Default" Debug="true"%>
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
        <h1>Elenco tipo veicoli</h1>
        <div class="grid-x grid-padding-x grid-padding-y small-up-2 medium-up-4 large-up-4">
	        <% for (int xy = 0; xy < dtVeicoliTipo.Rows.Count; xy++){%>
           <div class="cell">
            <div class="card">
              <div class="card-divider text-center">
    					 <!--  <h2><a href="/<%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_UrlKey"].ToString()%>/<%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_UrlKey"].ToString()%>.html"><%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_Titolo"].ToString()%></h2></a> -->
    					 <h2><a href="/frontend/base/veicoli/elenco-categorie-veicoli.aspx?VeicoliTipo_Ky=<%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_Ky"].ToString()%>"><%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_Titolo"].ToString()%></h2></a>
              </div>
              <% 
              if (dtVeicoliTipo.Rows[xy]["VeicoliTipo_Foto"].ToString().Length>0){
                strFoto=dtVeicoliTipo.Rows[xy]["VeicoliTipo_Foto"].ToString();
              }else{
                strFoto="https://picsum.photos/seed/" + dtVeicoliTipo.Rows[xy]["VeicoliTipo_Ky"].ToString() + "/800/600.webp";
              } %>
              <a href="/frontend/base/veicoli/elenco-veicoli.aspx?VeicoliTipo_Ky=<%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_Ky"].ToString()%>"><img src="<%=strFoto%>" alt="<%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_Titolo"].ToString()%>" class="lazy" border="0" loading="lazy" /></a>
              <div class="card-section">
                <%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_Descrizione"].ToString()%>
                <%
          	    strWHERENet = "VeicoliTipo_Ky=" + dtVeicoliTipo.Rows[xy]["VeicoliTipo_Ky"].ToString();
                dtVeicoliCategoria = new System.Data.DataTable("VeicoliCategoria");
                dtVeicoliCategoria = Smartdesk.Sql.getTablePage("VeicoliCategoria", null, "VeicoliCategoria_Ky", strWHERENet, "VeicoliCategoria_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtVeicoliCategoria.Rows.Count>0){
                  Response.Write("<ul class=\"vertical\">");
        	        for (int iCategoria = 0; iCategoria < dtVeicoliCategoria.Rows.Count; iCategoria++){%>
            					<!-- <li><a href="/<%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_UrlKey"].ToString()%>/<%=dtVeicoliCategoria.Rows[iCategoria]["VeicoliCategoria_UrlKey"].ToString()%>/<%=dtVeicoliCategoria.Rows[iCategoria]["VeicoliCategoria_UrlKey"].ToString()%>.html"><%=dtVeicoliCategoria.Rows[iCategoria]["VeicoliCategoria_Titolo"].ToString()%></a></li> -->
            					<li><a href="/<%=dtVeicoliTipo.Rows[xy]["VeicoliTipo_urlKey"].ToString()%>/<%=dtVeicoliCategoria.Rows[iCategoria]["VeicoliCategoria_UrlKey"].ToString()%>.html"><%=dtVeicoliCategoria.Rows[iCategoria]["VeicoliCategoria_Titolo"].ToString()%></a></li>
        			    <% } 
                  Response.Write("</ul>");
                }%>
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
