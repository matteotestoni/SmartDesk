<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/annunci/scheda-annuncimarca.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Annunci > Scheda marca</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
    <form id="form-annuncimarca" action="/admin/app/annunci/crud/salva-annuncimarca.aspx" method="post" data-abide novalidate>
      <div data-sticky-container>
        <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
            <div class="grid-x grid-padding-x align-middle">
                <div class="large-4 medium-4 small-12 cell align-middle">
                  <h1><i class="fa-duotone fa-globe fa-lg fa-fw"></i><%=strH1%>: 
                  	<i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAnnunciMarca, "AnnunciMarca_Ky")%>
                  </h1>
                </div>
                <div class="large-8 medium-8 small-12 cell float-right align-middle">
            			<div class="stacked-for-small button-group small hide-for-print align-right">
            				<a href="/admin/view.aspx?CoreModules_Ky=3&CoreEntities_Ky=53&CoreGrids_Ky=44" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
            				<a href="/admin/app/annunci/scheda-annuncimarca.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
                  	<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
            			</div>
        	      </div>
            </div>
        </div>
      </div>
      <div class="grid-container">
     		<div class="divform" id="divscheda" data-magellan-target="divscheda">
          <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
          <input type="hidden" name="AnnunciMarca_Ky" id="AnnunciMarca_Ky" value="<%=GetFieldValue(dtAnnunciMarca, "AnnunciMarca_Ky")%>">
          <!--#include file=/admin/forms_messaggi.inc -->
          <!--#include file=/admin/app/annunci/forms/annuncimarca_form.htm -->
      	</div>
      </div>
    	<!--#include file=/admin/app/annunci/scheda-annuncimarca-modelli.inc -->
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
