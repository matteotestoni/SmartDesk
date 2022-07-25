<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/annunci/scheda-annunci.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Annunci > Scheda annuncio</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script src="//cdn.ckeditor.com/4.19.1/full/ckeditor.js"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.min.css" integrity="sha512-H9jrZiiopUdsLpg94A333EfumgUBpO9MdbxStdeITo+KEIMaNfHNvwyjjDJb+ERPaRS6DpyRlKbvPUasNItRyw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
  <script src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.min.js" integrity="sha512-uURl+ZXMBrF4AwGaWmEetzrd+J5/8NRkWAvJx5sbPSSuOb0bZLqf+tOzniObO00BjHa/dD7gub9oCGMLPQHtQA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 

<form id="form-annunci" enctype="multipart/form-data" action="/admin/app/annunci/crud/salva-annunci.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-bullhorn fa-lg fa-fw"></i><%=strH1%>: 
            	<i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAnnunci, "Annunci_Ky")%>
              <% if (strAste_Ky!=null && strAste_Ky.Length>0 && strAste_Ky!="0"){ %>
            	 - Asta <span class="badge large secondary"><%=dtAste.Rows[0]["Aste_Numero"].ToString()%></span>
            	<% } %>
            </h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/app/annunci/elenco-annunci.aspx?CoreModules_Ky=3&CoreEntities_Ky=48&CoreGrids_Ky=42" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna ad elenco annunci</a>
              <% if (strAste_Ky!=null && strAste_Ky.Length>0 && strAste_Ky!="0"){ %>
      				<a href="/admin/app/aste/scheda-aste.aspx?Aste_Ky=<%=strAste_Ky%>" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'asta</a>
      				<% } %>
      		    <% if (boolAdmin && strAzione!="new"){ %>
      				<a href="/admin/app/annunci/report/rpt-annunci.aspx?Annunci_Ky=<%=GetFieldValue(dtAnnunci, "Annunci_Ky")%>" class="button clear" target="_blank"><i class="fa-duotone fa-print fa-fw"></i>Stampa</a>
      		    <% } %>
              <% if (strAzione!="new"){ %>
      				<a href="/admin/app/annunci/scheda-annunci.aspx?azione=new&Aste_Ky=<%=strAste_Ky%>" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
      				<% } %>
            	<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
      			</div>
  	      </div>
      </div>
  </div>
</div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
        <input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="Annunci_Ky" id="Annunci_Ky" value="<%=GetFieldValue(dtAnnunci, "Annunci_Ky")%>">
        <input type="hidden" name="Aste_Ky" id="Aste_Ky" value="<%=GetFieldValue(dtAnnunci, "Aste_Ky")%>">
  	    <input type="hidden" name="numerofoto" id="numerofoto" value="<%=GetFieldValue(dtAnnunci, "Annunci_NumeroFoto")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
        <!--#include file=/admin/app/annunci/forms/annunci_form.htm -->
      </div>
    </div>
  </div>
</form>    



<br>
<!--#include file=/admin/app/annunci/scheda-annunci-foto.inc -->
<!--#include file=/admin/app/annunci/scheda-annunci-files.inc -->
<% if (strAzione!="new" && dtAste!=null && dtAste.Rows.Count>0){
	if (GetFieldValue(dtAste, "AsteNatura_Ky")=="1"){ %>
		<!--#include file=/admin/app/annunci/scheda-annunci-offerte.inc -->
<% }
 } %>
<!--#include file=/admin/inc-footer.aspx -->
<script>
	jQuery("[data-fancybox]").fancybox({
  	thumbs : {
  		autoStart : true,
      infobar : true,
      lang : 'it'
  	}
  });
</script>
</body>
</html>
