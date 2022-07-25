<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-Servizi.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Catalogo > Scheda servizio</title>
  <!--#include file="/admin/inc-head.aspx"-->
	<script src="//cdn.ckeditor.com/4.19.1/full/ckeditor.js"></script>
</head>
<body class="bg-body">
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-servizi" action="/admin/app/catalogo/crud/salva-servizi.aspx" method="post" class="needs-validation" novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-cube fa-lg fa-fw"></i>Scheda servizio:<span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtServizi, "Servizi_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/app/catalogo/scheda-servizi.aspx?azione=new" class="button btn"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
      	        <button type="submit" value="salva" name="salva" class="button btn success btn-success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
      			</div>
  	      </div>
      </div>
  </div>
</div>
<div class="container px-4">
  <div class="row">
    <div class="large-12 medium-12 small-12 cell">
  	 <div class="divform">  
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
  	  	<input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
        <input type="hidden" name="Servizi_Ky" id="Servizi_Ky" value="<%=GetFieldValue(dtServizi, "Servizi_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
   			<!--#include file=/admin/app/catalogo/forms/servizi_form.htm -->
     </div>
    </div>
  </div>
</div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
 
